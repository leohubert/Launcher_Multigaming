using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Launcher_Arma3
{
    public partial class launcherMain : MetroFramework.Forms.MetroForm
    {

        /* Launcher basic config */
        string apiUrl = "http://localhost/";   /* Link to API launcher Arma 3 */


        public launcherMain()
        {
            InitializeComponent();
        }

        private void launcherMain_Load(object sender, EventArgs e)
        {

        }

        private void checkOptions(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {

                byte[] response =
                client.UploadValues(apiUrl + "options.php", new NameValueCollection());
                string result = System.Text.Encoding.UTF8.GetString(response);
                dynamic stuff = JObject.Parse(result);

                if (stuff.maintenance == "1")
                {
                    infoBox.Visible = true;
                    infoBox.Text = stuff.maintenance_msg;
                    pictureBig.ImageLocation = stuff.maintenance_image;
                    return;
                }
                if (stuff.news == "1")
                {

                }
                pictureBig.Visible = false;
                notification("TEST", "Ceci est un test");
            }
        }

        void notification(string title, string message)
        {
            notif.ShowBalloonTip(1000, title, message, ToolTipIcon.Info);
        }
    }
}