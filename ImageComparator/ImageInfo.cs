using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageComparator
{
    public class ImageInfo : IComparable
    {
        FileInfo FileInfoData { get; set; }
        public string FileName { get; protected set; }
        public string NewFileName { get; protected set; }

        int Size { get; set; }
        int Width { get; set; }
        int Height { get; set; }

        public double SizeCoef { get; protected set; }

        public void SetSizeInfo(int width, int height)
        {
            Width = width; Height = height;
            Size = Width * Height;
            SizeCoef = Width / Height;
        }

        uint TotalValue { get; set; }
        uint TotalSaturation { get; set; }

        public double ValueCoef { get; protected set; }
        public double SaturationCoef { get; protected set; }

        public void SetAndCalculateSatValCoef(uint value, uint saturation)
        {
            if (Size > 0)
            {
                TotalValue = value; TotalSaturation = saturation;

                ValueCoef = Math.Round((double)TotalValue / (double)Size, 2);
                SaturationCoef = Math.Round((double)TotalSaturation / (double)Size, 2);
            }
        }

        uint RedVal { get; set; }
        uint YellowVal { get; set; }
        uint GreenVal { get; set; }
        uint CyanVal { get; set; }
        uint BlueVal { get; set; }
        uint MagentaVal { get; set; }

        public double RedCoef { get; protected set; }
        public double YellowCoef { get; protected set; }
        public double GreenCoef { get; protected set; }
        public double CyanCoef { get; protected set; }
        public double BlueCoef { get; protected set; }
        public double MagentaCoef { get; protected set; }

        public void SetAndCalculateColorInfo(uint red, uint yellow, uint green, uint cyan, uint blue, uint magenta)
        {
            if (Size > 0)
            {
                RedVal = red; YellowVal = yellow; GreenVal = green;
                CyanVal = cyan; BlueVal = blue; MagentaVal = magenta;

                RedCoef = Math.Round((double)RedVal / (double)Size * 100, 2);
                YellowCoef = Math.Round((double)YellowVal / (double)Size * 100, 2);
                GreenCoef = Math.Round((double)GreenVal / (double)Size * 100, 2);
                CyanCoef = Math.Round((double)CyanVal / (double)Size * 100, 2);
                BlueCoef = Math.Round((double)BlueVal / (double)Size * 100, 2);
                MagentaCoef = Math.Round((double)MagentaVal / (double)Size * 100, 2);
            }
        }

        public ImageInfo(FileInfo file) 
        {
            if (file != null)
            {
                FileInfoData = file;
                FileName = file.FullName;
            }
            else
            {
                FileInfoData = null;
                FileName = string.Empty;
            }
        }

        public void CreateNewFileName(string fileName)
        {
            NewFileName = FileInfoData.Directory.FullName + "\\" + fileName + FileInfoData.Extension;
        }

        public void TryRenameFile()
        {
            try
            {
                if (FileInfoData != null && !string.IsNullOrWhiteSpace(NewFileName))
                {
                    if (!File.Exists(NewFileName))
                    {
                        FileInfoData.MoveTo(NewFileName);
                        FileName = NewFileName;
                    }
                }
            }
            catch (Exception ex) { }
        }

        public bool IsSimilar(ImageInfo image, double coefficient)
        {
            if (Math.Abs(this.ValueCoef - image.ValueCoef) > coefficient) return false;
            if (Math.Abs(this.SaturationCoef - image.SaturationCoef) > coefficient) return false;
            if (Math.Abs(this.RedCoef - image.RedCoef) > coefficient) return false;
            if (Math.Abs(this.YellowCoef - image.YellowCoef) > coefficient) return false;
            if (Math.Abs(this.GreenCoef - image.GreenCoef) > coefficient) return false;
            if (Math.Abs(this.CyanCoef - image.CyanCoef) > coefficient) return false;
            if (Math.Abs(this.BlueCoef - image.BlueCoef) > coefficient) return false;
            if (Math.Abs(this.MagentaCoef - image.MagentaCoef) > coefficient) return false;

            return true;
        }


        public int CompareTo(object comparedObject)
        {
            if (comparedObject == null || !(comparedObject is ImageInfo)) return 1;

            ImageInfo objectInfo = comparedObject as ImageInfo;
            int value = 1;

            switch (ImageComparisonMode.ImageComparison)
            {
                case ComparisonMode.FileName:
                    return this.FileName.CompareTo(objectInfo.FileName);
                case ComparisonMode.Size:
                    value = this.Size.CompareTo(objectInfo.Size);
                    if (value == 0)
                    {
                        value = this.Width.CompareTo(objectInfo.Width);
                        if (value == 0) value = this.Height.CompareTo(objectInfo.Height);
                        return value;
                    }
                    else return value;
                case ComparisonMode.ImageProperties:
                    value = this.SizeCoef.CompareTo(objectInfo.SizeCoef);
                    if (value == 0) value = this.ValueCoef.CompareTo(objectInfo.ValueCoef);
                    if (value == 0) value = this.SaturationCoef.CompareTo(objectInfo.SaturationCoef);
                    return value;
                case ComparisonMode.ColorCoef:
                    value = this.RedCoef.CompareTo(objectInfo.RedCoef);
                    if (value == 0) value = this.YellowCoef.CompareTo(objectInfo.YellowCoef);
                    if (value == 0) value = this.GreenCoef.CompareTo(objectInfo.GreenCoef);
                    if (value == 0) value = this.CyanCoef.CompareTo(objectInfo.CyanCoef);
                    if (value == 0) value = this.BlueCoef.CompareTo(objectInfo.BlueCoef);
                    if (value == 0) value = this.MagentaCoef.CompareTo(objectInfo.MagentaCoef);
                    return value;
                case ComparisonMode.NumericFileName:
                    int thisValue; int objectValue;
                    bool thisParsed = Int32.TryParse(Path.GetFileNameWithoutExtension(this.FileName), out thisValue);
                    bool objectParsed = Int32.TryParse(Path.GetFileNameWithoutExtension(objectInfo.FileName), out objectValue);
                    if (thisParsed && objectParsed)
                    {
                        return thisValue.CompareTo(objectValue);
                    }
                    else
                    {
                        if (thisParsed) return 1;
                        else if (objectParsed) return -1;
                        else return this.FileName.CompareTo(objectInfo.FileName);
                    }
            }

            return 1;
        }

        public override string ToString()
        {
            return string.Format("{0} : Size {1} (W:{2}, H:{3} - Value:{4}, Saturation:{5})", FileName, Size, Width, Height, ValueCoef, SaturationCoef);
        }

        public string GetColorCoef()
        {
            return string.Format("Value:{0}; Saturation:{1}: Red:{2}, Yellow:{3} Green:{4}, Cyan:{5}, Blue:{6}, Magenta:{7} - {8} : Size {9} (W:{10}, H:{11})",
                ValueCoef, SaturationCoef, RedCoef, YellowCoef, GreenCoef, CyanCoef, BlueCoef, MagentaCoef, FileName, Size, Width, Height);
        }
    }
}
