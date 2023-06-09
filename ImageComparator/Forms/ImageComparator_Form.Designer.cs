namespace ImageComparator
{
    partial class ImageComparator_Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Directory = new System.Windows.Forms.Label();
            this.label_DirectoryPath = new System.Windows.Forms.Label();
            this.label_ImagesCount = new System.Windows.Forms.Label();
            this.checkBox_SumCoef = new System.Windows.Forms.CheckBox();
            this.groupBox_Sorting = new System.Windows.Forms.GroupBox();
            this.radioButton_SortByColor = new System.Windows.Forms.RadioButton();
            this.radioButton_SortByProperties = new System.Windows.Forms.RadioButton();
            this.radioButton_SortBySize = new System.Windows.Forms.RadioButton();
            this.radioButton_SortByFilename = new System.Windows.Forms.RadioButton();
            this.textBox_NamePrefix = new System.Windows.Forms.TextBox();
            this.label_NamePrefix = new System.Windows.Forms.Label();
            this.checkBox_RecreateReportAfterSorting = new System.Windows.Forms.CheckBox();
            this.groupBox_ReportOptions = new System.Windows.Forms.GroupBox();
            this.numericUpDown_FirstIndex = new System.Windows.Forms.NumericUpDown();
            this.label_FirstIndex = new System.Windows.Forms.Label();
            this.progressBar_ReprtProgress = new ImageComparator.Controls.CustomProgressBar();
            this.button_BeginAction_SortImages = new ImageComparator.Controls.CustomButton();
            this.button_BeginAction_Calculate = new ImageComparator.Controls.CustomButton();
            this.button_CreateImageList = new ImageComparator.Controls.CustomButton();
            this.button_StopAction = new ImageComparator.Controls.NavigationButton();
            this.button_ChangeDirectory = new ImageComparator.Controls.NavigationButton();
            this.button_Minimize = new ImageComparator.Controls.NavigationButton();
            this.button_Close = new ImageComparator.Controls.NavigationButton();
            this.groupBox_Sorting.SuspendLayout();
            this.groupBox_ReportOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FirstIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Directory
            // 
            this.label_Directory.AutoSize = true;
            this.label_Directory.BackColor = System.Drawing.Color.Transparent;
            this.label_Directory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Directory.ForeColor = System.Drawing.Color.White;
            this.label_Directory.Location = new System.Drawing.Point(48, 19);
            this.label_Directory.Name = "label_Directory";
            this.label_Directory.Size = new System.Drawing.Size(102, 16);
            this.label_Directory.TabIndex = 6;
            this.label_Directory.Text = "Action directory:";
            // 
            // label_DirectoryPath
            // 
            this.label_DirectoryPath.AutoSize = true;
            this.label_DirectoryPath.BackColor = System.Drawing.Color.Transparent;
            this.label_DirectoryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DirectoryPath.ForeColor = System.Drawing.Color.White;
            this.label_DirectoryPath.Location = new System.Drawing.Point(12, 44);
            this.label_DirectoryPath.MaximumSize = new System.Drawing.Size(300, 0);
            this.label_DirectoryPath.Name = "label_DirectoryPath";
            this.label_DirectoryPath.Size = new System.Drawing.Size(14, 16);
            this.label_DirectoryPath.TabIndex = 8;
            this.label_DirectoryPath.Text = "_";
            // 
            // label_ImagesCount
            // 
            this.label_ImagesCount.AutoSize = true;
            this.label_ImagesCount.BackColor = System.Drawing.Color.Transparent;
            this.label_ImagesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ImagesCount.ForeColor = System.Drawing.Color.White;
            this.label_ImagesCount.Location = new System.Drawing.Point(113, 108);
            this.label_ImagesCount.Name = "label_ImagesCount";
            this.label_ImagesCount.Size = new System.Drawing.Size(14, 16);
            this.label_ImagesCount.TabIndex = 10;
            this.label_ImagesCount.Text = "_";
            // 
            // checkBox_SumCoef
            // 
            this.checkBox_SumCoef.AutoSize = true;
            this.checkBox_SumCoef.Location = new System.Drawing.Point(6, 19);
            this.checkBox_SumCoef.Name = "checkBox_SumCoef";
            this.checkBox_SumCoef.Size = new System.Drawing.Size(104, 17);
            this.checkBox_SumCoef.TabIndex = 13;
            this.checkBox_SumCoef.Text = "Color Value Sum";
            this.checkBox_SumCoef.UseVisualStyleBackColor = true;
            // 
            // groupBox_Sorting
            // 
            this.groupBox_Sorting.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Sorting.Controls.Add(this.radioButton_SortByColor);
            this.groupBox_Sorting.Controls.Add(this.radioButton_SortByProperties);
            this.groupBox_Sorting.Controls.Add(this.radioButton_SortBySize);
            this.groupBox_Sorting.Controls.Add(this.radioButton_SortByFilename);
            this.groupBox_Sorting.ForeColor = System.Drawing.Color.White;
            this.groupBox_Sorting.Location = new System.Drawing.Point(113, 218);
            this.groupBox_Sorting.Name = "groupBox_Sorting";
            this.groupBox_Sorting.Size = new System.Drawing.Size(116, 113);
            this.groupBox_Sorting.TabIndex = 15;
            this.groupBox_Sorting.TabStop = false;
            this.groupBox_Sorting.Text = "Sort by:";
            // 
            // radioButton_SortByColor
            // 
            this.radioButton_SortByColor.AutoSize = true;
            this.radioButton_SortByColor.Location = new System.Drawing.Point(6, 88);
            this.radioButton_SortByColor.Name = "radioButton_SortByColor";
            this.radioButton_SortByColor.Size = new System.Drawing.Size(107, 17);
            this.radioButton_SortByColor.TabIndex = 3;
            this.radioButton_SortByColor.Text = "Color Coefficients";
            this.radioButton_SortByColor.UseVisualStyleBackColor = true;
            this.radioButton_SortByColor.CheckedChanged += new System.EventHandler(this.radioButton_SortByColor_CheckedChanged);
            // 
            // radioButton_SortByProperties
            // 
            this.radioButton_SortByProperties.AutoSize = true;
            this.radioButton_SortByProperties.Location = new System.Drawing.Point(6, 65);
            this.radioButton_SortByProperties.Name = "radioButton_SortByProperties";
            this.radioButton_SortByProperties.Size = new System.Drawing.Size(104, 17);
            this.radioButton_SortByProperties.TabIndex = 2;
            this.radioButton_SortByProperties.Text = "Image Properties";
            this.radioButton_SortByProperties.UseVisualStyleBackColor = true;
            this.radioButton_SortByProperties.CheckedChanged += new System.EventHandler(this.radioButton_SortByProperties_CheckedChanged);
            // 
            // radioButton_SortBySize
            // 
            this.radioButton_SortBySize.AutoSize = true;
            this.radioButton_SortBySize.Checked = true;
            this.radioButton_SortBySize.Location = new System.Drawing.Point(6, 42);
            this.radioButton_SortBySize.Name = "radioButton_SortBySize";
            this.radioButton_SortBySize.Size = new System.Drawing.Size(45, 17);
            this.radioButton_SortBySize.TabIndex = 1;
            this.radioButton_SortBySize.TabStop = true;
            this.radioButton_SortBySize.Text = "Size";
            this.radioButton_SortBySize.UseVisualStyleBackColor = true;
            this.radioButton_SortBySize.CheckedChanged += new System.EventHandler(this.radioButton_SortBySize_CheckedChanged);
            // 
            // radioButton_SortByFilename
            // 
            this.radioButton_SortByFilename.AutoSize = true;
            this.radioButton_SortByFilename.Location = new System.Drawing.Point(6, 19);
            this.radioButton_SortByFilename.Name = "radioButton_SortByFilename";
            this.radioButton_SortByFilename.Size = new System.Drawing.Size(67, 17);
            this.radioButton_SortByFilename.TabIndex = 0;
            this.radioButton_SortByFilename.Text = "Filename";
            this.radioButton_SortByFilename.UseVisualStyleBackColor = true;
            this.radioButton_SortByFilename.CheckedChanged += new System.EventHandler(this.radioButton_SortByFilename_CheckedChanged);
            // 
            // textBox_NamePrefix
            // 
            this.textBox_NamePrefix.Location = new System.Drawing.Point(12, 234);
            this.textBox_NamePrefix.MaxLength = 16;
            this.textBox_NamePrefix.Name = "textBox_NamePrefix";
            this.textBox_NamePrefix.Size = new System.Drawing.Size(95, 20);
            this.textBox_NamePrefix.TabIndex = 17;
            this.textBox_NamePrefix.TextChanged += new System.EventHandler(this.textBox_NamePrefix_TextChanged);
            // 
            // label_NamePrefix
            // 
            this.label_NamePrefix.AutoSize = true;
            this.label_NamePrefix.BackColor = System.Drawing.Color.Transparent;
            this.label_NamePrefix.ForeColor = System.Drawing.Color.White;
            this.label_NamePrefix.Location = new System.Drawing.Point(12, 218);
            this.label_NamePrefix.Name = "label_NamePrefix";
            this.label_NamePrefix.Size = new System.Drawing.Size(71, 13);
            this.label_NamePrefix.TabIndex = 18;
            this.label_NamePrefix.Text = "Names prefix:";
            // 
            // checkBox_RecreateReportAfterSorting
            // 
            this.checkBox_RecreateReportAfterSorting.AutoSize = true;
            this.checkBox_RecreateReportAfterSorting.Location = new System.Drawing.Point(6, 42);
            this.checkBox_RecreateReportAfterSorting.Name = "checkBox_RecreateReportAfterSorting";
            this.checkBox_RecreateReportAfterSorting.Size = new System.Drawing.Size(70, 17);
            this.checkBox_RecreateReportAfterSorting.TabIndex = 19;
            this.checkBox_RecreateReportAfterSorting.Text = "Recreate";
            this.checkBox_RecreateReportAfterSorting.UseVisualStyleBackColor = true;
            // 
            // groupBox_ReportOptions
            // 
            this.groupBox_ReportOptions.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_ReportOptions.Controls.Add(this.checkBox_SumCoef);
            this.groupBox_ReportOptions.Controls.Add(this.checkBox_RecreateReportAfterSorting);
            this.groupBox_ReportOptions.ForeColor = System.Drawing.Color.White;
            this.groupBox_ReportOptions.Location = new System.Drawing.Point(113, 145);
            this.groupBox_ReportOptions.Name = "groupBox_ReportOptions";
            this.groupBox_ReportOptions.Size = new System.Drawing.Size(116, 65);
            this.groupBox_ReportOptions.TabIndex = 20;
            this.groupBox_ReportOptions.TabStop = false;
            this.groupBox_ReportOptions.Text = "Report options:";
            // 
            // numericUpDown_FirstIndex
            // 
            this.numericUpDown_FirstIndex.Location = new System.Drawing.Point(12, 278);
            this.numericUpDown_FirstIndex.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_FirstIndex.Name = "numericUpDown_FirstIndex";
            this.numericUpDown_FirstIndex.Size = new System.Drawing.Size(95, 20);
            this.numericUpDown_FirstIndex.TabIndex = 21;
            this.numericUpDown_FirstIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_FirstIndex
            // 
            this.label_FirstIndex.AutoSize = true;
            this.label_FirstIndex.BackColor = System.Drawing.Color.Transparent;
            this.label_FirstIndex.ForeColor = System.Drawing.Color.White;
            this.label_FirstIndex.Location = new System.Drawing.Point(12, 262);
            this.label_FirstIndex.Name = "label_FirstIndex";
            this.label_FirstIndex.Size = new System.Drawing.Size(57, 13);
            this.label_FirstIndex.TabIndex = 22;
            this.label_FirstIndex.Text = "First index:";
            // 
            // progressBar_ReprtProgress
            // 
            this.progressBar_ReprtProgress.BackColor = System.Drawing.Color.White;
            this.progressBar_ReprtProgress.Location = new System.Drawing.Point(12, 358);
            this.progressBar_ReprtProgress.Name = "progressBar_ReprtProgress";
            this.progressBar_ReprtProgress.Size = new System.Drawing.Size(217, 25);
            this.progressBar_ReprtProgress.TabIndex = 30;
            this.progressBar_ReprtProgress.Value = 0;
            // 
            // button_BeginAction_SortImages
            // 
            this.button_BeginAction_SortImages.BackColor = System.Drawing.Color.Transparent;
            this.button_BeginAction_SortImages.Location = new System.Drawing.Point(12, 307);
            this.button_BeginAction_SortImages.Name = "button_BeginAction_SortImages";
            this.button_BeginAction_SortImages.Size = new System.Drawing.Size(95, 45);
            this.button_BeginAction_SortImages.TabIndex = 29;
            this.button_BeginAction_SortImages.Text = "Rename and Sort";
            this.button_BeginAction_SortImages.TextSize = 10;
            this.button_BeginAction_SortImages.Click += new System.EventHandler(this.button_BeginAction_SortImages_Click);
            // 
            // button_BeginAction_Calculate
            // 
            this.button_BeginAction_Calculate.BackColor = System.Drawing.Color.Transparent;
            this.button_BeginAction_Calculate.Location = new System.Drawing.Point(12, 145);
            this.button_BeginAction_Calculate.Name = "button_BeginAction_Calculate";
            this.button_BeginAction_Calculate.Size = new System.Drawing.Size(95, 45);
            this.button_BeginAction_Calculate.TabIndex = 28;
            this.button_BeginAction_Calculate.Text = "Calculate";
            this.button_BeginAction_Calculate.TextSize = 12;
            this.button_BeginAction_Calculate.Click += new System.EventHandler(this.button_BeginAction_Calculate_Click);
            // 
            // button_CreateImageList
            // 
            this.button_CreateImageList.BackColor = System.Drawing.Color.Transparent;
            this.button_CreateImageList.Location = new System.Drawing.Point(12, 94);
            this.button_CreateImageList.Name = "button_CreateImageList";
            this.button_CreateImageList.Size = new System.Drawing.Size(95, 45);
            this.button_CreateImageList.TabIndex = 27;
            this.button_CreateImageList.Text = "Create image list";
            this.button_CreateImageList.TextSize = 10;
            this.button_CreateImageList.Click += new System.EventHandler(this.button_CreateImageList_Click);
            // 
            // button_StopAction
            // 
            this.button_StopAction.BackColor = System.Drawing.Color.Transparent;
            this.button_StopAction.ButtonType = ImageComparator.NavigationButtonType.Stop;
            this.button_StopAction.Location = new System.Drawing.Point(241, 354);
            this.button_StopAction.Name = "button_StopAction";
            this.button_StopAction.Size = new System.Drawing.Size(32, 32);
            this.button_StopAction.TabIndex = 26;
            this.button_StopAction.Click += new System.EventHandler(this.button_StopAction_Click);
            // 
            // button_ChangeDirectory
            // 
            this.button_ChangeDirectory.BackColor = System.Drawing.Color.Transparent;
            this.button_ChangeDirectory.ButtonType = ImageComparator.NavigationButtonType.BrowseDirectory;
            this.button_ChangeDirectory.Location = new System.Drawing.Point(12, 8);
            this.button_ChangeDirectory.Name = "button_ChangeDirectory";
            this.button_ChangeDirectory.Size = new System.Drawing.Size(32, 32);
            this.button_ChangeDirectory.TabIndex = 25;
            this.button_ChangeDirectory.Click += new System.EventHandler(this.button_ChangeDirectory_Click);
            // 
            // button_Minimize
            // 
            this.button_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.button_Minimize.ButtonType = ImageComparator.NavigationButtonType.Minimize;
            this.button_Minimize.Location = new System.Drawing.Point(241, 8);
            this.button_Minimize.Name = "button_Minimize";
            this.button_Minimize.Size = new System.Drawing.Size(32, 32);
            this.button_Minimize.TabIndex = 24;
            this.button_Minimize.Click += new System.EventHandler(this.button_Minimalize_Click);
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.Transparent;
            this.button_Close.ButtonType = ImageComparator.NavigationButtonType.Close;
            this.button_Close.Location = new System.Drawing.Point(279, 8);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(32, 32);
            this.button_Close.TabIndex = 23;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // ImageComparator_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.BackgroundImage = global::ImageComparator.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(318, 398);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar_ReprtProgress);
            this.Controls.Add(this.button_BeginAction_SortImages);
            this.Controls.Add(this.button_BeginAction_Calculate);
            this.Controls.Add(this.button_CreateImageList);
            this.Controls.Add(this.button_StopAction);
            this.Controls.Add(this.button_ChangeDirectory);
            this.Controls.Add(this.button_Minimize);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_FirstIndex);
            this.Controls.Add(this.numericUpDown_FirstIndex);
            this.Controls.Add(this.groupBox_ReportOptions);
            this.Controls.Add(this.label_NamePrefix);
            this.Controls.Add(this.textBox_NamePrefix);
            this.Controls.Add(this.groupBox_Sorting);
            this.Controls.Add(this.label_ImagesCount);
            this.Controls.Add(this.label_DirectoryPath);
            this.Controls.Add(this.label_Directory);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ImageComparator_Form";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseMove);
            this.groupBox_Sorting.ResumeLayout(false);
            this.groupBox_Sorting.PerformLayout();
            this.groupBox_ReportOptions.ResumeLayout(false);
            this.groupBox_ReportOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FirstIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Directory;
        private System.Windows.Forms.Label label_DirectoryPath;
        private System.Windows.Forms.Label label_ImagesCount;
        private System.Windows.Forms.CheckBox checkBox_SumCoef;
        private System.Windows.Forms.GroupBox groupBox_Sorting;
        private System.Windows.Forms.RadioButton radioButton_SortByProperties;
        private System.Windows.Forms.RadioButton radioButton_SortBySize;
        private System.Windows.Forms.RadioButton radioButton_SortByFilename;
        private System.Windows.Forms.TextBox textBox_NamePrefix;
        private System.Windows.Forms.Label label_NamePrefix;
        private System.Windows.Forms.CheckBox checkBox_RecreateReportAfterSorting;
        private System.Windows.Forms.GroupBox groupBox_ReportOptions;
        private System.Windows.Forms.NumericUpDown numericUpDown_FirstIndex;
        private System.Windows.Forms.Label label_FirstIndex;
        private Controls.NavigationButton button_Close;
        private Controls.NavigationButton button_Minimize;
        private Controls.NavigationButton button_ChangeDirectory;
        private Controls.NavigationButton button_StopAction;
        private Controls.CustomButton button_CreateImageList;
        private Controls.CustomButton button_BeginAction_Calculate;
        private Controls.CustomButton button_BeginAction_SortImages;
        private Controls.CustomProgressBar progressBar_ReprtProgress;
        private System.Windows.Forms.RadioButton radioButton_SortByColor;
    }
}

