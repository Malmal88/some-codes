using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace звезды
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
            for(int i = 0; i < N; i++)
            {
                x[i] = r.Next(pictureBox1.Width);
                y[i] = r.Next(pictureBox1.Height);
                speed[i] = r.Next(0,300)/10f;
                starsize[i]=r.Next(1, 4);
                
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up) { shipy -= 10; }
            if (keyData == Keys.Down) {shipy+=10; }
            if(keyData == Keys.Left) { shipx-=10; }
            if (keyData == Keys.Right) { shipx += 10; }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        const int N = 400;
        float[] x = new float[N];
        float[] y = new float[N];
        float []speed = new float[N];
        float[]starsize=new float[N];
        float shipx = 300;
        float shipy = 300;
        Random r = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            gr.Clear(Color.Black);
            for(int i = 0; i < N;i++)
            {
                gr.FillEllipse(Brushes.Silver, x[i], y[i], starsize[i], starsize[i]);
                if (x[i] > 0) { x[i] -= speed[i]; }
                else x[i] = pictureBox1.Width; 
            }
            gr.FillEllipse(Brushes.LightYellow, shipx, shipy, 50, 20);

        }
    }
}
