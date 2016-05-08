namespace LauncherArma3
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.cancelButton = new MonoFlat.MonoFlat_Button();
            this.saveButton = new FlatUI.FlatButton();
            this.changeLanguage = new FlatUI.FlatButton();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cancelButton.Image = null;
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(23, 296);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(153, 51);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.saveButton.Location = new System.Drawing.Point(417, 296);
            this.saveButton.Name = "saveButton";
            this.saveButton.Rounded = false;
            this.saveButton.Size = new System.Drawing.Size(153, 51);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // changeLanguage
            // 
            this.changeLanguage.BackColor = System.Drawing.Color.Transparent;
            this.changeLanguage.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.changeLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeLanguage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.changeLanguage.Location = new System.Drawing.Point(23, 106);
            this.changeLanguage.Name = "changeLanguage";
            this.changeLanguage.Rounded = false;
            this.changeLanguage.Size = new System.Drawing.Size(153, 64);
            this.changeLanguage.TabIndex = 2;
            this.changeLanguage.Text = "Change language";
            this.changeLanguage.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.changeLanguage.Click += new System.EventHandler(this.changeLanguage_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 370);
            this.Controls.Add(this.changeLanguage);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "settingsForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Launcher Options";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_Button cancelButton;
        private FlatUI.FlatButton saveButton;
        private FlatUI.FlatButton changeLanguage;
    }
}