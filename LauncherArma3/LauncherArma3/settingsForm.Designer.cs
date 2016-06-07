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
            this.saveButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.changeLanguageButon = new MaterialSkin.Controls.MaterialRaisedButton();
            this.deleteButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.launchParam = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cancelButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Depth = 0;
            this.saveButton.Location = new System.Drawing.Point(208, 146);
            this.saveButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveButton.Name = "saveButton";
            this.saveButton.Primary = true;
            this.saveButton.Size = new System.Drawing.Size(121, 27);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // changeLanguageButon
            // 
            this.changeLanguageButon.Depth = 0;
            this.changeLanguageButon.Location = new System.Drawing.Point(23, 63);
            this.changeLanguageButon.MouseState = MaterialSkin.MouseState.HOVER;
            this.changeLanguageButon.Name = "changeLanguageButon";
            this.changeLanguageButon.Primary = true;
            this.changeLanguageButon.Size = new System.Drawing.Size(150, 35);
            this.changeLanguageButon.TabIndex = 14;
            this.changeLanguageButon.Text = "Change language";
            this.changeLanguageButon.UseVisualStyleBackColor = true;
            this.changeLanguageButon.Click += new System.EventHandler(this.changeLanguageButon_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Depth = 0;
            this.deleteButton.Location = new System.Drawing.Point(179, 63);
            this.deleteButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Primary = true;
            this.deleteButton.Size = new System.Drawing.Size(150, 35);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.Text = "Delete mods";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // launchParam
            // 
            this.launchParam.BackColor = System.Drawing.Color.White;
            this.launchParam.Depth = 0;
            this.launchParam.ForeColor = System.Drawing.Color.White;
            this.launchParam.Hint = "Arma 3 launch options";
            this.launchParam.Location = new System.Drawing.Point(23, 117);
            this.launchParam.MouseState = MaterialSkin.MouseState.HOVER;
            this.launchParam.Name = "launchParam";
            this.launchParam.PasswordChar = '\0';
            this.launchParam.SelectedText = "";
            this.launchParam.SelectionLength = 0;
            this.launchParam.SelectionStart = 0;
            this.launchParam.Size = new System.Drawing.Size(306, 23);
            this.launchParam.TabIndex = 16;
            this.launchParam.UseSystemPasswordChar = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Depth = 0;
            this.cancelButton.Location = new System.Drawing.Point(23, 146);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Primary = true;
            this.cancelButton.Size = new System.Drawing.Size(121, 27);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // settingsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 190);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.launchParam);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.changeLanguageButon);
            this.Controls.Add(this.saveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "settingsForm";
            this.Resizable = false;
            this.Text = "Launcher Options";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton saveButton;
        private MaterialSkin.Controls.MaterialRaisedButton changeLanguageButon;
        private MaterialSkin.Controls.MaterialRaisedButton deleteButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField launchParam;
        private MaterialSkin.Controls.MaterialRaisedButton cancelButton;
    }
}