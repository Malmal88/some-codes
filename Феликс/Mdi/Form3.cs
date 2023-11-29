using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mdi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void Updatemodels()
        {
            listView1.Items.Clear();
            foreach (Model model in DataContext.models)
            {
                listView1.Items.Add(new ListViewItem(new string[] { model.Name, model.Brand.Name }) { Tag = model });
            }
        }
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (DataContext.brands.Count == 0)
            {
                MessageBox.Show("В базе нет доступных брендов");
                return;
            }
            Form5 form5 = new Form5();
            form5.ShowDialog();
            if (form5.DialogResult == DialogResult.OK)
            {
                var newmodel = form5.Model;
                DataContext.models.Add(newmodel);
                Updatemodels();
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            var model = listView1.SelectedItems[0].Tag as Model;
            DialogResult = MessageBox.Show($"Удалить {model.Name}", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.No) return;
            DataContext.models.Remove(model);
            Updatemodels();
        }
    }
}
