using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Globalization;
using System.Threading;
using System.Net.NetworkInformation;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;

namespace Launcher_Arma3
{

    public partial class Form2 : Form
    {

        string language;
        string appdata;
        string dest_options;
        string file_username;
        string file_a3options;
        string file_language;

        public string[] UserNames { get; private set; }
         
        public Form2(string value, string value2, string value3, string value4, string value5, string value6)
        {

            InitializeComponent();
            language = value;
            appdata = value2;
            dest_options = value3;
            file_username = value4;
            file_a3options = value5;
            file_language = value6;
        }


    
        private void Form2_Load(object sender, EventArgs e)
        {

            
          
            // Change the language form */* Change la langue du Form
            if (!Change_Lang.IsBusy)
            {
                Change_Lang.RunWorkerAsync();
            }
          
           if (!Directory.Exists(appdata + dest_options ))
           {
               Directory.CreateDirectory(appdata + dest_options);
           }


        //Load Options Bouton
           if (File.Exists(appdata + dest_options + "\\" + file_username)) 
           {
               string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_username);
               TextBox_User.Text = lines[0];
               if (lines[1] == "True")
               {
                   Toggle_User.Toggled = true;
               }
           }
           if (File.Exists(appdata + dest_options + "\\" + file_a3options))
           {
               string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_a3options);
               TextBox_Options.Text = lines[0];
               if (lines[1] == "True")
               {
                   Toggle_Options.Toggled = true;
               }
           }

        
  
  
        }

        private void iTalk_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Language_Chose.Text == "English")
            {
                language = "EN";
                if (!Change_Lang.IsBusy)
                {
                    Change_Lang.RunWorkerAsync();
                }

            }
            if (Language_Chose.Text == "Français")
            {
                language = "FR";
                if (!Change_Lang.IsBusy)
                {
                    Change_Lang.RunWorkerAsync();
                }
         
            }
            if (Language_Chose.Text == "German")
            {
                language = "AL";
                if (!Change_Lang.IsBusy)
                {
                    Change_Lang.RunWorkerAsync();
                }
            }
            if (Language_Chose.Text == "Italiano")
            {
                language = "IT";
                if (!Change_Lang.IsBusy)
                {
                    Change_Lang.RunWorkerAsync();
                }
            }
            if (Language_Chose.Text == "中国")
            {
                language = "CH";
                if (!Change_Lang.IsBusy)
                {
                    Change_Lang.RunWorkerAsync();
                }
            }


            File.WriteAllText(appdata + dest_options + "\\" + file_language, Language_Chose.Text + Environment.NewLine + language); 
        }



        private void iTalk_Icon_Tick1_Click(object sender, EventArgs e)
        {
            this.UserNames = language.Split(new[] { ',' }, 100);
            this.Hide();
   
        }

        private void Change_Lang_DoWork(object sender, DoWorkEventArgs e)
        {
            // Open XML doc */* Ouvre le fichier XML
            XDocument xmlDoc = XDocument.Load(Properties.Resources.Translate_server);

            // Search translate */* Cherche la traduction
            var tr_close = xmlDoc.Descendants("settings").Elements(language).Elements("Close").Select(r => r.Value).ToArray();
            var tr_language = xmlDoc.Descendants("settings").Elements(language).Elements("Language").Select(r => r.Value).ToArray();
            var tr_settings = xmlDoc.Descendants("settings").Elements(language).Elements("Options").Select(r => r.Value).ToArray();
            var tr_username = xmlDoc.Descendants("settings").Elements(language).Elements("UserName").Select(r => r.Value).ToArray();
            var tr_launchoptions = xmlDoc.Descendants("settings").Elements(language).Elements("LaunchOptions").Select(r => r.Value).ToArray();
            var tr_launcher = xmlDoc.Descendants("settings").Elements(language).Elements("Launcher").Select(r => r.Value).ToArray();
            


            string tra_language = string.Join(",", tr_language);
            string tra_username = string.Join(",", tr_username);
            string tra_settings = string.Join(",", tr_settings);
            string tra_launchoptions = string.Join(",", tr_launchoptions);
            string tra_close = string.Join(",", tr_close);
            string tra_launcher = string.Join(",", tr_launcher);


            // Change bouton text */* Change le text des boutons 
            monoFlat_ThemeContainer1.Text = tra_launcher + " " + tra_settings;
            Group_UserName.Text = tra_username;
            Language_Chose.Text = tra_language;
            Group_Options.Text = tra_launchoptions;
            Close_Bouton.Text = tra_close;
        }

        private void UserName_ChangeText(object sender, EventArgs e)
        {
            File.WriteAllText(appdata + dest_options + "\\" + file_username, TextBox_User.Text + Environment.NewLine + Toggle_User.Toggled.ToString()); 
        }

        private void User_Toggle()
        {
            File.WriteAllText(appdata + dest_options + "\\" + file_username, TextBox_User.Text + Environment.NewLine + Toggle_User.Toggled.ToString());               
        }

        private void StartOption_Text(object sender, EventArgs e)
        {
            File.WriteAllText(appdata + dest_options + "\\" + file_a3options, TextBox_Options.Text + Environment.NewLine + Toggle_Options.Toggled.ToString()); 
        }

        private void Toggle_Option()
        {
            File.WriteAllText(appdata + dest_options + "\\" + file_a3options, TextBox_Options.Text + Environment.NewLine + Toggle_Options.Toggled.ToString()); 
        }


    }
}
