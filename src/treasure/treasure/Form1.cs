using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using System.Windows.Forms;
using Solve;

namespace treasure
{


    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public static char[,] txttoMatrix(string namafile)
        {
            string[] text = File.ReadAllLines(namafile);
            List<string> list = new List<string>();
            foreach (string huruf in text)
            {

                list.Add(huruf);
            }
            int len = list[0].Length;
            int row = list.Count;
            int col = 0;
            for (int i = 0; i < len; i++)
            {
                if (list[0][i] != ' ')
                {
                    col += 1;
                }
            }
            char[,] matrixchar = new char[row, col];
            int countrow = 0;
            int countcol = 0;
            for (int j = 0; j < row; j++)
            {
                for (int k = 0; k < len; k++)
                {
                    if (list[j][k] != ' ')
                    {
                        matrixchar[countrow, countcol] = list[j][k];
                        countcol += 1;
                    }
                    else
                    {
                        continue;
                    }
                }
                countrow += 1;
                countcol = 0;
            }
            return matrixchar;

        }

        public class GlobalMatriks
        {
            public static char[,] matrikschar = new char[0, 0];
        }
        public class directFile
        {
            public static string directoryfile = "";
        }



        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog carifile = new OpenFileDialog();
            carifile.Title = "Select File";
            carifile.Filter = "Text FIle(*.txt)|*txt";
            carifile.FilterIndex = 1;
            carifile.ShowDialog();
            if (carifile.FileName != "")
            {
                try
                {
                    directFile.directoryfile = carifile.FileName;
                    GlobalMatriks.matrikschar = txttoMatrix(carifile.FileName);
                    if (cekvalidMatrix(GlobalMatriks.matrikschar))
                    {
                        string getnamafile = Path.GetFileName(carifile.FileName);
                        makeMap(GlobalMatriks.matrikschar);
                        makeMap(GlobalMatriks.matrikschar);
                        resizeTabelReal();
                        textBox5.Text = getnamafile;
                        textBox5.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Input masih ada yang salah");
                    }

                }
                catch
                {
                    MessageBox.Show("Input file masih salah!");
                }


            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myDataGridView_SelectionChanged(Object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        public bool cekvalidMatrix(char[,] matriks)
        {
            for (int i = 0; i < matriks.GetLength(0); i++)
            {
                for (int j = 0; j < matriks.GetLength(1); j++)
                {
                    if (matriks[i, j] != 'K' && matriks[i, j] != 'T' && matriks[i, j] != 'R' && matriks[i, j] != 'X')
                    {
                        return false;
                        break;

                    }
                }
            }
            return true;
        }
        public void makeMap(char[,] matriks)
        {

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.ColumnHeadersVisible = false;

            dataGridView1.RowHeadersVisible = false;
            int row = matriks.GetLength(0);
            int col = matriks.GetLength(1);
            dataGridView1.ColumnCount = col;
            dataGridView1.RowCount = row;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for (int r = 0; r < row; r++)
            {

                for (int c = 0; c < col; c++)
                {

                    if (matriks[r, c] == 'K')
                    {
                        dataGridView1[c, r].Value = "Start";
                    }
                    else if (matriks[r, c] == 'X')
                    {
                        dataGridView1[c, r].Style.BackColor = Color.Black;
                    }

                    else if (matriks[r, c] == 'T')
                    {
                        dataGridView1[c, r].Value = "Treassure";
                    }
                    else if (matriks[r, c] == 'R')
                    {
                        dataGridView1[c, r].Style.BackColor = Color.White;
                    }

                }

            }

            for (int r = 0; r < col; r++)
            {
                dataGridView1.Columns[r].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

        }
        public void clearMap(char[,] matriks)
        {
            int row = matriks.GetLength(0);
            int col = matriks.GetLength(1);
            for (int r = 0; r < row; r++)
            {

                for (int c = 0; c < col; c++)
                {

                    if (matriks[r, c] == 'K')
                    {
                        dataGridView1[c, r].Value = "Start";
                        dataGridView1[c, r].Style.BackColor = Color.White;
                    }
                    else if (matriks[r, c] == 'X')
                    {
                        dataGridView1[c, r].Style.BackColor = Color.Black;
                    }

                    else if (matriks[r, c] == 'T')
                    {
                        dataGridView1[c, r].Value = "Treassure";
                        dataGridView1[c, r].Style.BackColor = Color.White;

                    }
                    else if (matriks[r, c] == 'R')
                    {
                        dataGridView1[c, r].Style.BackColor = Color.White;
                    }
                }

            }

            for (int r = 0; r < col; r++)
            {
                dataGridView1.Columns[r].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        public class sudahSelesai
        {
            public static bool sudahselesai = true;
        }
        public static int[] cariK(char[,] matriks)
        {
            int[] cari = new int[2];
            int row = matriks.GetLength(0);
            int col = matriks.GetLength(1); 
            for(int i = 0;i<row;i++)
            {
                for(int j = 0;j<col;j++)
                {
                    if (matriks[i,j]=='K')
                    {
                        cari[0] = i;
                        cari[1] = j;
                        break;
                    }
                }
            }
            return cari;
        }
        public async void makeColorMap(List<int[]> cetakMap)
        {

            int banyak = cetakMap.Count;
            int[] tempatK = cariK(GlobalMatriks.matrikschar);
            dataGridView1[tempatK[1], tempatK[0] ].Style.BackColor = Color.Blue;

            await Task.Delay(500);
            dataGridView1[tempatK[1], tempatK[0]].Style.BackColor = Color.LightGreen;
            
            for (int i = 0; i < banyak; i++)
            {

                dataGridView1[cetakMap[i][1], cetakMap[i][0]].Style.BackColor = Color.Blue;
                if (i > 0)
                {
                    dataGridView1[cetakMap[i-1][1], cetakMap[i-1][0]].Style.BackColor = Color.LightGreen;
                }
                await Task.Delay(500);
                sudahSelesai.sudahselesai = false;
            }
            sudahSelesai.sudahselesai = true;
        }
        private void resizeTabelReal()
        {
            int selisih = 3;
            if (dataGridView1.RowCount == 0) return;
            int panjang = (dataGridView1.Size.Height - selisih) / dataGridView1.RowCount;
            int sisap = (dataGridView1.Size.Height - selisih) % dataGridView1.RowCount;

            foreach (DataGridViewRow baris in dataGridView1.Rows)
            {
                if (sisap > 0)
                {
                    baris.Height = panjang + 1;
                    sisap--;
                }
                else
                {
                    baris.Height = panjang;
                }
            }
        }
        private void resizeTable(object sender, EventArgs e)
        {
            resizeTabelReal();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked && directFile.directoryfile != "" && cekvalidMatrix(GlobalMatriks.matrikschar))
            {
                if (sudahSelesai.sudahselesai == false)
                {
                    MessageBox.Show("Belum Selesai Woi");
                }
                else
                {
                    //clearMap(GlobalMatriks.matrikschar);
                    if(checkBox1.Checked)
                    {
                        var watch = new System.Diagnostics.Stopwatch();
                        cekRute.simpanrute = new Stack<int[]>();
                        cekRute.semuarute = new List<int[]>();
                        watch.Start();
                        Solve.Matrix matriks = new Solve.Matrix(GlobalMatriks.matrikschar);
                        Solve.Map map = new Solve.Map(matriks);
                        Solve.Route rute = new Solve.Route();
                        Solve.DFS dfs = new Solve.DFS(map);


                        dfs.SetTSP(true);
                        dfs.FindRoute(dfs.GetRow(), dfs.GetCol(), map, rute);
                        watch.Stop();
                        long waktu = watch.ElapsedMilliseconds;
                        if (rute.GetStatus() == "Complete")
                        {
                            rute.Reverse();
                            makeColorMap(cekRute.semuarute);
                            textBox1.Text = rute.ToString();
                            textBox2.Text = cekRute.semuarute.Count.ToString();
                            textBox3.Text = rute.GetElmt().Count.ToString();
                            textBox4.Text = waktu.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Gak nemu rute mazeh");
                        }


                    }
                    else
                    {
                        var watch = new System.Diagnostics.Stopwatch();
                        cekRute.simpanrute = new Stack<int[]>();
                        cekRute.semuarute = new List<int[]>();
                        watch.Start();
                        Solve.Matrix matriks = new Solve.Matrix(GlobalMatriks.matrikschar);
                        Solve.Map map = new Solve.Map(matriks);
                        Solve.Route rute = new Solve.Route();
                        Solve.DFS dfs = new Solve.DFS(map);
                        
                        
                        dfs.SetTSP(false);
                        dfs.FindRoute(dfs.GetRow(),dfs.GetCol(),map,rute);
                        watch.Stop();
                        long waktu = watch.ElapsedMilliseconds;
                        if(rute.GetStatus()=="Complete")
                        {
                            rute.Reverse();
                            makeColorMap(cekRute.semuarute);
                            textBox1.Text = rute.ToString();
                            textBox2.Text = cekRute.semuarute.Count.ToString();
                            textBox3.Text = rute.GetElmt().Count.ToString();
                            textBox4.Text = waktu.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Gak nemu rute mazeh");
                        }



                    }

                    
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox4.ReadOnly = true;
                }

            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}