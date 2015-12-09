using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignedDistanceFieldGenerator
{
    struct Job
    {
        public int minX;
        public int minY;
        public int maxX;
        public int maxY;
    }

    public partial class SignedDistanceFieldForm : Form
    {

        #region Variables
        private string imgPath = "";

        private Bitmap loadedImage;

        private OpenFileDialog readDialog;
        private SaveFileDialog saveDialog;
        private int running;

        private const int jobsHorizontal = 10;
        private const int jobsVertical = 10;
        private int numCores = Environment.ProcessorCount;
        private const int jobsCount = jobsHorizontal * jobsVertical;
        private int jobMaxWidth = 0;
        private int jobMaxHeight = 0;
        private int currentJob = 0;
        static readonly object jobLocker = new object();
        private int radius = 0;
        bool hasAlpha = true;

        float maxValue = 0;
        float currentValue = 0;
        DateTime startTime;

        List<Job> Jobs = new List<Job>();

        #endregion

        public SignedDistanceFieldForm()
        {
            InitializeComponent();
            readDialog = new OpenFileDialog();
            readDialog.Title = "Load an Image";
            readDialog.Filter = "PNG|*.png";
            readDialog.InitialDirectory = @"C:\";

            saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG|*.png";

            running = 0;

            progress.Text = "Load a File";
        }

        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private Bitmap CopyToImage(ref byte[] pixelArray, ref Bitmap Image)
        {
            Bitmap clone = new Bitmap(Image.Width, Image.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            BitmapData imageData = clone.LockBits(new Rectangle(0, 0, clone.Width, clone.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);

            //copy the calculations into the out image
            IntPtr ptrFirstPixel = imageData.Scan0;
            Marshal.Copy(pixelArray, 0, ptrFirstPixel, pixelArray.Length);

            clone.UnlockBits(imageData);

            return clone;
        }

        private void GeneratePixelArray(ref Bitmap Image, out byte[] pixelArray, bool copy)
        {
            lock(jobLocker)
            {
                BitmapData imageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadOnly, Image.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(Image.PixelFormat) / 8;
                int byteCount = imageData.Stride * Image.Height;
                //create variables
                pixelArray = new byte[byteCount];

                if (copy)
                {
                    //Copy Data
                    IntPtr ptrFirstPixel = imageData.Scan0;
                    Marshal.Copy(ptrFirstPixel, pixelArray, 0, pixelArray.Length);
                }

                Image.UnlockBits(imageData);
            }
        }    

        private void SignedDistanceField(int sx, int sy, int ex, int ey, ref byte[] threadPixels, ref byte[] writePixels)
        {
            Color InColor = Color.FromArgb(255, colorBox.BackColor.R, colorBox.BackColor.G, colorBox.BackColor.B);

            for (int y = sy; y < ey; ++y)
            {
                for (int x = sx; x < ex; ++x)
                {
                    int idx = (x + (y * jobMaxWidth)) * 4;
                    Color InPixel = Color.FromArgb(threadPixels[idx + 3], threadPixels[idx], threadPixels[idx + 1], threadPixels[idx + 2]);

                    float distance = float.MaxValue;
                    bool IsIn = false;
                    //The Pixel is "In", so we calculate the Distance to the edge
                    if (InPixel == InColor)
                    {
                        IsIn = true;
                    }

                    int xMin = Math.Max(x - radius, 0);
                    int xMax = Math.Min(x + radius, jobMaxWidth);
                    int yMin = Math.Max(y - radius, 0);
                    int yMax = Math.Min(y + radius, jobMaxHeight);

                    //Now search in are around him
                    for (int y2 = yMin; y2 < yMax; ++y2)
                    {
                        for (int x2 = xMin; x2 < xMax; ++x2)
                        {
                            int idx2 = (x2 + (y2 * jobMaxWidth)) * 4;
                            Color OutPixel = Color.FromArgb(threadPixels[idx2 + 3], threadPixels[idx2], threadPixels[idx2 + 1], threadPixels[idx2 + 2]);
                            if (IsIn && OutPixel != InColor || !IsIn && OutPixel == InColor)
                            {
                                // Calculate distance
                                float xd = x - x2;
                                float yd = y - y2;
                                float d = (float)Math.Sqrt(Math.Abs((xd * xd) + (yd * yd)));

                                // Compare absolute distance values, and if smaller replace distnace with the new oe
                                if (d < distance)
                                {
                                    distance = d;
                                }
                            }


                        }
                    }

                    //If we found a new distance, otherwise we'll just use A 
                    float sAlpha = 0.0f;

                    if (distance != float.MaxValue)
                    {
                        if (distance > radius)
                            distance = radius;
                        sAlpha = (radius - distance) / (radius * 2);
                        if (IsIn)
                        {
                            sAlpha = 1.0f - sAlpha;
                        }
                    }
                    else
                    {
                        if (IsIn)
                        {
                            sAlpha = 1.0f;
                        }
                    }

                    // Write pixel out
                    byte outVal = (byte)(sAlpha * 255);
                    writePixels[idx] = 0;
                    writePixels[idx + 1] = 0;
                    writePixels[idx + 2] = 0;
                    writePixels[idx + 3] = outVal;

                    //Just for displaying where we are
                    currentValue++;
                }
            }
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void SeekJobs(ref byte[] resultPixels)
        {
            running++;
            byte[] threadPixels;
            GeneratePixelArray(ref loadedImage, out threadPixels, true);

            while (currentJob != jobsCount)
            {
                int cjob = Interlocked.Increment(ref currentJob);
                if (cjob != jobsCount)
                {
                    Job threadJob = Jobs[cjob];
                    Console.WriteLine(cjob);
                    SignedDistanceField(threadJob.minX, threadJob.minY, threadJob.maxX, threadJob.maxY, ref threadPixels, ref resultPixels);
                }
            }
            running--;
        }

        #region Button Clicks
        private void loadButton_Click(object sender, EventArgs e)
        {
            if (readDialog.ShowDialog() == DialogResult.OK)
            {
                imgPath = readDialog.FileName.ToString();
                loadedImage = new Bitmap(imgPath);
                loadedImage = loadedImage.Clone(new Rectangle(0, 0, loadedImage.Width, loadedImage.Height), PixelFormat.Format32bppArgb);
                //set display
                imgpath.Text = imgPath;
                imagebox.Image = loadedImage;
                imagebox.SizeMode = PictureBoxSizeMode.StretchImage;

                progressBar.Value = 0;
                progress.Text = "Start Generation";
            }
            else
            {
                MessageBox.Show("File could not be loaded.");
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (imgPath == "")
            {
                MessageBox.Show("You have to load an Image first.");
            }
            else if (running <= 0)
            {
                startTime = DateTime.Now;

                currentValue = 0;
                radius = searchRadius.Value;
                maxValue = loadedImage.Width * loadedImage.Height;
                jobMaxWidth = loadedImage.Width;
                jobMaxHeight = loadedImage.Height;

                int traceJobWidth = jobMaxWidth / jobsHorizontal;
                int traceJobHeight = jobMaxHeight / jobsVertical;

                Jobs.Clear();

                for (int y = 0; y < jobsVertical; ++y)
                {
                    for (int x = 0; x < jobsHorizontal; ++x)
                    {
                        Job job = new Job();
                        job.minX = (int)(x * traceJobWidth);
                        job.minY = (int)(y * traceJobHeight);
                        job.maxX = (int)(job.minX + traceJobWidth);
                        job.maxY = (int)(job.minY + traceJobHeight);
                        Jobs.Add(job);
                    }
                }

                int size = loadedImage.Width * loadedImage.Height * 4;
                byte[] resultPixels = new byte[size];

                Thread[] threads = new Thread[numCores];

                //Start Threads
                currentJob = -1;
                for (int x = 0; x < numCores; ++x)
                {
                    threads[x] = new Thread(() => SeekJobs(ref resultPixels));
                    threads[x].Start();
                }
                
                while(running != 0)
                {
                    if (currentJob > 0)
                    {
                        string txt = Convert.ToString(currentJob) + "/ " + Convert.ToString(jobsCount);
                        progress.Text = txt;
                        int progressValue = (int)(((double)currentJob / (double)jobsCount) * 100);
                        progressBar.Value = progressValue;
                    }
                    Application.DoEvents();
                }
                progressBar.Value = 100;

                loadedImage = CopyToImage(ref resultPixels, ref loadedImage);

                //set new image as display image
                imagebox.Image = loadedImage;
                progress.Text = "Generation complete.";

                //UpdateStatus(ref resultPixels);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (imgPath == "")
            {
                MessageBox.Show("You have to load an Image first.");
            }
            else
            {
                if (loadedImage != null && saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ResizeImage(loadedImage, (int)OutWidth.Value, (int)OutHeight.Value).Save(saveDialog.FileName);
                    MessageBox.Show("Image saved!");
                }
            }
        }

        private void colorBox_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.AnyColor = true;
            MyDialog.Color = colorBox.BackColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                colorBox.BackColor = MyDialog.Color;
            }
        }

        private void searchRadius_Scroll(object sender, EventArgs e)
        {
            Radius.Text = "" + searchRadius.Value;
        }

        #endregion
    }
}
