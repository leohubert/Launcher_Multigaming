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
		

        string site = "";
        string patch = "";
        string dlauncher = Application.StartupPath + "\\";

        string file_patch = "update.txt";
        string file_site = "site.txt";


        bool siteon = true;
        bool patchon = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (File.Exists(file_patch))
            {
                patch = File.ReadAllText(file_patch);
            }
            else
            {
                patchon = false;
            }

            if (File.Exists(file_site))
            {
                site = File.ReadAllText(file_site);
            }
            else
            {
                siteon = false;
            }


            // If file is not exists stop the update and show a message */* Si les fichier n'existe pas on montre un message et on stop la mise à jour !
            if (siteon == false )
            {
                MessageBox.Show("Erreur #202 | Les fichiers requis ne sont pas présent !");
                Application.Exit();
            }
            if (patchon == false)
            {
                MessageBox.Show("Erreur #202 | Les fichiers requis ne sont pas présent !");
                Application.Exit();
            }


            update_launcher.RunWorkerAsync();


        }

        private void update_launcher_DoWork(object sender, DoWorkEventArgs e)
        {
            // the URL to download the file from
             string sUrlToReadFileFrom = site;
             // the path to write the file to
             string sFilePathToWriteFileTo = patch;
 
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

                        update_launcher.ReportProgress(iProgressPercentage);
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
            }

            Application.Exit();
        }

    }
}
