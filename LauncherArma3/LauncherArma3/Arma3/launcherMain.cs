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
using System.Collections;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Win32;
using LauncherArma3.Arma3;

namespace LauncherArma3
{
    public partial class launcherMain : MetroFramework.Forms.MetroForm
    {

        /* Launcher basic config */
        string communityName;
        string apiUrl;
        string webSite;
        string teamSpeak;
        string ftp_url;
        string ftp_user;
        string ftp_pass;
        bool showIGinfo;
        string serverID;
        string modsPackName;
        string downloadPath;
        bool serverMaintenance;
        bool serverLocked;
        string serverLockPass = null;
        string serverPass = null;

        /* Variables globals */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        private MaterialSkinManager materialSkinManager;
        string news1;
        string news2;
        string news3;
        string vLast_mod;
        string vThis_mod;
        string vThis_taskforce;
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
        long oldBytes = 0;
        int taskforce;
        string vtaskforce;
        bool modDev;
        int oldTime;
        long oldBytesPerSeconds;
        string serverArmaIp;

        /* TIME CALCUL */
        DateTime startTimeDownload;
        long bytesPerSecond;
        long totalRecieved = 0;
        DateTime lastProgressChange = DateTime.Now;
        Stack<int> timeSatck = new Stack<int>(5);
        Stack<long> byteSatck = new Stack<long>(5);

        /* ARMA 3 SERVER */
        string serverName;

        /* STEAM VARIABLE */
        string armaDirectory = null;

        /* Session info */
        string sessionToken = null;
        string username = null;
        string email = null;
        string level = null;
        string uid = null;
        string picture = null;

        /* GENERAL TRANSLATE */
        Dictionary<string, string> translateDic = new Dictionary<string, string>();

        public launcherMain(string server, string api, string website, string _teamSpeak, string session, string ftpUrl, string ftpUser, string ftpPass, string vmod,
            int _taskforce, string _vtaskforce, bool _modDev, string _serverArmaIp, Dictionary<string, string> _translateDic, bool _showIGinfo, string _serverName,
            string _serverID, string _modsPackName, string _downloadPath, bool _serverLocked, bool _serverMaintenance, string _serverPass)
        {
            InitializeComponent();
            communityName = server;
            apiUrl = api;
            webSite = website;
            sessionToken = session;
            ftp_url = ftpUrl;
            ftp_user = ftpUser;
            ftp_pass = ftpPass;
            vLast_mod = vmod;
            vtaskforce = _vtaskforce;
            taskforce = _taskforce;
            modDev = _modDev;
            serverArmaIp = _serverArmaIp;
            teamSpeak = _teamSpeak;
            translateDic = _translateDic;
            showIGinfo = _showIGinfo;
            serverName = _serverName;
            serverID = _serverID;
            modsPackName = _modsPackName;
            downloadPath = _downloadPath;
            serverLocked = _serverLocked;
            serverMaintenance = _serverMaintenance;
            serverPass = _serverPass;
            this.Text = serverName;
        }

        private void launcherMain_Load(object sender, EventArgs e)
        {            
            //notification.ShowBalloonTip(1000, "Hey", "Welcome", ToolTipIcon.Info);
            if (!Directory.Exists((appdata + communityName + "/" + serverID)))
                Directory.CreateDirectory(appdata + communityName + "/" + serverID);
            if (taskforce == 0)
            {
                taskforceBox.Visible = false;
                changeGameButton.Location = new Point(826, 65);
            }
            setLanguage();         
            if (File.Exists(appdata + communityName + "/armaDest"))
            {
                armaDirectory = File.ReadAllText(appdata + communityName + "/armaDest");
                checkArmaDirectory(armaDirectory);
            }
            else
                loadArma3Directory();
            if (armaDirectory != null && !Directory.Exists(armaDirectory + "/" + modsPackName))
            {
                if (File.Exists(appdata + communityName + "/" + serverID + "/vMod"))
                    File.Delete(appdata + communityName + "/" + serverID + "/vMod");
            }
            if (File.Exists(appdata + communityName + "/" + serverID + "/vMod"))
                vThis_mod = File.ReadAllText(appdata + communityName + "/" + serverID + "/vMod");
            else
                vThis_mod = "-42";
            if (File.Exists(appdata + communityName + "/" + serverID + "/launchOptions"))
                launchOptions = File.ReadAllText(appdata + communityName + "/" + serverID + "/launchOptions");
            if (sessionToken != null)
            {
                loginWithToken();
            }
            else
            {
                logoutButton.Enabled = false;
            }
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Blue700, Primary.Blue100, Accent.Red400, TextShade.WHITE);
            taskforceVersion.Text = vtaskforce;
            checkUpdate();
            if (modDev == true)
            {
                infoBox.Visible = true;
                infoBox.Text = translateDic["modDev"];
            }
            if (taskforce == 1)
            {
                if (File.Exists(appdata + communityName + "/" + serverID + "/vTaskForce"))
                {
                    vThis_taskforce = File.ReadAllText(appdata + communityName + "/" + serverID + "/vTaskForce");
                    if (vThis_taskforce == vtaskforce)
                    {
                        taskforceStatus.ForeColor = Color.ForestGreen;
                        taskforceStatus.Text = translateDic["installed"];
                        taskforceButton.Text = translateDic["forceUpdateTaskforce"];
                    }
                    else
                    {
                        taskforceStatus.ForeColor = Color.DarkOrange;
                        taskforceStatus.Text = translateDic["updateTaskforceRequire"];
                        taskforceButton.Text = translateDic["updateTaskforce"];
                    }
                }
                else
                {
                    vThis_taskforce = "-42";
                    taskforceStatus.ForeColor = Color.DarkRed;
                    taskforceStatus.Text = translateDic["notInstalled"];
                    taskforceButton.Text = translateDic["installTaskforce"];
                }
            }
            if (showIGinfo == false)
            {
                playerInGameBox.Visible = false;
                usefulBox.Location = new Point(308, 253);
            }
            if (serverLocked == true)
            {
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = translateDic["serverLocked"];
                this.Style = MetroColorStyle.Yellow;
            }
            if (serverMaintenance == true)
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = translateDic["serverMaintenance"];
                this.Style = MetroColorStyle.Orange;
            }
            if (serverMaintenance == true || serverLocked == true)
                refreshMaintenance();
            getNotification();
            autoRefresh();

        }

        private async void refreshMaintenance()
        {
            int i = 0;
            while (i != 1)
            {
                await Task.Delay(5000);
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        var client = new RestClient(apiUrl);

                        var request = new RestRequest("api/server/get", Method.POST);

                        request.AddParameter("id", serverID);

                        IRestResponse response = client.Execute(request);
                        var content = response.Content;

                        dynamic res = JObject.Parse(content.ToString());

                        if (res.status == "42")
                        {
                            if (res.maintenance == "0" && serverMaintenance == true)
                            {
                                serverMaintenance = false;
                                this.Style = MetroColorStyle.Blue;
                                clearNotif();
                            }
                            if (res.locked == false && serverLocked == true)
                            {
                                this.Style = MetroColorStyle.Blue;
                                clearNotif();
                                serverLocked = false;
                                checkUpdate();
                            }
                            if (serverMaintenance == false && serverLocked == false)
                                i = 1;
                        }                        
                    }
                    catch
                    {

                    }
                });
                thread.Start();
            }
        }

        private async void autoRefresh()
        {
            int i = 0;
            while (i != 1)
            {
                await Task.Delay(15000);
                Thread thread = new Thread(() =>
                {
                    loadServerStatus();
                    loadIGinfos();
                    getNotification();
                });
                thread.Start();
            }
        }

        void loadArma3Directory()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");

                            if (displayName != null && displayName.ToString() == "Arma 3")
                            {
                                armaDirectory = sk.GetValue("InstallLocation").ToString();
                                directoryLabel.Text = armaDirectory;
                                return;
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
            uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");

                            if (displayName != null && displayName.ToString() == "Arma 3")
                            {
                                armaDirectory = sk.GetValue("InstallLocation").ToString();
                                directoryLabel.Text = armaDirectory;
                                return;
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
            uninstallKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");

                            if (displayName != null && displayName.ToString() == "Arma 3")
                            {
                                armaDirectory = sk.GetValue("InstallLocation").ToString();
                                directoryLabel.Text = armaDirectory;
                                return;
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
            chooseButton.Visible = true;
            directoryLabel.Visible = true;
            clearNotif();
            errorBox.Visible = true;
            errorBox.Text = translateDic["chooseArma"];
        }

        void loginWithToken()
        {
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/users/client/get", Method.POST);

                request.AddParameter("token", sessionToken);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());

                clearNotif();

                if (res.status == "42")
                {
                    username = res.username;
                    email = res.email;
                    level = res.level;
                    uid = res.uid;
                    picture = res.picture;
                    changeStatus("Green");
                    loadNews();
                    refreshSession();
                    loadServerStatus();
                    loadIGinfos();
                }
                else
                {
                    errorBox.Visible = true;
                    errorBox.Text = res.message;
                    if (File.Exists(appdata + communityName + "/token.bin2hex"))
                        File.Delete(appdata + communityName + "/token.bin2hex");
                }
            }
            catch
            {

            }

        }

        void refreshSession()
        {
            if (username.Length >= 18)
                playerUsername.Text = username.Substring(0, 18) + "...";
            else
                playerUsername.Text = username;
            if (email.Length >= 18)
                playerEmail.Text = email.Substring(0, 18) + "...";
            else
                playerEmail.Text = email;
            if (uid.Length >= 18)
                playerUID.Text = uid.Substring(0, 18) + "...";
            else
                playerUID.Text = uid;
            switch (level)
            {
                case "1":
                    playerStatus.Text = "Player";
                    playerStatus.ForeColor = Color.CadetBlue;
                    break;
                case "2":
                    playerStatus.Text = "Policeman";
                    playerStatus.ForeColor = Color.DodgerBlue;
                    break;
                case "3":
                    playerStatus.Text = "Medic";
                    playerStatus.ForeColor = Color.Green;
                    break;
                case "4":
                    playerStatus.Text = "Rebel";
                    playerStatus.ForeColor = Color.DarkRed;
                    break;
                case "5":
                    playerStatus.Text = "VIP";
                    playerStatus.ForeColor = Color.BlueViolet;
                    break;
                case "6":
                    playerStatus.Text = "Support";
                    playerStatus.ForeColor = Color.YellowGreen;
                    break;
                case "7":
                    playerStatus.Text = "Moderator";
                    playerStatus.ForeColor = Color.DarkOrange;
                    break;
                case "8":
                    playerStatus.Text = "Admin";
                    playerStatus.ForeColor = Color.Red;
                    break;
                case "9":
                    playerStatus.Text = "Developer";
                    playerStatus.ForeColor = Color.DarkBlue;
                    break;
                case "10":
                    playerStatus.Text = "Founder";
                    playerStatus.ForeColor = Color.Blue;
                    break;
                default:
                    playerStatus.Text = "INCONNU";
                    playerStatus.ForeColor = Color.OrangeRed;
                    break;
            }
        }

        void getNotification()
        {
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/notifications/get", Method.POST);

                request.AddParameter("token", sessionToken);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());
                
                if (res.status == "42")
                {
                    int total = res.total;
                    notificationNumber.Value = total;                   
                }
                else
                {
                    errorBox.Visible = true;
                    errorBox.Text = res.message;
                }
            }
            catch
            {
                               
            }
        }

        void loadServerStatus()
        {
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/server/status/get", Method.POST);

                request.AddParameter("name", communityName);
                request.AddParameter("arma_ip", serverArmaIp);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());

                clearNotif();

                if (res.status == "42")
                {
                    if (res.online == true)
                    {
                        serverStatus.Text = translateDic["online"];
                        serverStatus.ForeColor = Color.Green;
                        serverMission.Text = res.server_mission;
                        serverPlayers.Text = res.server_onlineplayers + " / " + res.server_maxplayers;
                        serverMap.Text = res.server_map;
                    }
                    else
                    {
                        serverStatus.Text = translateDic["offline"];
                        serverStatus.ForeColor = Color.Red;
                        serverMission.Text = translateDic["notFound"];
                        serverPlayers.Text = translateDic["notFound"];
                        serverMap.Text = translateDic["notFound"];
                    }
                }
                else
                {
                    errorBox.Visible = true;
                    errorBox.Text = res.message;
                }
            }
            catch
            {

            }
        }

        void loadIGinfos()
        {
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/server/client/players/get", Method.POST);

                request.AddParameter("token", sessionToken);
                request.AddParameter("id", serverID);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());

                clearNotif();
                if (res.status == "42")
                {
                    double tmp;
                    IGplayer_username.Text = res.name;
                    tmp = res.cash;
                    IGplayer_cash.Text = tmp.ToString("C", System.Globalization.CultureInfo.GetCultureInfo(translateDic["money"]));
                    tmp = res.bank;
                    IGplayer_bank.Text = tmp.ToString("C", System.Globalization.CultureInfo.GetCultureInfo(translateDic["money"]));
                    IGplayer_coplevel.Text = res.coplevel;
                    IGplayer_mediclevel.Text = res.mediclevel;
                    IGplayer_adminlevel.Text = res.adminlevel;
                }
                else if (res.status != "24" && res.status != "40" && res.status != "15")
                {
                    errorBox.Visible = true;
                    errorBox.Text = res.message;
                }
            }
            catch
            {

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

            var request = new RestRequest("api/news/launcher", Method.POST);

            request.AddParameter("id", serverID);

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
                errorBox.Text = translateDic["downloadProgress"];
                return;
            }
            if (File.Exists(appdata + communityName + "/token.bin2hex"))
                File.Delete(appdata + communityName + "/token.bin2hex");
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

        void setLanguage()
        {
            newsLabel1.Text = translateDic["commingSoon"];
            newsLabel2.Text = translateDic["commingSoon"];
            newsLabel3.Text = translateDic["commingSoon"];
            playerUsernameLabel.Text = translateDic["username"] + " :";
            IGplayerLabel_username.Text = translateDic["username"] + " :";
            playerEmailLabel.Text = translateDic["email"] + " :";
            playerStatusLabel.Text = translateDic["status"] + " :";
            serverStatusLabel.Text = translateDic["status"] + " :";
            logoutButton.Text = translateDic["logOut"];
            settingsButton.Text = translateDic["settings"];
            playerUIDLabel.Text = translateDic["steamUID"] + " :";
            serverMissionLabel.Text = translateDic["mission"] + " :";
            supportButton.Text = translateDic["support"];
            taskforceVersionLabel.Text = translateDic["taskforceVersion"];
            forceUpdate.Text = translateDic["forceUpdate"];
            visitSiteButton.Text = translateDic["visitSite"];
            visitTeamSpeakButton.Text = translateDic["visitTeamSpeak"];
            cancelButton.Text = translateDic["cancel"];
            pauseButton.Text = translateDic["pause"];
            serverPlayersLabel.Text = translateDic["playersIG"] + " :";
            serverMapLabel.Text = translateDic["map"] + " :";
            IGplayerLabel_adminlevel.Text = translateDic["adminLevel"] + " :";
            IGplayerLabel_coplevel.Text = translateDic["copLevel"] + " :";
            IGplayerLabel_mediclevel.Text = translateDic["medicLevel"] + " :";
            IGplayerLabel_cash.Text = translateDic["cash"] + " :";
            IGplayerLabel_bank.Text = translateDic["bank"] + " :";
            playerInGameBox.Text = translateDic["IGinformations"];
            serverBox.Text = translateDic["serverStatus"];
            usefulBox.Text = translateDic["usefulLink"];
            /*if (translateDic["reverse"] == "true")
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }*/
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            using (var form = new settingsForm(communityName, armaDirectory, onDownload, serverID))
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                var result = form.ShowDialog();
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                if (result == DialogResult.OK)
                {
                    if (form.refreshMods == true)
                    {
                        if (File.Exists(appdata + communityName + "/" + serverID + "/vMod"))
                            vThis_mod = File.ReadAllText(appdata + communityName + "/" + serverID + "/vMod");
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
                directoryLabel.Text = translateDic["armaOK"];
                armaDirectory = path;
                return true;
            }
            else
            {
                directoryLabel.Text = translateDic["selectArma"];
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
                errorBox.Text = translateDic["downloadProgress"];
                return;
            }
            directoryChooser.ShowDialog();
            clearNotif();
            if (checkArmaDirectory(directoryChooser.SelectedPath) == true)
            {
                succesBox.Visible = true;
                succesBox.Text = translateDic["success"];
            }
            else
            {
                errorBox.Visible = true;
                errorBox.Text = translateDic["armaNotOK"];
            }
            if (File.Exists(appdata + communityName + "/armaDest"))
                File.Delete(appdata + communityName + "/armaDest");
            File.WriteAllText(appdata + communityName + "/armaDest", directoryChooser.SelectedPath);
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
                    local_addons_md5 = getFileMd5(armaDirectory + "/" + modsPackName + "/addons/" + currentAddons).ToLower();
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
                    local_cpp_md5 = getFileMd5(armaDirectory + "/" + modsPackName + "/" + currentCpp).ToLower();
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
            if (serverMaintenance == true)
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = translateDic["serverMaintenance"];
                return;
            }
            bool alreadyUp = false;

            /* CHECK IF ARMA 3 IS ON */
            if (Process.GetProcessesByName("arma3").Length > 0)
            {
                DialogResult dialogResult = MetroMessageBox.Show(this, "Arma 3 is open, you want to close it ?", "Close Arma 3 ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName("arma3"))
                        {
                            proc.Kill();
                        }
                    }
                    catch
                    {

                    }
                }
                return;
            }
            if (armaDirectory == null)
            {
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = translateDic["selectArma"];
                return;
            }
            if (onDownload == true)
            {
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = translateDic["waitDownload"];
                return;
            }
            if (taskforce == 1 && vtaskforce != vThis_taskforce)
            {
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = translateDic["updateTaskforceBefore"];
                return;
            }
            if (update == false && forceUpdate.Checked == false)
            {
                if (serverLocked == false)
                    startArma();
                else
                {
                    using (var form = new serverPassword(apiUrl, serverID))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            if (form.access == true)
                            {
                                serverLockPass = form.password;
                                serverLocked = true;
                                startArma();
                            }
                        }
                    }
                }
                return;
            }

            /* INIT DOWNLOAD */

            downloadProgress.Visible = true;
            downloadProgressLabel.Visible = true;
            pauseButton.Visible = true;
            cancelButton.Visible = true;
            onDownload = true;
            forceUpdate.Visible = false;
            playButton.Text = translateDic["downloadProgress"];
            estimedTime.Text = translateDic["downloadInitialisation"];
            downloadProgress.Maximum = 100;
            this.Refresh();


            if (!Directory.Exists(armaDirectory + "/" + modsPackName))
            {
                Directory.CreateDirectory(armaDirectory + "/" + modsPackName);
            }
            if (!Directory.Exists(armaDirectory + "/" + modsPackName + "/addons"))
            {
                Directory.CreateDirectory(armaDirectory + "/" + modsPackName + "/addons");
            }

            while (serverRequest.IsBusy)
            {
                serverRequest.Dispose();
                downloadMessage.Text = translateDic["pleaseWait"];
                await Task.Delay(1000);
            }

            /* START LISTING */
            dynamic res;

            stat = 0;

            if (cancel == true)
                downloadMessage.Text = translateDic["cancelling"];
            else
            {
                downloadMessage.Text = translateDic["serverRequest"];
                serverRequest.RunWorkerAsync();
            }            

            while (stat == 0)
            {
                if (downloadProgress.Value < 30)
                    downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = translateDic["cancelling"];
                    stat = 1;
                }
                else
                    await Task.Delay(1000);
            }

            if (result.status != "42")
            {
                MetroMessageBox.Show(this, "Please contact the fondateur for fix this problem (need to create an update)", "An error was detected !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cancel = true;
            }

            res = result;



            /* LISTING ADDONS */

            Queue addonsList = new Queue();
            stat = 0;

            if (cancel == true)
                downloadMessage.Text = translateDic["cancelling"];
            else
            {
                downloadMessage.Text = translateDic["listingMod"];
                addonsList = listAddons(res);
            }


            while (stat == 0)
            {
                if (downloadProgress.Value < 60)
                    downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = translateDic["cancelling"];
                    stat = 1;
                }
                else
                    await Task.Delay(1000);
            }


            /* LISTING CPP */

            Queue cppList = new Queue();
            stat = 0;
            if (cancel == true)
                downloadMessage.Text = translateDic["cancelling"];
            else
            {
                downloadMessage.Text = translateDic["listingCpp"];
                cppList = listCpp(res);
            }

            while (stat == 0)
            {
                if (downloadProgress.Value < 70)
                    downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = translateDic["cancelling"];
                    stat = 1;
                }
                else
                    await Task.Delay(1000);
            }

            /* LISTING USERCONFIG */

            Queue userconfigList = new Queue();
            stat = 0;
            if (cancel == true)
                downloadMessage.Text = translateDic["cancelling"];
            else
            {
                downloadMessage.Text = translateDic["listingAdditional"];
                userconfigList = listUserconfigs(res);
            }

            while (stat == 0)
            {
                if (downloadProgress.Value < 70)
                    downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = translateDic["cancelling"];
                    stat = 1;
                }
                else
                    await Task.Delay(1000);
            }

            /* CHECK IF ALREADY UP TO DATE */

            if (addonsList.Count == 0 && cppList.Count == 0
               && userconfigList.Count == 0)
            {
                downloadMessage.Text = translateDic["alreadyUpToDate"];
                alreadyUp = true;
            }

            while (downloadProgress.Value < 100)
            {
                downloadProgress.Value += 1;
                if (cancel == true)
                {
                    downloadMessage.Text = translateDic["cancelling"];
                    break;
                }
                else
                    await Task.Delay(50);
            }

            /* SHOW TOTAL FILES */

            int total_files = addonsList.Count + cppList.Count + userconfigList.Count;
            int downloaded = 0;


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
                    downloadMessage.Text = translateDic["cancelling"];
                else
                    downloadMessage.Text = translateDic["downloadMod"] + " : " + current + " " + translateDic["inProgress"];
                startDownload(apiUrl + downloadPath + "/modpack/addons/" + current, armaDirectory + "/" + modsPackName + "/addons/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                downloaded++;
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
                    downloadMessage.Text = translateDic["cancelling"];
                else
                    downloadMessage.Text = translateDic["downloadFile"] + " : " + current + " " + translateDic["inProgress"];
                startDownload(apiUrl + downloadPath + "/modpack/" + current, armaDirectory + " /" + modsPackName + "/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                downloaded++;
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
                    downloadMessage.Text = translateDic["cancelling"];
                else
                    downloadMessage.Text = translateDic["downloadFile"] + " : " + current + " " + translateDic["inProgress"];
                startDownload(apiUrl + downloadPath + "/" + current, armaDirectory + "/" + current);
                while (stat == 0)
                    await Task.Delay(1000);
                downloaded++;
                i--;
            }


            if (taskforce == 1)
            {
                stat = 0;
                if (!Directory.Exists(armaDirectory + "/userconfig"))
                    Directory.CreateDirectory(armaDirectory + "/userconfig");
                if (!Directory.Exists(armaDirectory + "/userconfig/task_force_radio"))
                    Directory.CreateDirectory(armaDirectory + "/userconfig/task_force_radio");
                startDownload(apiUrl + downloadPath + "/userconfig/task_force_radio/radio_settings.hpp", armaDirectory + "/userconfig/task_force_radio/radio_settings.hpp");
                while (stat == 0)
                    await Task.Delay(1000);
            }

            /* END DOWNLOAD USERCONFIGS */


            /* DELETE INUTILES MODS AND CPP */

            if (cancel == true)
                downloadMessage.Text = translateDic["cancelling"];
            else
            {
                downloadMessage.Text = translateDic["checkMod"];

                string addonsName;
                string[] files = Directory.GetFiles(armaDirectory + "/" + modsPackName + "/addons/", "*", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    addonsName = Path.GetFileName(file);
                    if (addonsExits(addonsName, res) == false)
                        File.Delete(file);
                }
            }

            if (cancel == true)
                downloadMessage.Text = translateDic["cancelling"];
            else
            {
                downloadMessage.Text = translateDic["checkCpp"];

                string cppName;
                string[] files = Directory.GetFiles(armaDirectory + "/" + modsPackName + "/", "*", SearchOption.TopDirectoryOnly);
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
                infoBox.Text = translateDic["downloadStoped"];
                checkUpdate();
            }
            else
            {
                if (alreadyUp == false)
                {
                    succesBox.Text = translateDic["downloadFinish"];
                    succesBox.Visible = true;
                }
                if (File.Exists(appdata + communityName + "/" + serverID + "/vMod"))
                    File.Delete(appdata + communityName + "/" + serverID + "/vMod");
                File.WriteAllText(appdata + communityName + "/" + serverID + "/vMod", vLast_mod);
                vThis_mod = vLast_mod;
                checkUpdate();
            }
            downloadProgress.Value = 0;
            downloadProgressLabel.Text = "";
            onDownload = false;
            estimedTime.Text = "";
            sizeLabel.Text = "";
            cancel = false;
            pause = false;
            result = null;
            pauseButton.Text = translateDic["pause"];
        }

        private async void startArma()
        {
            playButton.Text = "Game Starting ...";
            if (serverLockPass == null)
            {
                if (launchOptions == null || launchOptions.Length == 0)
                {
                    if (serverPass == null)
                        Process.Start(armaDirectory + "/arma3battleye.exe", "0 1 -mod=" + modsPackName + " -nopause -connect=" + serverArmaIp);
                    else
                        Process.Start(armaDirectory + "/arma3battleye.exe", "0 1 -mod=" + modsPackName + " -nopause -connect=" + serverArmaIp + " -password=" + serverPass);
                }            
                else
                {
                    if (serverPass == null)
                        Process.Start(armaDirectory + "/arma3battleye.exe", "0 1 -mod=" + modsPackName + " -nopause -connect=" + serverArmaIp + " " + launchOptions);
                    else
                        Process.Start(armaDirectory + "/arma3battleye.exe", "0 1 -mod=" + modsPackName + " -nopause -connect=" + serverArmaIp + " -password=" + serverPass + " " + launchOptions);
                }                
            }
            else 
            {                
                if (launchOptions == null || launchOptions.Length == 0)
                    Process.Start(armaDirectory + "/arma3battleye.exe", "0 1 -mod=" + modsPackName + " -nopause -connect=" + serverArmaIp + " -password=" + serverLockPass);
                else
                    Process.Start(armaDirectory + "/arma3battleye.exe", "0 1 -mod=" + modsPackName + " -nopause -connect=" + serverArmaIp + " -password=" + serverLockPass + " " + launchOptions);
            }

            await Task.Delay(17000);
            checkUpdate();
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
                pauseButton.Text = translateDic["pause"];
            }
            else
            {
                pauseButton.Text = translateDic["resume"];
                pause = true;
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = translateDic["downloadWillPause"];
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
                downloadMessage.Text = translateDic["downloadPaused"];
                while (pause == true)
                {
                    await Task.Delay(1000);
                    if (cancel == true)
                        break;
                }
            }
            oldBytes = 0;
            oldTime = DateTime.Now.Second;
            oldBytesPerSeconds = 0;
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
                    downloadMessage.Text = translateDic["cancelling"];
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
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                downloaded_bytes += e.BytesReceived - oldBytes;
                oldBytes = e.BytesReceived;

                string received = FormatBytes(e.BytesReceived);
                string total = FormatBytes(e.TotalBytesToReceive);
                downloadProgressLabel.Text = translateDic["downloaded"] + " " + received + " " + translateDic["of"] + " " + total;
                downloadProgress.Maximum = (int)e.TotalBytesToReceive;
                downloadProgress.Value = (int)e.BytesReceived;
                sizeLabel.Text = translateDic["downloaded"] + " " + FormatBytes(downloaded_bytes) + " " + translateDic["of"] + " " + FormatBytes(need_to_download);



                /* CALCULE TIME */

                if (DateTime.Now.Second != oldTime)
                {
                    try
                    {
                        bytesPerSecond = (e.BytesReceived - oldBytesPerSeconds);
                        oldBytesPerSeconds = e.BytesReceived;
                        oldTime = DateTime.Now.Second;
                        long sent = (need_to_download - downloaded_bytes);
                        if (sent != 0 && bytesPerSecond != 0)
                        {
                            long remainingseconds = (sent / 1000) / (bytesPerSecond / 1000);
                            estimedTime.Text = translateDic["estimatedTime"] + " : " + FormatDurationSeconds((int)remainingseconds);
                        }
                    }
                    catch
                    {
                        //Error division by 0
                    }

                }
            });
        }

        public string FormatDurationSeconds(int seconds)
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
                if (File.Exists(appdata + communityName + "/" + serverID + "/vMod"))
                {
                    playButton.Text = translateDic["update"];
                    downloadMessage.Text = translateDic["updateAvailable"];
                    forceUpdate.Visible = false;
                }
                else
                {
                    playButton.Text = translateDic["download"];
                    downloadMessage.Text = translateDic["waitForDownload"];
                    forceUpdate.Visible = false;
                }
            }
            else
            {
                update = false;
                if (serverLocked == false)
                    playButton.Text = translateDic["play"];
                else
                    playButton.Text = translateDic["serverLocked"];
                downloadMessage.Text = translateDic["alreadyUpToDate"];
                forceUpdate.Visible = true;
            }
        }

        private void forceUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (forceUpdate.Checked == true)
            {
                playButton.Text = translateDic["forceUpdate"];
            }
            else
                checkUpdate();
        }

        private void serverRequest_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var client = new RestClient(apiUrl);
                var request = new RestRequest("api/games/arma3/addons", Method.POST);

                request.AddParameter("id", serverID);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                result = JObject.Parse(content.ToString());
                stat = 1;
            }
            catch
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = translateDic["errorListing"];
                result = null;
            }
        }

        private void taskforceButton_Click(object sender, EventArgs e)
        {
            if (onDownload == true)
            {
                clearNotif();
                infoBox.Visible = true;
                infoBox.Text = translateDic["waitDownload"];
                return;
            }
            taskforceButton.Enabled = false;
            if (!File.Exists("taskforceInstaller.exe"))
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = translateDic["taskforceInstallerMissing"];
                return;
            }
            try
            {
                Process taskforce = new Process();
                taskforce.StartInfo.FileName = "taskforceInstaller.exe";
                taskforce.StartInfo.Arguments = apiUrl + " \"" + appdata + communityName + "/" + serverID + "\" \"" + vtaskforce + "\" \"" + System.Windows.Forms.Application.ExecutablePath + "\" \"" + serverID + "\" \"" + downloadPath + "\"";
                taskforce.Start();
                normalyClose = false;
                this.Close();
            }
            catch
            {
                errorBox.Visible = true;
                errorBox.Text = translateDic["installCancel"];
            }
            taskforceButton.Enabled = true;
        }

        private void supportButton_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = apiUrl + "login?auto=true&token=" + sessionToken;
            p.Start();
        }

        private void teamSpeakIcon_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "ts3server://" + teamSpeak;
            p.Start();
        }

        private void webSiteIcon_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = webSite;
                p.Start();
            }
            catch
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = "WebSite link ins't correct";
            }            
        }

        private void changeGameButton_Click(object sender, EventArgs e)
        {
            if (onDownload == true)
            {
                clearNotif();
                errorBox.Visible = true;
                errorBox.Text = translateDic["downloadProgress"];
                return;
            }
            this.DialogResult = DialogResult.Yes;
            normalyClose = true;
            this.Close();
        }
    }
}

