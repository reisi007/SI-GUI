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
using SI_GUI.exceptions;
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
        private string[] dl_special;
        private string[] initialDir;
        private ChangingDLInfo[] dlInfos;
        private access_settings set = new access_settings();
        private ResourceManager rm = new ResourceManager("SI_GUI.l10n.strings", Assembly.GetExecutingAssembly());
        public TDFPiwik piwik;
        //Download backend
        private Downloader downloader;
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
            SETTINGS settings = new SETTINGS();
            try
            {
                settings = set.open_settings();
                string lang = settings.l10n;
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
                    settings.l10n = lang;
                    set.save_settings(settings);
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
            initialDir = settings.FilesFolders.OpenFileStoredDir;
            if (initialDir == null)
                initialDir = new string[3];
            for (int i = 0; i < initialDir.Length; i++)
                if (initialDir[i] == null)
                    initialDir[i] = Path.GetTempPath();

            downloader = new Downloader(settings, set.program_version(), progressBar, this, percent, start_dl, choose_lang);
            choose_lang.Items.AddRange(alllang);
        }
        private void MainUI_Load(object sender, EventArgs e)
        {
            if (rtl_layout)
            {
                // Which texts should stay LTR, when using a RTL language

                subfolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_installdir.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_help.RightToLeft = System.Windows.Forms.RightToLeft.No;
                path_main.RightToLeft = System.Windows.Forms.RightToLeft.No;

            }

            //l10n start
            b_open_libo_installer.Text = getstring("open_installer");
            b_open_libo_help.Text = getstring("open_help");
            b_open_libo_sdk.Text = getstring("open_sdk");
            b_configInstalldir.Text = getstring("config_installdir");
            cb_subfolder.Text = getstring("subfolder_do");
            choose_lang_label.Text = getstring("m_l10n_langhelptxt") + ":";
            create_lnk.Text = getstring("b_create_shortcut");
            dl_versions.Text = getstring("s_version");
            gb_create_lnk.Text = create_lnk.Text;
            gb_download.Text = getstring("m_l10n_dl");
            gb_installation.Text = getstring("gb_parallel_install");
            label1.Text = getstring("s_version");
            labelProgress.Text = getstring("progress");
            m_about.Text = getstring("about");
            m_help.Text = getstring("help");
            m_man.Text = getstring("man_title");
            b_edit_bs.Text = getstring("edit_bs_ini");
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
            dl_special = new string[] { getstring("liboFresh"), getstring("liboStable"), getstring("m_l10n_t"), "---" };
            /*
            * 
            *    Set special download end
            * 
            * */
            loadsettings();
            percent.Text = "0 %";
            // Position choose_lang
            choose_lang.Location = new Point(choose_lang_label.Location.X + choose_lang_label.Width + 6, choose_lang_label.Location.Y - 3);
            choose_lang.Size = new System.Drawing.Size(dl_versions.Location.X + dl_versions.Size.Width - choose_lang.Location.X, choose_lang.Size.Height);
            openfile.InitialDirectory = Path.GetTempPath();
            openfile2.InitialDirectory = openfile.InitialDirectory;
            // Position progressbar 1
            // Start Setting tooltips
            ToolTip ink = get_ToolTip(create_lnk, getstring("tt_ink"));
            ToolTip pathtoexe = get_ToolTip(path_to_exe, getstring("tt_path_to_exe"));
            ToolTip manuallyUpdate = get_ToolTip(version, getstring("tt_autoupdate"));
            ToolTip go1 = get_ToolTip(go_patHelp, getstring("tt_go"));
            ToolTip go2 = get_ToolTip(go_pathMain, getstring("tt_go"));
            // End Setting tooltips
            //Add all available download options
            availableDLOptions.Add(getstring("gb_dl_installer"));
            availableDLOptions.Add(getstring("gb_dl_help"));
            availableDLOptions.Add("SDK");
            clb_downloadSelector.DataSource = availableDLOptions;
            // Setup message baloon
            give_message.BalloonTipClicked += new EventHandler(gm_do);
            give_message.BalloonTipClosed += new EventHandler(gm_do);
            give_message.Click += new EventHandler(gm_do);
            give_message.DoubleClick += new EventHandler(gm_do);
            bootstrapui = createBootstrapUI();
            this.BringToFront();
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
        public void sendStats(string hplang)
        {
            piwik.sendDLstats(dl_versions.SelectedIndex, dl_versions.SelectedText, hplang);
        }
        public void sendStatsFilename(Uri filename)
        {
            piwik.sendDLfilename(filename.ToString());
        }


        public void issueNotifyBallon(int timeout, string title, string text)
        {
            give_message.ShowBalloonTip(timeout, title, text, ToolTipIcon.Info);
        }

        private void gm_do(Object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filename_install = openfile.FileName;
            path_main.Text = filename_install;
            initialDir[(int)Downloader.Version.MAIN] = Path.GetDirectoryName(filename_install);
            openfile.InitialDirectory = initialDir[(int)Downloader.Version.MAIN];
        }
        private void openLibohelp(object sender, EventArgs e)
        {
            openfile2.InitialDirectory = initialDir[(int)Downloader.Version.HP];
            openfile2.ShowDialog();
            piwik.sendFeatreUseageStats(TDFPiwik.Features.Open_Help);
        }

        private void openfile2_FileOk(object sender, CancelEventArgs e)
        {
            string filename_help = openfile2.FileName;
            path_help.Text = filename_help;
            initialDir[(int)Downloader.Version.HP] = Path.GetDirectoryName(filename_help);
            openfile2.InitialDirectory = initialDir[(int)Downloader.Version.HP];
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
            doInstall(path_main.Text, path_help.Text, path_sdk.Text, getFinalInstalldir());
        }
        public void doInstall(string main, string help, string sdk, string dir)
        {

            piwik.sendFeatreUseageStats(TDFPiwik.Features.ParallelInstall_Start);
            bool install_main = main.Length > 0;
            bool install_help = help.Length > 0;
            bool install_path = dir != null;
            bool install_sdk = sdk.Length > 0;
            bool go_on = true;
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
                    string bspath = executeInstallation(install_main, install_help, install_sdk, main, help, sdk, getFinalInstalldir());
                    piwik.sendFeatreUseageStats(TDFPiwik.Features.ParallelInstall_OK);
                    bootstrapui.openbootstrap_ini(true, bspath);
                    piwik.sendFeatreUseageStats(TDFPiwik.Features.ParallelInstall_End);
                }

            }
        }
        private string getFinalInstalldir()
        {
            string path = path_installdir.Text;
            if (path.Length == 0)
            {
                return null;
            }
            if (cb_subfolder.Checked && (subfolder.Text != ""))
            {

                path += "\\" + subfolder.Text;
            }
            return path.Replace("\\\\", "\\");
        }

        private string executeInstallation(bool install_libo, bool install_help, bool install_sdk, string main, string help, string sdk, string dir)
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
            if (install_sdk)
            {
                p.StartInfo = new ProcessStartInfo("msiexec", "/qr /a \"" + sdk + "\" TARGETDIR=\"" + dir + "\"");
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
        public String getbsINIPath()
        {
            return path_to_exe.Text.Replace("soffice.exe", "bootstrap.ini");
        }







        private void open_installer_Click(object sender, EventArgs e)
        {
            openfile.InitialDirectory = initialDir[(int)Downloader.Version.MAIN];
            openfile.ShowDialog();
            piwik.sendFeatreUseageStats(TDFPiwik.Features.Open_Installer);
        }
        public void exceptionmessage(string ex_message)
        {
            MessageBox.Show(getstring("standarderror") + ":" + Environment.NewLine + ex_message, getstring("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public string getstring(string strMessage)
        {
            string rt = "??? + (" + strMessage + ")";
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
        }
        private string[] dl_list;
        private int selected_item;
        private void update_versions_Click(object sender, EventArgs e)
        {
            piwik.sendFeatreUseageStats(TDFPiwik.Features.Update_ListOfVersion);
            dl_list = downloader.getLibOListOfDL();
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
        }
        private void update_changingVersions()
        {
            string url = "http://dev-builds.libreoffice.org/si-gui/.dlinfo/" + (set.program_version().EndsWith("ing")/*testing versions*/ ? "beta" : "info") + ".txt";
            System.Net.WebClient wc = downloader.getPreparedWebClient();
            string[] info = wc.DownloadString(url).Replace("\r\n", "\n").Split(new char[] { '\n' });
            dlInfos = ChangingDLInfo.Parse(info);
        }

        private static int versionsFixed = 3;
        private void start_dl_Click(object sender, EventArgs e)
        {
            bool dl_allowed = (!downloader.isEasyFileNames() || progressBar.Value == 0) && (isInstallerSelected() || isHelpSelected() || isSDKSelected());
            if (!dl_allowed)
            {
                if (!(isHelpSelected() || isInstallerSelected() || isSDKSelected()))
                    exceptionmessage(getstring("dl_forbidded_selection"));
                else if (downloader.isEasyFileNames() && downloader.isDownloading())
                    exceptionmessage(getstring("dl_forbidded_easyNames"));
                else
                {
                    string debuginfo = "dl_allowed=false;progressbar.Value=" + progressBar.Value + "[checkstates|sdk:" + isSDKSelected() + "|help" + isHelpSelected() + "|Main" + isInstallerSelected() + "]";
                    exceptionmessage(getstring("dl_forbidden_other").Replace("%s", debuginfo));

                }
                return;
            }
            if (dl_versions.SelectedItem != null)
            {
                try
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
                                if (isInstallerSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.LB, Downloader.Version.MAIN);
                                }
                                if (isHelpSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.LB, Downloader.Version.HP);
                                }
                                if (isSDKSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.LB, Downloader.Version.SDK);
                                }
                                break;
                            case (1):
                                // Older branch
                                if (isInstallerSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.OB, Downloader.Version.MAIN);
                                }
                                if (isHelpSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.OB, Downloader.Version.HP);
                                }
                                if (isSDKSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.OB, Downloader.Version.SDK);
                                }
                                break;
                            case (2):
                                // Testing
                                if (isInstallerSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.T, Downloader.Version.MAIN);
                                }
                                if (isHelpSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.T, Downloader.Version.HP);
                                }
                                if (isSDKSelected())
                                {
                                    downloader.startStaticDL(Downloader.Branch.T, Downloader.Version.SDK);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        // Selected Thinderboxes
                        if (index <= versionsFixed + dlInfos.Length)
                        {
                            ChangingDLInfo info = dlInfos[index - (versionsFixed + 1)];
                            if (isInstallerSelected())
                                downloader.downloadAnyVersion(info.url, Downloader.Version.MAIN, Downloader.Branch.M);
                            if (info.helppackAvailable && isHelpSelected())
                                downloader.downloadAnyVersion(info.url, Downloader.Version.HP, Downloader.Branch.M);
                            if (info.sdkAvailable && isSDKSelected())
                                downloader.downloadAnyVersion(info.url, Downloader.Version.SDK, Downloader.Branch.M);
                        }
                        else
                        {
                            if (isInstallerSelected())
                            {
                                downloader.startArchiveDownload(dl_versions.SelectedItem.ToString(), Downloader.Version.MAIN);
                            }
                            if (isInstallerSelected())
                            {
                                downloader.startArchiveDownload(dl_versions.SelectedItem.ToString(), Downloader.Version.HP);
                            }
                            if (isSDKSelected())
                            {
                                downloader.startArchiveDownload(dl_versions.SelectedItem.ToString(), Downloader.Version.SDK);
                            }
                        }
                    }
                    piwik.sendFeatreUseageStats(TDFPiwik.Features.StartDL);
                }
                catch (DownloadNotAvailableException dnae)
                {
                    if (dnae.getBranch() == Downloader.Branch.T)
                        MessageBox.Show(getstring("notest_txt"), getstring("notest_ti"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        exceptionmessage(dnae.Message);
                }
                catch (MissingSettingException mse)
                {
                    exceptionmessage(mse.Message + "[ERR:SETTING_NOTSET]");
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
                string file = Path.Combine(Path.GetTempPath(), "update.application");
                wc.DownloadFile("http://dev-builds.libreoffice.org/si-gui/LibreOffice%20Server%20Install%20GUI.application", file);
                Process.Start(file);
                Environment.Exit(0);
            }
            catch (Exception) { }
        }

        private void cancel_dl_Click(object sender, EventArgs e)
        {
            downloader.cancel();
        }

        private void show_gb_bs_Click(object sender, EventArgs e)
        {
            if (bootstrapui == null)
                createBootstrapUI();
            bootstrapui.ShowDialog();
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
                catch (System.IO.IOException ex)
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
        public void setPathMain(string newPath)
        {
            path_main.Text = newPath;
        }
        public void setPathHelp(string newPath)
        {
            path_help.Text = newPath;
        }
        public void setPathSDK(string newPath)
        {
            path_sdk.Text = newPath;
        }
        public void setSubfolder(string subFolderName)
        {
            subfolder.Text = (subFolderName == null ? subfolder.Text : subFolderName);
        }

        private void resetPathSDK_Click(object sender, EventArgs e)
        {
            path_sdk.Text = "";
            piwik.sendFeatreUseageStats(TDFPiwik.Features.FreeInstallerField);
        }

        private void b_open_libo_sdk_Click(object sender, EventArgs e)
        {
            openfile3.InitialDirectory = initialDir[(int)Downloader.Version.SDK];
            openfile3.ShowDialog();
            piwik.sendFeatreUseageStats(TDFPiwik.Features.Open_SDK);
        }

        private void updateCreateShortCutText(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb_version.Text = tb.Text;
        }

        private void openfile3_FileOk(object sender, CancelEventArgs e)
        {
            string filename_sdk = openfile3.FileName;
            path_sdk.Text = filename_sdk;
            initialDir[(int)Downloader.Version.SDK] = Path.GetDirectoryName(filename_sdk);
            openfile.InitialDirectory = initialDir[(int)Downloader.Version.SDK];
        }
        private void b_open_libo_installer_DragDrop(object sender, DragEventArgs e)
        {
            acceptDnDMsiExe(path_main, e);
        }
        private void b_open_libo_help_DragDrop(object sender, DragEventArgs e)
        {
            acceptDnDMsiExe(path_help, e);
        }
        private void b_open_libo_sdk_DragDrop(object sender, DragEventArgs e)
        {
            acceptDnDMsiExe(path_sdk, e);
        }

        private void checkDnDExtensionMsiExe(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
            {
                string s = ((string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop))[0];
                if (s.EndsWith("exe") || s.EndsWith("msi"))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;

        }
        private void acceptDnDMsiExe(TextBox t, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
            {
                string s = ((string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop))[0];
                if (s.EndsWith("exe") || s.EndsWith("msi"))
                    t.Text = s;
            }
        }

        private void tb_DnD_drop(object sender, DragEventArgs e)
        {
            acceptDnDMsiExe((TextBox)sender, e);
        }

        private void checkDnDFolder(object sender, DragEventArgs e)
        {
            e.Effect = (getFolder(e) == null ? DragDropEffects.None : DragDropEffects.Copy);
        }
        private string getFolder(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
            {
                string s = ((string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop))[0];
                try
                {
                    FileAttributes attributes = System.IO.File.GetAttributes(s);
                    if (!((attributes & FileAttributes.Directory) == FileAttributes.Directory))
                    {
                        //If s is not a dir
                        s = Path.GetDirectoryName(s);
                    }
                    if (s.Length > 0)
                        return s;
                }
                catch (ArgumentException) { }
                catch (IOException) { }
            }
            return null;
        }

        private void b_configInstalldir_DragDrop(object sender, DragEventArgs e)
        {
            acceptDnDFolder(path_installdir, e);
        }

        private void acceptDnDFolder(object sender, DragEventArgs e)
        {
            string s = getFolder(e);
            if (s != null)
                ((TextBox)sender).Text = s;
        }

    }
}