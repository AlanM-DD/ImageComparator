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
    public partial class NavigationButton : UserControl
    {
        private bool _imageHighlighted = false;
        private NavigationButtonType _buttonType = NavigationButtonType.None;

        [Category("ButtonType"), Description("Type of button icon.")]
        public NavigationButtonType ButtonType
        {
            get { return _buttonType; }
            set 
            {
                _buttonType = value;
                prepareBackgroundImage();
            }
        }

        public NavigationButton()
        {
            InitializeComponent();
        }

        private void NavigationButton_Load(object sender, EventArgs e)
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
                Bitmap background = Resources.Button_Navigation_Normal;
                if (_imageHighlighted) background = Resources.Button_Navigation_Active;

                using (Graphics graphics = Graphics.FromImage(background))
                {
                    switch (_buttonType)
                    {
                        case NavigationButtonType.Close:
                            graphics.DrawImage(Resources.Navigation_Cross, 0, 0);
                            break;
                        case NavigationButtonType.Minimize:
                            graphics.DrawImage(Resources.Navigation_Minimize, 0, 0);
                            break;
                        case NavigationButtonType.BrowseDirectory:
                            graphics.DrawImage(Resources.Navigation_Explore, 0, 0);
                            break;
                        case NavigationButtonType.Stop:
                            graphics.DrawImage(Resources.Navigation_Stop, 0, 0);
                            break;
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

        private void pictureBox_ButtonImage_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
