using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class DFS
{
    private string startingDir;
    private string goalState;
    private bool isAll;
    private bool found; // boolean untuk NOT isAll Occurence
    Dictionary<string, bool> visited = new Dictionary<string, bool>(); // value: path, key: boolean (udah divisit atau belum)


    public DFS(string startingDir, string goalState, bool isAll) // konstruktor
    {
        this.startingDir = startingDir;
        this.goalState = goalState;
        this.isAll = isAll;
        this.found = false;
        this.visited = new Dictionary<string, bool>();
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

    public void search(string start)
    {
        string[] allDir = Directory.GetDirectories(start);
        string[] allFiles = Directory.GetFiles(start);

        // Basis: file ditemukan (untuk not isAll Occurence)
        // atau pencarian berakhir untuk semua file dan directory yg ada pada parent directory
        foreach (string file in allFiles)
        {   
            // jika nama file ditemukan
            if (Path.GetFileName(file) == this.goalState)
            {                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(file);
                Console.ForegroundColor = ConsoleColor.Gray;
                visited[file] = true;
                // jika bukan All Occurence, maka pencarian berakhir
                if (!isAll)
                {
                    found = true;
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine(file);
                visited[file] = true;
            }
        }
        if (!found) // belum ketemu atau bukan All Occurence
        {
            visited[start] = false;
            foreach (string dir in allDir)
            {
                if (visited[dir] == false)
                {
                    Console.WriteLine(dir);
                    search(dir); // rekurens
                }
            }
            visited[start] = false;
        }
    }

    public void DFSearch(string start)
    {
        initializeVisited(startingDir);
        search(start);
    }
}

class Driver
{
    static void Main(string[] args)
    {
        string path = @"D:\SEMESTER 4\IF2211 Strategi Algoritma\Tugas\Home";
        string goal = @"not.jpeg";
        DFS searcher = new DFS(path, goal, false);
        searcher.DFSearch(path);
    }
}
