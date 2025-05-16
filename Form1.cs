using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Piano_Game
{
    public partial class Form1 : Form
    {
        int Timer = 30;
        bool l = true;
        bool l2 = false;

        int x_b1 = 0;
        int x_b2 = 100;
        int x_b3 = 200;
        int x_b4 = 300;

        int y_b1 = 0;
        int y_b2 = 150;
        int y_b3 = 300;
        int y_b4 = 450;

        int Score = 0;
        int All_Score = 0;
        int r = new Random().Next(1, 5);
        private void Loc(Button ob, int x, int y)
        {
            ob.Location = new System.Drawing.Point(x, y);
        }
        private void Update_Loc()
        {
            Loc(b11, x_b1, y_b1);
            Loc(b21, x_b2, y_b1);
            Loc(b31, x_b3, y_b1);
            Loc(b41, x_b4, y_b1);

            Loc(b12, x_b1, y_b2);
            Loc(b22, x_b2, y_b2);
            Loc(b32, x_b3, y_b2);
            Loc(b42, x_b4, y_b2);

            Loc(b13, x_b1, y_b3);
            Loc(b23, x_b2, y_b3);
            Loc(b33, x_b3, y_b3);
            Loc(b43, x_b4, y_b3);

            Loc(b14, x_b1, y_b4);
            Loc(b24, x_b2, y_b4);
            Loc(b34, x_b3, y_b4);
            Loc(b44, x_b4, y_b4);
        }
        private void Edit_Color(Button ob1, Button ob2, Button ob3, Button ob4)
        {
            r = new Random().Next(1, 5);
            ob1.BackColor = Color.PaleTurquoise;
            ob2.BackColor = Color.PaleTurquoise;
            ob3.BackColor = Color.PaleTurquoise;
            ob4.BackColor = Color.PaleTurquoise;
            if (r == 1)
            {
                ob1.BackColor = Color.PaleVioletRed;
            }
            if (r == 2)
            {
                ob2.BackColor = Color.PaleVioletRed;
            }
            if (r == 3)
            {
                ob3.BackColor = Color.PaleVioletRed;
            }
            if (r == 4)
            {
                ob4.BackColor = Color.PaleVioletRed;
            }
        }

        public Form1()
        {
            InitializeComponent();
            Update_Loc();
            Line_Red.FlatStyle = FlatStyle.Flat;
            Line_Red.FlatAppearance.BorderSize = 0;
            button1.Visible = false;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Visible = false;
            try
            {
                All_Score = int.Parse(File.ReadAllText("Data.dll"));
            }
            catch
            {
                File.WriteAllText("Data.dll", $"{All_Score}");
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Start();
            if (Score > All_Score)
            {
                label5.Visible = true;
            }
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            if (l2)
            {
                if(Timer==0)
                {
                    System.Threading.Thread.Sleep(2000);
                }
                Environment.Exit(0);
            }
            void Lose(int x, Button ob1, Button ob2, Button ob3, Button ob4)
            {
                if (x == 450)
                {
                    if (e.KeyCode == Keys.F | e.KeyCode == Keys.F)
                    {
                        if (ob1.BackColor != Color.PaleVioletRed)
                        {
                            ob1.BackColor = Color.Red;
                            l = false;
                        }
                    }
                    if (e.KeyCode == Keys.G)
                    {
                        if (ob2.BackColor != Color.PaleVioletRed)
                        {
                            ob2.BackColor = Color.Red;
                            l = false;
                        }
                    }
                    if (e.KeyCode == Keys.H)
                    {
                        if (ob3.BackColor != Color.PaleVioletRed)
                        {
                            ob3.BackColor = Color.Red;
                            l = false;
                        }
                    }
                    if (e.KeyCode == Keys.J)
                    {
                        if (ob4.BackColor != Color.PaleVioletRed)
                        {
                            ob4.BackColor = Color.Red;
                            l = false;
                        }
                    }
                }
            }
            Lose(y_b1, b11, b21, b31, b41);
            Lose(y_b2, b12, b22, b32, b42);
            Lose(y_b3, b13, b23, b33, b43);
            Lose(y_b4, b14, b24, b34, b44);
            if (l)
            {
                if (e.KeyCode == Keys.G | e.KeyCode == Keys.F | e.KeyCode == Keys.J | e.KeyCode == Keys.H)
                {
                    y_b1 += 150;
                    y_b2 += 150;
                    y_b3 += 150;
                    y_b4 += 150;
                    ++Score;
                    Console.Beep(500, 50);
                }
                if (y_b1 > 450)
                {
                    y_b1 = 0;
                    Edit_Color(b11, b21, b31, b41);
                }
                if (y_b2 > 450)
                {
                    y_b2 = 0;
                    Edit_Color(b12, b22, b32, b42);
                }
                if (y_b3 > 450)
                {
                    y_b3 = 0;
                    Edit_Color(b13, b23, b33, b43);
                }
                if (y_b4 > 450)
                {
                    y_b4 = 0;
                    Edit_Color(b14, b24, b34, b44);
                }
                Update_Loc();
                void BackColor(Button ob, int y, Label l)
                {
                    if (y == 0)
                    {
                        l.BackColor = ob.BackColor;
                    }
                }
                BackColor(b41, y_b1, label5);
                BackColor(b42, y_b2, label5);
                BackColor(b43, y_b3, label5);
                BackColor(b44, y_b4, label5);
                BackColor(b11, y_b1, T_Lable);
                BackColor(b12, y_b2, T_Lable);
                BackColor(b13, y_b3, T_Lable);
                BackColor(b14, y_b4, T_Lable);
            }
            else
            {
                if (Score > All_Score)
                {
                    All_Score = Score;
                    File.WriteAllText("Data.dll", $"{All_Score}");
                }
                Line_Red.Visible = false;
                button1.Visible = true;
                button1.Text = $"\nScore: {Score}\n\nRecorad: {All_Score}";
                l2 = true;
                timer1.Stop();
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            --Timer;
            T_Lable.Text = $"{Timer}";
            if (Timer == 0) 
            {
                if (Score > All_Score)
                {
                    All_Score = Score;
                    File.WriteAllText("Data.dll", $"{All_Score}");
                }
                Line_Red.Visible = false;
                button1.Visible = true;
                button1.Text = $"\nScore: {Score}\n\nRecorad: {All_Score}";
                l2 = true;
                timer1.Stop();
            }
        }
    }
}
