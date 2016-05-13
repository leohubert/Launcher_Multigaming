using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using System.Diagnostics;
using System.IO;
using System.Xml;
using RestSharp;
using Newtonsoft.Json.Linq;

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
        bool normayClose = false;

        /* Session info */
        string sessionToken = null;
        string username = null;
        string email = null;
        string level = null;

        /* GENERAL TRANSLATE */
    
        string tr_username;
        string tr_email;
        string tr_disconnectMsg;

        public launcherMain(string server, string api, string website, string session)
        {
            InitializeComponent();
            serverName = server;
            apiUrl = api;
            webSite = website;
            sessionToken = session;
        }

        private void launcherMain_Load(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/language.lang"))
            {
                language = File.ReadAllText(appdata + serverName + "/language.lang");
                setLanguage(language);
            }
            if (sessionToken != null)
            {
                loginWithToken();
            }
            else
            {
                disconnectButton.Enabled = false;
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

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/token.bin2hex"))
                File.Delete(appdata + serverName + "/token.bin2hex");
            checkNotif();
            succesBox.Visible = true;
            succesBox.Text = tr_disconnectMsg;
            connected = false;
            changeStatus("Red");
            normayClose = true;
            this.Close();
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
                translate.ReadToFollowing("logOut");
                disconnectButton.Text = translate.ReadElementContentAsString();                          
                translate.ReadToFollowing("commingSoon");
                tmp = translate.ReadElementContentAsString();
                newsLabel1.Text = tmp;
                newsLabel2.Text = tmp;
                newsLabel3.Text = tmp;
                translate.ReadToFollowing("username");
                tmp = translate.ReadElementContentAsString();
                tr_username = tmp;
                playerUsernameLabel.Text = tmp + " :";
                translate.ReadToFollowing("email");
                tmp = translate.ReadElementContentAsString();
                tr_email = tmp;
                playerEmailLabel.Text = tmp + " :";
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

        private void close(object sender, FormClosedEventArgs e)
        {
            if (normayClose == false)
            {
                Environment.Exit(42);
            }
        }


    }
}
