namespace LauncherArma3
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.loginButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.loginUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.loginPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.registerLink = new MaterialSkin.Controls.MaterialRaisedButton();
            this.registerMessage = new MaterialSkin.Controls.MaterialLabel();
            this.separator2 = new MaterialSkin.Controls.MaterialTabSelector();
            this.separator1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.separator3 = new MaterialSkin.Controls.MaterialTabSelector();
            this.newsTitle = new MaterialSkin.Controls.MaterialLabel();
            this.newsContent = new MaterialSkin.Controls.MaterialLabel();
            this.loginLogo = new System.Windows.Forms.PictureBox();
            this.loginRemember = new MaterialSkin.Controls.MaterialCheckBox();
            this.errorImage = new System.Windows.Forms.PictureBox();
            this.errorBox = new FlatUI.FlatAlertBox();
            this.maintenanceRefresh = new System.ComponentModel.BackgroundWorker();
            this.newPassword = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.loginLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImage)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Depth = 0;
            this.loginButton.Location = new System.Drawing.Point(362, 217);
            this.loginButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginButton.Name = "loginButton";
            this.loginButton.Primary = true;
            this.loginButton.Size = new System.Drawing.Size(249, 46);
            this.loginButton.TabIndex = 11;
            this.loginButton.Text = "Sign in";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginUsername
            // 
            this.loginUsername.BackColor = System.Drawing.Color.White;
            this.loginUsername.Depth = 0;
            this.loginUsername.ForeColor = System.Drawing.Color.White;
            this.loginUsername.Hint = "Username";
            this.loginUsername.Location = new System.Drawing.Point(362, 111);
            this.loginUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginUsername.Name = "loginUsername";
            this.loginUsername.PasswordChar = '\0';
            this.loginUsername.SelectedText = "";
            this.loginUsername.SelectionLength = 0;
            this.loginUsername.SelectionStart = 0;
            this.loginUsername.Size = new System.Drawing.Size(249, 23);
            this.loginUsername.TabIndex = 12;
            this.loginUsername.UseSystemPasswordChar = false;
            // 
            // loginPassword
            // 
            this.loginPassword.BackColor = System.Drawing.Color.White;
            this.loginPassword.Depth = 0;
            this.loginPassword.ForeColor = System.Drawing.Color.White;
            this.loginPassword.Hint = "Password";
            this.loginPassword.Location = new System.Drawing.Point(362, 151);
            this.loginPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.PasswordChar = '*';
            this.loginPassword.SelectedText = "";
            this.loginPassword.SelectionLength = 0;
            this.loginPassword.SelectionStart = 0;
            this.loginPassword.Size = new System.Drawing.Size(249, 23);
            this.loginPassword.TabIndex = 13;
            this.loginPassword.UseSystemPasswordChar = true;
            // 
            // registerLink
            // 
            this.registerLink.Depth = 0;
            this.registerLink.Location = new System.Drawing.Point(366, 375);
            this.registerLink.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerLink.Name = "registerLink";
            this.registerLink.Primary = true;
            this.registerLink.Size = new System.Drawing.Size(245, 46);
            this.registerLink.TabIndex = 16;
            this.registerLink.Text = "Create an account";
            this.registerLink.UseVisualStyleBackColor = true;
            this.registerLink.Click += new System.EventHandler(this.registerLink_Click);
            // 
            // registerMessage
            // 
            this.registerMessage.BackColor = System.Drawing.Color.Transparent;
            this.registerMessage.Depth = 0;
            this.registerMessage.Font = new System.Drawing.Font("Roboto", 11F);
            this.registerMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.registerMessage.Location = new System.Drawing.Point(362, 327);
            this.registerMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerMessage.Name = "registerMessage";
            this.registerMessage.Size = new System.Drawing.Size(249, 45);
            this.registerMessage.TabIndex = 17;
            this.registerMessage.Text = "New in our community ?";
            this.registerMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // separator2
            // 
            this.separator2.BaseTabControl = null;
            this.separator2.Depth = 0;
            this.separator2.Location = new System.Drawing.Point(323, 5);
            this.separator2.MouseState = MaterialSkin.MouseState.HOVER;
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(3, 443);
            this.separator2.TabIndex = 18;
            this.separator2.Text = "separator";
            // 
            // separator1
            // 
            this.separator1.BaseTabControl = null;
            this.separator1.Depth = 0;
            this.separator1.Location = new System.Drawing.Point(323, 297);
            this.separator1.MouseState = MaterialSkin.MouseState.HOVER;
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(325, 2);
            this.separator1.TabIndex = 19;
            this.separator1.Text = "materialTabSelector1";
            // 
            // separator3
            // 
            this.separator3.BaseTabControl = null;
            this.separator3.Depth = 0;
            this.separator3.Location = new System.Drawing.Point(-1, 82);
            this.separator3.MouseState = MaterialSkin.MouseState.HOVER;
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(325, 2);
            this.separator3.TabIndex = 20;
            this.separator3.Text = "materialTabSelector2";
            // 
            // newsTitle
            // 
            this.newsTitle.Depth = 0;
            this.newsTitle.Font = new System.Drawing.Font("Roboto", 11F);
            this.newsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.newsTitle.Location = new System.Drawing.Point(23, 30);
            this.newsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.newsTitle.Name = "newsTitle";
            this.newsTitle.Size = new System.Drawing.Size(272, 38);
            this.newsTitle.TabIndex = 21;
            this.newsTitle.Text = "News loading";
            this.newsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // newsContent
            // 
            this.newsContent.Depth = 0;
            this.newsContent.Font = new System.Drawing.Font("Roboto", 11F);
            this.newsContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.newsContent.Location = new System.Drawing.Point(23, 96);
            this.newsContent.MouseState = MaterialSkin.MouseState.HOVER;
            this.newsContent.Name = "newsContent";
            this.newsContent.Size = new System.Drawing.Size(272, 325);
            this.newsContent.TabIndex = 22;
            this.newsContent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginLogo
            // 
            this.loginLogo.Image = ((System.Drawing.Image)(resources.GetObject("loginLogo.Image")));
            this.loginLogo.Location = new System.Drawing.Point(362, 26);
            this.loginLogo.Name = "loginLogo";
            this.loginLogo.Size = new System.Drawing.Size(249, 64);
            this.loginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginLogo.TabIndex = 23;
            this.loginLogo.TabStop = false;
            // 
            // loginRemember
            // 
            this.loginRemember.AutoSize = true;
            this.loginRemember.Depth = 0;
            this.loginRemember.Font = new System.Drawing.Font("Roboto", 10F);
            this.loginRemember.Location = new System.Drawing.Point(362, 177);
            this.loginRemember.Margin = new System.Windows.Forms.Padding(0);
            this.loginRemember.MouseLocation = new System.Drawing.Point(-1, -1);
            this.loginRemember.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginRemember.Name = "loginRemember";
            this.loginRemember.Ripple = true;
            this.loginRemember.Size = new System.Drawing.Size(120, 30);
            this.loginRemember.TabIndex = 24;
            this.loginRemember.Text = "Remember me";
            this.loginRemember.UseVisualStyleBackColor = true;
            // 
            // errorImage
            // 
            this.errorImage.Image = ((System.Drawing.Image)(resources.GetObject("errorImage.Image")));
            this.errorImage.Location = new System.Drawing.Point(23, 111);
            this.errorImage.Name = "errorImage";
            this.errorImage.Size = new System.Drawing.Size(272, 310);
            this.errorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.errorImage.TabIndex = 26;
            this.errorImage.TabStop = false;
            // 
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.errorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.errorBox.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.errorBox.Location = new System.Drawing.Point(323, 46);
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(325, 42);
            this.errorBox.TabIndex = 25;
            this.errorBox.Visible = false;
            this.errorBox.Click += new System.EventHandler(this.normalView);
            // 
            // maintenanceRefresh
            // 
            this.maintenanceRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.maintenanceRefresh_DoWork);
            this.maintenanceRefresh.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.callRefresh);
            // 
            // newPassword
            // 
            this.newPassword.BackColor = System.Drawing.Color.Transparent;
            this.newPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newPassword.Depth = 0;
            this.newPassword.Font = new System.Drawing.Font("Roboto", 11F);
            this.newPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.newPassword.Location = new System.Drawing.Point(332, 266);
            this.newPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(308, 18);
            this.newPassword.TabIndex = 27;
            this.newPassword.Text = "Need a new password ?";
            this.newPassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newPassword.Click += new System.EventHandler(this.newPassword_Click);
            // 
            // loginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 444);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.loginRemember);
            this.Controls.Add(this.loginLogo);
            this.Controls.Add(this.newsContent);
            this.Controls.Add(this.newsTitle);
            this.Controls.Add(this.separator3);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.registerMessage);
            this.Controls.Add(this.registerLink);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.loginPassword);
            this.Controls.Add(this.loginUsername);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.errorImage);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "loginForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "Launcher Login";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.VisibleChanged += new System.EventHandler(this.checkOptions);
            ((System.ComponentModel.ISupportInitialize)(this.loginLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton loginButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField loginUsername;
        private MaterialSkin.Controls.MaterialSingleLineTextField loginPassword;
        private MaterialSkin.Controls.MaterialRaisedButton registerLink;
        private MaterialSkin.Controls.MaterialLabel registerMessage;
        private MaterialSkin.Controls.MaterialTabSelector separator2;
        private MaterialSkin.Controls.MaterialTabSelector separator1;
        private MaterialSkin.Controls.MaterialTabSelector separator3;
        private MaterialSkin.Controls.MaterialLabel newsTitle;
        private MaterialSkin.Controls.MaterialLabel newsContent;
        private System.Windows.Forms.PictureBox loginLogo;
        private MaterialSkin.Controls.MaterialCheckBox loginRemember;
        private FlatUI.FlatAlertBox errorBox;
        private System.Windows.Forms.PictureBox errorImage;
        private System.ComponentModel.BackgroundWorker maintenanceRefresh;
        private MaterialSkin.Controls.MaterialLabel newPassword;
    }
}