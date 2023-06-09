namespace ImageComparator.Controls
{
    partial class NavigationButton
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
            this.pictureBox_ButtonImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ButtonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ButtonImage
            // 
            this.pictureBox_ButtonImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_ButtonImage.Image = global::ImageComparator.Properties.Resources.Button_Navigation_Normal;
            this.pictureBox_ButtonImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_ButtonImage.Name = "pictureBox_ButtonImage";
            this.pictureBox_ButtonImage.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_ButtonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ButtonImage.TabIndex = 0;
            this.pictureBox_ButtonImage.TabStop = false;
            this.pictureBox_ButtonImage.Click += new System.EventHandler(this.pictureBox_ButtonImage_Click);
            this.pictureBox_ButtonImage.MouseEnter += new System.EventHandler(this.pictureBox_ButtonImage_MouseEnter);
            this.pictureBox_ButtonImage.MouseLeave += new System.EventHandler(this.pictureBox_ButtonImage_MouseLeave);
            // 
            // NavigationButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox_ButtonImage);
            this.Name = "NavigationButton";
            this.Size = new System.Drawing.Size(32, 32);
            this.Load += new System.EventHandler(this.NavigationButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ButtonImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ButtonImage;
    }
}
