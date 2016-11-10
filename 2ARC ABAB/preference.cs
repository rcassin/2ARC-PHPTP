using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2ARC_ABAB
{
    public partial class preference : Form
    {
        public preference()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void preference_Load(object sender, EventArgs e)
        {
            resize();
            //listView1.Items.Add("qzdqzdqzd", "C:test.exe");
        }

        private void preference_SizeChanged(object sender, EventArgs e)
        {
            resize();
        }
        private void resize()
        {
            /*listView1.Width = this.Width - 40;
            int colsize = listView1.Size.Width / listView1.Columns.Count;
            for (int i = 0; i <= listView1.Columns.Count - 1; i++)
            {
                listView1.Columns[i].Width = colsize;
            }*/
        }
    }
}
