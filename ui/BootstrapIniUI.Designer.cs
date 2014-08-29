namespace SI_GUI.ui
{
    partial class BootstrapIniUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BootstrapIniUI));
            this.gb_bootstrap = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.save_file = new System.Windows.Forms.Button();
            this.bootinipath = new System.Windows.Forms.TextBox();
            this.userinstallation = new System.Windows.Forms.TextBox();
            this.bootstrap_text = new System.Windows.Forms.TextBox();
            this.open_bootstrap = new System.Windows.Forms.OpenFileDialog();
            this.gb_bootstrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_bootstrap
            // 
            this.gb_bootstrap.Controls.Add(this.button4);
            this.gb_bootstrap.Controls.Add(this.save_file);
            this.gb_bootstrap.Controls.Add(this.bootinipath);
            this.gb_bootstrap.Controls.Add(this.userinstallation);
            this.gb_bootstrap.Controls.Add(this.bootstrap_text);
            this.gb_bootstrap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gb_bootstrap.Location = new System.Drawing.Point(12, 12);
            this.gb_bootstrap.Name = "gb_bootstrap";
            this.gb_bootstrap.Size = new System.Drawing.Size(404, 441);
            this.gb_bootstrap.TabIndex = 1;
            this.gb_bootstrap.TabStop = false;
            this.gb_bootstrap.Text = "Edit bootdtrap.ini";
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(5, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Open bootstap.ini";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.open_bootstrap_Click);
            // 
            // save_file
            // 
            this.save_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save_file.Enabled = false;
            this.save_file.ForeColor = System.Drawing.SystemColors.ControlText;
            this.save_file.Location = new System.Drawing.Point(198, 19);
            this.save_file.Name = "save_file";
            this.save_file.Size = new System.Drawing.Size(200, 23);
            this.save_file.TabIndex = 17;
            this.save_file.Text = "Save bootstap.ini";
            this.save_file.UseVisualStyleBackColor = true;
            this.save_file.Click += new System.EventHandler(this.save_bootstrap);
            // 
            // bootinipath
            // 
            this.bootinipath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bootinipath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bootinipath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bootinipath.Location = new System.Drawing.Point(6, 48);
            this.bootinipath.Name = "bootinipath";
            this.bootinipath.ReadOnly = true;
            this.bootinipath.Size = new System.Drawing.Size(393, 20);
            this.bootinipath.TabIndex = 0;
            // 
            // userinstallation
            // 
            this.userinstallation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userinstallation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userinstallation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userinstallation.Location = new System.Drawing.Point(5, 415);
            this.userinstallation.Name = "userinstallation";
            this.userinstallation.ReadOnly = true;
            this.userinstallation.Size = new System.Drawing.Size(393, 20);
            this.userinstallation.TabIndex = 0;
            this.userinstallation.Text = "UserInstallation=$ORIGIN/..";
            // 
            // bootstrap_text
            // 
            this.bootstrap_text.CausesValidation = false;
            this.bootstrap_text.Location = new System.Drawing.Point(6, 74);
            this.bootstrap_text.Multiline = true;
            this.bootstrap_text.Name = "bootstrap_text";
            this.bootstrap_text.Size = new System.Drawing.Size(386, 331);
            this.bootstrap_text.TabIndex = 18;
            // 
            // open_bootstrap
            // 
            this.open_bootstrap.FileName = "bootstrap.ini";
            this.open_bootstrap.Filter = "LibreOffice bootstrap.ini file | bootstrap.ini";
            this.open_bootstrap.Title = "Open bootstrap.ini";
            // 
            // BootstrapIniUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 469);
            this.Controls.Add(this.gb_bootstrap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BootstrapIniUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BootstrapIniUI";
            this.gb_bootstrap.ResumeLayout(false);
            this.gb_bootstrap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_bootstrap;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button save_file;
        private System.Windows.Forms.TextBox bootinipath;
        private System.Windows.Forms.TextBox userinstallation;
        private System.Windows.Forms.TextBox bootstrap_text;
        private System.Windows.Forms.OpenFileDialog open_bootstrap;

    }
}