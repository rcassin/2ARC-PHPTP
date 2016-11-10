using Newtonsoft.Json.Linq;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
       
            lostfoc(URL, new EventArgs());
            lostfoc(Login, new EventArgs());
            lostfoc(Password, new EventArgs());
                
            Color backco = Color.FromArgb(238, 238, 242);

            this.BackColor = backco;
            button1.BackColor = backco;

            panel1.BackColor = Color.Transparent;

            this.Focus();
        }

        private void click(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text == text.Name)
            {
                text.Text = "";
                text.ForeColor = Color.Black;
            }
        }

        private void lostfoc(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text == "")
            {
                text.Text = text.Name;
                text.ForeColor = Color.Gray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Launch"); Login.Text = "Login"; Login.ForeColor = Color.Gray;
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Blue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Valider_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Save();
            Valider.Text = "Processing...";
            Valider.Enabled = false;

            
            backgroundWorker1.RunWorkerAsync();
        }

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("CTV");
            Task<connectThreadVar> asyncConnectValue = connectThread.asyncConnect(Login.Text, Password.Text);
            connectThreadVar ctv = await asyncConnectValue;

            if (ctv == null) e.Cancel = true;
            e.Result = ctv;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            Console.WriteLine("Finish");
            if (!e.Cancelled)
            {
                connectThreadVar ctv = (connectThreadVar)e.Result;
                if (ctv.protocolV != Properties.Settings.Default.ProtocolV)
                    MessageBox.Show("Mauvaise version du protocol de Transfert (PHPTP):" +
                        " client=" + Properties.Settings.Default.ProtocolV +
                        " Serveur=" + ctv.protocolV +
                        "\r\n 003"
                        );


                if (ctv.valid)
                {
                    var main = new _2arc_abab();
                    main.Login = Login.Text;
                    main.Password = ctv.PHPSESSID;
                    main.AppName = ctv.appname;
                    main.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Identifiant(s) incorrect \r\n 002");
            }
            else
                MessageBox.Show("Annulation de la connection \r\n 001");

            Valider.Text = "Valider";
            Valider.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar s = (TrackBar) sender;
            if(Console.BufferWidth < s.Value)
            {
                Console.BufferWidth = s.Value;
                Console.WindowWidth = Console.BufferWidth;
            }
            else
            {
                Console.WindowWidth = s.Value;
                Console.BufferWidth = Console.WindowWidth;
            }
            
        }

        private void changepos(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HT_CAPTION = 0x2;
            if (e.Button == MouseButtons.Left)
            {
                DllImports.ReleaseCapture();
                DllImports.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
