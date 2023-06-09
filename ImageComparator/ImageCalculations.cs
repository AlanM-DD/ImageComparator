using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;


namespace ImageComparator
{
    public static class ImageCalculations
    {
        /// <summary>
        /// This method compares two images, loaded based on information contained in FileInfo instances.
        /// </summary>
        /// <param name="firstImageFile">First FileInfo instance.</param>
        /// <param name="secondImageFile">Second FileInfo instance.</param>
        /// <param name="comparisonCoef">Comparison coefficient - if all image parameters (brightness, saturation, colors) fall within the limit of the coefficient, the images are considered similar.</param>
        /// <returns>
        /// The method returns an FileComparisonResult enumerator:
        /// InvalidFileInfo - One of the files does not exist.
        /// InvalidImageExtension - One of the files is not a supported image file.
        /// InvalidImageFormat - One of the files is not an image in a supported format (24bppRgb or 32bppArgb).
        /// Different - Images are different (properties of the images do not fall within the given coefficient).
        /// Similar - Images are similar.
        /// </returns>
        public static FileComparisonResult CompareTwoImageFiles(FileInfo firstImageFile, FileInfo secondImageFile, double comparisonCoef)
        {
            if (FileOperations.IsFileInfoValid(firstImageFile) == false || FileOperations.IsFileInfoValid(secondImageFile) == false) 
            { 
                return FileComparisonResult.InvalidFileInfo; 
            }

            if (FileOperations.IsFileTypeValid(firstImageFile) == false || FileOperations.IsFileTypeValid(secondImageFile) == false) 
            { 
                return FileComparisonResult.InvalidImageExtension; 
            }

            //Comparison coefficint should be greater than or equal to 0.
            if (comparisonCoef < 0) { comparisonCoef = 0; }
            bool imageCallculated;

            //Load and calculate parameters of first image.
            Bitmap firstImage = new Bitmap(firstImageFile.FullName);
            ImageInfo firstImageInfo = new ImageInfo(firstImageFile);
            imageCallculated = CallculateImageColorInfo(firstImage, ref firstImageInfo);
            if (imageCallculated == false) { return FileComparisonResult.InvalidImageFormat; }

            //Load and calculate parameters of second image.
            Bitmap secondImage = new Bitmap(secondImageFile.FullName);
            ImageInfo secondImageInfo = new ImageInfo(secondImageFile);
            imageCallculated = CallculateImageColorInfo(secondImage, ref secondImageInfo);
            if (imageCallculated == false) { return FileComparisonResult.InvalidImageFormat; }

            if (firstImageInfo.IsSimilar(secondImageInfo, comparisonCoef))
            {
                return FileComparisonResult.Similar;
            }
            else return FileComparisonResult.Different;
        }

        /// <summary>
        /// This method takes the image's color arrays and calculates the sums of the individual color components.
        /// </summary>
        /// <param name="image">Bitmap instance.</param>
        /// <param name="imageInfo">Reference to ImageInfo object.</param>
        /// <returns>
        /// True if it was possible to read the component sums.
        /// False if the image format is not supported.
        /// </returns>
        public static bool CallculateImageColorInfo(Bitmap image, ref ImageInfo imageInfo)
        {
            byte[] R = null; byte[] G = null; byte[] B = null;
            int size = image.Width * image.Height;
            if (image.PixelFormat == PixelFormat.Format24bppRgb)
            {
                R = new byte[size];
                G = new byte[size];
                B = new byte[size];

                BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                int stride = data.Stride;
                System.IntPtr Scan0 = data.Scan0;
                unsafe
                {
                    byte* ptr = (byte*)(void*)Scan0;
                    int offset = stride - data.Width * 3;
                    for (int y = 0; y < data.Height; y++)
                    {
                        for (int x = 0; x < data.Width; x++)
                        {
                            B[x + y * data.Width] = ptr[0];
                            G[x + y * data.Width] = ptr[1];
                            R[x + y * data.Width] = ptr[2];
                            ptr += 3;
                        }

                        ptr += offset;
                    }
                }
                image.UnlockBits(data);
            }
            else if (image.PixelFormat == PixelFormat.Format32bppArgb)
            {
                R = new byte[size];
                G = new byte[size];
                B = new byte[size];

                BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                int stride = data.Stride;
                System.IntPtr Scan0 = data.Scan0;
                unsafe
                {
                    byte* ptr = (byte*)(void*)Scan0;
                    int offset = stride - data.Width * 4;
                    for (int y = 0; y < data.Height; y++)
                    {
                        for (int x = 0; x < data.Width; x++)
                        {
                            B[x + y * data.Width] = ptr[0];
                            G[x + y * data.Width] = ptr[1];
                            R[x + y * data.Width] = ptr[2];
                            ptr += 4;
                        }

                        ptr += offset;
                    }
                }
                image.UnlockBits(data);
            }

            if (R != null && G != null && B != null)
            {
                imageInfo.SetSizeInfo(image.Width, image.Height);

                /*
                //Sum of RGB components
                uint RSum = 0;
                uint GSum = 0;
                uint BSum = 0;

                for (int i = 0; i < size; i++)
                {
                    RSum = RSum + R[i];
                    GSum = GSum + G[i];
                    BSum = BSum + B[i];
                }
                */

                double[] H = new double[size];
                double[] S = new double[size];
                double[] V = new double[size];

                Parallel.For(0, size, (i) =>
                {
                    Color pixelColor = Color.FromArgb(R[i], G[i], B[i]);
                    ColorToHSV(pixelColor, out H[i], out S[i], out V[i]);
                });

                uint totalValue = 0; uint totalSaturation = 0;
                uint red = 0; uint yellow = 0; uint green = 0;
                uint cyan = 0; uint blue = 0; uint magenta = 0;

                for (int i = 0; i < size; i++)
                {
                    totalValue += (uint)(V[i] * 100);
                    totalSaturation += (uint)(S[i] * 100);

                    //The color is assigned to one of six classes, based on the hue value.
                    if (H[i] > 330 || H[i] <= 30) //Red - H = 0;
                    {
                        red++;
                    }
                    else if (H[i] > 30 && H[i] <= 90) //Yellow - H = 60;
                    {
                        yellow++;
                    }
                    else if (H[i] > 90 && H[i] <= 150) //Green - H = 120;
                    {
                        green++;
                    }
                    else if (H[i] > 150 && H[i] <= 210) //Cyan - H = 180;
                    {
                        cyan++;
                    }
                    else if (H[i] > 210 && H[i] <= 270) //Blue - H = 240;
                    {
                        blue++;
                    }
                    else if (H[i] > 270 && H[i] <= 330) //Magenta - H = 300;
                    {
                        magenta++;
                    }
                }

                imageInfo.SetAndCalculateSatValCoef(totalValue, totalSaturation);
                imageInfo.SetAndCalculateColorInfo(red, yellow, green, cyan, blue, magenta);
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method creates color arrays based on the Bitmap data.
        /// </summary>
        /// <param name="image">Bitmap instance.</param>
        /// <param name="R">Array of pixel values for Red channel.</param>
        /// <param name="G">Array of pixel values for Green channel.</param>
        /// <param name="B">Array of pixel values for Blue channel.</param>
        /// <returns>
        /// True if it was possible to read bitmap data.
        /// False if the image format is not supported.
        /// </returns>
        public static bool CreateImageTab(Bitmap image, out byte[] R, out byte[] G, out byte[] B)
        {
            R = null; G = null; B = null;
            int size = image.Width * image.Height;
            if (image.PixelFormat == PixelFormat.Format24bppRgb)
            {
                R = new byte[size];
                G = new byte[size];
                B = new byte[size];

                BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                int stride = data.Stride;
                System.IntPtr Scan0 = data.Scan0;
                unsafe
                {
                    byte* ptr = (byte*)(void*)Scan0;
                    int offset = stride - data.Width * 3;
                    for (int y = 0; y < data.Height; y++)
                    {
                        for (int x = 0; x < data.Width; x++)
                        {
                            B[x + y * data.Width] = ptr[0];
                            G[x + y * data.Width] = ptr[1];
                            R[x + y * data.Width] = ptr[2];
                            ptr += 3;
                        }

                        ptr += offset;
                    }
                }
                image.UnlockBits(data);
                return true;
            }
            else if (image.PixelFormat == PixelFormat.Format32bppArgb)
            {
                R = new byte[size];
                G = new byte[size];
                B = new byte[size];

                BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                int stride = data.Stride;
                System.IntPtr Scan0 = data.Scan0;
                unsafe
                {
                    byte* ptr = (byte*)(void*)Scan0;
                    int offset = stride - data.Width * 4;
                    for (int y = 0; y < data.Height; y++)
                    {
                        for (int x = 0; x < data.Width; x++)
                        {
                            B[x + y * data.Width] = ptr[0];
                            G[x + y * data.Width] = ptr[1];
                            R[x + y * data.Width] = ptr[2];
                            ptr += 4;
                        }

                        ptr += offset;
                    }
                }
                image.UnlockBits(data);
                return true;
            }

            return false;
        }


        /// <summary>The method returns hue, saturation and value, depending on the given Color instance.</summary>
        /// <param name="color">Color structure.</param>
        /// <param name="hue">Hue in degrees (double). Return value is between 0 and 360.</param>
        /// <param name="saturation">Percentage of saturation (double). Return value is between 0 and 1.</param>
        /// <param name="value">Percentage of the white light value (double). Return value is between 0 and 1.</param>
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }
    }
}
