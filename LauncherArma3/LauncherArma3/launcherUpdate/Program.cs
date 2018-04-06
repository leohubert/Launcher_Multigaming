using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace launcherUpdate
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] av)
        {     
            if (av.Length != 3)
             {              
                 MessageBox.Show("You can't open manually this software.");
                 return;
             }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new updateMain(av[0], av[1], av[2]));
        }
    }
}
