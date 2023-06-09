using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComparator
{
    public static class ImageComparisonMode
    {
        public static ComparisonMode ImageComparison = ComparisonMode.Size;
    }
    public enum ComparisonMode { FileName, Size, ImageProperties, ColorCoef, NumericFileName }

    public enum MainWindowState { StartApplication, FileInfoLoaded, HistogramInfoCreated }

    public enum NavigationButtonType { None, Close, Minimize, BrowseDirectory, Stop }

    public enum FileComparisonResult { Similar = 1, Different = 0, InvalidFileInfo = -1, InvalidImageExtension = -2, InvalidImageFormat = -3 }
}
