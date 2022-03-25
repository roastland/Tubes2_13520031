using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Tubes2_13520031
{
    class DFSSearch
    {
        private string startingDir;
        private string goalState;
        private bool isAll;
        private bool found; // boolean untuk NOT isAll Occurence
        Dictionary<string, bool> visited = new Dictionary<string, bool>(); // value: path, key: boolean (udah divisit atau belum)
        private List<string> goalDirectory;
        private List<string> dikunjungi;
        private Microsoft.Msagl.Drawing.Graph graph;

        public DFSSearch(string startingDir, string goalState, bool isAll) // konstruktor
        {
            this.startingDir = startingDir;
            this.goalState = goalState;
            this.isAll = isAll;
            this.found = false;
            this.visited = new Dictionary<string, bool>();
            this.goalDirectory = new List<string>();
            this.dikunjungi = new List<string>();
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
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
            foreach (Microsoft.Msagl.Drawing.Edge e in this.graph.Edges.ToList())
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
            foreach (string s in this.dikunjungi.ToList())
            {
                this.dikunjungi.Remove(s);
            }
        }

        public void removeAllGoalDirectory()
        {
            foreach (string s in this.goalDirectory.ToList())
            {
                this.goalDirectory.Remove(s);
            }
        }

        public void removeAllVisited()
        {
            visited.Clear();
        }

        public void resetIsFound()
        {
            this.found = false;
        }


        public void initializeVisited(string starting) // inisialisasi value pada dictionary dengan false
        {
            foreach (string file in Directory.GetFiles(starting))
            {
                visited.Add(file, false);
            }
            foreach (string dir in Directory.GetDirectories(starting))
            {
                visited.Add(dir, false);
                initializeVisited(dir);
            }
        }



        /*
        public void search(string start)
        {
            string[] allDir = Directory.GetDirectories(start);
            string[] allFiles = Directory.GetFiles(start);
            Console.WriteLine(start);
            // Basis: file ditemukan (untuk not isAll Occurence)
            // atau pencarian berakhir untuk semua file dan directory yg ada pada parent directory
            foreach (string file in allFiles)
            {
                if (!found)
                {
                    // jika nama file ditemukan
                    if (Path.GetFileName(file) == this.goalState)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(file);
                        this.goalDirectory.Add(file);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        visited[file] = true;
                        // jika bukan All Occurence, maka pencarian berakhir
                        if (!isAll)
                        {
                            found = true;
                            //Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine(file);
                        visited[file] = true;
                    }
                }
            }
            if (!found) // belum ketemu atau bukan All Occurence
            {
                visited[start] = false;
                foreach (string dir in allDir)
                {
                    if (visited[dir] == false)
                    {
                        //Console.WriteLine(dir);
                        if (!found)
                        {
                            search(dir); // rekurens
                        }
                    }
                }
                visited[start] = false;
            }
        } */

            
        public void search(string start)
        {
            string[] allDir = Directory.GetDirectories(start);
            string[] allFiles = Directory.GetFiles(start);
            Console.WriteLine(start);
            // Basis: file ditemukan (untuk not isAll Occurence)
            // atau pencarian berakhir untuk semua file dan directory yg ada pada parent directory
            if (allDir.Length == 0 && allFiles.Length == 0)
            {
                DirectoryInfo startDirectoryInfo = new DirectoryInfo(this.startingDir);
                //DirectoryInfo dirInfo = new DirectoryInfo(start);
                string finalDir = start;

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

                found = true;
            }
            foreach (string file in allFiles)
            {
                if (!found)
                {
                    // jika nama file ditemukan
                    if (Path.GetFileName(file) == this.goalState)
                    {
                        /*
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(file);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        visited[file] = true;
                        */
                        if (!this.goalDirectory.Contains(file))
                        {
                            this.goalDirectory.Add(file);
                        }
                        DirectoryInfo dirInfo = new DirectoryInfo(start);
                        DirectoryInfo parentInfo;
                        if (start.Equals(this.startingDir) )
                        {
                            parentInfo = new DirectoryInfo(start);
                        }
                        else
                        {
                            parentInfo = new DirectoryInfo(Directory.GetParent(start).FullName);
                        }
                        if (dikunjungi.Contains(Path.GetFileName(file)))
                        {
                            string fileNode;
                            DirectoryInfo prevNodeFileInfo = new DirectoryInfo(start);
                            string prevNodeFile = prevNodeFileInfo.Name;
                            fileNode = prevNodeFile + "/" + Path.GetFileName(file);
                            while (dikunjungi.Contains(fileNode) && prevNodeFile != this.startingDir)
                            {
                                prevNodeFileInfo = new DirectoryInfo(Directory.GetParent(prevNodeFile).FullName);
                                prevNodeFile = prevNodeFileInfo.Name;
                                fileNode = prevNodeFile + "/" + Path.GetFileName(file);
                            }
                            if (dikunjungi.Contains(parentInfo.Name+ "/" + dirInfo.Name))
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
                        // jika bukan All Occurence, maka pencarian berakhir
                        if (!isAll)
                        {
                            found = true;
                            //Environment.Exit(0);
                            //return;
                        }
                    }
                    else
                    {
                        DirectoryInfo parentInfo;
                        DirectoryInfo dirInfo = new DirectoryInfo(start);
                        if (start.Equals(this.startingDir))
                        {
                            parentInfo = new DirectoryInfo(start);
                        }
                        else
                        {
                            parentInfo = new DirectoryInfo(Directory.GetParent(start).FullName);
                        }
                        if (dikunjungi.Contains(Path.GetFileName(file)))
                        {
                            string fileNode;
                            DirectoryInfo prevNodeFileInfo = new DirectoryInfo(start);
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
                        DirectoryInfo temp = new DirectoryInfo(finalDir);
                        if (!this.graph.FindNode(temp.Name).Attr.FillColor.Equals(Microsoft.Msagl.Drawing.Color.Green))
                        {
                            this.graph.FindNode(temp.Name).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                        }


                    }
                }
            }
            if (!found) // belum ketemu atau bukan All Occurence
            {
                visited[start] = false;
                foreach (string dir in allDir)
                {
                    if (visited[dir] == false)
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(start);
                        DirectoryInfo nextInfo = new DirectoryInfo(dir);
                        if (!this.dikunjungi.Contains(nextInfo.Name))
                        {
                            this.graph.AddEdge(dirInfo.Name, nextInfo.Name);
                            dikunjungi.Add(nextInfo.Name);
                        }
                        else
                        {
                            this.graph.AddEdge(dirInfo.Name, dirInfo.Name + "/" + nextInfo.Name);
                            dikunjungi.Add(dirInfo.Name + "/" + nextInfo.Name);
                        }
                        search(dir); // rekurens
                    }
                }
                visited[start] = false;
            }
        }
        public (Microsoft.Msagl.Drawing.Graph graph, List<String> goalDirectory) DFSearch()
        {
            resetIsFound();
            initializeVisited(startingDir);
            search(startingDir);
            return (this.graph, this.goalDirectory);
        }
    }
}
/* class Driver
{
    static void Main(string[] args)
    {
        string path = @"D:\SEMESTER 4\IF2211 Strategi Algoritma\Tugas\Home";
        string goal = @"not.jpeg";
        DFS searcher = new DFS(path, goal, false);
        searcher.DFSearch(path);
    }
} */
