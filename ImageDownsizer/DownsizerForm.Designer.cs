namespace ImageDownsizer
{
    partial class DownsizerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectedImageBox = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.downScaleFactorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsequential = new System.Windows.Forms.Button();
            this.btnParallel = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblBitmapColorArray = new System.Windows.Forms.Label();
            this.lblResize = new System.Windows.Forms.Label();
            this.lblColorArrayBitmap = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedImageBox
            // 
            this.selectedImageBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.selectedImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectedImageBox.Location = new System.Drawing.Point(12, 12);
            this.selectedImageBox.Name = "selectedImageBox";
            this.selectedImageBox.Size = new System.Drawing.Size(524, 357);
            this.selectedImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectedImageBox.TabIndex = 0;
            this.selectedImageBox.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSelectImage.Location = new System.Drawing.Point(12, 393);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(148, 32);
            this.btnSelectImage.TabIndex = 1;
            this.btnSelectImage.Text = "Select image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.resultPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.resultPictureBox.Location = new System.Drawing.Point(554, 12);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(524, 357);
            this.resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resultPictureBox.TabIndex = 2;
            this.resultPictureBox.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(930, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(211, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Downscale Factor";
            // 
            // downScaleFactorTextBox
            // 
            this.downScaleFactorTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.downScaleFactorTextBox.Location = new System.Drawing.Point(348, 396);
            this.downScaleFactorTextBox.Name = "downScaleFactorTextBox";
            this.downScaleFactorTextBox.Size = new System.Drawing.Size(161, 29);
            this.downScaleFactorTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(515, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "%";
            // 
            // btnConsequential
            // 
            this.btnConsequential.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsequential.Location = new System.Drawing.Point(604, 393);
            this.btnConsequential.Name = "btnConsequential";
            this.btnConsequential.Size = new System.Drawing.Size(123, 32);
            this.btnConsequential.TabIndex = 7;
            this.btnConsequential.Text = "Consequential";
            this.btnConsequential.UseVisualStyleBackColor = true;
            this.btnConsequential.Click += new System.EventHandler(this.btnConsequential_Click);
            // 
            // btnParallel
            // 
            this.btnParallel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnParallel.Location = new System.Drawing.Point(754, 393);
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(148, 32);
            this.btnParallel.TabIndex = 8;
            this.btnParallel.Text = "Parallel";
            this.btnParallel.UseVisualStyleBackColor = true;
            this.btnParallel.Click += new System.EventHandler(this.btnParallel_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResults.Location = new System.Drawing.Point(12, 446);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(63, 21);
            this.lblResults.TabIndex = 9;
            this.lblResults.Text = "Results:";
            // 
            // lblBitmapColorArray
            // 
            this.lblBitmapColorArray.AutoSize = true;
            this.lblBitmapColorArray.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBitmapColorArray.Location = new System.Drawing.Point(70, 478);
            this.lblBitmapColorArray.Name = "lblBitmapColorArray";
            this.lblBitmapColorArray.Size = new System.Drawing.Size(162, 21);
            this.lblBitmapColorArray.TabIndex = 10;
            this.lblBitmapColorArray.Text = "Bitmap to Color array:";
            // 
            // lblResize
            // 
            this.lblResize.AutoSize = true;
            this.lblResize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResize.Location = new System.Drawing.Point(70, 508);
            this.lblResize.Name = "lblResize";
            this.lblResize.Size = new System.Drawing.Size(57, 21);
            this.lblResize.TabIndex = 11;
            this.lblResize.Text = "Resize:";
            // 
            // lblColorArrayBitmap
            // 
            this.lblColorArrayBitmap.AutoSize = true;
            this.lblColorArrayBitmap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblColorArrayBitmap.Location = new System.Drawing.Point(70, 539);
            this.lblColorArrayBitmap.Name = "lblColorArrayBitmap";
            this.lblColorArrayBitmap.Size = new System.Drawing.Size(162, 21);
            this.lblColorArrayBitmap.TabIndex = 12;
            this.lblColorArrayBitmap.Text = "Color array to Bitmap:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(70, 569);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(45, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total:";
            // 
            // DownsizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1090, 597);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblColorArrayBitmap);
            this.Controls.Add(this.lblResize);
            this.Controls.Add(this.lblBitmapColorArray);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnParallel);
            this.Controls.Add(this.btnConsequential);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.downScaleFactorTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.resultPictureBox);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.selectedImageBox);
            this.Name = "DownsizerForm";
            this.Text = "Image Downsizer";
            ((System.ComponentModel.ISupportInitialize)(this.selectedImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox selectedImageBox;
        private Button btnSelectImage;
        private PictureBox resultPictureBox;
        private Button btnSave;
        private Label label1;
        private TextBox downScaleFactorTextBox;
        private Label label2;
        private Button btnConsequential;
        private Button btnParallel;
        private Label lblResults;
        private Label lblBitmapColorArray;
        private Label lblResize;
        private Label lblColorArrayBitmap;
        private Label lblTotal;
    }
}