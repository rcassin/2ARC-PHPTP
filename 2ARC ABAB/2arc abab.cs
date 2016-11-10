using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace _2ARC_ABAB
{
    public partial class _2arc_abab : Form
    {
        public string Login = "";
        public string Password = "";
        public string AppName = "";
        public string PHPSESSID = "";

        private bool listWorkerWorking = false;
        string currentDirectory = "/";

        public void ls(string dirname)
        {
            this.Invoke(new Action(() => this.Cursor = Cursors.WaitCursor));
            currentDirectory = dirname;
            this.Invoke(new Action(() => label1.Text = currentDirectory));
            
            try
            {
                this.Invoke(new Action(() => DirGrid.Rows.Clear()));
                if (dirname != "/")
                {
                    int re =(int) this.Invoke(new Func<int>(() => DirGrid.Rows.Add("../", "", "", "", "", "", "")));
                    this.Invoke(new Action(() => DirGrid.Rows[re].ReadOnly = true)); ;
                }
                var getout = new Dictionary<string, string>();
                getout["dir"] = dirname;
                Console.WriteLine("Listing: " + dirname);
                JObject getFile = Functions.webJson("ls.php", Login, Password, getout);

                //dynamic data = System.Web.Helpers.Json.Decode(json);
                IList<JToken> dir = getFile["dir"].Children().ToList();
                IList<JToken> file = getFile["file"].Children().ToList();
                if (dir.Count != 0)
                    foreach (JToken data in dir)
                        addEntity(data, false);

                if (file.Count != 0)
                    foreach (JToken data in file)
                        addEntity(data, true);  
            }
            catch (Exception execp)
            {
                MessageBox.Show(execp.Message);
                
            }
            
        }

        void addEntity(JToken data, bool isFile)
        {
            var datastring = data.ToString();
            JObject dirinfo = JObject.Parse(datastring);
            var name = "";
            var type = "";
            var taille = "";
            var lastmod = "";
            var perm = "";
            var own = "";

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(int.Parse(dirinfo["lastmod"].ToString())).ToLocalTime();

            name = dirinfo["name"].ToString();
            type = dirinfo["type"].ToString();
            taille = dirinfo["size"].ToString();
            lastmod = dtDateTime.ToString();
            perm = dirinfo["perm"].ToString();
            own = dirinfo["owner"].ToString();
            Button butt = new Button();
            
            if (isFile)
                this.Invoke(new Action(() => DirGrid.Rows.Add(name, type, taille, lastmod, perm, own, "Download", "Supprimer", name)));
            else
            {
                int idrow = (int) this.Invoke(new Func<int>(() => DirGrid.Rows.Add(name, type, taille, lastmod, perm, own, "", "Supprimer", name)));
                this.Invoke(new Action(() => DirGrid.Rows[idrow].Cells["Nom"].Style.ForeColor = Color.Blue));
            }
        }

        public void download(string uri, string mime)
        {
            string ext = uri.Split('.')[uri.Split('.').Count() - 1];
            string name = uri.Split('/')[uri.Split('/').Count() - 1];
            WebClient wc = new WebClient();
            saveFileDialog1.FileName = name;
            saveFileDialog1.Filter = mime + "(*." + ext + ")|*." + ext + "|All|*.*";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                NameValueCollection getout = new NameValueCollection();
                getout.Add("login", Login); getout.Add("passwd", Password); getout.Add("file", uri);
                wc.QueryString = getout;
                wc.DownloadFile(Properties.Settings.Default.Serveur + "down.php", saveFileDialog1.FileName);
                ListWorker.RunWorkerAsync(currentDirectory);
            }

        }

        private void resizecol()
        {
            DirGrid.Size = new Size(this.Size.Width - 40, this.Size.Height - 92);
            var colsize = (DirGrid.Size.Width / (DirGrid.ColumnCount - 1) - 80);
            for (int i = 0; i <= DirGrid.ColumnCount - 1; i++)
            {
                if (DirGrid.Columns[i].Name == "Nom") { DirGrid.Columns[i].Width = colsize + 70 * DirGrid.ColumnCount; }
                else if (DirGrid.Columns[i].Name == "originalname") { DirGrid.Columns[i].Width = 0; }
                else { DirGrid.Columns[i].Width = colsize; }
            }
            
        }
        private void chgButton()
        {
            //1159
            button1.Location = new Point(this.Size.Width - 103, button1.Location.Y);
            button2.Location = new Point(this.Size.Width - 240, button1.Location.Y);
            button4.Location = new Point(this.Size.Width - 323, button1.Location.Y);
        }
        private void cellInteract(DataGridView row)
        {
            this.Focus();
            if (row.CurrentRow.Cells["type"].Value.ToString() == "dir")
            {
                ListWorker.RunWorkerAsync(currentDirectory + row.CurrentRow.Cells["Nom"].Value.ToString());
            }
            else if (row.CurrentRow.Cells["Nom"].Value.ToString() == "../")
            {
                var result = "/";
                for (int i = 1; i < currentDirectory.Split('/').Count() - 2; i++)
                {
                    result += currentDirectory.Split('/')[i] + "/";
                }
                ls(result);
            }
            else
            {

                var getout = new Dictionary<string, string>();
                getout["file"] = currentDirectory + row.CurrentRow.Cells["Nom"].Value.ToString();
                var doc = Functions.webString("down.php", Login, Password, getout);

                var editor = new Editor();
                editor.mime = row.CurrentRow.Cells["Type"].Value.ToString();
                editor.Login = Login;
                editor.Password = Password;
                editor.data = doc;
                editor.file = currentDirectory + row.CurrentRow.Cells["Nom"].Value.ToString();
                editor.Show();
            }
        }
        private void rename(string original, string newname)
        {
            using (WebClient wc = new WebClient())
            {
                var getout = new Dictionary<string, string>();
                getout["dir"] = original;
                var result = Functions.webJson("rename.php", Login, Password, getout);
                if((int)result["err"] == 1)
                {
                    MessageBox.Show("Erreur: " + (string)result["err_msg"]);
                }
                ls(currentDirectory);
            }
        }

        
        public _2arc_abab() { InitializeComponent(); }

        private void _2arc_abab_Load(object sender, EventArgs e)
        {
            this.Text = AppName;
            Console.Title = "PHPTP - " + AppName;
            resizecol();
            ListWorker.RunWorkerAsync("/");
            chgButton();
            DirGrid.DragDrop += new DragEventHandler(DragFile);
            var size = button1.Size.Width + button2.Size.Width + button3.Size.Width + label1.Size.Width + 70;
            this.MinimumSize = new Size(size, 15);
        }
        private void _2arc_abab_FormClosed(object sender, FormClosedEventArgs e)
        {
            var main = new Form1();
            main.Close();
            Application.Exit();
        }
        private void _2arc_abab_SizeChanged(object sender, EventArgs e) { resizecol(); chgButton(); }

        private void button1_Click(object sender, EventArgs e)
        {
            ListWorker.RunWorkerAsync(currentDirectory);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var createbox = new Create();
            createbox.Login = Login;
            createbox.Password = Password;
            createbox.Dir = currentDirectory;
            createbox.Show();
            ListWorker.RunWorkerAsync(currentDirectory);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var connect = new Form1();
            connect.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //var pref = new preference();
            //pref.Show();
            MessageBox.Show("Pas encore implémenté", "PHPTP", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void DirGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //e.RowIndex + 1
            //e.ColumnIndex + 1
           try
            { 
                if(e.ColumnIndex == 6 && DirGrid.Rows[e.RowIndex].Cells["type"].Value.ToString() != "dir")
                {
                    download(currentDirectory + DirGrid.Rows[e.RowIndex].Cells["Nom"].Value.ToString(), DirGrid.Rows[e.RowIndex].Cells["Type"].Value.ToString());
                }
                else if(e.ColumnIndex == 7)
                {
                    var getout = new Dictionary<string, string>();
                    getout["dir"] = currentDirectory + DirGrid.Rows[e.RowIndex].Cells["Nom"].Value.ToString();
                    var query = Functions.webJson("remove.php", Login, Password, getout);
                    var iserr = (int)query["err"];
                    if(iserr == 1)
                    {
                        MessageBox.Show("Error: " + (string)query["err_msg"]);
                    }
                    ListWorker.RunWorkerAsync(currentDirectory);
                }
           }
            catch (Exception execp)
            {
                MessageBox.Show(execp.Message);
            }
        }
        private void DirGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var name = DirGrid.Rows[e.RowIndex].Cells["originalname"].Value;
            var org = DirGrid.Rows[e.RowIndex].Cells["Nom"].Value;
            if (name != org) rename(currentDirectory + name, (string)org);
        }
        private void DirGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) { cellInteract((DataGridView)sender); }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            var hittestInfo = DirGrid.HitTest(e.X, e.Y);

            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
            {
                valueFromMouseDown = DirGrid.Rows[hittestInfo.RowIndex].Cells[hittestInfo.ColumnIndex].Value;
                if (valueFromMouseDown != null)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void DirGrid_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if(!allowdrag)
            {
                e.Action = DragAction.Cancel;
                allowdrag = true;
                return;
            }
            e.Action = DragAction.Continue;
        }

        private bool allowdrag = true;

        private void DragFile(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            using (WebClient wc = new WebClient())
            {
                NameValueCollection getout = new NameValueCollection();
                var splitfile = files[0].Split('\\')[files[0].Split('\\').Count() - 1];
                getout.Add("login", Login); getout.Add("passwd", Password); getout.Add("dir", currentDirectory);
                wc.Headers["Cookie"] = "PHPSESSID=" + Password;
                wc.QueryString = getout;
                byte[] reply = {  };
                try
                {
                    reply = wc.UploadFile(Properties.Settings.Default.Serveur + "sendfile.php", "POST", files[0]);
                } catch(Exception k)
                {
                    MessageBox.Show("Erreur lors de l'envoi");
                    Console.WriteLine("Erreur dans l'utilitaire d'envoi:");
                    Console.Write("Message:");
                    Console.WriteLine(k.Message);
                }
                
                string result = System.Text.Encoding.UTF8.GetString(reply);
                if (listWorkerWorking)
                    ListWorker.CancelAsync();

                try
                {
                    ListWorker.RunWorkerAsync(currentDirectory);
                }
                catch (Exception k)
                {
                    Console.WriteLine("Petite Erreur dans le listage au niveau de l'utilitaire d'envoi");
                }
                    
            }


        }
        private void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private Rectangle dragBoxFromMouseDown;
        private object valueFromMouseDown;
        private void DirGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = DirGrid.DoDragDrop(valueFromMouseDown, DragDropEffects.Copy);
                }
            }
        }

        private void ListWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Console.WriteLine("Listing BGW...");
            listWorkerWorking = true;
            ls((string)e.Argument);
            this.Invoke(new Action(() => this.Cursor = Cursors.Default));
        }
        private void ListWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new Action(() => this.Cursor = Cursors.Default));
            Console.WriteLine("BGW finished");
            listWorkerWorking = false;
        }
    }
    class Functions
    {
        public static JObject webJson(string url, string Login, string PHPSESSID, Dictionary<string, string> args)
        {
            WebClient wc = new WebClient();
            
            NameValueCollection getout = new NameValueCollection();
            getout.Add("login", Login); getout.Add("passwd", "");
            Console.WriteLine("Request: " + url.Split('.')[url.Split('.').Count() - 2]);
            Console.Write("Login: " + Login); Console.Write(" PHPSESSID: " + PHPSESSID); Console.WriteLine();
            foreach (KeyValuePair<string, string> arg in args)
            {
                getout.Add(arg.Key, arg.Value);
            }
            wc.QueryString = getout;
            wc.Headers["Cookie"] = "PHPSESSID=" + PHPSESSID;
            Properties.Settings.Default.Save();

            var query = Properties.Settings.Default.Serveur + url;
            var brutjson = wc.DownloadString(query);
            //cookie.; PHPSESSID
            return JObject.Parse(brutjson);
        }


        public static string webString(string url, string Login, string PHPSESSID, Dictionary<string, string> args)
        {
            WebClient wc = new WebClient();

            NameValueCollection getout = new NameValueCollection();
            Console.WriteLine("Request: " + url.Split('.')[url.Split('.').Count() - 2]);
            Console.Write("Login: " + Login); Console.Write(" PHPSESSID: " + PHPSESSID); Console.WriteLine();
            getout.Add("login", Login); getout.Add("passwd", ""); 
            foreach (KeyValuePair<string, string> arg in args)
            {
                getout.Add(arg.Key, arg.Value);
            }
            wc.QueryString = getout;
            wc.Headers["Cookie"] = "PHPSESSID=" + PHPSESSID;
            Properties.Settings.Default.Save();

            var query = Properties.Settings.Default.Serveur + url;
            var brutjson = wc.DownloadString(query);
            //cookie.; PHPSESSID
            return brutjson;
        }
    }
}
