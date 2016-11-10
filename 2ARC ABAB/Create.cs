using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2ARC_ABAB
{
    public partial class Create : Form
    {

        public string Login;
        public string Password;

        public string Dir;

        public Create()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                int isdir = comboBox1.SelectedIndex;
                var getout = new Dictionary<string, string>();
                getout["dir"] = isdir.ToString();
                getout["file"] = Dir + textBox1.Text;
                var result = Functions.webJson("create.php", Login, Password, getout);
                if((int)result["err"] == 1)
                {
                    MessageBox.Show("Erreur: " + (string)result["err_msg"]);
                }
                var main = new _2arc_abab();
                this.Close();

            }
        }

        private void Create_Load(object sender, EventArgs e)
        {
            label2.Text = Dir;
        }
    }
}
