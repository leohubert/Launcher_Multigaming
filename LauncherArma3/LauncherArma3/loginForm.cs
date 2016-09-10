using LauncherArma3.Properties;
using MaterialSkin;
using MetroFramework;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LauncherArma3
{


    public partial class loginForm : MetroFramework.Forms.MetroForm
    {

        /* GENERAL OPTIONS */

        string communityName;
        string apiUrl;
        string webSite;
        string teamSpeak;
        string ftp_url;
        string ftp_user;
        string ftp_pass;
        bool showIGinfo;
        string modPackName;
        string downloadPath;
        bool canPlay;
        bool serverMaintenance;

        /* SERVER VARIABLE */

        string serverIP;
        string serverID;
        string serverName;
        string serverGame;


        /* ANOTHER VARIABLE */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        private readonly MaterialSkinManager materialSkinManager;
        string sessionToken;
        string language;
        string vLast;
        int stat = 0;
        bool startLauncher = false;
        bool modDev;
        bool internet;
        bool server;
        bool maintenance;
        bool loaded = false;
        bool notif = false;
        int taskforce;
        string vtaskforce;

        /* TRANSLATE PART */

        XmlReader translate = XmlReader.Create(new StringReader(Resources.translate));
        Dictionary<string, string> translateDic = new Dictionary<string, string>();


        public loginForm(string _communityName, string api, string ftpUrl, string ftpUser, string ftpPass, bool mod)
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
            communityName = _communityName;
            apiUrl = api;
            ftp_url = ftpUrl;
            ftp_user = ftpUser;
            ftp_pass = ftpPass;
            modDev = mod;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(appdata + communityName + "/token.bin2hex"))
            {
                sessionToken = File.ReadAllText(appdata + communityName + "/token.bin2hex");
            }
            if (File.Exists(appdata + communityName + "/language.lang"))
            {
                language = File.ReadAllText(appdata + communityName + "/language.lang");
                loadLanguage();
            }
            if (modDev == true)
            {
                notifView("Warning ! Dev mod enabled !");   
            }
            if (translateDic["reverse"] == "true")
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }
                             
        }

        private void checkOptions(object sender, EventArgs e)
        {
            if (loaded == true)
            {
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                return;
            }
            loaded = true;
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                internet = true;
            }
            catch
            {
                this.Style = MetroColorStyle.Red;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
                internet = false;
                newsTitle.Text = translateDic["errorInternet"];
                notifView(translateDic["errorInternet"]);
                errorImage.BringToFront();
                return;
            }
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/settings", Method.GET);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());

                if (res.maintenance == "1")
                {
                    maintenance = true;
                    loginButton.Enabled = false;
                    registerLink.Enabled = false;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
                    this.Style = MetroColorStyle.Orange;
                    if (res.maintenance_title == "{picture}")
                    {
                        newsImage.Visible = true;
                        newsImage.ImageLocation = res.maintenance_content;
                        newsImage.BringToFront();
                    }
                    else
                    {
                        newsTitle.Text = res.maintenance_title;
                        newsContent.Text = res.maintenance_content;
                    }
                    maintenanceRefresh.RunWorkerAsync();                
                    return;
                }

                if (res.msg_title == "{picture}")
                {
                    newsImage.Visible = true;
                    newsImage.ImageLocation = res.msg_content;
                    newsImage.BringToFront();
                }
                newsTitle.Text = res.msg_title;
                newsContent.Text = res.msg_content;

                if (modDev == false && res.vlauncher != getLauncherMd5().ToLower())
                {
                    launcherUpdate();
                    return;
                }
                if (res.login == "0")
                {
                    sessionToken = null;
                    startLauncher = false;
                    loginUsername.Text = "";
                    loginPassword.Text = "";
                    loginRemember.Checked = false;
                    this.Visible = false;
                    if (!File.Exists(appdata + communityName + "/autoConnect"))
                    {
                        using (var chooseServer = new serverChoose(apiUrl, communityName, translateDic, appdata))
                        {                            
                            var result = chooseServer.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                serverID = chooseServer.currentServerid;
                                serverIP = chooseServer.currentServerIP;
                                serverGame = chooseServer.currentServerGame;
                                serverName = chooseServer.currentServerName;
                                getServerInfo(serverID);
                            }
                        }
                    }
                    else
                    {
                        string id = File.ReadAllText(appdata + communityName + "/autoConnect");

                        //GET SERVER INFO
                        getServerInfo(id);
                    }
                    switch (serverGame)
                    {
                        case "arma3":
                            using (var launcher = new launcherMain(communityName, apiUrl, webSite, teamSpeak, sessionToken, ftp_url, ftp_user, 
                                ftp_pass, vLast, taskforce, vtaskforce, modDev, serverIP, translateDic, showIGinfo, serverName, serverID,
                                modPackName, downloadPath, canPlay, serverMaintenance))
                            {
                                var result = launcher.ShowDialog();
                                if (result == DialogResult.Yes)
                                {
                                    if (File.Exists(appdata + communityName + "/autoConnect"))
                                        File.Delete(appdata + communityName + "/autoConnect");
                                    loginWithToken();
                                }
                            }
                            break;
                        default:
                            MessageBox.Show("This game is not created on this launcher");
                            break;
                    }
                    materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    this.Visible = true;
                }
                if (res.register == "0")
                {
                    registerLink.Enabled = false;
                    registerMessage.Text = translateDic["registerDisabled"];
                }
                if (sessionToken != null)
                {
                    loginWithToken();
                }
                server = true;
            }
            catch
            {
                this.Style = MetroColorStyle.Red;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
                server = false;
                newsTitle.Text = translateDic["error404"];
                notifView(translateDic["error404"]);
                newsContent.Visible = false;
                newsImage.Visible = false;
                errorImage.BringToFront();
            }
        }


        private async void loginButton_Click(object sender, EventArgs e)
        {
            stat = 0;
            Thread thread = new Thread(() =>
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    try
                    {
                        if (internet == false)
                        {
                            notifView(translateDic["errorInternet"]);
                            return;
                        }
                        if (server == false)
                        {
                            notifView(translateDic["error404"]);
                            return;
                        }
                        var client = new RestClient(apiUrl);

                        var request = new RestRequest("api/login", Method.POST);

                        request.AddParameter("login", loginUsername.Text);
                        request.AddParameter("password", loginPassword.Text);
                        request.AddParameter("launcher", 1);

                        IRestResponse response = client.Execute(request);
                        var content = response.Content;
                    
                        dynamic res = JObject.Parse(content.ToString());

                        if (res.status == "42")
                        {
                            sessionToken = res.token;
                            if (loginRemember.Checked == true)
                            {
                                string token = res.token;
                                File.WriteAllText(appdata + communityName + "/token.bin2hex", token);
                            }

                            // Reset form
                            startLauncher = true;
                            stat = 1;
                        }                        
                        else
                        {
                            string message = res.message;
                            notifView(message);
                        }
                    }
                    catch
                    {
                        notifView(translateDic["error404"]);
                    }
                });
            });
            thread.Start();
            while (stat == 0)
                await Task.Delay(1000);
            if (startLauncher == true)
            {
                startLauncher = false;
                loginUsername.Text = "";
                loginPassword.Text = "";
                loginRemember.Checked = false;
                this.Visible = false;
                if (!File.Exists(appdata + communityName + "/autoConnect"))
                {
                    using (var chooseServer = new serverChoose(apiUrl, communityName, translateDic, appdata))
                    {
                        var result = chooseServer.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            serverID = chooseServer.currentServerid;
                            serverIP = chooseServer.currentServerIP;
                            serverGame = chooseServer.currentServerGame;
                            serverName = chooseServer.currentServerName;
                            getServerInfo(serverID);
                        }
                        else
                            this.Close();        
                    }
                }
                else
                {
                    string id = File.ReadAllText(appdata + communityName + "/autoConnect");

                    //GET SERVER INFO
                    getServerInfo(id);        
                }
                switch (serverGame)
                {
                    case "arma3":
                        using (var launcher = new launcherMain(communityName, apiUrl, webSite, teamSpeak, sessionToken, ftp_url, ftp_user, ftp_pass, 
                            vLast, taskforce, vtaskforce, modDev, serverIP, translateDic, showIGinfo, serverName, serverID, modPackName, downloadPath,
                            canPlay, serverMaintenance))
                        {
                            var result = launcher.ShowDialog();
                            if (result == DialogResult.Yes)
                            {
                                if (File.Exists(appdata + communityName + "/autoConnect"))
                                    File.Delete(appdata + communityName + "/autoConnect");
                                loginWithToken();
                            }
                        }
                        break;
                    default:
                        MessageBox.Show("This game is not created on this launcher");
                        break;
                }
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                this.Visible = true;
            }
        }

        void getServerInfo(string id)
        {
            //GET SERVER INFO
            var client = new RestClient(apiUrl);

            var request = new RestRequest("api/server/get", Method.POST);

            request.AddParameter("id", id);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            if (res.status == "42")
            {
                serverID = res.id;
                serverIP = res.ip + ":" + res.port;
                serverGame = res.game;
                serverName = res.name;
                teamSpeak = res.teamspeak;
                webSite = res.website;
                vLast = res.vmod;
                vtaskforce = res.vtaskforce;
                taskforce = res.taskforce;
                modPackName = res.modpack_name;
                downloadPath = res.local_path;
                if (res.show_infos == "1")
                    showIGinfo = true;
                else
                    showIGinfo = false;
                if (res.maintenance == "1")
                    serverMaintenance = true;
                else
                    serverMaintenance = false;
                if (res.can_play == "1")
                    canPlay = true;
                else
                    canPlay = false;
            }
        }

        void loginWithToken()
        {
            stat = 0;
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/users/client/get", Method.POST);

                request.AddParameter("token", sessionToken);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());

                if (res.status == "42")
                {
                    startLauncher = false;
                    loginUsername.Text = "";
                    loginPassword.Text = "";
                    loginRemember.Checked = false;
                    this.Visible = false;
                    if (!File.Exists(appdata + communityName + "/autoConnect"))
                    {
                        using (var chooseServer = new serverChoose(apiUrl, communityName, translateDic, appdata))
                        {                                                    
                            var result = chooseServer.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                serverID = chooseServer.currentServerid;
                                serverIP = chooseServer.currentServerIP;
                                serverGame = chooseServer.currentServerGame;
                                serverName = chooseServer.currentServerName;
                                getServerInfo(serverID);
                            }
                            else
                                this.Close();
                        }
                    }
                    else
                    {
                        string id = File.ReadAllText(appdata + communityName + "/autoConnect");

                        //GET SERVER INFO
                        getServerInfo(id);
                    }
                    switch (serverGame)
                    {
                        case "arma3":
                            using (var launcher = new launcherMain(communityName, apiUrl, webSite, teamSpeak, sessionToken, ftp_url, ftp_user, ftp_pass, vLast, taskforce, 
                                vtaskforce, modDev, serverIP, translateDic, showIGinfo, serverName, serverID, modPackName, downloadPath, canPlay, serverMaintenance))
                            {
                                var result = launcher.ShowDialog();
                                if (result == DialogResult.Yes)
                                {
                                    if (File.Exists(appdata + communityName + "/autoConnect"))
                                        File.Delete(appdata + communityName + "/autoConnect");
                                    loginWithToken();
                                }
                            }
                            break;
                        default:
                            MessageBox.Show("This game is not created on this launcher");
                            break;
                    }
                    materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    this.Visible = true;
                }
                else
                {
                    string msg = res.message;
                    notifView(msg);
                    if (File.Exists(appdata + communityName + "/token.bin2hex"))
                        File.Delete(appdata + communityName + "/token.bin2hex");
                }
            }
            catch
            {
                notifView(translateDic["error404"]);
            }
        }

        private void registerLink_Click(object sender, EventArgs e)
        {
            if (internet == false)
            {
                notifView(translateDic["errorInternet"]);
                return;
            }
            if (server == false)
            {
                notifView(translateDic["error404"]);
                return;
            }
            registerForm register = new registerForm(communityName, apiUrl, webSite, translateDic);

            // Show the laguage choice
            register.ShowDialog();
        }

        void loadLanguage()
        {
            try
            {

                translate.ReadToFollowing(language);
                translate.ReadToFollowing("money");
                translateDic.Add("money", translate.ReadElementContentAsString());
                translate.ReadToFollowing("reverse");
                translateDic.Add("reverse", translate.ReadElementContentAsString());
                translate.ReadToFollowing("logIn");
                translateDic.Add("logIn", translate.ReadElementContentAsString());
                translate.ReadToFollowing("logOut");
                translateDic.Add("logOut", translate.ReadElementContentAsString());
                translate.ReadToFollowing("remember");
                translateDic.Add("remember", translate.ReadElementContentAsString());
                translate.ReadToFollowing("loginMsg");
                translateDic.Add("loginMsg", translate.ReadElementContentAsString());
                translate.ReadToFollowing("registerLink");
                translateDic.Add("registerLink", translate.ReadElementContentAsString());
                translate.ReadToFollowing("commingSoon");
                translateDic.Add("commingSoon", translate.ReadElementContentAsString());
                translate.ReadToFollowing("registerMsg");
                translateDic.Add("registerMsg", translate.ReadElementContentAsString());
                translate.ReadToFollowing("username");
                translateDic.Add("username", translate.ReadElementContentAsString());
                translate.ReadToFollowing("password");
                translateDic.Add("password", translate.ReadElementContentAsString());
                translate.ReadToFollowing("passwordConfirm");
                translateDic.Add("passwordConfirm", translate.ReadElementContentAsString());
                translate.ReadToFollowing("email");
                translateDic.Add("email", translate.ReadElementContentAsString());
                translate.ReadToFollowing("cancel");
                translateDic.Add("cancel", translate.ReadElementContentAsString());
                translate.ReadToFollowing("register");
                translateDic.Add("register", translate.ReadElementContentAsString());
                translate.ReadToFollowing("forgotPass");
                translateDic.Add("forgotPass", translate.ReadElementContentAsString());
                translate.ReadToFollowing("status");
                translateDic.Add("status", translate.ReadElementContentAsString());
                translate.ReadToFollowing("disconnectMsg");
                translateDic.Add("disconnectMsg", translate.ReadElementContentAsString());
                translate.ReadToFollowing("maintenanceTitle");
                translateDic.Add("maintenanceTitle", translate.ReadElementContentAsString());
                translate.ReadToFollowing("registerDisabled");
                translateDic.Add("registerDisabled", translate.ReadElementContentAsString());
                translate.ReadToFollowing("error404");
                translateDic.Add("error404", translate.ReadElementContentAsString());
                translate.ReadToFollowing("errorUpdate");
                translateDic.Add("errorUpdate", translate.ReadElementContentAsString());
                translate.ReadToFollowing("updateCancel");
                translateDic.Add("updateCancel", translate.ReadElementContentAsString());
                translate.ReadToFollowing("settings");
                translateDic.Add("settings", translate.ReadElementContentAsString());
                translate.ReadToFollowing("steamUID");
                translateDic.Add("steamUID", translate.ReadElementContentAsString());
                translate.ReadToFollowing("mission");
                translateDic.Add("mission", translate.ReadElementContentAsString());
                translate.ReadToFollowing("online");
                translateDic.Add("online", translate.ReadElementContentAsString());
                translate.ReadToFollowing("offline");
                translateDic.Add("offline", translate.ReadElementContentAsString());
                translate.ReadToFollowing("notFound");
                translateDic.Add("notFound", translate.ReadElementContentAsString());
                translate.ReadToFollowing("support");
                translateDic.Add("support", translate.ReadElementContentAsString());
                translate.ReadToFollowing("taskforceVersion");
                translateDic.Add("taskforceVersion", translate.ReadElementContentAsString());
                translate.ReadToFollowing("notInstalled");
                translateDic.Add("notInstalled", translate.ReadElementContentAsString());
                translate.ReadToFollowing("installed");
                translateDic.Add("installed", translate.ReadElementContentAsString());
                translate.ReadToFollowing("updateTaskforceRequire");
                translateDic.Add("updateTaskforceRequire", translate.ReadElementContentAsString());
                translate.ReadToFollowing("forceUpdateTaskforce");
                translateDic.Add("forceUpdateTaskforce", translate.ReadElementContentAsString());
                translate.ReadToFollowing("installTaskforce");
                translateDic.Add("installTaskforce", translate.ReadElementContentAsString());
                translate.ReadToFollowing("updateTaskforce");
                translateDic.Add("updateTaskforce", translate.ReadElementContentAsString());
                translate.ReadToFollowing("play");
                translateDic.Add("play", translate.ReadElementContentAsString());
                translate.ReadToFollowing("download");
                translateDic.Add("download", translate.ReadElementContentAsString());
                translate.ReadToFollowing("update");
                translateDic.Add("update", translate.ReadElementContentAsString());
                translate.ReadToFollowing("forceUpdate");
                translateDic.Add("forceUpdate", translate.ReadElementContentAsString());
                translate.ReadToFollowing("visitSite");
                translateDic.Add("visitSite", translate.ReadElementContentAsString());
                translate.ReadToFollowing("visitTeamSpeak");
                translateDic.Add("visitTeamSpeak", translate.ReadElementContentAsString());
                translate.ReadToFollowing("modDev");
                translateDic.Add("modDev", translate.ReadElementContentAsString());
                translate.ReadToFollowing("chooseArma");
                translateDic.Add("chooseArma", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloadProgress");
                translateDic.Add("downloadProgress", translate.ReadElementContentAsString());
                translate.ReadToFollowing("armaOK");
                translateDic.Add("armaOK", translate.ReadElementContentAsString());
                translate.ReadToFollowing("selectArma");
                translateDic.Add("selectArma", translate.ReadElementContentAsString());
                translate.ReadToFollowing("armaNotOK");
                translateDic.Add("armaNotOK", translate.ReadElementContentAsString());
                translate.ReadToFollowing("success");
                translateDic.Add("success", translate.ReadElementContentAsString());
                translate.ReadToFollowing("waitDownload");
                translateDic.Add("waitDownload", translate.ReadElementContentAsString());
                translate.ReadToFollowing("updateTaskforceBefore");
                translateDic.Add("updateTaskforceBefore", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloadInitialisation");
                translateDic.Add("downloadInitialisation", translate.ReadElementContentAsString());
                translate.ReadToFollowing("pleaseWait");
                translateDic.Add("pleaseWait", translate.ReadElementContentAsString());
                translate.ReadToFollowing("cancelling");
                translateDic.Add("cancelling", translate.ReadElementContentAsString());
                translate.ReadToFollowing("pause");
                translateDic.Add("pause", translate.ReadElementContentAsString());
                translate.ReadToFollowing("resume");
                translateDic.Add("resume", translate.ReadElementContentAsString());
                translate.ReadToFollowing("serverRequest");
                translateDic.Add("serverRequest", translate.ReadElementContentAsString());
                translate.ReadToFollowing("listingMod");
                translateDic.Add("listingMod", translate.ReadElementContentAsString());
                translate.ReadToFollowing("listingCpp");
                translateDic.Add("listingCpp", translate.ReadElementContentAsString());
                translate.ReadToFollowing("listingAdditional");
                translateDic.Add("listingAdditional", translate.ReadElementContentAsString());
                translate.ReadToFollowing("alreadyUpToDate");
                translateDic.Add("alreadyUpToDate", translate.ReadElementContentAsString());
                translate.ReadToFollowing("inProgress");
                translateDic.Add("inProgress", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloadMod");
                translateDic.Add("downloadMod", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloadFile");
                translateDic.Add("downloadFile", translate.ReadElementContentAsString());
                translate.ReadToFollowing("checkMod");
                translateDic.Add("checkMod", translate.ReadElementContentAsString());
                translate.ReadToFollowing("checkCpp");
                translateDic.Add("checkCpp", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloadStoped");
                translateDic.Add("downloadStoped", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloadFinish");
                translateDic.Add("downloadFinish", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloadWillPause");
                translateDic.Add("downloadWillPause", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloadPaused");
                translateDic.Add("downloadPaused", translate.ReadElementContentAsString());
                translate.ReadToFollowing("downloaded");
                translateDic.Add("downloaded", translate.ReadElementContentAsString());
                translate.ReadToFollowing("of");
                translateDic.Add("of", translate.ReadElementContentAsString());
                translate.ReadToFollowing("estimatedTime");
                translateDic.Add("estimatedTime", translate.ReadElementContentAsString());
                translate.ReadToFollowing("waitForDownload");
                translateDic.Add("waitForDownload", translate.ReadElementContentAsString());
                translate.ReadToFollowing("updateAvailable");
                translateDic.Add("updateAvailable", translate.ReadElementContentAsString());
                translate.ReadToFollowing("errorListing");
                translateDic.Add("errorListing", translate.ReadElementContentAsString());
                translate.ReadToFollowing("taskforceInstallerMissing");
                translateDic.Add("taskforceInstallerMissing", translate.ReadElementContentAsString());
                translate.ReadToFollowing("installCancel");
                translateDic.Add("installCancel", translate.ReadElementContentAsString());
                translate.ReadToFollowing("minutes");
                translateDic.Add("minutes", translate.ReadElementContentAsString());
                translate.ReadToFollowing("seconds");
                translateDic.Add("seconds", translate.ReadElementContentAsString());
                translate.ReadToFollowing("hours");
                translateDic.Add("hours", translate.ReadElementContentAsString());
                translate.ReadToFollowing("playersIG");
                translateDic.Add("playersIG", translate.ReadElementContentAsString());
                translate.ReadToFollowing("map");
                translateDic.Add("map", translate.ReadElementContentAsString());
                translate.ReadToFollowing("adminLevel");
                translateDic.Add("adminLevel", translate.ReadElementContentAsString());
                translate.ReadToFollowing("copLevel");
                translateDic.Add("copLevel", translate.ReadElementContentAsString());
                translate.ReadToFollowing("medicLevel");
                translateDic.Add("medicLevel", translate.ReadElementContentAsString());
                translate.ReadToFollowing("cash");
                translateDic.Add("cash", translate.ReadElementContentAsString());
                translate.ReadToFollowing("bank");
                translateDic.Add("bank", translate.ReadElementContentAsString());
                translate.ReadToFollowing("serverStatus");
                translateDic.Add("serverStatus", translate.ReadElementContentAsString());
                translate.ReadToFollowing("IGinformations");
                translateDic.Add("IGinformations", translate.ReadElementContentAsString());
                translate.ReadToFollowing("usefulLink");
                translateDic.Add("usefulLink", translate.ReadElementContentAsString());
                translate.ReadToFollowing("serverMaintenance");
                translateDic.Add("serverMaintenance", translate.ReadElementContentAsString());
                translate.ReadToFollowing("serverLocked");
                translateDic.Add("serverLocked", translate.ReadElementContentAsString());            

                loginButton.Text = translateDic["logIn"];
                registerLink.Text = translateDic["registerLink"];
                loginUsername.Hint = translateDic["username"];
                loginPassword.Hint = translateDic["password"];
                loginRemember.Text = translateDic["remember"];
                newPassword.Text = translateDic["forgotPass"];
                registerMessage.Text = translateDic["registerMsg"];                           
                this.Refresh();
            }
            catch
            {
                languageChoice formLanguage = new languageChoice(communityName, true);

                // Show the laguage choice
                formLanguage.ShowDialog();

                if (File.Exists(appdata + communityName + "/language.lang"))
                {
                    language = File.ReadAllText(appdata + communityName + "/language.lang");
                    loadLanguage();
                }

            }

        }

        void notifView(string msg)
        {
            if (notif == false)
            {
                this.Height += 50;
                registerLink.Location = new Point(registerLink.Location.X, registerLink.Location.Y + 50);
                registerMessage.Location = new Point(registerMessage.Location.X, registerMessage.Location.Y + 50);
                separator1.Location = new Point(separator1.Location.X, separator1.Location.Y + 50);
                separator2.Height += 50;
                loginButton.Location = new Point(loginButton.Location.X, loginButton.Location.Y + 50);
                loginRemember.Location = new Point(loginRemember.Location.X, loginRemember.Location.Y + 50);
                loginUsername.Location = new Point(loginUsername.Location.X, loginUsername.Location.Y + 50);
                loginPassword.Location = new Point(loginPassword.Location.X, loginPassword.Location.Y + 50);
                errorImage.Location = new Point(errorImage.Location.X, errorImage.Location.Y + 25);
                newPassword.Location = new Point(newPassword.Location.X, newPassword.Location.Y + 50);
                errorBox.Visible = true;
                notif = true;
                errorBox.Location = new Point(errorBox.Location.X, errorBox.Location.Y + 50);
            }
            errorBox.Text = msg;
        }

        private void normalView(object sender, EventArgs e)
        {
            this.Height -= 50;
            registerLink.Location = new Point(registerLink.Location.X, registerLink.Location.Y - 50);
            registerMessage.Location = new Point(registerMessage.Location.X, registerMessage.Location.Y - 50);
            separator1.Location = new Point(separator1.Location.X, separator1.Location.Y - 50);
            separator2.Height -= 50;
            loginButton.Location = new Point(loginButton.Location.X, loginButton.Location.Y - 50);
            loginRemember.Location = new Point(loginRemember.Location.X, loginRemember.Location.Y - 50);
            loginUsername.Location = new Point(loginUsername.Location.X, loginUsername.Location.Y - 50);
            loginPassword.Location = new Point(loginPassword.Location.X, loginPassword.Location.Y - 50);
            newPassword.Location = new Point(newPassword.Location.X, newPassword.Location.Y - 50);
            errorImage.Location = new Point(errorImage.Location.X, errorImage.Location.Y - 25);
            errorBox.Visible = false;
            errorBox.Location = new Point(errorBox.Location.X, errorBox.Location.Y - 50);
            notif = false;
        }

        private void maintenanceRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/settings", Method.GET);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());

                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (res.maintenance == "1")
                    {
                        if (res.maintenance_title == "{picture}")
                        {
                            newsImage.Visible = true;
                            newsImage.ImageLocation = res.maintenance_content;
                            newsImage.BringToFront();
                        }
                        else
                        {
                            newsImage.Visible = false;
                            newsTitle.Text = res.maintenance_title;
                            newsContent.Text = res.maintenance_content;
                        }
                    }
                });           
                if (res.maintenance == "0")
                {
                    maintenance = false;
                }
                loaded = false;
            }
            catch
            {

            }
        }

        private void callRefresh(object sender, RunWorkerCompletedEventArgs e)
        {
            if (maintenance == false)
            {
                loginButton.Enabled = true;
                registerLink.Enabled = true;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
                this.Style = MetroColorStyle.Blue;
                checkOptions(null, null);
                this.Refresh();
            }
            else
                maintenanceRefresh.RunWorkerAsync();    
        }

        void launcherUpdate()
        {
            if (!File.Exists("launcherUpdate.exe"))
            {
                notifView(translateDic["errorUpdate"]);
                return;
            }
            try
            {
                loginButton.Enabled = false;
                registerLink.Enabled = false;
                Process update = new Process();
                update.StartInfo.FileName = "launcherUpdate.exe";
                update.StartInfo.Arguments = apiUrl + "games/launcher/launcher.exe" + " \"" + System.Windows.Forms.Application.ExecutablePath + "\" \"" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + "\"";
                update.Start();
                this.Close();
            }
            catch
            {
                notifView(translateDic["updateCancel"]);
            }
        }

        protected string getLauncherMd5()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(System.Windows.Forms.Application.ExecutablePath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }
        private void newPassword_Click(object sender, EventArgs e)
        {
            Process newPass = new Process();
            newPass.StartInfo.FileName = apiUrl + "password/reset";
            newPass.Start();
        }

        private Point MouseDownLocation;

        private void mouse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void mouse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            selectSteamProfile formLanguage = new selectSteamProfile();

            // Show the laguage choice
            formLanguage.ShowDialog();
        }
    }
}
