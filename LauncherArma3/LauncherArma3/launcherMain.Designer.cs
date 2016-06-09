namespace LauncherArma3
{
    partial class launcherMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(launcherMain));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.newsBox = new System.Windows.Forms.GroupBox();
            this.newsDate3 = new iTalk.iTalk_Label();
            this.newsDate2 = new iTalk.iTalk_Label();
            this.newsDate1 = new iTalk.iTalk_Label();
            this.newsLabel3 = new iTalk.iTalk_Label();
            this.newsLabel2 = new iTalk.iTalk_Label();
            this.newsLabel1 = new iTalk.iTalk_Label();
            this.newsLink3 = new iTalk.iTalk_Button_1();
            this.newsLink2 = new iTalk.iTalk_Button_1();
            this.newsLink1 = new iTalk.iTalk_Button_1();
            this.iTalk_Separator3 = new iTalk.iTalk_Separator();
            this.iTalk_Separator2 = new iTalk.iTalk_Separator();
            this.playerBox = new System.Windows.Forms.GroupBox();
            this.settingsButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.logoutButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.playerStatusLabel = new FlatUI.FlatLabel();
            this.playerEmailLabel = new FlatUI.FlatLabel();
            this.playerUsernameLabel = new FlatUI.FlatLabel();
            this.playerStatus = new FlatUI.FlatLabel();
            this.playerEmail = new FlatUI.FlatLabel();
            this.playerUsername = new FlatUI.FlatLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.playButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chooseButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.directoryChooser = new System.Windows.Forms.FolderBrowserDialog();
            this.pauseButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cancelButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.forceUpdate = new MaterialSkin.Controls.MaterialCheckBox();
            this.totalFiles = new FlatUI.FlatLabel();
            this.downloadedFiles = new FlatUI.FlatLabel();
            this.directoryLabel = new FlatUI.FlatLabel();
            this.errorBox = new FlatUI.FlatAlertBox();
            this.succesBox = new FlatUI.FlatAlertBox();
            this.infoBox = new FlatUI.FlatAlertBox();
            this.downloadProgressLabel = new FlatUI.FlatLabel();
            this.downloadProgress = new FlatUI.FlatProgressBar();
            this.downloadMessage = new FlatUI.FlatLabel();
            this.estimedTime = new FlatUI.FlatLabel();
            this.serverRequest = new System.ComponentModel.BackgroundWorker();
            this.sizeLabel = new FlatUI.FlatLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.newsBox.SuspendLayout();
            this.playerBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.tabPage2.Location = new System.Drawing.Point(44, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(835, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.tabPage1.Location = new System.Drawing.Point(44, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(835, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(505, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // newsBox
            // 
            this.newsBox.BackColor = System.Drawing.Color.Transparent;
            this.newsBox.Controls.Add(this.newsDate3);
            this.newsBox.Controls.Add(this.newsDate2);
            this.newsBox.Controls.Add(this.newsDate1);
            this.newsBox.Controls.Add(this.newsLabel3);
            this.newsBox.Controls.Add(this.newsLabel2);
            this.newsBox.Controls.Add(this.newsLabel1);
            this.newsBox.Controls.Add(this.newsLink3);
            this.newsBox.Controls.Add(this.newsLink2);
            this.newsBox.Controls.Add(this.newsLink1);
            this.newsBox.Controls.Add(this.iTalk_Separator3);
            this.newsBox.Controls.Add(this.iTalk_Separator2);
            this.newsBox.Controls.Add(this.pictureBox2);
            this.newsBox.Location = new System.Drawing.Point(308, 60);
            this.newsBox.Name = "newsBox";
            this.newsBox.Size = new System.Drawing.Size(506, 187);
            this.newsBox.TabIndex = 6;
            this.newsBox.TabStop = false;
            // 
            // newsDate3
            // 
            this.newsDate3.AutoSize = true;
            this.newsDate3.BackColor = System.Drawing.Color.Transparent;
            this.newsDate3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsDate3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.newsDate3.Location = new System.Drawing.Point(351, 147);
            this.newsDate3.Name = "newsDate3";
            this.newsDate3.Size = new System.Drawing.Size(80, 21);
            this.newsDate3.TabIndex = 20;
            this.newsDate3.Text = "**/**/****";
            // 
            // newsDate2
            // 
            this.newsDate2.AutoSize = true;
            this.newsDate2.BackColor = System.Drawing.Color.Transparent;
            this.newsDate2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsDate2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.newsDate2.Location = new System.Drawing.Point(351, 87);
            this.newsDate2.Name = "newsDate2";
            this.newsDate2.Size = new System.Drawing.Size(80, 21);
            this.newsDate2.TabIndex = 19;
            this.newsDate2.Text = "**/**/****";
            // 
            // newsDate1
            // 
            this.newsDate1.AutoSize = true;
            this.newsDate1.BackColor = System.Drawing.Color.Transparent;
            this.newsDate1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsDate1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.newsDate1.Location = new System.Drawing.Point(351, 32);
            this.newsDate1.Name = "newsDate1";
            this.newsDate1.Size = new System.Drawing.Size(80, 21);
            this.newsDate1.TabIndex = 18;
            this.newsDate1.Text = "**/**/****";
            // 
            // newsLabel3
            // 
            this.newsLabel3.AutoSize = true;
            this.newsLabel3.BackColor = System.Drawing.Color.Transparent;
            this.newsLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.newsLabel3.Location = new System.Drawing.Point(6, 147);
            this.newsLabel3.Name = "newsLabel3";
            this.newsLabel3.Size = new System.Drawing.Size(126, 21);
            this.newsLabel3.TabIndex = 17;
            this.newsLabel3.Text = "Comming soon";
            // 
            // newsLabel2
            // 
            this.newsLabel2.AutoSize = true;
            this.newsLabel2.BackColor = System.Drawing.Color.Transparent;
            this.newsLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.newsLabel2.Location = new System.Drawing.Point(6, 87);
            this.newsLabel2.Name = "newsLabel2";
            this.newsLabel2.Size = new System.Drawing.Size(126, 21);
            this.newsLabel2.TabIndex = 16;
            this.newsLabel2.Text = "Comming soon";
            // 
            // newsLabel1
            // 
            this.newsLabel1.AutoSize = true;
            this.newsLabel1.BackColor = System.Drawing.Color.Transparent;
            this.newsLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.newsLabel1.Location = new System.Drawing.Point(6, 32);
            this.newsLabel1.Name = "newsLabel1";
            this.newsLabel1.Size = new System.Drawing.Size(126, 21);
            this.newsLabel1.TabIndex = 15;
            this.newsLabel1.Text = "Comming soon";
            // 
            // newsLink3
            // 
            this.newsLink3.BackColor = System.Drawing.Color.Transparent;
            this.newsLink3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.newsLink3.Image = null;
            this.newsLink3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newsLink3.Location = new System.Drawing.Point(453, 150);
            this.newsLink3.Name = "newsLink3";
            this.newsLink3.Size = new System.Drawing.Size(35, 18);
            this.newsLink3.TabIndex = 14;
            this.newsLink3.Text = "...";
            this.newsLink3.TextAlignment = System.Drawing.StringAlignment.Center;
            this.newsLink3.Click += new System.EventHandler(this.newsLink3_Click);
            // 
            // newsLink2
            // 
            this.newsLink2.BackColor = System.Drawing.Color.Transparent;
            this.newsLink2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.newsLink2.Image = null;
            this.newsLink2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newsLink2.Location = new System.Drawing.Point(453, 90);
            this.newsLink2.Name = "newsLink2";
            this.newsLink2.Size = new System.Drawing.Size(35, 18);
            this.newsLink2.TabIndex = 13;
            this.newsLink2.Text = "...";
            this.newsLink2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.newsLink2.Click += new System.EventHandler(this.newsLink2_Click);
            // 
            // newsLink1
            // 
            this.newsLink1.BackColor = System.Drawing.Color.Transparent;
            this.newsLink1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.newsLink1.Image = null;
            this.newsLink1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newsLink1.Location = new System.Drawing.Point(453, 35);
            this.newsLink1.Name = "newsLink1";
            this.newsLink1.Size = new System.Drawing.Size(35, 18);
            this.newsLink1.TabIndex = 12;
            this.newsLink1.Text = "...";
            this.newsLink1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.newsLink1.Click += new System.EventHandler(this.newsLink1_Click);
            // 
            // iTalk_Separator3
            // 
            this.iTalk_Separator3.BackColor = System.Drawing.Color.White;
            this.iTalk_Separator3.Location = new System.Drawing.Point(6, 64);
            this.iTalk_Separator3.Name = "iTalk_Separator3";
            this.iTalk_Separator3.Size = new System.Drawing.Size(493, 10);
            this.iTalk_Separator3.TabIndex = 11;
            this.iTalk_Separator3.Text = "iTalk_Separator3";
            // 
            // iTalk_Separator2
            // 
            this.iTalk_Separator2.BackColor = System.Drawing.Color.White;
            this.iTalk_Separator2.Location = new System.Drawing.Point(6, 125);
            this.iTalk_Separator2.Name = "iTalk_Separator2";
            this.iTalk_Separator2.Size = new System.Drawing.Size(493, 10);
            this.iTalk_Separator2.TabIndex = 10;
            this.iTalk_Separator2.Text = "iTalk_Separator2";
            // 
            // playerBox
            // 
            this.playerBox.Controls.Add(this.settingsButton);
            this.playerBox.Controls.Add(this.logoutButton);
            this.playerBox.Controls.Add(this.playerStatusLabel);
            this.playerBox.Controls.Add(this.playerEmailLabel);
            this.playerBox.Controls.Add(this.playerUsernameLabel);
            this.playerBox.Controls.Add(this.playerStatus);
            this.playerBox.Controls.Add(this.playerEmail);
            this.playerBox.Controls.Add(this.playerUsername);
            this.playerBox.Controls.Add(this.pictureBox4);
            this.playerBox.Location = new System.Drawing.Point(20, 60);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(282, 187);
            this.playerBox.TabIndex = 9;
            this.playerBox.TabStop = false;
            // 
            // settingsButton
            // 
            this.settingsButton.Depth = 0;
            this.settingsButton.Location = new System.Drawing.Point(6, 145);
            this.settingsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Primary = true;
            this.settingsButton.Size = new System.Drawing.Size(126, 36);
            this.settingsButton.TabIndex = 18;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Depth = 0;
            this.logoutButton.Location = new System.Drawing.Point(140, 145);
            this.logoutButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Primary = true;
            this.logoutButton.Size = new System.Drawing.Size(134, 36);
            this.logoutButton.TabIndex = 17;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // playerStatusLabel
            // 
            this.playerStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerStatusLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold);
            this.playerStatusLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.playerStatusLabel.Location = new System.Drawing.Point(7, 83);
            this.playerStatusLabel.Name = "playerStatusLabel";
            this.playerStatusLabel.Size = new System.Drawing.Size(125, 14);
            this.playerStatusLabel.TabIndex = 15;
            this.playerStatusLabel.Text = "Status :";
            // 
            // playerEmailLabel
            // 
            this.playerEmailLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerEmailLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold);
            this.playerEmailLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.playerEmailLabel.Location = new System.Drawing.Point(6, 61);
            this.playerEmailLabel.Name = "playerEmailLabel";
            this.playerEmailLabel.Size = new System.Drawing.Size(126, 14);
            this.playerEmailLabel.TabIndex = 14;
            this.playerEmailLabel.Text = "Email :";
            // 
            // playerUsernameLabel
            // 
            this.playerUsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerUsernameLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold);
            this.playerUsernameLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.playerUsernameLabel.Location = new System.Drawing.Point(6, 36);
            this.playerUsernameLabel.Name = "playerUsernameLabel";
            this.playerUsernameLabel.Size = new System.Drawing.Size(126, 14);
            this.playerUsernameLabel.TabIndex = 12;
            this.playerUsernameLabel.Text = "Username :";
            // 
            // playerStatus
            // 
            this.playerStatus.BackColor = System.Drawing.Color.Transparent;
            this.playerStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerStatus.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerStatus.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.playerStatus.Location = new System.Drawing.Point(137, 80);
            this.playerStatus.Name = "playerStatus";
            this.playerStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.playerStatus.Size = new System.Drawing.Size(138, 22);
            this.playerStatus.TabIndex = 16;
            this.playerStatus.Text = "NULL";
            this.playerStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // playerEmail
            // 
            this.playerEmail.BackColor = System.Drawing.Color.Transparent;
            this.playerEmail.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerEmail.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerEmail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.playerEmail.Location = new System.Drawing.Point(138, 56);
            this.playerEmail.Name = "playerEmail";
            this.playerEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.playerEmail.Size = new System.Drawing.Size(136, 22);
            this.playerEmail.TabIndex = 13;
            this.playerEmail.Text = "NULL";
            this.playerEmail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // playerUsername
            // 
            this.playerUsername.BackColor = System.Drawing.Color.Transparent;
            this.playerUsername.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerUsername.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerUsername.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.playerUsername.Location = new System.Drawing.Point(137, 33);
            this.playerUsername.Name = "playerUsername";
            this.playerUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.playerUsername.Size = new System.Drawing.Size(138, 22);
            this.playerUsername.TabIndex = 10;
            this.playerUsername.Text = "NULL";
            this.playerUsername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(285, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // playButton
            // 
            this.playButton.Depth = 0;
            this.playButton.Location = new System.Drawing.Point(819, 430);
            this.playButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.playButton.Name = "playButton";
            this.playButton.Primary = true;
            this.playButton.Size = new System.Drawing.Size(158, 46);
            this.playButton.TabIndex = 17;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // chooseButton
            // 
            this.chooseButton.Depth = 0;
            this.chooseButton.Location = new System.Drawing.Point(23, 431);
            this.chooseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Primary = true;
            this.chooseButton.Size = new System.Drawing.Size(214, 46);
            this.chooseButton.TabIndex = 18;
            this.chooseButton.Text = "Choose arma directory";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Depth = 0;
            this.pauseButton.Location = new System.Drawing.Point(819, 377);
            this.pauseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Primary = true;
            this.pauseButton.Size = new System.Drawing.Size(158, 46);
            this.pauseButton.TabIndex = 20;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Visible = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Depth = 0;
            this.cancelButton.Location = new System.Drawing.Point(819, 324);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Primary = true;
            this.cancelButton.Size = new System.Drawing.Size(158, 46);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // forceUpdate
            // 
            this.forceUpdate.AutoSize = true;
            this.forceUpdate.Depth = 0;
            this.forceUpdate.Font = new System.Drawing.Font("Roboto", 10F);
            this.forceUpdate.Location = new System.Drawing.Point(696, 446);
            this.forceUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.forceUpdate.MouseLocation = new System.Drawing.Point(-1, -1);
            this.forceUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.forceUpdate.Name = "forceUpdate";
            this.forceUpdate.Ripple = true;
            this.forceUpdate.Size = new System.Drawing.Size(111, 30);
            this.forceUpdate.TabIndex = 25;
            this.forceUpdate.Text = "Force update";
            this.forceUpdate.UseVisualStyleBackColor = true;
            this.forceUpdate.Visible = false;
            this.forceUpdate.CheckedChanged += new System.EventHandler(this.forceUpdate_CheckedChanged);
            // 
            // totalFiles
            // 
            this.totalFiles.AutoSize = true;
            this.totalFiles.BackColor = System.Drawing.Color.Transparent;
            this.totalFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.totalFiles.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalFiles.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.totalFiles.Location = new System.Drawing.Point(25, 324);
            this.totalFiles.Name = "totalFiles";
            this.totalFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.totalFiles.Size = new System.Drawing.Size(0, 18);
            this.totalFiles.TabIndex = 27;
            this.totalFiles.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // downloadedFiles
            // 
            this.downloadedFiles.AutoSize = true;
            this.downloadedFiles.BackColor = System.Drawing.Color.Transparent;
            this.downloadedFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.downloadedFiles.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadedFiles.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.downloadedFiles.Location = new System.Drawing.Point(25, 349);
            this.downloadedFiles.Name = "downloadedFiles";
            this.downloadedFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.downloadedFiles.Size = new System.Drawing.Size(0, 18);
            this.downloadedFiles.TabIndex = 26;
            this.downloadedFiles.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.directoryLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.directoryLabel.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.directoryLabel.Location = new System.Drawing.Point(23, 406);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.directoryLabel.Size = new System.Drawing.Size(180, 18);
            this.directoryLabel.TabIndex = 19;
            this.directoryLabel.Text = "Select a arma directory";
            this.directoryLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.errorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.errorBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorBox.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.errorBox.Location = new System.Drawing.Point(250, 12);
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(500, 42);
            this.errorBox.TabIndex = 2;
            this.errorBox.Visible = false;
            // 
            // succesBox
            // 
            this.succesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.succesBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.succesBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.succesBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.succesBox.kind = FlatUI.FlatAlertBox._Kind.Success;
            this.succesBox.Location = new System.Drawing.Point(250, 12);
            this.succesBox.Name = "succesBox";
            this.succesBox.Size = new System.Drawing.Size(500, 42);
            this.succesBox.TabIndex = 1;
            this.succesBox.Visible = false;
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.infoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.infoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoBox.kind = FlatUI.FlatAlertBox._Kind.Info;
            this.infoBox.Location = new System.Drawing.Point(250, 12);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(500, 42);
            this.infoBox.TabIndex = 0;
            this.infoBox.Visible = false;
            // 
            // downloadProgressLabel
            // 
            this.downloadProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.downloadProgressLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.downloadProgressLabel.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadProgressLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.downloadProgressLabel.Location = new System.Drawing.Point(0, 458);
            this.downloadProgressLabel.Name = "downloadProgressLabel";
            this.downloadProgressLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.downloadProgressLabel.Size = new System.Drawing.Size(1001, 18);
            this.downloadProgressLabel.TabIndex = 19;
            this.downloadProgressLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // downloadProgress
            // 
            this.downloadProgress.BackColor = System.Drawing.Color.White;
            this.downloadProgress.DarkerProgress = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            this.downloadProgress.Location = new System.Drawing.Point(0, 458);
            this.downloadProgress.Maximum = 100;
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Pattern = true;
            this.downloadProgress.PercentSign = false;
            this.downloadProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.downloadProgress.ShowBalloon = false;
            this.downloadProgress.Size = new System.Drawing.Size(1001, 42);
            this.downloadProgress.TabIndex = 8;
            this.downloadProgress.Text = "downloadProgress";
            this.downloadProgress.Value = 0;
            this.downloadProgress.Visible = false;
            // 
            // downloadMessage
            // 
            this.downloadMessage.BackColor = System.Drawing.Color.Transparent;
            this.downloadMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.downloadMessage.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadMessage.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.downloadMessage.Location = new System.Drawing.Point(0, 419);
            this.downloadMessage.Name = "downloadMessage";
            this.downloadMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.downloadMessage.Size = new System.Drawing.Size(1001, 18);
            this.downloadMessage.TabIndex = 24;
            this.downloadMessage.Text = "Wait for download";
            this.downloadMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // estimedTime
            // 
            this.estimedTime.BackColor = System.Drawing.Color.Transparent;
            this.estimedTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.estimedTime.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estimedTime.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.estimedTime.Location = new System.Drawing.Point(0, 437);
            this.estimedTime.Name = "estimedTime";
            this.estimedTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.estimedTime.Size = new System.Drawing.Size(1001, 18);
            this.estimedTime.TabIndex = 28;
            this.estimedTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // serverRequest
            // 
            this.serverRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.serverRequest_DoWork);
            // 
            // sizeLabel
            // 
            this.sizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.sizeLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.sizeLabel.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.sizeLabel.Location = new System.Drawing.Point(0, 398);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sizeLabel.Size = new System.Drawing.Size(1001, 18);
            this.sizeLabel.TabIndex = 29;
            this.sizeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // launcherMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.totalFiles);
            this.Controls.Add(this.downloadedFiles);
            this.Controls.Add(this.forceUpdate);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.newsBox);
            this.Controls.Add(this.playerBox);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.succesBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.downloadProgressLabel);
            this.Controls.Add(this.downloadProgress);
            this.Controls.Add(this.downloadMessage);
            this.Controls.Add(this.estimedTime);
            this.Controls.Add(this.sizeLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "launcherMain";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Launcher Arma3";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.close);
            this.Load += new System.EventHandler(this.launcherMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.newsBox.ResumeLayout(false);
            this.newsBox.PerformLayout();
            this.playerBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private FlatUI.FlatAlertBox infoBox;
        private FlatUI.FlatAlertBox succesBox;
        private FlatUI.FlatAlertBox errorBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox newsBox;
        private iTalk.iTalk_Button_1 newsLink3;
        private iTalk.iTalk_Button_1 newsLink2;
        private iTalk.iTalk_Button_1 newsLink1;
        private iTalk.iTalk_Separator iTalk_Separator3;
        private iTalk.iTalk_Separator iTalk_Separator2;
        private iTalk.iTalk_Label newsLabel3;
        private iTalk.iTalk_Label newsLabel2;
        private iTalk.iTalk_Label newsLabel1;
        private iTalk.iTalk_Label newsDate3;
        private iTalk.iTalk_Label newsDate2;
        private iTalk.iTalk_Label newsDate1;
        private System.Windows.Forms.GroupBox playerBox;
        private System.Windows.Forms.PictureBox pictureBox4;
        private FlatUI.FlatLabel playerUsernameLabel;
        private FlatUI.FlatLabel playerUsername;
        private FlatUI.FlatLabel playerEmail;
        private FlatUI.FlatLabel playerEmailLabel;
        private FlatUI.FlatLabel playerStatus;
        private FlatUI.FlatLabel playerStatusLabel;
        private MaterialSkin.Controls.MaterialRaisedButton playButton;
        private MaterialSkin.Controls.MaterialRaisedButton logoutButton;
        private MaterialSkin.Controls.MaterialRaisedButton settingsButton;
        private MaterialSkin.Controls.MaterialRaisedButton chooseButton;
        private System.Windows.Forms.FolderBrowserDialog directoryChooser;
        private FlatUI.FlatLabel directoryLabel;
        private MaterialSkin.Controls.MaterialRaisedButton pauseButton;
        private FlatUI.FlatLabel downloadProgressLabel;
        private MaterialSkin.Controls.MaterialRaisedButton cancelButton;
        public FlatUI.FlatProgressBar downloadProgress;
        private FlatUI.FlatLabel downloadMessage;
        private MaterialSkin.Controls.MaterialCheckBox forceUpdate;
        private FlatUI.FlatLabel downloadedFiles;
        private FlatUI.FlatLabel totalFiles;
        private FlatUI.FlatLabel estimedTime;
        private System.ComponentModel.BackgroundWorker serverRequest;
        private FlatUI.FlatLabel sizeLabel;
    }
}