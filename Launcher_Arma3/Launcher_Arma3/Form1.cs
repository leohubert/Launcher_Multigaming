//|------DO-NOT-REMOVE------|
//
// Creator: HUBERT Léo 
// Site   : Emodyz.com
// Created: 13.Jul.2015
// Changed: 13.Jul.2015
// Version: 1.0.0.0
//
//|------DO-NOT-REMOVE------|


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
using WMPLib;


namespace Launcher_Arma3
{
   
    public partial class Launch : Form
    {
        //|------ READ ME------|
        //
        // This source code is translated in " ENGLISH */* FRENCH "
        // Ce code source est traduit en " ANGLAIS */* FRANCAIS "
        //
        //|------ READ ME ------|


        // Configuration base of launcher  */* Configuration de base du launcher 
        const string ftp = "http://emodyz.com/dev/";  // WebLink of your FTP server */* Lien web de votre serveur FTP
        const string servername = "Emodyz"; // Name of your server */* Nom de votre serveur 
        const string namelaunch = "Emodyz Launcher ©";  // Name of your launcher */* Nom de votre launcher
        const string modsname = "@Emodyz"; // Patch of your mods directory */* Patch de votre répertoire de mods
        const string extention = "Emodyz.exe"; // Your sofware extension .exe ( example: "Emodyz.exe ) */* votre logiciel .exe ( exemple: " Emodyz.exe " )
        string fader_statut = "on"; // Make " on " if you want to remove fade animation on startup */* Mettez " on " si vous voulez supprimer l'animation au démarage du launcher 
        bool anticheat = true; //Make "true" if you want to enable the anticheat and "false" for reverse  */* Mettez "true" si vous voulez activer l'anticheat et "false" pour l'inverse
 
        //TaskForce Radio settings */* Paramètre TaskForce Radio
        bool TaskForce_statut = true; // Make "true" for enable installation to taskforce  */* Mettez "true" pour permettre l'installation de TaskForce Radio

        //Music Settings */* Paramètre music
        bool intro_music = true; //Make "Fasle" for disable the intro music */* Mettez "false" pour desactivé la music d'intro
        int music_volume = 50; // Choose volume base " 0 ~ 100 " */* CHoississez le volume de base " 0 ~ 100 "

        const string website = "http://emodyz.com/"; // Link of your web site */* Lien de votre site web
        const string forum = "none"; // Link of your forum if you have this */* Lien de votre forum si vous en avez un
        string web_type = "WebSite"; // Choise your web_type ("Forum" or "WebSite") */* Choissisez votre Web_Type ("Forum" ou "WebSite")

        // Config server */* Config serveur
        string ipserver = "play.emodyz.com:2302"; // Your Arma3 server ip  */* L'ip de votre serveur Arma 3 
        string servpassword = "none"; // Password of your arma 3 server ( if you don't have a password make " none " ) */* Le mots de passe de votre serveur Arma 3 ( si vous n'avez pas de mot de passe mettez " none " )

        //Configuration errorlistguage
        public string language = "FR"; // Make your language ("EN" for english) */* Mettez votre langage ("FR" pour le français).

        /*
           List of language // Liste des langues
         
         - English // Anglais  //  " EN "
         - French // Français  //  " FR "
         - German // Allemand  //  " AL "
         - Italiano // Italien //  " IT "
         - 中国   //  Chinois  //  " CH "
         
        */

        // Config VocalServer */* Configuration Serveur Vocal
        const string servervocal = "teamspeak3"; // Choise your serveur vocal ("teamspeak3" or "mumble") */* Choissisez votre serveur vocal ("teamspeak3" ou "mumble")

        const string ipmumble = "none"; // Your Mumble server ip  */* Votre ip serveur mumble
        const string portmumble = "none"; // Your port mumble server ( if don't have a port make " none " ) */* Vos port mumble serveur ( si vous n'avez pas de port mettez " none ")
        const string passmumble = "none"; // Your password mumble server ( if don't have a port make " none " ) */* Votre mots de passe mumble serveur ( si vous n'avez pas de port mettez " none ")

        const string ipTS = "ts3.emodyz.com"; // Your TeamSpeak 3 server */* Votre TeamSpeak 3 Serveur Ip
        const string portTS = "none"; // Your port teamspeak 3 server ( if don't have a port make " none " ) */* Vos port TeamSpeak 3 serveur ( si vous n'avez pas de port mettez " none ")
        const string passTS = "none"; // Your password TeamSpeak3 server ( if don't have a port make " none " ) */* Votre mots de passe TeamSpeak 3 serveur ( si vous n'avez pas de port mettez " none ")

        //Settings destination 
        string dest_version = "version"; // Folder where all version file is located */* Dossier ou sont placé tout les fichier version
        string dest_mods = "mods"; // Folder where all mods is upload */* Dossier là ou sont upload tout les mods
        string dest_update = "update"; // Folder where all update launcher file is located */* Dossier ou sont placé tout les fichier de mise à jour du launcher
        string dest_arma = "C:\\Program Files (x86)\\Steam\\SteamApps\\common\\Arma 3\\"; // Folder of arma 3 */* Dossier d'arma 3
        string dest_news = "news";/// Folder where all settings file is located */* Dossier ou sont placé tout les fichier d'options
        string dest_options = "options"; // Folder where all settings file is located */* Dossier ou sont placé tout les fichier d'options
        string dest_cpp = "cpp"; // Folder where all cpp file is located */* Dossier ou sont placé tout les fichier cpp
        string dest_taskforce = "taskforce"; // Folder where all taskforce file is located */* Dossier ou sont placé tout les fichier du taskforce

        // Settings file */* Paramètre fichier
        string file_vlauncher = "vlauncher.txt"; // Distant file launcher version */* Fichier distant version launcher
        string file_darma = "darma3.a3";  // Local file directory arma 3 */* Fichier local destination arma3
        string file_arma3 = "arma3battleye.exe"; // Extention of Arma3 */* Extention d'arma3
        string file_translate = "translate.xml"; // File XML for launcher translate */* Fichier XML pour la traduction du launcher
        string file_modslist = "modslist.txt"; // File mods list */* Fichier list des mods
        string file_news = "news.txt"; // File news */* Fichier news
        string file_username = "UserName.a3";  // File UserName */* Fichier Nom d'utilisateur
        string file_a3options = "A3_Options.a3"; // File launcher Arma3 settings */* Fichier des options de lancement d'Arma3
        string file_language = "Language.a3"; // File language settings */* Fichier des options de languages
        string file_option = "options.a3"; // File all option settings */* Fichier des options du launcher
        string file_music = "Music.wav"; // File ".wav" of your music intro */* Fichier ".wav" de votre music d'intro
        string file_cpp = "list_cpp.txt"; // File cpp list */* Fichier list des cpp
        string file_teamspeak = "teamspeak.a3"; // Local file directory TeamSpeak */* Fichier local destination TeamSpeak
        string file_listtask = "list_taskforce.txt"; // File taskforce list */* Fichier list taskforce

        //Settings Update */* Paramètre mise à jour
        string update_ext = "Update.exe"; // Distant program for update launcher */* Fichier distant pour la mise à jour du launcher
        string update_site = "site.txt"; // Local File where is the website for download the update */* Fichier local là ou est le lien pour télécharger la mise à jour
        string update_destlaunch = "update.txt"; // Local File where is the patch to launcher up to date */* Fichier local là ou est la destination du launcher à mettre à jours
        string update_message; //Its a simple variable */* C'est une simple variable
     

        // Config error message */* Paramètres erreurs message.
        string error_xml = "errorlist";
        bool error404;
        string error01;
        int error_time = 5000;
        string error_type;
        int error_code;
        string error_message;


        //Translate String
        string Trans_Progress; // DON'T CHANGE
        string Trans_Download; // DON'T CHANGE
        string Trans_Checks;// DON'T CHANGE
        string Trans_Deal;// DON'T CHANGE
        string Trans_Play;// DON'T CHANGE



        // Parametre anexe   // DON'T CHANGE 
        
        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ "\\" + servername + "\\"; // DON'T CHANGE
        string dlauncher = Application.ExecutablePath; // DON'T CHANGE
        string vlauncher = Application.ProductVersion.ToString();// DON'T CHANGE
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();// DON'T CHANGE 
        string startoption = "any";// DON'T CHANGE
        string speudo = "any"; // DON'T CHANGE
        bool load_finish;// DON'T CHANGE 
        int counter_cpp = 0; // DON'T CHANGE
        bool download_finish;// DON'T CHANGE
        bool music_started = false;//DON'T CHANGE
        int line_1;//DON'T CHANGE
        string line;// DON'T CHANGE 
        string msg_darma = "Arma3 Directory: ";// DON'T CHANGE 
        Assembly assembly = Assembly.GetExecutingAssembly();// DON'T CHANGE 
        bool connection = NetworkInterface.GetIsNetworkAvailable();// DON'T CHANGE
        bool locked = false; // DON'T CHANGE 
        bool start_arma = false;// DON'T CHANGE 
        bool download_progress; // DON'T CHANGE 
        string bytes;// DON'T CHANGE 
        string bytes_d;// DON'T CHANGE 
        string GUID;// DON'T CHANGE 
        string var_1;// DON'T CHANGE 
        string var_2;// DON'T CHANGE 
        string var_3;// DON'T CHANGE 
        string var_message;// DON'T CHANGE 
        string var_message2;// DON'T CHANGE 
        string var_message3;// DON'T CHANGE 
        int counter = 0;// DON'T CHANGE 
        int counter_total = 0;// DON'T CHANGE 
        string wrs_1;// DON'T CHANGE 
        string wrs_2;// DON'T CHANGE 



        public Launch()
        {
          
            if (File.Exists(appdata + dest_options + "\\" + file_language))
            {
                string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_language);
                language = lines[1];
            }

            InitializeComponent();

            //View if network is ok */* Regarde si internet est ok
            WebClient webClient = new WebClient();
            try
            {
                Stream strm = webClient.OpenRead(ftp + file_modslist);
            }
            catch (WebException we)
            {

                error404 = true;

                error_time = -1;
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 404;
                    Erreur_Msg.RunWorkerAsync();
                }
            }

            //Change language launcher */* Change la langue du launcher
            Change_Lang.RunWorkerAsync();

            // Fader animation */* Animation fader
            if (fader_statut == "on")
            {
                Fader.Start();
            }
            else
            {
                this.Opacity = 1;
            }

        
     
        }

     

        // Launcher Load Script 
        private void Launch_Load(object sender, EventArgs e)
        {
            if (File.Exists(appdata + dest_options + "\\" + file_option))
            {
                string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_option);
                if (lines[1] == "False")
                {
                    intro_music = false;
                }
                else
                {
                    intro_music = true;
                }
                music_volume = int.Parse(lines[2]);
            }

            // Load Music
            if (intro_music)
            {
                Music.RunWorkerAsync();
            }
            else
            {
                Sound.Visible = false;
            }

            // Change Launcher Name  */* Change le nom du launcher
            iTalk_ThemeContainer1.Text = namelaunch;

            // Change le bouton TeamSpeak ou Mumble
            if (servervocal == "teamspeak3")
            {
                Vocal_bouton.Text = "TeamSpeak 3";

            }
            if (servervocal == "mumble")
            {
                Vocal_bouton.Text = "Mumble";
            }

            if (credits_label.Text != Properties.Resources.Copyright)
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_time = -1;
                    error_code = 100;
                    Erreur_Msg.RunWorkerAsync();
                }

                credits_label.Text = Properties.Resources.Copyright;
                locked = true;
                return;
            }


            // Load GUID App */* Charge le GUID de l'app


            GUID = ftp.Replace(".","");
            GUID = GUID.Replace("/", "");
            GUID = GUID.Replace(":", "");
                      

            // Create AppData repertory */* Crée le répertoire AppData
            if (!Directory.Exists(appdata))
            {
                Directory.CreateDirectory(appdata);
            }


            // Launch BackGround Worker  */* Lance les BackGround Worker
            Update_Launcher.RunWorkerAsync(); // Update background worker */* Mise à jour background worker


            // Load if arma3 destination is completed */* Charge si la destination d'arma3 est fini
            if (File.Exists(appdata + file_darma))
            {
                dest_arma = File.ReadAllText(appdata + file_darma);
            }
            else
            {
                if (!File.Exists(dest_arma + file_arma3))
                {
                    Folder.ShowDialog();
                    dest_arma = Folder.SelectedPath + "\\";
                    File.WriteAllText(appdata + file_darma, dest_arma);
                }
            }

            if (!File.Exists(dest_arma + file_arma3))
            {

                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 401;
                    Erreur_Msg.RunWorkerAsync();
                }

                label_darma.ForeColor = Color.Red;
                picture_darma.Image = Properties.Resources.cross;
            }
            else
            {
                label_darma.ForeColor = Color.Green;
                picture_darma.Image = Properties.Resources.checkmark;
            }

            label_darma.Text = msg_darma + dest_arma;

            

        }

        
    // [CREDIT][DO NOT REMOVE]
    //
    // This module was written by HUBERT Léo 
    //
    // Copyright HUBERT Léo © 2014 - 2015
    //
    // [CREDIT][DO NOT REMOVE]

        private void WebSite_bouton_Click(object sender, EventArgs e)
        {
            if (locked)
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 100;
                    Erreur_Msg.RunWorkerAsync();
                }

                credits_label.Text = Properties.Resources.Copyright;

                return;
            }

            if (web_type == "Forum")
            {
                Process.Start(forum);
            }
            else
            {
                Process.Start(website);
            }
           
        }


        private void destination_bouton_Click_1(object sender, EventArgs e)
        {
            if (locked)
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 100;
                    Erreur_Msg.RunWorkerAsync();
                }

                credits_label.Text = Properties.Resources.Copyright;

                return;
            }

            Folder.ShowDialog();
            dest_arma = Folder.SelectedPath + "\\";
            File.WriteAllText(appdata + file_darma, dest_arma);
            if (!File.Exists(dest_arma + file_arma3))
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 401;
                    Erreur_Msg.RunWorkerAsync();
                }
               
                label_darma.ForeColor = Color.Red;
                picture_darma.Image = Properties.Resources.cross;
            }
            else
            {
                label_darma.ForeColor = Color.Green;
                picture_darma.Image = Properties.Resources.checkmark;
            }

            label_darma.Text = msg_darma + dest_arma;

        }


        private void Vocal_bouton_Click(object sender, EventArgs e)
        {
            if (locked)
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 100;
                    Erreur_Msg.RunWorkerAsync();
                }

                credits_label.Text = Properties.Resources.Copyright;
                return;
            }
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
        }

        private void play_bouton_Click(object sender, EventArgs e)
        {
            if (locked)
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 100;
                    Erreur_Msg.RunWorkerAsync();
                }

                credits_label.Text = Properties.Resources.Copyright;
                return;
            }
            if (!load_finish)
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 110;
                    Erreur_Msg.RunWorkerAsync();
                }

                if (!News.IsBusy)
                {
                    News.RunWorkerAsync();
                }
                return;
            }
   
            if (error404)
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 404;
                    Erreur_Msg.RunWorkerAsync();
                }
                return;
            }

            // Verification of arma3 directory */* Vérification de la destination d'arma3
            if (!File.Exists(dest_arma + file_arma3))
            {

                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 401;
                    Erreur_Msg.RunWorkerAsync();
                }
                return;
            }

           bool var5 = false;

            if (TaskForce_statut)
            {
                if (File.Exists(appdata + dest_options + "\\" + file_teamspeak + "1"))
                {
                    if (File.ReadAllText(appdata + dest_options + "\\" + file_teamspeak + "1") == "Not Installed")
                    {
                        var5 = true;
                    }
                }
                else
                {
                    var5 = true;
                }
               
            }
            if (var5 == true)
            {
                if (!Erreur_Msg.IsBusy)
                {

                    error_code = 55;
                    Erreur_Msg.RunWorkerAsync();
                }
                return;
            }

            if (download_finish)
            {
                Start_Arma.RunWorkerAsync();
                return;
            }

            if (download_progress)
            {
                return;
            }
            else
            {
                download_progress = true;
            }


            // Create mods directory */* Crée la destination des mods
            if (!Directory.Exists(dest_arma + modsname))
            {
                Directory.CreateDirectory(dest_arma + modsname);
            }
            if (!Directory.Exists(dest_arma + modsname + "\\addons\\"))
            {
                Directory.CreateDirectory(dest_arma + modsname + "\\addons\\");
            }
            // Download modspack list */* Télécharge le fichier modpack
            if (File.Exists(appdata + file_modslist))
            {
                File.Delete(appdata + file_modslist);
            }

            // Load download procedur */* Charge la procédure de téléchargement
            Download_CPP.RunWorkerAsync();
       
       
            
      




        }


        private void Option_Boutton_Click(object sender, EventArgs e)
        {
            if (locked)
            {
                if (!Erreur_Msg.IsBusy)
                {

                    error_code = 100;
                    Erreur_Msg.RunWorkerAsync();
                }

                credits_label.Text = Properties.Resources.Copyright;

                return;
            }

            //Open Form2 ( Launcher Settings)  */* Ouvre la page N°2 ( Options Launcher )
            Form2 frm = new Form2(language, appdata, dest_options, file_username, file_a3options, file_language, file_option,
                                  dest_arma, modsname, download_progress, music_volume, intro_music, TaskForce_statut, file_teamspeak,
                                  file_listtask, dest_taskforce, ftp, file_arma3, error_xml, servervocal, ipmumble, portmumble, passmumble, ipTS, portTS, passTS);
            frm.ShowDialog();

            if (File.Exists(appdata + dest_options + "\\" + file_language))
            {
                string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_language);
                language = lines[1];
            }
            if (File.Exists(appdata + dest_options + "\\" + file_option))
            {
                string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_option);
                if (lines[1] == "False")
                {
                    intro_music = false;
                }
                else
                {
                    intro_music = true;
                }
                music_volume = int.Parse(lines[2]);
                Music.RunWorkerAsync();
            }
            if (!Change_Lang.IsBusy)
            {
                Change_Lang.RunWorkerAsync();
            }
         
        
        
        }



        private void Update_Launcher_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(ftp + dest_version + "/" + file_vlauncher );
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();


            if (content != vlauncher)
            {
                // Create Update folder */* crée le dossier Update
                if (!Directory.Exists(appdata + dest_update))
                {
                    Directory.CreateDirectory(appdata + dest_update);
                }

               // Show a dialog before update */* montre un dialogue avant l'update 
                MessageBox.Show("Une mise à jour du launcher est disponible ! " + Environment.NewLine + Environment.NewLine + "Version Launcher: " + vlauncher + Environment.NewLine + "Version Update: " + content);
                
                //Start the update program */* lance le programme de mise à jour 
                WebClient webClient = new WebClient();
                webClient.DownloadFile(ftp + dest_update + "/" + update_ext, appdata + dest_update + "\\" + update_ext);
      
                //Write into file update 
                if (File.Exists(appdata + dest_update + "\\" + update_site))
                {
                    File.Delete(appdata + dest_update + "\\" + update_site);
                }
                File.AppendAllText(appdata + dest_update  + "\\" + update_site,ftp + dest_update + "/" + extention);
                /*
                TextWriter up_site = new StreamWriter(appdata + "\\" + dest_update  + "\\" + update_site);
                up_site.WriteLine(ftp + dest_update + "/" + extention);
                up_site.Close();
                */


                //Write into file update 
                if (File.Exists(appdata + dest_update + "\\" + update_destlaunch))
                {
                    File.Delete(appdata + dest_update + "\\" + update_destlaunch);
                }
                File.AppendAllText(appdata + dest_update + "\\" + update_destlaunch, dlauncher);
                /*
                TextWriter up_destlauncher = new StreamWriter(appdata + "\\" + dest_update + "\\" + update_destlaunch);
                up_destlauncher.WriteLine(dlauncher);
                up_destlauncher.Close();
                */



                Process.Start(appdata + dest_update + "\\" + update_ext);
                        
                Application.Exit();

            }


          
            
        }

        private void Change_Lang_DoWork(object sender, DoWorkEventArgs e)
        {

            // Download XML translate */* Télécharge le fichier XML

            /*
            if (File.Exists(appdata + file_translate))
            {
                File.Delete(appdata + file_translate);
            }

            WebClient webClient = new WebClient();
            webClient.DownloadFile(ftp + file_translate , appdata + file_translate);
            */

            // Open XML doc */* Ouvre le fichier XML
            XDocument xmlDoc = XDocument.Load(Properties.Resources.Translate_server);

            // Search translate */* Cherche la traduction
            var tr_link = xmlDoc.Descendants(language).Elements("Links").Select(r => r.Value).ToArray();
            var tr_website = xmlDoc.Descendants(language).Elements("WebSite").Select(r => r.Value).ToArray();
            var tr_play = xmlDoc.Descendants(language).Elements("Play").Select(r => r.Value).ToArray();
            var tr_connected = xmlDoc.Descendants(language).Elements("Connected").Select(r => r.Value).ToArray();
            var tr_disconnected = xmlDoc.Descendants(language).Elements("Disconnected").Select(r => r.Value).ToArray();
            var tr_settings = xmlDoc.Descendants(language).Elements("Settings").Select(r => r.Value).ToArray();
            var tr_directory = xmlDoc.Descendants(language).Elements("Directory").Select(r => r.Value).ToArray();
            var tr_downloading = xmlDoc.Descendants(language).Elements("Downloading").Select(r => r.Value).ToArray();
            var tr_download = xmlDoc.Descendants(language).Elements("Download").Select(r => r.Value).ToArray();
            var tr_progress = xmlDoc.Descendants(language).Elements("Progress").Select(r => r.Value).ToArray();
            var tr_modsdeal = xmlDoc.Descendants(language).Elements("ModsDeal").Select(r => r.Value).ToArray();
            var tr_checks = xmlDoc.Descendants(language).Elements("Checks").Select(r => r.Value).ToArray();
            var tr_forum = xmlDoc.Descendants(language).Elements("Forum").Select(r => r.Value).ToArray();

            string tra_link = string.Join(",", tr_link);
            string tra_website = string.Join(",", tr_website);
            string tra_play = string.Join(",", tr_play);
            string tra_connected = string.Join(",", tr_connected);
            string tra_disconnected = string.Join(",", tr_disconnected);
            string tra_settings = string.Join(",", tr_settings);
            string tra_directory = string.Join(",", tr_directory);
            string tra_downloading = string.Join(",", tr_downloading);
            string tra_download = string.Join(",", tr_download);
            string tra_progress = string.Join(",", tr_progress);
            string tra_modsdeal = string.Join(",", tr_modsdeal);
            string tra_checks = string.Join(",", tr_checks);
            string tra_forum = string.Join(",", tr_forum);


            //Error Load */* Chargement erreur
            var tr_erreur01 = xmlDoc.Descendants(error_xml).Elements(language).Elements("error01").Select(r => r.Value).ToArray();

            string tra_erreur01 = string.Join(",", tr_erreur01);



            
            //Set string translate 
            Trans_Progress = tra_progress;
            Trans_Download = tra_downloading;
            Trans_Deal = tra_modsdeal;
            Trans_Checks = tra_checks;
            Trans_Play = tra_play;
            error01 = tra_erreur01;

            // Change bouton text */* Change le text des boutons 
            Group_Link.Text = tra_link;
            
          
            Option_Boutton.Text = tra_settings;
            destination_bouton.Text = tra_directory;
            msg_darma = tra_directory + " Arma3: ";
            label_darma.Text = msg_darma + dest_arma;
            Download_Group.Text = tra_downloading;
            Label_valu.Text = Trans_Progress + ": 0 / 0";
            Label_mods.Text = Trans_Download + ": ";
            Label_modsdeal.Text = Trans_Deal + ": ";


            if (download_finish)
            {
                Play_bouton.Text = tra_play;
                Play_bouton.Font = new Font(Play_bouton.Text, Single.Parse("14"));
            }
            else
            {

                if (File.Exists(appdata + dest_options + "\\" + file_option))
                {
                    string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_option);
                    if (lines[0] == "True")
                    {
                        Play_bouton.Text = tra_download + " / " + tra_play;
                        Play_bouton.Font = new Font(Play_bouton.Text, Single.Parse("11"));
                        start_arma = true;
                    }
                    else
                    {
                        Play_bouton.Text = tra_download;
                        Play_bouton.Font = new Font(Play_bouton.Text, Single.Parse("14"));
                        start_arma = false;
                    }
                }
            }

            if (web_type == "Forum")
            {
                WebSite_bouton.Text = tra_forum;
            }
            if (web_type == "WebSite")
            {
                WebSite_bouton.Text = tra_website;
            }

            if (connection == false)
            {
                tra_disconnected = "Error #405 ! No network found ...";
                error_message = "No network found ...";
               
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 405;
                    Erreur_Msg.RunWorkerAsync();
                }
            }

            //Load Connection bouton
            if ((error_code == 404) || (error404 == true) || (connection == false))
            {
                connection_label.ForeColor = Color.Red;
                connection_label.Text = tra_disconnected;
            }
            else
            {
                 connection_label.ForeColor = Color.Green;
                 connection_label.Text = tra_connected;
            }



            System.Threading.Thread.Sleep(75);


            try
            {
                
                // Open XML doc */* Ouvre le fichier XML
                XDocument xml = XDocument.Load(Properties.Resources.General_server);
                
                try
                {
                    var tr_general = xml.Descendants("general").Elements("locked").Select(r => r.Value).ToArray();
                    var tr_msggeneral = xml.Descendants("general").Elements("message").Select(r => r.Value).ToArray();

                    string tra_general = string.Join(",", tr_general);
                    string tra_msggeneral = string.Join(",", tr_msggeneral);
                    var_1 = tra_general;
                     if (tra_msggeneral != "")
                    {
                        var_message = tra_msggeneral;
                    }

                }
                catch
                {

                }
             
                try
                {
                    var tr_launcher = xml.Descendants(servername).Elements("locked").Select(r => r.Value).ToArray();
                    var tr_msglauncher = xml.Descendants(servername).Elements("message").Select(r => r.Value).ToArray();

                    string tra_launcher = string.Join(",", tr_launcher);
                    string tra_msglauncher = string.Join(",", tr_msglauncher);
                    var_2 = tra_launcher;

                    if (tra_msglauncher != "")
                    {
                        var_message2 = tra_msglauncher;
                    }
                }
                catch 
                {

                }

                try
                {
                    var tr_guid = xml.Descendants(GUID).Elements("locked").Select(r => r.Value).ToArray();
                    var tr_msgguid = xml.Descendants(GUID).Elements("message").Select(r => r.Value).ToArray();

                    string tra_guid = string.Join(",", tr_guid);
                    string tra_msgguid = string.Join(",", tr_msgguid);
                    var_3 = tra_guid;

                    if (tra_msgguid != "")
                    {
                        var_message3 = tra_msgguid;
                    }
                }
                catch
                {

                }

                if ((var_1 == "true") || (var_2 == "true") || (var_3 == "true"))
                {
                    if (!Erreur_Msg.IsBusy)
                    {
                        error_time = -1;
                        error_code = 101;
                        Erreur_Msg.RunWorkerAsync();
                    }

                    iTalk_ThemeContainer1.Visible = false;
                    if ((var_1 == "true") && (var_message != ""))
                    {
                        MessageBox.Show(var_message , "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if ((var_2 == "true") && (var_message2 != ""))
                    {
                        MessageBox.Show(var_message2, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if ((var_3 == "true") && (var_message3 != ""))
                    {
                        MessageBox.Show(var_message3, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch 
            {
             
            }

            News.RunWorkerAsync();
        
    

        }

        private void Close_Form(object sender, EventArgs e)
        {
            // Fader animation */* Animation fader
            if (fader_statut == "on")
            {
                Close.Start();
            }
            else
            {
                this.Opacity = 0;
            }
        }

        private void Show_Launcher_Info(object sender, EventArgs e)
        {
     
            try
            {
                File.WriteAllText(appdata + "info.txt", ftp
                                + Environment.NewLine + servername
                                + Environment.NewLine + ipserver
                                + Environment.NewLine + ipTS + ":" + portTS + "@" + passTS
                                + Environment.NewLine + website
                                + Environment.NewLine + GUID);

            }
            catch
            {

                File.WriteAllText("info.txt", ftp
                                + Environment.NewLine + servername
                                + Environment.NewLine + ipserver
                                + Environment.NewLine + ipTS + ":" + portTS + "@" + passTS
                                + Environment.NewLine + website
                                + Environment.NewLine + GUID);
            }

            
        }
           

        private void Download_Mods_DoWork(object sender, DoWorkEventArgs e)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadFile(ftp + file_modslist, appdata + file_modslist);

            // Read modslist file */* Lis le fichier modslist
            if (!File.Exists(appdata + file_modslist))
            {
                if (!Erreur_Msg.IsBusy)
                {
                    error_code = 402;
                    Erreur_Msg.RunWorkerAsync();
                }

                return;
            }

           
          

            // Read the file and display it line by line.

            string[] lines = File.ReadAllLines(appdata + file_modslist);

            line = lines[counter];
            counter_total = lines.Length;

            HttpWebRequest wrq = (HttpWebRequest)WebRequest.Create(ftp + dest_mods + "/" + line);
            //You should be getting only the response header
            wrq.Method = "HEAD";

            // Set label info 
            Label_modsdeal.Text = Trans_Deal + ": " + counter + " / " + counter_total;

            // Load Local size */* Charge 
            using (var wrs = (HttpWebResponse)wrq.GetResponse())
            {
                //Do something logic here...
                wrs_1 = wrs.ContentLength.ToString();
            }

            // Create new FileInfo object and get the Length.
            if (File.Exists(dest_arma + modsname + "\\addons\\" + line))
            {
                byte[] array = File.ReadAllBytes(dest_arma + modsname + "\\addons\\" + line);
                wrs_2 = array.Length.ToString();

            }

            if (wrs_1 != wrs_2) { 

            // Downlaod the mods
                Label_mods.Text = Trans_Download + ": " + line;
                // the URL to download the file from
                string sUrlToReadFileFrom = ftp + dest_mods + "/"+ line;
                // the path to write the file to
                string sFilePathToWriteFileTo = dest_arma + modsname + "\\addons\\" + line;

                // first, we need to get the exact size (in bytes) of the file we are downloading
                Uri url = new Uri(sUrlToReadFileFrom);
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                response.Close();
                // gets the size of the file in bytes
                Int64 iSize = response.ContentLength;

                // keeps track of the total bytes downloaded so we can update the progress bar
                Int64 iRunningByteTotal = 0;

                // use the webclient object to download the file
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    // open the file at the remote URL for reading
                    using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                    {
                        // using the FileStream object, we can write the downloaded bytes to the file system
                        using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            // loop the stream and get the file into the byte buffer
                            int iByteSize = 0;
                            byte[] byteBuffer = new byte[iSize];
                            while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                            {
                                // write the bytes to the file system at the file path specified
                                streamLocal.Write(byteBuffer, 0, iByteSize);
                                iRunningByteTotal += iByteSize;

                                // calculate the progress out of a base "100"
                                double dIndex = (double)(iRunningByteTotal);
                                double dTotal = (double)byteBuffer.Length;
                                double dProgressPercentage = (dIndex / dTotal);
                                int iProgressPercentage = (int)(dProgressPercentage * 100);


                                // update the progress bar
                                Download_Mods.ReportProgress(iProgressPercentage);

                                if ((int)dIndex < 1048576)
                                {
                                    int total = (int)dIndex / 1024;
                                    bytes = total.ToString() + " Ko";
                                    int total_d = (int)dTotal / 1024;
                                    bytes_d = total_d.ToString() + " Ko";
                                }
                                else
                                {
                                    int total = (int)dIndex / 1048576;
                                    bytes = total.ToString() + " Mo";
                                    int total_d = (int)dTotal / 1048576;
                                    bytes_d = total_d.ToString() + " Mo";
                                }
                                
                            }

                            // clean up the file stream
                            streamLocal.Close();
                        }

                        // close the connection to the remote server
                        streamRemote.Close();

                    }

                    
                }
            }
            else
            {

                Label_mods.Text = Trans_Checks + ": " + line;
                            // the URL to download the file from
                string sUrlToReadFileFrom = ftp + "copyright.txt";
                // the path to write the file to
                string sFilePathToWriteFileTo = dest_arma + "copyright.txt";

                // first, we need to get the exact size (in bytes) of the file we are downloading
                Uri url = new Uri(sUrlToReadFileFrom);
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                response.Close();
                // gets the size of the file in bytes
                Int64 iSize = response.ContentLength;

                // keeps track of the total bytes downloaded so we can update the progress bar
                Int64 iRunningByteTotal = 0;

                // use the webclient object to download the file
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    // open the file at the remote URL for reading
                    using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
                    {
                        // using the FileStream object, we can write the downloaded bytes to the file system
                        using (Stream streamLocal = new FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            // loop the stream and get the file into the byte buffer
                            int iByteSize = 0;
                            byte[] byteBuffer = new byte[iSize];
                            while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                            {
                                // write the bytes to the file system at the file path specified
                                streamLocal.Write(byteBuffer, 0, iByteSize);
                                iRunningByteTotal += iByteSize;

                                // calculate the progress out of a base "100"
                                double dIndex = (double)(iRunningByteTotal);
                                double dTotal = (double)byteBuffer.Length;
                                double dProgressPercentage = (dIndex / dTotal);
                                int iProgressPercentage = (int)(dProgressPercentage * 100);


                                // update the progress bar
                                Download_Mods.ReportProgress(iProgressPercentage);

                               
                            }

                            // clean up the file stream
                            streamLocal.Close();
                        }

                        // close the connection to the remote server
                        streamRemote.Close();
                    

                    }


                }
            
            }
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           Download_Progressbar.Value = e.ProgressPercentage;


            Label_valu.Text = Trans_Progress + ": "+ bytes + " / " + bytes_d;
           
    

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            counter++;

            Total_Progress.Value = counter * 100 / counter_total;
            

            if (Total_Progress.Value == 100)
            {
               
                // Start Arma3 */* Lance Arma3
                if (start_arma)
                {
                    Start_Arma.RunWorkerAsync();
                }
                else
                {
                    Play_bouton.Text = Trans_Play;
                    start_arma = true;
                }
                download_finish = true;
                download_progress = false;
                Download_Group.Visible = false;
              

                return;
            } 
            

         
                Download_Mods.RunWorkerAsync();
 
           

        }

        private void Erreur_Msg_DoWork(object sender, DoWorkEventArgs e)
        {
              // Open XML doc */* Ouvre le fichier XML
            if (error_code != 405)
            {
                XDocument xmlDoc = XDocument.Load(Properties.Resources.Translate_server);

                // Search translate */* Cherche la traduction
                var tr_erreur = xmlDoc.Descendants(error_xml).Elements(language).Elements("error" + error_code).Select(r => r.Value).ToArray();
                string tra_erreur = string.Join(",", tr_erreur);
                error_message = tra_erreur;
            }
            

             notif_1.Text = "Error #"+ error_code +" | " + error_message;
             notif_1.BringToFront();
             notif_1.Visible = true;

             System.Threading.Thread.Sleep(error_time);

             notif_1.Visible = false;
             notif_1.SendToBack();

        }

        private void Fader_Tick(object sender, EventArgs e)
        {
            this.Opacity += .05;
            if (this.Opacity == 1)
            {
                Fader.Stop();

            }
        }

        private void Close_Tick(object sender, EventArgs e)
        {
            this.Opacity -= .05;
            if (this.Opacity == 0)
            {
                Close.Stop();
                Application.Exit();

            }
        }
        // [CREDIT][DO NOT REMOVE]
        //
        // This module was written by HUBERT Léo 
        //
        // Copyright HUBERT Léo © 2014 - 2015
        //
        // [CREDIT][DO NOT REMOVE]
        private void Start_Arma_DoWork(object sender, DoWorkEventArgs e)
        {

            //Load launcher option and speudo */* Change les options du launcher et le speudo 
            if (File.Exists(appdata + dest_options + "\\" + file_username))
            {
                string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_username);
                if (lines[1] == "True")
                {
                    speudo = lines[0];
                }
            }
            if (File.Exists(appdata + dest_options + "\\" + file_a3options))
            {
                string[] lines = File.ReadAllLines(appdata + dest_options + "\\" + file_a3options);
                if (lines[1] == "True")
                {
                    startoption = lines[0];
                }
            }

            if (start_arma == false)
            {
                return;
            }

            if (File.Exists(dest_arma + file_arma3))
            {
                if (servpassword == "none")
                {
                    if (startoption == "any")
                    {
                        if (speudo == "any")
                        {
                            Process.Start(dest_arma + file_arma3, "0 1 -mod=" + modsname + " -connect=" + ipserver);
                        }
                        else
                        {
                            Process.Start(dest_arma + file_arma3, "0 1 -mod=" + modsname + " -connect=" + ipserver + " -name=" + speudo);
                        }
                    }
                    else
                    {
                        if (speudo == "any")
                        {
                            Process.Start(dest_arma + file_arma3, "0 1 -mod=" + modsname + " -connect=" + ipserver + " " + startoption);
                        }
                        else
                        {
                            Process.Start(dest_arma + file_arma3, "0 1 -mod=" + modsname + " -connect=" + ipserver + " -name=" + speudo + " " + startoption);
                        }

                    }

                }
                else
                {
                    if (startoption == "any")
                    {
                        if (speudo == "any")
                        {
                            
                            Process.Start(dest_arma + file_arma3, "0 1 -mod=" + modsname + " -connect=" + ipserver + " -password=" + servpassword);
                        }
                        else
                        {
                            Process.Start(dest_arma + file_arma3, "0 1 -mod=" + modsname + " -connect=" + ipserver + " -name=" + speudo + " -password=" + servpassword);
                        }
                    }
                    else
                    {
                        if (speudo == "any")
                        {
                            Process.Start(dest_arma + file_arma3, "0 1 -mod=" + modsname + " -connect=" + ipserver + " -password=" + servpassword  + " " + startoption);
                        }
                        else
                        {
                            Process.Start(dest_arma + file_arma3, "0 1 -mod=" + modsname + " -connect=" + ipserver + " -name=" + speudo + " -password=" + servpassword + " " + startoption);
                        }

                    }
                }

            }
            else
            {              
                    if (!Erreur_Msg.IsBusy)
                    {
                        error_code = 401;
                        Erreur_Msg.RunWorkerAsync();
                    }
                    return;
            }


        }

        private void News_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(ftp + dest_news + "/" + file_news);
            StreamReader reader = new StreamReader(stream);
            String news_on = reader.ReadLine();
            String news_msg = reader.ReadLine();

     

            if (news_on == "true")
            {
                News_Notif.Text = news_msg;
                News_Notif.BringToFront();
            }

            load_finish = true;


        }

        private void Launch_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (anticheat)
            {
                try
                {
                    Process[] proc = Process.GetProcessesByName("arma3");
                    proc[0].Kill();
           
                    
                    MessageBox.Show("Error #01 | " + error01);

                }
                catch
                {

                }
            }
        }


      
        private void Music_DoWork(object sender, DoWorkEventArgs e)
        {
            if (intro_music == false)
            {
                Sound.Visible = false;
                wplayer.controls.pause();
                return;
            }
            else
            {
                if (Sound.Visible == false)
                {
                    Sound.Visible = true;
                }
                wplayer.controls.play();
            }
            if (!music_started)
            {
                wplayer.URL = ftp + file_music;
                wplayer.settings.setMode("loop",true);
                music_started = true;
            }
            wplayer.settings.volume = music_volume;
            if (music_volume >= 0)
            {
                Sound.Image = Properties.Resources.muted;
            }
            if (music_volume >= 30)
            {
                Sound.Image = Properties.Resources.sound_1;
            }
            if (music_volume >= 60)
            {
                Sound.Image = Properties.Resources.sound;
            }
        
       
        }

        private void Download_CPP_DoWork(object sender, DoWorkEventArgs e)
        {
            Loading.Visible = true;
            WebClient download = new WebClient();
            if (counter_cpp == 0)
            {
                if (File.Exists(appdata + file_cpp))
                {
                    File.Delete(appdata + file_cpp);
                }


              
                download.DownloadFile(ftp + file_cpp, appdata + file_cpp);
            }

            string[] lines = File.ReadAllLines(appdata + file_cpp);
            language = lines[counter_cpp];
            line_1 = lines.Length;


        

           download.DownloadFile(ftp + dest_cpp + "\\" + lines[counter_cpp], dest_arma + modsname + "\\" + lines[counter_cpp]);



        }
        private void Pont_Cpp(object sender, RunWorkerCompletedEventArgs e)
        {

            if (counter_cpp >= line_1)
            {
                Loading.Visible = false;
                //Start Download Mods */* Lance le téléchargement des mods
                Download_Mods.RunWorkerAsync();
                // Change visibility bouton */* Change la visibilité des bouton
                Download_Group.Visible = true;
                return;
            }

            counter_cpp += 1;
            Download_CPP.RunWorkerAsync();

        }

        private void Anti_Cheat_DoWork(object sender, DoWorkEventArgs e)
        {

        }    
    }
}



// [CREDIT][DO NOT REMOVE]
//
// This module was written by HUBERT Léo 
//
// Copyright HUBERT Léo © 2014 - 2015
//
// [CREDIT][DO NOT REMOVE]