using System;
using System.IO;
using System.Collections.Generic;
using Solve;

class Test {
    static void Main() {
        bool exit = false;
        while (!exit) {
            try {
                Matrix matrix = new Matrix();
                Map map = new Map(matrix);
                Console.WriteLine(map);
                Route route = new Route();
                DFS dfs = new DFS(map);

                dfs.SetTSP(false);
                dfs.FindRoute(dfs.GetRow(), dfs.GetCol(), map, route);

                if (TSP.GetElmt().Count != 0) {
                    TSP.Print();
                    TSP.GetElmt().Clear();
                } else {
                    if (route.GetStatus() == "Complete") {
                        route.Reverse();
                        Console.WriteLine(route);
                    } else {
                        Console.WriteLine("Unable to find route");
                    }
                }
                
                exit = true;
            } catch (ArgumentException error) {
                Console.WriteLine(error.Message);
            } catch (FileNotFoundException error) {
                Console.WriteLine(error.Message);
            }
        }
    }
}