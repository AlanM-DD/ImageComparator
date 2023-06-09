namespace ImageComparator.Controls
{
    partial class CustomProgressBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_ProgressImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProgressImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ProgressImage
            // 
            this.pictureBox_ProgressImage.BackColor = System.Drawing.Color.White;
            this.pictureBox_ProgressImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_ProgressImage.Name = "pictureBox_ProgressImage";
            this.pictureBox_ProgressImage.Size = new System.Drawing.Size(217, 25);
            this.pictureBox_ProgressImage.TabIndex = 0;
            this.pictureBox_ProgressImage.TabStop = false;
            // 
            // CustomProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pictureBox_ProgressImage);
            this.Name = "CustomProgressBar";
            this.Size = new System.Drawing.Size(217, 25);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ProgressImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ProgressImage;
    }
}
