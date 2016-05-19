using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using System.Diagnostics;
using System.IO;
using System.Xml;
using RestSharp;
using Newtonsoft.Json.Linq;
using MaterialSkin;
using Microsoft.Win32;
using System.Collections;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.ComponentModel;

namespace LauncherArma3
{
    public partial class launcherMain : MetroFramework.Forms.MetroForm
    {

        /* Launcher basic config */
        string apiUrl;
        string webSite;
        string serverName;
        string ftp_url;
        string ftp_user;
        string ftp_pass;


        /* Variables globals */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        private MaterialSkinManager materialSkinManager;
        string news1;
        string news2;
        string news3;
        string language;
        bool normayClose = false;
        bool onDownload = false;
        bool pause = false;
        bool cancel = false;
        int stat = 0;
        dynamic result = null;

        /* STEAM VARIABLE */
        string armaDirectory = @"c:\Program Files (x86)\Steam\steamapps\common\Arma 3";

        /* Session info */
        string sessionToken = null;
        string username = null;
        string email = null;
        string level = null;

        /* GENERAL TRANSLATE */

        string tr_username;
        string tr_email;
        string tr_disconnectMsg;

        public launcherMain(string server, string api, string website, string session, string ftpUrl, string ftpUser, string ftpPass)
        {
            InitializeComponent();
            serverName = server;
            apiUrl = api;
            webSite = website;
            sessionToken = session;
            ftp_url = ftpUrl;
            ftp_user = ftpUser;
            ftp_pass = ftpPass;
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
                logoutButton.Enabled = false;
            }
            checkArmaDirectory(armaDirectory);
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Blue700, Primary.Blue100, Accent.LightGreen200, TextShade.WHITE);
        }

        void loginWithToken()
        {
            var client = new RestClient(apiUrl);

            var request = new RestRequest("api/user/get", Method.POST);

            request.AddParameter("token", sessionToken);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            clearNotif();

            if (res.status == "42")
            {
                username = res.user.username;
                email = res.user.email;
                level = res.user.level;
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
            if (onDownload == true)
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = "Download in progress";
                return;
            }
            if (File.Exists(appdata + serverName + "/token.bin2hex"))
                File.Delete(appdata + serverName + "/token.bin2hex");
            clearNotif();
            succesBox.Visible = true;
            succesBox.Text = tr_disconnectMsg;
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
                logoutButton.Text = translate.ReadElementContentAsString();
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

        void clearNotif()
        {
            if (errorBox.Text != null)
            {
                errorBox.Text = null;
                errorBox.Visible = false;
            }
            if (succesBox.Text != null)
            {
                succesBox.Text = null;
                succesBox.Visible = false;
            }
            if (infoBox.Text != null)
            {
                infoBox.Text = null;
                infoBox.Visible = false;
            }
        }

        bool checkArmaDirectory(string path)
        {
            if (File.Exists(path + @"\arma3.exe"))
            {
                directoryLabel.Text = "Arma directory: " + path;
                armaDirectory = path;
                return true;
            }
            else
            {
                directoryLabel.Text = "Reselect arma diretory !";
                armaDirectory = null;
                return false;
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (onDownload == true)
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = "Download in progress";
                return;
            }
            directoryChooser.ShowDialog();
            clearNotif();
            if (checkArmaDirectory(directoryChooser.SelectedPath) == true)
            {
                succesBox.Visible = true;
                succesBox.Text = "Success !";
            }
            else
            {
                errorBox.Visible = true;
                errorBox.Text = "Arma directory not good ! ";
            }
        }

        Queue listAddons(dynamic res)
        {

            Queue modList = new Queue();

            Thread thread = new Thread(() =>
            {
                /* VARIABLES */

                string remote_addons_md5;
                string local_addons_md5;
                string currentAddons;
                int i = 0;
                int total_addons = res.total_addons;

                /* LIST DES MODS A TELECHARGER */
                while (i < total_addons)
                {
                    currentAddons = res.addons[i].name;
                    local_addons_md5 = getFileMd5(armaDirectory + "/@" + serverName + "/addons/" + currentAddons).ToLower();
                    remote_addons_md5 = res.addons[i].md5;
                    if (remote_addons_md5 != local_addons_md5)
                    {
                        modList.Enqueue(currentAddons);
                    }
                    i++;
                }
                stat = 1;
            });
            thread.Start();
            return (modList);
        }

        Queue listCpp(dynamic res)
        {

            Queue cppList = new Queue();
            Thread thread = new Thread(() =>
            {
                /* VARIABLES */

                string remote_cpp_md5;
                string local_cpp_md5;
                string currentCpp;
                int i = 0;
                int total_cpp = res.total_cpps;

                /* LIST DES CPP A TELECHARGER */
                while (i < total_cpp)
                {
                    currentCpp = res.cpps[i].name;
                    local_cpp_md5 = getFileMd5(armaDirectory + "/@" + serverName + "/" + currentCpp).ToLower();
                    remote_cpp_md5 = res.cpps[i].md5;
                    if (remote_cpp_md5 != local_cpp_md5)
                    {
                        cppList.Enqueue(currentCpp);
                    }
                    i++;
                }
                stat = 1;
            });
            thread.Start();
            return (cppList);
        }

        Queue listUserconfigs(dynamic res)
        {

            Queue userconfigList = new Queue();

            Thread thread = new Thread(() =>
            {
                /* VARIABLES */

                string remote_userconfigs_md5;
                string local_userconfigs_md5;
                string currentUserconfigs;
                int i = 0;
                int total_userconfigs = res.total_userconfigs;

                /* LIST DES USERSCONFIGS A TELECHARGER */
                while (i < total_userconfigs)
                {
                    currentUserconfigs = res.userconfigs[i].name;
                    local_userconfigs_md5 = getFileMd5(armaDirectory + "/" + currentUserconfigs).ToLower();
                    remote_userconfigs_md5 = res.userconfigs[i].md5;
                    if (remote_userconfigs_md5 != local_userconfigs_md5)
                    {
                        userconfigList.Enqueue(currentUserconfigs);
                    }
                    i++;
                }
                stat = 1;
            });
            thread.Start();
            return (userconfigList);
        }

        private async void playButton_Click(object sender, EventArgs e)
        {
            if (armaDirectory == null)
            {
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = "Please select arma directory.";
                return;
            }
            if (onDownload == true)
            {
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = "Wait until the end of the current download.";
                return;
            }

            /* INIT DOWNLOAD */

            downloadProgress.Visible = true;
            downloadProgressLabel.Visible = true;
            pauseButton.Visible = true;
            cancelButton.Visible = true;
            onDownload = true;
            clearNotif();
            succesBox.Visible = true;
            succesBox.Text = "Download started";
            this.Refresh();


            if (!Directory.Exists(armaDirectory + "/@" + serverName))
            {
                Directory.CreateDirectory(armaDirectory + "/@" + serverName);
            }
            if (!Directory.Exists(armaDirectory + "/@" + serverName + "/addons"))
            {
                Directory.CreateDirectory(armaDirectory + "/@" + serverName + "/addons");
            }


            /* START LISTING */

            initDownload.RunWorkerAsync();

            while (result == null)
                await Task.Delay(1000);


            dynamic res = result;

            /* LISTING ADDONS */

            Queue addonsList = new Queue();
            stat = 0;
            downloadMessage.Text = "Listing des mods à télécharger.";
            addonsList = listAddons(res);

            while (stat == 0)
                await Task.Delay(1000);

            /* LISTING CPP */

            Queue cppList = new Queue();
            stat = 0;
            downloadMessage.Text = "Listing des ccp à télécharger.";
            cppList = listCpp(res);

            while (stat == 0)
                await Task.Delay(1000);

            /* LISTING USERCONFIG */

            Queue userconfigList = new Queue();
            stat = 0;
            downloadMessage.Text = "Listing des fichier anexes à télécharger.";
            userconfigList = listUserconfigs(res);

            while (stat == 0)
                await Task.Delay(1000);



            /* DOWNLOAD ADDONS */

            int i;
            string current;

            i = addonsList.Count;

            while (i > 0)
            {
                stat = 0;
                current = addonsList.Dequeue().ToString();
                downloadMessage.Text = "Téléchargement du mod: " + current + "en cours.";
                startDownload(apiUrl + "api/arma3/addons/download/" + current, armaDirectory + "/@" + serverName + "/addons/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                i--;
            }

            /* END DOWNLOAD ADDONS */


            /* DOWNLOAD CPP */

            i = cppList.Count;

            while (i > 0)
            {
                stat = 0;
                current = cppList.Dequeue().ToString();
                downloadMessage.Text = "Téléchargement du fichier: " + current + "en cours.";
                startDownload(apiUrl + "api/arma3/cpps/download/" + current, armaDirectory + "/@" + serverName + "/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                i--;
            }

            /* END DOWNLOADCPP */


            /* DOWNLOAD USERCONFIGS */

            i = userconfigList.Count;

            while (i > 0)
            {
                stat = 0;
                current = userconfigList.Dequeue().ToString();
                downloadMessage.Text = "Téléchargement du fichier: " + current + "en cours.";
                startDownload(apiUrl + "api/arma3/userconfigs/download/" + current, armaDirectory + "/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                i--;
            }

            /* END DOWNLOAD USERCONFIGS */


            /* CHECK IF ALREADY UP TO DATE */

            if (addonsList.Count == 0 && cppList.Count == 0
               && userconfigList.Count == 0)
            {
                downloadMessage.Text = "Already up to date, you can play !";
            }



            /* END DOWNLOAD */
            /*
            downloadProgress.Visible = false;
            downloadProgressLabel.Visible = false;
            pauseButton.Visible = false;
            cancelButton.Visible = false;
            clearNotif();
            if (cancel == true)
            {
                infoBox.Visible = true;
                infoBox.Text = "Download stoped ";
            }
            else
            {
                succesBox.Visible = true;
                succesBox.Text = "Download finish !";
            }
            */
            onDownload = false;
            cancel = false;
            pause = false;

        }


        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (pause == true)
            {
                pause = false;
                pauseButton.Text = "Pause";
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = "Le téléchargement se mettra en pause après avoir tétécharger le fichier en cours .";

            }
            else
            {
                pauseButton.Text = "Resume";
                pause = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancel = true;
        }

        protected string getFileMd5(string filePath)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                    }
                }
            }
            catch
            {
                return "errormd5";
            }
            return (null);
        }

        private async void startDownload(string remote, string local)
        {
            while (pause == true)
                await Task.Delay(1000);
            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(remote), local);
            });
            thread.Start();

        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                downloadProgressLabel.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                downloadProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                stat = 1;
            });
        }

        private void initDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var client = new RestClient(apiUrl);
                var request = new RestRequest("api/arma3/addons", Method.GET);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                result = JObject.Parse(content.ToString());
            }
            catch
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = "Error when start listing mods";
            }
        }
    }
}
