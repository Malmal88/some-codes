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
    public partial class StudentAdd : Form
    {
        public StudentAdd()
        {
            InitializeComponent();
            Class[]cl=DataContext.Classes.ToArray();
            Init(cl);
        }
        void Init(Class[] classes)
        {
            comboBox1.Items.Clear();
            foreach (var cl in classes)
            {
                comboBox1.Items.Add(new Comboboxitem() { Name=cl.Name, Tag=cl});
            }
        }
        public Student Student=new Student();
        private void button1_Click(object sender, EventArgs e)
        {
           
            if(textBoxFam.Text == string.Empty && textBoxName.Text == string.Empty && textBoxOtch.Text == string.Empty) { MessageBox.Show("Введите данные"); return; }
            Student.Name=textBoxName.Text;
            Student.Surname=textBoxFam.Text;
            Student.Otchestvo=textBoxOtch.Text;
            Student.birthday = dateTimePicker1.Value;
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выбирете класс");return;
            }
            
                var calss = ((Comboboxitem)comboBox1.SelectedItem).Tag as Class;
                Student.Class = calss;
            
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void StudentAdd_Shown(object sender, EventArgs e)
        {
            textBoxFam.Text = Student.Surname;
            textBoxName.Text = Student.Name;
            textBoxOtch.Text = Student.Otchestvo;
        }
    }
}
