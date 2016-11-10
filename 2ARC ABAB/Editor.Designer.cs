namespace _2ARC_ABAB
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.enregisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.téléchargerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new ScintillaNET.Scintilla();
            this.chercherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregisterToolStripMenuItem,
            this.téléchargerToolStripMenuItem,
            this.chercherToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(55, 22);
            this.toolStripDropDownButton1.Text = "Fichier";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // enregisterToolStripMenuItem
            // 
            this.enregisterToolStripMenuItem.Name = "enregisterToolStripMenuItem";
            this.enregisterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.enregisterToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.enregisterToolStripMenuItem.Text = "Enregister";
            this.enregisterToolStripMenuItem.Click += new System.EventHandler(this.enregisterToolStripMenuItem_Click);
            // 
            // téléchargerToolStripMenuItem
            // 
            this.téléchargerToolStripMenuItem.Name = "téléchargerToolStripMenuItem";
            this.téléchargerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.téléchargerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.téléchargerToolStripMenuItem.Text = "Télécharger";
            this.téléchargerToolStripMenuItem.Click += new System.EventHandler(this.téléchargerToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(894, 437);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "scintilla1";
            this.textBox1.UseTabs = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // chercherToolStripMenuItem
            // 
            this.chercherToolStripMenuItem.Name = "chercherToolStripMenuItem";
            this.chercherToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.chercherToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.chercherToolStripMenuItem.Text = "Chercher";
            this.chercherToolStripMenuItem.Click += new System.EventHandler(this.chercherToolStripMenuItem_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 477);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = Properties.Resources.Iconeapp;
            this.Name = "Editor";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.Resize += new System.EventHandler(this.Editor_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem enregisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem téléchargerToolStripMenuItem;
        private ScintillaNET.Scintilla textBox1;
        private System.Windows.Forms.ToolStripMenuItem chercherToolStripMenuItem;
    }
}