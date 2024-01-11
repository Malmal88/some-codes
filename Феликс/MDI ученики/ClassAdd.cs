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
    public partial class ClassAdd : Form
    {
        public ClassAdd()
        {
            InitializeComponent();
            Teacher []teacher=DataContext.Teachers.ToArray();
            Init(teacher);
        }
        void Init(Teacher[] teachers)
        {
            comboBox1.Items.Clear();
            foreach (var t in teachers)
            {
                comboBox1.Items.Add(new Comboboxitem() { Name = t.Surname, Tag = t });
            }
        }
        public Class newclass =new Class();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty) { MessageBox.Show("Введите имя класса"); return; };
            newclass.Name=textBox1.Text;
            if(comboBox1.SelectedItem !=null)
            {
                var teacher = ((Comboboxitem)comboBox1.SelectedItem).Tag as Teacher;
                newclass.Teacher = teacher;
            }
            
            newclass.id = DataContext.counter;
            DataContext.counter++;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ClassAdd_Shown(object sender, EventArgs e)
        {
            textBox1.Text=newclass.Name;
            //if(newclass.Teacher!=null) { comboBox1.SelectedItem=newclass.Teacher.Surname; }
        }
    }
}
