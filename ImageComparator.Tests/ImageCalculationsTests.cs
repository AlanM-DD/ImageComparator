using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ImageComparator.Tests
{
    [TestClass]
    public class ImageCalculationsTests
    {
        private static double COEFFICIENT = 1.0;

        [TestMethod]
        public void CompareTwoImages_WhenMirrored_ReturnSimilar()
        {
            //Arrange
            string firstFilePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"TestImages\TestImage_01.jpg");
            FileInfo firstFileInfo = new FileInfo(firstFilePath);

            string secondFilePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"TestImages\TestImage_01_Mirrored.jpg");
            FileInfo secondFileInfo = new FileInfo(secondFilePath);

            //Act
            FileComparisonResult result = ImageCalculations.CompareTwoImageFiles(firstFileInfo, secondFileInfo, COEFFICIENT);

            //Assert
            Assert.AreEqual(FileComparisonResult.Similar, result);
        }

        [TestMethod]
        public void CompareTwoImages_WhenResized_ReturnSimilar()
        {
            //Arrange
            string firstFilePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"TestImages\TestImage_02.jpg");
            FileInfo firstFileInfo = new FileInfo(firstFilePath);

            string secondFilePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"TestImages\TestImage_02_Resized.jpg");
            FileInfo secondFileInfo = new FileInfo(secondFilePath);

            //Act
            FileComparisonResult result = ImageCalculations.CompareTwoImageFiles(firstFileInfo, secondFileInfo, COEFFICIENT);

            //Assert
            Assert.AreEqual(FileComparisonResult.Similar, result);
        }

        [TestMethod]
        public void CompareTwoImages_WhenDifferent_ReturnDifferent()
        {
            //Arrange
            string firstFilePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"TestImages\TestImage_03.jpg");
            FileInfo firstFileInfo = new FileInfo(firstFilePath);

            string secondFilePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"TestImages\TestImage_04.jpg");
            FileInfo secondFileInfo = new FileInfo(secondFilePath);

            //Act
            FileComparisonResult result = ImageCalculations.CompareTwoImageFiles(firstFileInfo, secondFileInfo, COEFFICIENT);

            //Assert
            Assert.AreEqual(FileComparisonResult.Different, result);
        }
    }
}
