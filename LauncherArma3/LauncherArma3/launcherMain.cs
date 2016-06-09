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
using System.Collections.Generic;
using System.Linq;

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

        /* ARMA CONFIG */

        string serverArmaIp = "0.0.0.0";


        /* Variables globals */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        private MaterialSkinManager materialSkinManager;
        string news1;
        string news2;
        string news3;
        string language;
        string vLast_mod;
        string vThis_mod;
        string launchOptions;
        bool normalyClose = false;
        bool update = false;
        bool onDownload = false;
        bool pause = false;
        bool cancel = false;
        int stat = 0;
        dynamic result = null;
        long downloaded_bytes = 0;
        long need_to_download = 0;

        /* TIME CALCUL */
        DateTime startTimeDownload;
        long kbPerSecond;
        long totalRecieved = 0;
        DateTime lastProgressChange = DateTime.Now;
        Stack<int> timeSatck = new Stack<int>(5);
        Stack<long> byteSatck = new Stack<long>(5);


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

        public launcherMain(string server, string api, string website, string session, string ftpUrl, string ftpUser, string ftpPass, string vmod)
        {
            InitializeComponent();
            serverName = server;
            apiUrl = api;
            webSite = website;
            sessionToken = session;
            ftp_url = ftpUrl;
            ftp_user = ftpUser;
            ftp_pass = ftpPass;
            vLast_mod = vmod;
        }

        private void launcherMain_Load(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/language.lang"))
            {
                language = File.ReadAllText(appdata + serverName + "/language.lang");
                setLanguage(language);
            }
            if (File.Exists(appdata + serverName + "/armaDest"))
            {
                armaDirectory = File.ReadAllText(appdata + serverName + "/armaDest");
                checkArmaDirectory(armaDirectory);
            }
            if (armaDirectory != null && !Directory.Exists(armaDirectory + "/@" + serverName))
            {
                if (File.Exists(appdata + serverName + "/vMod"))
                    File.Delete(appdata + serverName + "/vMod");
            }
            if (File.Exists(appdata + serverName + "/vMod"))
                vThis_mod = File.ReadAllText(appdata + serverName + "/vMod");
            else
                vThis_mod = "-42";
            if (File.Exists(appdata + serverName + "/launchOptions"))
                launchOptions = File.ReadAllText(appdata + serverName + "/launchOptions");
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
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Blue700, Primary.Blue100, Accent.Red400, TextShade.WHITE);
            checkUpdate();
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
            normalyClose = true;
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
                languageChoice formLanguage = new languageChoice(serverName, true);

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
            using (var form = new settingsForm(serverName, armaDirectory, onDownload))
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                var result = form.ShowDialog();
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                if (result == DialogResult.OK)
                {
                    if (form.refreshMods == true)
                    {
                        if (File.Exists(appdata + serverName + "/vMod"))
                            vThis_mod = File.ReadAllText(appdata + serverName + "/vMod");
                        else
                            vThis_mod = "-42";
                        checkUpdate();
                    }
                    launchOptions = form.launchOptions;
                }
            }
        }

        private void close(object sender, FormClosedEventArgs e)
        {
            if (normalyClose == false)
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
                directoryLabel.Text = "Arma directory ok";
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
            if (File.Exists(appdata + serverName + "/armaDest"))
                File.Delete(appdata + serverName + "/armaDest");
            File.WriteAllText(appdata + serverName + "/armaDest", directoryChooser.SelectedPath);
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
                long currentSize;

                /* LIST DES MODS A TELECHARGER */
                while (i < total_addons)
                {
                    if (cancel == true)
                        break;
                    currentAddons = res.addons[i].name;
                    currentSize = res.addons[i].size;
                    local_addons_md5 = getFileMd5(armaDirectory + "/@" + serverName + "/addons/" + currentAddons).ToLower();
                    remote_addons_md5 = res.addons[i].md5;

                    if (remote_addons_md5 != local_addons_md5)
                    {
                        need_to_download += currentSize;
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
                long currentSize;

                /* LIST DES CPP A TELECHARGER */
                while (i < total_cpp)
                {
                    if (cancel == true)
                        break;
                    currentCpp = res.cpps[i].name;
                    currentSize = res.cpps[i].size;
                    local_cpp_md5 = getFileMd5(armaDirectory + "/@" + serverName + "/" + currentCpp).ToLower();
                    remote_cpp_md5 = res.cpps[i].md5;
                    if (remote_cpp_md5 != local_cpp_md5)
                    {
                        need_to_download += currentSize;
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
                long currentSize;

                /* LIST DES USERSCONFIGS A TELECHARGER */
                while (i < total_userconfigs)
                {
                    if (cancel == true)
                        break;
                    currentUserconfigs = res.userconfigs[i].name;
                    currentSize = res.userconfigs[i].size;
                    local_userconfigs_md5 = getFileMd5(armaDirectory + "/" + currentUserconfigs).ToLower();
                    remote_userconfigs_md5 = res.userconfigs[i].md5;
                    if (remote_userconfigs_md5 != local_userconfigs_md5)
                    {
                        need_to_download += currentSize;
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
            bool alreadyUp = false;

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
            if (update == false && forceUpdate.Checked == false)
            {
                startArma();
                return;
            }

            /* INIT DOWNLOAD */

            downloadProgress.Visible = true;
            downloadProgressLabel.Visible = true;
            pauseButton.Visible = true;
            cancelButton.Visible = true;
            onDownload = true;
            forceUpdate.Visible = false;
            clearNotif();
            succesBox.Visible = true;
            succesBox.Text = "Download started";
            playButton.Text = "Download in progress";
            estimedTime.Text = "Initalisation du téléchargement";
            downloadProgress.Maximum = 100;
            this.Refresh();


            if (!Directory.Exists(armaDirectory + "/@" + serverName))
            {
                Directory.CreateDirectory(armaDirectory + "/@" + serverName);
            }
            if (!Directory.Exists(armaDirectory + "/@" + serverName + "/addons"))
            {
                Directory.CreateDirectory(armaDirectory + "/@" + serverName + "/addons");
            }

            while (serverRequest.IsBusy)
            {
                await Task.Delay(1000);
                serverRequest.Dispose();
                downloadMessage.Text = "Veuillez patientez...";
            }


            /* START LISTING */
            dynamic res;

            stat = 0;

            if (cancel == true)
                downloadMessage.Text = "Annulation en cours...";
            else
            {
                downloadMessage.Text = "Requete au serveur en cours...";
                serverRequest.RunWorkerAsync();
            }
          

            while (stat == 0)
            {
                await Task.Delay(1000);
                if (downloadProgress.Value < 30)
                    downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = "Annulation en cours...";
                    stat = 1;
                }
            }

            res = result;



            /* LISTING ADDONS */

            Queue addonsList = new Queue();
            stat = 0;

            if (cancel == true)
                downloadMessage.Text = "Annulation en cours...";
            else
            {
                downloadMessage.Text = "Listing des mods à télécharger.";
                addonsList = listAddons(res);
            }
       

            while (stat == 0)
            {
                await Task.Delay(1000);
                if (downloadProgress.Value < 60)
                    downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = "Annulation en cours...";
                    stat = 1;
                }
            }


            /* LISTING CPP */

            Queue cppList = new Queue();
            stat = 0;
            if (cancel == true)
                downloadMessage.Text = "Annulation en cours...";
            else
            {
                downloadMessage.Text = "Listing des ccp à télécharger.";
                cppList = listCpp(res);
            }
         
            while (stat == 0)
            {
                await Task.Delay(1000);
                if (downloadProgress.Value < 70)
                    downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = "Annulation en cours...";
                    stat = 1;
                }
            }

            /* LISTING USERCONFIG */

            Queue userconfigList = new Queue();
            stat = 0;
            if (cancel == true)
                downloadMessage.Text = "Annulation en cours...";
            else
            {
                downloadMessage.Text = "Listing des fichier anexes à télécharger.";
                userconfigList = listUserconfigs(res);
            }           

            while (stat == 0)
            {
                await Task.Delay(1000);
                if (downloadProgress.Value < 70)
                    downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = "Annulation en cours...";
                    stat = 1;
                }
            }

            /* CHECK IF ALREADY UP TO DATE */

            if (addonsList.Count == 0 && cppList.Count == 0
               && userconfigList.Count == 0)
            {
                downloadMessage.Text = "Already up to date, you can play !";
                alreadyUp = true;
            }

            while (downloadProgress.Value < 100)
            {
                await Task.Delay(100);
                downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = "Annulation en cours...";
                    break;
                }
            }

            /* SHOW TOTAL FILES */

            int total_files = addonsList.Count + cppList.Count + userconfigList.Count;
            int downloaded = 0;

            totalFiles.Text = "Fichier à télécharger: " + total_files;

            /* DOWNLOAD ADDONS */

            int i;
            string current;

            i = addonsList.Count;

            while (i > 0)
            {
                if (cancel == true)
                    break;
                stat = 0;
                current = addonsList.Dequeue().ToString();
                if (cancel == true)
                    downloadMessage.Text = "Annulation en cours...";
                else
                    downloadMessage.Text = "Téléchargement du mod: " + current + " en cours.";
                startDownload(apiUrl + "api/arma3/addons/download/" + current, armaDirectory + "/@" + serverName + "/addons/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                downloaded++;
                downloadedFiles.Text = "Fichier télécharger: " + downloaded;
                i--;
            }

            /* END DOWNLOAD ADDONS */


            /* DOWNLOAD CPP */

            i = cppList.Count;

            while (i > 0)
            {
                if (cancel == true)
                    break;
                stat = 0;
                current = cppList.Dequeue().ToString();
                if (cancel == true)
                    downloadMessage.Text = "Annulation en cours...";
                else
                    downloadMessage.Text = "Téléchargement du fichier: " + current + " en cours.";
                startDownload(apiUrl + "api/arma3/cpp/download/" + current, armaDirectory + "/@" + serverName + "/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                downloaded++;
                downloadedFiles.Text = "Fichier télécharger: " + downloaded;
                i--;
            }

            /* END DOWNLOADCPP */


            /* DOWNLOAD USERCONFIGS */

            i = userconfigList.Count;

            while (i > 0)
            {
                if (cancel == true)
                    break;
                stat = 0;
                current = userconfigList.Dequeue().ToString();
                if (cancel == true)
                    downloadMessage.Text = "Annulation en cours...";
                else
                    downloadMessage.Text = "Téléchargement du fichier: " + current + " en cours.";
                startDownload(apiUrl + "api/arma3/userconfigs/download/" + current, armaDirectory + "/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                downloaded++;
                downloadedFiles.Text = "Fichier télécharger: " + downloaded;
                i--;
            }

            /* END DOWNLOAD USERCONFIGS */


            /* DELETE INUTILES MODS AND CPP */

            if (cancel == true)
                downloadMessage.Text = "Annulation en cours...";
            else
            {
                downloadMessage.Text = "Verification des mods en cours...";

                string addonsName;
                string[] files = Directory.GetFiles(armaDirectory + "/@" + serverName + "/addons/", "*", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    addonsName = Path.GetFileName(file);
                    if (addonsExits(addonsName, res) == false)
                        File.Delete(file);
                }
            }

            if (cancel == true)
                downloadMessage.Text = "Annulation en cours...";
            else
            {
                downloadMessage.Text = "Verification des cpp en cours...";

                string cppName;
                string[] files = Directory.GetFiles(armaDirectory + "/@" + serverName + "/", "*", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    cppName = Path.GetFileName(file);
                    if (cppExits(cppName, res) == false)
                        File.Delete(file);
                }
            }

            /* END DELETE MODS */

            /* END DOWNLOAD */

            downloadProgress.Visible = false;
            downloadProgressLabel.Visible = false;
            pauseButton.Visible = false;
            cancelButton.Visible = false;
            forceUpdate.Checked = false;
            clearNotif();
            if (cancel == true)
            {
                infoBox.Visible = true;
                infoBox.Text = "Download stoped ";
                checkUpdate();
            }
            else
            {
                if (alreadyUp == false)
                {
                    succesBox.Text = "Download finish !";
                    succesBox.Visible = true;
                }
                if (File.Exists(appdata + serverName + "/vMod"))
                    File.Delete(appdata + serverName + "/vMod");
                File.WriteAllText(appdata + serverName + "/vMod", vLast_mod);
                vThis_mod = vLast_mod;
                checkUpdate();
            }
            downloadProgress.Value = 0;
            downloadProgressLabel.Text = "";
            onDownload = false;
            estimedTime.Text = "";
            sizeLabel.Text = "";
            totalFiles.Text = "";
            downloadedFiles.Text = "";
            cancel = false;
            pause = false;
            result = null;
            pauseButton.Text = "Pause";
        }

        private void startArma()
        {
            if (launchOptions != null)
                Process.Start(armaDirectory + "/arma3.exe", "0 1 -mod=@" + serverName + " -connect=" + serverArmaIp);
            else
                Process.Start(armaDirectory + "/arma3.exe", "0 1 -mod=@" + serverName + " -connect=" + serverArmaIp + " " + launchOptions);
        }

        private bool addonsExits(string addonsName, dynamic res)
        {
            int totalAddons = res.total_addons;
            int i = 0;
            string currentAddons = null;
            while (i < totalAddons)
            {
                currentAddons = res.addons[i].name;
                if (addonsName == currentAddons)
                    return (true);
                i++;
            }
            return (false);
        }

        private bool cppExits(string cppName, dynamic res)
        {
            int totalCpp = res.total_cpps;
            int i = 0;
            string currentCpp = null;
            while (i < totalCpp)
            {
                currentCpp = res.cpps[i].name;
                if (cppName == currentCpp)
                    return (true);
                i++;
            }
            return (false);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (pause == true)
            {
                pause = false;
                pauseButton.Text = "Pause";
            }
            else
            {
                pauseButton.Text = "Resume";
                pause = true;
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = "Le téléchargement se mettra en pause après avoir tétécharger le fichier en cours .";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancel = true;
        }

        protected string getFileMd5(string filePath)
        {
            if (!File.Exists(filePath))
                return ("errorMd5");
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
        }

        private async void startDownload(string remote, string local)
        {
            if (pause == true)
            {
                downloadProgressLabel.Text = "";
                downloadMessage.Text = "Download paused";
                while (pause == true)
                {
                    await Task.Delay(1000);
                    if (cancel == true)
                        break;
                }
            }
            tmp = 0;
            WebClient client = new WebClient();
            Thread thread = new Thread(() =>
            {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                startTimeDownload = DateTime.Now;
                client.DownloadFileAsync(new Uri(remote), local);
            });
            thread.Start();
            while (stat == 0)
            {
                if (cancel == true)
                {
                    downloadMessage.Text = "Annulation en cours...";
                    client.CancelAsync();
                }
                await Task.Delay(1000);
            }
        }

        public string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }

        long tmp = 0;

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                string received = FormatBytes(e.BytesReceived);
                string total = FormatBytes(e.TotalBytesToReceive);
                downloadProgressLabel.Text = "Downloaded " + received + " of " + total;
                downloadProgress.Maximum = (int)e.TotalBytesToReceive;
                downloadProgress.Value = (int)e.BytesReceived;
                sizeLabel.Text = "Downloaded " + FormatBytes(downloaded_bytes) + " to " + FormatBytes(need_to_download);

                downloaded_bytes += e.BytesReceived - tmp;
                tmp = e.BytesReceived;

                /* CALCULE TIME */
                DateTime now;

                now = DateTime.Now;

                if ((now.Second - startTimeDownload.Second) > 0)
                {
                    kbPerSecond = (int)((100 * 1000) / 8);                    
                }
                long sent = (need_to_download - downloaded_bytes);
                if (sent != 0 && kbPerSecond != 0)
                {
                    long remainingseconds = sent / kbPerSecond;
                    estimedTime.Text = "Temps estimé: " + FormatDurationSeconds((int)remainingseconds / 1000);
                }

            });
        }

        public static string FormatDurationSeconds(int seconds)
        {
            var duration = TimeSpan.FromSeconds(seconds);
            string result = "";

            if (duration.TotalHours >= 1)
                result += (int)duration.TotalHours + " Hours, ";

            result += String.Format("{0:%m} Minutes, {0:%s} Seconds", duration);
            return result;
        }


        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                stat = 1;
            });
        }

        void checkUpdate()
        {
            if (vLast_mod != vThis_mod)
            {
                update = true;
                if (File.Exists(appdata + serverName + "/vMod"))
                {
                    playButton.Text = "Update";
                    downloadMessage.Text = "An update is available";
                    forceUpdate.Visible = false;
                }
                else
                {
                    playButton.Text = "Download";
                    downloadMessage.Text = "Wait for download";
                    forceUpdate.Visible = false;
                }
            }
            else
            {
                update = false;
                playButton.Text = "Play";
                downloadMessage.Text = "Already up to date, you can play !";
                forceUpdate.Visible = true;
            }
        }

        private void forceUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (forceUpdate.Checked == true)
            {
                playButton.Text = "Force Update";
            }
            else
                checkUpdate();
        }

        private void serverRequest_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var client = new RestClient(apiUrl);
                var request = new RestRequest("api/arma3/addons", Method.GET);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                result = JObject.Parse(content.ToString());
                stat = 1;
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
