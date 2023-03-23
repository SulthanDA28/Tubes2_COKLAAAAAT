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
                TSP tsp = new TSP();

                dfs.SetTSP(false);
                dfs.FindRoute(dfs.GetRow(), dfs.GetCol(), map, route, tsp);

                if (dfs.GetTSP()) {
                    route.Reverse();
                    Console.WriteLine(route);
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