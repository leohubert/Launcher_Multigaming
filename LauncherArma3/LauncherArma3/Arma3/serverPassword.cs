using MetroFramework;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherArma3.Arma3
{
    public partial class serverPassword : MetroFramework.Forms.MetroForm
    {

        /* USEFULL VARIABLE */
        string apiUrl;
        string serverID;

        public bool access { get; set; }
        public string password { get; set; }

        public serverPassword(string _apiUrl, string _serverID)
        {
            InitializeComponent();
            apiUrl = _apiUrl;
            serverID = _serverID;
            this.access = false;
        }

        private void serverPassword_Load(object sender, EventArgs e)
        {
            this.password = null;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    var client = new RestClient(apiUrl);

                    var request = new RestRequest("api/server/auth", Method.POST);

                    request.AddParameter("id", serverID);
                    request.AddParameter("password", serverPass.Text);

                    IRestResponse response = client.Execute(request);
                    var content = response.Content;

                    dynamic res = JObject.Parse(content.ToString());

                    if (res.status == "42")
                    {
                        this.DialogResult = DialogResult.OK;
                        this.password = res.password;
                        this.access = true;
                        this.Close();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Error with password !", "You have entered a wrong password.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {

                }
            });
            thread.Start();
        }
    }
}
