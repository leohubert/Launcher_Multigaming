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
// [CREDIT][DO NOT REMOVE]
//
// This module was written by HUBERT Léo 
//
// Copyright HUBERT Léo © 2014 - 2015
//
// [CREDIT][DO NOT REMOVE]
namespace Launcher_Arma3
{

    public partial class Form2 : Form
    {

        string language;
        string appdata;
        string modsname;
        bool download_progress;
        bool music_intro;
        bool TaskForce_Statut;
        bool TaskForce_install;
        int music_volume;
        string dteamspeak;
        int counter_task = 0;
        string ftp;
        int list_task;
        string line;
        int progress_task = 0;
        string error_xml;
        int error_code;
        string error_message;
        bool music_play;

        string dest_arma;
        string dest_options;
        string dest_taskforce;

        string file_username;
        string file_a3options;
        string file_language;
        string file_options;
        string file_teamspeak;
        string file_listtask;
        string file_arma3;
        string file_translate;

        string Trans_Progress;
        string Trans_WarningMsg;
        string Trans_Loading;
        string Trans_TaskFinish;

        // Traduction error message 

        string Trans_error50;
        string Trans_error51;
        string Trans_error52;
        string Trans_error401;

        //Serveur Vocal
        string servervocal; 

        string ipmumble;
        string portmumble;
        string passmumble; 
        string ipTS; 
        string portTS; 
        string passTS;

      
   
        public string[] UserNames { get; private set; }
         
        public Form2(string value, string value2, string value3, string value4, string value5, string value6, string value7, 
                     string value8, string value9, bool value10, int value11, bool value12, bool value12_1, bool value13, string value14,
                     string value15, string value16, string value17, string value18, string value19, string value20, string value21,
                     string value22, string value23, string value24,string value25,string value26, string value27)
        {

            InitializeComponent();
            language = value;
            appdata = value2;
            dest_options = value3;
            file_username = value4;
            file_a3options = value5;
            file_language = value6;
            file_options = value7;
            dest_arma = value8;
            modsname = value9;
            download_progress = value10;
            music_volume = value11;
            music_intro = value12;
            music_play = value12_1;
            TaskForce_Statut = value13;
            file_teamspeak = value14;
            file_listtask = value15;
            dest_taskforce = value16;
            ftp = value17;
            file_arma3 = value18;
            error_xml = value19;
            servervocal = value20;
            ipmumble = value21;
            portmumble = value22;
            passmumble = value23;
            ipTS= value24;
            portTS = value25;
            passTS = value26;
            file_translate = value27;
        }


    
        private void Form2_Load(object sender, EventArgs e)
        {

            if (!TaskForce_Statut)
            {
                Group_TaskForce.Visible = false;
            }
            
          
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
           if (File.Exists(appdata + dest_options + "\\" + file_options))
           {
               string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_options);
               if (lines[0] == "True")
               {
                   Toggle_StartArma.Toggled = true;
               }

               if (music_intro != false)
               {
                   if (lines[1] == "True")
                   {
                       Toggle_Sound.Toggled = true;
                   }
               }
               else
               {
                   Toggle_Sound.Toggled = false;
                   Toggle_Sound.Enabled = false;
                   TrackBar_Sound.Enabled = false;
                   Label_Sound.ForeColor = Color.LightCoral;
               }
              
               TrackBar_Sound.Value = int.Parse(lines[2]);
           }
           else
           {
               Toggle_Sound.Toggled = music_play;
               TrackBar_Sound.Value = music_volume;
           }

        
  
  
        }

        // [CREDIT][DO NOT REMOVE]
        //
        // This module was written by HUBERT Léo 
        //
        // Copyright HUBERT Léo © 2014 - 2015
        //
        // [CREDIT][DO NOT REMOVE]

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



        // [CREDIT][DO NOT REMOVE]
        //
        // This module was written by HUBERT Léo 
        //
        // Copyright HUBERT Léo © 2014 - 2015
        //
        // [CREDIT][DO NOT REMOVE]


        private void iTalk_Icon_Tick1_Click(object sender, EventArgs e)
        {
            if (TaskForce_install)
            {

                MessageBox.Show("Error #52 | " + Trans_error52);
                return;
            }

            this.UserNames = language.Split(new[] { ',' }, 100);
            this.Hide();
   
        }

        private void Change_Lang_DoWork(object sender, DoWorkEventArgs e)
        {
            // Open XML doc */* Ouvre le fichier XML
            XDocument xmlDoc = XDocument.Load(ftp + file_translate);

            // Search translate */* Cherche la traduction
            var tr_close = xmlDoc.Descendants("settings").Elements(language).Elements("Close").Select(r => r.Value).ToArray();
            var tr_language = xmlDoc.Descendants("settings").Elements(language).Elements("Language").Select(r => r.Value).ToArray();
            var tr_settings = xmlDoc.Descendants("settings").Elements(language).Elements("Options").Select(r => r.Value).ToArray();
            var tr_username = xmlDoc.Descendants("settings").Elements(language).Elements("UserName").Select(r => r.Value).ToArray();
            var tr_launchoptions = xmlDoc.Descendants("settings").Elements(language).Elements("LaunchOptions").Select(r => r.Value).ToArray();
            var tr_launcher = xmlDoc.Descendants("settings").Elements(language).Elements("Launcher").Select(r => r.Value).ToArray();
            var tr_startarma = xmlDoc.Descendants("settings").Elements(language).Elements("StartArma").Select(r => r.Value).ToArray();
            var tr_music = xmlDoc.Descendants("settings").Elements(language).Elements("Music").Select(r => r.Value).ToArray();
            var tr_reset = xmlDoc.Descendants("settings").Elements(language).Elements("Reset").Select(r => r.Value).ToArray();
            var tr_warningzone = xmlDoc.Descendants("settings").Elements(language).Elements("WarningZone").Select(r => r.Value).ToArray();
            var tr_warningmsg = xmlDoc.Descendants("settings").Elements(language).Elements("WarningMsg").Select(r => r.Value).ToArray();
            var tr_warninglabel = xmlDoc.Descendants("settings").Elements(language).Elements("WarningLabel").Select(r => r.Value).ToArray();
            var tr_taskfinish = xmlDoc.Descendants("settings").Elements(language).Elements("TaskFinish").Select(r => r.Value).ToArray();
            var tr_loading = xmlDoc.Descendants("settings").Elements(language).Elements("Loading").Select(r => r.Value).ToArray();
            var tr_taskforce = xmlDoc.Descendants("settings").Elements(language).Elements("TaskForce").Select(r => r.Value).ToArray();
            var tr_install = xmlDoc.Descendants("settings").Elements(language).Elements("Install").Select(r => r.Value).ToArray();
            var tr_lang = xmlDoc.Descendants("settings").Elements(language).Elements("Lang").Select(r => r.Value).ToArray();
            var tr_disable = xmlDoc.Descendants("settings").Elements(language).Elements("Disable").Select(r => r.Value).ToArray();


            var tr_progress = xmlDoc.Descendants(language).Elements("Progress").Select(r => r.Value).ToArray();


            var tr_erreur50 = xmlDoc.Descendants(error_xml).Elements(language).Elements("error50").Select(r => r.Value).ToArray();
            var tr_erreur51 = xmlDoc.Descendants(error_xml).Elements(language).Elements("error51").Select(r => r.Value).ToArray();
            var tr_erreur52 = xmlDoc.Descendants(error_xml).Elements(language).Elements("error52").Select(r => r.Value).ToArray();
            var tr_erreur401 = xmlDoc.Descendants(error_xml).Elements(language).Elements("error401").Select(r => r.Value).ToArray();
            var tr_erreur405 = xmlDoc.Descendants(error_xml).Elements(language).Elements("error401").Select(r => r.Value).ToArray();

            string tra_erreur405 = string.Join(",", tr_erreur405);
            string tra_erreur401 = string.Join(",", tr_erreur401);
            string tra_erreur50 = string.Join(",", tr_erreur50);
            string tra_erreur51 = string.Join(",", tr_erreur51);
            string tra_erreur52 = string.Join(",", tr_erreur52);


            string tra_language = string.Join(",", tr_language);
            string tra_username = string.Join(",", tr_username);
            string tra_settings = string.Join(",", tr_settings);
            string tra_launchoptions = string.Join(",", tr_launchoptions);
            string tra_close = string.Join(",", tr_close);
            string tra_launcher = string.Join(",", tr_launcher);
            string tra_startarma = string.Join(",", tr_startarma);
            string tra_music = string.Join(",", tr_music);
            string tra_reset = string.Join(",", tr_reset);
            string tra_warningzone = string.Join(",", tr_warningzone);
            string tra_warningmsg = string.Join(",", tr_warningmsg);
            string tra_warninglabel = string.Join(",", tr_warninglabel);
            string tra_loading = string.Join(",", tr_loading);
            string tra_taskfinish = string.Join(",", tr_taskfinish);
            string tra_taskforce = string.Join(",", tr_taskforce);
            string tra_install = string.Join(",", tr_install);
            string tra_lang = string.Join(",", tr_lang);
            string tra_disable = string.Join(",", tr_disable);

            string tra_progress = string.Join(",", tr_progress);


            // Change bouton text */* Change le text des boutons 
            monoFlat_ThemeContainer1.Text = tra_launcher + " " + tra_settings;
            Group_UserName.Text = tra_username;
            Language_Chose.Text = tra_language;
            Group_Options.Text = tra_launchoptions;
            Close_Bouton.Text = tra_close;
            Groups_OptionsArma.Text = tra_launcher + " " + tra_settings;
            Label_StartArma.Text = tra_startarma + ".";           
            Bouton_Reset.Text = tra_reset;
            Groupe_Warning.Text = tra_warningzone;
            Warning_Label.Text =  "/!\\  " + tra_warninglabel + "  /!\\";
            Label_TaskForce.Text = tra_progress + ": ";
            Group_TaskForce.Text = tra_taskforce;
            Bouton_TaskForce.Text = tra_install + " " + tra_taskforce;
            Language_label.Text = tra_lang + ":" ;
            

            if (music_intro != false)
            {
                Label_Sound.Text = tra_music + " " + tra_settings;
            }
            else
            {
                Label_Sound.Text = tra_music + " " + tra_settings + " //  " + tra_disable;
            }


            Trans_Loading = tra_loading;
            Trans_WarningMsg = tra_warningmsg;
            Trans_Progress = tra_progress + ": ";
            Trans_error401 = tra_erreur401;
            Trans_error50 = tra_erreur50;
            Trans_error51 = tra_erreur51;
            Trans_error52 = tra_erreur52;
            Trans_TaskFinish = tra_taskfinish;

            
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

        private void Toggle_StartArma_ToggledChanged()
        {
            File.WriteAllText(appdata + dest_options + "\\" + file_options, Toggle_StartArma.Toggled.ToString() + Environment.NewLine + Toggle_Sound.Toggled.ToString() + Environment.NewLine + TrackBar_Sound.Value.ToString());

            if (Toggle_StartArma.Toggled.ToString() == "True")
            {
                Label_StartArma.ForeColor = Color.LightGreen;
            }
            else
            {
                Label_StartArma.ForeColor = Color.LightCoral;
            }
        }


        private void TackBar_Sound_ValueChanged()
        {
            Volume_Number.Value = TrackBar_Sound.Value;
            File.WriteAllText(appdata + dest_options + "\\" + file_options, Toggle_StartArma.Toggled.ToString() + Environment.NewLine + Toggle_Sound.Toggled.ToString() + Environment.NewLine + TrackBar_Sound.Value.ToString());
        }

        private void monoFlat_Toggle1_ToggledChanged()
        {
            File.WriteAllText(appdata + dest_options + "\\" + file_options, Toggle_StartArma.Toggled.ToString() + Environment.NewLine + Toggle_Sound.Toggled.ToString() + Environment.NewLine + TrackBar_Sound.Value.ToString());
        }

        private void Bouton_Reset_Click(object sender, EventArgs e)
        {
            if (!download_progress)
            {
              
                if (MessageBox.Show(Trans_WarningMsg, Groupe_Warning.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Directory.Exists(dest_arma + modsname))
                    {
                        Directory.Delete(dest_arma + modsname, true);
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Error #50 | " + Trans_error50);
            }
        }

        private void Bouton_TaskForce_Click(object sender, EventArgs e)
        {
            if (download_progress)
            {
                MessageBox.Show("Error #50 | " + Trans_error50);
                return;
            }

            if (TaskForce_install)
            {
                MessageBox.Show("Error #52 | " + Trans_error52);
                return;
            }

            bool var1 = false;
            bool var2 = false;

            if (!File.Exists(dest_arma + file_arma3))
            {
                MessageBox.Show("Error #401 | " + Trans_error401);
                return;
            }

            if (!File.Exists(appdata + dest_options + "\\" + file_teamspeak))
            {
                TeamSpeak.ShowDialog();
                dteamspeak = TeamSpeak.SelectedPath + "\\";
                File.WriteAllText(appdata + dest_options + "\\" + file_teamspeak, dteamspeak);
             
            }
            else
            {
                dteamspeak = File.ReadAllText(appdata + dest_options + "\\" + file_teamspeak);
            }
            if ((!File.Exists(dteamspeak + "ts3client_win64.exe")) || (!File.Exists(dteamspeak + "ts3client_win32.exe")))
            {
                TeamSpeak.ShowDialog();
                dteamspeak = TeamSpeak.SelectedPath + "\\";
                File.WriteAllText(appdata + dest_options + "\\" + file_teamspeak, dteamspeak);
            }

            if (File.Exists(dteamspeak + "ts3client_win64.exe"))
            {
                var1 = true;
            }
            if (File.Exists(dteamspeak + "ts3client_win32.exe"))
            {
                var2 = true;
            }

            if ((var1 == false) && (var2 == false))
            {
                MessageBox.Show("Error #51 | " + Trans_error51);
                return;
            }


            try
            {
                Process[] proc = Process.GetProcessesByName("ts3client_win32");
                proc[0].Kill();
            }
            catch
            {
            }
            try
            {
                Process[] proc = Process.GetProcessesByName("ts3client_win64");
                proc[0].Kill();
            }
            catch
            {
            }


            Label_TaskForce.Text = Trans_Progress + Trans_Loading + "...";
            Language_Chose.Enabled = false;

            File.WriteAllText(appdata + dest_options + "\\" + file_teamspeak + "1", "Not Installed");

            TaskForce_Install.RunWorkerAsync();
            TaskForce_install = true;

        }

        private void TaskForce_Install_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient download = new WebClient();
            if (progress_task == 0) {
                // Install plugins TS3
                Progress_TaskForce.Value = 1;
                Label_TaskForce.Text = Trans_Progress + Progress_TaskForce.Value.ToString() +"/100";
   
                //Download TS3 list Download 
                if (File.Exists(appdata + file_listtask))
                {
                    File.Delete(appdata + file_listtask);
                }
                WebClient taskforce = new WebClient();
                taskforce.DownloadFile(ftp + file_listtask, appdata + file_listtask);
                
                Progress_TaskForce.Value = 10;
                Label_TaskForce.Text = Trans_Progress + Progress_TaskForce.Value.ToString() + "/100";
                
                //Create all directory
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-new");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-new\ab");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-new\dd");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-new\lr");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-new\sw");
                Progress_TaskForce.Value += 2;
                Label_TaskForce.Text = Trans_Progress + Progress_TaskForce.Value.ToString() + "/100";
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-old");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-old\ab");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-old\dd");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-old\lr");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds-old\sw");
                Progress_TaskForce.Value += 2;
                Label_TaskForce.Text = Trans_Progress + Progress_TaskForce.Value.ToString() + "/100";
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds\ab");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds\dd");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds\lr");
                Directory.CreateDirectory(dteamspeak + @"plugins\radio-sounds\sw");
                Progress_TaskForce.Value += 2;
                Label_TaskForce.Text = Trans_Progress + Progress_TaskForce.Value.ToString() + "/100";
                progress_task += 1;
            }
            if (progress_task == 1)
            {
                Progress_TaskForce.Value += 1;
                Label_TaskForce.Text = Trans_Progress + Progress_TaskForce.Value.ToString() + "/100";


                string[] lines = File.ReadAllLines(appdata + file_listtask);

                line = lines[counter_task];
                list_task = lines.Length;
              

                download.DownloadFile(ftp + dest_taskforce + "\\" + lines[counter_task], dteamspeak + "plugins\\" + lines[counter_task]);

                counter_task += 1;
                if (counter_task ==  list_task)
                {
                    progress_task += 1;
                }
                counter_task -= 1;
            }
            if (progress_task == 2)
            {
                Directory.CreateDirectory(dest_arma + @"userconfig");
                Directory.CreateDirectory(dest_arma + @"userconfig\task_force_radio");
                if (File.Exists(dest_arma + @"userconfig\task_force_radio\radio_settings.hpp"))
                {
                    File.Delete(dest_arma + @"userconfig\task_force_radio\radio_settings.hpp");
                }
                Progress_TaskForce.Value += 5;
                Label_TaskForce.Text = Trans_Progress + Progress_TaskForce.Value.ToString() + "/100";

                download.DownloadFile(ftp + dest_taskforce + @"\radio_settings.hpp", dest_arma + @"userconfig\task_force_radio\radio_settings.hpp");

                Progress_TaskForce.Value = 100;
                Label_TaskForce.Text = Trans_Progress + Progress_TaskForce.Value.ToString() + "/100";

                
            }
        
            
        }


        // [CREDIT][DO NOT REMOVE]
        //
        // This module was written by HUBERT Léo 
        //
        // Copyright HUBERT Léo © 2014 - 2015
        //
        // [CREDIT][DO NOT REMOVE]

        private void Pont_Task(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Progress_TaskForce.Value == 100)
            {
                // Finish Installation
                Language_Chose.Enabled = true;
                TaskForce_install = false;
                File.WriteAllText(appdata + dest_options + "\\" + file_teamspeak +"1", "Installed");

                if (servervocal == "teamspeak3")
            {
                if (portTS == "none")
                {
                    if (passTS == "none")
                    {
                        Process.Start("ts3server://" + ipTS);
                    }
                    else
                    {
                        Process.Start("ts3server://" + ipTS + "?password=" + passTS);
                    }
                }
                else
                {
                    if (passTS == "none")
                    {
                        Process.Start("ts3server://" + ipTS + "?port=" + portTS);
                    }
                    else
                    {
                        Process.Start("ts3server://" + ipTS + "?port=" + portTS + "?password=" + passTS);
                    }

                }
            }

                if (servervocal == "mumble")
                {
                    if (portmumble == "none")
                    {
                        if (passmumble == "none")
                        {
                            Process.Start("mumble://" + ipmumble);
                        }
                        else
                        {
                            Process.Start("mumble://:" + passmumble + "@" + ipmumble);
                        }
                    }
                    else
                    {
                        if (passmumble == "none")
                        {
                            Process.Start("mumble://" + ipmumble + portmumble);
                        }
                        else
                        {
                            Process.Start("mumble://:" + passmumble + "@" + ipmumble + portmumble);
                        }

                    }
                }


                MessageBox.Show(Trans_TaskFinish);
                return;
            }
            counter_task += 1;
            try
            {
                TaskForce_Install.RunWorkerAsync();
            }
            catch
            {

            }
        }

  







    }
}
