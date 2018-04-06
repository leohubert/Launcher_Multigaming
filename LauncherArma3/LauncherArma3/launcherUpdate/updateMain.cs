using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace launcherUpdate
{
    public partial class updateMain : MetroFramework.Forms.MetroForm
    {
        private MaterialSkinManager materialSkinManager;
        string webUrl;
        string localUrl;
        string process;    

        public updateMain(string web, string local, string proc)
        {
            InitializeComponent();
            webUrl = web;
            localUrl = local;
            process = proc;
        }

        private void updateMain_Load(object sender, EventArgs e)
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan400, Primary.Indigo700, Primary.Indigo100, Accent.LightGreen200, TextShade.WHITE);
            download_update();
        }

        async void download_update()
        {
            bool ok = false;
            while (ok != true)
            {
                try
                {
                    Process[] proc = Process.GetProcessesByName(process);
                    proc[0].Kill();
                }
                catch
                {
                    Thread thread = new Thread(() =>
                    {
                        WebClient client = new WebClient();
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                        client.DownloadFileAsync(new Uri(webUrl), localUrl);
                    });
                    thread.Start();
                    ok = true;
                }
                await Task.Delay(1000);
            }


        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                downloadLabel.Text = "Downloaded " + e.BytesReceived / 1024 + " Mb of " + e.TotalBytesToReceive / 1024 + " Mb";
                downloadProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                downloadLabel.Text = "Completed";
            });
            try
            {
                Process launcher = new Process();
                launcher.StartInfo.FileName = localUrl;
                launcher.Start();
                this.Close();
            }
            catch
            {
                this.Close();
            }

        }
    }
}
