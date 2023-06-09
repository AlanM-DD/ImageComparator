using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace ImageComparator.Tests
{
    [TestClass]
    public class HSVConverterTests
    {
        [TestMethod]
        public void ColorToHSV_Black_ValueZero()
        {
            //Arrange
            Color selectedColor = Color.Black;
            double hue; double saturation; double value;

            //Act
            ImageCalculations.ColorToHSV(selectedColor, out hue, out saturation, out value);

            //Assert
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void ColorToHSV_White_ValueOneSaturationZero()
        {
            //Arrange
            Color selectedColor = Color.White;
            double hue; double saturation; double value;

            //Act
            ImageCalculations.ColorToHSV(selectedColor, out hue, out saturation, out value);

            //Assert
            Assert.AreEqual(1, value);
            Assert.AreEqual(0, saturation);
        }

        [TestMethod]
        public void ColorToHSV_Red_Hue0()
        {
            //Arrange
            Color selectedColor = Color.Red;
            double hue; double saturation; double value;

            //Act
            ImageCalculations.ColorToHSV(selectedColor, out hue, out saturation, out value);

            //Assert
            Assert.AreEqual(0, hue);
        }

        [TestMethod]
        public void ColorToHSV_Yellow_Hue60()
        {
            //Arrange
            Color selectedColor = Color.Yellow;
            double hue; double saturation; double value;

            //Act
            ImageCalculations.ColorToHSV(selectedColor, out hue, out saturation, out value);

            //Assert
            Assert.AreEqual(60, hue);
        }

        [TestMethod]
        public void ColorToHSV_Green_Hue120()
        {
            //Arrange
            Color selectedColor = Color.Green;
            double hue; double saturation; double value;

            //Act
            ImageCalculations.ColorToHSV(selectedColor, out hue, out saturation, out value);

            //Assert
            Assert.AreEqual(120, hue);
        }

        [TestMethod]
        public void ColorToHSV_Cyan_Hue180()
        {
            //Arrange
            Color selectedColor = Color.Cyan;
            double hue; double saturation; double value;

            //Act
            ImageCalculations.ColorToHSV(selectedColor, out hue, out saturation, out value);

            //Assert
            Assert.AreEqual(180, hue);
        }

        [TestMethod]
        public void ColorToHSV_Blue_Hue240()
        {
            //Arrange
            Color selectedColor = Color.Blue;
            double hue; double saturation; double value;

            //Act
            ImageCalculations.ColorToHSV(selectedColor, out hue, out saturation, out value);

            //Assert
            Assert.AreEqual(240, hue);
        }

        [TestMethod]
        public void ColorToHSV_Magenta_Hue300()
        {
            //Arrange
            Color selectedColor = Color.Magenta;
            double hue; double saturation; double value;

            //Act
            ImageCalculations.ColorToHSV(selectedColor, out hue, out saturation, out value);

            //Assert
            Assert.AreEqual(300, hue);
        }
    }
}
