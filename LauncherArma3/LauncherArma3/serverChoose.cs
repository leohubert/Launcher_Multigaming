using MaterialSkin;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherArma3
{
    public partial class serverChoose : MetroFramework.Forms.MetroForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        /* GLOBAL VARIABLES */
        string apiUrl;
        string communityName;
        string appdata;

        /* ANOTHER VARIABLE */
        string[] serverName_list;
        string[] serverIP_list;
        string[] serverPort_list;
        string[] serverid_list;
        string[] serverGame_list;

        public string currentServerName { get; set; }
        public string currentServerIP { get; set; }
        public string currentServerid { get; set; }
        public string currentServerGame { get; set; }

        Dictionary<string, string> translateDic = new Dictionary<string, string>();

        public serverChoose(string _apiUrl, string _communityName, Dictionary<string, string> _translateDic, string _appdata)
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
            apiUrl = _apiUrl;
            communityName = _communityName;
            translateDic = _translateDic;
            appdata = _appdata;
        }

        private void serverChoose_Load(object sender, EventArgs e)
        {
            listServers();
            if (File.Exists(appdata + communityName + "/autoConnect"))
            {
                this.currentServerid = File.ReadAllText(appdata + communityName + "/autoConnect");
                int i = 0;
                int total = serverName_list.Length;

                while (i < total)
                {                  
                    if (serverid_list[i] == this.currentServerid)
                    {
                        this.currentServerGame = serverGame_list[i];
                        this.currentServerName = serverName_list[i];
                        this.currentServerIP = serverIP_list[i] + ":" + serverPort_list[i];
                        chooseServer.SelectedIndex = i + 1;
                        switch (serverGame_list[i])
                        {
                            case "arma3":
                                arma3Server(i);
                                break;
                        }
                        if (autoConnect.Checked == true)
                        {
                            if (File.Exists(appdata + communityName + "/autoConnect"))
                                File.Delete(appdata + communityName + "/autoConnect");
                            File.WriteAllText(appdata + communityName + "/autoConnect", this.currentServerid);
                        }
                    }
                    i++;
                }
                autoConnect.Checked = true;
            }
        }

        void listServers ()
        {
            /* VARIABLE DECLARATION */
            int total;
            int i = 0;
            string tmp;

            var client = new RestClient(apiUrl);
            var request = new RestRequest("api/server/list", Method.GET);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic res = JObject.Parse(content.ToString());

            if (res.status == "42")
            {
                total = res.total;
                serverName_list = new string[total];
                serverIP_list = new string[total];
                serverPort_list = new string[total];
                serverid_list = new string[total];
                serverGame_list = new string[total];
                while (i < total)
                {
                    chooseServer.Items.Add(res.servers[i].game + " | " + res.servers[i].name);
                    serverName_list[i] = res.servers[i].name;
                    serverid_list[i] = res.servers[i].id;
                    serverIP_list[i] = res.servers[i].ip;
                    serverPort_list[i] = res.servers[i].port;
                    serverGame_list[i] = res.servers[i].game;
                    i++;
                }
            }
            else
            {

            }
        }

        private void chooseServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            int total = serverName_list.Length;

            while (i < total)
            {
                if (chooseServer.SelectedItem.ToString() == serverGame_list[i] + " | " + serverName_list[i])
                {
                    this.currentServerid = serverid_list[i];
                    this.currentServerGame = serverGame_list[i];
                    this.currentServerName = serverName_list[i];
                    this.currentServerIP = serverIP_list[i] + ":" + serverPort_list[i];
                    switch (serverGame_list[i])
                    {
                        case "arma3":
                            arma3Server(i);
                            break;                       
                    }
                    if (autoConnect.Checked == true)
                    {
                        if (File.Exists(appdata + communityName + "/autoConnect"))
                            File.Delete(appdata + communityName + "/autoConnect");
                        File.WriteAllText(appdata + communityName + "/autoConnect", this.currentServerid);
                    }
                }
                i++;
            }
        }

        void arma3Server(int i)
        {
            try
            {
                var client = new RestClient(apiUrl);

                var request = new RestRequest("api/server/status/get", Method.POST);

                request.AddParameter("name", serverName_list[i]);
                request.AddParameter("arma_ip", serverIP_list[i] + ":" + serverPort_list[i]);

                IRestResponse response = client.Execute(request);
                var content = response.Content;


                dynamic res = JObject.Parse(content.ToString());


                if (res.status == "42")
                {
                    if (res.online == true)
                    {
                        serverStatus.Text = translateDic["online"];
                        serverName.Text = serverName_list[i];
                        serverStatus.ForeColor = Color.Green;
                        serverMap.Text = res.server_map;
                        serverPlayers.Text = res.server_onlineplayers + " / " + res.server_maxplayers;
                        serverMission.Text = res.server_mission;
                    }
                    else
                    {
                        serverStatus.Text = translateDic["offline"];
                        serverName.Text = serverName_list[i];
                        serverStatus.ForeColor = Color.Red;
                        serverMap.Text = translateDic["notFound"];
                        serverPlayers.Text = translateDic["notFound"];
                        serverMission.Text = translateDic["notFound"];
                    }
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void autoConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (autoConnect.Checked == true)
            {
                if (File.Exists(appdata + communityName + "/autoConnect"))
                    File.Delete(appdata + communityName + "/autoConnect");
                File.WriteAllText(appdata + communityName + "/autoConnect", this.currentServerid);
            }
            else
            {
                if (File.Exists(appdata + communityName + "/autoConnect"))
                    File.Delete(appdata + communityName + "/autoConnect");
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (chooseServer.SelectedItem.ToString() == "Choose a server / game")
            {
                MessageBox.Show("Choose a server before !");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
