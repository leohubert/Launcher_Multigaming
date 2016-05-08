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
using System.Reflection;
using System.Xml;


namespace LauncherArma3
{
    public partial class launcherMain : MetroFramework.Forms.MetroForm
    { 

        /* Launcher basic config */
        string apiUrl;
        string webSite;
        string serverName;


        /* Variables globals */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        bool connected = false;
        bool internet;
        string news1;
        string news2;
        string news3;
        bool showLogin = false;
        bool showRegister = false;
        string language;

        /* Session info */
        string sessionToken = null;
        string username = null;
        string email = null;
        string level = null;

        /* GENERAL TRANSLATE */
    
        string tr_username;
        string tr_email;
        string tr_disconnectMsg;

        public launcherMain(string server, string api, string website)
        {
            InitializeComponent();
            serverName = server;
            apiUrl = api;
            webSite = website;
        }

        private void launcherMain_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(appdata + serverName))
                Directory.CreateDirectory(appdata + serverName);
            if (File.Exists(appdata + serverName + "/token.bin2hex"))
                sessionToken = File.ReadAllText(appdata + serverName + "/token.bin2hex");
            if (File.Exists(appdata + serverName + "/language.lang"))
            {
                language = File.ReadAllText(appdata + serverName + "/language.lang");
                setLanguage(language);
            }
        }

        private void checkOptions(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/options", Method.GET);

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
                    changeStatus("Red");
                    showLogin = true;
                    disconnectedView();
                }
                else
                {
                    connected = true;
                    disconnectButton.Enabled = false;
                    loggedView();
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

            var request = new RestRequest("api/user/get", Method.POST);

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
                succesBox.Visible = true;
                succesBox.Text = res.msg;
                changeStatus("Green");
                loadNews();
                refreshSession();
                loggedView();
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
            playerUsername.Text = username;
            playerEmail.Text = email;
            switch (level)
            {
                case "0":
                    playerStatus.Text = "Joueur";
                    playerStatus.ForeColor = Color.BlueViolet;
                    break;
                case "1":
                    playerStatus.Text = "Admin";
                    playerStatus.ForeColor = Color.Red;
                    break;
                default:
                    playerStatus.Text = "INCONNU";
                    playerStatus.ForeColor = Color.OrangeRed;
                    break;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var client = new RestClient(apiUrl);

            var request = new RestRequest("api/user/login", Method.POST);

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
                succesBox.Visible = true;
                succesBox.Text = res.msg;
                changeStatus("Green");
                loadNews();
                refreshSession();
                loggedView();
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
            if (errorBox.Visible == true)
                errorBox.Visible = false;
            if (infoBox.Visible == true)
                infoBox.Visible = false;
            if (succesBox.Visible == true)
                succesBox.Visible = false;
            this.Refresh();
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

            var request = new RestRequest("api/user", Method.POST);

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
                sessionToken = res.user.token;
                changeStatus("Red");
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

            var request = new RestRequest("api/news", Method.GET);

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

        void disconnectedView()
        {
            newsBox.Visible = false;
            playerBox.Visible = false;
            if (showLogin == true)
                loginBox.Visible = true;
        }

        void loggedView()
        {
            newsBox.Visible = true;
            playerBox.Visible = true;
            loginBox.Visible = false;
            registerBox.Visible = false;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/token.bin2hex"))
                File.Delete(appdata + serverName + "/token.bin2hex");
            loginPassword.Text = "0000";
            loginRemember.Checked = false;
            loginUsername.Text = tr_username;
            registerEmail.Text = tr_email;
            registerUsername.Text = tr_username;
            checkNotif();
            succesBox.Visible = true;
            succesBox.Text = tr_disconnectMsg;
            connected = false;
            changeStatus("Red");
            disconnectedView();
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

        void setLanguage(string language)
        {
            try
            {
                string tmp;
                string translateFile = Properties.Resources.translate;
                XmlReader translate = XmlReader.Create(new StringReader(translateFile));

                translate.ReadToFollowing(language);
                translate.ReadToFollowing("logIn");
                loginButton.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("logOut");
                disconnectButton.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("remember");
                loginRememberLabel.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("loginMsg");
                loginLabel.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("registerLink");
                registerLink.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("commingSoon");
                tmp = translate.ReadElementContentAsString();
                newsLabel1.Text = tmp;
                newsLabel2.Text = tmp;
                newsLabel3.Text = tmp;
                translate.ReadToFollowing("registerMsg");
                registerLabel.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("username");
                tmp = translate.ReadElementContentAsString();
                loginUsername.Text = tmp;
                tr_username = tmp;
                registerUsername.Text = tmp;
                playerUsernameLabel.Text = tmp + " :";
                translate.ReadToFollowing("email");
                tmp = translate.ReadElementContentAsString();
                registerEmail.Text = tmp;
                tr_email = tmp;
                playerEmailLabel.Text = tmp + " :";
                translate.ReadToFollowing("cancel");
                registerCancel.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("register");
                registerButton.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("forgotPass");
                loginForgot.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("status");
                playerStatusLabel.Text = translate.ReadElementContentAsString();
                translate.ReadToFollowing("disconnectMsg");
                tr_disconnectMsg = translate.ReadElementContentAsString();
                this.Refresh();
            }
            catch
            {
                languageChoice formLanguage = new languageChoice(serverName);

                // Show the laguage choice
                formLanguage.ShowDialog();

                if (File.Exists(appdata + serverName + "/language.lang"))
                {
                    language = File.ReadAllText(appdata + serverName + "/language.lang");
                    setLanguage(language);
                }

            }

        }

        private void loginForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = apiUrl + "password/reset";
            p.Start();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsForm settings = new settingsForm(serverName);

            // Show the laguage choice
            settings.ShowDialog();

        }

        private void flatAlertBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
