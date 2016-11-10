namespace _2ARC_ABAB
{
    partial class preference
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(preference));
            this.SuspendLayout();
            // 
            // preference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 179);
            this.Icon = Properties.Resources.Iconeapp;
            this.Name = "preference";
            this.Text = "preference";
            this.Load += new System.EventHandler(this.preference_Load);
            this.SizeChanged += new System.EventHandler(this.preference_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}