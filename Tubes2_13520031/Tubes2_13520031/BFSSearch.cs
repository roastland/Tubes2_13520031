using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tubes2_13520031
{
    delegate void FileFound(string path);
    class BFSSearch
    {
        private Queue<string> antrian;
        private List<string> dikunjungi;
        private string startingDir;
        private string goalState;
        private bool isAll;

        public BFSSearch(string startingDir, string goalState, bool isAll)
        {
            this.startingDir = startingDir;
            this.antrian = new Queue<string>();
            this.dikunjungi = new List<string>();
            this.goalState = goalState;
            this.isAll = isAll;
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

        public void Search()
        {
            Console.WriteLine(this.startingDir);
            this.dikunjungi.Add(this.startingDir);
            this.antrian.Enqueue(this.startingDir);
            bool found = false;
            while (this.antrian.Count > 0)
            {
                string holder = this.antrian.Dequeue();

                //Mencari file dan atau folder yang bertetangga dengan folder  holder
                string[] allDir = Directory.GetDirectories(holder);
                string[] allFiles = Directory.GetFiles(holder);

                List<string> searchTree = new List<string>();

                searchTree.AddRange(allFiles);
                searchTree.AddRange(allDir);

                foreach (string file in allFiles)
                {

                    if (Path.GetFileName(file) == goalState)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(file);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        found = true;
                        if (!isAll)
                        {
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine(file);
                    }


                }
                if (!found || isAll)
                {
                    foreach (string dir in allDir)
                    {
                        if (!this.dikunjungi.Contains(dir))
                        {
                            Console.WriteLine(dir);
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


        }
    }

    /*
    class Driver
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\irfan\OneDrive\Documents\Nando\Informatika\Semester 4\OOP";
            string goal = @"PrioQueue.hpp";
            bool searchAll = true;
            BFSSearch searcher = new BFSSearch(path, goal, searchAll);

            searcher.Search();

        }

    }

    */


}

