using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static телефонная_книга_3.Form1;

namespace телефонная_книга_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBoxPhone.Text = person.Phone;
            textBoxName.Text = person.Name;
        }
        public Person person = new Person();


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            person.Phone = textBoxPhone.Text;
            person.Name = textBoxName.Text;
            Close();
        }
    }
}
