namespace LauncherArma3
{
    partial class steamWrapper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(steamWrapper));
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.startSteam = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.Black;
            this.flatLabel1.Location = new System.Drawing.Point(23, 56);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(458, 102);
            this.flatLabel1.TabIndex = 13;
            this.flatLabel1.Text = resources.GetString("flatLabel1.Text");
            this.flatLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // startSteam
            // 
            this.startSteam.Depth = 0;
            this.startSteam.Location = new System.Drawing.Point(124, 175);
            this.startSteam.MouseState = MaterialSkin.MouseState.HOVER;
            this.startSteam.Name = "startSteam";
            this.startSteam.Primary = true;
            this.startSteam.Size = new System.Drawing.Size(254, 46);
            this.startSteam.TabIndex = 14;
            this.startSteam.Text = "Start Steam";
            this.startSteam.UseVisualStyleBackColor = true;
            this.startSteam.Click += new System.EventHandler(this.startSteam_Click);
            // 
            // steamWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 244);
            this.ControlBox = false;
            this.Controls.Add(this.startSteam);
            this.Controls.Add(this.flatLabel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "steamWrapper";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "Steam Wrapper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FlatUI.FlatLabel flatLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton startSteam;
    }
}