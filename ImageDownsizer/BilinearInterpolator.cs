using System.Drawing.Imaging;

namespace ImageDownsizer
{
    public class BilinearInterpolator
    {
        public static Color[,] ResizeImageSequential(Color[,] image, double scalePercent)
        {
            int originalWidth = image.GetLength(0);
            int originalHeight = image.GetLength(1);

            double scale = scalePercent / 100.0;
            int newWidth = (int)(originalWidth * scale);
            int newHeight = (int)(originalHeight * scale);
            Color[,] newImage = new Color[newWidth, newHeight];

            double widthRatio = (double)(originalWidth - 1) / (newWidth - 1);
            double heightRatio = (double)(originalHeight - 1) / (newHeight - 1);

            for (int newY = 0; newY < newHeight; newY++)
            {
                int sourceY1 = (int)Math.Floor(newY * heightRatio);
                int sourceY2 = Math.Min(sourceY1 + 1, originalHeight - 1);
                double yFraction = newY * heightRatio - sourceY1;

                for (int newX = 0; newX < newWidth; newX++)
                {
                    int sourceX1 = (int)Math.Floor(newX * widthRatio);
                    int sourceX2 = Math.Min(sourceX1 + 1, originalWidth - 1);
                    double xFraction = newX * widthRatio - sourceX1;

                    Color c11 = image[sourceX1, sourceY1];
                    Color c12 = image[sourceX1, sourceY2];
                    Color c21 = image[sourceX2, sourceY1];
                    Color c22 = image[sourceX2, sourceY2];

                    byte red = (byte)((1 - xFraction) * (1 - yFraction) * c11.R +
                                    xFraction * (1 - yFraction) * c21.R +
                                    (1 - xFraction) * yFraction * c12.R +
                                    xFraction * yFraction * c22.R);

                    byte green = (byte)((1 - xFraction) * (1 - yFraction) * c11.G +
                                    xFraction * (1 - yFraction) * c21.G +
                                    (1 - xFraction) * yFraction * c12.G +
                                    xFraction * yFraction * c22.G);

                    byte blue = (byte)((1 - xFraction) * (1 - yFraction) * c11.B +
                                    xFraction * (1 - yFraction) * c21.B +
                                    (1 - xFraction) * yFraction * c12.B +
                                    xFraction * yFraction * c22.B);

                    newImage[newX, newY] = Color.FromArgb(red, green, blue);
                }
            }

            return newImage;
        }


        public static Color[,] ResizeImageParallel(Color[,] image, double scalePercent)
        {
            int originalWidth = image.GetLength(0);
            int originalHeight = image.GetLength(1);

            double scale = scalePercent / 100.0;
            int newWidth = (int)(originalWidth * scale);
            int newHeight = (int)(originalHeight * scale);

            Color[,] resizedImage = new Color[newWidth, newHeight];

            double widthRatio = (double)(originalWidth - 1) / (newWidth - 1);
            double heightRatio = (double)(originalHeight - 1) / (newHeight - 1);

            // Parallelize the processing of rows
            Parallel.For(0, newHeight, newY =>
            {
                // Process each row in parallel
                for (int newX = 0; newX < newWidth; newX++)
                {
                    double sourceX = newX * widthRatio;
                    double sourceY = newY * heightRatio;

                    int x1 = (int)Math.Floor(sourceX);
                    int x2 = Math.Min(x1 + 1, originalWidth - 1);
                    int y1 = (int)Math.Floor(sourceY);
                    int y2 = Math.Min(y1 + 1, originalHeight - 1);

                    double xFraction = sourceX - x1;
                    double yFraction = sourceY - y1;

                    Color c11 = image[x1, y1];
                    Color c12 = image[x1, y2];
                    Color c21 = image[x2, y1];
                    Color c22 = image[x2, y2];

                    byte red = (byte)((1 - xFraction) * (1 - yFraction) * c11.R +
                                    xFraction * (1 - yFraction) * c21.R +
                                    (1 - xFraction) * yFraction * c12.R +
                                    xFraction * yFraction * c22.R);

                    byte green = (byte)((1 - xFraction) * (1 - yFraction) * c11.G +
                                    xFraction * (1 - yFraction) * c21.G +
                                    (1 - xFraction) * yFraction * c12.G +
                                    xFraction * yFraction * c22.G);

                    byte blue = (byte)((1 - xFraction) * (1 - yFraction) * c11.B +
                                    xFraction * (1 - yFraction) * c21.B +
                                    (1 - xFraction) * yFraction * c12.B +
                                    xFraction * yFraction * c22.B);

                    resizedImage[newX, newY] = Color.FromArgb(red, green, blue);
                }
            });

            return resizedImage;
        }
    }
}
