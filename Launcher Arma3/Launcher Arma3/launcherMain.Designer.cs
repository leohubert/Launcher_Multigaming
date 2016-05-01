namespace Launcher_Arma3
{
    partial class launcherMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(launcherMain));
            this.pictureBig = new System.Windows.Forms.PictureBox();
            this.notif = new System.Windows.Forms.NotifyIcon(this.components);
            this.loginBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.requestLogin = new System.ComponentModel.BackgroundWorker();
            this.flatProgressBar1 = new FlatUI.FlatProgressBar();
            this.staffMessage = new FlatUI.FlatTextBox();
            this.loginButton = new FlatUI.FlatButton();
            this.loginLabel = new FlatUI.FlatLabel();
            this.loginPassword = new FlatUI.FlatTextBox();
            this.loginUsername = new FlatUI.FlatTextBox();
            this.errorBox = new FlatUI.FlatAlertBox();
            this.succesBox = new FlatUI.FlatAlertBox();
            this.infoBox = new FlatUI.FlatAlertBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.newsBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBig)).BeginInit();
            this.loginBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.newsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBig
            // 
            this.pictureBig.BackColor = System.Drawing.Color.Transparent;
            this.pictureBig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBig.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBig.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBig.ErrorImage")));
            this.pictureBig.Image = ((System.Drawing.Image)(resources.GetObject("pictureBig.Image")));
            this.pictureBig.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBig.InitialImage")));
            this.pictureBig.Location = new System.Drawing.Point(20, 60);
            this.pictureBig.Name = "pictureBig";
            this.pictureBig.Size = new System.Drawing.Size(883, 421);
            this.pictureBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBig.TabIndex = 3;
            this.pictureBig.TabStop = false;
            // 
            // notif
            // 
            this.notif.Text = "notifyIcon1";
            this.notif.Visible = true;
            // 
            // loginBox
            // 
            this.loginBox.BackColor = System.Drawing.Color.Transparent;
            this.loginBox.Controls.Add(this.pictureBox1);
            this.loginBox.Controls.Add(this.loginButton);
            this.loginBox.Controls.Add(this.loginLabel);
            this.loginBox.Controls.Add(this.loginPassword);
            this.loginBox.Controls.Add(this.loginUsername);
            this.loginBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBox.Location = new System.Drawing.Point(321, 151);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(258, 212);
            this.loginBox.TabIndex = 4;
            this.loginBox.TabStop = false;
            this.loginBox.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // flatProgressBar1
            // 
            this.flatProgressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.flatProgressBar1.DarkerProgress = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            this.flatProgressBar1.Location = new System.Drawing.Point(20, 439);
            this.flatProgressBar1.Maximum = 100;
            this.flatProgressBar1.Name = "flatProgressBar1";
            this.flatProgressBar1.Pattern = true;
            this.flatProgressBar1.PercentSign = false;
            this.flatProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatProgressBar1.ShowBalloon = true;
            this.flatProgressBar1.Size = new System.Drawing.Size(883, 42);
            this.flatProgressBar1.TabIndex = 8;
            this.flatProgressBar1.Text = "flatProgressBar1";
            this.flatProgressBar1.Value = 50;
            // 
            // staffMessage
            // 
            this.staffMessage.BackColor = System.Drawing.Color.Transparent;
            this.staffMessage.FocusOnHover = false;
            this.staffMessage.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.staffMessage.Location = new System.Drawing.Point(215, 25);
            this.staffMessage.MaxLength = 32767;
            this.staffMessage.Multiline = false;
            this.staffMessage.Name = "staffMessage";
            this.staffMessage.ReadOnly = true;
            this.staffMessage.Size = new System.Drawing.Size(639, 27);
            this.staffMessage.TabIndex = 5;
            this.staffMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.staffMessage.TextColor = System.Drawing.Color.Gray;
            this.staffMessage.UseSystemPasswordChar = false;
            this.staffMessage.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Transparent;
            this.loginButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.loginButton.Location = new System.Drawing.Point(45, 163);
            this.loginButton.Name = "loginButton";
            this.loginButton.Rounded = false;
            this.loginButton.Size = new System.Drawing.Size(162, 32);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Se connecter";
            this.loginButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.loginLabel.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.loginLabel.Location = new System.Drawing.Point(6, 27);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loginLabel.Size = new System.Drawing.Size(246, 36);
            this.loginLabel.TabIndex = 3;
            this.loginLabel.Text = "Afin de rejoindre notre serveur\r\n veuillez vous connecter\r\n";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginPassword
            // 
            this.loginPassword.BackColor = System.Drawing.Color.Transparent;
            this.loginPassword.FocusOnHover = false;
            this.loginPassword.Location = new System.Drawing.Point(6, 115);
            this.loginPassword.MaxLength = 32767;
            this.loginPassword.Multiline = false;
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.ReadOnly = false;
            this.loginPassword.Size = new System.Drawing.Size(246, 29);
            this.loginPassword.TabIndex = 2;
            this.loginPassword.Text = "0000";
            this.loginPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loginPassword.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loginPassword.UseSystemPasswordChar = true;
            // 
            // loginUsername
            // 
            this.loginUsername.BackColor = System.Drawing.Color.Transparent;
            this.loginUsername.FocusOnHover = false;
            this.loginUsername.Location = new System.Drawing.Point(6, 70);
            this.loginUsername.MaxLength = 32767;
            this.loginUsername.Multiline = false;
            this.loginUsername.Name = "loginUsername";
            this.loginUsername.ReadOnly = false;
            this.loginUsername.Size = new System.Drawing.Size(246, 29);
            this.loginUsername.TabIndex = 1;
            this.loginUsername.Text = "Username or Email";
            this.loginUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loginUsername.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.loginUsername.UseSystemPasswordChar = false;
            // 
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.errorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.errorBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorBox.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.errorBox.Location = new System.Drawing.Point(249, 63);
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(426, 42);
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
            this.succesBox.Location = new System.Drawing.Point(249, 63);
            this.succesBox.Name = "succesBox";
            this.succesBox.Size = new System.Drawing.Size(426, 42);
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
            this.infoBox.Location = new System.Drawing.Point(249, 63);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(426, 42);
            this.infoBox.TabIndex = 0;
            this.infoBox.Visible = false;
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
            this.pictureBox2.Location = new System.Drawing.Point(6, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(499, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // newsBox
            // 
            this.newsBox.BackColor = System.Drawing.Color.Transparent;
            this.newsBox.Controls.Add(this.pictureBox2);
            this.newsBox.Location = new System.Drawing.Point(20, 221);
            this.newsBox.Name = "newsBox";
            this.newsBox.Size = new System.Drawing.Size(505, 232);
            this.newsBox.TabIndex = 6;
            this.newsBox.TabStop = false;
            // 
            // launcherMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.None;
            this.ClientSize = new System.Drawing.Size(923, 501);
            this.Controls.Add(this.flatProgressBar1);
            this.Controls.Add(this.newsBox);
            this.Controls.Add(this.staffMessage);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.succesBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.pictureBig);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "launcherMain";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = "Green";
            this.Text = "Launcher Arma3";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.launcherMain_Load);
            this.VisibleChanged += new System.EventHandler(this.checkOptions);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBig)).EndInit();
            this.loginBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.newsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUI.FlatAlertBox infoBox;
        private FlatUI.FlatAlertBox succesBox;
        private FlatUI.FlatAlertBox errorBox;
        private System.Windows.Forms.PictureBox pictureBig;
        private System.Windows.Forms.NotifyIcon notif;
        private System.Windows.Forms.GroupBox loginBox;
        private FlatUI.FlatTextBox loginUsername;
        private FlatUI.FlatButton loginButton;
        private FlatUI.FlatLabel loginLabel;
        private FlatUI.FlatTextBox loginPassword;
        private System.ComponentModel.BackgroundWorker requestLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FlatUI.FlatTextBox staffMessage;
        private FlatUI.FlatProgressBar flatProgressBar1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox newsBox;
    }
}

