using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mdi
{
    public partial class Form1 : Form
    {
        Form2 f2;
        Form3 f3;
        
        public Form1()
        {
            InitializeComponent();
        }
        void f2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f2 = null;
        }
        void f3_FormClosed(object sender, FormClosedEventArgs e)
        {
            f3 = null;
        }
        private void brandsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (f2 == null)
            {
                f2 = new Form2();
                f2.MdiParent = this;
                f2.FormClosed += new FormClosedEventHandler(f2_FormClosed);
                f2.Show();
            }
            else
                f2.Activate();
        }


        private void modelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f3 == null)
            {
                f3 = new Form3();
                f3.MdiParent = this;
                f3.FormClosed += new FormClosedEventHandler(f3_FormClosed);
                f3.Show();
            }
            else
                f3.Activate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd= new SaveFileDialog();
            sfd.Filter = "Xml files(*xml}|*.xml";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("<root>");
            foreach (Model s in Form3.models)
            {
                sb.AppendLine($"<Model's name=\"{s.Name}\"Model's brand=\"{s.Brand}\"/>");
            }
            sb.AppendLine("</root>");
            File.WriteAllText(sfd.FileName, sb.ToString());
        }

       
    }
}
