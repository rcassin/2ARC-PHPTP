using System.Windows.Forms;

namespace _2ARC_ABAB
{
    partial class _2arc_abab
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
            this.DirGrid = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastmod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telecharger = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Supprimer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.originalname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ListWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.DirGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DirGrid
            // 
            this.DirGrid.AllowDrop = true;
            this.DirGrid.AllowUserToAddRows = false;
            this.DirGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DirGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DirGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.type,
            this.size,
            this.lastmod,
            this.perm,
            this.Owner,
            this.Telecharger,
            this.Supprimer,
            this.originalname});
            this.DirGrid.Location = new System.Drawing.Point(12, 41);
            this.DirGrid.MultiSelect = false;
            this.DirGrid.Name = "DirGrid";
            this.DirGrid.RowHeadersVisible = false;
            this.DirGrid.Size = new System.Drawing.Size(1119, 560);
            this.DirGrid.TabIndex = 1;
            this.DirGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DirGrid_CellClick);
            this.DirGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DirGrid_CellContentDoubleClick);
            this.DirGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DirGrid_CellValueChanged);
            this.DirGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragFile);
            this.DirGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            this.DirGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.DirGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DirGrid_MouseMove);
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // size
            // 
            this.size.HeaderText = "Taille";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // lastmod
            // 
            this.lastmod.HeaderText = "Derniere Modif.";
            this.lastmod.Name = "lastmod";
            this.lastmod.ReadOnly = true;
            // 
            // perm
            // 
            this.perm.HeaderText = "Permission";
            this.perm.Name = "perm";
            this.perm.ReadOnly = true;
            // 
            // Owner
            // 
            this.Owner.HeaderText = "Owner";
            this.Owner.Name = "Owner";
            this.Owner.ReadOnly = true;
            // 
            // Telecharger
            // 
            this.Telecharger.HeaderText = "Telecharger";
            this.Telecharger.Name = "Telecharger";
            this.Telecharger.ReadOnly = true;
            this.Telecharger.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Telecharger.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Supprimer
            // 
            this.Supprimer.HeaderText = "Supprimer";
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.ReadOnly = true;
            this.Supprimer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Supprimer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // originalname
            // 
            this.originalname.HeaderText = "originalname";
            this.originalname.Name = "originalname";
            this.originalname.ReadOnly = true;
            this.originalname.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1056, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(917, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Créer un Fichier/Dossier";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(12, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Deconnexion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(836, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Preference";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ListWorker
            // 
            this.ListWorker.WorkerSupportsCancellation = true;
            this.ListWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ListWorker_DoWork);
            this.ListWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ListWorker_RunWorkerCompleted);
            // 
            // _2arc_abab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 613);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DirGrid);
            this.Icon = global::_2ARC_ABAB.Properties.Resources.Iconeapp;
            this.Name = "_2arc_abab";
            this.Text = "2ARC ABAB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this._2arc_abab_FormClosed);
            this.Load += new System.EventHandler(this._2arc_abab_Load);
            this.SizeChanged += new System.EventHandler(this._2arc_abab_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DirGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DirGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastmod;
        private System.Windows.Forms.DataGridViewTextBoxColumn perm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewButtonColumn Telecharger;
        private System.Windows.Forms.DataGridViewButtonColumn Supprimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalname;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker ListWorker;
    }
}