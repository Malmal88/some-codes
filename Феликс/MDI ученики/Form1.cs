using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_ученики
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Update();
        }
        void Update()
        {
            listView1.Items.Clear();
            foreach(Student student in DataContext.temp)
            {
                listView1.Items.Add(new ListViewItem(new string[] { student.Surname, student.Name, student.Otchestvo, student.birthday.ToString(), student.Class.Name }));
            }
            
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Update();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataContext.temp.Clear();
        }
    }
}
