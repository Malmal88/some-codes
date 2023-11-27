using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mdi
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Brand[] br = Form2.brands.ToArray();
            Init(br);
        }

        public void Init(Brand[] brands)
        {
            comboBox1.Items.Clear();
            foreach (var brand in brands)
            {
                comboBox1.Items.Add(new ComboboxItem() { Name = brand.Name, Tag = brand });
            }
        }
        public Model Model = new Model();
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Model.Name = textBox1.Text;
            var brand=((ComboboxItem)comboBox1.SelectedItem).Tag as Brand;
            Model.Brand = brand;
            Close();
        }
    }
}
