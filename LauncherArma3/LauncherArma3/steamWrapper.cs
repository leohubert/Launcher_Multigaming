using MetroFramework;
using Steamworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherArma3
{
    public partial class steamWrapper : MetroFramework.Forms.MetroForm
    {
        public string SteamUUID { get; set; }

        public steamWrapper()
        {
            InitializeComponent();
        }

        private bool tryToGetSteamUID(bool showAlerts)
        {
            SteamAPI.Init();
            if (SteamAPI.IsSteamRunning())
            {
                startSteam.Text = "STEAM STARTED !";              
                try
                {
                    this.SteamUUID = SteamUser.GetSteamID().ToString();
                    SteamAPI.Shutdown();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception de)
                {
                    if (showAlerts)
                        MetroMessageBox.Show(this, "Veuillez vous connecter sur Steam.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (showAlerts)
                    MetroMessageBox.Show(this, "Steam n'est toujours pas lancé...", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }

        private void startSteam_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                if (SteamAPI.IsSteamRunning())
                {
                    this.SteamUUID = SteamUser.GetSteamID().ToString();
                    SteamAPI.Shutdown();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.BeginInvoke((MethodInvoker)async delegate
                    {
                    startSteam.Enabled = false;
                    startSteam.Text = "STARTING...";
                    Process.Start("steam://");
                    startSteam.Text = "PLEASE WAIT...";
                    await Task.Delay(10000);
                    while (tryToGetSteamUID(false) == false) {
                        await Task.Delay(2000);
                        }
                    });
                }
            });
            thread.Start();
        }
    }
}
