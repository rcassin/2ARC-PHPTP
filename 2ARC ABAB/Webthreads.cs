using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2ARC_ABAB
{
    class Webthreads
    {
    }
    class connectThread
    {
        public static async Task<connectThreadVar> asyncConnect(string Login, string Password) 
        {
            try
            {

            
            WebClient wc = new WebClient();

            NameValueCollection getout = new NameValueCollection();
            getout.Add("login", Login); getout.Add("passwd", Password);
            wc.QueryString = getout;
            Properties.Settings.Default.Save();

            var query = Properties.Settings.Default.Serveur + "connect.php";
            var brutjson = wc.DownloadString(query);
            var cookie = wc.ResponseHeaders["Set-Cookie"].Split(';')[0];
            var PHPSESSID = cookie.Split('=')[1];


            JObject connectInf = JObject.Parse(brutjson);
            return new connectThreadVar((bool)connectInf["result"], (int)connectInf["PROTOC_V"], Login, PHPSESSID, (string)connectInf["APP_NAME"]);
            } catch(Exception e) {
                Console.WriteLine("Erreur: ");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }

    class connectThreadVar
    {
        private bool _valid;
        private int _protocolV;
        private string _login;
        private string _PHPSESSID;
        private string _appname;

        public connectThreadVar(bool valid, int protocolV, string login, string PHPSESSID, string appname)
        {
            _valid      = valid;
            _protocolV  = protocolV;
            _login      = login;
            _PHPSESSID  = PHPSESSID;
            _appname    = appname;
        }

        public bool valid
        {
            get
            {
                return _valid;
            }
            set
            {
                _valid = value;
            }
        }
        public int protocolV
        {
            get
            {
                return _protocolV;
            }
            set
            {
                _protocolV = value;
            }
        }
        public string login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }
        public string PHPSESSID
        {
            get
            {
                return _PHPSESSID;
            }
            set
            {
                _PHPSESSID = value;
            }
        }
        public string appname
        {
            get
            {
                return _appname;
            }
            set
            {
                _appname = value;
            }
        }

    }

}
