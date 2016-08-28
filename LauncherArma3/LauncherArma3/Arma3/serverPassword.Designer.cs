namespace LauncherArma3.Arma3
{
    partial class serverPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serverPassword));
            this.serverPass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.connectButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // serverPass
            // 
            this.serverPass.BackColor = System.Drawing.Color.White;
            this.serverPass.Depth = 0;
            this.serverPass.ForeColor = System.Drawing.Color.White;
            this.serverPass.Hint = "Type the password server";
            this.serverPass.Location = new System.Drawing.Point(23, 63);
            this.serverPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.serverPass.Name = "serverPass";
            this.serverPass.PasswordChar = '*';
            this.serverPass.SelectedText = "";
            this.serverPass.SelectionLength = 0;
            this.serverPass.SelectionStart = 0;
            this.serverPass.Size = new System.Drawing.Size(286, 23);
            this.serverPass.TabIndex = 17;
            this.serverPass.UseSystemPasswordChar = true;
            // 
            // connectButton
            // 
            this.connectButton.Depth = 0;
            this.connectButton.Location = new System.Drawing.Point(23, 92);
            this.connectButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.connectButton.Name = "connectButton";
            this.connectButton.Primary = true;
            this.connectButton.Size = new System.Drawing.Size(286, 36);
            this.connectButton.TabIndex = 18;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // serverPassword
            // 
            this.AcceptButton = this.connectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 139);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.serverPass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "serverPassword";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Server authentification";
            this.Load += new System.EventHandler(this.serverPassword_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField serverPass;
        private MaterialSkin.Controls.MaterialRaisedButton connectButton;
    }
}