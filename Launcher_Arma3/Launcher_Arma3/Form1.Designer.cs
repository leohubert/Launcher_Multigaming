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
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
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
            this.Loading = new Ambiance.Ambiance_ProgressIndicator();
            this.connection_label = new iTalk.iTalk_Label();
            this.destination_bouton = new iTalk.iTalk_Button_2();
            this.Option_Boutton = new iTalk.iTalk_Button_1();
            this.Play_bouton = new iTalk.iTalk_Button_2();
            this.iTalk_ControlBox1 = new iTalk.iTalk_ControlBox();
            this.imagebox = new System.Windows.Forms.PictureBox();
            this.Group_Link = new iTalk.iTalk_GroupBox();
            this.WebSite_bouton = new MonoFlat.MonoFlat_Button();
            this.Vocal_bouton = new MonoFlat.MonoFlat_Button();
            this.notif_1 = new MonoFlat.MonoFlat_NotificationBox();
            this.News_Notif = new MonoFlat.MonoFlat_NotificationBox();
            this.iTalk_ThemeContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sound)).BeginInit();
            this.Download_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_darma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagebox)).BeginInit();
            this.Group_Link.SuspendLayout();
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
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.Sound);
            this.iTalk_ThemeContainer1.Controls.Add(this.Download_Group);
            this.iTalk_ThemeContainer1.Controls.Add(this.picture_darma);
            this.iTalk_ThemeContainer1.Controls.Add(this.credits_label);
            this.iTalk_ThemeContainer1.Controls.Add(this.label_darma);
            this.iTalk_ThemeContainer1.Controls.Add(this.Loading);
            this.iTalk_ThemeContainer1.Controls.Add(this.connection_label);
            this.iTalk_ThemeContainer1.Controls.Add(this.destination_bouton);
            this.iTalk_ThemeContainer1.Controls.Add(this.Option_Boutton);
            this.iTalk_ThemeContainer1.Controls.Add(this.Play_bouton);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_ControlBox1);
            this.iTalk_ThemeContainer1.Controls.Add(this.imagebox);
            this.iTalk_ThemeContainer1.Controls.Add(this.Group_Link);
            this.iTalk_ThemeContainer1.Controls.Add(this.notif_1);
            this.iTalk_ThemeContainer1.Controls.Add(this.News_Notif);
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
            // Sound
            // 
            this.Sound.BackColor = System.Drawing.Color.Transparent;
            this.Sound.Cursor = System.Windows.Forms.Cursors.Default;
            this.Sound.Image = global::Launcher_Arma3.Properties.Resources.muted;
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
            this.Download_Progressbar.Location = new System.Drawing.Point(11, 31);
            this.Download_Progressbar.Maximum = 100;
            this.Download_Progressbar.Name = "Download_Progressbar";
            this.Download_Progressbar.ShowPercentage = false;
            this.Download_Progressbar.Size = new System.Drawing.Size(531, 38);
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
            this.label_darma.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_darma.ForeColor = System.Drawing.Color.Black;
            this.label_darma.Location = new System.Drawing.Point(32, 443);
            this.label_darma.Name = "label_darma";
            this.label_darma.Size = new System.Drawing.Size(93, 14);
            this.label_darma.TabIndex = 12;
            this.label_darma.Text = "Arma3 Directory: ";
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
            // connection_label
            // 
            this.connection_label.AutoSize = true;
            this.connection_label.BackColor = System.Drawing.Color.Transparent;
            this.connection_label.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connection_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.connection_label.Location = new System.Drawing.Point(2, 421);
            this.connection_label.Name = "connection_label";
            this.connection_label.Size = new System.Drawing.Size(83, 20);
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
            this.destination_bouton.Size = new System.Drawing.Size(212, 60);
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
            this.Option_Boutton.Location = new System.Drawing.Point(12, 324);
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
            this.Group_Link.Controls.Add(this.WebSite_bouton);
            this.Group_Link.Controls.Add(this.Vocal_bouton);
            this.Group_Link.Location = new System.Drawing.Point(786, 324);
            this.Group_Link.MinimumSize = new System.Drawing.Size(136, 50);
            this.Group_Link.Name = "Group_Link";
            this.Group_Link.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.Group_Link.Size = new System.Drawing.Size(212, 129);
            this.Group_Link.TabIndex = 2;
            this.Group_Link.Text = "Links";
            this.Group_Link.DoubleClick += new System.EventHandler(this.Show_Launcher_Info);
            // 
            // WebSite_bouton
            // 
            this.WebSite_bouton.BackColor = System.Drawing.Color.Transparent;
            this.WebSite_bouton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.WebSite_bouton.Image = null;
            this.WebSite_bouton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WebSite_bouton.Location = new System.Drawing.Point(8, 78);
            this.WebSite_bouton.Name = "WebSite_bouton";
            this.WebSite_bouton.Size = new System.Drawing.Size(196, 41);
            this.WebSite_bouton.TabIndex = 2;
            this.WebSite_bouton.Text = "WebSite";
            this.WebSite_bouton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.WebSite_bouton.Click += new System.EventHandler(this.WebSite_bouton_Click);
            // 
            // Vocal_bouton
            // 
            this.Vocal_bouton.BackColor = System.Drawing.Color.Transparent;
            this.Vocal_bouton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Vocal_bouton.Image = null;
            this.Vocal_bouton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Vocal_bouton.Location = new System.Drawing.Point(8, 31);
            this.Vocal_bouton.Name = "Vocal_bouton";
            this.Vocal_bouton.Size = new System.Drawing.Size(196, 41);
            this.Vocal_bouton.TabIndex = 1;
            this.Vocal_bouton.Text = "VocalServeur";
            this.Vocal_bouton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Vocal_bouton.Click += new System.EventHandler(this.Vocal_bouton_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.Sound)).EndInit();
            this.Download_Group.ResumeLayout(false);
            this.Download_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_darma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagebox)).EndInit();
            this.Group_Link.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private MonoFlat.MonoFlat_NotificationBox notif_1;
        private MonoFlat.MonoFlat_Button Vocal_bouton;
        private iTalk.iTalk_GroupBox Group_Link;
        private MonoFlat.MonoFlat_Button WebSite_bouton;
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

    }
}

