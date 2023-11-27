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
   
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
       
        public Brand brand=new Brand();
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            brand.Name=textBox1.Text;           
            Close();
        }
    }
}
