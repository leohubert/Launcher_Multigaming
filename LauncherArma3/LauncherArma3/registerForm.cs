using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherArma3
{
    public partial class registerForm : MetroFramework.Forms.MetroForm
    {
        /* GENERAL OPTIONS */

        string serverName;
        string apiUrl;
        string webSite;

        /* ANOTHER VARIABLE */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        bool notif = false;
        string notifStyle = null;

        /* TRANSLATE */
        Dictionary<string, string> translateDic = new Dictionary<string, string>();

        public registerForm(string server, string api, string website, Dictionary<string, string> translate)
        {
            InitializeComponent();
            serverName = server;
            apiUrl = api;
            webSite = website;
            translateDic = translate;
        }

        private void registerForm_Load(object sender, EventArgs e)
        {
            registerButton.Text = translateDic["register"];
            registerEmail.Hint = translateDic["email"];
            registerUsername.Hint = translateDic["username"];
            registerPass.Hint = translateDic["password"];
            registerPassConfirm.Hint = translateDic["passwordConfirm"];
            loginLink.Text = translateDic["logIn"];
            loginMessage.Text = translateDic["loginMsg"];
        }

        private void registerLink_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var client = new RestClient(apiUrl);

            var request = new RestRequest("api/user", Method.POST);

            request.AddHeader("Accept", "application/json");

            request.AddParameter("launcher", 1);
            request.AddParameter("username", registerUsername.Text);
            request.AddParameter("email", registerEmail.Text);
            request.AddParameter("password", registerPass.Text);
            request.AddParameter("password_confirmation", registerPassConfirm.Text);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            string message = res.msg;

            if (res.status == "42")
            {
                notifView("success", message);
            }
            else
            {
                notifView("error", message);
            }
        }

        void notifView(string type, string msg)
        {
            if (notifStyle != null && notifStyle != type)
                normalView(this, null);
            if (notif == false)
            {
                this.Height += 50;
                registerEmail.Location = new Point(registerEmail.Location.X, registerEmail.Location.Y + 50);
                registerUsername.Location = new Point(registerUsername.Location.X, registerUsername.Location.Y + 50);
                registerPass.Location = new Point(registerPass.Location.X, registerPass.Location.Y + 50);
                registerPassConfirm.Location = new Point(registerPassConfirm.Location.X, registerPassConfirm.Location.Y + 50);
                registerButton.Location = new Point(registerButton.Location.X, registerButton.Location.Y + 50);
                separator.Location = new Point(separator.Location.X, separator.Location.Y + 50);
                loginLink.Location = new Point(loginLink.Location.X, loginLink.Location.Y + 50);
                loginMessage.Location = new Point(loginMessage.Location.X, loginMessage.Location.Y + 50);
                if (type == "success")
                {
                    notifStyle = "success";
                    successBox.Visible = true;
                    successBox.Location = new Point(successBox.Location.X, successBox.Location.Y + 50);
                }
                if (type == "error")
                {
                    notifStyle = "error";
                    errorBox.Visible = true;
                    errorBox.Location = new Point(errorBox.Location.X, errorBox.Location.Y + 50);
                }
                notif = true;
            }
            errorBox.Text = msg;
            successBox.Text = msg;
        }

        private void normalView(object sender, EventArgs e)
        {
            this.Height -= 50;
            registerEmail.Location = new Point(registerEmail.Location.X, registerEmail.Location.Y - 50);
            registerUsername.Location = new Point(registerUsername.Location.X, registerUsername.Location.Y - 50);
            registerPass.Location = new Point(registerPass.Location.X, registerPass.Location.Y - 50);
            registerPassConfirm.Location = new Point(registerPassConfirm.Location.X, registerPassConfirm.Location.Y - 50);
            registerButton.Location = new Point(registerButton.Location.X, registerButton.Location.Y - 50);
            separator.Location = new Point(separator.Location.X, separator.Location.Y - 50);
            loginLink.Location = new Point(loginLink.Location.X, loginLink.Location.Y - 50);
            loginMessage.Location = new Point(loginMessage.Location.X, loginMessage.Location.Y - 50);
            if (notifStyle == "error")
            {
                errorBox.Visible = false;
                errorBox.Location = new Point(errorBox.Location.X, errorBox.Location.Y - 50);
            }
            if (notifStyle == "success")
            {
                successBox.Visible = false;
                successBox.Location = new Point(successBox.Location.X, successBox.Location.Y - 50);
            }
            notifStyle = null;
            notif = false;
        }

    }
}
