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
            this.noSplash = new MaterialSkin.Controls.MaterialCheckBox();
            this.emptyWorld = new MaterialSkin.Controls.MaterialCheckBox();
            this.showScriptError = new MaterialSkin.Controls.MaterialCheckBox();
            this.noPause = new MaterialSkin.Controls.MaterialCheckBox();
            this.skipIntro = new MaterialSkin.Controls.MaterialCheckBox();
            this.noLogs = new MaterialSkin.Controls.MaterialCheckBox();
            this.noFilePath = new MaterialSkin.Controls.MaterialCheckBox();
            this.windowed = new MaterialSkin.Controls.MaterialCheckBox();
            this.playerStatusLabel = new FlatUI.FlatLabel();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Depth = 0;
            this.saveButton.Location = new System.Drawing.Point(462, 356);
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
            this.changeLanguageButon.Location = new System.Drawing.Point(306, 348);
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
            this.deleteButton.Location = new System.Drawing.Point(150, 348);
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
            this.launchParam.Hint = "Start game options";
            this.launchParam.Location = new System.Drawing.Point(23, 319);
            this.launchParam.MouseState = MaterialSkin.MouseState.HOVER;
            this.launchParam.Name = "launchParam";
            this.launchParam.PasswordChar = '\0';
            this.launchParam.SelectedText = "";
            this.launchParam.SelectionLength = 0;
            this.launchParam.SelectionStart = 0;
            this.launchParam.Size = new System.Drawing.Size(561, 23);
            this.launchParam.TabIndex = 16;
            this.launchParam.UseSystemPasswordChar = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Depth = 0;
            this.cancelButton.Location = new System.Drawing.Point(23, 356);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Primary = true;
            this.cancelButton.Size = new System.Drawing.Size(121, 27);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // noSplash
            // 
            this.noSplash.AutoSize = true;
            this.noSplash.Depth = 0;
            this.noSplash.Font = new System.Drawing.Font("Roboto", 10F);
            this.noSplash.Location = new System.Drawing.Point(23, 60);
            this.noSplash.Margin = new System.Windows.Forms.Padding(0);
            this.noSplash.MouseLocation = new System.Drawing.Point(-1, -1);
            this.noSplash.MouseState = MaterialSkin.MouseState.HOVER;
            this.noSplash.Name = "noSplash";
            this.noSplash.Ripple = true;
            this.noSplash.Size = new System.Drawing.Size(136, 30);
            this.noSplash.TabIndex = 26;
            this.noSplash.Text = "No splash screen";
            this.noSplash.UseVisualStyleBackColor = true;
            this.noSplash.CheckedChanged += new System.EventHandler(this.noSplash_CheckedChanged);
            // 
            // emptyWorld
            // 
            this.emptyWorld.AutoSize = true;
            this.emptyWorld.Depth = 0;
            this.emptyWorld.Font = new System.Drawing.Font("Roboto", 10F);
            this.emptyWorld.Location = new System.Drawing.Point(23, 90);
            this.emptyWorld.Margin = new System.Windows.Forms.Padding(0);
            this.emptyWorld.MouseLocation = new System.Drawing.Point(-1, -1);
            this.emptyWorld.MouseState = MaterialSkin.MouseState.HOVER;
            this.emptyWorld.Name = "emptyWorld";
            this.emptyWorld.Ripple = true;
            this.emptyWorld.Size = new System.Drawing.Size(153, 30);
            this.emptyWorld.TabIndex = 27;
            this.emptyWorld.Text = "Empty default world";
            this.emptyWorld.UseVisualStyleBackColor = true;
            this.emptyWorld.CheckedChanged += new System.EventHandler(this.emptyWorld_CheckedChanged);
            // 
            // showScriptError
            // 
            this.showScriptError.AutoSize = true;
            this.showScriptError.Depth = 0;
            this.showScriptError.Font = new System.Drawing.Font("Roboto", 10F);
            this.showScriptError.Location = new System.Drawing.Point(23, 120);
            this.showScriptError.Margin = new System.Windows.Forms.Padding(0);
            this.showScriptError.MouseLocation = new System.Drawing.Point(-1, -1);
            this.showScriptError.MouseState = MaterialSkin.MouseState.HOVER;
            this.showScriptError.Name = "showScriptError";
            this.showScriptError.Ripple = true;
            this.showScriptError.Size = new System.Drawing.Size(135, 30);
            this.showScriptError.TabIndex = 28;
            this.showScriptError.Text = "Show script error";
            this.showScriptError.UseVisualStyleBackColor = true;
            this.showScriptError.CheckedChanged += new System.EventHandler(this.showScriptError_CheckedChanged);
            // 
            // noPause
            // 
            this.noPause.AutoSize = true;
            this.noPause.Depth = 0;
            this.noPause.Font = new System.Drawing.Font("Roboto", 10F);
            this.noPause.Location = new System.Drawing.Point(23, 150);
            this.noPause.Margin = new System.Windows.Forms.Padding(0);
            this.noPause.MouseLocation = new System.Drawing.Point(-1, -1);
            this.noPause.MouseState = MaterialSkin.MouseState.HOVER;
            this.noPause.Name = "noPause";
            this.noPause.Ripple = true;
            this.noPause.Size = new System.Drawing.Size(88, 30);
            this.noPause.TabIndex = 29;
            this.noPause.Text = "No pause";
            this.noPause.UseVisualStyleBackColor = true;
            this.noPause.CheckedChanged += new System.EventHandler(this.noPause_CheckedChanged);
            // 
            // skipIntro
            // 
            this.skipIntro.AutoSize = true;
            this.skipIntro.Depth = 0;
            this.skipIntro.Font = new System.Drawing.Font("Roboto", 10F);
            this.skipIntro.Location = new System.Drawing.Point(232, 150);
            this.skipIntro.Margin = new System.Windows.Forms.Padding(0);
            this.skipIntro.MouseLocation = new System.Drawing.Point(-1, -1);
            this.skipIntro.MouseState = MaterialSkin.MouseState.HOVER;
            this.skipIntro.Name = "skipIntro";
            this.skipIntro.Ripple = true;
            this.skipIntro.Size = new System.Drawing.Size(88, 30);
            this.skipIntro.TabIndex = 30;
            this.skipIntro.Text = "Skip intro";
            this.skipIntro.UseVisualStyleBackColor = true;
            this.skipIntro.CheckedChanged += new System.EventHandler(this.skipIntro_CheckedChanged);
            // 
            // noLogs
            // 
            this.noLogs.AutoSize = true;
            this.noLogs.Depth = 0;
            this.noLogs.Font = new System.Drawing.Font("Roboto", 10F);
            this.noLogs.Location = new System.Drawing.Point(232, 60);
            this.noLogs.Margin = new System.Windows.Forms.Padding(0);
            this.noLogs.MouseLocation = new System.Drawing.Point(-1, -1);
            this.noLogs.MouseState = MaterialSkin.MouseState.HOVER;
            this.noLogs.Name = "noLogs";
            this.noLogs.Ripple = true;
            this.noLogs.Size = new System.Drawing.Size(81, 30);
            this.noLogs.TabIndex = 31;
            this.noLogs.Text = "No Logs";
            this.noLogs.UseVisualStyleBackColor = true;
            this.noLogs.CheckedChanged += new System.EventHandler(this.noLogs_CheckedChanged);
            // 
            // noFilePath
            // 
            this.noFilePath.AutoSize = true;
            this.noFilePath.Depth = 0;
            this.noFilePath.Font = new System.Drawing.Font("Roboto", 10F);
            this.noFilePath.Location = new System.Drawing.Point(232, 90);
            this.noFilePath.Margin = new System.Windows.Forms.Padding(0);
            this.noFilePath.MouseLocation = new System.Drawing.Point(-1, -1);
            this.noFilePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.noFilePath.Name = "noFilePath";
            this.noFilePath.Ripple = true;
            this.noFilePath.Size = new System.Drawing.Size(127, 30);
            this.noFilePath.TabIndex = 32;
            this.noFilePath.Text = "No file patching";
            this.noFilePath.UseVisualStyleBackColor = true;
            this.noFilePath.CheckedChanged += new System.EventHandler(this.noFilePath_CheckedChanged);
            // 
            // windowed
            // 
            this.windowed.AutoSize = true;
            this.windowed.Depth = 0;
            this.windowed.Font = new System.Drawing.Font("Roboto", 10F);
            this.windowed.Location = new System.Drawing.Point(232, 120);
            this.windowed.Margin = new System.Windows.Forms.Padding(0);
            this.windowed.MouseLocation = new System.Drawing.Point(-1, -1);
            this.windowed.MouseState = MaterialSkin.MouseState.HOVER;
            this.windowed.Name = "windowed";
            this.windowed.Ripple = true;
            this.windowed.Size = new System.Drawing.Size(94, 30);
            this.windowed.TabIndex = 33;
            this.windowed.Text = "Windowed";
            this.windowed.UseVisualStyleBackColor = true;
            this.windowed.CheckedChanged += new System.EventHandler(this.windowed_CheckedChanged);
            // 
            // playerStatusLabel
            // 
            this.playerStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerStatusLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold);
            this.playerStatusLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.playerStatusLabel.Location = new System.Drawing.Point(20, 300);
            this.playerStatusLabel.Name = "playerStatusLabel";
            this.playerStatusLabel.Size = new System.Drawing.Size(92, 14);
            this.playerStatusLabel.TabIndex = 34;
            this.playerStatusLabel.Text = "Game options :";
            // 
            // settingsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 406);
            this.Controls.Add(this.playerStatusLabel);
            this.Controls.Add(this.windowed);
            this.Controls.Add(this.noFilePath);
            this.Controls.Add(this.noLogs);
            this.Controls.Add(this.skipIntro);
            this.Controls.Add(this.noPause);
            this.Controls.Add(this.showScriptError);
            this.Controls.Add(this.emptyWorld);
            this.Controls.Add(this.noSplash);
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
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton saveButton;
        private MaterialSkin.Controls.MaterialRaisedButton changeLanguageButon;
        private MaterialSkin.Controls.MaterialRaisedButton deleteButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField launchParam;
        private MaterialSkin.Controls.MaterialRaisedButton cancelButton;
        private MaterialSkin.Controls.MaterialCheckBox noSplash;
        private MaterialSkin.Controls.MaterialCheckBox emptyWorld;
        private MaterialSkin.Controls.MaterialCheckBox showScriptError;
        private MaterialSkin.Controls.MaterialCheckBox noPause;
        private MaterialSkin.Controls.MaterialCheckBox skipIntro;
        private MaterialSkin.Controls.MaterialCheckBox noLogs;
        private MaterialSkin.Controls.MaterialCheckBox noFilePath;
        private MaterialSkin.Controls.MaterialCheckBox windowed;
        private FlatUI.FlatLabel playerStatusLabel;
    }
}