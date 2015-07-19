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

namespace Launcher_Updater
{
    public partial class Form1 : Form
    {

        //|------ READ ME------|
        //
        // This is the launcher update program
        // 
        // This source code is translated in " ENGLISH */* FRENCH "
        // Ce code source est traduit en " ANGLAIS */* FRANCAIS "
        //
        //|------ READ ME ------|

        // Settings of file requerement */* Paramètre des fichiers requis
        string update_site = "up_site.txt";
        string update_destlaunch = "up_patch.txt";

        // Anex Settings */* Paramètres anex
        string site = "";
        string patch = "";

        // [CREDIT][DO NOT REMOVE]
        //
        // This module was written by HUBERT Léo 
        //
        // Copyright HUBERT Léo © 2014 - 2015
        //
        // [CREDIT][DO NOT REMOVE]


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Give link and directory of launcher for update */* Donne la destination et le lien du launcher pour la mise à jour 

            if (File.Exists(update_destlaunch))
            {
               patch = File.ReadAllText(update_destlaunch);
            
            }
            else
            {
                MessageBox.Show("Erreur #01650 | Any destination for the launcher update is given " + Environment.NewLine
                                + "" + Environment.NewLine
                                + "Please contact your administrator !");
               Application.Exit();
            }

            if (File.Exists(update_site))
            {
               string site = File.ReadAllText(update_site);
            }
            else
            {
                MessageBox.Show("Erreur #01651 | Any link for the launcher update is given " + Environment.NewLine
                                + "" + Environment.NewLine
                                + "Please contact your administrator !");
                 Application.Exit();
            }


            // Load update program */* Charge le programme de mise à jour
            launcher_updater.RunWorkerAsync();
        }

        private void launcher_updater_DoWork(object sender, DoWorkEventArgs e)
        {

           
            // the URL to download the file from
            string sUrlToReadFileFrom = site.ToString();
            // the path to write the file to
            string sFilePathToWriteFileTo = patch.ToString();
            


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
                            launcher_updater.ReportProgress(iProgressPercentage);
                        }

                        // clean up the file stream
                        streamLocal.Close();
                    }

                    // close the connection to the remote server
                    streamRemote.Close();
                }
            }
        }
    

        

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (File.Exists(patch))
            {
                Process.Start(patch);
            } else
            {
                MessageBox.Show("Erreur #204  |  New Launcher Downloaded is not present in your computer ");
            }

            Application.Exit();
           
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