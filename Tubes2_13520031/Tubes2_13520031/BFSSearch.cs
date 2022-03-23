using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Tubes2_13520031
{
    //delegate void FileFound();
    class BFSSearch
    {
        private Queue<string> antrian;
        private List<string> dikunjungi;
        private string startingDir;
        private string goalState;
        private bool isAll;
        private Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        private Microsoft.Msagl.Drawing.Graph graph;
        private long time_spent;
        private List<String> goalDirectory;
        //public event FileFound OnFileFound;

        public BFSSearch(string startingDir, string goalState, bool isAll)
        {
            this.startingDir = startingDir;
            this.antrian = new Queue<string>();
            this.dikunjungi = new List<string>();
            this.goalState = goalState;
            this.isAll = isAll;
            this.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            this.time_spent = 0;
            this.goalDirectory = new List<string>();
        }

        public void setStartingDir(string startingDir)
        {
            this.startingDir = startingDir;
        }

        public void setGoalState(string goalState)
        {
            this.goalState = goalState;
        }

        public void setOccurence(bool isAll)
        {
            this.isAll = isAll;
        }

        public Microsoft.Msagl.GraphViewerGdi.GViewer getViewer()
        {
            return this.viewer;
        }

        public (Microsoft.Msagl.Drawing.Graph graph, List<String> goalDirectory) Search()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            //Console.WriteLine(this.startingDir);
            this.dikunjungi.Add(this.startingDir);
            this.antrian.Enqueue(this.startingDir);

            graph.AddNode(this.startingDir); // set starting dir sebagai akar

            bool found = false;
            while (this.antrian.Count > 0)
            {
                string holder = this.antrian.Dequeue();
                //Mencari file dan atau folder yang bertetangga dengan folder  holder
                string[] allDir = Directory.GetDirectories(holder);
                string[] allFiles = Directory.GetFiles(holder);

                // Prioritaskan file terlebih dahulu baru folder
                foreach (string file in allFiles)
                {
                    string[] temp_file = file.Split('\\');
                    if (graph.FindNode(temp_file[temp_file.Length - 1]) == null) // jika belum ditemukan node, maka tambahkan node
                    {
                        if (holder == this.startingDir) // agar nama node menjadi starting dir
                        {
                            graph.AddEdge(holder, temp_file[temp_file.Length - 1]);
                        }
                        else
                        {
                            graph.AddEdge(temp_file[temp_file.Length - 2], temp_file[temp_file.Length - 1]);
                        }
                    }
                    if (Path.GetFileName(file) == goalState)
                    {
                        graph.FindNode(temp_file.Last()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
                        this.goalDirectory.Add(file); // tambah direktori file ke dalam list goalDirectory
                        //this.goalDirectory.Add(file);
                        found = true;
                        if (!isAll)
                        {
                            break;
                        }
                    }
                    else
                    {
                        graph.FindNode(temp_file.Last()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                        //Console.WriteLine(file);
                    }
                }
                if (!found || isAll)
                {
                    foreach (string dir in allDir)
                    {
                        string[] temp_dir = dir.Split('\\');
                        if (graph.FindNode(temp_dir[temp_dir.Length - 1]) == null) // jika belum ditemukan node, maka tambahkan node
                        {
                            if (holder == this.startingDir) // agar nama node menjadi starting dir
                            {
                                graph.AddEdge(holder, temp_dir[temp_dir.Length - 1]);
                            }
                            else
                            {
                                graph.AddEdge(temp_dir[temp_dir.Length - 2], temp_dir[temp_dir.Length - 1]);
                            }
                        }
                        if (!this.dikunjungi.Contains(dir))
                        {
                            //Console.WriteLine(dir);
                            antrian.Enqueue(dir);
                            dikunjungi.Add(dir);
                        }
                    }
                }

                if (!isAll && found)
                {
                    break;
                }
            }
            stopwatch.Stop();
            /* if (found) {
                foreach (Microsoft.Msagl.Drawing.Edge e in graph.Edges)
                {
                    foreach (string file in this.goalDirectory)
                    {
                        string directoryWithoutStart = file.Substring(goalState.Length);
                        string[] edges = directoryWithoutStart.Split('\\');
                        for (int i = 0; i < edges.Length; i ++)
                        {
                            if (e.)
                        }
                        e.Attr.Color = 
                    }
                    if (e.SourceNode)
                }
            } */
            this.time_spent = stopwatch.ElapsedMilliseconds;
            //OnFileFound();
            return (this.graph, this.goalDirectory);
        }
    }
}

