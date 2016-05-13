namespace launcherUpdate
{
    partial class splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(splash));
            this.wait = new System.ComponentModel.BackgroundWorker();
            this.splashScreen = new System.Windows.Forms.PictureBox();
            this.loadingProgress = new FlatUI.FlatProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splashScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // wait
            // 
            this.wait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wait_DoWork);
            this.wait.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.startUpdate);
            // 
            // splashScreen
            // 
            this.splashScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splashScreen.Image = ((System.Drawing.Image)(resources.GetObject("splashScreen.Image")));
            this.splashScreen.Location = new System.Drawing.Point(0, 0);
            this.splashScreen.Name = "splashScreen";
            this.splashScreen.Size = new System.Drawing.Size(673, 486);
            this.splashScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.splashScreen.TabIndex = 0;
            this.splashScreen.TabStop = false;
            // 
            // loadingProgress
            // 
            this.loadingProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.loadingProgress.DarkerProgress = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            this.loadingProgress.Location = new System.Drawing.Point(0, -24);
            this.loadingProgress.Maximum = 100;
            this.loadingProgress.Name = "loadingProgress";
            this.loadingProgress.Pattern = true;
            this.loadingProgress.PercentSign = false;
            this.loadingProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.loadingProgress.ShowBalloon = true;
            this.loadingProgress.Size = new System.Drawing.Size(673, 42);
            this.loadingProgress.TabIndex = 1;
            this.loadingProgress.Value = 0;
            // 
            // splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(673, 486);
            this.Controls.Add(this.loadingProgress);
            this.Controls.Add(this.splashScreen);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splash";
            this.TransparencyKey = System.Drawing.Color.DeepPink;
            this.Load += new System.EventHandler(this.splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splashScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker wait;
        private System.Windows.Forms.PictureBox splashScreen;
        private FlatUI.FlatProgressBar loadingProgress;
    }
}