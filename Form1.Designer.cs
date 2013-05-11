namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openfile = new System.Windows.Forms.OpenFileDialog();
            this.b_open_libo_installer = new System.Windows.Forms.Button();
            this.path_main = new System.Windows.Forms.TextBox();
            this.path_help = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openfile2 = new System.Windows.Forms.OpenFileDialog();
            this.start_install = new System.Windows.Forms.Button();
            this.wheretoinstall = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.path_installdir = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.bootstrap_text = new System.Windows.Forms.TextBox();
            this.open_bootstrap = new System.Windows.Forms.OpenFileDialog();
            this.save_file = new System.Windows.Forms.Button();
            this.bootinipath = new System.Windows.Forms.TextBox();
            this.userinstallation = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.path_to_file_ondisk = new System.Windows.Forms.TextBox();
            this.percent = new System.Windows.Forms.Label();
            this.cb_subfolder = new System.Windows.Forms.CheckBox();
            this.subfolder = new System.Windows.Forms.TextBox();
            this.give_message = new System.Windows.Forms.NotifyIcon(this.components);
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.percent2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.path_to_file_on_disk_2 = new System.Windows.Forms.TextBox();
            this.version = new System.Windows.Forms.Label();
            this.path_to_exe = new System.Windows.Forms.TextBox();
            this.tb_version = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.create_lnk = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.m_dl = new System.Windows.Forms.ToolStripMenuItem();
            this.m_item_lb = new System.Windows.Forms.ToolStripMenuItem();
            this.m_lb_i = new System.Windows.Forms.ToolStripMenuItem();
            this.m_lb_h = new System.Windows.Forms.ToolStripMenuItem();
            this.m_item_ob = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ob_i = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ob_h = new System.Windows.Forms.ToolStripMenuItem();
            this.m_item_tb = new System.Windows.Forms.ToolStripMenuItem();
            this.m_t_i = new System.Windows.Forms.ToolStripMenuItem();
            this.m_t_h = new System.Windows.Forms.ToolStripMenuItem();
            this.m_m_i = new System.Windows.Forms.ToolStripMenuItem();
            this.m_item_all_libo = new System.Windows.Forms.ToolStripMenuItem();
            this.m_liball_i = new System.Windows.Forms.ToolStripMenuItem();
            this.m_liball_h = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_item_hplang_tb = new System.Windows.Forms.ToolStripTextBox();
            this.m_hp_lang = new System.Windows.Forms.ToolStripComboBox();
            this.m_man = new System.Windows.Forms.ToolStripMenuItem();
            this.m_help = new System.Windows.Forms.ToolStripMenuItem();
            this.m_about = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menu.SuspendLayout();
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
            this.b_open_libo_installer.Location = new System.Drawing.Point(12, 37);
            this.b_open_libo_installer.Name = "b_open_libo_installer";
            this.b_open_libo_installer.Size = new System.Drawing.Size(206, 23);
            this.b_open_libo_installer.TabIndex = 0;
            this.b_open_libo_installer.Text = "Open LibreOffice installer";
            this.b_open_libo_installer.UseVisualStyleBackColor = true;
            this.b_open_libo_installer.Click += new System.EventHandler(this.open_installer_Click);
            // 
            // path_main
            // 
            this.path_main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_main.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_main.Location = new System.Drawing.Point(224, 40);
            this.path_main.Name = "path_main";
            this.path_main.ReadOnly = true;
            this.path_main.Size = new System.Drawing.Size(195, 20);
            this.path_main.TabIndex = 1;
            this.path_main.TextChanged += new System.EventHandler(this.validate_filename);
            // 
            // path_help
            // 
            this.path_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_help.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_help.Location = new System.Drawing.Point(224, 66);
            this.path_help.Name = "path_help";
            this.path_help.ReadOnly = true;
            this.path_help.Size = new System.Drawing.Size(195, 20);
            this.path_help.TabIndex = 3;
            this.path_help.TextChanged += new System.EventHandler(this.validate_filename);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(12, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Open LibreOffice help";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.openLibohelp);
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
            this.start_install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_install.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.start_install.ForeColor = System.Drawing.SystemColors.ControlText;
            this.start_install.Location = new System.Drawing.Point(12, 124);
            this.start_install.Name = "start_install";
            this.start_install.Size = new System.Drawing.Size(407, 74);
            this.start_install.TabIndex = 4;
            this.start_install.Text = "Start installation";
            this.start_install.UseVisualStyleBackColor = true;
            this.start_install.Click += new System.EventHandler(this.start_install_Click);
            // 
            // wheretoinstall
            // 
            this.wheretoinstall.Description = "Choose installation directory";
            this.wheretoinstall.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.wheretoinstall.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(11, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Configure installation directory";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.config_installdir);
            // 
            // path_installdir
            // 
            this.path_installdir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_installdir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_installdir.Location = new System.Drawing.Point(223, 97);
            this.path_installdir.Name = "path_installdir";
            this.path_installdir.ReadOnly = true;
            this.path_installdir.Size = new System.Drawing.Size(196, 20);
            this.path_installdir.TabIndex = 6;
            this.path_installdir.TextChanged += new System.EventHandler(this.savesettings);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(5, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Open bootstap.ini";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.open_bootstrap_Click);
            // 
            // bootstrap_text
            // 
            this.bootstrap_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bootstrap_text.Location = new System.Drawing.Point(6, 74);
            this.bootstrap_text.Multiline = true;
            this.bootstrap_text.Name = "bootstrap_text";
            this.bootstrap_text.Size = new System.Drawing.Size(368, 141);
            this.bootstrap_text.TabIndex = 8;
            // 
            // open_bootstrap
            // 
            this.open_bootstrap.FileName = "bootstrap.ini";
            this.open_bootstrap.Filter = "LibreOffice bootstrap.ini file | bootstrap.ini";
            this.open_bootstrap.Title = "Open bootstrap.ini";
            // 
            // save_file
            // 
            this.save_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save_file.Enabled = false;
            this.save_file.ForeColor = System.Drawing.SystemColors.ControlText;
            this.save_file.Location = new System.Drawing.Point(184, 19);
            this.save_file.Name = "save_file";
            this.save_file.Size = new System.Drawing.Size(190, 23);
            this.save_file.TabIndex = 9;
            this.save_file.Text = "Save bootstap.ini";
            this.save_file.UseVisualStyleBackColor = true;
            this.save_file.Click += new System.EventHandler(this.save_bootstrap);
            // 
            // bootinipath
            // 
            this.bootinipath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bootinipath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bootinipath.Location = new System.Drawing.Point(6, 48);
            this.bootinipath.Name = "bootinipath";
            this.bootinipath.ReadOnly = true;
            this.bootinipath.Size = new System.Drawing.Size(369, 20);
            this.bootinipath.TabIndex = 10;
            // 
            // userinstallation
            // 
            this.userinstallation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userinstallation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userinstallation.Location = new System.Drawing.Point(5, 221);
            this.userinstallation.Name = "userinstallation";
            this.userinstallation.ReadOnly = true;
            this.userinstallation.Size = new System.Drawing.Size(369, 20);
            this.userinstallation.TabIndex = 11;
            this.userinstallation.Text = "UserInstallation=$ORIGIN/..";
            this.userinstallation.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(69, 279);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(688, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Progress:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.save_file);
            this.groupBox1.Controls.Add(this.bootinipath);
            this.groupBox1.Controls.Add(this.userinstallation);
            this.groupBox1.Controls.Add(this.bootstrap_text);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(428, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 247);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit bootdtrap.ini";
            // 
            // path_to_file_ondisk
            // 
            this.path_to_file_ondisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_to_file_ondisk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_to_file_ondisk.Location = new System.Drawing.Point(12, 253);
            this.path_to_file_ondisk.Name = "path_to_file_ondisk";
            this.path_to_file_ondisk.ReadOnly = true;
            this.path_to_file_ondisk.Size = new System.Drawing.Size(206, 20);
            this.path_to_file_ondisk.TabIndex = 17;
            // 
            // percent
            // 
            this.percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.percent.AutoSize = true;
            this.percent.BackColor = System.Drawing.Color.Transparent;
            this.percent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.percent.Location = new System.Drawing.Point(763, 289);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(45, 13);
            this.percent.TabIndex = 18;
            this.percent.Text = "12,34 %";
            this.percent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_subfolder
            // 
            this.cb_subfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_subfolder.AutoSize = true;
            this.cb_subfolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb_subfolder.Location = new System.Drawing.Point(12, 204);
            this.cb_subfolder.Name = "cb_subfolder";
            this.cb_subfolder.Size = new System.Drawing.Size(348, 17);
            this.cb_subfolder.TabIndex = 22;
            this.cb_subfolder.Text = "Should a subfolder be created automatically? Name of the subfolder:";
            this.cb_subfolder.UseVisualStyleBackColor = true;
            this.cb_subfolder.CheckedChanged += new System.EventHandler(this.savesettings);
            // 
            // subfolder
            // 
            this.subfolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.subfolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.subfolder.Location = new System.Drawing.Point(12, 227);
            this.subfolder.Name = "subfolder";
            this.subfolder.Size = new System.Drawing.Size(407, 20);
            this.subfolder.TabIndex = 23;
            this.subfolder.TextChanged += new System.EventHandler(this.savesettings);
            // 
            // give_message
            // 
            this.give_message.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.give_message.Icon = ((System.Drawing.Icon)(resources.GetObject("give_message.Icon")));
            this.give_message.Text = "Libreoffice Server Installation GUI";
            this.give_message.Visible = true;
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(69, 308);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(688, 23);
            this.progressBar2.TabIndex = 28;
            // 
            // percent2
            // 
            this.percent2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.percent2.AutoSize = true;
            this.percent2.BackColor = System.Drawing.Color.Transparent;
            this.percent2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.percent2.Location = new System.Drawing.Point(763, 318);
            this.percent2.Name = "percent2";
            this.percent2.Size = new System.Drawing.Size(45, 13);
            this.percent2.TabIndex = 30;
            this.percent2.Text = "12,34 %";
            this.percent2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(9, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Progress:";
            // 
            // path_to_file_on_disk_2
            // 
            this.path_to_file_on_disk_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_to_file_on_disk_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_to_file_on_disk_2.Location = new System.Drawing.Point(224, 253);
            this.path_to_file_on_disk_2.Name = "path_to_file_on_disk_2";
            this.path_to_file_on_disk_2.ReadOnly = true;
            this.path_to_file_on_disk_2.Size = new System.Drawing.Size(195, 20);
            this.path_to_file_on_disk_2.TabIndex = 31;
            // 
            // version
            // 
            this.version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(9, 343);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(188, 13);
            this.version.TabIndex = 32;
            this.version.Text = "LibreOffice Server Install GUI v x.y.z.w";
            // 
            // path_to_exe
            // 
            this.path_to_exe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.path_to_exe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.path_to_exe.Location = new System.Drawing.Point(203, 340);
            this.path_to_exe.Name = "path_to_exe";
            this.path_to_exe.ReadOnly = true;
            this.path_to_exe.Size = new System.Drawing.Size(216, 20);
            this.path_to_exe.TabIndex = 33;
            this.path_to_exe.TextChanged += new System.EventHandler(this.savesettings);
            // 
            // tb_version
            // 
            this.tb_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_version.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tb_version.Location = new System.Drawing.Point(476, 340);
            this.tb_version.Name = "tb_version";
            this.tb_version.Size = new System.Drawing.Size(167, 20);
            this.tb_version.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Version:";
            // 
            // create_lnk
            // 
            this.create_lnk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.create_lnk.Location = new System.Drawing.Point(649, 337);
            this.create_lnk.Name = "create_lnk";
            this.create_lnk.Size = new System.Drawing.Size(159, 24);
            this.create_lnk.TabIndex = 36;
            this.create_lnk.Text = "Create shortcut";
            this.create_lnk.UseVisualStyleBackColor = true;
            this.create_lnk.Click += new System.EventHandler(this.create_ink_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_dl,
            this.m_man,
            this.m_help,
            this.m_about});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(820, 24);
            this.menu.TabIndex = 37;
            this.menu.Text = "menuStrip1";
            // 
            // m_dl
            // 
            this.m_dl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_item_lb,
            this.m_item_ob,
            this.m_item_tb,
            this.m_m_i,
            this.m_item_all_libo,
            this.toolStripSeparator1,
            this.m_item_hplang_tb,
            this.m_hp_lang});
            this.m_dl.Name = "m_dl";
            this.m_dl.Size = new System.Drawing.Size(73, 20);
            this.m_dl.Text = "&Download";
            // 
            // m_item_lb
            // 
            this.m_item_lb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_lb_i,
            this.m_lb_h});
            this.m_item_lb.Name = "m_item_lb";
            this.m_item_lb.Size = new System.Drawing.Size(181, 22);
            this.m_item_lb.Text = "&Latest branch";
            // 
            // m_lb_i
            // 
            this.m_lb_i.Name = "m_lb_i";
            this.m_lb_i.Size = new System.Drawing.Size(124, 22);
            this.m_lb_i.Text = "&Installer";
            this.m_lb_i.Click += new System.EventHandler(this.m_lb_i_Click);
            // 
            // m_lb_h
            // 
            this.m_lb_h.Name = "m_lb_h";
            this.m_lb_h.Size = new System.Drawing.Size(124, 22);
            this.m_lb_h.Text = "&Helppack";
            this.m_lb_h.Click += new System.EventHandler(this.m_lb_h_Click);
            // 
            // m_item_ob
            // 
            this.m_item_ob.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ob_i,
            this.m_ob_h});
            this.m_item_ob.Name = "m_item_ob";
            this.m_item_ob.Size = new System.Drawing.Size(181, 22);
            this.m_item_ob.Text = "&Older branch";
            // 
            // m_ob_i
            // 
            this.m_ob_i.Name = "m_ob_i";
            this.m_ob_i.Size = new System.Drawing.Size(124, 22);
            this.m_ob_i.Text = "&Installer";
            this.m_ob_i.Click += new System.EventHandler(this.m_ob_i_Click);
            // 
            // m_ob_h
            // 
            this.m_ob_h.Name = "m_ob_h";
            this.m_ob_h.Size = new System.Drawing.Size(124, 22);
            this.m_ob_h.Text = "&Helppack";
            this.m_ob_h.Click += new System.EventHandler(this.m_ob_h_Click);
            // 
            // m_item_tb
            // 
            this.m_item_tb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_t_i,
            this.m_t_h});
            this.m_item_tb.Name = "m_item_tb";
            this.m_item_tb.Size = new System.Drawing.Size(181, 22);
            this.m_item_tb.Text = "&Testing build";
            // 
            // m_t_i
            // 
            this.m_t_i.Name = "m_t_i";
            this.m_t_i.Size = new System.Drawing.Size(124, 22);
            this.m_t_i.Text = "&Installer";
            this.m_t_i.Click += new System.EventHandler(this.m_t_i_Click);
            // 
            // m_t_h
            // 
            this.m_t_h.Name = "m_t_h";
            this.m_t_h.Size = new System.Drawing.Size(124, 22);
            this.m_t_h.Text = "&Helppack";
            this.m_t_h.Click += new System.EventHandler(this.m_t_h_Click);
            // 
            // m_m_i
            // 
            this.m_m_i.Name = "m_m_i";
            this.m_m_i.Size = new System.Drawing.Size(181, 22);
            this.m_m_i.Text = "&Master";
            this.m_m_i.Click += new System.EventHandler(this.m_m_i_Click);
            // 
            // m_item_all_libo
            // 
            this.m_item_all_libo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_liball_i,
            this.m_liball_h});
            this.m_item_all_libo.Name = "m_item_all_libo";
            this.m_item_all_libo.Size = new System.Drawing.Size(181, 22);
            this.m_item_all_libo.Text = "All L&ibo versions";
            // 
            // m_liball_i
            // 
            this.m_liball_i.Name = "m_liball_i";
            this.m_liball_i.Size = new System.Drawing.Size(152, 22);
            this.m_liball_i.Text = "&Installer";
            this.m_liball_i.Click += new System.EventHandler(this.installerToolStripMenuItem_Click);
            // 
            // m_liball_h
            // 
            this.m_liball_h.Name = "m_liball_h";
            this.m_liball_h.Size = new System.Drawing.Size(152, 22);
            this.m_liball_h.Text = "&Helppack";
            this.m_liball_h.Click += new System.EventHandler(this.helppackToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // m_item_hplang_tb
            // 
            this.m_item_hplang_tb.Name = "m_item_hplang_tb";
            this.m_item_hplang_tb.Size = new System.Drawing.Size(120, 23);
            this.m_item_hplang_tb.Text = "Language (help)";
            this.m_item_hplang_tb.TextChanged += new System.EventHandler(this.m_item_hplang_tb_TextChanged);
            // 
            // m_hp_lang
            // 
            this.m_hp_lang.Items.AddRange(new object[] {
            "ast",
            "bg",
            "bn-IN",
            "bn",
            "bo",
            "bs",
            "ca-XV",
            "ca",
            "cs",
            "da",
            "de",
            "dz",
            "el",
            "en-GB",
            "en-US",
            "en-ZA",
            "eo",
            "es",
            "et",
            "eu",
            "fi",
            "fr",
            "gl",
            "gu",
            "he",
            "hi",
            "hr",
            "hu",
            "id",
            "is",
            "it",
            "ja",
            "ka",
            "km",
            "ko",
            "lb",
            "nb",
            "ne",
            "nl",
            "nn",
            "om",
            "pl",
            "pt-BR",
            "pt",
            "ru",
            "si",
            "sk",
            "sl",
            "sq",
            "sv",
            "tg",
            "tr",
            "ug",
            "uk",
            "vi",
            "zh-CN",
            "zh-TW"});
            this.m_hp_lang.Name = "m_hp_lang";
            this.m_hp_lang.Size = new System.Drawing.Size(121, 23);
            this.m_hp_lang.SelectedIndexChanged += new System.EventHandler(this.savesettings);
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
            // m_about
            // 
            this.m_about.Name = "m_about";
            this.m_about.Size = new System.Drawing.Size(156, 20);
            this.m_about.Text = "&About / Change language";
            this.m_about.Click += new System.EventHandler(this.m_about_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 373);
            this.Controls.Add(this.create_lnk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_version);
            this.Controls.Add(this.path_to_exe);
            this.Controls.Add(this.version);
            this.Controls.Add(this.path_to_file_on_disk_2);
            this.Controls.Add(this.percent2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.subfolder);
            this.Controls.Add(this.cb_subfolder);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.path_to_file_ondisk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.path_installdir);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.start_install);
            this.Controls.Add(this.path_help);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.path_main);
            this.Controls.Add(this.b_open_libo_installer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(836, 411);
            this.MinimumSize = new System.Drawing.Size(836, 411);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "LibreOffice Server Installation GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openfile;
        private System.Windows.Forms.Button b_open_libo_installer;
        private System.Windows.Forms.TextBox path_main;
        private System.Windows.Forms.TextBox path_help;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openfile2;
        private System.Windows.Forms.Button start_install;
        private System.Windows.Forms.FolderBrowserDialog wheretoinstall;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox path_installdir;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox bootstrap_text;
        private System.Windows.Forms.OpenFileDialog open_bootstrap;
        private System.Windows.Forms.Button save_file;
        private System.Windows.Forms.TextBox bootinipath;
        private System.Windows.Forms.TextBox userinstallation;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox path_to_file_ondisk;
        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.CheckBox cb_subfolder;
        private System.Windows.Forms.TextBox subfolder;
        private System.Windows.Forms.NotifyIcon give_message;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label percent2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox path_to_file_on_disk_2;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.TextBox path_to_exe;
        private System.Windows.Forms.TextBox tb_version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button create_lnk;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem m_dl;
        private System.Windows.Forms.ToolStripMenuItem m_man;
        private System.Windows.Forms.ToolStripMenuItem m_help;
        private System.Windows.Forms.ToolStripMenuItem m_about;
        private System.Windows.Forms.ToolStripMenuItem m_item_lb;
        private System.Windows.Forms.ToolStripMenuItem m_item_ob;
        private System.Windows.Forms.ToolStripMenuItem m_item_tb;
        private System.Windows.Forms.ToolStripMenuItem m_m_i;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox m_item_hplang_tb;
        private System.Windows.Forms.ToolStripComboBox m_hp_lang;
        private System.Windows.Forms.ToolStripMenuItem m_lb_i;
        private System.Windows.Forms.ToolStripMenuItem m_lb_h;
        private System.Windows.Forms.ToolStripMenuItem m_ob_i;
        private System.Windows.Forms.ToolStripMenuItem m_ob_h;
        private System.Windows.Forms.ToolStripMenuItem m_t_i;
        private System.Windows.Forms.ToolStripMenuItem m_t_h;
        private System.Windows.Forms.ToolStripMenuItem m_item_all_libo;
        private System.Windows.Forms.ToolStripMenuItem m_liball_i;
        private System.Windows.Forms.ToolStripMenuItem m_liball_h;
    }
}

