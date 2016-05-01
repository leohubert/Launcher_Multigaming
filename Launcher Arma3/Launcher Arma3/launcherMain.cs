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
using MetroFramework.Animation;
using MetroFramework.Components;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Launcher_Arma3
{
    public partial class launcherMain : MetroFramework.Forms.MetroForm
    {

        /* Launcher basic config */
        string apiUrl = "http://localhost/API/";   /* Link to API launcher Arma 3 */


        /* Variables globals */

        bool login = false;
        bool connected = false;
        bool internet;

        public launcherMain()
        {
            InitializeComponent();
        }

        private void launcherMain_Load(object sender, EventArgs e)
        {

        }

        private void checkOptions(object sender, EventArgs e)
        {
            try
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
                        this.Style = "Orange";
                        return;
                    }
                    if (stuff.login == "1")
                    {
                        login = true;
                        loginBox.Visible = true;
                        this.Style = "Red";
                    }
                    if (stuff.news == "1")
                    {
                        staffMessage.Text = stuff.news_msg;
                        staffMessage.Visible = true;
                    }
                    pictureBig.Visible = false;
                    internet = true;
                }
            }
            catch
            {
                errorBox.Visible = true;
                errorBox.Text = "Error #404: Internet or Serveur not found.";
                internet = false;
                pictureBig.Visible = false;
            }

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {

                byte[] response =
                client.UploadValues(apiUrl + "login.php", new NameValueCollection()
                {
                    { "login", loginUsername.Text},
                    { "password", loginPassword.Text}
                });

                string result = System.Text.Encoding.UTF8.GetString(response);
                dynamic stuff = JObject.Parse(result);

                checkNotif();

                if (stuff.status == "42")
                {
                    errorBox.Visible = false;
                    loginBox.Visible = false;
                    succesBox.Visible = true;
                    succesBox.Text = stuff.msg;
                    this.Style = "Green";
                }
                else
                {
                    errorBox.Visible = true;
                    errorBox.Text = stuff.msg;
                }
            }
        }

        void checkNotif()
        {
            /* Ne me demandez pas pourquoi ça marche moi même je ne pige pas xD */
            if (errorBox.Visible == false)
                errorBox.Visible = false;
            if (infoBox.Visible == false)
                infoBox.Visible = false;
            if (succesBox.Visible == false)
                succesBox.Visible = false;
        }
    }
}