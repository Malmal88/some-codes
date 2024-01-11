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
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
            Update();
            DataContext.Teachers.CollectionChanged += Teachers_CollectionChanged;
        }

        private void Teachers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            listViewClasses.Items.Clear();
            foreach (Class classss in DataContext.Classes)
            {
                string teach=string.Empty;
                if (classss.Teacher == null) teach = "Не выбран";
                else teach = classss.Teacher.Surname;
                listViewClasses.Items.Add(new ListViewItem(new string[] { classss.Name, teach }) { Tag = classss });
            }
        }

        void Update()
        {
            listViewClasses.Items.Clear();
            foreach (Class classss in DataContext.Classes)
            {
                string teach;
                if (classss.Teacher == null) teach = "Не выбран";
                else teach = classss.Teacher.Surname;
                listViewClasses.Items.Add(new ListViewItem(new string[] { classss.Name, teach }) { Tag = classss });
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (DataContext.Teachers.Count == 0) { MessageBox.Show("Нет доступных руководителей, сначала добавьте учителя "); return; }
            ClassAdd classes = new ClassAdd();

            classes.ShowDialog();
            if (classes.DialogResult == DialogResult.OK)
            {
                var classadd = classes.newclass;
                DataContext.Classes.Add(classadd);
                Update();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listViewClasses.SelectedItems.Count == 0) { return; }
            var classs = listViewClasses.SelectedItems[0].Tag as Class;
            int counter = 0;
            foreach (Student student in DataContext.Students)
            {
                if (student.Class != null && student.Class.Name == classs.Name) counter++;
            }
            if (counter != 0)
            {
                DialogResult result = MessageBox.Show
                ($"В классе {counter} учеников, все равно удалить?",
                "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
            }

            foreach (Student student in DataContext.Students)
            {
                if (student.Class != null && student.Class.Name == classs.Name)
                {
                    student.Class = null;
                }
            }
            DataContext.Classes.Remove(classs);
            Update();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(listViewClasses.SelectedItems.Count == 0) { return; }
            var cl = listViewClasses.SelectedItems[0].Tag as Class;
            ClassAdd classAdd = new ClassAdd();
            classAdd.newclass = cl;
            classAdd.ShowDialog();
            Update();
        }

        private void списокУчениковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewClasses.SelectedItems.Count == 0) return;
            var cl = listViewClasses.SelectedItems[0].Tag as Class;
            
            foreach (Student student in DataContext.Students)
            {
                if(student.Class.Name == cl.Name)  DataContext.temp.Add(student);  
            }
            Form1 form1 = new Form1();
            form1.ShowDialog();

        }
    }
}
