namespace SI_GUI
{
    partial class MainUI
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
                if (piwik != null)
                    piwik.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.openfile = new System.Windows.Forms.OpenFileDialog();
            this.b_open_libo_installer = new System.Windows.Forms.Button();
            this.path_main = new System.Windows.Forms.TextBox();
            this.path_help = new System.Windows.Forms.TextBox();
            this.b_open_libo_help = new System.Windows.Forms.Button();
            this.openfile2 = new System.Windows.Forms.OpenFileDialog();
            this.start_install = new System.Windows.Forms.Button();
            this.wheretoinstall = new System.Windows.Forms.FolderBrowserDialog();
            this.b_configInstalldir = new System.Windows.Forms.Button();
            this.path_installdir = new System.Windows.Forms.TextBox();
            this.cb_subfolder = new System.Windows.Forms.CheckBox();
            this.subfolder = new System.Windows.Forms.TextBox();
            this.give_message = new System.Windows.Forms.NotifyIcon(this.components);
            this.path_to_exe = new System.Windows.Forms.TextBox();
            this.tb_version = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.create_lnk = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.m_about = new System.Windows.Forms.ToolStripMenuItem();
            this.m_man = new System.Windows.Forms.ToolStripMenuItem();
            this.m_help = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_create_lnk = new System.Windows.Forms.GroupBox();
            this.gb_download = new System.Windows.Forms.GroupBox();
            this.clb_downloadSelector = new System.Windows.Forms.CheckedListBox();
            this.choose_lang = new System.Windows.Forms.ComboBox();
            this.cancel_dl = new System.Windows.Forms.Button();
            this.choose_lang_label = new System.Windows.Forms.Label();
            this.start_dl = new System.Windows.Forms.Button();
            this.update_versions = new System.Windows.Forms.Button();
            this.percent = new System.Windows.Forms.Label();
            this.dl_versions = new System.Windows.Forms.ComboBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.gb_installation = new System.Windows.Forms.GroupBox();
            this.go_pathSDK = new System.Windows.Forms.Button();
            this.resetPathSDK = new System.Windows.Forms.Button();
            this.b_open_libo_sdk = new System.Windows.Forms.Button();
            this.path_sdk = new System.Windows.Forms.TextBox();
            this.go_patHelp = new System.Windows.Forms.Button();
            this.go_pathMain = new System.Windows.Forms.Button();
            this.delete_pathHelp = new System.Windows.Forms.Button();
            this.reset_pathMain = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.LinkLabel();
            this.openfile3 = new System.Windows.Forms.OpenFileDialog();
            this.show_gb_bs = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.gb_create_lnk.SuspendLayout();
            this.gb_download.SuspendLayout();
            this.gb_installation.SuspendLayout();
            this.SuspendLayout();
            // 
            // openfile
            // 
            this.openfile.DefaultExt = "msi";
            this.openfile.Filter = "LibreOffice installation file|Lib*Win_x86*.msi;*LibO-Dev*Win_x86*.msi;libreoffice" +
    "*.msi;master~*LibreOffice*Win*.msi";
            this.openfile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // b_open_libo_installer
            // 
            this.b_open_libo_installer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_open_libo_installer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_open_libo_installer.Location = new System.Drawing.Point(7, 15);
            this.b_open_libo_installer.Name = "b_open_libo_installer";
            this.b_open_libo_installer.Size = new System.Drawing.Size(198, 23);
            this.b_open_libo_installer.TabIndex = 7;
            this.b_open_libo_installer.Text = "Open LibreOffice installer";
            this.b_open_libo_installer.UseVisualStyleBackColor = true;
            this.b_open_libo_installer.Click += new System.EventHandler(this.open_installer_Click);
            // 
            // path_main
            // 
            this.path_main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_main.BackColor = System.Drawing.Color.WhiteSmoke;
            this.path_main.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_main.Location = new System.Drawing.Point(210, 15);
            this.path_main.Name = "path_main";
            this.path_main.Size = new System.Drawing.Size(111, 20);
            this.path_main.TabIndex = 8;
            this.path_main.TextChanged += new System.EventHandler(this.validate_filename);
            this.path_main.Validating += new System.ComponentModel.CancelEventHandler(this.checkFileExists);
            // 
            // path_help
            // 
            this.path_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_help.BackColor = System.Drawing.Color.WhiteSmoke;
            this.path_help.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_help.Location = new System.Drawing.Point(210, 49);
            this.path_help.Name = "path_help";
            this.path_help.Size = new System.Drawing.Size(111, 20);
            this.path_help.TabIndex = 10;
            this.path_help.TextChanged += new System.EventHandler(this.validate_filename);
            this.path_help.Validating += new System.ComponentModel.CancelEventHandler(this.checkFileExists);
            // 
            // b_open_libo_help
            // 
            this.b_open_libo_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_open_libo_help.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_open_libo_help.Location = new System.Drawing.Point(6, 47);
            this.b_open_libo_help.Name = "b_open_libo_help";
            this.b_open_libo_help.Size = new System.Drawing.Size(199, 23);
            this.b_open_libo_help.TabIndex = 9;
            this.b_open_libo_help.Text = "Open LibreOffice help";
            this.b_open_libo_help.UseVisualStyleBackColor = true;
            this.b_open_libo_help.Click += new System.EventHandler(this.openLibohelp);
            // 
            // openfile2
            // 
            this.openfile2.DefaultExt = "msi";
            this.openfile2.Filter = "LibreOffice help installation file | *Win_x86_helppack_*.msi";
            this.openfile2.FileOk += new System.ComponentModel.CancelEventHandler(this.openfile2_FileOk);
            // 
            // start_install
            // 
            this.start_install.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.start_install.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.start_install.ForeColor = System.Drawing.SystemColors.ControlText;
            this.start_install.Location = new System.Drawing.Point(6, 182);
            this.start_install.Name = "start_install";
            this.start_install.Size = new System.Drawing.Size(391, 57);
            this.start_install.TabIndex = 15;
            this.start_install.Text = "Start installation";
            this.start_install.UseVisualStyleBackColor = true;
            this.start_install.Click += new System.EventHandler(this.start_install_Click);
            // 
            // wheretoinstall
            // 
            this.wheretoinstall.Description = "Choose installation directory";
            this.wheretoinstall.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // b_configInstalldir
            // 
            this.b_configInstalldir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_configInstalldir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_configInstalldir.Location = new System.Drawing.Point(5, 104);
            this.b_configInstalldir.Name = "b_configInstalldir";
            this.b_configInstalldir.Size = new System.Drawing.Size(199, 23);
            this.b_configInstalldir.TabIndex = 11;
            this.b_configInstalldir.Text = "Configure installation directory";
            this.b_configInstalldir.UseVisualStyleBackColor = true;
            this.b_configInstalldir.Click += new System.EventHandler(this.config_installdir);
            // 
            // path_installdir
            // 
            this.path_installdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_installdir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.path_installdir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_installdir.Location = new System.Drawing.Point(209, 107);
            this.path_installdir.Name = "path_installdir";
            this.path_installdir.Size = new System.Drawing.Size(192, 20);
            this.path_installdir.TabIndex = 12;
            this.path_installdir.Validating += new System.ComponentModel.CancelEventHandler(this.validateInstalldir);
            // 
            // cb_subfolder
            // 
            this.cb_subfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_subfolder.AutoSize = true;
            this.cb_subfolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb_subfolder.Location = new System.Drawing.Point(5, 133);
            this.cb_subfolder.Name = "cb_subfolder";
            this.cb_subfolder.Size = new System.Drawing.Size(348, 17);
            this.cb_subfolder.TabIndex = 13;
            this.cb_subfolder.Text = "Should a subfolder be created automatically? Name of the subfolder:";
            this.cb_subfolder.UseVisualStyleBackColor = true;
            // 
            // subfolder
            // 
            this.subfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.subfolder.BackColor = System.Drawing.Color.White;
            this.subfolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.subfolder.Location = new System.Drawing.Point(6, 156);
            this.subfolder.Name = "subfolder";
            this.subfolder.Size = new System.Drawing.Size(391, 20);
            this.subfolder.TabIndex = 14;
            // 
            // give_message
            // 
            this.give_message.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.give_message.Icon = ((System.Drawing.Icon)(resources.GetObject("give_message.Icon")));
            this.give_message.Text = "Libreoffice Server Install GUI";
            this.give_message.Visible = true;
            // 
            // path_to_exe
            // 
            this.path_to_exe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.path_to_exe.BackColor = System.Drawing.Color.WhiteSmoke;
            this.path_to_exe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_to_exe.Location = new System.Drawing.Point(5, 16);
            this.path_to_exe.Name = "path_to_exe";
            this.path_to_exe.ReadOnly = true;
            this.path_to_exe.Size = new System.Drawing.Size(181, 20);
            this.path_to_exe.TabIndex = 0;
            // 
            // tb_version
            // 
            this.tb_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_version.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tb_version.Location = new System.Drawing.Point(243, 16);
            this.tb_version.Name = "tb_version";
            this.tb_version.Size = new System.Drawing.Size(154, 20);
            this.tb_version.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version:";
            // 
            // create_lnk
            // 
            this.create_lnk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.create_lnk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_lnk.Location = new System.Drawing.Point(6, 51);
            this.create_lnk.Name = "create_lnk";
            this.create_lnk.Size = new System.Drawing.Size(392, 24);
            this.create_lnk.TabIndex = 20;
            this.create_lnk.Text = "Create shortcut";
            this.create_lnk.UseVisualStyleBackColor = true;
            this.create_lnk.Click += new System.EventHandler(this.create_ink_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_about,
            this.m_man,
            this.m_help});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(435, 24);
            this.menu.TabIndex = 37;
            this.menu.Text = "menuStrip1";
            // 
            // m_about
            // 
            this.m_about.Name = "m_about";
            this.m_about.Size = new System.Drawing.Size(105, 20);
            this.m_about.Text = "About / &Settings";
            this.m_about.Click += new System.EventHandler(this.m_about_Click);
            // 
            // m_man
            // 
            this.m_man.Name = "m_man";
            this.m_man.Size = new System.Drawing.Size(66, 20);
            this.m_man.Text = "&Manager";
            this.m_man.Click += new System.EventHandler(this.m_man_Click);
            // 
            // m_help
            // 
            this.m_help.Name = "m_help";
            this.m_help.Size = new System.Drawing.Size(44, 20);
            this.m_help.Text = "&Help";
            this.m_help.Click += new System.EventHandler(this.m_help_Click);
            // 
            // gb_create_lnk
            // 
            this.gb_create_lnk.Controls.Add(this.path_to_exe);
            this.gb_create_lnk.Controls.Add(this.create_lnk);
            this.gb_create_lnk.Controls.Add(this.tb_version);
            this.gb_create_lnk.Controls.Add(this.label1);
            this.gb_create_lnk.Location = new System.Drawing.Point(13, 438);
            this.gb_create_lnk.Name = "gb_create_lnk";
            this.gb_create_lnk.Size = new System.Drawing.Size(404, 81);
            this.gb_create_lnk.TabIndex = 0;
            this.gb_create_lnk.TabStop = false;
            this.gb_create_lnk.Text = "Create shortcut";
            // 
            // gb_download
            // 
            this.gb_download.Controls.Add(this.clb_downloadSelector);
            this.gb_download.Controls.Add(this.choose_lang);
            this.gb_download.Controls.Add(this.cancel_dl);
            this.gb_download.Controls.Add(this.choose_lang_label);
            this.gb_download.Controls.Add(this.start_dl);
            this.gb_download.Controls.Add(this.update_versions);
            this.gb_download.Controls.Add(this.percent);
            this.gb_download.Controls.Add(this.dl_versions);
            this.gb_download.Controls.Add(this.labelProgress);
            this.gb_download.Controls.Add(this.progressBar);
            this.gb_download.Location = new System.Drawing.Point(18, 27);
            this.gb_download.Name = "gb_download";
            this.gb_download.Size = new System.Drawing.Size(399, 147);
            this.gb_download.TabIndex = 0;
            this.gb_download.TabStop = false;
            this.gb_download.Text = "Download";
            // 
            // clb_downloadSelector
            // 
            this.clb_downloadSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_downloadSelector.BackColor = System.Drawing.SystemColors.Control;
            this.clb_downloadSelector.CheckOnClick = true;
            this.clb_downloadSelector.FormattingEnabled = true;
            this.clb_downloadSelector.Items.AddRange(new object[] {
            "Main",
            "Help",
            "SDK"});
            this.clb_downloadSelector.Location = new System.Drawing.Point(262, 24);
            this.clb_downloadSelector.Name = "clb_downloadSelector";
            this.clb_downloadSelector.Size = new System.Drawing.Size(131, 49);
            this.clb_downloadSelector.TabIndex = 21;
            this.clb_downloadSelector.SelectedValueChanged += new System.EventHandler(this.enableDLbutton);
            // 
            // choose_lang
            // 
            this.choose_lang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.choose_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.choose_lang.FormattingEnabled = true;
            this.choose_lang.Location = new System.Drawing.Point(118, 57);
            this.choose_lang.Name = "choose_lang";
            this.choose_lang.Size = new System.Drawing.Size(138, 21);
            this.choose_lang.TabIndex = 5;
            // 
            // cancel_dl
            // 
            this.cancel_dl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_dl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_dl.ForeColor = System.Drawing.Color.Red;
            this.cancel_dl.Location = new System.Drawing.Point(520, 44);
            this.cancel_dl.Name = "cancel_dl";
            this.cancel_dl.Size = new System.Drawing.Size(26, 23);
            this.cancel_dl.TabIndex = 20;
            this.cancel_dl.Text = "X";
            this.cancel_dl.UseVisualStyleBackColor = true;
            this.cancel_dl.Click += new System.EventHandler(this.cancel_dl_Click);
            // 
            // choose_lang_label
            // 
            this.choose_lang_label.AutoSize = true;
            this.choose_lang_label.Location = new System.Drawing.Point(6, 60);
            this.choose_lang_label.Name = "choose_lang_label";
            this.choose_lang_label.Size = new System.Drawing.Size(87, 13);
            this.choose_lang_label.TabIndex = 0;
            this.choose_lang_label.Text = "Language (help):";
            // 
            // start_dl
            // 
            this.start_dl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_dl.AutoEllipsis = true;
            this.start_dl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_dl.Location = new System.Drawing.Point(9, 119);
            this.start_dl.Name = "start_dl";
            this.start_dl.Size = new System.Drawing.Size(383, 21);
            this.start_dl.TabIndex = 6;
            this.start_dl.Text = "Begin download";
            this.start_dl.UseVisualStyleBackColor = true;
            this.start_dl.Click += new System.EventHandler(this.start_dl_Click);
            // 
            // update_versions
            // 
            this.update_versions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.update_versions.Location = new System.Drawing.Point(117, 20);
            this.update_versions.Name = "update_versions";
            this.update_versions.Size = new System.Drawing.Size(139, 23);
            this.update_versions.TabIndex = 2;
            this.update_versions.Text = "Update list of versions";
            this.update_versions.UseVisualStyleBackColor = true;
            this.update_versions.Click += new System.EventHandler(this.update_versions_Click);
            // 
            // percent
            // 
            this.percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.percent.AutoSize = true;
            this.percent.BackColor = System.Drawing.Color.Transparent;
            this.percent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.percent.Location = new System.Drawing.Point(552, 49);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(45, 13);
            this.percent.TabIndex = 0;
            this.percent.Text = "12,34 %";
            this.percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dl_versions
            // 
            this.dl_versions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dl_versions.DropDownWidth = 130;
            this.dl_versions.FormattingEnabled = true;
            this.dl_versions.IntegralHeight = false;
            this.dl_versions.Location = new System.Drawing.Point(7, 20);
            this.dl_versions.MaxDropDownItems = 20;
            this.dl_versions.Name = "dl_versions";
            this.dl_versions.Size = new System.Drawing.Size(104, 21);
            this.dl_versions.TabIndex = 1;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelProgress.Location = new System.Drawing.Point(6, 93);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(51, 13);
            this.labelProgress.TabIndex = 0;
            this.labelProgress.Text = "Progress:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(63, 89);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(329, 20);
            this.progressBar.TabIndex = 0;
            // 
            // gb_installation
            // 
            this.gb_installation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_installation.Controls.Add(this.go_pathSDK);
            this.gb_installation.Controls.Add(this.resetPathSDK);
            this.gb_installation.Controls.Add(this.b_open_libo_sdk);
            this.gb_installation.Controls.Add(this.path_sdk);
            this.gb_installation.Controls.Add(this.go_patHelp);
            this.gb_installation.Controls.Add(this.go_pathMain);
            this.gb_installation.Controls.Add(this.delete_pathHelp);
            this.gb_installation.Controls.Add(this.reset_pathMain);
            this.gb_installation.Controls.Add(this.start_install);
            this.gb_installation.Controls.Add(this.b_open_libo_installer);
            this.gb_installation.Controls.Add(this.path_main);
            this.gb_installation.Controls.Add(this.b_open_libo_help);
            this.gb_installation.Controls.Add(this.subfolder);
            this.gb_installation.Controls.Add(this.path_help);
            this.gb_installation.Controls.Add(this.cb_subfolder);
            this.gb_installation.Controls.Add(this.b_configInstalldir);
            this.gb_installation.Controls.Add(this.path_installdir);
            this.gb_installation.Location = new System.Drawing.Point(14, 180);
            this.gb_installation.Name = "gb_installation";
            this.gb_installation.Size = new System.Drawing.Size(403, 247);
            this.gb_installation.TabIndex = 0;
            this.gb_installation.TabStop = false;
            this.gb_installation.Text = "Parallel installation";
            // 
            // go_pathSDK
            // 
            this.go_pathSDK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.go_pathSDK.Enabled = false;
            this.go_pathSDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.go_pathSDK.ForeColor = System.Drawing.Color.Green;
            this.go_pathSDK.Location = new System.Drawing.Point(326, 75);
            this.go_pathSDK.Name = "go_pathSDK";
            this.go_pathSDK.Size = new System.Drawing.Size(38, 23);
            this.go_pathSDK.TabIndex = 23;
            this.go_pathSDK.Text = "GO!";
            this.go_pathSDK.UseVisualStyleBackColor = true;
            // 
            // resetPathSDK
            // 
            this.resetPathSDK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetPathSDK.Enabled = false;
            this.resetPathSDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPathSDK.ForeColor = System.Drawing.Color.Red;
            this.resetPathSDK.Location = new System.Drawing.Point(370, 75);
            this.resetPathSDK.Name = "resetPathSDK";
            this.resetPathSDK.Size = new System.Drawing.Size(26, 23);
            this.resetPathSDK.TabIndex = 22;
            this.resetPathSDK.Text = "X";
            this.resetPathSDK.UseVisualStyleBackColor = true;
            this.resetPathSDK.Click += new System.EventHandler(this.resetPathSDK_Click);
            // 
            // b_open_libo_sdk
            // 
            this.b_open_libo_sdk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_open_libo_sdk.Enabled = false;
            this.b_open_libo_sdk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_open_libo_sdk.Location = new System.Drawing.Point(5, 75);
            this.b_open_libo_sdk.Name = "b_open_libo_sdk";
            this.b_open_libo_sdk.Size = new System.Drawing.Size(199, 23);
            this.b_open_libo_sdk.TabIndex = 20;
            this.b_open_libo_sdk.Text = "Open LibreOffice SDK";
            this.b_open_libo_sdk.UseVisualStyleBackColor = true;
            this.b_open_libo_sdk.Click += new System.EventHandler(this.b_open_libo_sdk_Click);
            // 
            // path_sdk
            // 
            this.path_sdk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_sdk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.path_sdk.Enabled = false;
            this.path_sdk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_sdk.Location = new System.Drawing.Point(209, 77);
            this.path_sdk.Name = "path_sdk";
            this.path_sdk.Size = new System.Drawing.Size(111, 20);
            this.path_sdk.TabIndex = 21;
            // 
            // go_patHelp
            // 
            this.go_patHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.go_patHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.go_patHelp.ForeColor = System.Drawing.Color.Green;
            this.go_patHelp.Location = new System.Drawing.Point(327, 47);
            this.go_patHelp.Name = "go_patHelp";
            this.go_patHelp.Size = new System.Drawing.Size(38, 23);
            this.go_patHelp.TabIndex = 19;
            this.go_patHelp.Text = "GO!";
            this.go_patHelp.UseVisualStyleBackColor = true;
            this.go_patHelp.Click += new System.EventHandler(this.go_pathhelp_Click);
            // 
            // go_pathMain
            // 
            this.go_pathMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.go_pathMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.go_pathMain.ForeColor = System.Drawing.Color.Green;
            this.go_pathMain.Location = new System.Drawing.Point(327, 15);
            this.go_pathMain.Name = "go_pathMain";
            this.go_pathMain.Size = new System.Drawing.Size(38, 23);
            this.go_pathMain.TabIndex = 18;
            this.go_pathMain.Text = "GO!";
            this.go_pathMain.UseVisualStyleBackColor = true;
            this.go_pathMain.Click += new System.EventHandler(this.go_pathMain_Click);
            // 
            // delete_pathHelp
            // 
            this.delete_pathHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delete_pathHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_pathHelp.ForeColor = System.Drawing.Color.Red;
            this.delete_pathHelp.Location = new System.Drawing.Point(371, 47);
            this.delete_pathHelp.Name = "delete_pathHelp";
            this.delete_pathHelp.Size = new System.Drawing.Size(26, 23);
            this.delete_pathHelp.TabIndex = 17;
            this.delete_pathHelp.Text = "X";
            this.delete_pathHelp.UseVisualStyleBackColor = true;
            this.delete_pathHelp.Click += new System.EventHandler(this.delete_pathHelp_Click);
            // 
            // reset_pathMain
            // 
            this.reset_pathMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reset_pathMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_pathMain.ForeColor = System.Drawing.Color.Red;
            this.reset_pathMain.Location = new System.Drawing.Point(371, 15);
            this.reset_pathMain.Name = "reset_pathMain";
            this.reset_pathMain.Size = new System.Drawing.Size(26, 23);
            this.reset_pathMain.TabIndex = 16;
            this.reset_pathMain.Text = "X";
            this.reset_pathMain.UseVisualStyleBackColor = true;
            this.reset_pathMain.Click += new System.EventHandler(this.reset_pathMain_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(229, 530);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(188, 13);
            this.version.TabIndex = 38;
            this.version.TabStop = true;
            this.version.Text = "LibreOffice Server Install GUI v x.y.z.w";
            this.version.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.checkUpdate);
            // 
            // openfile3
            // 
            this.openfile3.DefaultExt = "msi";
            this.openfile3.Filter = "LibreOffice SDK installation file | *Win_x86_sdk.msi";
            // 
            // show_gb_bs
            // 
            this.show_gb_bs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.show_gb_bs.Location = new System.Drawing.Point(19, 526);
            this.show_gb_bs.Name = "show_gb_bs";
            this.show_gb_bs.Size = new System.Drawing.Size(204, 23);
            this.show_gb_bs.TabIndex = 39;
            this.show_gb_bs.Text = "Show edit bs";
            this.show_gb_bs.UseVisualStyleBackColor = true;
            this.show_gb_bs.Click += new System.EventHandler(this.show_gb_bs_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 552);
            this.Controls.Add(this.show_gb_bs);
            this.Controls.Add(this.version);
            this.Controls.Add(this.gb_installation);
            this.Controls.Add(this.gb_create_lnk);
            this.Controls.Add(this.gb_download);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(451, 590);
            this.MinimumSize = new System.Drawing.Size(451, 590);
            this.Name = "MainUI";
            this.RightToLeftLayout = true;
            this.Text = "LibreOffice Server Install GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.tidyUponClose);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.gb_create_lnk.ResumeLayout(false);
            this.gb_create_lnk.PerformLayout();
            this.gb_download.ResumeLayout(false);
            this.gb_download.PerformLayout();
            this.gb_installation.ResumeLayout(false);
            this.gb_installation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openfile;
        private System.Windows.Forms.Button b_open_libo_installer;
        private System.Windows.Forms.TextBox path_main;
        private System.Windows.Forms.TextBox path_help;
        private System.Windows.Forms.Button b_open_libo_help;
        private System.Windows.Forms.OpenFileDialog openfile2;
        private System.Windows.Forms.Button start_install;
        private System.Windows.Forms.FolderBrowserDialog wheretoinstall;
        private System.Windows.Forms.Button b_configInstalldir;
        private System.Windows.Forms.TextBox path_installdir;
        private System.Windows.Forms.CheckBox cb_subfolder;
        private System.Windows.Forms.TextBox subfolder;
        public System.Windows.Forms.NotifyIcon give_message;
        private System.Windows.Forms.TextBox path_to_exe;
        private System.Windows.Forms.TextBox tb_version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button create_lnk;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem m_man;
        private System.Windows.Forms.ToolStripMenuItem m_help;
        private System.Windows.Forms.ToolStripMenuItem m_about;
        private System.Windows.Forms.GroupBox gb_create_lnk;
        private System.Windows.Forms.GroupBox gb_installation;
        private System.Windows.Forms.Button delete_pathHelp;
        private System.Windows.Forms.Button reset_pathMain;
        private System.Windows.Forms.Button go_patHelp;
        private System.Windows.Forms.Button go_pathMain;
        private System.Windows.Forms.LinkLabel version;
        private System.Windows.Forms.Button go_pathSDK;
        private System.Windows.Forms.Button resetPathSDK;
        private System.Windows.Forms.Button b_open_libo_sdk;
        private System.Windows.Forms.TextBox path_sdk;
        private System.Windows.Forms.GroupBox gb_download;
        private System.Windows.Forms.CheckedListBox clb_downloadSelector;
        private System.Windows.Forms.ComboBox choose_lang;
        private System.Windows.Forms.Button cancel_dl;
        private System.Windows.Forms.Label choose_lang_label;
        private System.Windows.Forms.Button start_dl;
        private System.Windows.Forms.Button update_versions;
        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.ComboBox dl_versions;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openfile3;
        private System.Windows.Forms.Button show_gb_bs;
    }
}

