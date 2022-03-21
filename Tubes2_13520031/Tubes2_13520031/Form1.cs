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

namespace Tubes2_13520031
{
    public partial class MainForm : Form
    {
        private BFSSearch bfs;
        private Stopwatch stopwatch;

        public MainForm()
        {
            InitializeComponent();
            this.stopwatch = new Stopwatch();
            this.bfs = new BFSSearch(null, null, false);
            this.bfs.OnFileFound += FileFound;
            searchWorker.DoWork += SearchFile; // melakukan searching file
            searchWorker.RunWorkerCompleted += SearchCompleted;
        }

        private void FileFound(Microsoft.Msagl.Drawing.Graph graph, long time_spent)
        {
            graphPanel.BeginInvoke((Action)delegate ()
            {
                Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                viewer.Graph = graph;
                viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                viewer.ToolBarIsVisible = false;
                graphPanel.Controls.Add(viewer);
                //timeSpentText.Text = "Time Spent : " + time_spent.ToString();
            });
        }

        private void SearchCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            MessageBox.Show("Search Completed!");
            stopwatch.Stop();
            string temp = "Time Spent : " + stopwatch.ElapsedMilliseconds.ToString();
            timeSpentText.Text = temp + " ms";
        }

        private void SearchFile(object sender, DoWorkEventArgs args)
        {
            // TODO: Tambah metode search (proses search) sesuai metode pilihan user
            bfs.Search();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void searchMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void findAllOccurence_CheckedChanged(object sender, EventArgs e) // findAllOccurence
        {

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
                if (searchMethod.Text == "BFS")
                {
                    bfs.setStartingDir(folderBrowserDialog1.SelectedPath);
                    bfs.setGoalState(inputFileName.Text);
                    bfs.setOccurence(findAllOccurence.Checked);
                    stopwatch.Start();
                    searchWorker.RunWorkerAsync();
                }
                else // DFS
                {

                }
            }
        }
    }
}
