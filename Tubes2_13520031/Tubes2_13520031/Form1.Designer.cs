
namespace Tubes2_13520031
{
    partial class Form1
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
            this.InputFileName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchMethodPanel = new System.Windows.Forms.Panel();
            this.searchMethod = new System.Windows.Forms.ComboBox();
            this.fileNamePanel = new System.Windows.Forms.Panel();
            this.FindAllOccurence = new System.Windows.Forms.CheckBox();
            this.directoryPanel = new System.Windows.Forms.Panel();
            this.chooseStartingDirectoryText = new System.Windows.Forms.Label();
            this.chooseFolderButton = new System.Windows.Forms.Button();
            this.directoryChoosen = new System.Windows.Forms.Label();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.searchMethodPanel.SuspendLayout();
            this.fileNamePanel.SuspendLayout();
            this.directoryPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
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
            this.inputFileNameText.Click += new System.EventHandler(this.label2_Click);
            // 
            // InputFileName
            // 
            this.InputFileName.Location = new System.Drawing.Point(16, 43);
            this.InputFileName.Name = "InputFileName";
            this.InputFileName.Size = new System.Drawing.Size(209, 22);
            this.InputFileName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Search Method";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.searchMethodPanel);
            this.panel1.Controls.Add(this.fileNamePanel);
            this.panel1.Controls.Add(this.directoryPanel);
            this.panel1.Controls.Add(this.titlePanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 413);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.searchButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // searchMethodPanel
            // 
            this.searchMethodPanel.BackColor = System.Drawing.Color.White;
            this.searchMethodPanel.Controls.Add(this.label4);
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
            this.fileNamePanel.BackColor = System.Drawing.Color.White;
            this.fileNamePanel.Controls.Add(this.FindAllOccurence);
            this.fileNamePanel.Controls.Add(this.inputFileNameText);
            this.fileNamePanel.Controls.Add(this.InputFileName);
            this.fileNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileNamePanel.Location = new System.Drawing.Point(0, 100);
            this.fileNamePanel.Name = "fileNamePanel";
            this.fileNamePanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.fileNamePanel.Size = new System.Drawing.Size(507, 120);
            this.fileNamePanel.TabIndex = 10;
            // 
            // FindAllOccurence
            // 
            this.FindAllOccurence.AutoSize = true;
            this.FindAllOccurence.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FindAllOccurence.Location = new System.Drawing.Point(16, 74);
            this.FindAllOccurence.Name = "FindAllOccurence";
            this.FindAllOccurence.Size = new System.Drawing.Size(154, 22);
            this.FindAllOccurence.TabIndex = 9;
            this.FindAllOccurence.Text = "Find all occurence";
            this.FindAllOccurence.UseVisualStyleBackColor = true;
            this.FindAllOccurence.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // directoryPanel
            // 
            this.directoryPanel.BackColor = System.Drawing.Color.White;
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
            // chooseStartingDirectoryText
            // 
            this.chooseStartingDirectoryText.AutoSize = true;
            this.chooseStartingDirectoryText.Font = new System.Drawing.Font("HP Simplified Hans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseStartingDirectoryText.Location = new System.Drawing.Point(12, 18);
            this.chooseStartingDirectoryText.Name = "chooseStartingDirectoryText";
            this.chooseStartingDirectoryText.Size = new System.Drawing.Size(224, 23);
            this.chooseStartingDirectoryText.TabIndex = 1;
            this.chooseStartingDirectoryText.Text = "Choose starting directory";
            this.chooseStartingDirectoryText.Click += new System.EventHandler(this.label1_Click);
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
            this.chooseFolderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // directoryChoosen
            // 
            this.directoryChoosen.AutoSize = true;
            this.directoryChoosen.Location = new System.Drawing.Point(146, 61);
            this.directoryChoosen.Name = "directoryChoosen";
            this.directoryChoosen.Size = new System.Drawing.Size(104, 17);
            this.directoryChoosen.TabIndex = 5;
            this.directoryChoosen.Text = "No File Chosen";
            this.directoryChoosen.Click += new System.EventHandler(this.label3_Click);
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
            this.title.Size = new System.Drawing.Size(233, 52);
            this.title.TabIndex = 9;
            this.title.Text = "Folder Crawler";
            this.title.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 413);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(515, 460);
            this.Name = "Form1";
            this.Text = "Folder Crawling";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.searchMethodPanel.ResumeLayout(false);
            this.searchMethodPanel.PerformLayout();
            this.fileNamePanel.ResumeLayout(false);
            this.fileNamePanel.PerformLayout();
            this.directoryPanel.ResumeLayout(false);
            this.directoryPanel.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label inputFileNameText;
        private System.Windows.Forms.TextBox InputFileName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox searchMethod;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel searchMethodPanel;
        private System.Windows.Forms.Panel fileNamePanel;
        private System.Windows.Forms.Panel directoryPanel;
        private System.Windows.Forms.Label chooseStartingDirectoryText;
        private System.Windows.Forms.Button chooseFolderButton;
        private System.Windows.Forms.Label directoryChoosen;
        private System.Windows.Forms.CheckBox FindAllOccurence;
        private System.Windows.Forms.Button searchButton;
    }
}

