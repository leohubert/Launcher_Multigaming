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
            this.change_language = new System.ComponentModel.BackgroundWorker();
            this.monoFlat_ThemeContainer1 = new MonoFlat.MonoFlat_ThemeContainer();
            this.iTalk_Icon_Tick1 = new iTalk.iTalk_Icon_Tick();
            this.Language_label = new iTalk.iTalk_Label();
            this.Language_Chose = new iTalk.iTalk_ComboBox();
            this.monoFlat_ThemeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monoFlat_ThemeContainer1
            // 
            this.monoFlat_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoFlat_ThemeContainer1.Controls.Add(this.iTalk_Icon_Tick1);
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
            // iTalk_Icon_Tick1
            // 
            this.iTalk_Icon_Tick1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.iTalk_Icon_Tick1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iTalk_Icon_Tick1.ForeColor = System.Drawing.Color.Firebrick;
            this.iTalk_Icon_Tick1.Location = new System.Drawing.Point(673, 323);
            this.iTalk_Icon_Tick1.Name = "iTalk_Icon_Tick1";
            this.iTalk_Icon_Tick1.Size = new System.Drawing.Size(33, 33);
            this.iTalk_Icon_Tick1.TabIndex = 2;
            this.iTalk_Icon_Tick1.Text = "iTalk_Icon_Tick1";
            this.iTalk_Icon_Tick1.Click += new System.EventHandler(this.iTalk_Icon_Tick1_Click);
            // 
            // Language_label
            // 
            this.Language_label.AutoSize = true;
            this.Language_label.BackColor = System.Drawing.Color.Transparent;
            this.Language_label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Language_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.Language_label.Location = new System.Drawing.Point(12, 70);
            this.Language_label.Name = "Language_label";
            this.Language_label.Size = new System.Drawing.Size(64, 13);
            this.Language_label.TabIndex = 1;
            this.Language_label.Text = "Language: ";
            // 
            // Language_Chose
            // 
            this.Language_Chose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Language_Chose.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Language_Chose.DropDownHeight = 100;
            this.Language_Chose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Language_Chose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Language_Chose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.Language_Chose.FormattingEnabled = true;
            this.Language_Chose.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Language_Chose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Language_Chose.IntegralHeight = false;
            this.Language_Chose.ItemHeight = 16;
            this.Language_Chose.Items.AddRange(new object[] {
            "English",
            "Français",
            "Allemand"});
            this.Language_Chose.Location = new System.Drawing.Point(15, 86);
            this.Language_Chose.Name = "Language_Chose";
            this.Language_Chose.Size = new System.Drawing.Size(303, 22);
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
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer monoFlat_ThemeContainer1;
        private iTalk.iTalk_Label Language_label;
        private iTalk.iTalk_ComboBox Language_Chose;
        private iTalk.iTalk_Icon_Tick iTalk_Icon_Tick1;
        private System.ComponentModel.BackgroundWorker change_language;


    }
}