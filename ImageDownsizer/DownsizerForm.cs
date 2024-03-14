using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

namespace ImageDownsizer
{
    public partial class DownsizerForm : Form
    {
        private Bitmap? selectedImage;
        private Stopwatch? stopWatch;
        private long totalTime;

        public DownsizerForm()
        {
            InitializeComponent();
            this.stopWatch = new Stopwatch();
            this.totalTime = 0;
        }

        private void Downsize(ImageProcessingMethod processingMethod)
        { 
            totalTime = 0;

            if (selectedImage == null)
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double downscaleFactor;

            if (!double.TryParse(downScaleFactorTextBox.Text, out downscaleFactor) || downscaleFactor <= 0 || downscaleFactor > 100)
            {
                MessageBox.Show("Please enter a valid downscale factor (1-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            long bitmapToColorArrayTime = 0;
            long resizeTime = 0;
            long colorArrayToBitmapTime = 0;

            switch (processingMethod)
            {
                case ImageProcessingMethod.BilinearSequential:
                    lblResults.Text = "Bilinear Sequential Results:";
                    (bitmapToColorArrayTime, resizeTime, colorArrayToBitmapTime) = ProcessBilinearSequential(selectedImage, downscaleFactor);
                    break;
                case ImageProcessingMethod.BilinearParallel:
                    lblResults.Text = "Bilinear Parallel For Loop Results:";
                    (bitmapToColorArrayTime, resizeTime, colorArrayToBitmapTime) = ProcessBilinearParallel(selectedImage, downscaleFactor);
                    break;
            }

            lblBitmapColorArray.Text = $"Bitmap To ColorArray execution time: {bitmapToColorArrayTime} ms";
            lblResize.Text = $"Resizing execution time: {resizeTime} ms";
            lblColorArrayBitmap.Text = $"ColorArray To Bitmap execution time: {colorArrayToBitmapTime} ms";

            lblTotal.Text = $"Total time: {totalTime} ms";           
        }

        private void btnConsequential_Click(object sender, EventArgs e)
        {
            Downsize(ImageProcessingMethod.BilinearSequential);
        }

        private void btnParallel_Click(object sender, EventArgs e)
        {
            Downsize(ImageProcessingMethod.BilinearParallel);
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedImagePath = openFileDialog.FileName;
                        // Display the selected image in PictureBox
                        selectedImage = new Bitmap(openFileDialog.FileName);
                        selectedImageBox.Image = selectedImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        
        private (long, long, long) ProcessBilinearSequential(Bitmap selectedImage, double downscaleFactor)
        {
            var (colorArray, bitmapToColorArrayTime) = MeasureExecutionTime(() =>
            {
                var array = BitmapHelper.BitmapToColorArray(selectedImage);
                return (array, totalTime);
            });

            var (resizedImage, resizeTime) = MeasureExecutionTime(() =>
            {
                var image = BilinearInterpolator.ResizeImageSequential(colorArray, downscaleFactor);
                return (image, totalTime);
            });

            var (result, colorArrayToBitmapTime) = MeasureExecutionTime(() =>
            {
                var result = BitmapHelper.ColorArrayToBitmap(resizedImage);
                resultPictureBox.Image = result;
                return (result, totalTime);
            });

            return (bitmapToColorArrayTime, resizeTime, colorArrayToBitmapTime);
        }

        private (long, long, long) ProcessBilinearParallel(Bitmap selectedImage, double downscaleFactor)
        {
            var (colorArray, bitmapToColorArrayTime) = MeasureExecutionTime(() =>
            {
                var array = BitmapHelper.BitmapToColorArray(selectedImage);
                return (array, totalTime);
            });

            var (resizedImage, resizeTime) = MeasureExecutionTime(() =>
            {
                var image = BilinearInterpolator.ResizeImageParallel(colorArray, downscaleFactor);
                return (image, totalTime);
            });

            var (result, colorArrayToBitmapTime) = MeasureExecutionTime(() =>
            {
                var result = BitmapHelper.ColorArrayToBitmap(resizedImage);
                resultPictureBox.Image = result;
                return (result, totalTime);
            });

            return (bitmapToColorArrayTime, resizeTime, colorArrayToBitmapTime);
        }

        private (T, long) MeasureExecutionTime<T>(Func<(T, long)> action)
        {
            stopWatch.Restart();
            (T result, _) = action();
            stopWatch.Stop();
            totalTime += stopWatch.ElapsedMilliseconds; // Update totalTime here
            return (result, stopWatch.ElapsedMilliseconds);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp";
            saveFileDialog.Title = "Save Image";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string, proceed with saving.
            if (saveFileDialog.FileName != "")
            {
                // Determine the file format based on the selected filter.
                ImageFormat format;
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        format = ImageFormat.Jpeg;
                        break;
                    case 2:
                        format = ImageFormat.Png;
                        break;
                    case 3:
                        format = ImageFormat.Bmp;
                        break;
                    default:
                        format = ImageFormat.Jpeg; // Default to JPEG
                        break;
                }

                // Save the bitmap to the specified file path.


                var downscaledImage = (Bitmap)resultPictureBox.Image;
                downscaledImage.Save(saveFileDialog.FileName, format);
            }
        }
    }
}