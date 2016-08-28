namespace LauncherArma3
{
    partial class selectSteamProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectSteamProfile));
            this.chooseAccount = new iTalk.iTalk_ComboBox();
            this.SuspendLayout();
            // 
            // chooseAccount
            // 
            this.chooseAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.chooseAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chooseAccount.DropDownHeight = 100;
            this.chooseAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chooseAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.chooseAccount.FormattingEnabled = true;
            this.chooseAccount.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.chooseAccount.IntegralHeight = false;
            this.chooseAccount.ItemHeight = 20;
            this.chooseAccount.Items.AddRange(new object[] {
            "Choose a steam account"});
            this.chooseAccount.Location = new System.Drawing.Point(23, 63);
            this.chooseAccount.Name = "chooseAccount";
            this.chooseAccount.Size = new System.Drawing.Size(293, 26);
            this.chooseAccount.StartIndex = 0;
            this.chooseAccount.TabIndex = 6;
            // 
            // selectSteamProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 122);
            this.Controls.Add(this.chooseAccount);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "selectSteamProfile";
            this.Resizable = false;
            this.Text = "Choose your steam account";
            this.Load += new System.EventHandler(this.selectSteamProfile_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ComboBox chooseAccount;
    }
}