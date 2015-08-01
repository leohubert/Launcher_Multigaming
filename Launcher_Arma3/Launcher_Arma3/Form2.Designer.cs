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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Change_Lang = new System.ComponentModel.BackgroundWorker();
            this.TaskForce_Install = new System.ComponentModel.BackgroundWorker();
            this.TeamSpeak = new System.Windows.Forms.FolderBrowserDialog();
            this.monoFlat_ThemeContainer1 = new MonoFlat.MonoFlat_ThemeContainer();
            this.Group_TaskForce = new System.Windows.Forms.GroupBox();
            this.Label_TaskForce = new Ambiance.Ambiance_Label();
            this.Progress_TaskForce = new PerplexProgressBar();
            this.Bouton_TaskForce = new Ambiance.Ambiance_Button_2();
            this.Groupe_Warning = new System.Windows.Forms.GroupBox();
            this.Warning_Label = new iTalk.iTalk_Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Bouton_Reset = new iTalk.iTalk_Button_1();
            this.Groups_OptionsArma = new System.Windows.Forms.GroupBox();
            this.Toggle_Sound = new MonoFlat.MonoFlat_Toggle();
            this.Volume_Number = new iTalk.iTalk_NotificationNumber();
            this.Label_Sound = new iTalk.iTalk_Label();
            this.TrackBar_Sound = new iTalk.iTalk_TrackBar();
            this.monoFlat_Separator1 = new MonoFlat.MonoFlat_Separator();
            this.Label_StartArma = new iTalk.iTalk_Label();
            this.Toggle_StartArma = new MonoFlat.MonoFlat_Toggle();
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
            this.Group_TaskForce.SuspendLayout();
            this.Groupe_Warning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Groups_OptionsArma.SuspendLayout();
            this.Group_Options.SuspendLayout();
            this.Group_UserName.SuspendLayout();
            this.SuspendLayout();
            // 
            // Change_Lang
            // 
            this.Change_Lang.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Change_Lang_DoWork);
            // 
            // TaskForce_Install
            // 
            this.TaskForce_Install.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TaskForce_Install_DoWork);
            this.TaskForce_Install.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Pont_Task);
            // 
            // TeamSpeak
            // 
            this.TeamSpeak.Description = "Choose your TeamSpeak 3 destination */* Choisissez la destination de votre TeamSp" +
    "eak 3";
            // 
            // monoFlat_ThemeContainer1
            // 
            this.monoFlat_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoFlat_ThemeContainer1.Controls.Add(this.Group_TaskForce);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Groupe_Warning);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Groups_OptionsArma);
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
            // Group_TaskForce
            // 
            this.Group_TaskForce.Controls.Add(this.Label_TaskForce);
            this.Group_TaskForce.Controls.Add(this.Progress_TaskForce);
            this.Group_TaskForce.Controls.Add(this.Bouton_TaskForce);
            this.Group_TaskForce.ForeColor = System.Drawing.Color.White;
            this.Group_TaskForce.Location = new System.Drawing.Point(432, 73);
            this.Group_TaskForce.Name = "Group_TaskForce";
            this.Group_TaskForce.Size = new System.Drawing.Size(278, 123);
            this.Group_TaskForce.TabIndex = 13;
            this.Group_TaskForce.TabStop = false;
            this.Group_TaskForce.Text = "TaskForce Radio";
            // 
            // Label_TaskForce
            // 
            this.Label_TaskForce.AutoSize = true;
            this.Label_TaskForce.BackColor = System.Drawing.Color.Transparent;
            this.Label_TaskForce.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Label_TaskForce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Label_TaskForce.Location = new System.Drawing.Point(2, 92);
            this.Label_TaskForce.Name = "Label_TaskForce";
            this.Label_TaskForce.Size = new System.Drawing.Size(68, 20);
            this.Label_TaskForce.TabIndex = 14;
            this.Label_TaskForce.Text = "Progress:";
            // 
            // Progress_TaskForce
            // 
            this.Progress_TaskForce.BackColor = System.Drawing.Color.Transparent;
            this.Progress_TaskForce.Location = new System.Drawing.Point(6, 61);
            this.Progress_TaskForce.Maximum = 100;
            this.Progress_TaskForce.Name = "Progress_TaskForce";
            this.Progress_TaskForce.ShowPercentage = false;
            this.Progress_TaskForce.Size = new System.Drawing.Size(266, 28);
            this.Progress_TaskForce.TabIndex = 13;
            this.Progress_TaskForce.Text = "perplexProgressBar1";
            this.Progress_TaskForce.Value = 0;
            // 
            // Bouton_TaskForce
            // 
            this.Bouton_TaskForce.BackColor = System.Drawing.Color.Transparent;
            this.Bouton_TaskForce.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Bouton_TaskForce.Image = null;
            this.Bouton_TaskForce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bouton_TaskForce.Location = new System.Drawing.Point(6, 21);
            this.Bouton_TaskForce.Name = "Bouton_TaskForce";
            this.Bouton_TaskForce.Size = new System.Drawing.Size(266, 30);
            this.Bouton_TaskForce.TabIndex = 12;
            this.Bouton_TaskForce.Text = "Install TaskForce";
            this.Bouton_TaskForce.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Bouton_TaskForce.Click += new System.EventHandler(this.Bouton_TaskForce_Click);
            // 
            // Groupe_Warning
            // 
            this.Groupe_Warning.Controls.Add(this.Warning_Label);
            this.Groupe_Warning.Controls.Add(this.pictureBox1);
            this.Groupe_Warning.Controls.Add(this.Bouton_Reset);
            this.Groupe_Warning.ForeColor = System.Drawing.Color.White;
            this.Groupe_Warning.Location = new System.Drawing.Point(432, 202);
            this.Groupe_Warning.Name = "Groupe_Warning";
            this.Groupe_Warning.Size = new System.Drawing.Size(278, 74);
            this.Groupe_Warning.TabIndex = 11;
            this.Groupe_Warning.TabStop = false;
            this.Groupe_Warning.Text = "Warning Zone";
            // 
            // Warning_Label
            // 
            this.Warning_Label.AutoSize = true;
            this.Warning_Label.BackColor = System.Drawing.Color.Transparent;
            this.Warning_Label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Warning_Label.ForeColor = System.Drawing.Color.Tomato;
            this.Warning_Label.Location = new System.Drawing.Point(6, 19);
            this.Warning_Label.Name = "Warning_Label";
            this.Warning_Label.Size = new System.Drawing.Size(175, 13);
            this.Warning_Label.TabIndex = 8;
            this.Warning_Label.Text = "/!\\ This button delete all mods /!\\";
            this.Warning_Label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(186, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Bouton_Reset
            // 
            this.Bouton_Reset.BackColor = System.Drawing.Color.Transparent;
            this.Bouton_Reset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bouton_Reset.Image = null;
            this.Bouton_Reset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bouton_Reset.Location = new System.Drawing.Point(6, 35);
            this.Bouton_Reset.Name = "Bouton_Reset";
            this.Bouton_Reset.Size = new System.Drawing.Size(175, 33);
            this.Bouton_Reset.TabIndex = 10;
            this.Bouton_Reset.Text = "Reset";
            this.Bouton_Reset.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Bouton_Reset.Click += new System.EventHandler(this.Bouton_Reset_Click);
            // 
            // Groups_OptionsArma
            // 
            this.Groups_OptionsArma.Controls.Add(this.Toggle_Sound);
            this.Groups_OptionsArma.Controls.Add(this.Volume_Number);
            this.Groups_OptionsArma.Controls.Add(this.Label_Sound);
            this.Groups_OptionsArma.Controls.Add(this.TrackBar_Sound);
            this.Groups_OptionsArma.Controls.Add(this.monoFlat_Separator1);
            this.Groups_OptionsArma.Controls.Add(this.Label_StartArma);
            this.Groups_OptionsArma.Controls.Add(this.Toggle_StartArma);
            this.Groups_OptionsArma.ForeColor = System.Drawing.Color.White;
            this.Groups_OptionsArma.Location = new System.Drawing.Point(12, 73);
            this.Groups_OptionsArma.Name = "Groups_OptionsArma";
            this.Groups_OptionsArma.Size = new System.Drawing.Size(414, 123);
            this.Groups_OptionsArma.TabIndex = 8;
            this.Groups_OptionsArma.TabStop = false;
            this.Groups_OptionsArma.Text = "Launcher Options";
            // 
            // Toggle_Sound
            // 
            this.Toggle_Sound.Location = new System.Drawing.Point(6, 84);
            this.Toggle_Sound.Name = "Toggle_Sound";
            this.Toggle_Sound.Size = new System.Drawing.Size(76, 33);
            this.Toggle_Sound.TabIndex = 14;
            this.Toggle_Sound.Text = "Toggle_Sound";
            this.Toggle_Sound.Toggled = false;
            this.Toggle_Sound.Type = MonoFlat.MonoFlat_Toggle._Type.CheckMark;
            this.Toggle_Sound.ToggledChanged += new MonoFlat.MonoFlat_Toggle.ToggledChangedEventHandler(this.monoFlat_Toggle1_ToggledChanged);
            // 
            // Volume_Number
            // 
            this.Volume_Number.Location = new System.Drawing.Point(245, 69);
            this.Volume_Number.Maximum = 99;
            this.Volume_Number.Name = "Volume_Number";
            this.Volume_Number.Size = new System.Drawing.Size(20, 20);
            this.Volume_Number.TabIndex = 13;
            this.Volume_Number.Text = "Volume_Number";
            this.Volume_Number.Value = 0;
            // 
            // Label_Sound
            // 
            this.Label_Sound.AutoSize = true;
            this.Label_Sound.BackColor = System.Drawing.Color.Transparent;
            this.Label_Sound.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Sound.ForeColor = System.Drawing.Color.White;
            this.Label_Sound.Location = new System.Drawing.Point(6, 57);
            this.Label_Sound.Name = "Label_Sound";
            this.Label_Sound.Size = new System.Drawing.Size(86, 15);
            this.Label_Sound.TabIndex = 12;
            this.Label_Sound.Text = "Sound Options";
            this.Label_Sound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TrackBar_Sound
            // 
            this.TrackBar_Sound.DrawHatch = true;
            this.TrackBar_Sound.DrawValueString = false;
            this.TrackBar_Sound.JumpToMouse = true;
            this.TrackBar_Sound.Location = new System.Drawing.Point(102, 95);
            this.TrackBar_Sound.Maximum = 100;
            this.TrackBar_Sound.Minimum = 0;
            this.TrackBar_Sound.MinimumSize = new System.Drawing.Size(37, 22);
            this.TrackBar_Sound.Name = "TrackBar_Sound";
            this.TrackBar_Sound.Size = new System.Drawing.Size(306, 22);
            this.TrackBar_Sound.TabIndex = 10;
            this.TrackBar_Sound.Text = "TrackBar_Sound";
            this.TrackBar_Sound.Value = 0;
            this.TrackBar_Sound.ValueColour = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TrackBar_Sound.ValueDivison = iTalk.iTalk_TrackBar.ValueDivisor.By1;
            this.TrackBar_Sound.ValueToSet = 0F;
            this.TrackBar_Sound.ValueChanged += new iTalk.iTalk_TrackBar.ValueChangedEventHandler(this.TackBar_Sound_ValueChanged);
            // 
            // monoFlat_Separator1
            // 
            this.monoFlat_Separator1.Location = new System.Drawing.Point(6, 61);
            this.monoFlat_Separator1.Name = "monoFlat_Separator1";
            this.monoFlat_Separator1.Size = new System.Drawing.Size(402, 11);
            this.monoFlat_Separator1.TabIndex = 6;
            this.monoFlat_Separator1.Text = "monoFlat_Separator1";
            // 
            // Label_StartArma
            // 
            this.Label_StartArma.AutoSize = true;
            this.Label_StartArma.BackColor = System.Drawing.Color.Transparent;
            this.Label_StartArma.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_StartArma.ForeColor = System.Drawing.Color.LightCoral;
            this.Label_StartArma.Location = new System.Drawing.Point(91, 31);
            this.Label_StartArma.Name = "Label_StartArma";
            this.Label_StartArma.Size = new System.Drawing.Size(213, 13);
            this.Label_StartArma.TabIndex = 5;
            this.Label_StartArma.Text = "Start Arma3 when download is finished.";
            this.Label_StartArma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Toggle_StartArma
            // 
            this.Toggle_StartArma.Location = new System.Drawing.Point(9, 21);
            this.Toggle_StartArma.Name = "Toggle_StartArma";
            this.Toggle_StartArma.Size = new System.Drawing.Size(76, 33);
            this.Toggle_StartArma.TabIndex = 4;
            this.Toggle_StartArma.Text = "Toggle_StartArma";
            this.Toggle_StartArma.Toggled = false;
            this.Toggle_StartArma.Type = MonoFlat.MonoFlat_Toggle._Type.CheckMark;
            this.Toggle_StartArma.ToggledChanged += new MonoFlat.MonoFlat_Toggle.ToggledChangedEventHandler(this.Toggle_StartArma_ToggledChanged);
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
            this.Group_Options.Text = "Arma3 Options";
            // 
            // TextBox_Options
            // 
            this.TextBox_Options.BackColor = System.Drawing.Color.Transparent;
            this.TextBox_Options.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TextBox_Options.ForeColor = System.Drawing.Color.DimGray;
            this.TextBox_Options.Image = null;
            this.TextBox_Options.Location = new System.Drawing.Point(89, 22);
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
            this.Toggle_Options.Location = new System.Drawing.Point(9, 30);
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
            this.Group_UserName.Location = new System.Drawing.Point(12, 202);
            this.Group_UserName.Name = "Group_UserName";
            this.Group_UserName.Size = new System.Drawing.Size(414, 74);
            this.Group_UserName.TabIndex = 7;
            this.Group_UserName.TabStop = false;
            this.Group_UserName.Text = "User Options";
            // 
            // TextBox_User
            // 
            this.TextBox_User.BackColor = System.Drawing.Color.Transparent;
            this.TextBox_User.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TextBox_User.ForeColor = System.Drawing.Color.DimGray;
            this.TextBox_User.Image = null;
            this.TextBox_User.Location = new System.Drawing.Point(88, 22);
            this.TextBox_User.MaxLength = 32767;
            this.TextBox_User.Multiline = false;
            this.TextBox_User.Name = "TextBox_User";
            this.TextBox_User.ReadOnly = false;
            this.TextBox_User.Size = new System.Drawing.Size(320, 41);
            this.TextBox_User.TabIndex = 5;
            this.TextBox_User.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBox_User.UseSystemPasswordChar = false;
            this.TextBox_User.TextChanged += new System.EventHandler(this.UserName_ChangeText);
            // 
            // Toggle_User
            // 
            this.Toggle_User.Location = new System.Drawing.Point(6, 30);
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
            this.Group_TaskForce.ResumeLayout(false);
            this.Group_TaskForce.PerformLayout();
            this.Groupe_Warning.ResumeLayout(false);
            this.Groupe_Warning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Groups_OptionsArma.ResumeLayout(false);
            this.Groups_OptionsArma.PerformLayout();
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
        private System.Windows.Forms.GroupBox Groups_OptionsArma;
        private MonoFlat.MonoFlat_Toggle Toggle_StartArma;
        private iTalk.iTalk_Label Label_StartArma;
        private MonoFlat.MonoFlat_Separator monoFlat_Separator1;
        private iTalk.iTalk_TrackBar TrackBar_Sound;
        private iTalk.iTalk_Label Warning_Label;
        private iTalk.iTalk_NotificationNumber Volume_Number;
        private iTalk.iTalk_Label Label_Sound;
        private MonoFlat.MonoFlat_Toggle Toggle_Sound;
        private iTalk.iTalk_Button_1 Bouton_Reset;
        private System.Windows.Forms.GroupBox Groupe_Warning;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox Group_TaskForce;
        private Ambiance.Ambiance_Label Label_TaskForce;
        private PerplexProgressBar Progress_TaskForce;
        private Ambiance.Ambiance_Button_2 Bouton_TaskForce;
        private System.ComponentModel.BackgroundWorker TaskForce_Install;
        private System.Windows.Forms.FolderBrowserDialog TeamSpeak;


    }
}