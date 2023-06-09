using ImageComparator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageComparator.Controls
{
    public partial class CustomProgressBar : UserControl
    {
        private int _progress = 0;

        [Category("Progress"), Description("Progress value visible on the strip.")]
        public int Value
        {
            get { return _progress; }
            set
            {
                _progress = Math.Min(Math.Max(value, 0), 100);
                prepareBackgroundImage();
            }
        }

        public CustomProgressBar()
        {
            InitializeComponent();
        }

        private void prepareBackgroundImage()
        {
            try
            {
                Bitmap background = new Bitmap(220, 25);
                using (Graphics graphics = Graphics.FromImage(background))
                {
                    float progressValue = _progress * pictureBox_ProgressImage.Width / 100;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

                    if (_progress == 0)
                    {
                        graphics.FillRectangle(Brushes.White, 0, 0, pictureBox_ProgressImage.Width, pictureBox_ProgressImage.Height);
                    }
                    else
                    {
                        graphics.DrawImage(Resources.Progress_Bar, 0, 0);
                        graphics.FillRectangle(Brushes.White, progressValue, 0, pictureBox_ProgressImage.Width, pictureBox_ProgressImage.Height);
                    }
                }
                if (pictureBox_ProgressImage.Image != null)
                {
                    pictureBox_ProgressImage.Image.Dispose();
                }
                pictureBox_ProgressImage.Image = background;
                pictureBox_ProgressImage.Invalidate();
            }
            catch (Exception ex) { }
        }
    }
}
