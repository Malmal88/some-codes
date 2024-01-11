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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            Update();
            DataContext.Classes.CollectionChanged += Classes_CollectionChanged;
        }
        
        private void Classes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            listViewStudents.Items.Clear();
            foreach (Student st in DataContext.Students)
            {
                string classss;
                if (st.Class == null) classss = "Не выбран";
                else classss = st.Class.Name;

                listViewStudents.Items.Add(new ListViewItem(new string[] { st.Name, st.Surname, st.Otchestvo, st.birthday.ToString(), classss }) { Tag = st });
            }
        }

        void Update()
        {
            listViewStudents.Items.Clear();
            foreach (Student st in DataContext.Students)
            {
                string classss;
                if (st.Class == null) classss = "Не выбран";
                else classss = st.Class.Name;
                
                listViewStudents.Items.Add(new ListViewItem(new string[] { st.Name, st.Surname, st.Otchestvo, st.birthday.ToShortDateString(), classss  }) { Tag =st});
            } 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(DataContext.Classes.Count == 0) { MessageBox.Show("Нет доступных классов, сначала создайте класс"); return; }
            StudentAdd studentAdd = new StudentAdd();
            studentAdd.ShowDialog();
            if (studentAdd.DialogResult == DialogResult.OK)
            {
                var newstudent=studentAdd.Student;
                DataContext.Students.Add(newstudent);
                Update();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count == 0) return;
            var student = listViewStudents.SelectedItems[0].Tag as Student;
            DataContext.Students.Remove(student);
            Update();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count == 0) return;
            var stud = listViewStudents.SelectedItems[0].Tag as Student;
            StudentAdd studentAdd1 = new StudentAdd();
            studentAdd1.Student = stud;
            studentAdd1.ShowDialog();
            Update();
        }
    }
}
