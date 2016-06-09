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

        string serverName;
        string armaDirectory;
        bool onDownload;

        /* VARIABLES */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";


        /* RETURN VARIABLES */
        public bool refreshMods { get; set; }
        public string launchOptions { get; set; }


        public settingsForm(string serveur, string arma, bool download)
        {
            InitializeComponent();
            serverName = serveur;
            armaDirectory = arma;
            onDownload = download;
            this.refreshMods = false;
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/launchOptions"))
                launchParam.Text = File.ReadAllText(appdata + serverName + "/launchOptions");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(appdata + serverName + "/launchOptions"))
                File.Delete(appdata + serverName + "/launchOptions");
            File.WriteAllText(appdata + serverName + "/launchOptions", launchParam.Text);
            this.launchOptions = launchParam.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void changeLanguageButon_Click(object sender, EventArgs e)
        {
            languageChoice settings = new languageChoice(serverName, true);

            // Show the laguage choice
            settings.ShowDialog();

            MetroMessageBox.Show(this, "To apply changes you must restart the launcher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (onDownload == true)
            {
                MetroMessageBox.Show(this, "Download in progress !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Directory.Exists(armaDirectory + "/@" + serverName))
            {
                DialogResult dialogResult = MetroMessageBox.Show(this, "Are you sure ?", "Delete all mods ?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    Directory.Delete(armaDirectory + "/@" + serverName, true);
                    if (File.Exists(appdata + serverName + "/vMod"))
                        File.Delete(appdata + serverName + "/vMod");
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
    }
}
