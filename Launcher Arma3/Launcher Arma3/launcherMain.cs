using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Animation;
using MetroFramework.Components;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Diagnostics;
using System.IO;
using RestSharp;

namespace Launcher_Arma3
{
    public partial class launcherMain : MetroFramework.Forms.MetroForm
    {

        /* Launcher basic config */
        string apiUrl = "http://localhost/public/api/";   /* Link to API launcher Arma 3 */
        string webSite = "http://emodyz.com/";
        string serverName = "Emodyz";


        /* Variables globals */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        bool login = false;
        bool connected = false;
        bool internet;
        string news1;
        string news2;
        string news3;

        /* Session info */
        string sessionToken = null;
        string username = null;
        string email = null;
        string level = null;

        public launcherMain()
        {
            InitializeComponent();
        }

        private void launcherMain_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(appdata + serverName))
                Directory.CreateDirectory(appdata + serverName);
            if (File.Exists(appdata + serverName + "/token.bin2hex"))
                sessionToken = File.ReadAllText(appdata + serverName + "/token.bin2hex");
        }

        private void checkOptions(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("options", Method.GET);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());

                if (res.maintenance == "1")
                {
                    infoBox.Visible = true;
                    infoBox.Text = res.maintenance_msg;
                    pictureBig.ImageLocation = res.maintenance_image;
                    changeStatus("Orange");
                    return;
                }
                if (res.login == "1")
                {
                    login = true;
                    loginBox.Visible = true;
                    changeStatus("Red");
                }
                if (res.register == "1")
                {
                    registerLink.Visible = true;
                }
                if (res.news == "1")
                {
                    staffMessage.Text = res.news_msg;
                    staffMessage.Visible = true;
                }
                if (sessionToken != null)
                {
                    loginWithToken();
                }
                pictureBig.Visible = false;
                internet = true;
            }
            catch
            {
                errorBox.Visible = true;
                errorBox.Text = "Error #404: Internet or Serveur not found.";
                internet = false;
                pictureBig.Visible = false;
                changeStatus("Red");
            }

        }

        void loginWithToken()
        {
            var client = new RestClient(apiUrl);

            var request = new RestRequest("user/get", Method.POST);

            request.AddParameter("token", sessionToken);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            checkNotif();

            if (res.status == "42")
            {
                username = res.user.username;
                email = res.user.email;
                level = res.user.level;
                connected = true;
                loginBox.Visible = false;
                newsBox.Visible = true;
                succesBox.Visible = true;
                playerBox.Visible = true;
                succesBox.Text = res.msg;
                changeStatus("Green");
                loadNews();
                refreshSession();
            }
            else
            {
                errorBox.Visible = true;
                errorBox.Text = res.msg;
                if (File.Exists(appdata + serverName + "/token.bin2hex"))
                    File.Delete(appdata + serverName + "/token.bin2hex");
            }
        }

        void refreshSession()
        {
            connectedAs.Text = username;
            userEmailLabel.Text = email;
            switch (level)
            {
                case "0":
                    playerAdminLabel.Text = "Joueur";
                    playerAdminLabel.ForeColor = Color.BlueViolet;
                    break;
                case "1":
                    playerAdminLabel.Text = "Admin";
                    playerAdminLabel.ForeColor = Color.Red;
                    break;
                default:
                    playerAdminLabel.Text = "INCONNU";
                    playerAdminLabel.ForeColor = Color.OrangeRed;
                    break;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var client = new RestClient(apiUrl);

            var request = new RestRequest("user/login", Method.POST);

            request.AddParameter("username", loginUsername.Text);
            request.AddParameter("password", loginPassword.Text);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            checkNotif();

            if (res.status == "42")
            {
                username = res.user.username;
                email = res.user.email;
                level = res.user.level;
                sessionToken = res.user.token;
                connected = true;
                loginBox.Visible = false;
                newsBox.Visible = true;
                succesBox.Visible = true;
                playerBox.Visible = true;
                succesBox.Text = res.msg;
                changeStatus("Green");
                loadNews();
                refreshSession();
                if (loginRemember.Checked == true)
                {
                    string token = res.user.token;
                    File.WriteAllText(appdata + serverName + "/token.bin2hex", token);
                }
            }
            else
            {
                errorBox.Visible = true;
                errorBox.Text = res.msg;
            }

        }

        void checkNotif()
        {
            /* Ne me demandez pas pourquoi ça marche moi même je ne pige pas xD */
            if (errorBox.Visible == true)
                errorBox.Visible = false;
            if (infoBox.Visible == true)
                infoBox.Visible = false;
            if (succesBox.Visible == true)
                succesBox.Visible = false;
        }

        private void register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginBox.Visible = false;
            registerBox.Visible = true;
            changeStatus("Blue");
        }

        private void registerCancel_Click(object sender, EventArgs e)
        {
            loginBox.Visible = true;
            registerBox.Visible = false;
            changeStatus("Red");
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var client = new RestClient(apiUrl);

            var request = new RestRequest("user", Method.POST);

            request.AddParameter("launcher", 1);
            request.AddParameter("username", registerUsername.Text);
            request.AddParameter("email", registerEmail.Text);
            request.AddParameter("password", registerPass.Text);
            request.AddParameter("password_confirmation", registerPassConf.Text);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            checkNotif();

            if (res.status == "42")
            {
                succesBox.Visible = true;
                succesBox.Text = res.msg;
                registerBox.Visible = false;
                loginBox.Visible = true;
                changeStatus("Red");
                sessionToken = res.user.token;
                loginWithToken();
            }
            else
            {
                errorBox.Visible = true;
                errorBox.Text = res.msg;
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
            var client = new RestClient(apiUrl);

            var request = new RestRequest("news", Method.GET);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            if (res.total > "0")
            {
                newsLabel1.Text = res.news[0].title;
                newsDate1.Text = res.news[0].date;
                news1 = res.news[0].link;
            }
            if (res.total > "1")
            {
                newsLabel2.Text = res.news[1].title;
                newsDate2.Text = res.news[1].date;
                news2 = res.news[1].link;
            }
            if (res.total > "2")
            {
                newsLabel3.Text = res.news[2].title;
                newsDate3.Text = res.news[2].date;
                news3 = res.news[2].link;
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/token.bin2hex"))
                File.Delete(appdata + serverName + "/token.bin2hex");
            loginBox.Visible = true;
            loginPassword.Text = "0000";
            loginRemember.Checked = false;
            loginUsername.Text = "Username";
            newsBox.Visible = false;
            playerBox.Visible = false;
            checkNotif();
            succesBox.Visible = true;
            succesBox.Text = "Vous êtes bien déconnecter";
            connected = false;
            changeStatus("Red");
        }

        void changeStatus(string style)
        {
            switch (style)
            {
                case "Red":
                    this.Style = MetroColorStyle.Red;
                    break;
                case "Green":
                    this.Style = MetroColorStyle.Green;
                    break;
                case "Blue":
                    this.Style = MetroColorStyle.Blue;
                    break;
                case "Orange":
                    this.Style = MetroColorStyle.Orange;
                    break;
                default:
                    this.Style = MetroColorStyle.Teal;
                    break;
            }
            this.Refresh();
        }
    }
}