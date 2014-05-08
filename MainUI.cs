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
// Create lnk
using IWshRuntimeLibrary;


//Used for translation: http://www.codeproject.com/Articles/16068/Zeta-Resource-Editor 

namespace SI_GUI
{
    public partial class MainUI : Form
    {
        #region String[] alllnag
        string[] alllang = new string[]
        {
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
            "zh-TW"
        };
        #endregion
        private bool rtl_layout = false;
        string[] dl_special;
        ChangingDLInfo[] dlInfos;
        access_settings set = new access_settings();
        ResourceManager rm = new ResourceManager("SI_GUI.l10n.strings", Assembly.GetExecutingAssembly());
        TDFPiwik piwik;
        string path_4_download = Path.GetTempPath();
        bool AdvancedFilenames;
        string siguiTitle
        {
            get
            {
                return "Server Install GUI - " + getstring("siguislogan");
            }
        }
        public MainUI()
        {

            //l10n import
            string[] rtl = new string[] { "He" };
            SETTINGS temp = new SETTINGS();
            try
            {
                temp = set.open_settings();
                if (temp.DL_saved_settings.download_path != null)
                    path_4_download = temp.DL_saved_settings.download_path;
                string lang = temp.l10n;
                if (lang != null)
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang, false);
                else
                {
                    int i = 0;
                    try
                    {
                        while (true)
                        {
                            if (Thread.CurrentThread.CurrentUICulture.DisplayName.Contains(langAvailable[i]))
                                break;
                            i++;
                        }
                    }
                    catch (Exception) { i = 0; }
                    lang = langAvailable[i];
                    temp.l10n = lang;
                    set.save_settings(temp);
                }
                piwik = new TDFPiwik(getstring("ga_allowed_title"), getstring("ga_allowed_text"));
                piwik.sendStartupStats(lang);
                if (rtl.Contains(lang))
                    rtl_layout = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            if (rtl_layout)
                RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            InitializeComponent();

            openfile.InitialDirectory = temp.DL_saved_settings.download_path;
            openfile2.InitialDirectory = openfile.InitialDirectory;
            choose_lang.Items.AddRange(alllang);
            try
            {
                Directory.CreateDirectory(path_4_download);
            }
            catch (Exception e)
            {
                exceptionmessage(e.Message);
            }

        }
        private void MainUI_Load(object sender, EventArgs e)
        {
            if (rtl_layout)
            {
                // Which texts should stay LTR, when using a RTL language
                bootinipath.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bootstrap_text.RightToLeft = System.Windows.Forms.RightToLeft.No;
                subfolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_installdir.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_help.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_main.RightToLeft = System.Windows.Forms.RightToLeft.No;
                userinstallation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }

            //l10n start
            b_open_libo_installer.Text = getstring("open_installer");
            button2.Text = getstring("open_help");
            button3.Text = getstring("config_installdir");
            button4.Text = getstring("open_bootstrap_ini");
            cb_help.Text = getstring("gb_dl_help");
            cb_installer.Text = getstring("gb_dl_installer");
            cb_subfolder.Text = getstring("subfolder_do");
            choose_lang_label.Text = getstring("m_l10n_langhelptxt") + ":";
            create_lnk.Text = getstring("b_create_shortcut");
            dl_versions.Text = getstring("s_version");
            gb_bootstrap.Text = getstring("edit_bs_ini");
            gb_create_lnk.Text = create_lnk.Text;
            gb_download.Text = getstring("m_l10n_dl");
            gb_installation.Text = getstring("gb_parallel_install");
            // give_message.Text = siguiTitle;
            label1.Text = getstring("s_version");
            labelProgress.Text = getstring("progress");
            m_about.Text = getstring("about");
            m_help.Text = getstring("help");
            m_man.Text = getstring("man_title");
            open_bootstrap.Title = getstring("open_bootstrap_title");
            save_file.Text = getstring("save_bootstrap_ini");
            show_gb_bs.Text = gb_bootstrap.Text;
            start_dl.Text = getstring("gb_dl_begindl");
            start_install.Text = getstring("start_install");
            this.Text = siguiTitle;
            update_versions.Text = getstring("gb_dl_update");
            wheretoinstall.Description = getstring("where_to_install");
            /* l10n end
             Update version information */
            version.Text = "LibreOffice Server Install GUI " + set.program_version();
            // Load settings
            /*
             * 
             *    Set special download
             * 
             * */
            dl_special = new string[] { getstring("liboFresh"),getstring("liboStable"), getstring("m_l10n_t"), "---" };
            /*
            * 
            *    Set special download end
            * 
            * */
            loadsettings();
            percent.Text = "0 %";
            // Position choose_lang
            choose_lang.Location = new Point(choose_lang_label.Location.X + choose_lang_label.Width + 6, choose_lang_label.Location.Y - 3);
            // Position startdl
            start_dl.Location = new Point(choose_lang.Width + choose_lang.Location.X + 6, choose_lang.Location.Y);
            start_dl.Width = 397 - start_dl.Location.X;
            // Specify the starting folder for FileOpen dialogs
            openfile.InitialDirectory = Path.GetTempPath();
            openfile2.InitialDirectory = openfile.InitialDirectory;
            // Position progressbar 1
            // Start Setting tooltips
            ToolTip ink = get_ToolTip(create_lnk, getstring("tt_ink"));
            ToolTip bootstrapini = get_ToolTip(bootstrap_text, getstring("tt_bootstrap"));
            ToolTip pathtoexe = get_ToolTip(path_to_exe, getstring("tt_path_to_exe"));
            ToolTip manuallyUpdate = get_ToolTip(version, getstring("tt_autoupdate"));
            ToolTip go1 = get_ToolTip(go_patHhelp, getstring("tt_go"));
            ToolTip go2 = get_ToolTip(go_pathMain, getstring("tt_go"));
            /* End Setting tooltips
             * Change progressbar location */
            progressBar.Location = new Point(labelProgress.Location.X + 6 + labelProgress.Size.Width, progressBar.Location.Y);
            progressBar.Size = new System.Drawing.Size(cancel_dl.Location.X - progressBar.Location.X - 6, progressBar.Size.Height);
            // Setup message baloon
            give_message.BalloonTipClicked += new EventHandler(gm_do);
            give_message.BalloonTipClosed += new EventHandler(gm_do);
            give_message.Click += new EventHandler(gm_do);
            give_message.DoubleClick += new EventHandler(gm_do);
        }

        public static ToolTip get_ToolTip(Control c, string text)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(c, text);
            tt.ShowAlways = true;
            tt.IsBalloon = true;
            tt.UseAnimation = true;

            return tt;
        }

        private void loadsettings()
        {
            try
            {
                SETTINGS toapply = set.open_settings();
                //Apply settings
                cb_subfolder.Checked = toapply.cb_create_subfolder;
                AdvancedFilenames = toapply.cb_advanced_filenames;
                path_installdir.Text = toapply.FilesFolders.InstallFolder;
                subfolder.Text = toapply.FilesFolders.nameSubfolder;
                choose_lang.SelectedIndex = toapply.lang;
                path_to_exe.Text = toapply.FilesFolders.lastSofficeEXE;
                path_main.Text = toapply.FilesFolders.MainInstalldir;
                path_help.Text = toapply.FilesFolders.HelpInstalldir;
                dl_list = toapply.DL_saved_settings.versions;
                if (dl_list == null)
                    dl_list = new string[0];
                dlInfos = toapply.DL_saved_settings.changingVersion;
                if (dlInfos == null)
                    dlInfos = new ChangingDLInfo[0];

                loadVersionstoList();
                try
                {
                    dl_versions.SelectedIndex = toapply.DL_saved_settings.versions_last_version;
                }
                catch (Exception)
                { }
                cb_installer.Checked = toapply.DL_saved_settings.cb_installer;
                cb_help.Checked = toapply.DL_saved_settings.cb_help;
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
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
            piwik.sendFeatreUseageStats(TDFPiwik.Features.Open_Help);
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
            piwik.sendFeatreUseageStats(TDFPiwik.Features.Config_Dir);
        }

        private void start_install_Click(object sender, EventArgs e)
        {
            doInstall(path_main.Text, path_help.Text, getFinalInstalldir());
        }
        public void doInstall(string main, string help, string dir)
        {
            piwik.sendFeatreUseageStats(TDFPiwik.Features.ParallelInstall_Start);
            bool install_main = false;
            bool install_help = false;
            bool install_path = false;
            bool go_on = true;
            // Check settings
            if (main.Length > 0)
                install_main = true;
            if (help.Length > 0)
                install_help = true;
            if (dir.Length > 0)
                install_path = true;
            Process p = new Process();
            // Throw an exeption, when no installdir choosen and a warning if no LibreOffice was choosen.
            try
            {
                if (!install_path)
                    throw new Exception(getstring("no_installdir"));
            }

            catch (Exception ex)
            {
                exceptionmessage(ex.Message);
                go_on = false;
            }
            finally
            {
                try
                {
                    if (!install_main)
                    {
                        if (MessageBox.Show(getstring("no_installfile"), getstring("warning"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                            throw new Exception(getstring("go_back"));
                    }
                }

                catch (Exception) { go_on = false; }
            }
            if (go_on)
            {
                // Test, if there is a existing ServerInastallation
                bool okay = false;
                try
                {
                    System.IO.File.OpenRead(dir);
                }
                catch (Exception)
                {
                    okay = true;
                }
                if (!okay)
                {
                    if (MessageBox.Show(getstring("install_err1_txt"), getstring("install_err1_tit"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                        go_on = false;
                }
                if (go_on)
                {
                    // Install
                    String bspath = executeInstallation(install_main, install_help, main, help, getFinalInstalldir());
                    piwik.sendFeatreUseageStats(TDFPiwik.Features.ParallelInstall_OK);
                    openbootstrap_ini(true, bspath);
                    piwik.sendFeatreUseageStats(TDFPiwik.Features.ParallelInstall_End);
                }

            }
        }
        private String getFinalInstalldir()
        {
            string path = path_installdir.Text;
            if (cb_subfolder.Checked && (subfolder.Text != ""))
            {

                path += "\\" + subfolder.Text;
            }
            return path.Replace("\\\\", "\\");
        }

        private String executeInstallation(bool install_libo, bool install_help, String main, String help, String dir)
        {
            Process p = new Process();
            if (install_libo)
            {
                p.StartInfo = new ProcessStartInfo("msiexec", "/qr /norestart /a \"" + main + "\" TARGETDIR=\"" + dir + "\"");
                p.Start();
                p.WaitForExit();
            }
            if (install_help)
            {
                p.StartInfo = new ProcessStartInfo("msiexec", "/qr /a \"" + help + "\" TARGETDIR=\"" + dir + "\"");
                p.Start();
                p.WaitForExit();
            }
            try
            {
                // If installation finished --> Add to manager...
                SETTINGS temp = set.open_settings();
                temp.manager_versions = set.update_manager_array(temp.manager_versions, dir);
                set.save_settings(temp);
                // Create path to soffice.exe
                dir += "\\program\\soffice.exe";
                path_to_exe.Text = dir;
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
                exceptionmessage(ex.Message);
            }
            return getbsINIPath();

        }
        private String getbsINIPath()
        {
            return path_to_exe.Text.Replace("soffice.exe", "bootstrap.ini");
        }
        private void open_bootstrap_Click(object sender, EventArgs e)
        {
            openbootstrap_iniFO();
        }
        private bool openbootstrap_iniFO()
        {
            if (open_bootstrap.ShowDialog() == DialogResult.OK)

                return secondtry(open_bootstrap.FileName);
            else return false;

        }

        private bool openbootstrap_ini(bool autoEditenabled)
        {
            return openbootstrap_ini(autoEditenabled, getbsINIPath());
        }

        private bool openbootstrap_ini(bool autoEditenabled, String file)
        {
            piwik.sendFeatreUseageStats(TDFPiwik.Features.OpenBootstrap);
            bool working = true;
            if (file == null)
                file = Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic);
            try
            {
                bootstrap_text.Text = System.IO.File.ReadAllText(file);
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                working = false;
                if (!autoEditenabled)
                {

                    return working;
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                working = false;
                if (!autoEditenabled)
                {
                    if (open_bootstrap.ShowDialog() == DialogResult.OK)
                    {
                        working = secondtry(open_bootstrap.FileName);
                    }
                    return working;
                }
            }

            catch (Exception ex)
            {
                working = false;
                if (!autoEditenabled)
                {
                    exceptionmessage(ex.Message);
                    return working;
                }
            }
            if (working)
            {
                save_file.Enabled = true;
                bootinipath.Text = file;
                if (autoEditenabled)
                    editbs();
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
                exceptionmessage(ex.Message);
            }
            if (working)
            {
                save_file.Enabled = true;
                bootinipath.Text = path;
            }
            return working;

        }
        private void editbs()
        {
            give_message.ShowBalloonTip(2000, getstring("tt_editbs_tit"), getstring("tt_editbs_txt"), ToolTipIcon.Info);
            int start = bootstrap_text.Text.IndexOf("UserInstallation");
            int end = bootstrap_text.Text.IndexOf(Environment.NewLine, start);
            string substring = bootstrap_text.Text.Substring(start, end - start);
            bootstrap_text.Text = bootstrap_text.Text.Replace(substring, "UserInstallation=$ORIGIN/..");
            save_bootstrap(true);
            bootinipath.Text = "";
            bootstrap_text.Text = "";
        }
        private void save_bootstrap(object sender, EventArgs e)
        {
            save_bootstrap(false);
        }
        private void save_bootstrap(bool quiet)
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
                    piwik.sendFeatreUseageStats(TDFPiwik.Features.SaveBootstrap);
                    if (!quiet)
                        MessageBox.Show(getstring("filesave"), getstring("title_filesave"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    exceptionmessage(exeptiontext);
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
            piwik.sendFeatreUseageStats(TDFPiwik.Features.Open_Installer);
        }
        public void exceptionmessage(string ex_message)
        {
            MessageBox.Show(getstring("standarderror") + " " + ex_message, getstring("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public string getstring(string strMessage)
        {
            string rt = "??? + ("+strMessage+")";
            try
            {
                rt = rm.GetString(strMessage).Replace(":n:", Environment.NewLine).Replace(":nl:", Environment.NewLine);
            }
            catch (Exception)
            {
                exceptionmessage("An error in the l10n part occured!");
            }
            return rt;

        }

        // Function, which prepares the data, which should be saved for next startup


        private void create_ink_Click(object sender, EventArgs e)
        {
            bool ok = true;
            piwik.sendFeatreUseageStats(TDFPiwik.Features.CreateInk);
            try
            {
                if (tb_version.Text == "")
                    throw new Exception(getstring("ink_error_1"));
                if (path_to_exe.Text == "")
                    throw new Exception(getstring("ink_error_2"));
                WshShell wsh = new WshShell();
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "LibO Parallel " + tb_version.Text + ".lnk");
                IWshShortcut shortcut = (IWshShortcut)wsh.CreateShortcut(@path);
                string des = getstring("ink_des");
                des = des.Replace("%version", tb_version.Text);
                shortcut.Description = des;
                shortcut.TargetPath = path_to_exe.Text;
                shortcut.Save();
            }
            catch (Exception ex)
            {
                exceptionmessage(ex.Message);
                ok = false;
            }
            finally
            {
                if (ok)
                    MessageBox.Show(getstring("msb_lnk_txt"), getstring("msb_lnk_title"), MessageBoxButtons.OK);
            }

        }

        private void m_about_Click(object sender, EventArgs e)
        {
            openSettings();
        }

        private void m_man_Click(object sender, EventArgs e)
        {
            openManager();
        }

        private void m_help_Click(object sender, EventArgs e)
        {
            openHelp();
        }
        private void validate_filename(object sender, EventArgs e)
        {
            if (path_main.Text.Contains("exe") || path_help.Text.Contains("exe"))
            {
                start_install.Enabled = false;
                if (path_main.Text.Contains("exe"))
                    path_main.ForeColor = Color.Red;
                else
                    path_help.ForeColor = Color.Red;
            }
            else
            {
                start_install.Enabled = true;
                path_main.ForeColor = Color.Black;
                path_help.ForeColor = Color.Black;
            }
            path_main.Update();
            path_help.Update();
            savesettings();
        }
        private string[] dl_list;
        private int selected_item;
        private void update_versions_Click(object sender, EventArgs e)
        {
            piwik.sendFeatreUseageStats(TDFPiwik.Features.Update_ListOfVersion);
            dl_list = getLibO_List_of_DL();
            update_changingVersions();
            loadVersionstoList();
        }
        private void loadVersionstoList()
        {
            dl_versions.BeginUpdate();
            selected_item = dl_versions.SelectedIndex;
            dl_versions.Items.Clear();
            foreach (string s in dl_special)
                dl_versions.Items.Add(s);
            foreach (ChangingDLInfo item in dlInfos)
                dl_versions.Items.Add(item.ToString());
            dl_versions.Items.Add("---");
            dl_versions.Items.AddRange(dl_list);
            dl_versions.SelectedIndex = selected_item;
            dl_versions.EndUpdate();
            savesettings();
        }
        private void update_changingVersions()
        {
            string url = "http://dev-builds.libreoffice.org/si-gui/.dlinfo/info.txt";
            System.Net.WebClient wc = getPreparedWebClient();
            string[] info = wc.DownloadString(url).Replace("\r\n", "\n").Split(new char[] { '\n' });
            dlInfos = ChangingDLInfo.Parse(info);
        }

        private static int versionsFixed = 3;
        private void start_dl_Click(object sender, EventArgs e)
        {
            piwik.sendFeatreUseageStats(TDFPiwik.Features.StartDL);
            if (dl_versions.SelectedItem != null)
            {
                int index = dl_versions.SelectedIndex;
                if ((index == versionsFixed || (index == (versionsFixed + dlInfos.Length + 1))))
                    return;
                if (index < versionsFixed)
                {
                    switch (index)
                    {
                        case (0):
                            // Latest branch
                            if (cb_installer.Checked)
                            {
                                asyncdl_wrapper(enum4DL_Special.LB, false);
                            }
                            if (cb_help.Checked)
                            {
                                asyncdl_wrapper(enum4DL_Special.LB, true);
                            }
                            break;
                        case (1):
                            // Older branch
                            if (cb_installer.Checked)
                            {
                                asyncdl_wrapper(enum4DL_Special.OB, false);
                            }
                            if (cb_help.Checked)
                            {
                                asyncdl_wrapper(enum4DL_Special.OB, true);
                            }
                            break;
                        case (2):
                            // Testing
                            if (cb_installer.Checked)
                            {
                                asyncdl_wrapper(enum4DL_Special.T, false);
                            }
                            if (cb_help.Checked)
                            {
                                asyncdl_wrapper(enum4DL_Special.T, true);
                            }
                            break;
                    }
                }
                else
                {
                    // Selected Thinderboxes
                    if (index <= versionsFixed + dlInfos.Length)
                    {
                        ChangingDLInfo info = dlInfos[index - (versionsFixed + 1)];
                        bool helppack = info.helppackAvailable && cb_help.Checked;
                        if (cb_installer.Checked)
                            // asyncdl_wrapper(info.url,false);
                            download_any_version(info.url, false);
                        if (helppack)
                            download_any_version(info.url, true);
                    }
                    else
                    {

                        string link = get_final_link(true, dl_versions.SelectedItem.ToString());
                        if (cb_installer.Checked)
                        {
                            download_any_version(link, false);
                        }
                        if (cb_help.Checked)
                        {
                            download_any_version(link, true);
                        }
                    }
                }
            }

        }

        private void reset_pathMain_Click(object sender, EventArgs e)
        {
            path_main.Text = "";
            piwik.sendFeatreUseageStats(TDFPiwik.Features.FreeInstallerField);
        }

        private void delete_pathHelp_Click(object sender, EventArgs e)
        {
            path_help.Text = "";
            piwik.sendFeatreUseageStats(TDFPiwik.Features.FreeInstallerField);
        }

        private void go_pathMain_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(path_main.Text);
                piwik.sendFeatreUseageStats(TDFPiwik.Features.RunInstaller);
            }
            catch (Exception ex)
            {
                exceptionmessage(ex.Message);
            }
        }

        private void go_pathhelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(path_help.Text);
                piwik.sendFeatreUseageStats(TDFPiwik.Features.RunInstaller);
            }
            catch (Exception ex)
            {
                exceptionmessage(ex.Message);
            }
        }

        private void checkUpdate(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                string file = Path.Combine(Path.GetTempPath(), "si-gui.application");
                wc.DownloadFile("http://dev-builds.libreoffice.org/si-gui/LibreOffice%20Server%20Install%20GUI.application", file);
                Process.Start(file);
                Environment.Exit(0);
            }
            catch (Exception) { }
        }

        private void cancel_dl_Click(object sender, EventArgs e)
        {
            resetDL();
        }

        private void show_gb_bs_Click(object sender, EventArgs e)
        {
            gb_bootstrap.Visible = !gb_bootstrap.Visible;
            gb_create_lnk.Visible = !gb_create_lnk.Visible;
            gb_download.Visible = !gb_download.Visible;
            gb_installation.Visible = !gb_installation.Visible;
            if (gb_bootstrap.Visible)
                show_gb_bs.Text = getstring("back");
            else
                show_gb_bs.Text = gb_bootstrap.Text;
        }

        private void checkFileExists(object sender, CancelEventArgs e)
        {
            // Checking of installer and help package
            TextBox t = (TextBox)sender;
            t.Text = doValidateInstaller(t.Text);

        }
        private String doValidateInstaller(String file)
        {
            if (file != "")
            {
                FileStream f = null;
                try
                {
                    f = System.IO.File.Open(file, System.IO.FileMode.Open);
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    file = "";
                    exceptionmessage(ex.Message);
                }
                finally
                {
                    if (f != null)
                        f.Close();
                }
            }
            return file;
        }

        private void validateInstalldir(object sender, CancelEventArgs e)
        {

            TextBox t = (TextBox)sender;
            if (t.Text != "" && !System.IO.Directory.Exists(t.Text))
            {
                DialogResult dr = MessageBox.Show(getstring("no_installdir") + Environment.NewLine + getstring("createdir").Replace("%folder%", t.Text), getstring("Error"), MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr != System.Windows.Forms.DialogResult.Yes)
                {
                    t.Text = "";
                }
                else
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(t.Text);
                    }
                    catch (Exception)
                    {
                        t.Text = "";
                    }

                }
            }
        }

        private void tidyUponClose(object sender, FormClosingEventArgs e)
        {
            savesettings();
        }
    }
}
