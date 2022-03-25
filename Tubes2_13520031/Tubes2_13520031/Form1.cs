using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Tubes2_13520031
{
    public partial class MainForm : Form
    {
        private BFSSearch bfs;
        private DFSSearch dfs;
        private Stopwatch stopwatch;
        private string searchMethodChosen;
        private Microsoft.Msagl.Drawing.Graph mainGraph;
        //private List<String> goalDirectory;
        //private Microsoft.Msagl.GraphViewerGdi.GViewer viewer;

        public MainForm()
        {
            InitializeComponent();
            this.stopwatch = new Stopwatch();
            this.bfs = new BFSSearch(null, null, false);
            this.dfs = new DFSSearch(null, null, false);
            this.mainGraph = new Microsoft.Msagl.Drawing.Graph();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void inputFileName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void chooseFolder_Click(object sender, EventArgs e) // buttonChooseFolder
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                directoryChoosen.Text = folderBrowserDialog1.SelectedPath;
                bfs.setGoalState(directoryChoosen.Text);
            } 
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(folderBrowserDialog1.SelectedPath))
            {
                MessageBox.Show("Starting directory is not selected yet!");
            }
            else if (String.IsNullOrEmpty(inputFileName.Text))
            {
                MessageBox.Show("File name is not entered yet!");
            }
            else if (String.IsNullOrEmpty(searchMethod.Text))
            {
                MessageBox.Show("Search method is not selected yet!");
            }
            else
            {
                Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                this.searchMethodChosen = searchMethod.Text;
                tableLayoutPath.RowStyles.Clear();
                //tableLayoutPath.AutoScroll = true;
                tableLayoutPath.AutoSize = true;
                List<string> listOfPath = new List<string>();
                tableLayoutPath.Controls.Clear();
                if (searchMethod.Text == "BFS")
                {
                    //graphPanel.Controls.Remove(viewer);
                    bfs.setStartingDir(folderBrowserDialog1.SelectedPath);
                    bfs.setGoalState(inputFileName.Text);
                    bfs.setOccurence(findAllOccurence.Checked);
                    bfs.removeAllGraph();
                    bfs.removeAllDikunjungi();
                    bfs.removeAllGoalDirectory();
                    bfs.removeAllAntrian();
                    
                    stopwatch.Start(); // mulai hitung waktu eksekusi
                    this.mainGraph = bfs.Search().graphResult;
                    //stopwatch.Stop(); // // selesai eksekusi
                    listOfPath = bfs.getGoalDirectory();
                }
                else // DFS
                {
                    dfs.setStartingDir(folderBrowserDialog1.SelectedPath);
                    dfs.setGoalState(inputFileName.Text);
                    dfs.setOccurence(findAllOccurence.Checked);
                    dfs.removeAllGraph();
                    dfs.removeAllDikunjungi();
                    dfs.removeAllGoalDirectory();
                    dfs.removeAllVisited();

                    stopwatch.Start(); // mulai hitung waktu eksekusi
                    this.mainGraph = dfs.DFSearch().graph;
                     // selesai eksekusi
                    listOfPath = dfs.getGoalDirectory();
                }
                stopwatch.Stop();
                MessageBox.Show("Search Completed!");
                string temp = "Time spent : " + stopwatch.ElapsedMilliseconds.ToString();
                timeSpentText.Text = temp + " ms";
                viewer.Graph = mainGraph;
                graphPanel.Controls.Clear();
                graphPanel.SuspendLayout();
                viewer.Dock = DockStyle.Fill;
                viewer.ToolBarIsVisible = false;
                graphPanel.Controls.Add(viewer);
                graphPanel.ResumeLayout();

                // tambah hyperlink path
                if (listOfPath.Count > 0) // file ditemukan
                {
                    Console.WriteLine("masuk");
                    tableLayoutPath.Controls.Clear();
                    tableLayoutPath.AutoSize = true;
                    //tableLayoutPath.Controls.Add(new LinkLabel { Text = goalDirectory[0] });
                    foreach (string goalDirectoryItem in listOfPath)
                    {
                        Console.WriteLine(goalDirectoryItem);
                        // dapatkan panjang goalDirectoryItem agar muat pada label
                        Label templabel = new Label { Text = goalDirectoryItem };
                        int width = templabel.Width + 1000;
                        LinkLabel linklabel = new LinkLabel { Name = goalDirectoryItem, Text = goalDirectoryItem };
                        linklabel.Width = width;
                        //linklabel.Font = new Font("Leelawadee UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                        linklabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.pathClick);
                        pathDirectoryPanel.SuspendLayout();
                        tableLayoutPath.RowCount ++;
                        tableLayoutPath.Controls.Add(linklabel);
                    }
                    tableLayoutPath.RowCount --;
                    pathDirectoryPanel.ResumeLayout();
                    Console.WriteLine(tableLayoutPath.RowCount);
                    /*if (tableLayoutPath.RowCount > 3)
                    // tambah scroll jika tingginya lebih dari tinggi minimum
                    {
                        ScrollBar verticalScrollBar = new VScrollBar();
                        verticalScrollBar.Dock = DockStyle.Right;
                        verticalScrollBar.Scroll += (s, args) => { tableLayoutPath.VerticalScroll.Value = verticalScrollBar.Value; };
                        tableLayoutPath.Controls.Add(verticalScrollBar);
                    } */
                    
                }
            }
        }

        private void pathClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var linklabel = (LinkLabel)sender;
            FileInfo fileDirectory = new FileInfo(linklabel.Text); // dapatkan direktori folder tempat file berada
            Process.Start(fileDirectory.DirectoryName);
        }
    }
}
