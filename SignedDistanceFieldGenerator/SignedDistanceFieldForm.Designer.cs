namespace SignedDistanceFieldGenerator
{
    partial class SignedDistanceFieldForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadButton = new System.Windows.Forms.Button();
            this.imgpath = new System.Windows.Forms.Label();
            this.imagebox = new System.Windows.Forms.PictureBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchRadius = new System.Windows.Forms.TrackBar();
            this.MinRadius = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Radius = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OutWidth = new System.Windows.Forms.NumericUpDown();
            this.OutHeight = new System.Windows.Forms.NumericUpDown();
            this.timeLeft = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imagebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 27);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // imgpath
            // 
            this.imgpath.AutoSize = true;
            this.imgpath.Location = new System.Drawing.Point(208, 86);
            this.imgpath.Name = "imgpath";
            this.imgpath.Size = new System.Drawing.Size(0, 13);
            this.imgpath.TabIndex = 1;
            // 
            // imagebox
            // 
            this.imagebox.Location = new System.Drawing.Point(211, 102);
            this.imagebox.Name = "imagebox";
            this.imagebox.Size = new System.Drawing.Size(249, 255);
            this.imagebox.TabIndex = 2;
            this.imagebox.TabStop = false;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(288, 402);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(102, 23);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(385, 27);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 448);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(448, 23);
            this.progressBar.TabIndex = 6;
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.Black;
            this.colorBox.Location = new System.Drawing.Point(46, 118);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(115, 50);
            this.colorBox.TabIndex = 7;
            this.colorBox.TabStop = false;
            this.colorBox.Click += new System.EventHandler(this.colorBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Inner Color";
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.Location = new System.Drawing.Point(13, 429);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(0, 13);
            this.progress.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Search Radius";
            // 
            // searchRadius
            // 
            this.searchRadius.LargeChange = 1;
            this.searchRadius.Location = new System.Drawing.Point(46, 249);
            this.searchRadius.Maximum = 100;
            this.searchRadius.Name = "searchRadius";
            this.searchRadius.Size = new System.Drawing.Size(115, 45);
            this.searchRadius.TabIndex = 14;
            this.searchRadius.Scroll += new System.EventHandler(this.searchRadius_Scroll);
            // 
            // MinRadius
            // 
            this.MinRadius.AutoSize = true;
            this.MinRadius.Location = new System.Drawing.Point(31, 249);
            this.MinRadius.Name = "MinRadius";
            this.MinRadius.Size = new System.Drawing.Size(13, 13);
            this.MinRadius.TabIndex = 15;
            this.MinRadius.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "100";
            // 
            // Radius
            // 
            this.Radius.AutoSize = true;
            this.Radius.Location = new System.Drawing.Point(94, 280);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(13, 13);
            this.Radius.TabIndex = 17;
            this.Radius.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Radius:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Height";
            // 
            // OutWidth
            // 
            this.OutWidth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.OutWidth.Location = new System.Drawing.Point(12, 333);
            this.OutWidth.Maximum = new decimal(new int[] {
            8096,
            0,
            0,
            0});
            this.OutWidth.Minimum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.OutWidth.Name = "OutWidth";
            this.OutWidth.Size = new System.Drawing.Size(64, 20);
            this.OutWidth.TabIndex = 23;
            this.OutWidth.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            // 
            // OutHeight
            // 
            this.OutHeight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.OutHeight.Location = new System.Drawing.Point(91, 333);
            this.OutHeight.Maximum = new decimal(new int[] {
            8096,
            0,
            0,
            0});
            this.OutHeight.Minimum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.OutHeight.Name = "OutHeight";
            this.OutHeight.Size = new System.Drawing.Size(64, 20);
            this.OutHeight.TabIndex = 24;
            this.OutHeight.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            // 
            // timeLeft
            // 
            this.timeLeft.AutoSize = true;
            this.timeLeft.Location = new System.Drawing.Point(12, 478);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.Size = new System.Drawing.Size(0, 13);
            this.timeLeft.TabIndex = 25;
            // 
            // SignedDistanceFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 513);
            this.Controls.Add(this.timeLeft);
            this.Controls.Add(this.OutHeight);
            this.Controls.Add(this.OutWidth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Radius);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MinRadius);
            this.Controls.Add(this.searchRadius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.imagebox);
            this.Controls.Add(this.imgpath);
            this.Controls.Add(this.loadButton);
            this.Name = "SignedDistanceFieldForm";
            this.Text = "Signed Distance Field Generator";
            ((System.ComponentModel.ISupportInitialize)(this.imagebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label imgpath;
        private System.Windows.Forms.PictureBox imagebox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label progress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar searchRadius;
        private System.Windows.Forms.Label MinRadius;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Radius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown OutWidth;
        private System.Windows.Forms.NumericUpDown OutHeight;
        private System.Windows.Forms.Label timeLeft;
    }
}

