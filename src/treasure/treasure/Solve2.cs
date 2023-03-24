using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace Solve2 {

    public class Matrix {
        // atribut
        private char[,] data;
        private int row;
        private int col;

        // ctor
        public Matrix() {
            Console.Write("Masukkan nama file: ");
            var fileName = Console.ReadLine();
            if (fileName == null) {
                throw new ArgumentException();
            } else {
                string[] fileData = File.ReadAllLines(fileName);
                int fileRow = fileData.Length;
                int fileCol = fileData[0].Length;
                data = new char[fileRow,(fileCol+1)/2];
                for (int i = 0; i < fileRow; i++) {
                    for (int j = 0; j < fileCol; j++) {
                        if (fileData[i][j] != ' ') {
                            data[i,(j+1)/2] = fileData[i][j];
                        }
                    }
                }
                row = data.GetLength(0);
                col = data.GetLength(1);
            }
        }
        public Matrix(char[,] matrikschar)
        {

            int baris = matrikschar.GetLength(0);
            int kolom = matrikschar.GetLength(1);
            data = new char[baris, kolom];
            for (int i = 0;i<baris;i++)
            {
                for(int j = 0;j<kolom;j++)
                {
                    data[i,j] = matrikschar[i,j];
                }
            }
            row = baris;
            col = kolom;
        }
        // getter
        public int GetRowCount() {
            return row;
        }
        // getter
        public int GetColCount() {
            return col;
        }
        // getter
        public char GetElmt(int i,int j) {
            return data[i,j];
        }

        // overload output
        public override string ToString() {
            var str = new StringBuilder();
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    str.Append(data[i,j]);
                }
                if (i < row-1) {
                    str.AppendLine();
                }
            }
            return str.ToString();
        }
    }

    public class Node {
        // atribut
        private char symbol;
        private bool right;
        private bool down;
        private bool left;
        private bool up;
        private int maxVisit;
        private int countVisit;

        // ctor
        public Node(char elmt) {
            symbol = elmt;
            if (symbol == 'K') {
                maxVisit = 1;
            }
            else {
                maxVisit = 0;
            }
            right = false;
            down = false;
            left = false;
            up = false;
            countVisit = 0;
        }

        // setter
        public void SetBool(string position, bool newBool) {
            if (position == "right") {
                right = newBool;
            } else if (position == "down") {
                down = newBool;
            } else if (position == "left") {
                left = newBool;
            } else {
                up = newBool;
            }
        }

        // getter
        public char GetSymbol() {
            return symbol;
        }
        // getter
        public bool GetBool(string position) {
            if (position == "right") {
                return right;
            } else if (position == "down") {
                return down;
            } else if (position == "left") {
                return left;
            } else {
                return up;
            }
        }

        // overload output
        public override string ToString() {
            return GetSymbol().ToString();
        }

        public void AddMaxVisit() {
            maxVisit++;
        }

        public void AddCountVisit() {
            countVisit++;
        }

        public void SubCountVisit() {
            countVisit--;
        }

        public bool IsVisitable() {
            return countVisit != maxVisit;
        }
        public int GetCountVisit() {
            return countVisit;
        }
    }

    public class Map {
        // atribut
        private Node[,] data;
        private int treasure = 0;
        private int row;
        private int col;

        // ctor
        public Map(Matrix matrix) {
            row = matrix.GetRowCount();
            col = matrix.GetColCount();
            data = new Node[row,col];
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    Node node = new Node(matrix.GetElmt(i,j));
                    data[i,j] = node;
                }
            }
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    if (data[i,j].GetSymbol() != 'X') {
                        if (data[i,j].GetSymbol() == 'T') {
                            treasure++;
                        }
                        if (i == 0) {
                            if (j == 0) {
                                if (data[i,j+1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("right",true);
                                    data[i, j].AddMaxVisit();
                                }
                            } else if (j < col-1) {
                                if (data[i,j+1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("right",true);
                                    data[i, j].AddMaxVisit();
                                }
                                if (data[i,j-1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("left",true);
                                    data[i, j].AddMaxVisit();
                                }
                            } else {
                                if (data[i,j-1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("left",true);
                                    data[i, j].AddMaxVisit();
                                }
                            }
                            if (data[i+1,j].GetSymbol() != 'X') {
                                    data[i,j].SetBool("down",true);
                                    data[i, j].AddMaxVisit();
                            }
                        } else if (i < row-1) {
                            if (j == 0) {
                                if (data[i,j+1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("right",true);
                                    data[i, j].AddMaxVisit();
                                }
                            } else if (j < col-1) {
                                if (data[i,j+1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("right",true);
                                    data[i, j].AddMaxVisit();
                                }
                                if (data[i,j-1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("left",true);
                                    data[i, j].AddMaxVisit();
                                }
                            } else {
                                if (data[i,j-1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("left",true);
                                    data[i, j].AddMaxVisit();
                                }
                            }
                            if (data[i-1,j].GetSymbol() != 'X') {
                                    data[i,j].SetBool("up",true);
                                    data[i, j].AddMaxVisit();
                            }
                            if (data[i+1,j].GetSymbol() != 'X') {
                                    data[i,j].SetBool("down",true);
                                    data[i, j].AddMaxVisit();
                            }
                        } else {
                            if (j == 0) {
                                if (data[i,j+1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("right",true);
                                    data[i, j].AddMaxVisit();
                                }
                            } else if (j < col-1) {
                                if (data[i,j+1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("right",true);
                                    data[i, j].AddMaxVisit();
                                }
                                if (data[i,j-1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("left",true);
                                    data[i, j].AddMaxVisit();
                                }
                            } else {
                                if (data[i,j-1].GetSymbol() != 'X') {
                                    data[i,j].SetBool("left",true);
                                    data[i, j].AddMaxVisit();
                                }
                            }
                            if (data[i-1,j].GetSymbol() != 'X') {
                                    data[i,j].SetBool("up",true);
                                    data[i, j].AddMaxVisit();
                            }
                        }
                    }
                }
            }
        }

        // getter
        public int GetTreasureCount() {
            return treasure;
        }
        // getter
        public int GetRowCount() {
            return row;
        }
        // getter
        public int GetColCount() {
            return col;
        }
        // getter
        public Node GetElmt(int i,int j) {
            return data[i,j];
        }

        // overload output
        public override string ToString() {
            var str = new StringBuilder();
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    str.Append(data[i,j]);
                }
                if (i < row-1) {
                    str.AppendLine();
                }
            }
            return str.ToString();
        }

    }

    public class Route {
        // atribut
        private Stack<char> data;
        private int treasure;
        private string status; 

        // ctor
        public Route() {
            data = new Stack<char>();
            treasure = 0;
            status = "Incomplete";
        }
        // cctor
        public Route(Route other) {
            data = new Stack<char>(other.data);
            treasure = other.treasure;
            status = other.status;
        }

        // setter
        public void SetElmt(Stack<char> newData) {
            data = newData;
        }
        // setter
        public void AddTreasure() {
            treasure++;
        }
        public void RemoveTreasure() {
            treasure--;
        }
        // setter
        public void SetStatus(string newStatus) {
            status = newStatus;
        }

        // getter
        public Stack<char> GetElmt() {
            return data;
        }
        // getter
        public int GetTreasureCount() {
            return treasure;
        }
        public string GetStatus() {
            return status;
        }

        // method
        public void Reverse() {
            Stack<char> revRoute = new Stack<char>();
            while (GetElmt().Count != 0) {
                revRoute.Push(GetElmt().Pop());
            }
            SetElmt(revRoute);
        }
        public override string ToString() {
            var str = new StringBuilder();
            str.Append("Route: ");
            foreach (char item in GetElmt()) {
                str.Append(item + "->");
            }
            str.Append("Finished");
            return str.ToString();
        }
    }

    // Test
    public class TSP {
        // atribut
        public static Stack<char> data = new Stack<char>();

        // setter
        public static void SetElmt(Route route) {
            data = route.GetElmt();
        }

        // getter
        public static Stack<char> GetElmt() {
            return data;
        }

        public static void Print() {
            var str = new StringBuilder();
            str.Append("TSP Route: ");
            foreach (char item in GetElmt()) {
                str.Append(item + "->");
            }
            str.Append("Finished");
            Console.WriteLine(str.ToString());
        }
    }
    public class cekRute
    {
        public static Stack<int[]> simpanrute = new Stack<int[]>();
        public static List<int[]> semuarute = new List<int[]>();
    }
    public class DFS {
        // atribut
        private int curRow;
        private int curCol;
        private Node curNode;
        private bool tsp;

        // ctor
        public DFS(Map map) {
            for (int i = 0; i < map.GetRowCount(); i++) {
                for (int j = 0; j < map.GetColCount(); j++) {
                    if (map.GetElmt(i,j).GetSymbol() == 'K') {
                        curRow = i;
                        curCol = j;
                    }
                }
            }
            curNode = map.GetElmt(curRow,curCol);

        }

        // setter
        public void SetTSP(bool newTSP) {
            tsp = newTSP;
        }
        
        // getter
        public int GetRow() {
            return curRow;
        }
        // getter
        public int GetCol() {
            return curCol;
        }
        // getter
        public bool GetTSP() {
            return tsp;
        }

        // method
        		// method
        public void FindRoute(int newRow, int newCol, Map newMap, Route newRoute) {
            Route Copy = new Route(newRoute);
            Console.Write("Current Route: ");
            while (Copy.GetElmt().Count != 0) {
                Console.Write(Copy.GetElmt().Pop());
                if (Copy.GetElmt().Count != 0) {
                    Console.Write("->");
                }
            }
            Console.WriteLine();

            int prevRow = curRow;
            int prevCol = curCol;
            Node prevNode = curNode;
            curRow = newRow;
            curCol = newCol;
            curNode = newMap.GetElmt(curRow,curCol);

            if (curNode.GetSymbol() == 'T') {
                if (curNode.GetCountVisit() == 0) {
                    newRoute.AddTreasure();
                }
            }

		    curNode.AddCountVisit();

            if (newRoute.GetTreasureCount() == newMap.GetTreasureCount()) {
                newRoute.SetStatus("Complete");
            }

            // Console.WriteLine("Checking Right Position");
            if ((curNode.GetBool("right")) && (newRoute.GetStatus() != "Complete")) {
                int nextCol = curCol+1;
                Node nextNode = newMap.GetElmt(curRow, nextCol);
                if (nextNode.IsVisitable()) {
                    newRoute.GetElmt().Push('R');
                    int[] simpan = new int[2];
                    simpan[0] = curRow;
                    simpan[1] = nextCol;
                    cekRute.simpanrute.Push(simpan);
                    cekRute.semuarute.Add(simpan);
                    // Console.WriteLine("Adding R to Unreversed Route");
                    FindRoute(curRow, nextCol, newMap, newRoute);
                }
            }
            // Console.WriteLine("Checking Down Position");
            if ((curNode.GetBool("down")) && (newRoute.GetStatus() != "Complete")) {
                int nextRow = curRow+1;
                Node nextNode = newMap.GetElmt(nextRow, curCol);
                if (nextNode.IsVisitable()) {
                    if (nextNode.GetSymbol() == 'T') {
                        newRoute.AddTreasure();
                    }
                    newRoute.GetElmt().Push('D');
                    int[] simpan = new int[2];
                    simpan[0] = nextRow;
                    simpan[1] = curCol;
                    cekRute.simpanrute.Push(simpan);
                    cekRute.semuarute.Add(simpan);
                    // Console.WriteLine("Adding D to Unreversed Route");
                    FindRoute(nextRow, curCol, newMap, newRoute);
                }
            }
            // Console.WriteLine("Checking Left Position");
            if ((curNode.GetBool("left")) && (newRoute.GetStatus() != "Complete")) {
                int nextCol = curCol-1;
                Node nextNode = newMap.GetElmt(curRow, nextCol);
                if (nextNode.IsVisitable()) {
                    newRoute.GetElmt().Push('L');
                    int[] simpan = new int[2];
                    simpan[0] = curRow;
                    simpan[1] = nextCol;
                    cekRute.simpanrute.Push(simpan);
                    cekRute.semuarute.Add(simpan);
                    // Console.WriteLine("Adding L to Unreversed Route");
                    FindRoute(curRow, nextCol, newMap, newRoute);
                }
            }
            // Console.WriteLine("Checking Up Position");
            if ((curNode.GetBool("up")) && (newRoute.GetStatus() != "Complete")) {
                int nextRow = curRow-1;
                Node nextNode = newMap.GetElmt(nextRow, curCol);
                if (nextNode.IsVisitable()) {
                    newRoute.GetElmt().Push('U');
                    int[] simpan = new int[2];
                    simpan[0] = nextRow;
                    simpan[1] = curCol;
                    cekRute.simpanrute.Push(simpan);
                    cekRute.semuarute.Add(simpan);
                    // Console.WriteLine("Adding U to Unreversed Route");
                    FindRoute(nextRow, curCol, newMap, newRoute);
                }
            }

            // Console.WriteLine("Reached Dead End...");

            if (newRoute.GetStatus() != "Complete") {
			    curNode.SubCountVisit();
                if (curNode.GetSymbol() == 'T') {
                    if (curNode.GetCountVisit() == 0) {
                        newRoute.RemoveTreasure();
                    }
                }
               	if (curNode.GetSymbol() != 'K') {
                  	char curChar = newRoute.GetElmt().Pop();
                  	int[] buang = cekRute.simpanrute.Pop();
                    cekRute.semuarute.Add(buang);
                  	// Console.WriteLine("Removing " + curChar + " from Unreversed Route...");
                }
                curRow = prevRow;
                curCol = prevCol;
                curNode = prevNode;
            }
        }
    }

}