using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Launcher_Arma3
{

    public partial class Form2 : Form
    {

        string language = "FR";

        public Form2(string value)
        {
            InitializeComponent();
            language = value;
        }


    
        private void Form2_Load(object sender, EventArgs e)
        {

          
            // Change the language form */* Change la langue du Form
            change_language.RunWorkerAsync();

           
  
        }

        private void iTalk_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Language_Chose.Text == "English")
            {
                language = "EN";
                change_language.RunWorkerAsync();

            }
            if (Language_Chose.Text == "Français")
            {
                language = "FR";
                change_language.RunWorkerAsync();
         
            }
            if (Language_Chose.Text == "Allemand")
            {
                language = "AL";
                change_language.RunWorkerAsync();

            }
        }



        private void iTalk_Icon_Tick1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void change_language_DoWork(object sender, DoWorkEventArgs e)
        {
    
            if (language == "FR")
            {
                monoFlat_ThemeContainer1.Text = "Launcher Options";
                Language_label.Text = "Langage: ";
                Language_Chose.Text = "Français";
            }
            if (language == "EN")
            {
                monoFlat_ThemeContainer1.Text = "Launcher Settings";
                Language_label.Text = "Language: ";
                Language_Chose.Text = "English";
            }

            if (language == "AL")
            {
                monoFlat_ThemeContainer1.Text = "Einstellungen";
                Language_label.Text = "Sprache: ";
                Language_Chose.Text = "Allemand";
            }

        }


    }
}
