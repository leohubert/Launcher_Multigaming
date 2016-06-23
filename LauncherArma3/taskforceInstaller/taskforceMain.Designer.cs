namespace taskforceInstaller
{
    partial class taskforceMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taskforceMain));
            this.chooseButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.installButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.teamspeakChooser = new System.Windows.Forms.FolderBrowserDialog();
            this.teamspeakDestination = new FlatUI.FlatLabel();
            this.taskforceProgress = new FlatUI.FlatProgressBar();
            this.SuspendLayout();
            // 
            // chooseButton
            // 
            this.chooseButton.Depth = 0;
            this.chooseButton.Location = new System.Drawing.Point(23, 33);
            this.chooseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Primary = true;
            this.chooseButton.Size = new System.Drawing.Size(166, 46);
            this.chooseButton.TabIndex = 19;
            this.chooseButton.Text = "Choose teamspeak3 directory";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Visible = false;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // installButton
            // 
            this.installButton.Depth = 0;
            this.installButton.Location = new System.Drawing.Point(241, 33);
            this.installButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.installButton.Name = "installButton";
            this.installButton.Primary = true;
            this.installButton.Size = new System.Drawing.Size(166, 46);
            this.installButton.TabIndex = 20;
            this.installButton.Text = "Install Tasforce";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // teamspeakDestination
            // 
            this.teamspeakDestination.BackColor = System.Drawing.Color.Transparent;
            this.teamspeakDestination.Cursor = System.Windows.Forms.Cursors.Default;
            this.teamspeakDestination.Font = new System.Drawing.Font("Arial Black", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamspeakDestination.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.teamspeakDestination.Location = new System.Drawing.Point(-3, 86);
            this.teamspeakDestination.Name = "teamspeakDestination";
            this.teamspeakDestination.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.teamspeakDestination.Size = new System.Drawing.Size(434, 22);
            this.teamspeakDestination.TabIndex = 21;
            this.teamspeakDestination.Text = "Ready to download";
            // 
            // taskforceProgress
            // 
            this.taskforceProgress.BackColor = System.Drawing.Color.White;
            this.taskforceProgress.DarkerProgress = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.taskforceProgress.Location = new System.Drawing.Point(0, 86);
            this.taskforceProgress.Maximum = 100;
            this.taskforceProgress.Name = "taskforceProgress";
            this.taskforceProgress.Pattern = true;
            this.taskforceProgress.PercentSign = false;
            this.taskforceProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.taskforceProgress.ShowBalloon = false;
            this.taskforceProgress.Size = new System.Drawing.Size(431, 42);
            this.taskforceProgress.TabIndex = 0;
            this.taskforceProgress.Value = 0;
            // 
            // taskforceMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 128);
            this.Controls.Add(this.teamspeakDestination);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.taskforceProgress);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "taskforceMain";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "taskforceMain";
            this.Load += new System.EventHandler(this.taskforceMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUI.FlatProgressBar taskforceProgress;
        private MaterialSkin.Controls.MaterialRaisedButton chooseButton;
        private MaterialSkin.Controls.MaterialRaisedButton installButton;
        private System.Windows.Forms.FolderBrowserDialog teamspeakChooser;
        private FlatUI.FlatLabel teamspeakDestination;
    }
}