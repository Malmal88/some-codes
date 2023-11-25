using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace телефонная_книга_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        List<Person> persons = new List<Person>();
        string filter=string.Empty;
       public void UpdateList()
        {
            listView1.Items.Clear();
            foreach (Person person in persons)
            {
                if (!person.Name.ToLower().Contains(filter)&&!person.Phone.ToLower().Contains(filter)) continue;
                listView1.Items.Add(new ListViewItem(new string[] { person.Name, person.Phone }) { Tag = person });
            }
            toolStripStatusLabel1.Text = ($"Shown {listView1.Items.Count} from {persons.Count}");
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var newPerson = form.person;
                persons.Add(newPerson);
                UpdateList();
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0) return;
            Form2 f = new Form2();
            f.person = listView1.Items[0].Tag as Person;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
                UpdateList();

        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0) { return; }
            var person = listView1.Items[0].Tag as Person;
            DialogResult = MessageBox.Show($"Удалить {person.Name}", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.No) return;
            persons.Remove(person);
            UpdateList();
        }

        private void toolStripButtonExp_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd= new SaveFileDialog();
            sfd.Filter = "Xml files(*.xml)|*.xml";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\"?>");
            sb.AppendLine("<root>");
            foreach (var p in persons)
            {
                sb.AppendLine($"<Person name=\"{p.Name}\" phone=\"{p.Phone}\"/>");
            }
            sb.AppendLine("</root>");
            File.WriteAllText(sfd.FileName, sb.ToString());
        }

        private void toolStripButtonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xml files(*.xml)|*.xml";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var doc = XDocument.Load(ofd.FileName);
            persons.Clear();
            foreach (var p in doc.Element("root").Elements("Person"))
            {
                var name = p.Attribute("name").Value;
                var phone=p.Attribute("phone").Value;
                persons.Add(new Person { Name = name, Phone = phone });
            }
            UpdateList();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filter = textBox1.Text.ToLower();
            UpdateList();
          
        }
       
    }
}
