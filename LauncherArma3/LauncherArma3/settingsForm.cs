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
    public partial class settingsForm : MetroFramework.Forms.MetroForm
    {
        /* GENERAL VARIABLE */

        string serverName;


        public settingsForm(string serveur)
        {
            InitializeComponent();
            serverName = serveur;
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeLanguage_Click(object sender, EventArgs e)
        {
            languageChoice settings = new languageChoice(serverName);

            // Show the laguage choice
            settings.ShowDialog();
        }
    }
}
