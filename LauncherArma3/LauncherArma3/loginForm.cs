using LauncherArma3.Properties;
using MaterialSkin;
using MetroFramework;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using static System.Net.Mime.MediaTypeNames;

namespace LauncherArma3
{


    public partial class loginForm : MetroFramework.Forms.MetroForm
    {

        /* GENERAL OPTIONS */

        string serverName;
        string apiUrl;
        string webSite;

        /* ANOTHER VARIABLE */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        private readonly MaterialSkinManager materialSkinManager;
        string sessionToken;
        string language;
        bool internet;
        bool loaded = false;
        bool notif = false;

       XmlReader translate = XmlReader.Create(new StringReader(Resources.translate));


        public loginForm(string server, string api, string website)
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
            serverName = server;
            apiUrl = api;
            webSite = website;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/token.bin2hex"))
                sessionToken = File.ReadAllText(appdata + serverName + "/token.bin2hex");
            if (File.Exists(appdata + serverName + "/language.lang"))
            {
                language = File.ReadAllText(appdata + serverName + "/language.lang");
                setLanguage();
            }
        }

        private void checkOptions(object sender, EventArgs e)
        {
            if (loaded == true)
                return;
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/options", Method.GET);

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                dynamic res = JObject.Parse(content.ToString());

                newsTitle.Text = res.msg_title;
                newsContent.Text = res.msg_content;
                loaded = true;
                if (res.maintenance == "1")
                {
                    newsTitle.Text = "Maintenance en cours !";
                    newsContent.Text = res.maintenance_msg;
                    loginButton.Enabled = false;
                    registerLink.Enabled = false;
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Orange400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
                    this.Style = MetroColorStyle.Orange;
                    return;
                }
                if (res.login == "0")
                {
                    sessionToken = null;
                    launcherMain launcher = new launcherMain(serverName, apiUrl, webSite, sessionToken);

                    // Show the laguage choice
                    this.Visible = false;
                    launcher.ShowDialog();
                    this.Visible = true;

                }
                if (res.register == "0")
                {
                    registerLink.Enabled = false;
                    registerMessage.Text = "Register disabled";
                }
                if (sessionToken != null)
                {
                    loginWithToken();
                }
                internet = true;
            }
            catch
            {
                this.Style = MetroColorStyle.Red;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
                internet = false;
                newsTitle.Text = "Error 404 internet not found !";
                notifView("Internet not found !");
                errorImage.BringToFront();
            }

        }


        private void loginButton_Click(object sender, EventArgs e)
        {
            if (internet == false)
            {
                notifView("Internet not found !");
                return;
            }
            var client = new RestClient(apiUrl);

            var request = new RestRequest("api/user/login", Method.POST);

            request.AddParameter("username", loginUsername.Text);
            request.AddParameter("password", loginPassword.Text);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            if (res.status == "42")
            {
                sessionToken = res.user.token;
                if (loginRemember.Checked == true)
                {
                    string token = res.user.token;
                    File.WriteAllText(appdata + serverName + "/token.bin2hex", token);
                }
                launcherMain launcher = new launcherMain(serverName, apiUrl, webSite, sessionToken);

                // Reset form
                loginUsername.Text = "";
                loginPassword.Text = "";
                loginRemember.Checked = false;
                this.Visible = false;
                launcher.ShowDialog();
                this.Visible = true;
            }
            else
            {
                // MessageBox.Show("Pass or email not good !");
                string message = res.msg;
                notifView(message);
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

            if (res.status == "42")
            {
                launcherMain launcher = new launcherMain(serverName, apiUrl, webSite, sessionToken);

                // Show the laguage choice
                this.Visible = false;
                launcher.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("error token");
                if (File.Exists(appdata + serverName + "/token.bin2hex"))
                    File.Delete(appdata + serverName + "/token.bin2hex");
            }
        }

        private void registerLink_Click(object sender, EventArgs e)
        {
            if (internet == false)
            {
                notifView("Internet not found !");
                return;
            }
            registerForm register = new registerForm(serverName, apiUrl, webSite);

            // Show the laguage choice
            register.ShowDialog();
        }

        string getTranslate(string search)
        {
            string result = "null";
            return (result);
        }

        void setLanguage()
        {
            try
            {               
                loginButton.Text = getTranslate("logIn");
                registerLink.Text = getTranslate("registerLink");
                loginUsername.Hint = getTranslate("username");
                loginPassword.Hint = getTranslate("password");
                loginRemember.Text = getTranslate("remember");
              

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
                    setLanguage();
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
            errorImage.Location = new Point(errorImage.Location.X, errorImage.Location.Y - 25);
            errorBox.Visible = false;
            errorBox.Location = new Point(errorBox.Location.X, errorBox.Location.Y - 50);
            notif = false;
        }
    }
}
