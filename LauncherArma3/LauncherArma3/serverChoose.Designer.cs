namespace LauncherArma3
{
    partial class serverChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serverChoose));
            this.autoConnect = new MaterialSkin.Controls.MaterialCheckBox();
            this.serverChooseBox = new System.Windows.Forms.GroupBox();
            this.serverIcon = new System.Windows.Forms.PictureBox();
            this.chooseServer = new iTalk.iTalk_ComboBox();
            this.serverStatusBox = new System.Windows.Forms.GroupBox();
            this.serverMap = new FlatUI.FlatLabel();
            this.serverMapLabel = new FlatUI.FlatLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.serverStatus = new FlatUI.FlatLabel();
            this.serverPlayers = new FlatUI.FlatLabel();
            this.serverNameLabel = new FlatUI.FlatLabel();
            this.serverName = new FlatUI.FlatLabel();
            this.serverPlayersLabel = new FlatUI.FlatLabel();
            this.serverMissionLabel = new FlatUI.FlatLabel();
            this.serverMission = new FlatUI.FlatLabel();
            this.nextButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.serverChooseBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverIcon)).BeginInit();
            this.serverStatusBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // autoConnect
            // 
            this.autoConnect.AutoSize = true;
            this.autoConnect.Depth = 0;
            this.autoConnect.Font = new System.Drawing.Font("Roboto", 10F);
            this.autoConnect.Location = new System.Drawing.Point(472, 175);
            this.autoConnect.Margin = new System.Windows.Forms.Padding(0);
            this.autoConnect.MouseLocation = new System.Drawing.Point(-1, -1);
            this.autoConnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.autoConnect.Name = "autoConnect";
            this.autoConnect.Ripple = true;
            this.autoConnect.Size = new System.Drawing.Size(112, 30);
            this.autoConnect.TabIndex = 3;
            this.autoConnect.Text = "Auto connect";
            this.autoConnect.UseVisualStyleBackColor = true;
            this.autoConnect.CheckedChanged += new System.EventHandler(this.autoConnect_CheckedChanged);
            // 
            // serverChooseBox
            // 
            this.serverChooseBox.Controls.Add(this.serverIcon);
            this.serverChooseBox.Controls.Add(this.chooseServer);
            this.serverChooseBox.Location = new System.Drawing.Point(320, 33);
            this.serverChooseBox.Name = "serverChooseBox";
            this.serverChooseBox.Size = new System.Drawing.Size(297, 88);
            this.serverChooseBox.TabIndex = 6;
            this.serverChooseBox.TabStop = false;
            // 
            // serverIcon
            // 
            this.serverIcon.BackColor = System.Drawing.Color.Transparent;
            this.serverIcon.Image = ((System.Drawing.Image)(resources.GetObject("serverIcon.Image")));
            this.serverIcon.Location = new System.Drawing.Point(1, 0);
            this.serverIcon.Name = "serverIcon";
            this.serverIcon.Size = new System.Drawing.Size(296, 24);
            this.serverIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.serverIcon.TabIndex = 11;
            this.serverIcon.TabStop = false;
            // 
            // chooseServer
            // 
            this.chooseServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.chooseServer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chooseServer.DropDownHeight = 100;
            this.chooseServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseServer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chooseServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.chooseServer.FormattingEnabled = true;
            this.chooseServer.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.chooseServer.IntegralHeight = false;
            this.chooseServer.ItemHeight = 20;
            this.chooseServer.Items.AddRange(new object[] {
            "Choose a server / game"});
            this.chooseServer.Location = new System.Drawing.Point(6, 42);
            this.chooseServer.Name = "chooseServer";
            this.chooseServer.Size = new System.Drawing.Size(285, 26);
            this.chooseServer.StartIndex = 0;
            this.chooseServer.TabIndex = 5;
            this.chooseServer.SelectedIndexChanged += new System.EventHandler(this.chooseServer_SelectedIndexChanged);
            // 
            // serverStatusBox
            // 
            this.serverStatusBox.Controls.Add(this.serverMap);
            this.serverStatusBox.Controls.Add(this.serverMapLabel);
            this.serverStatusBox.Controls.Add(this.pictureBox1);
            this.serverStatusBox.Controls.Add(this.serverStatus);
            this.serverStatusBox.Controls.Add(this.serverPlayers);
            this.serverStatusBox.Controls.Add(this.serverNameLabel);
            this.serverStatusBox.Controls.Add(this.serverName);
            this.serverStatusBox.Controls.Add(this.serverPlayersLabel);
            this.serverStatusBox.Controls.Add(this.serverMissionLabel);
            this.serverStatusBox.Controls.Add(this.serverMission);
            this.serverStatusBox.Location = new System.Drawing.Point(23, 33);
            this.serverStatusBox.Name = "serverStatusBox";
            this.serverStatusBox.Size = new System.Drawing.Size(291, 218);
            this.serverStatusBox.TabIndex = 20;
            this.serverStatusBox.TabStop = false;
            // 
            // serverMap
            // 
            this.serverMap.BackColor = System.Drawing.Color.Transparent;
            this.serverMap.Cursor = System.Windows.Forms.Cursors.Default;
            this.serverMap.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverMap.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.serverMap.Location = new System.Drawing.Point(9, 152);
            this.serverMap.Name = "serverMap";
            this.serverMap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.serverMap.Size = new System.Drawing.Size(282, 21);
            this.serverMap.TabIndex = 22;
            this.serverMap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // serverMapLabel
            // 
            this.serverMapLabel.BackColor = System.Drawing.Color.Transparent;
            this.serverMapLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold);
            this.serverMapLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.serverMapLabel.Location = new System.Drawing.Point(6, 138);
            this.serverMapLabel.Name = "serverMapLabel";
            this.serverMapLabel.Size = new System.Drawing.Size(126, 14);
            this.serverMapLabel.TabIndex = 21;
            this.serverMapLabel.Text = "Server Map:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // serverStatus
            // 
            this.serverStatus.BackColor = System.Drawing.Color.Transparent;
            this.serverStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.serverStatus.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverStatus.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.serverStatus.Location = new System.Drawing.Point(0, 31);
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.serverStatus.Size = new System.Drawing.Size(291, 22);
            this.serverStatus.TabIndex = 20;
            this.serverStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serverPlayers
            // 
            this.serverPlayers.BackColor = System.Drawing.Color.Transparent;
            this.serverPlayers.Cursor = System.Windows.Forms.Cursors.Default;
            this.serverPlayers.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverPlayers.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.serverPlayers.Location = new System.Drawing.Point(9, 187);
            this.serverPlayers.Name = "serverPlayers";
            this.serverPlayers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.serverPlayers.Size = new System.Drawing.Size(282, 21);
            this.serverPlayers.TabIndex = 19;
            this.serverPlayers.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.serverNameLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold);
            this.serverNameLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.serverNameLabel.Location = new System.Drawing.Point(6, 66);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(126, 14);
            this.serverNameLabel.TabIndex = 15;
            this.serverNameLabel.Text = "Server Name:";
            // 
            // serverName
            // 
            this.serverName.BackColor = System.Drawing.Color.Transparent;
            this.serverName.Cursor = System.Windows.Forms.Cursors.Default;
            this.serverName.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.serverName.Location = new System.Drawing.Point(9, 80);
            this.serverName.Name = "serverName";
            this.serverName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.serverName.Size = new System.Drawing.Size(282, 22);
            this.serverName.TabIndex = 13;
            this.serverName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // serverPlayersLabel
            // 
            this.serverPlayersLabel.BackColor = System.Drawing.Color.Transparent;
            this.serverPlayersLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold);
            this.serverPlayersLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.serverPlayersLabel.Location = new System.Drawing.Point(6, 173);
            this.serverPlayersLabel.Name = "serverPlayersLabel";
            this.serverPlayersLabel.Size = new System.Drawing.Size(126, 14);
            this.serverPlayersLabel.TabIndex = 18;
            this.serverPlayersLabel.Text = "Players online:";
            // 
            // serverMissionLabel
            // 
            this.serverMissionLabel.BackColor = System.Drawing.Color.Transparent;
            this.serverMissionLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold);
            this.serverMissionLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.serverMissionLabel.Location = new System.Drawing.Point(6, 102);
            this.serverMissionLabel.Name = "serverMissionLabel";
            this.serverMissionLabel.Size = new System.Drawing.Size(126, 14);
            this.serverMissionLabel.TabIndex = 16;
            this.serverMissionLabel.Text = "Server Mission:";
            // 
            // serverMission
            // 
            this.serverMission.BackColor = System.Drawing.Color.Transparent;
            this.serverMission.Cursor = System.Windows.Forms.Cursors.Default;
            this.serverMission.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverMission.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.serverMission.Location = new System.Drawing.Point(9, 116);
            this.serverMission.Name = "serverMission";
            this.serverMission.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.serverMission.Size = new System.Drawing.Size(282, 22);
            this.serverMission.TabIndex = 17;
            this.serverMission.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // nextButton
            // 
            this.nextButton.Depth = 0;
            this.nextButton.Location = new System.Drawing.Point(472, 208);
            this.nextButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.nextButton.Name = "nextButton";
            this.nextButton.Primary = true;
            this.nextButton.Size = new System.Drawing.Size(145, 46);
            this.nextButton.TabIndex = 12;
            this.nextButton.Text = "Continue";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // serverChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 274);
            this.Controls.Add(this.autoConnect);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.serverChooseBox);
            this.Controls.Add(this.serverStatusBox);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "serverChoose";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "Choose a server";
            this.Load += new System.EventHandler(this.serverChoose_Load);
            this.serverChooseBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serverIcon)).EndInit();
            this.serverStatusBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialCheckBox autoConnect;
        private iTalk.iTalk_ComboBox chooseServer;
        private System.Windows.Forms.GroupBox serverChooseBox;
        private System.Windows.Forms.PictureBox serverIcon;
        private FlatUI.FlatLabel serverPlayers;
        private FlatUI.FlatLabel serverPlayersLabel;
        private FlatUI.FlatLabel serverMission;
        private FlatUI.FlatLabel serverMissionLabel;
        private FlatUI.FlatLabel serverNameLabel;
        private FlatUI.FlatLabel serverName;
        private System.Windows.Forms.GroupBox serverStatusBox;
        private FlatUI.FlatLabel serverStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FlatUI.FlatLabel serverMap;
        private FlatUI.FlatLabel serverMapLabel;
        private MaterialSkin.Controls.MaterialRaisedButton nextButton;
    }
}