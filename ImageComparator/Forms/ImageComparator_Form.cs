using ImageComparator.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageComparator
{
    public partial class ImageComparator_Form : Form
    {
        static string REPORTNAME = "ImagesComparisonReport.txt";
        static string TEMPORARYFILENAME = "TemporaryName__";
        static int MAXDIRLABELLENGTH = 35;
        static double SIMILARITYCOEFFICIENT = 1.0;

        ToolTip _toolTip = new ToolTip();
        string _actionDirectory;
        bool _calculationsFullyCompleted;

        List<FileInfo> _images;
        List<ImageInfo> _histogramInfo = new List<ImageInfo>();

        bool _manualStopAction = false;


        public ImageComparator_Form()
        {
            InitializeComponent();
            _actionDirectory = Application.StartupPath;

            _toolTip.InitialDelay = 500;
            setDirectoryHint(_actionDirectory);
            setHints();

            setMainFormState(MainWindowState.StartApplication);
        }

        private void button_ChangeDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = _actionDirectory;

            folderBrowser.ShowDialog();
            if (!string.IsNullOrEmpty(folderBrowser.SelectedPath))
            {
                _actionDirectory = folderBrowser.SelectedPath;
                setDirectoryHint(_actionDirectory);
            }

            setMainFormState(MainWindowState.StartApplication);
        }

        #region Action buttons
        private void button_CreateImageList_Click(object sender, EventArgs e)
        {
            FileOperations.GetImagesFileInfoFromDirectory(ref _images, _actionDirectory);
            setImagesCount();
            if (_images.Count > 0) setMainFormState(MainWindowState.FileInfoLoaded);
        }

        private void button_BeginAction_Calculate_Click(object sender, EventArgs e)
        {
            _manualStopAction = false;
            changeStateOfActionButtons(false);
            button_StopAction.Enabled = true;

            Thread actionThread = new Thread(calculateThread);
            actionThread.Name = string.Format("Callculation thread");
            actionThread.IsBackground = true;
            actionThread.Start();
        }

        private void button_BeginAction_SortImages_Click(object sender, EventArgs e)
        {
            _manualStopAction = false;
            changeStateOfActionButtons(false);
            button_StopAction.Enabled = true;

            Thread actionThread = new Thread(renameAndSortThread);
            actionThread.Name = string.Format("Sorting thread");
            actionThread.IsBackground = true;
            actionThread.Start();
        }

        #endregion Action buttons

        private void calculateThread()
        {
            _histogramInfo.Clear();
            _calculationsFullyCompleted = false;
            int fileCount = 0;

            #region Calculating images data
            for (int i = 0; i < _images.Count; i++)
            {
                try
                {
                    FileInfo selectedFile = _images[i];
                    ImageInfo histInfo = new ImageInfo(selectedFile);
                    using (Bitmap image = new Bitmap(selectedFile.FullName))
                    {
                        ImageCalculations.CallculateImageColorInfo(image, ref histInfo);
                    }
                    _histogramInfo.Add(histInfo);
                    fileCount++;

                    Invoke(new Action(() =>
                    {
                        progressBar_ReprtProgress.Value = (int)(((i + 1) * 100) / _images.Count);
                    }));

                    if (_manualStopAction) break;
                }
                catch (Exception ex) { }
            }
            #endregion Calculating images data

            Invoke(new Action(() =>
            {
                if (fileCount == _images.Count)
                {
                    _calculationsFullyCompleted = true;
                    setMainFormState(MainWindowState.HistogramInfoCreated);
                }
                progressBar_ReprtProgress.Value = 0;
                button_StopAction.Enabled = false;
            }));

            createColorCoefReport();

            Invoke(new Action(() =>
            {
                showMessage("Calculating images color\ncoeficients completed");
            }));
        }

        private void createColorCoefReport()
        {
            if (_histogramInfo.Count > 1)
            {
                _histogramInfo = _histogramInfo.OrderBy(item => item.SizeCoef).ThenBy(item => item.ValueCoef).ThenBy(item => item.SaturationCoef).ToList();
            }

            string histogramInfoPath = Path.Combine(_actionDirectory, REPORTNAME);
            List<string> lines = new List<string>();

            try
            {
                if (!_calculationsFullyCompleted) lines.Add("The calculation has been interrupted - the report is incomplete.");

                lines.Add("Similar items:");
                foreach (ImageInfo infoFirst in _histogramInfo)
                {
                    foreach (ImageInfo infoSecond in _histogramInfo)
                    {
                        if (infoFirst.FileName != infoSecond.FileName)
                        {
                            if (infoFirst.IsSimilar(infoSecond, SIMILARITYCOEFFICIENT))
                            {
                                if (!lines.Contains(string.Format("{0} - {1}", infoSecond.FileName, infoFirst.FileName)))
                                {
                                    lines.Add(string.Format("{0} - {1}", infoFirst.FileName, infoSecond.FileName));
                                }
                            }
                        }
                    }
                }

                lines.Add("");

                foreach (ImageInfo info in _histogramInfo)
                {
                    if (checkBox_SumCoef.Checked) lines.Add(info.GetColorCoef());
                    else lines.Add(info.ToString());
                }

                File.WriteAllLines(histogramInfoPath, lines);
            }
            catch (Exception ex) { }
        }

        private void renameAndSortThread()
        {
            //Preparation of data for sorting - in case the image calculations has not been carried out.
            if (!_calculationsFullyCompleted && ImageComparisonMode.ImageComparison != ComparisonMode.ColorCoef)
            {
                _histogramInfo.Clear();

                for (int i = 0; i < _images.Count; i++)
                {
                    try
                    {
                        FileInfo selectedFile = _images[i];
                        ImageInfo histInfo = new ImageInfo(selectedFile);
                        using (Bitmap image = new Bitmap(selectedFile.FullName))
                        {
                            histInfo.SetSizeInfo(image.Width, image.Height);
                        }
                        _histogramInfo.Add(histInfo);
                    }
                    catch (Exception ex) { }
                }
            }

            //If names are only numeric values, sort by numeric value
            if (ImageComparisonMode.ImageComparison == ComparisonMode.FileName)
            {
                bool allowNumericSort = true;
                foreach (ImageInfo histInfo in _histogramInfo)
                {
                    int numericValue;
                    bool parsed = Int32.TryParse(Path.GetFileNameWithoutExtension(histInfo.FileName), out numericValue);
                    if (!parsed) { allowNumericSort = false; break; }
                }
                if (allowNumericSort) ImageComparisonMode.ImageComparison = ComparisonMode.NumericFileName;
            }
            _histogramInfo.Sort();

            string prefix = textBox_NamePrefix.Text;
            bool setTemporaryNames = !prefixIsNotUsed(prefix);

            if (setTemporaryNames)
            {
                #region Two step image renaming
                //Important assumption - There are no files in the directory with a name starting with "TemporaryName"
                for (int i = 0; i < _histogramInfo.Count; i++)
                {
                    try
                    {
                        string newFileName = string.Format("{0}{1}", TEMPORARYFILENAME, i);
                        _histogramInfo[i].CreateNewFileName(newFileName);
                        _histogramInfo[i].TryRenameFile();

                        Invoke(new Action(() =>
                        {
                            progressBar_ReprtProgress.Value = (int)(((i + 1) * 50) / _images.Count);
                        }));

                        if (_manualStopAction) break;
                    }
                    catch (Exception ex) { }
                }

                int index = (int)numericUpDown_FirstIndex.Value;
                for (int i = 0; i < _histogramInfo.Count; i++)
                {
                    try
                    {
                        string newFileName = string.Format("{0}{1}", prefix, index);
                        _histogramInfo[i].CreateNewFileName(newFileName);
                        _histogramInfo[i].TryRenameFile();

                        Invoke(new Action(() =>
                        {
                            progressBar_ReprtProgress.Value = 50 + (int)(((i + 1) * 50) / _images.Count);
                        }));

                        index++;
                        if (_manualStopAction) break;
                    }
                    catch (Exception ex) { }
                }
                #endregion Two step image renaming
            }
            else
            {
                #region Standard image renaming
                //There are no images in the directory with names that match the specified prefix - there is no name collision
                int index = (int)numericUpDown_FirstIndex.Value;
                for (int i = 0; i < _histogramInfo.Count; i++)
                {
                    try
                    {
                        string newFileName = string.Format("{0}{1}", prefix, index);
                        _histogramInfo[i].CreateNewFileName(newFileName);
                        _histogramInfo[i].TryRenameFile();

                        Invoke(new Action(() =>
                        {
                            progressBar_ReprtProgress.Value = (int)(((i + 1) * 100) / _images.Count);
                        }));

                        index++;
                        if (_manualStopAction) break;
                    }
                    catch (Exception ex) { }
                }
                #endregion Standard image renaming
            }

            if (_calculationsFullyCompleted && checkBox_RecreateReportAfterSorting.Checked) createColorCoefReport();
            Invoke(new Action(() =>
            {
                setMainFormState(MainWindowState.StartApplication);
                progressBar_ReprtProgress.Value = 0;
                button_StopAction.Enabled = false;
            }));

            Invoke(new Action(() =>
            {
                showMessage("File renaming and\nsorting completed");
            }));
        }

        private void button_StopAction_Click(object sender, EventArgs e)
        {
            _manualStopAction = true;
        }

        private bool prefixIsNotUsed(string prefix)
        {
            bool prefixIsNotUsed = true;
            for (int i = 0; i <= 9; i++)
            {
                string namePrefix = prefix + i.ToString();
                foreach (FileInfo file in _images)
                {
                    if (file.Name.StartsWith(namePrefix))
                    {
                        prefixIsNotUsed = false;
                    }
                }
            }
            return prefixIsNotUsed;
        }


        private void textBox_NamePrefix_TextChanged(object sender, EventArgs e)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            textBox_NamePrefix.Text = string.Join("", textBox_NamePrefix.Text.Split(invalidChars));
            textBox_NamePrefix.SelectionStart = textBox_NamePrefix.Text.Length + 1;
        }

        #region Options buttons
        private void radioButton_SortByFilename_CheckedChanged(object sender, EventArgs e)
        {
            ImageComparisonMode.ImageComparison = ComparisonMode.FileName;
        }

        private void radioButton_SortBySize_CheckedChanged(object sender, EventArgs e)
        {
            ImageComparisonMode.ImageComparison = ComparisonMode.Size;
        }

        private void radioButton_SortByProperties_CheckedChanged(object sender, EventArgs e)
        {
            ImageComparisonMode.ImageComparison = ComparisonMode.ImageProperties;
        }

        private void radioButton_SortByColor_CheckedChanged(object sender, EventArgs e)
        {
            ImageComparisonMode.ImageComparison = ComparisonMode.ColorCoef;
        }
        #endregion Options buttons

        #region Info labels
        private void setDirectoryHint(string path)
        {
            DirectoryInfo actionDirectoryInfo = new DirectoryInfo(path);
            if (actionDirectoryInfo.Exists)
            {
                if (path.Length > MAXDIRLABELLENGTH)
                {
                    string partition = actionDirectoryInfo.Root.Name;
                    string directoryName = actionDirectoryInfo.Name;
                    string labelInfo = string.Format("{0}...\\{1}", partition, directoryName);
                    if (actionDirectoryInfo.Parent != null)
                    {
                        string parentName = actionDirectoryInfo.Parent.Name;
                        string labelParentInfo = string.Format("{0}...\\{1}\\{2}", partition, parentName, directoryName);
                        if (labelParentInfo.Length < MAXDIRLABELLENGTH) labelInfo = labelParentInfo;
                    }

                    label_DirectoryPath.Text = labelInfo;
                    _toolTip.SetToolTip(label_DirectoryPath, path);
                }
                else
                {
                    label_DirectoryPath.Text = path;
                    _toolTip.SetToolTip(label_DirectoryPath, null);
                }
            }
        }

        private void setHints()
        {
            _toolTip.SetToolTip(checkBox_SumCoef, "Place the Color sum at beginning of each image data.");
            _toolTip.SetToolTip(checkBox_RecreateReportAfterSorting, "Re-create the Report after renaming images.");

            string namePrefixHint = string.Format("Max prefix length is {0} characters", textBox_NamePrefix.MaxLength);
            _toolTip.SetToolTip(label_NamePrefix, namePrefixHint);
            _toolTip.SetToolTip(textBox_NamePrefix, namePrefixHint);
        }

        private void setImagesCount()
        {
            if (_images.Count > 0)
            {
                label_ImagesCount.Text = "Images found: " + _images.Count.ToString();
                _toolTip.SetToolTip(label_ImagesCount, "Images type: .bmp; .jpeg; .jpg; .png.");
            }
            else
            {
                label_ImagesCount.Text = "No suported images in directory.";
            }
        }

        private void showMessage(string message)
        {
            MessageBox_Form messageForm = new MessageBox_Form(message);
            messageForm.ShowDialog(this);
        }

        #endregion Info labels

        #region Window state modules

        private void setMainFormState(MainWindowState state)
        {
            switch (state) 
            {
                case MainWindowState.StartApplication:
                    changeStateOfActionButtons(false);
                    button_StopAction.Enabled = false;
                    _calculationsFullyCompleted = false;
                    label_ImagesCount.Text = string.Empty;
                    break;

                case MainWindowState.FileInfoLoaded:
                    changeStateOfActionButtons(true);
                    if (radioButton_SortByProperties.Checked || radioButton_SortByColor.Checked) radioButton_SortBySize.Select();
                    radioButton_SortByProperties.Enabled = false;
                    radioButton_SortByColor.Enabled = false;
                    break;

                case MainWindowState.HistogramInfoCreated:
                    changeStateOfActionButtons(true);
                    radioButton_SortByProperties.Enabled = true;
                    radioButton_SortByColor.Enabled = true;
                    break;
            }
        }

        private void changeStateOfActionButtons(bool state)
        {
            button_BeginAction_Calculate.Enabled = state;
            groupBox_ReportOptions.Enabled = state;
            checkBox_SumCoef.Enabled = state;
            checkBox_RecreateReportAfterSorting.Enabled = state;
            groupBox_Sorting.Enabled = state;
            button_BeginAction_SortImages.Enabled = state;
            textBox_NamePrefix.Enabled = state;
            label_NamePrefix.Enabled = state;
            numericUpDown_FirstIndex.Enabled = state;
            label_FirstIndex.Enabled = state;
        }

        private Point _mouseDownLocation;

        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _mouseDownLocation = e.Location;
            }
        }

        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - _mouseDownLocation.X;
                this.Top = e.Y + this.Top - _mouseDownLocation.Y;
            }
        }

        private void button_Minimalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Window state modules
    }
}
