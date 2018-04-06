using LauncherArma3.Properties;
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
using System.Xml;

namespace LauncherArma3
{
    public partial class languageChoice : MetroFramework.Forms.MetroForm
    {
        /* GENERAL OPTIONS */

        string language = "EN";  // Default language
        string serverName;
        bool startLauncher;

        /* GLOBAL VARIABLE */

        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
        int status = 0;
        bool normalyClose = false;

        public languageChoice(string server, bool launcher)
        {
            InitializeComponent();
            serverName = server;
            startLauncher = launcher;
        }

        private void languageChoice_Load(object sender, EventArgs e)
        {
            animation.RunWorkerAsync();
            setLanguage();
        }

        void setLanguage()
        {
           // string translateFile = Properties.Resources.translate;
            XmlReader translate = XmlReader.Create(new StringReader(Resources.translate));

            translate.ReadToFollowing(language);
            translate.ReadToFollowing("languageTitle");
            this.Text = translate.ReadElementContentAsString();
            this.Refresh();
        }

        private void setFrench(object sender, EventArgs e)
        {
            language = "FR";
            setLanguage();
            status = 0;
            setColor("SILVER");
            this.Refresh();
        }

        private void setEnglish(object sender, EventArgs e)
        {
            language = "EN";
            setLanguage();
            status = 0;
            setColor("SILVER");
            this.Refresh();
        }

        private void setDeutch(object sender, EventArgs e)
        {
            language = "DE";
            setLanguage();
            status = 0;
            setColor("SILVER");
            this.Refresh();
        }

        private void setSpain(object sender, EventArgs e)
        {
            language = "SP";
            setLanguage();
            status = 0;
            setColor("SILVER");
            this.Refresh();
        }

        private void setArab(object sender, EventArgs e)
        {
            language = "AR";
            setLanguage();
            status = 0;
            setColor("SILVER");
            this.Refresh();
        }

        private void setJapan(object sender, EventArgs e)
        {
            language = "JP";
            setLanguage();
            status = 0;
            setColor("SILVER");
            this.Refresh();
        }

        void setColor(string color)
        {
            switch (color)
            {
                case "BLUE":
                    this.Style = MetroColorStyle.Blue;
                    break;
                case "GREEN":
                    this.Style = MetroColorStyle.Green;
                    break;
                case "WHITE":
                    this.Style = MetroColorStyle.White;
                    break;
                case "RED":
                    this.Style = MetroColorStyle.Red;
                    break;
                case "BLACK":
                    this.Style = MetroColorStyle.Black;
                    break;
                case "PINK":
                    this.Style = MetroColorStyle.Pink;
                    break;
                case "YELLOW":
                    this.Style = MetroColorStyle.Yellow;
                    break;
                case "PURPLE":
                    this.Style = MetroColorStyle.Purple;
                    break;
                case "BROWN":
                    this.Style = MetroColorStyle.Brown;
                    break;
                case "SILVER":
                    this.Style = MetroColorStyle.Silver;
                    break;
                case "ORANGE":
                    this.Style = MetroColorStyle.Orange;
                    break;
            }
        }

        void animationFrench()
        {
            switch (status)
            {
                case 0:
                    setColor("BLUE");
                    break;
                case 1:
                    setColor("WHITE");
                    break;
                case 2:
                    setColor("RED");
                    break;
                case 3:
                    setColor("SILVER");
                    break;
            }
        }

        void animationEnglish()
        {
            switch (status)
            {
                case 0:
                    setColor("RED");
                    break;
                case 1:
                    setColor("BLUE");
                    break;
                case 2:
                    setColor("WHITE");
                    break;
                case 3:
                    setColor("SILVER");
                    break;
            }
        }

        void animationDeutch()
        {
            switch (status)
            {
                case 0:
                    setColor("BLACK");
                    break;
                case 1:
                    setColor("RED");
                    break;
                case 2:
                    setColor("YELLOW");
                    break;
                case 3:
                    setColor("SILVER");
                    break;
            }
        }

        void animationSpain()
        {
            switch (status)
            {
                case 0:
                    setColor("RED");
                    break;
                case 1:
                    setColor("YELLOW");
                    break;
                case 2:
                    setColor("RED");
                    break;
                case 3:
                    setColor("SILVER");
                    break;
            }
        }

        void animationArab()
        {
            switch (status)
            {
                case 0:
                    setColor("GREEN");
                    break;
                case 1:
                    setColor("WHITE");
                    break;
                case 2:
                    setColor("GREEN");
                    break;
                case 3:
                    setColor("SILVER");
                    break;
            }
        }
        void animationJapan()
        {
            switch (status)
            {
                case 0:
                    setColor("WHITE");
                    break;
                case 1:
                    setColor("RED");
                    break;
                case 2:
                    setColor("WHITE");
                    break;
                case 3:
                    setColor("SILVER");
                    break;
            }
        }

        private void animation_DoWork(object sender, DoWorkEventArgs e)
        {
            if (status == 0)
                System.Threading.Thread.Sleep(500);
            switch (language)
            {
                case "FR":
                    animationFrench();
                    break;
                case "EN":
                    animationEnglish();
                    break;
                case "DE":
                    animationDeutch();
                    break;
                case "SP":
                    animationSpain();
                    break;
                case "AR":
                    animationArab();
                    break;
                case "JP":
                    animationJapan();
                    break;
            }
            System.Threading.Thread.Sleep(500);
            if (status > 2)
                status = 0;
            else
                status++;
        }

        private void refresh(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Refresh();
            animation.RunWorkerAsync();
        }

        private void frenchFlag_Click(object sender, EventArgs e)
        {
            File.WriteAllText(appdata + serverName + "/language.lang", "FR");
            normalyClose = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void englishFlag_Click(object sender, EventArgs e)
        {
            File.WriteAllText(appdata + serverName + "/language.lang", "EN");
            normalyClose = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void germanFlag_Click(object sender, EventArgs e)
        {
            File.WriteAllText(appdata + serverName + "/language.lang", "DE");
            normalyClose = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void spainFlag_Click(object sender, EventArgs e)
        {
            File.WriteAllText(appdata + serverName + "/language.lang", "SP");
            normalyClose = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }    

        private void arabFlag(object sender, EventArgs e)
        {
            File.WriteAllText(appdata + serverName + "/language.lang", "AR");
            normalyClose = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void japanFlag_Click(object sender, EventArgs e)
        {
            File.WriteAllText(appdata + serverName + "/language.lang", "JP");
            normalyClose = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void close(object sender, FormClosedEventArgs e)
        {
            if (normalyClose == false)
            {
                if (startLauncher == false)
                    Environment.Exit(42);
            }
        }
    }
}
