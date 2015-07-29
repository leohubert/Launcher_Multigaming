namespace Launcher_Arma3
{
    partial class Form2
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
            this.Change_Lang = new System.ComponentModel.BackgroundWorker();
            this.monoFlat_ThemeContainer1 = new MonoFlat.MonoFlat_ThemeContainer();
            this.Close_Bouton = new MonoFlat.MonoFlat_Button();
            this.Group_Options = new System.Windows.Forms.GroupBox();
            this.TextBox_Options = new iTalk.iTalk_TextBox_Big();
            this.Toggle_Options = new MonoFlat.MonoFlat_Toggle();
            this.Group_UserName = new System.Windows.Forms.GroupBox();
            this.TextBox_User = new iTalk.iTalk_TextBox_Big();
            this.Toggle_User = new MonoFlat.MonoFlat_Toggle();
            this.Language_label = new iTalk.iTalk_Label();
            this.Language_Chose = new iTalk.iTalk_ComboBox();
            this.monoFlat_ThemeContainer1.SuspendLayout();
            this.Group_Options.SuspendLayout();
            this.Group_UserName.SuspendLayout();
            this.SuspendLayout();
            // 
            // Change_Lang
            // 
            this.Change_Lang.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Change_Lang_DoWork);
            // 
            // monoFlat_ThemeContainer1
            // 
            this.monoFlat_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoFlat_ThemeContainer1.Controls.Add(this.Close_Bouton);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Group_Options);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Group_UserName);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Language_label);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Language_Chose);
            this.monoFlat_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monoFlat_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.monoFlat_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.monoFlat_ThemeContainer1.Name = "monoFlat_ThemeContainer1";
            this.monoFlat_ThemeContainer1.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.monoFlat_ThemeContainer1.RoundCorners = true;
            this.monoFlat_ThemeContainer1.Sizable = true;
            this.monoFlat_ThemeContainer1.Size = new System.Drawing.Size(718, 368);
            this.monoFlat_ThemeContainer1.SmartBounds = true;
            this.monoFlat_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.monoFlat_ThemeContainer1.TabIndex = 0;
            this.monoFlat_ThemeContainer1.Text = "Launcher Options";
            // 
            // Close_Bouton
            // 
            this.Close_Bouton.BackColor = System.Drawing.Color.Transparent;
            this.Close_Bouton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Close_Bouton.Image = null;
            this.Close_Bouton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Close_Bouton.Location = new System.Drawing.Point(572, 315);
            this.Close_Bouton.Name = "Close_Bouton";
            this.Close_Bouton.Size = new System.Drawing.Size(138, 41);
            this.Close_Bouton.TabIndex = 9;
            this.Close_Bouton.Text = "Close";
            this.Close_Bouton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Close_Bouton.Click += new System.EventHandler(this.iTalk_Icon_Tick1_Click);
            // 
            // Group_Options
            // 
            this.Group_Options.Controls.Add(this.TextBox_Options);
            this.Group_Options.Controls.Add(this.Toggle_Options);
            this.Group_Options.ForeColor = System.Drawing.Color.White;
            this.Group_Options.Location = new System.Drawing.Point(12, 282);
            this.Group_Options.Name = "Group_Options";
            this.Group_Options.Size = new System.Drawing.Size(554, 74);
            this.Group_Options.TabIndex = 6;
            this.Group_Options.TabStop = false;
            this.Group_Options.Text = "Launch Options";
            // 
            // TextBox_Options
            // 
            this.TextBox_Options.BackColor = System.Drawing.Color.Transparent;
            this.TextBox_Options.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TextBox_Options.ForeColor = System.Drawing.Color.DimGray;
            this.TextBox_Options.Image = null;
            this.TextBox_Options.Location = new System.Drawing.Point(6, 22);
            this.TextBox_Options.MaxLength = 32767;
            this.TextBox_Options.Multiline = false;
            this.TextBox_Options.Name = "TextBox_Options";
            this.TextBox_Options.ReadOnly = false;
            this.TextBox_Options.Size = new System.Drawing.Size(459, 41);
            this.TextBox_Options.TabIndex = 6;
            this.TextBox_Options.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_Options.UseSystemPasswordChar = false;
            this.TextBox_Options.TextChanged += new System.EventHandler(this.StartOption_Text);
            // 
            // Toggle_Options
            // 
            this.Toggle_Options.Location = new System.Drawing.Point(472, 30);
            this.Toggle_Options.Name = "Toggle_Options";
            this.Toggle_Options.Size = new System.Drawing.Size(76, 33);
            this.Toggle_Options.TabIndex = 3;
            this.Toggle_Options.Text = "Toggle_Options";
            this.Toggle_Options.Toggled = false;
            this.Toggle_Options.Type = MonoFlat.MonoFlat_Toggle._Type.CheckMark;
            this.Toggle_Options.ToggledChanged += new MonoFlat.MonoFlat_Toggle.ToggledChangedEventHandler(this.Toggle_Option);
            // 
            // Group_UserName
            // 
            this.Group_UserName.Controls.Add(this.TextBox_User);
            this.Group_UserName.Controls.Add(this.Toggle_User);
            this.Group_UserName.ForeColor = System.Drawing.Color.White;
            this.Group_UserName.Location = new System.Drawing.Point(13, 73);
            this.Group_UserName.Name = "Group_UserName";
            this.Group_UserName.Size = new System.Drawing.Size(354, 74);
            this.Group_UserName.TabIndex = 7;
            this.Group_UserName.TabStop = false;
            this.Group_UserName.Text = "UserName";
            // 
            // TextBox_User
            // 
            this.TextBox_User.BackColor = System.Drawing.Color.Transparent;
            this.TextBox_User.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TextBox_User.ForeColor = System.Drawing.Color.DimGray;
            this.TextBox_User.Image = null;
            this.TextBox_User.Location = new System.Drawing.Point(6, 22);
            this.TextBox_User.MaxLength = 32767;
            this.TextBox_User.Multiline = false;
            this.TextBox_User.Name = "TextBox_User";
            this.TextBox_User.ReadOnly = false;
            this.TextBox_User.Size = new System.Drawing.Size(256, 41);
            this.TextBox_User.TabIndex = 5;
            this.TextBox_User.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_User.UseSystemPasswordChar = false;
            this.TextBox_User.TextChanged += new System.EventHandler(this.UserName_ChangeText);
            // 
            // Toggle_User
            // 
            this.Toggle_User.Location = new System.Drawing.Point(268, 30);
            this.Toggle_User.Name = "Toggle_User";
            this.Toggle_User.Size = new System.Drawing.Size(76, 33);
            this.Toggle_User.TabIndex = 4;
            this.Toggle_User.Text = "Toggle_User";
            this.Toggle_User.Toggled = false;
            this.Toggle_User.Type = MonoFlat.MonoFlat_Toggle._Type.CheckMark;
            this.Toggle_User.ToggledChanged += new MonoFlat.MonoFlat_Toggle.ToggledChangedEventHandler(this.User_Toggle);
            // 
            // Language_label
            // 
            this.Language_label.AutoSize = true;
            this.Language_label.BackColor = System.Drawing.Color.Transparent;
            this.Language_label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Language_label.ForeColor = System.Drawing.Color.White;
            this.Language_label.Location = new System.Drawing.Point(563, 9);
            this.Language_label.Name = "Language_label";
            this.Language_label.Size = new System.Drawing.Size(64, 13);
            this.Language_label.TabIndex = 1;
            this.Language_label.Text = "Language: ";
            // 
            // Language_Chose
            // 
            this.Language_Chose.BackColor = System.Drawing.Color.Brown;
            this.Language_Chose.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Language_Chose.DropDownHeight = 100;
            this.Language_Chose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Language_Chose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Language_Chose.ForeColor = System.Drawing.Color.Black;
            this.Language_Chose.FormattingEnabled = true;
            this.Language_Chose.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Language_Chose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Language_Chose.IntegralHeight = false;
            this.Language_Chose.ItemHeight = 16;
            this.Language_Chose.Items.AddRange(new object[] {
            "English",
            "Français",
            "German",
            "Italiano",
            "中国"});
            this.Language_Chose.Location = new System.Drawing.Point(566, 25);
            this.Language_Chose.Name = "Language_Chose";
            this.Language_Chose.Size = new System.Drawing.Size(144, 22);
            this.Language_Chose.StartIndex = 0;
            this.Language_Chose.TabIndex = 0;
            this.Language_Chose.SelectedIndexChanged += new System.EventHandler(this.iTalk_ComboBox1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 368);
            this.Controls.Add(this.monoFlat_ThemeContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Launcher Options";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.monoFlat_ThemeContainer1.ResumeLayout(false);
            this.monoFlat_ThemeContainer1.PerformLayout();
            this.Group_Options.ResumeLayout(false);
            this.Group_UserName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer monoFlat_ThemeContainer1;
        private iTalk.iTalk_Label Language_label;
        private iTalk.iTalk_ComboBox Language_Chose;
        private MonoFlat.MonoFlat_Toggle Toggle_User;
        private MonoFlat.MonoFlat_Toggle Toggle_Options;
        private iTalk.iTalk_TextBox_Big TextBox_User;
        private System.Windows.Forms.GroupBox Group_UserName;
        private System.Windows.Forms.GroupBox Group_Options;
        private iTalk.iTalk_TextBox_Big TextBox_Options;
        private MonoFlat.MonoFlat_Button Close_Bouton;
        private System.ComponentModel.BackgroundWorker Change_Lang;


    }
}