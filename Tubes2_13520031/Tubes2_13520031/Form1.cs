using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes2_13520031
{
    public partial class MainForm : Form
    {
        private BFSSearch bfs;

        public MainForm()
        {
            InitializeComponent();
            this.bfs = new BFSSearch(null, null, false);
            searchWorker.DoWork += SearchFile; // melakukan searching file
            searchWorker.RunWorkerCompleted += SearchCompleted;

        }

        private void SearchCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            MessageBox.Show("Search Complete!");
        }

        private void SearchFile(object sender, DoWorkEventArgs args)
        {
            // TODO: Tambah metode search (proses search) sesuai metode pilihan user
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
                }
                else // DFS
                {

                }
            }
        }

        public void addGraphToPanel(Microsoft.Msagl.GraphViewerGdi.GViewer viewer)
        {
            graphPanel.Controls.Add(viewer);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void graphPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
