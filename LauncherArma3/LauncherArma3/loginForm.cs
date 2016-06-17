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

        string serverName;
        string apiUrl;
        string webSite;
        string ftp_url;
        string ftp_user;
        string ftp_pass;

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

        /* TRANSLATE PART */

        XmlReader translate = XmlReader.Create(new StringReader(Resources.translate));
        Dictionary<string, string> translateDic = new Dictionary<string, string>();


        public loginForm(string server, string api, string website, string ftpUrl, string ftpUser, string ftpPass, bool mod)
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
            serverName = server;
            apiUrl = api;
            webSite = website;
            ftp_url = ftpUrl;
            ftp_user = ftpUser;
            ftp_pass = ftpPass;
            modDev = mod;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/token.bin2hex"))
            {
                sessionToken = File.ReadAllText(appdata + serverName + "/token.bin2hex");
            }
            if (File.Exists(appdata + serverName + "/language.lang"))
            {
                language = File.ReadAllText(appdata + serverName + "/language.lang");
                loadLanguage();
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
                vLast = res.vmod;
                if (res.login == "0")
                {
                    sessionToken = null;
                    launcherMain launcher = new launcherMain(serverName, apiUrl, webSite, sessionToken, ftp_url, ftp_user, ftp_pass, vLast);

                    // Show the laguage choice
                    this.Visible = false;
                    launcher.ShowDialog();                    
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
                                File.WriteAllText(appdata + serverName + "/token.bin2hex", token);
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
                launcherMain launcher = new launcherMain(serverName, apiUrl, webSite, sessionToken, ftp_url, ftp_user, ftp_pass, vLast);
                startLauncher = false;
                loginUsername.Text = "";
                loginPassword.Text = "";
                loginRemember.Checked = false;
                this.Visible = false;
                launcher.ShowDialog();
                this.Visible = true;
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
                    // Login
                    launcherMain launcher = new launcherMain(serverName, apiUrl, webSite, sessionToken, ftp_url, ftp_user, ftp_pass, vLast);
                    startLauncher = false;
                    this.Visible = false;
                    launcher.ShowDialog();
                    this.Visible = true;
                }
                else
                {
                    string msg = res.message;
                    notifView(msg);
                    if (File.Exists(appdata + serverName + "/token.bin2hex"))
                        File.Delete(appdata + serverName + "/token.bin2hex");
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
            registerForm register = new registerForm(serverName, apiUrl, webSite, translateDic);

            // Show the laguage choice
            register.ShowDialog();
        }

        void loadLanguage()
        {
            try
            {

                translate.ReadToFollowing(language);
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
                languageChoice formLanguage = new languageChoice(serverName, true);

                // Show the laguage choice
                formLanguage.ShowDialog();

                if (File.Exists(appdata + serverName + "/language.lang"))
                {
                    language = File.ReadAllText(appdata + serverName + "/language.lang");
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
                update.StartInfo.Arguments = apiUrl + "api/arma3/launcher/download" + " \"" + System.Windows.Forms.Application.ExecutablePath + "\" \"" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + "\"";
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

    }
}
