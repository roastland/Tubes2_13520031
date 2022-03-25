using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Tubes2_13520031
{
    class BFSSearch
    {
        private Queue<string> antrian;
        private List<string> dikunjungi;
        private string startingDir;
        private string goalState;
        private bool isAll;
        private Microsoft.Msagl.Drawing.Graph graph;
        //private Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        private List<string> goalDirectory;


        public BFSSearch(string startingDir, string goalState, bool isAll)
        {
            this.startingDir = startingDir;
            this.antrian = new Queue<string>();
            this.dikunjungi = new List<string>();
            this.goalState = goalState;
            this.isAll = isAll;
            this.graph = new Microsoft.Msagl.Drawing.Graph();
            //this.viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.goalDirectory = new List<String>();
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

        public List<string> getGoalDirectory()
        {
            return this.goalDirectory;
        }

        public void removeAllGraph()
        {
            foreach(Microsoft.Msagl.Drawing.Edge e in this.graph.Edges.ToList())
            {
                this.graph.RemoveEdge(e);
            }
            foreach (Microsoft.Msagl.Drawing.Node n in this.graph.Nodes.ToList())
            {
                this.graph.RemoveNode(n);
            }
        }

        public void removeAllDikunjungi()
        {
            foreach(string s in this.dikunjungi.ToList())
            {
                this.dikunjungi.Remove(s);
            }
        }

        public void removeAllGoalDirectory()
        {
            foreach(string s in this.goalDirectory.ToList())
            {
                this.goalDirectory.Remove(s);
            }
        }

        public void removeAllAntrian()
        {
            this.antrian.Clear();
        }

        public (Microsoft.Msagl.Drawing.Graph graphResult, List<string> goalDirectory) Search()
        {
            //Console.WriteLine("All occurence: " + this.isAll);
            //Console.WriteLine(this.startingDir);
            this.dikunjungi.Add(this.startingDir);
            this.antrian.Enqueue(this.startingDir);
            bool found = false;
            while (this.antrian.Count > 0)
            {
                //string holder = new DirectoryInfo(this.antrian.Dequeue()).Name;
                string holder = this.antrian.Dequeue();

                //Mencari file dan atau folder yang bertetangga dengan folder  holder
                string[] allDir = Directory.GetDirectories(holder);
                string[] allFiles = Directory.GetFiles(holder);


                if (allDir.Length == 0 && allFiles.Length == 0)
                {
                    DirectoryInfo startDirectoryInfo = new DirectoryInfo(this.startingDir);
                    //DirectoryInfo dirInfo = new DirectoryInfo(holder);
                    string finalDir = holder;

                    while (finalDir != this.startingDir)
                    {
                        DirectoryInfo nextNode = new DirectoryInfo(finalDir);
                        DirectoryInfo prevNode = new DirectoryInfo(Directory.GetParent(finalDir).FullName);
                        DirectoryInfo GrandpaDir;
                        if (prevNode.Name != startDirectoryInfo.Name)
                        {
                            GrandpaDir = new DirectoryInfo(Directory.GetParent(Directory.GetParent(finalDir).FullName).FullName);

                        }
                        else
                        {
                            GrandpaDir = prevNode;
                        }
                        foreach (Microsoft.Msagl.Drawing.Edge edge in this.graph.Edges)
                        {
                            Console.WriteLine(nextNode.Name);

                            if (edge.SourceNode.LabelText.Equals(prevNode.Name) && edge.TargetNode.LabelText.Equals(nextNode.Name) && !edge.Attr.Color.Equals(Microsoft.Msagl.Drawing.Color.Green))
                            {
                                this.graph.AddEdge(prevNode.Name, nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                this.graph.FindNode(nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                this.graph.RemoveEdge(edge);

                                break;
                            }
                            else if (edge.SourceNode.LabelText.Equals(prevNode.Name) && edge.TargetNode.LabelText.Equals(prevNode.Name + "/" + nextNode.Name) && !edge.Attr.Color.Equals(Microsoft.Msagl.Drawing.Color.Green))
                            {
                                this.graph.AddEdge(prevNode.Name, prevNode.Name + "/" + nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                this.graph.FindNode(prevNode.Name + "/" + nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                this.graph.RemoveEdge(edge);
                                break;
                            }
                            else if (edge.SourceNode.LabelText.Equals(GrandpaDir.Name + "/" + prevNode.Name) && edge.TargetNode.LabelText.Equals(prevNode.Name + "/" + nextNode.Name) && !edge.Attr.Color.Equals(Microsoft.Msagl.Drawing.Color.Green))
                            {
                                this.graph.AddEdge(GrandpaDir.Name + "/" + prevNode.Name, prevNode.Name + "/" + nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                this.graph.FindNode(prevNode.Name + "/" + nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                this.graph.RemoveEdge(edge);
                                break;
                            }
                            else if (edge.SourceNode.LabelText.Equals(GrandpaDir.Name + "/" + prevNode.Name) && edge.TargetNode.LabelText.Equals(nextNode.Name) && !edge.Attr.Color.Equals(Microsoft.Msagl.Drawing.Color.Green))
                            {
                                this.graph.AddEdge(GrandpaDir.Name + "/" + prevNode.Name, nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                this.graph.FindNode(nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                this.graph.RemoveEdge(edge);
                                break;
                            }
                        }


                        finalDir = Directory.GetParent(finalDir).FullName;
                    }
                    DirectoryInfo temp = new DirectoryInfo(finalDir);
                    if (!this.graph.FindNode(temp.Name).Attr.FillColor.Equals(Microsoft.Msagl.Drawing.Color.Green))
                    {
                        this.graph.FindNode(temp.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                    }     
                }

                foreach (string file in allFiles)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(holder);

                    if (Path.GetFileName(file) == goalState)
                    {
                        DirectoryInfo parentInfo;
                        if (holder.Equals(this.startingDir))
                        {
                            parentInfo = new DirectoryInfo(holder);
                        }
                        else
                        {
                            parentInfo = new DirectoryInfo(Directory.GetParent(holder).FullName);
                        }
                        if (dikunjungi.Contains(Path.GetFileName(file)))
                        {
                            
                            string fileNode;
                            
                            DirectoryInfo prevNodeFileInfo = new DirectoryInfo(holder);
                            string prevNodeFile = prevNodeFileInfo.Name;
                            fileNode =  prevNodeFile+ "/" + Path.GetFileName(file);
                            while (dikunjungi.Contains(fileNode) && prevNodeFile != this.startingDir)
                            {
                                prevNodeFileInfo = new DirectoryInfo(Directory.GetParent(prevNodeFile).FullName);
                                prevNodeFile = prevNodeFileInfo.Name;
                                fileNode = prevNodeFile + "/" + Path.GetFileName(file);

                            }
                            if (dikunjungi.Contains(parentInfo.Name + "/" + dirInfo.Name))
                            {
                                this.graph.AddEdge(parentInfo.Name + "/" + dirInfo.Name, fileNode).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            }
                            else
                            {
                                this.graph.AddEdge(dirInfo.Name, fileNode).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            }
                            this.graph.FindNode(fileNode).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                            dikunjungi.Add(fileNode);
                        }
                        else
                        {
                            if (dikunjungi.Contains(parentInfo.Name + "/" + dirInfo.Name))
                            {
                                this.graph.AddEdge(parentInfo.Name + "/" + dirInfo.Name, Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            }
                            else
                            {
                                this.graph.AddEdge(dirInfo.Name, Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            }

                            this.graph.FindNode(Path.GetFileName(file)).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                            this.dikunjungi.Add(Path.GetFileName(file));
                        }


                        string finalDir = Directory.GetParent(file).FullName;
                        DirectoryInfo startDirectoryInfo = new DirectoryInfo(this.startingDir);
                        while (finalDir != this.startingDir)
                        {
                            DirectoryInfo nextNode = new DirectoryInfo(finalDir);
                            DirectoryInfo prevNode = new DirectoryInfo(Directory.GetParent(finalDir).FullName);
                            DirectoryInfo GrandpaDir;
                            if (prevNode.Name != startDirectoryInfo.Name)
                            {
                                GrandpaDir = new DirectoryInfo(Directory.GetParent(Directory.GetParent(finalDir).FullName).FullName);

                            }
                            else
                            {
                                GrandpaDir = prevNode;
                            }
                            foreach (Microsoft.Msagl.Drawing.Edge edge in this.graph.Edges)
                            {
                                Console.WriteLine(nextNode.Name);

                                if (edge.SourceNode.LabelText.Equals(prevNode.Name) && edge.TargetNode.LabelText.Equals(nextNode.Name))
                                {
                                    this.graph.AddEdge(prevNode.Name, nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                                    this.graph.FindNode(nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                                    this.graph.RemoveEdge(edge);

                                    break;
                                }
                                else if (edge.SourceNode.LabelText.Equals(prevNode.Name) && edge.TargetNode.LabelText.Equals(prevNode.Name + "/" + nextNode.Name))
                                {
                                    this.graph.AddEdge(prevNode.Name, prevNode.Name + "/" + nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                                    this.graph.FindNode(prevNode.Name + "/" + nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                                    this.graph.RemoveEdge(edge);
                                    break;
                                }
                                else if (edge.SourceNode.LabelText.Equals(GrandpaDir.Name + "/" + prevNode.Name) && edge.TargetNode.LabelText.Equals(prevNode.Name + "/" + nextNode.Name))
                                {
                                    this.graph.AddEdge(GrandpaDir.Name + "/" + prevNode.Name, prevNode.Name + "/" + nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                                    this.graph.FindNode(prevNode.Name + "/" + nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                                    this.graph.RemoveEdge(edge);
                                    break;
                                }
                                else if (edge.SourceNode.LabelText.Equals(GrandpaDir.Name + "/" + prevNode.Name) && edge.TargetNode.LabelText.Equals(nextNode.Name))
                                {
                                    this.graph.AddEdge(GrandpaDir.Name + "/" + prevNode.Name, nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                                    this.graph.FindNode(nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                                    this.graph.RemoveEdge(edge);
                                    break;
                                }
                            }


                            finalDir = Directory.GetParent(finalDir).FullName;
                        }
                        DirectoryInfo temp = new DirectoryInfo(this.startingDir);
                        this.graph.FindNode(temp.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                        found = true;
                        if (!this.goalDirectory.Contains(file))
                        {
                            this.goalDirectory.Add(file);
                        }
                        if (!isAll)
                        {
                            break;
                        }

                    }
                    else //Sampai pada node ujung (file) yang bukan dicari
                    { 

                        
                        DirectoryInfo parentInfo;
                        if (holder.Equals(this.startingDir))
                        {
                            parentInfo = new DirectoryInfo(holder);
                        }
                        else
                        {
                            parentInfo = new DirectoryInfo(Directory.GetParent(holder).FullName);
                        }
                        if (dikunjungi.Contains(Path.GetFileName(file)))
                        {
                            string fileNode;

                            DirectoryInfo prevNodeFileInfo = new DirectoryInfo(holder);
                            string prevNodeFile = prevNodeFileInfo.Name;
                            fileNode = prevNodeFile + "/" + Path.GetFileName(file);
                            while (dikunjungi.Contains(fileNode) && prevNodeFile != this.startingDir)
                            {
                                prevNodeFileInfo = new DirectoryInfo(Directory.GetParent(prevNodeFile).FullName);
                                prevNodeFile = prevNodeFileInfo.Name;
                                fileNode = prevNodeFile + "/" + Path.GetFileName(file);

                            }
                            if (dikunjungi.Contains(parentInfo.Name + "/" + dirInfo.Name))
                            {
                                this.graph.AddEdge(parentInfo.Name + "/" + dirInfo.Name, fileNode).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            }
                            else
                            {
                                this.graph.AddEdge(dirInfo.Name, fileNode).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            }
                            this.graph.FindNode(fileNode).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                            dikunjungi.Add(fileNode);

                        }
                        else
                        {
                            if (dikunjungi.Contains(parentInfo.Name + "/" + dirInfo.Name))
                            {
                                this.graph.AddEdge(parentInfo.Name + "/" + dirInfo.Name, Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            }
                            else
                            {
                                this.graph.AddEdge(dirInfo.Name, Path.GetFileName(file)).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            }

                            this.graph.FindNode(Path.GetFileName(file)).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                            this.dikunjungi.Add(Path.GetFileName(file));
                        }

                        string finalDir = Directory.GetParent(file).FullName;
                        DirectoryInfo startDirectoryInfo = new DirectoryInfo(this.startingDir);
                        while (finalDir != this.startingDir)
                        {
                            DirectoryInfo nextNode = new DirectoryInfo(finalDir);
                            DirectoryInfo prevNode = new DirectoryInfo(Directory.GetParent(finalDir).FullName);
                            DirectoryInfo GrandpaDir;
                            if (prevNode.Name != startDirectoryInfo.Name)
                            {
                                GrandpaDir = new DirectoryInfo(Directory.GetParent(Directory.GetParent(finalDir).FullName).FullName);

                            }
                            else
                            {
                                GrandpaDir = prevNode;
                            }
                            foreach (Microsoft.Msagl.Drawing.Edge edge in this.graph.Edges)
                            {
                                Console.WriteLine(nextNode.Name);

                                if (edge.SourceNode.LabelText.Equals(prevNode.Name) && edge.TargetNode.LabelText.Equals(nextNode.Name) && !edge.Attr.Color.Equals(Microsoft.Msagl.Drawing.Color.Green))
                                {
                                    this.graph.AddEdge(prevNode.Name, nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                    this.graph.FindNode(nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                    this.graph.RemoveEdge(edge);

                                    break;
                                }
                                else if (edge.SourceNode.LabelText.Equals(prevNode.Name) && edge.TargetNode.LabelText.Equals(prevNode.Name + "/" + nextNode.Name) && !edge.Attr.Color.Equals(Microsoft.Msagl.Drawing.Color.Green))
                                {
                                    this.graph.AddEdge(prevNode.Name, prevNode.Name + "/" + nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                    this.graph.FindNode(prevNode.Name + "/" + nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                    this.graph.RemoveEdge(edge);
                                    break;
                                }
                                else if (edge.SourceNode.LabelText.Equals(GrandpaDir.Name + "/" + prevNode.Name) && edge.TargetNode.LabelText.Equals(prevNode.Name + "/" + nextNode.Name) && !edge.Attr.Color.Equals(Microsoft.Msagl.Drawing.Color.Green))
                                {
                                    this.graph.AddEdge(GrandpaDir.Name + "/" + prevNode.Name, prevNode.Name + "/" + nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                    this.graph.FindNode(prevNode.Name + "/" + nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                    this.graph.RemoveEdge(edge);
                                    break;
                                }
                                else if (edge.SourceNode.LabelText.Equals(GrandpaDir.Name + "/" + prevNode.Name) && edge.TargetNode.LabelText.Equals(nextNode.Name) && !edge.Attr.Color.Equals(Microsoft.Msagl.Drawing.Color.Green))
                                {
                                    this.graph.AddEdge(GrandpaDir.Name + "/" + prevNode.Name, nextNode.Name).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                    this.graph.FindNode(nextNode.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                                    this.graph.RemoveEdge(edge);
                                    break;
                                }
                            }


                            finalDir = Directory.GetParent(finalDir).FullName;
                        }
                        DirectoryInfo temp2 = new DirectoryInfo(finalDir);
                        if (!this.graph.FindNode(temp2.Name).Attr.FillColor.Equals(Microsoft.Msagl.Drawing.Color.Green))
                        {
                        //Microsoft.Msagl.Drawing.Node temp = this.graph.FindNode(finalDir);
                            this.graph.FindNode(temp2.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                        }

                    }
                }
                if (!found || isAll)
                {
                    foreach (string dir in allDir)
                    {
                        this.AddDirNode(dir, holder);
                    }

                }

                if (!isAll && found)
                {
                    Console.WriteLine("MASUK");
                    break;
                }
            }

            //viewer.Graph = graph;
            //viewer.Graph = mainGraph;
            //graphPanel.SuspendLayout();
            //viewer.Dock = DockStyle.Fill;
            //viewer.ToolBarIsVisible = false;
            return (this.graph, this.goalDirectory);
        }
        
        public void AddDirNode (string dir, string holder)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            DirectoryInfo holderInfo = new DirectoryInfo(holder);
            if (!this.dikunjungi.Contains(dirInfo.Name))
            {
                this.graph.AddEdge(holderInfo.Name, dirInfo.Name);

                dikunjungi.Add(dirInfo.Name);
            }
            else
            {
                this.graph.AddEdge(holderInfo.Name, holderInfo.Name + "/" + dirInfo.Name);
                dikunjungi.Add(holderInfo.Name + "/" + dirInfo.Name);
            }
            antrian.Enqueue(dir);
        }


    }
}


