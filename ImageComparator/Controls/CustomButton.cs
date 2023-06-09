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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace ImageComparator.Controls
{
    public partial class CustomButton : UserControl
    {
        private bool _imageHighlighted = false;
        private int _textSize = 12;

        [Category("Text"), Description("Text size of the label.")]
        public int TextSize 
        {
            get { return _textSize; }
            set 
            { 
                _textSize = Math.Max(value, 8);
                prepareBackgroundImage();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Text"), Description("Displayed text.")]
        public override string Text 
        { 
            get => base.Text;
            set
            {
                base.Text = value;
                prepareBackgroundImage();
            }
        }

        public CustomButton()
        {
            InitializeComponent();
        }

        private void CustomButton_Load(object sender, EventArgs e)
        {
            prepareBackgroundImage();
        }

        private void pictureBox_ButtonImage_MouseEnter(object sender, EventArgs e)
        {
            _imageHighlighted = true;
            prepareBackgroundImage();
        }

        private void pictureBox_ButtonImage_MouseLeave(object sender, EventArgs e)
        {
            _imageHighlighted = false;
            prepareBackgroundImage();
        }

        private void prepareBackgroundImage()
        {
            try
            {
                Bitmap background = Resources.Button_Normal;
                if (_imageHighlighted) background = Resources.Button_Active;

                int textSize = TextSize;
                if (textSize < 8) { textSize = 8; }

                using (Graphics graphics = Graphics.FromImage(background))
                using (StringFormat textFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (Font textFont = new Font(FontFamily.GenericSansSerif, textSize))
                {
                    if (!string.IsNullOrWhiteSpace(Text))
                    {
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                        Rectangle textRectangle = new Rectangle(0, 0, background.Width, background.Height);
                        if (this.Enabled) graphics.DrawString(Text, textFont, Brushes.White, textRectangle, textFormat);
                        else graphics.DrawString(Text, textFont, Brushes.Gray, textRectangle, textFormat);
                    }
                }
                if (pictureBox_ButtonImage.Image != null)
                {
                    pictureBox_ButtonImage.Image.Dispose();
                }
                pictureBox_ButtonImage.Image = background;
                pictureBox_ButtonImage.Invalidate();
            }
            catch (Exception ex) { }
        }

        private void CustomButton_EnabledChanged(object sender, EventArgs e)
        {
            prepareBackgroundImage();
        }

        private void pictureBox_ButtonImage_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

    }
}
