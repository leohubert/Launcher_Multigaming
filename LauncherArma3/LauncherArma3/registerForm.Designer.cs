namespace LauncherArma3
{
    partial class registerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registerForm));
            this.registerLogo = new System.Windows.Forms.PictureBox();
            this.separator = new MaterialSkin.Controls.MaterialTabSelector();
            this.loginLink = new MaterialSkin.Controls.MaterialRaisedButton();
            this.registerButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.loginMessage = new MaterialSkin.Controls.MaterialLabel();
            this.registerPassConfirm = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.registerPass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.registerUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.registerEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.errorBox = new FlatUI.FlatAlertBox();
            this.successBox = new FlatUI.FlatAlertBox();
            ((System.ComponentModel.ISupportInitialize)(this.registerLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // registerLogo
            // 
            this.registerLogo.Image = ((System.Drawing.Image)(resources.GetObject("registerLogo.Image")));
            this.registerLogo.Location = new System.Drawing.Point(32, 33);
            this.registerLogo.Name = "registerLogo";
            this.registerLogo.Size = new System.Drawing.Size(249, 64);
            this.registerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.registerLogo.TabIndex = 31;
            this.registerLogo.TabStop = false;
            this.registerLogo.Click += new System.EventHandler(this.registerLogo_Click);
            // 
            // separator
            // 
            this.separator.BaseTabControl = null;
            this.separator.Depth = 0;
            this.separator.Location = new System.Drawing.Point(-1, 315);
            this.separator.MouseState = MaterialSkin.MouseState.HOVER;
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(325, 1);
            this.separator.TabIndex = 30;
            this.separator.Text = "materialTabSelector1";
            // 
            // loginLink
            // 
            this.loginLink.Depth = 0;
            this.loginLink.Location = new System.Drawing.Point(36, 385);
            this.loginLink.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginLink.Name = "loginLink";
            this.loginLink.Primary = true;
            this.loginLink.Size = new System.Drawing.Size(245, 46);
            this.loginLink.TabIndex = 28;
            this.loginLink.Text = "Sign In";
            this.loginLink.UseVisualStyleBackColor = true;
            this.loginLink.Click += new System.EventHandler(this.registerLink_Click);
            // 
            // registerButton
            // 
            this.registerButton.Depth = 0;
            this.registerButton.Location = new System.Drawing.Point(32, 243);
            this.registerButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerButton.Name = "registerButton";
            this.registerButton.Primary = true;
            this.registerButton.Size = new System.Drawing.Size(249, 46);
            this.registerButton.TabIndex = 25;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // loginMessage
            // 
            this.loginMessage.BackColor = System.Drawing.Color.Transparent;
            this.loginMessage.Depth = 0;
            this.loginMessage.Font = new System.Drawing.Font("Roboto", 11F);
            this.loginMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.loginMessage.Location = new System.Drawing.Point(32, 332);
            this.loginMessage.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginMessage.Name = "loginMessage";
            this.loginMessage.Size = new System.Drawing.Size(249, 45);
            this.loginMessage.TabIndex = 29;
            this.loginMessage.Text = "Already registered ?";
            this.loginMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // registerPassConfirm
            // 
            this.registerPassConfirm.BackColor = System.Drawing.Color.White;
            this.registerPassConfirm.Depth = 0;
            this.registerPassConfirm.ForeColor = System.Drawing.Color.White;
            this.registerPassConfirm.Hint = "Confirm password";
            this.registerPassConfirm.Location = new System.Drawing.Point(32, 202);
            this.registerPassConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerPassConfirm.Name = "registerPassConfirm";
            this.registerPassConfirm.PasswordChar = '*';
            this.registerPassConfirm.SelectedText = "";
            this.registerPassConfirm.SelectionLength = 0;
            this.registerPassConfirm.SelectionStart = 0;
            this.registerPassConfirm.Size = new System.Drawing.Size(249, 23);
            this.registerPassConfirm.TabIndex = 32;
            this.registerPassConfirm.UseSystemPasswordChar = true;
            // 
            // registerPass
            // 
            this.registerPass.BackColor = System.Drawing.Color.White;
            this.registerPass.Depth = 0;
            this.registerPass.ForeColor = System.Drawing.Color.White;
            this.registerPass.Hint = "Password";
            this.registerPass.Location = new System.Drawing.Point(32, 173);
            this.registerPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerPass.Name = "registerPass";
            this.registerPass.PasswordChar = '*';
            this.registerPass.SelectedText = "";
            this.registerPass.SelectionLength = 0;
            this.registerPass.SelectionStart = 0;
            this.registerPass.Size = new System.Drawing.Size(249, 23);
            this.registerPass.TabIndex = 33;
            this.registerPass.UseSystemPasswordChar = true;
            // 
            // registerUsername
            // 
            this.registerUsername.BackColor = System.Drawing.Color.White;
            this.registerUsername.Depth = 0;
            this.registerUsername.ForeColor = System.Drawing.Color.White;
            this.registerUsername.Hint = "Username";
            this.registerUsername.Location = new System.Drawing.Point(32, 116);
            this.registerUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerUsername.Name = "registerUsername";
            this.registerUsername.PasswordChar = '\0';
            this.registerUsername.SelectedText = "";
            this.registerUsername.SelectionLength = 0;
            this.registerUsername.SelectionStart = 0;
            this.registerUsername.Size = new System.Drawing.Size(249, 23);
            this.registerUsername.TabIndex = 34;
            this.registerUsername.UseSystemPasswordChar = false;
            // 
            // registerEmail
            // 
            this.registerEmail.BackColor = System.Drawing.Color.White;
            this.registerEmail.Depth = 0;
            this.registerEmail.ForeColor = System.Drawing.Color.White;
            this.registerEmail.Hint = "Email";
            this.registerEmail.Location = new System.Drawing.Point(32, 145);
            this.registerEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.registerEmail.Name = "registerEmail";
            this.registerEmail.PasswordChar = '\0';
            this.registerEmail.SelectedText = "";
            this.registerEmail.SelectionLength = 0;
            this.registerEmail.SelectionStart = 0;
            this.registerEmail.Size = new System.Drawing.Size(249, 23);
            this.registerEmail.TabIndex = 35;
            this.registerEmail.UseSystemPasswordChar = false;
            // 
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.errorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.errorBox.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.errorBox.Location = new System.Drawing.Point(-1, 49);
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(325, 42);
            this.errorBox.TabIndex = 36;
            this.errorBox.Visible = false;
            this.errorBox.Click += new System.EventHandler(this.normalView);
            // 
            // successBox
            // 
            this.successBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.successBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.successBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.successBox.kind = FlatUI.FlatAlertBox._Kind.Success;
            this.successBox.Location = new System.Drawing.Point(-1, 49);
            this.successBox.Name = "successBox";
            this.successBox.Size = new System.Drawing.Size(325, 42);
            this.successBox.TabIndex = 37;
            this.successBox.Visible = false;
            this.successBox.Click += new System.EventHandler(this.normalView);
            // 
            // registerForm
            // 
            this.AcceptButton = this.registerButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 444);
            this.Controls.Add(this.registerEmail);
            this.Controls.Add(this.registerUsername);
            this.Controls.Add(this.registerPass);
            this.Controls.Add(this.registerPassConfirm);
            this.Controls.Add(this.registerLogo);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.loginMessage);
            this.Controls.Add(this.loginLink);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.successBox);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "registerForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "registerForm";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.registerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registerLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox registerLogo;
        private MaterialSkin.Controls.MaterialTabSelector separator;
        private MaterialSkin.Controls.MaterialRaisedButton loginLink;
        private MaterialSkin.Controls.MaterialRaisedButton registerButton;
        private MaterialSkin.Controls.MaterialLabel loginMessage;
        private MaterialSkin.Controls.MaterialSingleLineTextField registerPassConfirm;
        private MaterialSkin.Controls.MaterialSingleLineTextField registerPass;
        private MaterialSkin.Controls.MaterialSingleLineTextField registerUsername;
        private MaterialSkin.Controls.MaterialSingleLineTextField registerEmail;
        private FlatUI.FlatAlertBox errorBox;
        private FlatUI.FlatAlertBox successBox;
    }
}