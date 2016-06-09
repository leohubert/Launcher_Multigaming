using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherArma3
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* GENERAL OPTIONS */

            string serverName = "Emodyz";  /* Your serverName */
            string apiUrl = "http://51.255.171.192/"; /* Link to API launcher Arma 3 */
            string webSite = "http://emodyz.com/"; /* Your webSite */
            string ftp_url = "ftp://localhost"; /* Your ftp server */
            string ftp_user = "launcher";
            string ftp_pass = "20071997";

            bool modDev = true;  /* enable or disable modDev */

            /* ANOTHER VARIABLE */

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
            string sessionToken = null;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Directory.Exists(appdata + serverName))
                Directory.CreateDirectory(appdata + serverName);
            if (File.Exists(appdata + serverName + "/language.lang"))
            {
                Application.Run(new loginForm(serverName, apiUrl, webSite, ftp_url, ftp_user, ftp_pass, modDev));
            }
            else
            {
                Application.Run(new languageChoice(serverName, false));
                Application.Run(new loginForm(serverName, apiUrl, webSite, ftp_url, ftp_user, ftp_pass, modDev));
            }
        }
    }
}
