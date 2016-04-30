namespace Launcher_Arma3
{
    partial class launcherMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(launcherMain));
            this.pictureBig = new System.Windows.Forms.PictureBox();
            this.errorBox = new FlatUI.FlatAlertBox();
            this.succesBox = new FlatUI.FlatAlertBox();
            this.infoBox = new FlatUI.FlatAlertBox();
            this.notif = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBig)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBig
            // 
            this.pictureBig.BackColor = System.Drawing.Color.Transparent;
            this.pictureBig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBig.Image = ((System.Drawing.Image)(resources.GetObject("pictureBig.Image")));
            this.pictureBig.Location = new System.Drawing.Point(20, 60);
            this.pictureBig.Name = "pictureBig";
            this.pictureBig.Size = new System.Drawing.Size(883, 421);
            this.pictureBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBig.TabIndex = 3;
            this.pictureBig.TabStop = false;
            // 
            // errorBox
            // 
            this.errorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.errorBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.errorBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorBox.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.errorBox.Location = new System.Drawing.Point(23, 63);
            this.errorBox.Name = "errorBox";
            this.errorBox.Size = new System.Drawing.Size(877, 42);
            this.errorBox.TabIndex = 2;
            this.errorBox.Visible = false;
            // 
            // succesBox
            // 
            this.succesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.succesBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.succesBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.succesBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.succesBox.kind = FlatUI.FlatAlertBox._Kind.Success;
            this.succesBox.Location = new System.Drawing.Point(23, 63);
            this.succesBox.Name = "succesBox";
            this.succesBox.Size = new System.Drawing.Size(877, 42);
            this.succesBox.TabIndex = 1;
            this.succesBox.Visible = false;
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.infoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.infoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoBox.kind = FlatUI.FlatAlertBox._Kind.Info;
            this.infoBox.Location = new System.Drawing.Point(23, 63);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(877, 42);
            this.infoBox.TabIndex = 0;
            this.infoBox.Visible = false;
            // 
            // notif
            // 
            this.notif.Text = "notifyIcon1";
            this.notif.Visible = true;
            // 
            // launcherMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 501);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.succesBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.pictureBig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "launcherMain";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = "Green";
            this.Text = "Launcher Arma3";
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.launcherMain_Load);
            this.VisibleChanged += new System.EventHandler(this.checkOptions);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUI.FlatAlertBox infoBox;
        private FlatUI.FlatAlertBox succesBox;
        private FlatUI.FlatAlertBox errorBox;
        private System.Windows.Forms.PictureBox pictureBig;
        private System.Windows.Forms.NotifyIcon notif;
    }
}

