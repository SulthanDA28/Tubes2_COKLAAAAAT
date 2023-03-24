namespace treasure
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            panel2 = new Panel();
            textBox5 = new TextBox();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 251);
            label3.Name = "label3";
            label3.Size = new Size(217, 25);
            label3.TabIndex = 6;
            label3.Text = "Silahkan pilih file peta(.txt)";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Freestyle Script", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(83, 12);
            label1.Name = "label1";
            label1.Size = new Size(153, 43);
            label1.TabIndex = 2;
            label1.Text = "Find Treasure";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 342);
            label2.Name = "label2";
            label2.Size = new Size(260, 25);
            label2.TabIndex = 3;
            label2.Text = "Silahkan Pilih Metode Pencarian";
            // 
            // button2
            // 
            button2.Location = new Point(168, 295);
            button2.Name = "button2";
            button2.Size = new Size(89, 33);
            button2.TabIndex = 7;
            button2.Text = "Select";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(40, 391);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(66, 29);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "BFS";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(40, 449);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(69, 29);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "DFS";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.TREASUREEEE_____;
            pictureBox1.Location = new Point(13, 63);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(294, 175);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(40, 503);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 4;
            button1.Text = "Mulai";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Info;
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(radioButton1);
            panel2.Controls.Add(radioButton2);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(-1, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1133, 622);
            panel2.TabIndex = 9;
            panel2.Paint += panel2_Paint;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(40, 295);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(122, 31);
            textBox5.TabIndex = 18;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeight = 34;
            dataGridView1.ImeMode = ImeMode.NoControl;
            dataGridView1.Location = new Point(330, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.RowTemplate.ReadOnly = true;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView1.Size = new Size(789, 493);
            dataGridView1.TabIndex = 17;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.SelectionChanged += myDataGridView_SelectionChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom;
            label7.AutoSize = true;
            label7.Location = new Point(734, 578);
            label7.Name = "label7";
            label7.Size = new Size(76, 25);
            label7.TabIndex = 16;
            label7.Text = "Exc.time";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Location = new Point(751, 537);
            label6.Name = "label6";
            label6.Size = new Size(47, 25);
            label6.TabIndex = 15;
            label6.Text = "Step";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Location = new Point(346, 578);
            label5.Name = "label5";
            label5.Size = new Size(56, 25);
            label5.TabIndex = 14;
            label5.Text = "Node";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Location = new Point(353, 537);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 13;
            label4.Text = "Rute";
            label4.Click += label4_Click;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Bottom;
            textBox4.Location = new Point(817, 577);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 31);
            textBox4.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Bottom;
            textBox3.Location = new Point(817, 533);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom;
            textBox2.Location = new Point(430, 577);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom;
            textBox1.Location = new Point(430, 533);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(253, 31);
            textBox1.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 618);
            Controls.Add(panel2);
            Name = "Form1";
            Text = "Form1";
            Resize += resizeTable;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Label label1;
        private Label label2;
        private Button button2;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private PictureBox pictureBox1;
        private Button button1;
        private Panel panel2;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        protected DataGridView dataGridView1;
        private TextBox textBox5;
    }
}