using System.Collections.Generic;
using System.IO;

namespace ImageComparator
{
    public static class FileOperations
    {
        /// <summary>
        /// This method searches the specified directory for image files (.bmp, .jpeg, .jpg and .png) and then creates a list of FileInfo instances.
        /// </summary>
        /// <param name="imageFilesList">Reference to FileInfo list.</param>
        /// <param name="directory">Given directory path.</param>
        /// <returns></returns>
        public static void GetImagesFileInfoFromDirectory(ref List<FileInfo> imageFilesList, string directory)
        {
            imageFilesList = new List<FileInfo>();
            DirectoryInfo info = new DirectoryInfo(directory);
            foreach (FileInfo file in info.GetFiles())
            {
                if (file.Extension.Equals(".bmp") || file.Extension.Equals(".jpeg") || file.Extension.Equals(".jpg") || file.Extension.Equals(".png"))
                {
                    imageFilesList.Add(file);
                }
            }
        }

        /// <summary>
        /// The method checks whether the file extension belongs to the type of supported image extensions.
        /// </summary>
        /// <param name="file">FileInfo instance.</param>
        /// <returns>
        /// True if the extension indicates a popular image format.
        /// False if the image format is not supported.
        /// </returns>
        public static bool IsFileTypeValid(FileInfo file)
        {
            if (file.Extension.Equals(".bmp") || file.Extension.Equals(".jpeg") || file.Extension.Equals(".jpg") || file.Extension.Equals(".png"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// The method checks whether the FileInfo instance points to an existing file.
        /// </summary>
        /// <param name="file">FileInfo instance.</param>
        /// <returns>
        /// True if the file exists.
        /// False if the FileInfo is invalid.
        /// </returns>
        public static bool IsFileInfoValid(FileInfo file)
        {
            if (file != null && File.Exists(file.FullName)) 
            { 
                return true; 
            }
            return false;
        }
    }
}
