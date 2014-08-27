namespace SI_GUI
{
    partial class AboutUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        #region Licence
        /*This file is part of the project "Reisisoft Server Install GUI",
         * which is licenced under LGPL v3+. You may find a copy in the source,
         * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */
        #endregion
        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUI));
            this.about = new System.Windows.Forms.TextBox();
            this.lang_chooser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ga_tracking = new System.Windows.Forms.CheckBox();
            this.folder = new System.Windows.Forms.FolderBrowserDialog();
            this.B_open_folder = new System.Windows.Forms.Button();
            this.folder_save = new System.Windows.Forms.TextBox();
            this.cb_advancedFilenames = new System.Windows.Forms.CheckBox();
            this.bOk = new System.Windows.Forms.Button();
            this.cb_bs_autoedit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // about
            // 
            this.about.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.about.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.about.Font = new System.Drawing.Font("Liberation Sans", 11.25F);
            this.about.Location = new System.Drawing.Point(13, 103);
            this.about.Multiline = true;
            this.about.Name = "about";
            this.about.ReadOnly = true;
            this.about.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.about.Size = new System.Drawing.Size(413, 297);
            this.about.TabIndex = 20;
            // 
            // lang_chooser
            // 
            this.lang_chooser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lang_chooser.FormattingEnabled = true;
            this.lang_chooser.Location = new System.Drawing.Point(355, 495);
            this.lang_chooser.Name = "lang_chooser";
            this.lang_chooser.Size = new System.Drawing.Size(71, 21);
            this.lang_chooser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Change language:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ga_tracking
            // 
            this.ga_tracking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ga_tracking.AutoSize = true;
            this.ga_tracking.Location = new System.Drawing.Point(15, 478);
            this.ga_tracking.Name = "ga_tracking";
            this.ga_tracking.Size = new System.Drawing.Size(92, 17);
            this.ga_tracking.TabIndex = 2;
            this.ga_tracking.Text = "Allow tracking";
            this.ga_tracking.UseVisualStyleBackColor = true;
            // 
            // folder
            // 
            this.folder.RootFolder = System.Environment.SpecialFolder.Templates;
            // 
            // B_open_folder
            // 
            this.B_open_folder.Location = new System.Drawing.Point(12, 406);
            this.B_open_folder.Name = "B_open_folder";
            this.B_open_folder.Size = new System.Drawing.Size(190, 23);
            this.B_open_folder.TabIndex = 1;
            this.B_open_folder.Text = "Select download folder";
            this.B_open_folder.UseVisualStyleBackColor = true;
            this.B_open_folder.Click += new System.EventHandler(this.B_open_folder_Click);
            // 
            // folder_save
            // 
            this.folder_save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folder_save.Location = new System.Drawing.Point(208, 409);
            this.folder_save.Name = "folder_save";
            this.folder_save.ReadOnly = true;
            this.folder_save.Size = new System.Drawing.Size(218, 20);
            this.folder_save.TabIndex = 9;
            // 
            // cb_advancedFilenames
            // 
            this.cb_advancedFilenames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_advancedFilenames.AutoSize = true;
            this.cb_advancedFilenames.Location = new System.Drawing.Point(15, 455);
            this.cb_advancedFilenames.Name = "cb_advancedFilenames";
            this.cb_advancedFilenames.Size = new System.Drawing.Size(137, 17);
            this.cb_advancedFilenames.TabIndex = 21;
            this.cb_advancedFilenames.Text = "Advanced file renaming";
            this.cb_advancedFilenames.UseVisualStyleBackColor = true;
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.Location = new System.Drawing.Point(13, 521);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(414, 23);
            this.bOk.TabIndex = 22;
            this.bOk.Text = "Okay";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // cb_bs_autoedit
            // 
            this.cb_bs_autoedit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_bs_autoedit.AutoSize = true;
            this.cb_bs_autoedit.Location = new System.Drawing.Point(15, 432);
            this.cb_bs_autoedit.Name = "cb_bs_autoedit";
            this.cb_bs_autoedit.Size = new System.Drawing.Size(128, 17);
            this.cb_bs_autoedit.TabIndex = 23;
            this.cb_bs_autoedit.Text = "Auto-edit bootstrap.ini";
            this.cb_bs_autoedit.UseVisualStyleBackColor = true;
            // 
            // AboutUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 551);
            this.ControlBox = false;
            this.Controls.Add(this.cb_bs_autoedit);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.cb_advancedFilenames);
            this.Controls.Add(this.folder_save);
            this.Controls.Add(this.B_open_folder);
            this.Controls.Add(this.ga_tracking);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lang_chooser);
            this.Controls.Add(this.about);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(454, 589);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(454, 589);
            this.Name = "AboutUI";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox about;
        private System.Windows.Forms.ComboBox lang_chooser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ga_tracking;
        private System.Windows.Forms.FolderBrowserDialog folder;
        private System.Windows.Forms.Button B_open_folder;
        private System.Windows.Forms.TextBox folder_save;
        private System.Windows.Forms.CheckBox cb_advancedFilenames;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.CheckBox cb_bs_autoedit;

    }
}