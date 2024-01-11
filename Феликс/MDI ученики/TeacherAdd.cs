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
    public partial class TeacherAdd : Form
    {
        public TeacherAdd()
        {
            InitializeComponent();
            
        }
        public Teacher teacher = new Teacher();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxFam.Text == string.Empty) { MessageBox.Show("Введите фамилию"); return; };
            teacher.Name = textBoxName.Text;
            teacher.Surname = textBoxFam.Text;
            teacher.Otchestvo = textBoxOtch.Text;
            teacher.id = DataContext.counter;
            DataContext.counter++;
            DialogResult = DialogResult.OK;
            
            Close();
        }

        private void TeacherAdd_Shown(object sender, EventArgs e)
        {
            textBoxName.Text = teacher.Name;
            textBoxFam.Text = teacher.Surname;
            textBoxOtch.Text = teacher.Otchestvo;
        }
    }
}
