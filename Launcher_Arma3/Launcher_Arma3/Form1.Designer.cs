namespace Launcher_Arma3
{
    partial class Launch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launch));
            this.Update_Launcher = new System.ComponentModel.BackgroundWorker();
            this.Change_Lang = new System.ComponentModel.BackgroundWorker();
            this.Folder = new System.Windows.Forms.FolderBrowserDialog();
            this.Download_Mods = new System.ComponentModel.BackgroundWorker();
            this.Erreur_Msg = new System.ComponentModel.BackgroundWorker();
            this.Fader = new System.Windows.Forms.Timer(this.components);
            this.Close = new System.Windows.Forms.Timer(this.components);
            this.Start_Arma = new System.ComponentModel.BackgroundWorker();
            this.News = new System.ComponentModel.BackgroundWorker();
            this.Anti_Cheat = new System.ComponentModel.BackgroundWorker();
            this.Music = new System.ComponentModel.BackgroundWorker();
            this.Download_CPP = new System.ComponentModel.BackgroundWorker();
            this.CheckInternet = new System.ComponentModel.BackgroundWorker();
            this.Changelogs = new System.ComponentModel.BackgroundWorker();
            this.Check_Mods = new System.ComponentModel.BackgroundWorker();
            this.Back_Test = new System.ComponentModel.BackgroundWorker();
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
            this.Option_Group = new iTalk.iTalk_GroupBox();
            this.Force_Update_Label = new iTalk.iTalk_Label();
            this.Force_Update = new iTalk.iTalk_CheckBox();
            this.Maintenance_Label = new Ambiance.Ambiance_Label();
            this.Sound = new System.Windows.Forms.PictureBox();
            this.Download_Group = new iTalk.iTalk_GroupBox();
            this.Download_Progressbar = new PerplexProgressBar();
            this.Label_modsdeal = new iTalk.iTalk_Label();
            this.Label_mods = new iTalk.iTalk_Label();
            this.Label_valu = new iTalk.iTalk_Label();
            this.Total_Progress = new iTalk.iTalk_ProgressBar();
            this.picture_darma = new System.Windows.Forms.PictureBox();
            this.credits_label = new System.Windows.Forms.Label();
            this.label_darma = new iTalk.iTalk_Label();
            this.connection_label = new iTalk.iTalk_Label();
            this.destination_bouton = new iTalk.iTalk_Button_2();
            this.Option_Boutton = new iTalk.iTalk_Button_1();
            this.Play_bouton = new iTalk.iTalk_Button_2();
            this.iTalk_ControlBox1 = new iTalk.iTalk_ControlBox();
            this.imagebox = new System.Windows.Forms.PictureBox();
            this.Group_Link = new iTalk.iTalk_GroupBox();
            this.Vocal_Icon = new System.Windows.Forms.PictureBox();
            this.Web_Icon = new System.Windows.Forms.PictureBox();
            this.notif_1 = new MonoFlat.MonoFlat_NotificationBox();
            this.News_Notif = new MonoFlat.MonoFlat_NotificationBox();
            this.Panel = new iTalk.iTalk_TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Changelogs_Serveur = new Ambiance.Ambiance_ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Changelogs_Launcher = new Ambiance.Ambiance_ListBox();
            this.Loading = new Ambiance.Ambiance_ProgressIndicator();
            this.Maintenance = new System.Windows.Forms.PictureBox();
            this.Delete_Mods = new System.ComponentModel.BackgroundWorker();
            this.iTalk_ThemeContainer1.SuspendLayout();
            this.Option_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sound)).BeginInit();
            this.Download_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_darma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagebox)).BeginInit();
            this.Group_Link.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vocal_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Web_Icon)).BeginInit();
            this.Panel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Maintenance)).BeginInit();
            this.SuspendLayout();
            // 
            // Update_Launcher
            // 
            this.Update_Launcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Update_Launcher_DoWork);
            // 
            // Change_Lang
            // 
            this.Change_Lang.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Change_Lang_DoWork);
            // 
            // Folder
            // 
            this.Folder.Description = "Choose Arma3 directory */* Choissisez la destination d\'arma3";
            this.Folder.SelectedPath = "C:\\Users\\Leo\\Desktop";
            // 
            // Download_Mods
            // 
            this.Download_Mods.WorkerReportsProgress = true;
            this.Download_Mods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Download_Mods_DoWork);
            this.Download_Mods.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.Download_Mods.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Erreur_Msg
            // 
            this.Erreur_Msg.WorkerReportsProgress = true;
            this.Erreur_Msg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Erreur_Msg_DoWork);
            // 
            // Fader
            // 
            this.Fader.Interval = 30;
            this.Fader.Tick += new System.EventHandler(this.Fader_Tick);
            // 
            // Close
            // 
            this.Close.Interval = 30;
            this.Close.Tick += new System.EventHandler(this.Close_Tick);
            // 
            // Start_Arma
            // 
            this.Start_Arma.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Start_Arma_DoWork);
            // 
            // News
            // 
            this.News.DoWork += new System.ComponentModel.DoWorkEventHandler(this.News_DoWork);
            // 
            // Anti_Cheat
            // 
            this.Anti_Cheat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Anti_Cheat_DoWork);
            // 
            // Music
            // 
            this.Music.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Music_DoWork);
            // 
            // Download_CPP
            // 
            this.Download_CPP.WorkerReportsProgress = true;
            this.Download_CPP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Download_CPP_DoWork);
            this.Download_CPP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Pont_Cpp);
            // 
            // CheckInternet
            // 
            this.CheckInternet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckInternet_DoWork);
            // 
            // Changelogs
            // 
            this.Changelogs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Changelogs_DoWork);
            // 
            // Check_Mods
            // 
            this.Check_Mods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Check_Mods_DoWork);
            // 
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.Option_Group);
            this.iTalk_ThemeContainer1.Controls.Add(this.Maintenance_Label);
            this.iTalk_ThemeContainer1.Controls.Add(this.Sound);
            this.iTalk_ThemeContainer1.Controls.Add(this.Download_Group);
            this.iTalk_ThemeContainer1.Controls.Add(this.picture_darma);
            this.iTalk_ThemeContainer1.Controls.Add(this.credits_label);
            this.iTalk_ThemeContainer1.Controls.Add(this.label_darma);
            this.iTalk_ThemeContainer1.Controls.Add(this.connection_label);
            this.iTalk_ThemeContainer1.Controls.Add(this.destination_bouton);
            this.iTalk_ThemeContainer1.Controls.Add(this.Option_Boutton);
            this.iTalk_ThemeContainer1.Controls.Add(this.Play_bouton);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_ControlBox1);
            this.iTalk_ThemeContainer1.Controls.Add(this.imagebox);
            this.iTalk_ThemeContainer1.Controls.Add(this.Group_Link);
            this.iTalk_ThemeContainer1.Controls.Add(this.notif_1);
            this.iTalk_ThemeContainer1.Controls.Add(this.News_Notif);
            this.iTalk_ThemeContainer1.Controls.Add(this.Panel);
            this.iTalk_ThemeContainer1.Controls.Add(this.Loading);
            this.iTalk_ThemeContainer1.Controls.Add(this.Maintenance);
            this.iTalk_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_ThemeContainer1.Name = "iTalk_ThemeContainer1";
            this.iTalk_ThemeContainer1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.iTalk_ThemeContainer1.Sizable = false;
            this.iTalk_ThemeContainer1.Size = new System.Drawing.Size(1004, 484);
            this.iTalk_ThemeContainer1.SmartBounds = false;
            this.iTalk_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.iTalk_ThemeContainer1.TabIndex = 0;
            this.iTalk_ThemeContainer1.Text = "Launcher Arma 3";
            this.iTalk_ThemeContainer1.DoubleClick += new System.EventHandler(this.Show_Launcher_Info);
            // 
            // Option_Group
            // 
            this.Option_Group.BackColor = System.Drawing.Color.Transparent;
            this.Option_Group.Controls.Add(this.Force_Update_Label);
            this.Option_Group.Controls.Add(this.Force_Update);
            this.Option_Group.Location = new System.Drawing.Point(786, 324);
            this.Option_Group.MinimumSize = new System.Drawing.Size(136, 50);
            this.Option_Group.Name = "Option_Group";
            this.Option_Group.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.Option_Group.Size = new System.Drawing.Size(212, 117);
            this.Option_Group.TabIndex = 30;
            this.Option_Group.Text = "Options";
            // 
            // Force_Update_Label
            // 
            this.Force_Update_Label.AutoSize = true;
            this.Force_Update_Label.BackColor = System.Drawing.Color.Transparent;
            this.Force_Update_Label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Force_Update_Label.ForeColor = System.Drawing.Color.Red;
            this.Force_Update_Label.Location = new System.Drawing.Point(31, 31);
            this.Force_Update_Label.Name = "Force_Update_Label";
            this.Force_Update_Label.Size = new System.Drawing.Size(111, 13);
            this.Force_Update_Label.TabIndex = 35;
            this.Force_Update_Label.Text = "Forcer la mise à jour";
            // 
            // Force_Update
            // 
            this.Force_Update.BackColor = System.Drawing.Color.Transparent;
            this.Force_Update.Checked = false;
            this.Force_Update.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Force_Update.ForeColor = System.Drawing.Color.LightCoral;
            this.Force_Update.Location = new System.Drawing.Point(6, 31);
            this.Force_Update.Name = "Force_Update";
            this.Force_Update.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Force_Update.Size = new System.Drawing.Size(136, 15);
            this.Force_Update.TabIndex = 34;
            this.Force_Update.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.Force_Update_CheckedChanged);
            // 
            // Maintenance_Label
            // 
            this.Maintenance_Label.AutoSize = true;
            this.Maintenance_Label.BackColor = System.Drawing.Color.Transparent;
            this.Maintenance_Label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Maintenance_Label.ForeColor = System.Drawing.Color.Red;
            this.Maintenance_Label.Location = new System.Drawing.Point(180, 140);
            this.Maintenance_Label.Name = "Maintenance_Label";
            this.Maintenance_Label.Size = new System.Drawing.Size(0, 20);
            this.Maintenance_Label.TabIndex = 29;
            // 
            // Sound
            // 
            this.Sound.BackColor = System.Drawing.Color.Transparent;
            this.Sound.Cursor = System.Windows.Forms.Cursors.Default;
            this.Sound.Image = ((System.Drawing.Image)(resources.GetObject("Sound.Image")));
            this.Sound.Location = new System.Drawing.Point(6, 460);
            this.Sound.Name = "Sound";
            this.Sound.Size = new System.Drawing.Size(34, 24);
            this.Sound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Sound.TabIndex = 24;
            this.Sound.TabStop = false;
            this.Sound.Click += new System.EventHandler(this.Show_Launcher_Info);
            // 
            // Download_Group
            // 
            this.Download_Group.BackColor = System.Drawing.Color.Transparent;
            this.Download_Group.Controls.Add(this.Download_Progressbar);
            this.Download_Group.Controls.Add(this.Label_modsdeal);
            this.Download_Group.Controls.Add(this.Label_mods);
            this.Download_Group.Controls.Add(this.Label_valu);
            this.Download_Group.Controls.Add(this.Total_Progress);
            this.Download_Group.Cursor = System.Windows.Forms.Cursors.Default;
            this.Download_Group.Location = new System.Drawing.Point(230, 258);
            this.Download_Group.MinimumSize = new System.Drawing.Size(136, 50);
            this.Download_Group.Name = "Download_Group";
            this.Download_Group.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.Download_Group.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Download_Group.Size = new System.Drawing.Size(550, 183);
            this.Download_Group.TabIndex = 19;
            this.Download_Group.Text = "Téléchargement";
            this.Download_Group.Visible = false;
            // 
            // Download_Progressbar
            // 
            this.Download_Progressbar.BackColor = System.Drawing.Color.Transparent;
            this.Download_Progressbar.Location = new System.Drawing.Point(8, 31);
            this.Download_Progressbar.Maximum = 100;
            this.Download_Progressbar.Name = "Download_Progressbar";
            this.Download_Progressbar.ShowPercentage = false;
            this.Download_Progressbar.Size = new System.Drawing.Size(534, 38);
            this.Download_Progressbar.TabIndex = 25;
            this.Download_Progressbar.Text = "perplexProgressBar1";
            this.Download_Progressbar.Value = 0;
            // 
            // Label_modsdeal
            // 
            this.Label_modsdeal.AutoSize = true;
            this.Label_modsdeal.BackColor = System.Drawing.Color.Transparent;
            this.Label_modsdeal.Font = new System.Drawing.Font("Impact", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_modsdeal.ForeColor = System.Drawing.Color.Black;
            this.Label_modsdeal.Location = new System.Drawing.Point(8, 116);
            this.Label_modsdeal.Name = "Label_modsdeal";
            this.Label_modsdeal.Size = new System.Drawing.Size(91, 15);
            this.Label_modsdeal.TabIndex = 24;
            this.Label_modsdeal.Text = "Mods Treaty:  0 / 0 ";
            // 
            // Label_mods
            // 
            this.Label_mods.AutoSize = true;
            this.Label_mods.BackColor = System.Drawing.Color.Transparent;
            this.Label_mods.Font = new System.Drawing.Font("Impact", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_mods.ForeColor = System.Drawing.Color.Black;
            this.Label_mods.Location = new System.Drawing.Point(8, 101);
            this.Label_mods.Name = "Label_mods";
            this.Label_mods.Size = new System.Drawing.Size(98, 15);
            this.Label_mods.TabIndex = 22;
            this.Label_mods.Text = "Download:  ******.pbo";
            // 
            // Label_valu
            // 
            this.Label_valu.AutoSize = true;
            this.Label_valu.BackColor = System.Drawing.Color.Transparent;
            this.Label_valu.Font = new System.Drawing.Font("Impact", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_valu.ForeColor = System.Drawing.Color.Black;
            this.Label_valu.Location = new System.Drawing.Point(8, 86);
            this.Label_valu.Name = "Label_valu";
            this.Label_valu.Size = new System.Drawing.Size(73, 15);
            this.Label_valu.TabIndex = 20;
            this.Label_valu.Text = "Progress: 0 / 0";
            // 
            // Total_Progress
            // 
            this.Total_Progress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Total_Progress.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.Total_Progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Total_Progress.Location = new System.Drawing.Point(442, 75);
            this.Total_Progress.Maximum = ((long)(100));
            this.Total_Progress.MinimumSize = new System.Drawing.Size(100, 100);
            this.Total_Progress.Name = "Total_Progress";
            this.Total_Progress.ProgressColor1 = System.Drawing.Color.Lime;
            this.Total_Progress.ProgressColor2 = System.Drawing.Color.Lime;
            this.Total_Progress.ProgressShape = iTalk.iTalk_ProgressBar._ProgressShape.Flat;
            this.Total_Progress.Size = new System.Drawing.Size(100, 100);
            this.Total_Progress.TabIndex = 17;
            this.Total_Progress.Text = "Total_Progress";
            this.Total_Progress.Value = ((long)(0));
            // 
            // picture_darma
            // 
            this.picture_darma.Location = new System.Drawing.Point(6, 438);
            this.picture_darma.Name = "picture_darma";
            this.picture_darma.Size = new System.Drawing.Size(20, 19);
            this.picture_darma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_darma.TabIndex = 14;
            this.picture_darma.TabStop = false;
            // 
            // credits_label
            // 
            this.credits_label.AutoSize = true;
            this.credits_label.BackColor = System.Drawing.Color.Transparent;
            this.credits_label.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credits_label.ForeColor = System.Drawing.Color.White;
            this.credits_label.Location = new System.Drawing.Point(789, 469);
            this.credits_label.Name = "credits_label";
            this.credits_label.Size = new System.Drawing.Size(211, 15);
            this.credits_label.TabIndex = 13;
            this.credits_label.Text = "Copyright HUBERT Léo © 2014 - 2015";
            // 
            // label_darma
            // 
            this.label_darma.AutoSize = true;
            this.label_darma.BackColor = System.Drawing.Color.Transparent;
            this.label_darma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_darma.ForeColor = System.Drawing.Color.Black;
            this.label_darma.Location = new System.Drawing.Point(32, 443);
            this.label_darma.Name = "label_darma";
            this.label_darma.Size = new System.Drawing.Size(105, 13);
            this.label_darma.TabIndex = 12;
            this.label_darma.Text = "Arma3 Directory: ";
            // 
            // connection_label
            // 
            this.connection_label.AutoSize = true;
            this.connection_label.BackColor = System.Drawing.Color.Transparent;
            this.connection_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connection_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.connection_label.Location = new System.Drawing.Point(2, 421);
            this.connection_label.Name = "connection_label";
            this.connection_label.Size = new System.Drawing.Size(82, 18);
            this.connection_label.TabIndex = 11;
            this.connection_label.Text = "Loading ..";
            // 
            // destination_bouton
            // 
            this.destination_bouton.BackColor = System.Drawing.Color.Transparent;
            this.destination_bouton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.destination_bouton.ForeColor = System.Drawing.Color.White;
            this.destination_bouton.Image = null;
            this.destination_bouton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.destination_bouton.Location = new System.Drawing.Point(12, 258);
            this.destination_bouton.Name = "destination_bouton";
            this.destination_bouton.Size = new System.Drawing.Size(212, 40);
            this.destination_bouton.TabIndex = 8;
            this.destination_bouton.Text = "Destination";
            this.destination_bouton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.destination_bouton.Click += new System.EventHandler(this.destination_bouton_Click_1);
            // 
            // Option_Boutton
            // 
            this.Option_Boutton.BackColor = System.Drawing.Color.Transparent;
            this.Option_Boutton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Option_Boutton.Image = null;
            this.Option_Boutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option_Boutton.Location = new System.Drawing.Point(12, 304);
            this.Option_Boutton.Name = "Option_Boutton";
            this.Option_Boutton.Size = new System.Drawing.Size(212, 33);
            this.Option_Boutton.TabIndex = 7;
            this.Option_Boutton.Text = "Options";
            this.Option_Boutton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Option_Boutton.Click += new System.EventHandler(this.Option_Boutton_Click);
            // 
            // Play_bouton
            // 
            this.Play_bouton.BackColor = System.Drawing.Color.Transparent;
            this.Play_bouton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Play_bouton.ForeColor = System.Drawing.Color.White;
            this.Play_bouton.Image = null;
            this.Play_bouton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Play_bouton.Location = new System.Drawing.Point(786, 258);
            this.Play_bouton.Name = "Play_bouton";
            this.Play_bouton.Size = new System.Drawing.Size(212, 60);
            this.Play_bouton.TabIndex = 6;
            this.Play_bouton.Text = "Play";
            this.Play_bouton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Play_bouton.Click += new System.EventHandler(this.play_bouton_Click);
            // 
            // iTalk_ControlBox1
            // 
            this.iTalk_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ControlBox1.Location = new System.Drawing.Point(923, -1);
            this.iTalk_ControlBox1.Name = "iTalk_ControlBox1";
            this.iTalk_ControlBox1.Size = new System.Drawing.Size(77, 19);
            this.iTalk_ControlBox1.TabIndex = 5;
            this.iTalk_ControlBox1.Text = "iTalk_ControlBox1";
            // 
            // imagebox
            // 
            this.imagebox.BackColor = System.Drawing.Color.Transparent;
            this.imagebox.Image = ((System.Drawing.Image)(resources.GetObject("imagebox.Image")));
            this.imagebox.Location = new System.Drawing.Point(6, 31);
            this.imagebox.Name = "imagebox";
            this.imagebox.Size = new System.Drawing.Size(992, 221);
            this.imagebox.TabIndex = 4;
            this.imagebox.TabStop = false;
            // 
            // Group_Link
            // 
            this.Group_Link.BackColor = System.Drawing.Color.Transparent;
            this.Group_Link.Controls.Add(this.Vocal_Icon);
            this.Group_Link.Controls.Add(this.Web_Icon);
            this.Group_Link.Location = new System.Drawing.Point(12, 343);
            this.Group_Link.MinimumSize = new System.Drawing.Size(136, 50);
            this.Group_Link.Name = "Group_Link";
            this.Group_Link.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.Group_Link.Size = new System.Drawing.Size(212, 75);
            this.Group_Link.TabIndex = 2;
            this.Group_Link.Text = "Links";
            this.Group_Link.DoubleClick += new System.EventHandler(this.Show_Launcher_Info);
            // 
            // Vocal_Icon
            // 
            this.Vocal_Icon.Image = global::Launcher_Arma3.Properties.Resources.teamspeak_icon;
            this.Vocal_Icon.Location = new System.Drawing.Point(154, 27);
            this.Vocal_Icon.Name = "Vocal_Icon";
            this.Vocal_Icon.Size = new System.Drawing.Size(50, 40);
            this.Vocal_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Vocal_Icon.TabIndex = 1;
            this.Vocal_Icon.TabStop = false;
            this.Vocal_Icon.Click += new System.EventHandler(this.Vocal_bouton_Click);
            // 
            // Web_Icon
            // 
            this.Web_Icon.Image = global::Launcher_Arma3.Properties.Resources.website_icon;
            this.Web_Icon.Location = new System.Drawing.Point(8, 27);
            this.Web_Icon.Name = "Web_Icon";
            this.Web_Icon.Size = new System.Drawing.Size(50, 40);
            this.Web_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Web_Icon.TabIndex = 0;
            this.Web_Icon.TabStop = false;
            this.Web_Icon.Click += new System.EventHandler(this.WebSite_bouton_Click);
            // 
            // notif_1
            // 
            this.notif_1.BorderCurve = 8;
            this.notif_1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.notif_1.Image = null;
            this.notif_1.Location = new System.Drawing.Point(6, 31);
            this.notif_1.MinimumSize = new System.Drawing.Size(100, 40);
            this.notif_1.Name = "notif_1";
            this.notif_1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
            this.notif_1.RoundCorners = false;
            this.notif_1.ShowCloseButton = false;
            this.notif_1.Size = new System.Drawing.Size(992, 40);
            this.notif_1.TabIndex = 0;
            // 
            // News_Notif
            // 
            this.News_Notif.BorderCurve = 8;
            this.News_Notif.Font = new System.Drawing.Font("Tahoma", 9F);
            this.News_Notif.Image = null;
            this.News_Notif.Location = new System.Drawing.Point(6, 212);
            this.News_Notif.MinimumSize = new System.Drawing.Size(100, 40);
            this.News_Notif.Name = "News_Notif";
            this.News_Notif.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Notice;
            this.News_Notif.RoundCorners = false;
            this.News_Notif.ShowCloseButton = true;
            this.News_Notif.Size = new System.Drawing.Size(992, 40);
            this.News_Notif.TabIndex = 23;
            // 
            // Panel
            // 
            this.Panel.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.Panel.Controls.Add(this.tabPage1);
            this.Panel.Controls.Add(this.tabPage2);
            this.Panel.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Panel.ItemSize = new System.Drawing.Size(44, 135);
            this.Panel.Location = new System.Drawing.Point(230, 258);
            this.Panel.Multiline = true;
            this.Panel.Name = "Panel";
            this.Panel.SelectedIndex = 0;
            this.Panel.Size = new System.Drawing.Size(545, 183);
            this.Panel.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Panel.TabIndex = 27;
            this.Panel.DoubleClick += new System.EventHandler(this.Show_Launcher_Info);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage1.Controls.Add(this.Changelogs_Serveur);
            this.tabPage1.Location = new System.Drawing.Point(139, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(402, 175);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serveur";
            // 
            // Changelogs_Serveur
            // 
            this.Changelogs_Serveur.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Changelogs_Serveur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Changelogs_Serveur.FormattingEnabled = true;
            this.Changelogs_Serveur.IntegralHeight = false;
            this.Changelogs_Serveur.ItemHeight = 18;
            this.Changelogs_Serveur.Items.AddRange(new object[] {
            "Loading ....",
            "Please Wait !"});
            this.Changelogs_Serveur.Location = new System.Drawing.Point(6, 6);
            this.Changelogs_Serveur.Name = "Changelogs_Serveur";
            this.Changelogs_Serveur.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Changelogs_Serveur.Size = new System.Drawing.Size(390, 166);
            this.Changelogs_Serveur.TabIndex = 26;
            this.Changelogs_Serveur.DoubleClick += new System.EventHandler(this.Show_Launcher_Info);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage2.Controls.Add(this.Changelogs_Launcher);
            this.tabPage2.Location = new System.Drawing.Point(139, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(402, 175);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Launcher";
            // 
            // Changelogs_Launcher
            // 
            this.Changelogs_Launcher.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Changelogs_Launcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Changelogs_Launcher.FormattingEnabled = true;
            this.Changelogs_Launcher.IntegralHeight = false;
            this.Changelogs_Launcher.ItemHeight = 18;
            this.Changelogs_Launcher.Items.AddRange(new object[] {
            "Loading ....",
            "Please Wait !"});
            this.Changelogs_Launcher.Location = new System.Drawing.Point(6, 6);
            this.Changelogs_Launcher.Name = "Changelogs_Launcher";
            this.Changelogs_Launcher.Size = new System.Drawing.Size(390, 166);
            this.Changelogs_Launcher.TabIndex = 0;
            // 
            // Loading
            // 
            this.Loading.Location = new System.Drawing.Point(447, 289);
            this.Loading.MinimumSize = new System.Drawing.Size(80, 80);
            this.Loading.Name = "Loading";
            this.Loading.P_AnimationColor = System.Drawing.Color.Gray;
            this.Loading.P_AnimationSpeed = 100;
            this.Loading.P_BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Loading.Size = new System.Drawing.Size(107, 107);
            this.Loading.TabIndex = 25;
            this.Loading.Text = "ambiance_ProgressIndicator1";
            this.Loading.Visible = false;
            // 
            // Maintenance
            // 
            this.Maintenance.InitialImage = ((System.Drawing.Image)(resources.GetObject("Maintenance.InitialImage")));
            this.Maintenance.Location = new System.Drawing.Point(161, 101);
            this.Maintenance.Name = "Maintenance";
            this.Maintenance.Size = new System.Drawing.Size(10, 10);
            this.Maintenance.TabIndex = 28;
            this.Maintenance.TabStop = false;
            // 
            // Delete_Mods
            // 
            this.Delete_Mods.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Delete_Mods_DoWork);
            this.Delete_Mods.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Delete_mods_RunWorkerCompleted);
            // 
            // Launch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1004, 484);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Launch";
            this.Opacity = 0D;
            this.Text = "Launcher Arma 3";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Launch_FormClosed);
            this.Load += new System.EventHandler(this.Launch_Load);
            this.Click += new System.EventHandler(this.Close_Form);
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.iTalk_ThemeContainer1.PerformLayout();
            this.Option_Group.ResumeLayout(false);
            this.Option_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sound)).EndInit();
            this.Download_Group.ResumeLayout(false);
            this.Download_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_darma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagebox)).EndInit();
            this.Group_Link.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Vocal_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Web_Icon)).EndInit();
            this.Panel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Maintenance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private MonoFlat.MonoFlat_NotificationBox notif_1;
        private iTalk.iTalk_GroupBox Group_Link;
        private System.Windows.Forms.PictureBox imagebox;
        private iTalk.iTalk_ControlBox iTalk_ControlBox1;
        private iTalk.iTalk_Button_2 Play_bouton;
        private System.ComponentModel.BackgroundWorker Update_Launcher;
        private iTalk.iTalk_Button_1 Option_Boutton;
        private iTalk.iTalk_Button_2 destination_bouton;
        private System.ComponentModel.BackgroundWorker Change_Lang;
        private iTalk.iTalk_Label connection_label;
        private System.Windows.Forms.FolderBrowserDialog Folder;
        private iTalk.iTalk_Label label_darma;
        protected System.Windows.Forms.Label credits_label;
        private System.Windows.Forms.PictureBox picture_darma;
        private System.ComponentModel.BackgroundWorker Download_Mods;
        private iTalk.iTalk_ProgressBar Total_Progress;
        private System.ComponentModel.BackgroundWorker Erreur_Msg;
        private System.Windows.Forms.Timer Fader;
        private iTalk.iTalk_GroupBox Download_Group;
        private System.Windows.Forms.Timer Close;
        private System.ComponentModel.BackgroundWorker Start_Arma;
        private iTalk.iTalk_Label Label_valu;
        private PerplexProgressBar Download_Progress;
        private iTalk.iTalk_Label Label_mods;
        private MonoFlat.MonoFlat_NotificationBox News_Notif;
        private System.ComponentModel.BackgroundWorker News;
        private iTalk.iTalk_Label Label_modsdeal;
        private System.ComponentModel.BackgroundWorker Anti_Cheat;
        private System.ComponentModel.BackgroundWorker Music;
        private System.Windows.Forms.PictureBox Sound;
        private PerplexProgressBar Download_Progressbar;
        private System.ComponentModel.BackgroundWorker Download_CPP;
        private Ambiance.Ambiance_ProgressIndicator Loading;
        private System.ComponentModel.BackgroundWorker CheckInternet;
        private iTalk.iTalk_TabControl Panel;
        private System.Windows.Forms.TabPage tabPage1;
        private Ambiance.Ambiance_ListBox Changelogs_Serveur;
        private System.Windows.Forms.TabPage tabPage2;
        private Ambiance.Ambiance_ListBox Changelogs_Launcher;
        private System.ComponentModel.BackgroundWorker Changelogs;
        private System.Windows.Forms.PictureBox Maintenance;
        private Ambiance.Ambiance_Label Maintenance_Label;
        private System.ComponentModel.BackgroundWorker Check_Mods;
        private System.ComponentModel.BackgroundWorker Back_Test;
        private System.Windows.Forms.PictureBox Vocal_Icon;
        private System.Windows.Forms.PictureBox Web_Icon;
        private iTalk.iTalk_GroupBox Option_Group;
        private iTalk.iTalk_CheckBox Force_Update;
        private iTalk.iTalk_Label Force_Update_Label;
        private System.ComponentModel.BackgroundWorker Delete_Mods;

    }
}

