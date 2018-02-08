/**
 * @Author: hubert_i
 * @Date:   2018-01-09T22:20:28+01:00
 * @Email:  leo.hubert@epitech.eu
 * @Last modified by:   hubert_i
 * @Last modified time: 2018-01-09T23:00:16+01:00
 */



﻿using System;
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

            string communityName = "Emodyz";  /* Your serverName */
            string apiUrl = "http://51.255.171.192:8080/"; /* Link to API launcher Arma 3 */

            /* FTP NO FUNCTIONAL */

            string ftp_url = "ftp://yoururl";
            string ftp_user = "username";
            string ftp_pass = "passwd";

            /* FTP NO FUNCTIONAL */

            bool modDev = true;  /* enable or disable modDev */
            string defaultLanguage = null; /* set to "FR" or "EN" or other for disable just set to null */

            /* ANOTHER VARIABLE */

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/v5.";
            string sessionToken = null;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Directory.Exists(appdata + communityName))
                Directory.CreateDirectory(appdata + communityName);
            if (defaultLanguage != null)
            {
              Application.Run(new loginForm(communityName, apiUrl, ftp_url, ftp_user, ftp_pass, modDev, defaultLanguage));
            }
            else if (File.Exists(appdata + communityName + "/language.lang"))
            {
                Application.Run(new loginForm(communityName, apiUrl, ftp_url, ftp_user, ftp_pass, modDev, defaultLanguage));
            }
            else
            {
                Application.Run(new languageChoice(communityName, false));
                Application.Run(new loginForm(communityName, apiUrl, ftp_url, ftp_user, ftp_pass, modDev, defaultLanguage));
            }
        }
    }
}
