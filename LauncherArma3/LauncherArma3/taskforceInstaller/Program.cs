using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskforceInstaller
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] av)
        {
            if (av.Length != 6)
            {
                MessageBox.Show("You cannot launch this program manualy !");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new taskforceMain(av[0], av[1], av[2], av[3], av[4], av[5]));
        }
    }
}
