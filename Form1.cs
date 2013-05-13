#region Licence
/*This file is part of the project "Reisisoft Server Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Xml.Serialization;


//Used for translating: http://www.codeproject.com/Articles/16068/Zeta-Resource-Editor (I will forget it soon)...

namespace WindowsFormsApplication1
{


    public partial class Form1 : Form
    {
        access_settings set = new access_settings();
        ResourceManager rm = new ResourceManager("WindowsFormsApplication1.strings", Assembly.GetExecutingAssembly());
        public Form1()
        {

            //l10n import
            string[] rtl = new string[] { "He" };
            try
            {

                SETTINGS temp = set.open_settings();
                string lang = temp.l10n;
                if (lang != null)
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang, false);

                if (rtl.Contains(lang))
                    this.RightToLeftLayout = true;

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SETTINGS temp = set.open_settings();
            string lang = temp.l10n;
            string[] rtl_lang = new string[] { "He" };



            if (rtl_lang.Contains(lang))
            {
                // Which texts should stay LTR, when using a RTL language
                bootinipath.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bootstrap_text.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_to_file_on_disk.RightToLeft = System.Windows.Forms.RightToLeft.No;
                subfolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_installdir.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_help.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }

            //l10n start
            shplang = getstring("m_l10n_langhelptxt");
            string installer = getstring("m_l10n_installer");
            string helppack = getstring("m_l10n_helppack");
            b_open_libo_installer.Text = getstring("open_installer");
            m_about.Text = getstring("about");
            m_man.Text = getstring("man_title");
            button2.Text = getstring("open_help");
            button3.Text = getstring("config_installdir");
            button4.Text = getstring("open_bootstrap_ini");
            gb_bootstrap.Text = getstring("edit_bs_ini");
            label2.Text = getstring("progress");
            open_bootstrap.Title = getstring("open_bootstrap_title");
            save_file.Text = getstring("save_bootstrap_ini");
            start_install.Text = getstring("start_install");
            wheretoinstall.Description = getstring("where_to_install");
            cb_subfolder.Text = getstring("subfolder_do");
            create_lnk.Text = getstring("b_create_shortcut");
            label1.Text = getstring("s_version");
            m_help.Text = getstring("help");
            m_item_lb.Text = getstring("m_l10n_lb");
            m_item_ob.Text = getstring("m_l10n_ob");
            m_item_tb.Text = getstring("m_l10n_t");
            m_item_hplang_tb.Text = shplang;
            m_lb_h.Text = helppack;
            m_ob_h.Text = helppack;
            m_t_h.Text = helppack;
            m_liball_h.Text = helppack;
            m_lb_i.Text = installer;
            m_ob_i.Text = installer;
            m_t_i.Text = installer;
            m_liball_i.Text = installer;
            gb_download.Text = m_dl.Text;
            gb_create_lnk.Text = create_lnk.Text;
            start_dl.Text = getstring("start_dl");
            cb_installer.Text = getstring("cb_installer");
            cb_help.Text = getstring("cb_help");
            update_versions.Text = getstring("update_versions");

            /* l10n end
             Update version information */
            version.Text = "LibreOffice Server Install GUI v." + set.program_version();

            // Start Setting tooltips
            ToolTip ink = new ToolTip();
            ToolTip bootstrapini = new ToolTip();
            ToolTip pathtoexe = new ToolTip();
            string bootstrap = getstring("tt_bootstrap");
            ink.SetToolTip(this.create_lnk, getstring("tt_ink"));
            bootstrapini.SetToolTip(this.bootstrap_text, bootstrap);
            pathtoexe.SetToolTip(this.path_to_exe, getstring("tt_path_to_exe"));
            bootstrapini.ShowAlways = true;
            pathtoexe.ShowAlways = true;
            ink.IsBalloon = true;
            bootstrapini.IsBalloon = true;
            pathtoexe.IsBalloon = true;
            /* End Setting tooltips
             *  Loading settings*/
            loadsettinmgs();
            // Setup message baloon
            give_message.BalloonTipClicked += new EventHandler(gm_do);
            give_message.BalloonTipClosed += new EventHandler(gm_do);
            give_message.Click += new EventHandler(gm_do);
            give_message.DoubleClick += new EventHandler(gm_do);
            // Bring the window in the foreground
            this.BringToFront();
            // Set up the progress bars 1 -> Installer 2 -> Helppack
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10000;
            percent.Text = "0 %";
        }
        private void loadsettinmgs()
        {
            try
            {
                SETTINGS toapply = set.open_settings();
                //Apply settings
                cb_subfolder.Checked = toapply.checkbox;
                path_installdir.Text = toapply.installdir;
                subfolder.Text = toapply.subfolder;
                m_hp_lang.SelectedIndex = toapply.lang;
                path_to_exe.Text = toapply.last_path_to_sofficeEXE;
            }
            catch (Exception)
            { }
        }

        private void gm_do(Object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filename_install = openfile.FileName;
            path_main.Text = filename_install;
        }
        private void openLibohelp(object sender, EventArgs e)
        {
            openfile2.ShowDialog();
        }

        private void openfile2_FileOk(object sender, CancelEventArgs e)
        {
            string filename_help = openfile2.FileName;
            path_help.Text = filename_help;
        }

        private void config_installdir(object sender, EventArgs e)
        {
            if (wheretoinstall.ShowDialog() == DialogResult.OK)
            {
                string fileame_installdir = wheretoinstall.SelectedPath;
                path_installdir.Text = fileame_installdir;
            }

        }

        private void start_install_Click(object sender, EventArgs e)
        {

            bool install_main = false;
            bool install_help = false;
            bool install_path = false;
            bool go_on = true;
            // Check settings
            if (path_main.TextLength > 0)
                install_main = true;
            if (path_help.TextLength > 0)
                install_help = true;
            if (path_installdir.TextLength > 0)
                install_path = true;

            // Throw an exeption, when no installdir choosen and a warning if no LibreOffice was choosen.
            try
            {
                if (!install_path)
                    throw new Exception(getstring("no_installdir"));
            }

            catch (Exception ex)
            {
                exeptionmessage(ex.Message);
                go_on = false;

            }
            finally
            {
                try
                {
                    if (!install_main)
                    {
                        MessageBox.Show(getstring("no_installfile"), getstring("warning"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        throw new Exception(getstring("go_back"));
                    }
                }

                catch (Exception) { go_on = false; }

            }
            if (go_on == true)
            {
                // Install
                string cmd_filename = create_cmd(install_main, install_help);
                try
                {
                    Process.Start(cmd_filename);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(getstring("installerror") + ex.Message, getstring("installnostart"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string bootini = path_installdir + "\\program\\bootstrap.ini";
            }
        }
        private string final_installpath { get; set; }

        private string create_cmd(bool install_libo, bool install_help)
        {
            string path = path_installdir.Text;
            if (cb_subfolder.Checked && (subfolder.Text != ""))
            {

                path += "\\" + subfolder.Text;
            }
            path = path.Replace("\\\\", "\\");
            final_installpath = path;
            string cmd_file = "@ECHO off" + Environment.NewLine;
            if (install_libo)
                cmd_file += "start /wait msiexec /qr /norestart /a \"" + path_main.Text + "\" TARGETDIR=\"" + path + "\"" + Environment.NewLine;
            if (install_help)
                cmd_file += "start /wait msiexec /qr /a \"" + path_help.Text + "\" TARGETDIR=\"" + path + "\"" + Environment.NewLine;
            cmd_file += "exit";
            string filename = System.IO.Path.GetTempPath() + "install.cmd";
            try
            {
                System.IO.File.WriteAllText(filename, cmd_file);
                // If CMD file created --> Add to manager...
                SETTINGS temp = set.open_settings();
                temp.manager = set.update_manager_array(temp.manager, path);
                set.save_settings(temp);
                // Create path to soffice.exe
                path += "\\program\\soffice.exe";
                path_to_exe.Text = path;
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show(getstring("dirnotfound") + getstring("dirnotfoundmessage"), getstring("dirnotfound"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show(getstring("si_message"), getstring("si"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                exeptionmessage(ex.Message);
            }
            return filename;
        }


        private void open_bootstrap_Click(object sender, EventArgs e)
        {
            openbootstrap_ini();


        }

        private bool openbootstrap_ini()
        {
            bool working = true;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "abc.txt";
            if (final_installpath != null)
                path = final_installpath + "\\" + "program" + "\\" + "bootstrap.ini";

            try
            {
                bootstrap_text.Text = System.IO.File.ReadAllText(path);
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                working = false;
                if (open_bootstrap.ShowDialog() == DialogResult.OK)
                {
                    working = secondtry(open_bootstrap.FileName);
                }
                return working;
            }
            catch (System.IO.FileNotFoundException)
            {
                working = false;

                if (open_bootstrap.ShowDialog() == DialogResult.OK)
                {
                    working = secondtry(open_bootstrap.FileName);
                }
                return working;
            }

            catch (Exception ex)
            {
                working = false;
                exeptionmessage(ex.Message);
                return working;
            }
            if (working == true)
            {
                save_file.Enabled = true;
                bootinipath.Text = path;
            }
            return working;
        }

        private bool secondtry(string path)
        {
            bool working = true;

            try
            {
                bootstrap_text.Text = System.IO.File.ReadAllText(path);

            }
            catch (Exception ex)
            {
                working = false;
                exeptionmessage(ex.Message);


            }
            if (working == true)
            {
                save_file.Enabled = true;
                bootinipath.Text = path;
            }

            return working;

        }

        private void save_bootstrap(object sender, EventArgs e)
        {
            bool working = true;
            string exeptiontext = "";
            // Save bootstrap.ini
            try
            {
                System.IO.File.WriteAllText(bootinipath.Text, bootstrap_text.Text);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                working = false;
                exeptiontext = ex.Message + " Error:DNF";
            }
            catch (System.IO.FileNotFoundException ex)
            {
                working = false;
                exeptiontext = ex.Message + " Error:FNF";
            }
            catch (System.IO.IOException ex)
            {
                working = false;
                exeptiontext = ex.Message + " Error:IOE";
            }
            catch (System.UnauthorizedAccessException ex)
            {
                working = false;
                exeptiontext = ex.Message + " Error:UAE" + Environment.NewLine + Environment.NewLine + getstring("help_runasadmin");
            }
            catch (System.NotSupportedException ex)
            {
                working = false;
                exeptiontext = ex.Message + " Error:NSE";
            }
            catch (System.Security.SecurityException ex)
            {
                working = false;
                exeptiontext = ex.Message + " Error:SE";
            }
            catch (Exception ex)
            {
                working = false;
                exeptiontext = ex.Message + " Error:???";
            }
            finally
            {

                if (working)
                {
                    MessageBox.Show(getstring("filesave"), getstring("title_filesave"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    exeptionmessage(exeptiontext);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userinstallation.Text = "UserInstallation=$ORIGIN/..";
        }
        private void open_installer_Click(object sender, EventArgs e)
        {
            openfile.ShowDialog();
        }
        public void exeptionmessage(string ex_message)
        {
            MessageBox.Show(getstring("standarderror") + ex_message, getstring("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public string getstring(string strMessage)
        {
            string rt = "???";
            try
            {
                rt = rm.GetString(strMessage);
            }
            catch (Exception)
            {
                exeptionmessage("An error in the l10n part occured!");
            }
            return rt;

        }

        // Function, which prepares the data, which should be saved for next startup
        private void savesettings(object sender, EventArgs e)
        {
            // Changing text of version
            tb_version.Text = subfolder.Text;
            // Really save settings
            SETTINGS thingstosave = set.open_settings();
            thingstosave.installdir = path_installdir.Text;
            thingstosave.subfolder = subfolder.Text;
            thingstosave.checkbox = cb_subfolder.Checked;
            thingstosave.lang = m_hp_lang.SelectedIndex;
            thingstosave.last_path_to_sofficeEXE = path_to_exe.Text;
            set.save_settings(thingstosave);

        }

        private void create_ink_Click(object sender, EventArgs e)
        {
            LINK lnk = new LINK();
            lnk.create_ink(path_to_exe.Text, tb_version.Text);
        }

        private void m_about_Click(object sender, EventArgs e)
        {
            openAbout();
        }

        private void m_man_Click(object sender, EventArgs e)
        {
            openManager();
        }

        private void m_help_Click(object sender, EventArgs e)
        {
            openHelp();
        }

        private void m_lb_i_Click(object sender, EventArgs e)
        {
            startasyncdownload("http://download.documentfoundation.org/libreoffice/stable/", false, false, true, false);
        }

        private void m_lb_h_Click(object sender, EventArgs e)
        {
            startasyncdownload("http://download.documentfoundation.org/libreoffice/stable/", false, false, true, false, true);
        }

        private void m_ob_i_Click(object sender, EventArgs e)
        {
            startasyncdownload("http://download.documentfoundation.org/libreoffice/stable/", false, false, false, true);
        }

        private void m_ob_h_Click(object sender, EventArgs e)
        {
            startasyncdownload("http://download.documentfoundation.org/libreoffice/stable/", false, false, false, true, true);
        }

        private void m_t_i_Click(object sender, EventArgs e)
        {
            startasyncdownload("http://dev-builds.libreoffice.org/pre-releases/win/x86/", true, false, false, false);
        }

        private void m_t_h_Click(object sender, EventArgs e)
        {
            startasyncdownload("http://dev-builds.libreoffice.org/pre-releases/win/x86/", true, false, false, false, true);
        }

        private void m_m_i_Click(object sender, EventArgs e)
        {
            startasyncdownload("http://dev-builds.libreoffice.org/daily/master/Win-x86@6/current/", false, true, false, false);
        }

        string shplang;
        private void m_item_hplang_tb_TextChanged(object sender, EventArgs e)
        {
            // Text should always stay the same
            m_item_hplang_tb.Text = shplang;
        }
        private void installerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Download any LibO installer
            ManageMassDL(false, true);
        }

        private void helppackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Download any LibO help
            ManageMassDL(true, true);
        }

        private void validate_filename(object sender, EventArgs e)
        {
            if (path_main.Text.Contains("exe"))
            {
                path_main.Text = "";
                MessageBox.Show(getstring("no_valid_filename_error_text"), getstring("no_valid_filename_error_title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (path_help.Text.Contains("exe"))
            {
                path_help.Text = "";
                MessageBox.Show(getstring("no_valid_filename_error_text"), getstring("no_valid_filename_error_title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
