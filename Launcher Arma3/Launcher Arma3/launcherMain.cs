using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Animation;
using MetroFramework.Components;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Diagnostics;

namespace Launcher_Arma3
{
    public partial class launcherMain : MetroFramework.Forms.MetroForm
    {

        /* Launcher basic config */
        string apiUrl = "http://localhost/API/";   /* Link to API launcher Arma 3 */
        string webSite = "http://emodyz.com/";


        /* Variables globals */

        bool login = false;
        bool connected = false;
        bool internet;
        string news1;
        string news2;
        string news3;

        public launcherMain()
        {
            InitializeComponent();
        }

        private void launcherMain_Load(object sender, EventArgs e)
        {

        }

        private void checkOptions(object sender, EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {

                    byte[] response =
                    client.UploadValues(apiUrl + "options.php", new NameValueCollection());
                    string result = System.Text.Encoding.UTF8.GetString(response);
                    dynamic stuff = JObject.Parse(result);

                    if (stuff.maintenance == "1")
                    {
                        infoBox.Visible = true;
                        infoBox.Text = stuff.maintenance_msg;
                        pictureBig.ImageLocation = stuff.maintenance_image;
                        this.Style = "Orange";
                        return;
                    }
                    if (stuff.login == "1")
                    {
                        login = true;
                        loginBox.Visible = true;
                        this.Style = "Red";
                    }
                    if (stuff.register == "1")
                    {                        
                        registerLink.Visible = true;           
                    }
                    if (stuff.news == "1")
                    {
                        staffMessage.Text = stuff.news_msg;
                        staffMessage.Visible = true;
                    }
                    pictureBig.Visible = false;
                    internet = true;
                }
            }
            catch
            {
                errorBox.Visible = true;
                errorBox.Text = "Error #404: Internet or Serveur not found.";
                internet = false;
                pictureBig.Visible = false;
                this.Style = "Red";
            }

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                byte[] response =
                client.UploadValues(apiUrl + "login.php", new NameValueCollection()
                {
                    { "login", loginUsername.Text},
                    { "password", loginPassword.Text}
                });

                string result = System.Text.Encoding.UTF8.GetString(response);
                dynamic stuff = JObject.Parse(result);

                checkNotif();

                if (stuff.status == "42")
                {
                    errorBox.Visible = false;
                    loginBox.Visible = false;
                    newsBox.Visible = true;
                    succesBox.Visible = true;
                    succesBox.Text = stuff.msg;                   
                    this.Style = "Green";
                    loadNews();
                }
                else
                {
                    errorBox.Visible = true;
                    errorBox.Text = stuff.msg;
                }
            }
        }

        void checkNotif()
        {
            /* Ne me demandez pas pourquoi ça marche moi même je ne pige pas xD */
            if (errorBox.Visible == false)
                errorBox.Visible = false;
            if (infoBox.Visible == false)
                infoBox.Visible = false;
            if (succesBox.Visible == false)
                succesBox.Visible = false;
        }

        private void register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginBox.Visible = false;
            registerBox.Visible = true;
            this.Style = "Blue";
        }

        private void registerCancel_Click(object sender, EventArgs e)
        {
            loginBox.Visible = true;
            registerBox.Visible = false;
            this.Style = "Red";
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                byte[] response =
                client.UploadValues(apiUrl + "register.php", new NameValueCollection()
                {
                    { "username", registerUsername.Text},
                    { "email", registerEmail.Text},
                    { "password_conf", registerPassConf.Text},
                    { "password", registerPass.Text}
                });

                string result = System.Text.Encoding.UTF8.GetString(response);
                dynamic stuff = JObject.Parse(result);

                checkNotif();

                if (stuff.status == "42")
                {
                    succesBox.Visible = true;
                    succesBox.Text = stuff.msg;
                    registerBox.Visible = false;
                    loginBox.Visible = true;                 
                    this.Style = "Red";
                }
                else
                {
                    errorBox.Visible = true;
                    errorBox.Text = stuff.msg;
                }
            }
        }

        private void newsLink1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            if (news1 == null)
                p.StartInfo.FileName = webSite;
            else
                p.StartInfo.FileName = news1;
            p.Start();
        }

        private void newsLink2_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            if (news2 == null)
                p.StartInfo.FileName = webSite;
            else
                p.StartInfo.FileName = news2;
            p.Start();
        }

        private void newsLink3_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            if (news3 == null)
                p.StartInfo.FileName = webSite;
            else
                p.StartInfo.FileName = news3;
            p.Start();
        }

        void loadNews()
        {
            using (WebClient client = new WebClient())
            {

                byte[] response =
                client.UploadValues(apiUrl + "news.php", new NameValueCollection());
                string result = System.Text.Encoding.UTF8.GetString(response);
                dynamic stuff = JObject.Parse(result);

                if (stuff.total > "0")
                {
                    newsLabel1.Text = stuff.news0.title;
                    newsDate1.Text = stuff.news0.date;
                    news1 = stuff.news0.link;
                }
                if (stuff.total > "1")
                {
                    newsLabel2.Text = stuff.news1.title;
                    newsDate2.Text = stuff.news1.date;
                    news2 = stuff.news1.link;
                }
                if (stuff.total > "2")
                {
                    newsLabel3.Text = stuff.news2.title;
                    newsDate3.Text = stuff.news2.date;
                    news3 = stuff.news2.link;
                }
                
            }
        }
    }
}