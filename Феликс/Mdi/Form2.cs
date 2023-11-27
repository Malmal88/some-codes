using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mdi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void Update()
        {
            listView1.Items.Clear();
            foreach (Brand s in brands)
            {
                listView1.Items.Add(new ListViewItem(new string[] { s.Name, s.id.ToString() }) { Tag = s });
            }
        }
        static public List<Brand> brands = new List<Brand>();        
        public int nextid = 1;
        private void toolStripButton1_Click(object sender, EventArgs e)// Добавить
        {
            Form4 fadd = new Form4();
            fadd.ShowDialog();
            if (fadd.DialogResult == DialogResult.OK)
            {
                var newBrand = fadd.brand;
                newBrand.id = nextid;
                brands.Add(newBrand);
                nextid++;
                Update();
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)// Удалить
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            var brand = listView1.SelectedItems[0].Tag as Brand;
            DialogResult = MessageBox.Show($"Удалить {brand.Name}", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.No) return;
            //foreach (var b in Form3.models) // !!!!!!!! ошибка при удалении
            //{
            //    if (b.Brand.Name == brand.Name)
            //    {
            //        Form3.models.Remove(b);
                    
            //    }
                   
            //}
            brands.Remove(brand);
            Update();
            

        }
    }
}
