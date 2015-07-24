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
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
            this.Download_label1 = new iTalk.iTalk_Label();
            this.Total_Progress = new iTalk.iTalk_ProgressBar();
            this.Download_Progress = new iTalk.iTalk_ProgressBar();
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
            this.WebSite_bouton = new MonoFlat.MonoFlat_Button();
            this.Vocal_bouton = new MonoFlat.MonoFlat_Button();
            this.notif_1 = new MonoFlat.MonoFlat_NotificationBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.iTalk_ThemeContainer1.SuspendLayout();
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
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.Download_label1);
            this.iTalk_ThemeContainer1.Controls.Add(this.Total_Progress);
            this.iTalk_ThemeContainer1.Controls.Add(this.Download_Progress);
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
            this.iTalk_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_ThemeContainer1.Name = "iTalk_ThemeContainer1";
            this.iTalk_ThemeContainer1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.iTalk_ThemeContainer1.Sizable = false;
            this.iTalk_ThemeContainer1.Size = new System.Drawing.Size(1004, 484);
            this.iTalk_ThemeContainer1.SmartBounds = false;
            this.iTalk_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.iTalk_ThemeContainer1.TabIndex = 0;
            this.iTalk_ThemeContainer1.Text = "Launcher Arma 3";
            // 
            // Download_label1
            // 
            this.Download_label1.AutoSize = true;
            this.Download_label1.BackColor = System.Drawing.Color.Transparent;
            this.Download_label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Download_label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.Download_label1.Location = new System.Drawing.Point(227, 421);
            this.Download_label1.Name = "Download_label1";
            this.Download_label1.Size = new System.Drawing.Size(64, 13);
            this.Download_label1.TabIndex = 18;
            this.Download_label1.Text = "Download:";
            this.Download_label1.Visible = false;
            // 
            // Total_Progress
            // 
            this.Total_Progress.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.Total_Progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Total_Progress.Location = new System.Drawing.Point(620, 258);
            this.Total_Progress.Maximum = ((long)(100));
            this.Total_Progress.MinimumSize = new System.Drawing.Size(100, 100);
            this.Total_Progress.Name = "Total_Progress";
            this.Total_Progress.ProgressColor1 = System.Drawing.Color.Lime;
            this.Total_Progress.ProgressColor2 = System.Drawing.Color.Lime;
            this.Total_Progress.ProgressShape = iTalk.iTalk_ProgressBar._ProgressShape.Round;
            this.Total_Progress.Size = new System.Drawing.Size(160, 160);
            this.Total_Progress.TabIndex = 17;
            this.Total_Progress.Text = "Total_Progress";
            this.Total_Progress.Value = ((long)(0));
            this.Total_Progress.Visible = false;
            // 
            // Download_Progress
            // 
            this.Download_Progress.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.Download_Progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Download_Progress.Location = new System.Drawing.Point(230, 258);
            this.Download_Progress.Maximum = ((long)(100));
            this.Download_Progress.MinimumSize = new System.Drawing.Size(100, 100);
            this.Download_Progress.Name = "Download_Progress";
            this.Download_Progress.ProgressColor1 = System.Drawing.Color.Lime;
            this.Download_Progress.ProgressColor2 = System.Drawing.Color.Lime;
            this.Download_Progress.ProgressShape = iTalk.iTalk_ProgressBar._ProgressShape.Round;
            this.Download_Progress.Size = new System.Drawing.Size(160, 160);
            this.Download_Progress.TabIndex = 16;
            this.Download_Progress.Text = "iTalk_ProgressBar2";
            this.Download_Progress.Value = ((long)(0));
            this.Download_Progress.Visible = false;
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
            this.Group_Link.Text = "Liens";
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "banner.jpg");
            this.imageList1.Images.SetKeyName(1, "banner.png");
            this.imageList1.Images.SetKeyName(2, "logo.jpg");
            // 
            // Launch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1004, 484);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Launch";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher Arma 3";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Launch_Load);
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.iTalk_ThemeContainer1.PerformLayout();
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
        private iTalk.iTalk_ProgressBar Download_Progress;
        private iTalk.iTalk_ProgressBar Total_Progress;
        private iTalk.iTalk_Label Download_label1;
        private System.ComponentModel.BackgroundWorker Erreur_Msg;
        private System.Windows.Forms.Timer Fader;
        private System.Windows.Forms.ImageList imageList1;


    }
}

