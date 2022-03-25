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
            //this.mainGraph = new Microsoft.Msagl.Drawing.Graph("graph");
            //this.goalDirectory = new List<String>();
            //this.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //this.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //this.bfs.OnFileFound += FileFound;
            this.mainGraph = new Microsoft.Msagl.Drawing.Graph();
            //this.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //searchWorker.DoWork += SearchFile; // melakukan searching file
            //searchWorker.ProgressChanged += ClickThreadOnProgressChanged;
            //searchWorker.RunWorkerCompleted += SearchCompleted; // search selesai
        }

        /* private void FileFound()
        {
            graphPanel.BeginInvoke((Action)delegate ()
            {
                Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                viewer.Graph = mainGraph;
                viewer.Dock = DockStyle.Fill;
                viewer.ToolBarIsVisible = false;
                //graphPanel.Controls.Clear();
                graphPanel.Controls.Add(viewer);
                if (goalDirectory.Count > 0) // file ditemukan
                {
                    tableLayoutPath.Controls.Clear();
                    foreach (string goalDirectoryItem in goalDirectory)
                    {
                        var linklabel = new LinkLabel{ Text = goalDirectoryItem };
                        linklabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.pathClick);
                        tableLayoutPath.Controls.Add(linklabel);
                        if (tableLayoutPath.Size.Height > tableLayoutPath.MinimumSize.Height)
                        // tambah scroll jika tingginya lebih dari tinggi minimum
                        {
                            pathDirectoryPanel.AutoScroll = true;
                            pathDirectoryPanel.AutoScrollMargin = new System.Drawing.Size(0, 1000);
                        }
                    }
                }
            });
        } */

        /*private void ClickThreadOnProgressChanged(object sender, ProgressChangedEventArgs args)
        {
            this.viewer.Controls.Clear();
            graphPanel.Controls.Clear();
            (mainGraph, goalDirectory) = ((Microsoft.Msagl.Drawing.Graph graph, List<String>))args.UserState;
            
            //viewer.Graph = mainGraph;
            viewer.Dock = DockStyle.Fill;
            viewer.ToolBarIsVisible = false;
            graphPanel.Controls.Add(viewer);
            if (goalDirectory.Count > 0) // file ditemukan
            {
                tableLayoutPath.Controls.Clear();
                foreach (string goalDirectoryItem in goalDirectory)
                {
                    var linklabel = new LinkLabel { Text = goalDirectoryItem };
                    linklabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.pathClick);
                    tableLayoutPath.Controls.Add(linklabel);
                    if (tableLayoutPath.Size.Height > tableLayoutPath.MinimumSize.Height)
                    // tambah scroll jika tingginya lebih dari tinggi minimum
                    {
                        pathDirectoryPanel.AutoScroll = true;
                        pathDirectoryPanel.AutoScrollMargin = new System.Drawing.Size(0, 1000);
                    }
                }
            }
        } */

        /* private void SearchCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            //graphPanel.Controls.Clear();
            MessageBox.Show("Search Completed!");
            stopwatch.Stop();
            string temp = "Time spent : " + stopwatch.ElapsedMilliseconds.ToString();
            timeSpentText.Text = temp + " ms";
            this.mainGraph = new Microsoft.Msagl.Drawing.Graph();
            //this.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //mainGraph.LayoutAlgorithmSettings = new Microsoft.Msagl.Layout.MDS.MdsLayoutSettings();
            //viewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            viewer.OutsideAreaBrush = Brushes.White;
            List<string> goalDirectory = new List<string>();
            // (viewer.Graph, goalDirectory) = ((Microsoft.Msagl.Drawing.Graph, List<string>))args.Result;
            foreach(string s in goalDirectory)
            {
                Console.WriteLine("selesai");
                Console.WriteLine(s);
            }
            //graphPanel.Controls.Clear();
            //viewer.Controls.Clear();
            //viewer.Graph = null;
            //viewer.Graph = mainGraph;
            //viewer.Graph = mainGraph;
            //graphPanel.SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            viewer.ToolBarIsVisible = false;
            graphPanel.Controls.Add(viewer);
            //graphPanel.ResumeLayout();
            if (goalDirectory.Count > 0) // file ditemukan
            {
                tableLayoutPath.Controls.Clear();
                //tableLayoutPath.Controls.Add(new LinkLabel { Text = goalDirectory[0] });
                foreach (string goalDirectoryItem in goalDirectory)
                {
                    // dapatkan panjang goalDirectoryItem agar muat pada label
                    Label templabel = new Label { Text = goalDirectoryItem };
                    int width = templabel.Width + 1000;
                    LinkLabel linklabel = new LinkLabel { Name = goalDirectoryItem, Text = goalDirectoryItem };
                    linklabel.Width = width;
                    linklabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.pathClick);
                    pathDirectoryPanel.SuspendLayout();
                    tableLayoutPath.Controls.Add(linklabel);
                    if (tableLayoutPath.Size.Height > tableLayoutPath.MinimumSize.Height)
                    // tambah scroll jika tingginya lebih dari tinggi minimum
                    {
                        pathDirectoryPanel.AutoScroll = true;
                    }
                    pathDirectoryPanel.ResumeLayout();
                }
            }
            /*mainGraph = tupleResult.graph;
            goalDirectory = tupleResult.goalDirectory;
        } */

        /*
        private void SearchFile(object sender, DoWorkEventArgs args)
        {
            // TODO: Tambah metode search (proses search) sesuai metode pilihan user
            /* graphPanel.BeginInvoke((Action)delegate ()
            {
                viewer.Controls.Clear();
            }); 
            if (this.searchMethodChosen == "BFS")
            {
                if (IsHandleCreated)
                {
                    BeginInvoke(this.viewer.Graph = bfs.Search().graphResult);
                    return;
                }
               
                //args.Result = result;
            } else
            {
                var result = dfs.DFSearch(folderBrowserDialog1.SelectedPath);
                args.Result = result;
            }
        } */

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
                if (searchMethod.Text == "BFS")
                {
                    //graphPanel.Controls.Remove(viewer);
                    bfs.setStartingDir(folderBrowserDialog1.SelectedPath);
                    bfs.setGoalState(inputFileName.Text);
                    bfs.setOccurence(findAllOccurence.Checked);
                    bfs.removeAllGraph();
                    bfs.removeAllDikunjungi();
                    tableLayoutPath.Controls.Clear();
                    stopwatch.Start(); // mulai hitung waktu eksekusi
                    this.mainGraph = bfs.Search().graphResult;
                    MessageBox.Show("Search Completed!");
                    stopwatch.Stop();
                    string temp = "Time spent : " + stopwatch.ElapsedMilliseconds.ToString();
                    graphPanel.Controls.Clear();
                    timeSpentText.Text = temp + " ms";
                    viewer.Graph = mainGraph;
                    graphPanel.SuspendLayout();
                    viewer.Dock = DockStyle.Fill;
                    viewer.ToolBarIsVisible = false;
                    graphPanel.Controls.Add(viewer);
                    graphPanel.ResumeLayout();
                    List<string> listOfPath = bfs.getGoalDirectory();
                    if (listOfPath.Count > 0) // file ditemukan
                    {
                        Console.WriteLine("masuk");
                        tableLayoutPath.Controls.Clear();
                        //tableLayoutPath.Controls.Add(new LinkLabel { Text = goalDirectory[0] });
                        foreach (string goalDirectoryItem in listOfPath)
                        {
                            Console.WriteLine(goalDirectoryItem);
                            // dapatkan panjang goalDirectoryItem agar muat pada label
                            Label templabel = new Label { Text = goalDirectoryItem };
                            int width = templabel.Width + 1000;
                            LinkLabel linklabel = new LinkLabel { Name = goalDirectoryItem, Text = goalDirectoryItem };
                            linklabel.Width = width;
                            linklabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.pathClick);
                            pathDirectoryPanel.SuspendLayout();
                            tableLayoutPath.Controls.Add(linklabel);
                            if (tableLayoutPath.Size.Height > tableLayoutPath.MinimumSize.Height)
                            // tambah scroll jika tingginya lebih dari tinggi minimum
                            {
                                pathDirectoryPanel.AutoScroll = true;
                            }
                            pathDirectoryPanel.ResumeLayout();
                        }
                    }
                }
                else // DFS
                {
                    dfs.setStartingDir(folderBrowserDialog1.SelectedPath);
                    dfs.setGoalState(inputFileName.Text);
                    dfs.setOccurence(findAllOccurence.Checked);
                    stopwatch.Start(); // mulai hitung waktu eksekusi
                    this.mainGraph = dfs.DFSearch(folderBrowserDialog1.SelectedPath).graph;
                    //searchWorker.RunWorkerAsync();
                    MessageBox.Show("Search Completed!");
                    stopwatch.Stop();
                    string temp = "Time spent : " + stopwatch.ElapsedMilliseconds.ToString();
                    timeSpentText.Text = temp + " ms";
                    viewer.Graph = mainGraph;
                    graphPanel.SuspendLayout();
                    viewer.Dock = DockStyle.Fill;
                    viewer.ToolBarIsVisible = false;
                    graphPanel.Controls.Add(viewer);
                    graphPanel.ResumeLayout();
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
