namespace MDI_ученики
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonTeachers = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClasses = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStudents = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButtonTeachers,
            this.toolStripButtonClasses,
            this.toolStripButtonStudents});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton1.Text = "Файл";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripButtonTeachers
            // 
            this.toolStripButtonTeachers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTeachers.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTeachers.Image")));
            this.toolStripButtonTeachers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTeachers.Name = "toolStripButtonTeachers";
            this.toolStripButtonTeachers.Size = new System.Drawing.Size(56, 22);
            this.toolStripButtonTeachers.Text = "Учителя";
            this.toolStripButtonTeachers.Click += new System.EventHandler(this.toolStripButtonTeachers_Click);
            // 
            // toolStripButtonClasses
            // 
            this.toolStripButtonClasses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonClasses.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClasses.Image")));
            this.toolStripButtonClasses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClasses.Name = "toolStripButtonClasses";
            this.toolStripButtonClasses.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonClasses.Text = "Классы";
            this.toolStripButtonClasses.Click += new System.EventHandler(this.toolStripButtonClasses_Click);
            // 
            // toolStripButtonStudents
            // 
            this.toolStripButtonStudents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStudents.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStudents.Image")));
            this.toolStripButtonStudents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStudents.Name = "toolStripButtonStudents";
            this.toolStripButtonStudents.Size = new System.Drawing.Size(58, 22);
            this.toolStripButtonStudents.Text = "Ученики";
            this.toolStripButtonStudents.Click += new System.EventHandler(this.toolStripButtonStudents_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonClasses;
        private System.Windows.Forms.ToolStripButton toolStripButtonStudents;
        private System.Windows.Forms.ToolStripButton toolStripButtonTeachers;
    }
}

