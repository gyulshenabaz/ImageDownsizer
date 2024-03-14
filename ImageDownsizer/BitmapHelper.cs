using System.Drawing.Imaging;

namespace ImageDownsizer
{
    public class BitmapHelper
    {
        public static Color[,] BitmapToColorArray(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Color[,] colors = new Color[width, height];

            // Lock the bitmap data
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0;

                // Calculate the stride (number of bytes per scanline)
                int stride = bmpData.Stride;

                // Iterate over each pixel
                Parallel.For(0, height, y =>
                {
                    byte* row = ptr + (y * stride); // Pointer to the start of the current row

                    for (int x = 0; x < width; x++)
                    {
                        // Get the color components
                        byte b = row[x * 4];
                        byte g = row[x * 4 + 1];
                        byte r = row[x * 4 + 2];
                        byte a = row[x * 4 + 3];

                        // Create the Color object and store it in the array
                        colors[x, y] = Color.FromArgb(a, r, g, b);
                    }
                });
            }

            // Unlock the bitmap data
            bitmap.UnlockBits(bmpData);

            return colors;
        }

        public static Bitmap ColorArrayToBitmap(Color[,] colorArray)
        {
            int width = colorArray.GetLength(0);
            int height = colorArray.GetLength(1);

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);

            int stride = bitmapData.Stride;
            IntPtr scan0 = bitmapData.Scan0;

            unsafe
            {
                byte* ptr = (byte*)scan0;

                // Iterate over rows first for better memory access patterns
                for (int y = 0; y < height; y++)
                {
                    byte* rowPtr = ptr + (y * stride);

                    for (int x = 0; x < width; x++)
                    {
                        Color color = colorArray[x, y];
                        rowPtr[x * 3] = color.B; // Blue
                        rowPtr[x * 3 + 1] = color.G; // Green
                        rowPtr[x * 3 + 2] = color.R; // Red
                    }
                }
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
