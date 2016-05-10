namespace LauncherArma3
{
    partial class languageChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(languageChoice));
            this.japanFlag = new System.Windows.Forms.PictureBox();
            this.germanFlag = new System.Windows.Forms.PictureBox();
            this.montrealFlag = new System.Windows.Forms.PictureBox();
            this.englishFlag = new System.Windows.Forms.PictureBox();
            this.spainFlag = new System.Windows.Forms.PictureBox();
            this.frenchFlag = new System.Windows.Forms.PictureBox();
            this.animation = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.japanFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.germanFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.montrealFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.englishFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spainFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frenchFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // japanFlag
            // 
            this.japanFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.japanFlag.Image = ((System.Drawing.Image)(resources.GetObject("japanFlag.Image")));
            this.japanFlag.Location = new System.Drawing.Point(460, 236);
            this.japanFlag.Name = "japanFlag";
            this.japanFlag.Size = new System.Drawing.Size(222, 157);
            this.japanFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.japanFlag.TabIndex = 12;
            this.japanFlag.TabStop = false;
            this.japanFlag.Click += new System.EventHandler(this.japanFlag_Click);
            this.japanFlag.MouseEnter += new System.EventHandler(this.setJapan);
            // 
            // germanFlag
            // 
            this.germanFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.germanFlag.Image = ((System.Drawing.Image)(resources.GetObject("germanFlag.Image")));
            this.germanFlag.Location = new System.Drawing.Point(460, 73);
            this.germanFlag.Name = "germanFlag";
            this.germanFlag.Size = new System.Drawing.Size(222, 157);
            this.germanFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.germanFlag.TabIndex = 11;
            this.germanFlag.TabStop = false;
            this.germanFlag.Click += new System.EventHandler(this.germanFlag_Click);
            this.germanFlag.MouseEnter += new System.EventHandler(this.setDeutch);
            // 
            // montrealFlag
            // 
            this.montrealFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.montrealFlag.Image = ((System.Drawing.Image)(resources.GetObject("montrealFlag.Image")));
            this.montrealFlag.Location = new System.Drawing.Point(232, 236);
            this.montrealFlag.Name = "montrealFlag";
            this.montrealFlag.Size = new System.Drawing.Size(222, 157);
            this.montrealFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.montrealFlag.TabIndex = 10;
            this.montrealFlag.TabStop = false;
            this.montrealFlag.Click += new System.EventHandler(this.montrealFlag_Click);
            this.montrealFlag.MouseEnter += new System.EventHandler(this.setMontreal);
            // 
            // englishFlag
            // 
            this.englishFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.englishFlag.Image = ((System.Drawing.Image)(resources.GetObject("englishFlag.Image")));
            this.englishFlag.Location = new System.Drawing.Point(232, 73);
            this.englishFlag.Name = "englishFlag";
            this.englishFlag.Size = new System.Drawing.Size(222, 157);
            this.englishFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.englishFlag.TabIndex = 9;
            this.englishFlag.TabStop = false;
            this.englishFlag.Click += new System.EventHandler(this.englishFlag_Click);
            this.englishFlag.MouseEnter += new System.EventHandler(this.setEnglish);
            // 
            // spainFlag
            // 
            this.spainFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spainFlag.Image = ((System.Drawing.Image)(resources.GetObject("spainFlag.Image")));
            this.spainFlag.Location = new System.Drawing.Point(4, 236);
            this.spainFlag.Name = "spainFlag";
            this.spainFlag.Size = new System.Drawing.Size(222, 157);
            this.spainFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spainFlag.TabIndex = 8;
            this.spainFlag.TabStop = false;
            this.spainFlag.Click += new System.EventHandler(this.spainFlag_Click);
            this.spainFlag.MouseEnter += new System.EventHandler(this.setSpain);
            // 
            // frenchFlag
            // 
            this.frenchFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.frenchFlag.Image = ((System.Drawing.Image)(resources.GetObject("frenchFlag.Image")));
            this.frenchFlag.Location = new System.Drawing.Point(4, 73);
            this.frenchFlag.Name = "frenchFlag";
            this.frenchFlag.Size = new System.Drawing.Size(222, 157);
            this.frenchFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.frenchFlag.TabIndex = 7;
            this.frenchFlag.TabStop = false;
            this.frenchFlag.Click += new System.EventHandler(this.frenchFlag_Click);
            this.frenchFlag.MouseEnter += new System.EventHandler(this.setFrench);
            // 
            // animation
            // 
            this.animation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.animation_DoWork);
            this.animation.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.refresh);
            // 
            // languageChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 399);
            this.Controls.Add(this.japanFlag);
            this.Controls.Add(this.germanFlag);
            this.Controls.Add(this.montrealFlag);
            this.Controls.Add(this.englishFlag);
            this.Controls.Add(this.spainFlag);
            this.Controls.Add(this.frenchFlag);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "languageChoice";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Select your language";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.close);
            this.Load += new System.EventHandler(this.languageChoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.japanFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.germanFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.montrealFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.englishFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spainFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frenchFlag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox japanFlag;
        private System.Windows.Forms.PictureBox germanFlag;
        private System.Windows.Forms.PictureBox montrealFlag;
        private System.Windows.Forms.PictureBox englishFlag;
        private System.Windows.Forms.PictureBox spainFlag;
        private System.Windows.Forms.PictureBox frenchFlag;
        private System.ComponentModel.BackgroundWorker animation;
    }
}