using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace launcherUpdate
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void startUpdate(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void wait_DoWork(object sender, DoWorkEventArgs e)
        {
            while (loadingProgress.Value < 25)
            {
                System.Threading.Thread.Sleep(50);
                loadingProgress.Value += 1;
            }
            System.Threading.Thread.Sleep(2000);
            while (loadingProgress.Value < 70)
            {
                System.Threading.Thread.Sleep(20);
                loadingProgress.Value += 1;
            }
            System.Threading.Thread.Sleep(500);
            while (loadingProgress.Value < 100)
            {
                System.Threading.Thread.Sleep(20);
                loadingProgress.Value += 1;
            }        
        }

        private void splash_Load(object sender, EventArgs e)
        {
            wait.RunWorkerAsync();
        }
    }
}
