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
            string apiUrl = "http://localhost/public/"; /* Link to API launcher Arma 3 */
            string webSite = "http://emodyz.com/"; /* Your webSite */

            /* ANOTHER VARIABLE */

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists(appdata + serverName))
                Directory.CreateDirectory(appdata + serverName);
            if (File.Exists(appdata + serverName + "/language.lang"))
            {
                Application.Run(new launcherMain(serverName, apiUrl, webSite));
            }
            else
            {
                Application.Run(new languageChoice(serverName));
                Application.Run(new launcherMain(serverName, apiUrl, webSite));
            }
        }
    }
}
