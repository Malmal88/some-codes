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
    public partial class Teachers : Form
    {
        public Teachers()
        {
            InitializeComponent();
            Updateteach();
        }
        void Updateteach()
        {
            listViewTeachers.Items.Clear();
            foreach(Teacher teacher in DataContext.Teachers) 
            {
                listViewTeachers.Items.Add(new ListViewItem(new string[] {teacher.Surname,teacher.Name,teacher.Otchestvo}) { Tag = teacher});
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TeacherAdd teacherAdd = new TeacherAdd();
            teacherAdd.ShowDialog();
            if(teacherAdd.DialogResult == DialogResult.OK)
            {
                var newteacher = teacherAdd.teacher;
                DataContext.Teachers.Add(newteacher);
                Updateteach();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(listViewTeachers.SelectedItems.Count == 0) { return; }
            var teacher = listViewTeachers.SelectedItems[0].Tag as Teacher;
            foreach(var cl in DataContext.Classes) 
            { 
                if(cl.Teacher.Surname == teacher.Surname)
                {
                    MessageBox.Show($"Учитель назначен(а) руководителем {cl.Name} класса, невозможно удалить!");return;
                }
            }
            DialogResult result = MessageBox.Show
               ($"удалить{teacher.Surname}?",
               "?", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return; 
            DataContext.Teachers.Remove(teacher);
            Updateteach();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (listViewTeachers.SelectedItems.Count == 0) { return; }
            var teacher = listViewTeachers.SelectedItems[0].Tag as Teacher;
            TeacherAdd teacherAdd = new TeacherAdd();
            teacherAdd.teacher = teacher;
            teacherAdd.ShowDialog();
            Updateteach();
        }
    }
}
