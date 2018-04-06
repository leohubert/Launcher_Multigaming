namespace launcherUpdate
{
    partial class updateMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(updateMain));
            this.downloadProgress = new FlatUI.FlatProgressBar();
            this.downloadLabel = new MonoFlat.MonoFlat_Label();
            this.SuspendLayout();
            // 
            // downloadProgress
            // 
            this.downloadProgress.BackColor = System.Drawing.Color.White;
            this.downloadProgress.DarkerProgress = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            this.downloadProgress.Location = new System.Drawing.Point(23, 12);
            this.downloadProgress.Maximum = 100;
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Pattern = true;
            this.downloadProgress.PercentSign = false;
            this.downloadProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.downloadProgress.ShowBalloon = true;
            this.downloadProgress.Size = new System.Drawing.Size(477, 42);
            this.downloadProgress.TabIndex = 1;
            this.downloadProgress.Text = "downloadProgress";
            this.downloadProgress.Value = 0;
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.BackColor = System.Drawing.Color.Transparent;
            this.downloadLabel.Font = new System.Drawing.Font("Berlin Sans FB Demi", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadLabel.ForeColor = System.Drawing.Color.DimGray;
            this.downloadLabel.Location = new System.Drawing.Point(20, 63);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(163, 18);
            this.downloadLabel.TabIndex = 2;
            this.downloadLabel.Text = "Download in progress ... ";
            // 
            // updateMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 96);
            this.ControlBox = false;
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.downloadProgress);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "updateMain";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "Launcher update";
            this.Load += new System.EventHandler(this.updateMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FlatUI.FlatProgressBar downloadProgress;
        private MonoFlat.MonoFlat_Label downloadLabel;
    }
}