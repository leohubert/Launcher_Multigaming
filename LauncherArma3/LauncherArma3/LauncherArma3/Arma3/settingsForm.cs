using MetroFramework;
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
    public partial class settingsForm : MetroFramework.Forms.MetroForm
    {
        /* GENERAL VARIABLE */

        string communityName;
        string armaDirectory;
        bool onDownload;
        string serverID;

        /* VARIABLES */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        bool initialized = false;


        /* RETURN VARIABLES */
        public bool refreshMods { get; set; }
        public string launchOptions { get; set; }


        public settingsForm(string serveur, string arma, bool download, string _serverID)
        {
            InitializeComponent();
            communityName = serveur;
            armaDirectory = arma;
            onDownload = download;
            serverID = _serverID;
            this.refreshMods = false;
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(appdata + communityName + "/" + serverID + "/launchOptions"))
                launchParam.Text = File.ReadAllText(appdata + communityName + "/" + serverID + "/launchOptions");
            if (launchParam.Text.Contains("-nosplash") == true)
                noSplash.Checked = true;
            if (launchParam.Text.Contains("-world=empty") == true)
                emptyWorld.Checked = true;
            if (launchParam.Text.Contains("-showScriptErrors") == true)
                showScriptError.Checked = true;
            if (launchParam.Text.Contains("-noPause") == true)
                noPause.Checked = true;
            if (launchParam.Text.Contains("-noLogs") == true)
                noLogs.Checked = true;
            if (launchParam.Text.Contains("-noFilePatching") == true)
                noFilePath.Checked = true;
            if (launchParam.Text.Contains("-window") == true)
                windowed.Checked = true;
            if (launchParam.Text.Contains("-skipIntro") == true)
                skipIntro.Checked = true;
            initialized = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(appdata + communityName + "/" + serverID + "/launchOptions"))
                File.Delete(appdata + communityName + "/" + serverID + "/launchOptions");
            File.WriteAllText(appdata + communityName + "/" + serverID + "/launchOptions", launchParam.Text);
            this.launchOptions = launchParam.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void changeLanguageButon_Click(object sender, EventArgs e)
        {
            using (var changeLang = new languageChoice(communityName, true))
            {
                var result = changeLang.ShowDialog();
                if (result == DialogResult.OK)
                {
                    MetroMessageBox.Show(this, "To apply changes you must restart the launcher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (onDownload == true)
            {
                MetroMessageBox.Show(this, "Download in progress !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Directory.Exists(armaDirectory + "/@" + communityName))
            {
                DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure ?", "Delete all mods ?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    Directory.Delete(armaDirectory + "/@" + communityName, true);
                    if (File.Exists(appdata + communityName + "/vMod"))
                        File.Delete(appdata + communityName + "/vMod");
                    this.refreshMods = true;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Mod not installed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void noSplash_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                if (noSplash.Checked == true)
                    launchParam.Text += " -nosplash";
                else
                    launchParam.Text = launchParam.Text.Replace(" -nosplash", "");
            }            
        }

        private void emptyWorld_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                if (emptyWorld.Checked == true)
                    launchParam.Text += " -world=empty";
                else
                    launchParam.Text = launchParam.Text.Replace(" -world=empty", "");
            }    
            
        }

        private void showScriptError_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                if (showScriptError.Checked == true)
                    launchParam.Text += " -showScriptErrors";
                else
                    launchParam.Text = launchParam.Text.Replace(" -showScriptErrors", "");
            }
        }

        private void noPause_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                if (noPause.Checked == true)
                    launchParam.Text += " -noPause";
                else
                    launchParam.Text = launchParam.Text.Replace(" -noPause", "");
            }
        }

        private void noLogs_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                if (noLogs.Checked == true)
                    launchParam.Text += " -noLogs";
                else
                    launchParam.Text = launchParam.Text.Replace(" -noLogs", "");
            }
        }

        private void noFilePath_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                if (noFilePath.Checked == true)
                    launchParam.Text += " -noFilePatching";
                else
                    launchParam.Text = launchParam.Text.Replace(" -noFilePatching", "");
            }
        }

        private void windowed_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                if (windowed.Checked == true)
                    launchParam.Text += " -window";
                else
                    launchParam.Text = launchParam.Text.Replace(" -window", "");
            }
        }

        private void skipIntro_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized == true)
            {
                if (skipIntro.Checked == true)
                    launchParam.Text += " -skipIntro";
                else
                    launchParam.Text = launchParam.Text.Replace(" -skipIntro", "");
            }
        }
    }
}
