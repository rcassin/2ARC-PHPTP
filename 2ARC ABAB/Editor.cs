using ScintillaNET;
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
    public partial class Editor : Form
    {
        public string Login;
        public string Password;

        public string data;
        public string file;
        public string mime;
        private int maxLineNumberCharLength;
        public Editor()
        {
            InitializeComponent();
            
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            var ext = file.Split('.')[file.Split('.').Count() - 1];
            if (ext == "html" || ext == "htm" || mime == "text/html" ) setHTML();
            else if (ext == "php") setPHP();
            else if(ext == "css") setCSS();
            folding();


            textBox1.Margins[0].Width = 16;
            textBox1.Text = data;
            this.Text = "Editor - " + file;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var nbet = this.Text.Split('*').Count();
            if (nbet <= 1)
            {
                this.Text = this.Text + " *";
            }
            
        }

        private void enregisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            download();
        }

        private void download()
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Request: Upload");
                Console.Write("Login: " + Login); Console.Write(" PHPSESSID: " + Password); Console.Write(" File: " + file); Console.WriteLine();
                NameValueCollection getout = new NameValueCollection();
                getout.Add("login", Login); getout.Add("passwd", Password); getout.Add("file", file);
                wc.Headers["Cookie"] = "PHPSESSID=" + Password;
                wc.QueryString = getout;
                byte[] reply = wc.UploadValues(Properties.Settings.Default.Serveur + "send.php", new NameValueCollection()
                {
                    { "file",textBox1.Text }
                });
                Console.WriteLine("Bytes sended: " + Encoding.ASCII.GetByteCount(textBox1.Text));
                //Console.WriteLine("Reply: " + Encoding.ASCII.GetString(reply));
                string result = System.Text.Encoding.UTF8.GetString(reply);
                this.Text = this.Text.Split('*')[0];
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void téléchargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _2arc_abab form = new _2arc_abab();
            form.download(file, mime);
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Editor_Resize(object sender, EventArgs e)
        {
            textBox1.Size = new Size(this.Size.Width - 40, this.Size.Height - 79);
        }
        private void setHTML()
        {
            textBox1.Styles[Style.Html.Default].ForeColor = Color.Blue;
            textBox1.Styles[Style.Html.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            textBox1.Styles[Style.Html.Number].ForeColor = Color.Olive;
            textBox1.Styles[Style.Html.Tag].ForeColor = Color.Red;
            textBox1.Styles[Style.Html.DoubleString].ForeColor = Color.Green;
            textBox1.Lexer = Lexer.Html;
        }
        private void setPHP()
        {
            textBox1.Styles[Style.PhpScript.Default].ForeColor = Color.Blue;
            textBox1.Styles[Style.PhpScript.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            textBox1.Styles[Style.PhpScript.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            textBox1.Styles[Style.PhpScript.Number].ForeColor = Color.Olive;
            textBox1.Styles[Style.PhpScript.Word].ForeColor = Color.Blue;
            textBox1.Styles[Style.PhpScript.Operator].ForeColor = Color.Purple;
            textBox1.Styles[Style.PhpScript.SimpleString].ForeColor = Color.Red;
            textBox1.Styles[Style.PhpScript.HStringVariable].ForeColor = Color.Red;
            textBox1.Styles[Style.PhpScript.HString].ForeColor = Color.Red;
            textBox1.Lexer = Lexer.PhpScript;
        }

        private void setCSS()
        {
            textBox1.Styles[Style.Css.Default].ForeColor = Color.Blue;
            textBox1.Styles[Style.Css.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            textBox1.Styles[Style.Css.Tag].ForeColor = Color.Red;
            textBox1.Styles[Style.Css.DoubleString].ForeColor = Color.Green;
            textBox1.Styles[Style.Css.Attribute].ForeColor = Color.Orange;
            textBox1.Styles[Style.Css.Class].ForeColor = Color.Red;
            textBox1.Styles[Style.Css.Id].ForeColor = Color.Red;
            textBox1.Styles[Style.Css.Value].ForeColor = Color.Green;
            textBox1.Styles[Style.Css.Media].ForeColor = Color.Turquoise;
            textBox1.Styles[Style.Css.Important].ForeColor = Color.Salmon;
            textBox1.Lexer = Lexer.Css;
        }

        private void chercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Indicators 0-7 could be in use by a lexer
            // so we'll use indicator 8 to highlight words.
            const int NUM = 8;
            var text = Microsoft.VisualBasic.Interaction.InputBox(" ", "Rechercher");
            if (text == "") return;
            // Remove all uses of our indicator
            textBox1.IndicatorCurrent = NUM;
            textBox1.IndicatorClearRange(0, textBox1.TextLength);

            // Update indicator appearance
            textBox1.Indicators[NUM].Style = IndicatorStyle.StraightBox;
            textBox1.Indicators[NUM].Under = true;
            textBox1.Indicators[NUM].ForeColor = Color.Green;
            textBox1.Indicators[NUM].OutlineAlpha = 50;
            textBox1.Indicators[NUM].Alpha = 30;

            // Search the document
            textBox1.TargetStart = 0;
            textBox1.TargetEnd = textBox1.TextLength;
            textBox1.SearchFlags = SearchFlags.None;
            while (textBox1.SearchInTarget(text) != -1)
            {
                // Mark the search results with the current indicator
                textBox1.IndicatorFillRange(textBox1.TargetStart, textBox1.TargetEnd - textBox1.TargetStart);

                // Search the remainder of the document
                textBox1.TargetStart = textBox1.TargetEnd;
                textBox1.TargetEnd = textBox1.TextLength;
            }
        }
        private void folding()
        {
            // Instruct the lexer to calculate folding
            textBox1.SetProperty("fold", "1");
            textBox1.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            textBox1.Margins[2].Type = MarginType.Symbol;
            textBox1.Margins[2].Mask = Marker.MaskFolders;
            textBox1.Margins[2].Sensitive = true;
            textBox1.Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                textBox1.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                textBox1.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            textBox1.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            textBox1.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            textBox1.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            textBox1.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            textBox1.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            textBox1.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            textBox1.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            textBox1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = textBox1.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            textBox1.Margins[0].Width = textBox1.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;
        }
    }
}
