using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MDI_ученики
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButtonClasses_Click(object sender, EventArgs e)
        {
            
            Form classes = new Classes();
            foreach (var f in MdiChildren)
            {
                if (f is Classes) { f.Activate(); return; };
            }
            classes.MdiParent = this;
            classes.Show();
        }

        private void toolStripButtonStudents_Click(object sender, EventArgs e)
        {
            Form students = new Students();
            foreach (var f in MdiChildren)
            {
                if (f is Students) { f.Activate(); return; };
            }
            students.MdiParent = this;
            students.Show();
        }

        private void toolStripButtonTeachers_Click(object sender, EventArgs e)
        {
            Form teachers = new Teachers();
            foreach (var f in MdiChildren)
            {
                if (f is Teachers) { f.Activate(); return; };
            }
            teachers.MdiParent = this;
            teachers.Show();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Xml files(*xml}|*.xml";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("<root>");
            sb.AppendLine("<Teachers>");
            foreach (Teacher t in DataContext.Teachers)
            {
                sb.AppendLine($"<Teacher surname=\"{t.Surname}\" name=\"{t.Name}\" secondname=\"{t.Otchestvo}\" id=\"{t.id}\"/>");
            }
            sb.AppendLine("</Teachers>");


            sb.AppendLine("<Classes>");

            foreach (Class cl in DataContext.Classes)
            {
                sb.AppendLine($"<Class name =\"{cl.Name}\" id=\"{cl.id}\" teacherid =\"{cl.Teacher.id}\"/>");
            }
            sb.AppendLine("</Classes>");

            sb.AppendLine("<Students>");
            foreach(Student student in DataContext.Students)
            {
                sb.AppendLine($"<Student surname=\"{student.Surname}\" name=\"{student.Name}\" secondname =\"{student.Otchestvo}\" birthday=\"{student.birthday.ToShortDateString()}\" classid=\"{student.Class.id}\"/>");
            }
            sb.AppendLine("</Students>");
            sb.AppendLine("</root>");
            File.WriteAllText(sfd.FileName, sb.ToString());
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xml filees(*xml)|*.xml";
            if(ofd.ShowDialog() != DialogResult.OK) { return; }
            var doc =XDocument.Load(ofd.FileName);
            DataContext.Teachers.Clear();
            DataContext.Students.Clear();
            DataContext.Classes.Clear();
            foreach (var t in doc.Element("root").Elements("Teachers").Elements("Teacher"))
            {
               var name=t.Attribute("name").Value;
                var surname = t.Attribute("surname").Value;
                var secname = t.Attribute("secondname").Value;
                var id = t.Attribute("id").Value;
                DataContext.Teachers.Add(new Teacher() { Name = name, Surname = surname, Otchestvo = secname, id = int.Parse(id) });
                DataContext.counter++;
            }
            foreach(var cl in doc.Element("root").Elements("Classes").Elements("Class"))
            {
                var clname=cl.Attribute("name").Value.Trim();
                var clid=int.Parse(cl.Attribute("id").Value);
                var tid=int.Parse(cl.Attribute("teacherid").Value.Trim());
                var teach=DataContext.Teachers.First(x => x.id==tid);
                DataContext.Classes.Add(new Class() { Name = clname,id=clid, Teacher = teach });
                DataContext.counter++;
            }
            foreach(var st in doc.Element("root").Elements("Students").Elements("Student"))
            {
                var name=st.Attribute("name").Value.Trim();
                var sname = st.Attribute("surname").Value.Trim();
                var secname = st.Attribute("secondname").Value.Trim();
                var birthday = DateTime.Parse( st.Attribute("birthday").Value);
                var clid = int.Parse(st.Attribute("classid").Value);
                var classs=DataContext.Classes.First(x => x.id==clid);
                DataContext.Students.Add(new Student() { Name = name, Surname = sname, Otchestvo = secname, birthday = birthday, Class = classs });
            }
            Teachers teachers = new Teachers();
            teachers.MdiParent = this;
            teachers.Update();
            teachers.Show();
            Classes classes = new Classes();
            classes.MdiParent = this;
            classes.Update();
            classes.Show();
            Students students = new Students();
            students.MdiParent = this;
            students.Update();
            students.Show();
        }
    }
}
