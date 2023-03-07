using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace шары_порядок
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            for (int i = 0; i <N;i++)
            {
                x[i] = r.Next(pictureBox1.Width);
                y[i] = r.Next(pictureBox1.Height);
                dirx[i] = r.Next(100) < 50;
                diry[i] = r.Next(100) < 50;
            }
        }
        const int N = 100;
        int[] x = new int[N];
        int[] y = new int[N];
        bool[] dirx = new bool[N];
        bool[] diry = new bool[N];
        int speed = 1;
        Random r = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            

            var gr = e.Graphics;
            gr.Clear(Color.White);
            for (int i = 0; i <N; i++)
            {
                gr.DrawEllipse(Pens.Black, x[i], y[i], 20, 20);
                gr.FillEllipse(Brushes.AliceBlue, x[i], y[i],20, 20);
                if (x[i] >= pictureBox1.Width - 20) { dirx[i] = false; }
                x[i] += dirx[i] ? speed : -speed;
                if (x[i] == 0) { dirx[i] = true; }
                if (y[i] >= pictureBox1.Height-20) { diry[i] = false; }
                y[i] += diry[i] ? speed : -speed;
                if (y[i] == 0) { diry[i] = true; }
               

            }

        }

       
    }
    }
