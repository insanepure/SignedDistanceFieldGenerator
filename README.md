I decided to make a Signed Distance Field Generator because I did not find any yet.
This SDF Generator generates a Signed Distance Field the bruteforce variant which also was used by valve.
see http://www.valvesoftware.com/publications/2007/SIGGRAPH2007_AlphaTestedMagnification.pdf.

The SDF Generator needs a monochromatical image as input and can give you a SDF image based on the inner Color you select.
You can define the Size of the final image as you like.
Also I added multithreading to speed things up.

Features so far
 - SDF Generation from monochromatical images
 - Define Size and Inner Color
 - Multithreading
 
 Later on I will add NVIDIA Cuda and add some more performance improvements.
