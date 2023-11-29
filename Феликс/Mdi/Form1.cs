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
using System.Xml.Linq;

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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Xml files(*xml}|*.xml";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<Brands>");
            foreach (Brand br in DataContext.brands)
            {
                sb.AppendLine($"<Brand name=\"{br.Name}\" id=\"{br.id}\"/>");
            }
            sb.AppendLine("</Brands>");
            sb.AppendLine("<Models>");

            foreach (Model s in DataContext.models)
            {
                sb.AppendLine($"<Model name=\"{s.Name}\" brandid=\"{s.Brand.id}\"/>");
            }
            sb.AppendLine("</Models>");
            sb.AppendLine("</root>");
            File.WriteAllText(sfd.FileName, sb.ToString());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xml files(*xml}|*.xml";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var doc = XDocument.Load(ofd.FileName);
            DataContext.brands.Clear();
            DataContext.models.Clear();
            foreach (var brand in doc.Element("root").Elements("Brand"))
            {
                var br= brand.Attribute("name").Value;
                var id= brand.Attribute("id").Value;
                DataContext.brands.Add(new Brand() { Name = br, id = int.Parse(id) });
            }


        }
    }
}
