using System;
using System.IO;
using System.Runtime.ExceptionServices;

class Bfs
{
    static public List<Node> bfs(Graph g, int treasureCount)    // Algoritma BFS utama
    {
        Node n;
        Node end;
        Node startNode = g.getStartNode();
        List<Node> treasures = new List<Node>();
        List<Node> neighbors;
        Queue<Node> queue = new Queue<Node>();

        queue.Enqueue(startNode);
        startNode.setMarked(true);

        while (queue.Count > 0 && treasureCount > 0)
        {
            n = queue.Dequeue();
            neighbors = g.getNeighbors(n);
            for (int i = 0; i < neighbors.Count; i++)
            {
                if (!neighbors[i].getMarked())
                {
                    if (neighbors[i].getNodeType() == 'T')
                    {
                        
                        end = neighbors[i];
                        treasures.Add(end);
                        treasureCount--;
                    }
                    queue.Enqueue(neighbors[i]);
                    neighbors[i].setMarked(true);
                    neighbors[i].setPrevNode(n);
                }
            }
        }
        return treasures;   // Mengembalikan semua treasure yang ditemukan untuk dibangun path/rutenya
    }

    static public List<List<Node>> constructPath(List<Node> treasures)  // Untuk membangun path/rute dari treasure ke starting node, yaitu 'K'
    {
        
        List<List<Node>> paths = new List<List<Node>>();

        for (int i = 0; i < treasures.Count; i++)
        {
            Node current = treasures[i];
            paths.Add(new List<Node>());
            while (current.getPrevNode() != null)
            {
                paths[i].Add(current);
                current = current.getPrevNode();
            }
            paths[i].Add(current);

            paths[i].Reverse();
        }

        return paths;
    }

    static public void readFileForBFS(Graph g, string textFile) // Membaca file input dan mengubahnya ke graf, dibuat khusus untuk BFS karena perbedaan representasi graf
    {
        List<Node> nodes = new List<Node>();

        string text = File.ReadAllText(textFile);
        int x = 0;
        int y = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '\n')
            {
                y++;
                x = 0;
            }
            if (text[i] == 'T' || text[i] == 'R' || text[i] == 'K')
            {
                nodes.Add(new Node(x, y, text[i]));
            }
            if (text[i] == 'T' || text[i] == 'R' || text[i] == 'K' || text[i] == 'X')
            {
                x++;
            }
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            g.addNode(nodes[i], new List<Node> { });
            for (int j = 0; j < nodes.Count; j++)
            {
                if (i != j)
                {
                    if (nodes[j].getX() == nodes[i].getX() || nodes[j].getX() == nodes[i].getX())
                    {
                        if (nodes[j].getY() == nodes[i].getY() + 1 || nodes[j].getY() == nodes[i].getY() - 1)
                        {
                            g.addNeighbor(nodes[i], nodes[j]);
                        }
                    }
                    if (nodes[j].getY() == nodes[i].getY() || nodes[j].getY() == nodes[i].getY())
                    {
                        if (nodes[j].getX() == nodes[i].getX() + 1 || nodes[j].getX() == nodes[i].getX() - 1)
                        {
                            g.addNeighbor(nodes[i], nodes[j]);
                        }
                    }
                }
            }
        }
    }

    static public void printAllPath(List<List<Node>> paths)
    {
        for (int i = 0; i < paths.Count; i++)
        {
            Console.WriteLine("Path " + (i+1) + " :");
            for (int j = 0; j < paths[i].Count; j++)
            {
                Console.WriteLine("(" + paths[i][j].getX() + ", " + paths[i][j].getY() + ")");
            }

        }
    }

    static public void printRoute(List<char> route)
    {
        for(int i = 0; i < route.Count; i++)
        {
            if(i < route.Count-1)
            {
                Console.Write(route[i] + " - ");
            } 
            else
            {
                Console.Write(route[i]);
            }
        }
        Console.WriteLine();
    }

    static public List<char> makeRoute(List<List<Node>> paths)
    {
        List<char> temp = new List<char>();
        List<char> route = new List<char>();

        for(int i = 0; i < paths.Count;i++)
        {
            for(int j = 0; j < paths[i].Count - 1; j++)
            {
                if (paths[i][j].getX() == paths[i][j+1].getX())
                {
                    if (paths[i][j].getY() > paths[i][j+1].getY())
                    {
                        temp.Add('D');
                        route.Add('U');
                    }
                    else
                    {
                        temp.Add('U');
                        route.Add('D');
                    }
                }
                if(paths[i][j].getY() == paths[i][j + 1].getY())
                {
                    if(paths[i][j].getX() > paths[i][j + 1].getX())
                    {
                        temp.Add('R');
                        route.Add('L');
                    }
                    else
                    {
                        temp.Add('L');
                        route.Add('R');
                    }
                }
            }
            if(i != paths.Count - 1)
            {
                temp.Reverse();
                route.AddRange(temp);
            }
        }
        return route;
    }

    static public void Main(String[] args)
    {
        List<List<Node>> paths;
        List<char> route;
        int treasureCount;

        // Testcase dari Spek
        Console.WriteLine("Testcase dari Spek");

        Graph g1 = new Graph();
        readFileForBFS(g1, "../../../tc.txt");
        treasureCount = g1.getTreasureCount();
        paths = constructPath(bfs(g1, treasureCount));
        route = makeRoute(paths);
        printRoute(route);
        printAllPath(paths);

        // Sampel-1
        Console.WriteLine("\nSampel-1");

        Graph g2 = new Graph();
        readFileForBFS(g2, "../../../sampel-1.txt");
        treasureCount = g2.getTreasureCount();
        paths = constructPath(bfs(g2, treasureCount));
        route = makeRoute(paths);
        printRoute(route);
        printAllPath(paths);

        // Sampel-2
        Console.WriteLine("\nSampel-2");

        Graph g3 = new Graph();
        readFileForBFS(g3, "../../../sampel-2.txt");
        treasureCount = g3.getTreasureCount();
        paths = constructPath(bfs(g3, treasureCount));
        route = makeRoute(paths);
        printRoute(route);
        printAllPath(paths);

        // Sampel-4
        Console.WriteLine("\nSampel-4");

        Graph g4 = new Graph();
        readFileForBFS(g4, "../../../sampel-4.txt");
        treasureCount = g4.getTreasureCount();
        paths = constructPath(bfs(g4, treasureCount));
        route = makeRoute(paths);
        printRoute(route);
        printAllPath(paths);

        // Sampel-5
        Console.WriteLine("\nSampel-5");

        Graph g5 = new Graph();
        readFileForBFS(g5, "../../../sampel-5.txt");
        treasureCount = g5.getTreasureCount();
        paths = constructPath(bfs(g5, treasureCount));
        route = makeRoute(paths);
        printRoute(route);
        printAllPath(paths);
    }
}