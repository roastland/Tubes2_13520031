
namespace Tubes2_13520031
{
    partial class MainForm
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
            this.inputFileNameText = new System.Windows.Forms.Label();
            this.inputFileName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.searchMethodText = new System.Windows.Forms.Label();
            this.searchButtonPanel = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchMethodPanel = new System.Windows.Forms.Panel();
            this.searchMethod = new System.Windows.Forms.ComboBox();
            this.fileNamePanel = new System.Windows.Forms.Panel();
            this.findAllOccurence = new System.Windows.Forms.CheckBox();
            this.directoryPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chooseStartingDirectoryText = new System.Windows.Forms.Label();
            this.chooseFolderButton = new System.Windows.Forms.Button();
            this.directoryChoosen = new System.Windows.Forms.Label();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.searchWorker = new System.ComponentModel.BackgroundWorker();
            this.outputTextPanel = new System.Windows.Forms.Panel();
            this.outputText = new System.Windows.Forms.Label();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.timeAndDirectoryPanel = new System.Windows.Forms.Panel();
            this.pathDirectory = new System.Windows.Forms.Label();
            this.timeSpentText = new System.Windows.Forms.Label();
            this.searchButtonPanel.SuspendLayout();
            this.searchMethodPanel.SuspendLayout();
            this.fileNamePanel.SuspendLayout();
            this.directoryPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.outputTextPanel.SuspendLayout();
            this.timeAndDirectoryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputFileNameText
            // 
            this.inputFileNameText.AutoSize = true;
            this.inputFileNameText.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputFileNameText.Location = new System.Drawing.Point(12, 20);
            this.inputFileNameText.Name = "inputFileNameText";
            this.inputFileNameText.Size = new System.Drawing.Size(138, 23);
            this.inputFileNameText.TabIndex = 3;
            this.inputFileNameText.Text = "Input file name";
            // 
            // inputFileName
            // 
            this.inputFileName.Location = new System.Drawing.Point(16, 43);
            this.inputFileName.Name = "inputFileName";
            this.inputFileName.Size = new System.Drawing.Size(209, 22);
            this.inputFileName.TabIndex = 4;
            // 
            // searchMethodText
            // 
            this.searchMethodText.AutoSize = true;
            this.searchMethodText.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchMethodText.Location = new System.Drawing.Point(12, 20);
            this.searchMethodText.Name = "searchMethodText";
            this.searchMethodText.Size = new System.Drawing.Size(137, 23);
            this.searchMethodText.TabIndex = 6;
            this.searchMethodText.Text = "Search Method";
            // 
            // searchButtonPanel
            // 
            this.searchButtonPanel.BackColor = System.Drawing.Color.Honeydew;
            this.searchButtonPanel.Controls.Add(this.searchButton);
            this.searchButtonPanel.Controls.Add(this.searchMethodPanel);
            this.searchButtonPanel.Controls.Add(this.fileNamePanel);
            this.searchButtonPanel.Controls.Add(this.directoryPanel);
            this.searchButtonPanel.Controls.Add(this.titlePanel);
            this.searchButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.searchButtonPanel.Name = "searchButtonPanel";
            this.searchButtonPanel.Size = new System.Drawing.Size(507, 726);
            this.searchButtonPanel.TabIndex = 8;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.White;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.searchButton.Location = new System.Drawing.Point(149, 350);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(177, 40);
            this.searchButton.TabIndex = 11;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchMethodPanel
            // 
            this.searchMethodPanel.BackColor = System.Drawing.Color.Honeydew;
            this.searchMethodPanel.Controls.Add(this.searchMethodText);
            this.searchMethodPanel.Controls.Add(this.searchMethod);
            this.searchMethodPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchMethodPanel.Location = new System.Drawing.Point(0, 220);
            this.searchMethodPanel.Name = "searchMethodPanel";
            this.searchMethodPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.searchMethodPanel.Size = new System.Drawing.Size(507, 100);
            this.searchMethodPanel.TabIndex = 9;
            // 
            // searchMethod
            // 
            this.searchMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchMethod.FormattingEnabled = true;
            this.searchMethod.Items.AddRange(new object[] {
            "BFS",
            "DFS"});
            this.searchMethod.Location = new System.Drawing.Point(16, 43);
            this.searchMethod.Name = "searchMethod";
            this.searchMethod.Size = new System.Drawing.Size(121, 24);
            this.searchMethod.TabIndex = 7;
            // 
            // fileNamePanel
            // 
            this.fileNamePanel.BackColor = System.Drawing.Color.Honeydew;
            this.fileNamePanel.Controls.Add(this.findAllOccurence);
            this.fileNamePanel.Controls.Add(this.inputFileNameText);
            this.fileNamePanel.Controls.Add(this.inputFileName);
            this.fileNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileNamePanel.Location = new System.Drawing.Point(0, 100);
            this.fileNamePanel.Name = "fileNamePanel";
            this.fileNamePanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.fileNamePanel.Size = new System.Drawing.Size(507, 120);
            this.fileNamePanel.TabIndex = 10;
            // 
            // findAllOccurence
            // 
            this.findAllOccurence.AutoSize = true;
            this.findAllOccurence.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.findAllOccurence.Location = new System.Drawing.Point(16, 74);
            this.findAllOccurence.Name = "findAllOccurence";
            this.findAllOccurence.Size = new System.Drawing.Size(147, 21);
            this.findAllOccurence.TabIndex = 9;
            this.findAllOccurence.Text = "Find all occurence";
            this.findAllOccurence.UseVisualStyleBackColor = true;
            this.findAllOccurence.CheckedChanged += new System.EventHandler(this.findAllOccurence_CheckedChanged);
            // 
            // directoryPanel
            // 
            this.directoryPanel.BackColor = System.Drawing.Color.Honeydew;
            this.directoryPanel.Controls.Add(this.panel2);
            this.directoryPanel.Controls.Add(this.panel1);
            this.directoryPanel.Controls.Add(this.chooseStartingDirectoryText);
            this.directoryPanel.Controls.Add(this.chooseFolderButton);
            this.directoryPanel.Controls.Add(this.directoryChoosen);
            this.directoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.directoryPanel.Location = new System.Drawing.Point(0, 0);
            this.directoryPanel.Name = "directoryPanel";
            this.directoryPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.directoryPanel.Size = new System.Drawing.Size(507, 100);
            this.directoryPanel.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(506, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(506, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 504);
            this.panel1.TabIndex = 9;
            // 
            // chooseStartingDirectoryText
            // 
            this.chooseStartingDirectoryText.AutoSize = true;
            this.chooseStartingDirectoryText.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseStartingDirectoryText.Location = new System.Drawing.Point(12, 18);
            this.chooseStartingDirectoryText.Name = "chooseStartingDirectoryText";
            this.chooseStartingDirectoryText.Size = new System.Drawing.Size(224, 23);
            this.chooseStartingDirectoryText.TabIndex = 1;
            this.chooseStartingDirectoryText.Text = "Choose starting directory";
            // 
            // chooseFolderButton
            // 
            this.chooseFolderButton.BackColor = System.Drawing.Color.White;
            this.chooseFolderButton.FlatAppearance.BorderSize = 0;
            this.chooseFolderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.chooseFolderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.chooseFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chooseFolderButton.Location = new System.Drawing.Point(16, 49);
            this.chooseFolderButton.Name = "chooseFolderButton";
            this.chooseFolderButton.Size = new System.Drawing.Size(124, 35);
            this.chooseFolderButton.TabIndex = 2;
            this.chooseFolderButton.Text = "Choose folder...";
            this.chooseFolderButton.UseVisualStyleBackColor = false;
            this.chooseFolderButton.Click += new System.EventHandler(this.chooseFolder_Click);
            // 
            // directoryChoosen
            // 
            this.directoryChoosen.AutoSize = true;
            this.directoryChoosen.Location = new System.Drawing.Point(146, 61);
            this.directoryChoosen.Name = "directoryChoosen";
            this.directoryChoosen.Size = new System.Drawing.Size(116, 16);
            this.directoryChoosen.TabIndex = 5;
            this.directoryChoosen.Text = "No Folder Chosen";
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.White;
            this.titlePanel.Controls.Add(this.title);
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(507, 101);
            this.titlePanel.TabIndex = 9;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Bahnschrift Condensed", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(12, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(232, 52);
            this.title.TabIndex = 9;
            this.title.Text = "Folder Crawler";
            // 
            // searchWorker
            // 
            this.searchWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SearchFile);
            // 
            // outputTextPanel
            // 
            this.outputTextPanel.BackColor = System.Drawing.Color.MintCream;
            this.outputTextPanel.Controls.Add(this.outputText);
            this.outputTextPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.outputTextPanel.Location = new System.Drawing.Point(507, 0);
            this.outputTextPanel.Name = "outputTextPanel";
            this.outputTextPanel.Size = new System.Drawing.Size(1014, 54);
            this.outputTextPanel.TabIndex = 0;
            // 
            // outputText
            // 
            this.outputText.AutoSize = true;
            this.outputText.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.Location = new System.Drawing.Point(19, 18);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(70, 23);
            this.outputText.TabIndex = 6;
            this.outputText.Text = "Output";
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.BackColor = System.Drawing.Color.MintCream;
            this.graphPanel.Location = new System.Drawing.Point(506, 155);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(1015, 571);
            this.graphPanel.TabIndex = 9;
            // 
            // timeAndDirectoryPanel
            // 
            this.timeAndDirectoryPanel.BackColor = System.Drawing.Color.MintCream;
            this.timeAndDirectoryPanel.Controls.Add(this.pathDirectory);
            this.timeAndDirectoryPanel.Controls.Add(this.timeSpentText);
            this.timeAndDirectoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeAndDirectoryPanel.Location = new System.Drawing.Point(507, 54);
            this.timeAndDirectoryPanel.Name = "timeAndDirectoryPanel";
            this.timeAndDirectoryPanel.Size = new System.Drawing.Size(1014, 100);
            this.timeAndDirectoryPanel.TabIndex = 10;
            //this.timeAndDirectoryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.timeAndDirectoryPanel_Paint);
            // 
            // pathDirectory
            // 
            this.pathDirectory.AutoSize = true;
            this.pathDirectory.Location = new System.Drawing.Point(20, 46);
            this.pathDirectory.Name = "pathDirectory";
            this.pathDirectory.Size = new System.Drawing.Size(0, 16);
            this.pathDirectory.TabIndex = 1;
            this.pathDirectory.Text = "Path directory : ";
            // 
            // timeSpentText
            // 
            this.timeSpentText.AutoSize = true;
            this.timeSpentText.Location = new System.Drawing.Point(20, 14);
            this.timeSpentText.Name = "timeSpentText";
            this.timeSpentText.Size = new System.Drawing.Size(0, 16);
            this.timeSpentText.TabIndex = 0;
            this.timeSpentText.Text = "Time spent : ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1521, 726);
            this.Controls.Add(this.timeAndDirectoryPanel);
            this.Controls.Add(this.outputTextPanel);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.searchButtonPanel);
            this.MinimumSize = new System.Drawing.Size(515, 460);
            this.Name = "MainForm";
            this.Text = "Folder Crawling";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.searchButtonPanel.ResumeLayout(false);
            this.searchMethodPanel.ResumeLayout(false);
            this.searchMethodPanel.PerformLayout();
            this.fileNamePanel.ResumeLayout(false);
            this.fileNamePanel.PerformLayout();
            this.directoryPanel.ResumeLayout(false);
            this.directoryPanel.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.outputTextPanel.ResumeLayout(false);
            this.outputTextPanel.PerformLayout();
            this.timeAndDirectoryPanel.ResumeLayout(false);
            this.timeAndDirectoryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label inputFileNameText;
        private System.Windows.Forms.TextBox inputFileName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label searchMethodText;
        private System.Windows.Forms.Panel searchButtonPanel;
        private System.Windows.Forms.ComboBox searchMethod;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel searchMethodPanel;
        private System.Windows.Forms.Panel fileNamePanel;
        private System.Windows.Forms.Panel directoryPanel;
        private System.Windows.Forms.Label chooseStartingDirectoryText;
        private System.Windows.Forms.Button chooseFolderButton;
        private System.Windows.Forms.Label directoryChoosen;
        private System.Windows.Forms.CheckBox findAllOccurence;
        private System.Windows.Forms.Button searchButton;
        private System.ComponentModel.BackgroundWorker searchWorker;
        private System.Windows.Forms.Panel outputTextPanel;
        private System.Windows.Forms.Label outputText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel timeAndDirectoryPanel;
        private System.Windows.Forms.Label timeSpentText;
        private System.Windows.Forms.Label pathDirectory;
    }
}

