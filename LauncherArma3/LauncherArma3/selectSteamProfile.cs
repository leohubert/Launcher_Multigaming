using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LauncherArma3
{
    public partial class selectSteamProfile : MetroFramework.Forms.MetroForm
    {
        /* STEAM */
        string steamDirectory = null;

        public selectSteamProfile()
        {
            InitializeComponent();
        }

        private void selectSteamProfile_Load(object sender, EventArgs e)
        {
           
            MessageBox.Show(steamDirectory);
        }
      
    }
}
