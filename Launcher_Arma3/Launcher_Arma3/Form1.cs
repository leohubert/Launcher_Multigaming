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
        const string ftp = "http://play.emodyz.com/dev/";  // WebLink of your FTP server */* Lien web de votre serveur FTP
        const string servername = "Emodyz"; // Name of your server */* Nom de votre serveur 
        const string namelaunch = "Emodyz Launcher ©";  // Name of your launcher */* Nom de votre launcher
        const string modsname = "@Emodyz"; // Patch of your mods directory */* Patch de votre répertoire de mods
        const string website = "http://emodyz.com"; // Link of your web site */* Lien de votre site web
        const string extention = "Emodyz.exe"; // Your sofware extension .exe ( example: "Emodyz.exe ) */* votre logiciel .exe ( exemple: " Emodyz.exe " )

        // Config server */* Config serveur
        const string ipserver = "play.emodyz.com:2302"; // Your Arma3 server ip  */* L'ip de votre serveur Arma 3 
        const string servpassword = "none"; // Password of your arma 3 server ( if you don't have a password make " none " ) */* Le mots de passe de votre serveur Arma 3 ( si vous n'avez pas de mot de passe mettez " none " )

        //Configuration language
        public string language = "FR"; // Make your language "EN" pour l'anglais */* Mettez votre langage "FR" pour le français.

        // Config VocalServer
        const string servervocal = "teamspeak3"; // Choise your serveur vocal ("teamspeak3" or "mumble") */* Choissisez votre serveur vocal ("teamspeak3" ou "mumble")

        const string ipmumble = "none"; // Your Mumble server ip  */* Votre ip serveur mumble
        const string portmumble = "none"; // Your port mumble server ( if don't have a port make " none " ) */* Vos port mumble serveur ( si vous n'avez pas de port mettez " none ")
        const string passmumble = "none"; // Your password mumble server ( if don't have a port make " none " ) */* Votre mots de passe mumble serveur ( si vous n'avez pas de port mettez " none ")

        const string ipTS = "ts3.emodyz.com"; // Your TeamSpeak 3 server */* Votre TeamSpeak 3 Serveur Ip
        const string portTS = "none"; // Your port teamspeak 3 server ( if don't have a port make " none " ) */* Vos port TeamSpeak 3 serveur ( si vous n'avez pas de port mettez " none ")
        const string passTS = "none"; // Your password TeamSpeak3 server ( if don't have a port make " none " ) */* Votre mots de passe TeamSpeak 3 serveur ( si vous n'avez pas de port mettez " none ")

        //Settings destination 
        string dest_version = "version"; // Folder where all version file is located */* Dossier ou sont placé tout les fichier version
        string dest_update = "update"; // Folder where all updazte launcher file is located */* Dossier ou sont placé tout les fichier de mise à jour du launcher

        // Settings file */* Paramètre fichier
        string file_vlauncher = "vlauncher.txt";

        //Settings Update */* Paramètre mise à jour
        string update_ext = "Update.exe";
        string update_site = "site.txt";
        string update_destlaunch = "update.txt";
                                                             
        // Parametre anexe 
        bool locked = false; // DON'T CHANGE 
        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\"; // DON'T CHANGE
        string dlauncher = Application.ExecutablePath;
        string vlauncher = Application.ProductVersion.ToString();
        string username = "UserName";


        public Launch()
        {
            InitializeComponent();
        }

        // Launcher Load Script 

        private void Launch_Load(object sender, EventArgs e)
        {

            // Change Launcher Name  */* Change le nom du launcher
            Launch.ActiveForm.Text = namelaunch;
            iTalk_ThemeContainer1.Text = namelaunch;

            //Change language launcher */* Change la langue du launcher
            Change_Lang.RunWorkerAsync();

            // Change le bouton TeamSpeak ou Mumble
            if (servervocal == "teamspeak3")
            {
                Vocal_bouton.Text = "TeamSpeak 3";

            }
            if (servervocal == "mumble")
            {
                Vocal_bouton.Text = "Mumble";
            }

            if (credits_label.Text != Application.CompanyName)
            {
                MessageBox.Show("Credits is modified ! */* Les crédits sont modifié !",  "Copyright HUBERT Léo © 2014 - 2015");
                credits_label.Text = "Copyright HUBERT Léo © 2014 - 2015";
                locked = true;
            }


            // Create AppData repertory */* Crée le répertoire AppData
            if (!Directory.Exists(appdata + servername))
            {
                Directory.CreateDirectory(appdata + servername);
            }


            // Launch BackGround Worker  */* Lance les BackGround Worker
            Update_Launcher.RunWorkerAsync();
                

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
            Process.Start(website);
        }

        private void Vocal_bouton_Click(object sender, EventArgs e)
        {
            if (credits_label.Text != Application.CompanyName)
            {
                MessageBox.Show("Credits is modified ! */* Les crédits sont modifié !", "Copyright HUBERT Léo © 2014 - 2015");
                credits_label.Text = "Copyright HUBERT Léo © 2014 - 2015";
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
                MessageBox.Show("Launcher Bloquer ! "+ Environment.NewLine + Environment.NewLine +"Cause: Changement de crédits .");
                return;
            }
            
            MessageBox.Show("CODAGE IN PROGRESS */* EN COUR DE CODAGE" , namelaunch );
        }

        private void destination_bouton_Click(object sender, EventArgs e)
        {
          
        } 


        private void Option_Boutton_Click(object sender, EventArgs e)
        {

            Form2 dlg = new Form2();
            dlg.language = language;
            dlg.Show();
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
                if (!Directory.Exists(appdata + servername + "\\" + dest_update))
                {
                    Directory.CreateDirectory(appdata + servername + "\\" + dest_update);
                }

               // Show a dialog before update */* montre un dialogue avant l'update 
                MessageBox.Show("Une mise à jour du launcher est disponible ! " + Environment.NewLine + Environment.NewLine + "Version Launcher: " + vlauncher + Environment.NewLine + "Version Update: " + content);
                
                //Start the update program */* lance le programme de mise à jour 
                WebClient webClient = new WebClient();
                webClient.DownloadFile(ftp + dest_update + "/" + update_ext, appdata + servername + "\\" + dest_update + "\\" + update_ext);
      
                //Write into file update 
                TextWriter up_site = new StreamWriter(appdata + servername + "\\" + dest_update  + "\\" + update_site);
                up_site.WriteLine(ftp + dest_update + "/" + extention);
                up_site.Close();

                //Write into file update 
                TextWriter up_destlauncher = new StreamWriter(appdata + servername + "\\" + dest_update + "\\" + update_destlaunch);
                up_destlauncher.WriteLine(dlauncher);
                up_destlauncher.Close();

                MessageBox.Show(dlauncher + Environment.NewLine + ftp + dest_update + "/" + extention );



                Process.Start(appdata + servername + "\\" + dest_update + "\\" + update_ext );

        


            
                Application.Exit();

            }


          
            
        }

        private void Change_Lang_DoWork(object sender, DoWorkEventArgs e)
        {

            // French language */* Langage Français 
            if (language == "FR")
            {
                Group_Link.Text = "Liens";
                WebSite_bouton.Text = "Site Web";
                Play_bouton.Text = "Jouer";
                Option_Boutton.Text = "Options";
                destination_bouton.Text = "Destination";
            }

            // English language */* Langage Anglais
            if (language == "EN")
            {
                Group_Link.Text = "Links";
                WebSite_bouton.Text = "WebSite";
                Play_bouton.Text = "Play";
                Option_Boutton.Text = "Settings";
                destination_bouton.Text = "Destination";
            }
        }

        private void destination_bouton_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(language);
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