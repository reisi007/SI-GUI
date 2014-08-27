using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SI_GUI.ui
{
    public partial class BootstrapIniUI : Form
    {
        MainUI parent;
        string[] l10n;
        public BootstrapIniUI(bool rtl, string[] l10n, MainUI parent)
        {
            this.parent = parent;
            this.l10n = l10n;
            InitializeComponent();
            if (rtl)
            {
                bootinipath.RightToLeft = System.Windows.Forms.RightToLeft.No;
                bootstrap_text.RightToLeft = System.Windows.Forms.RightToLeft.No;
                userinstallation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }
            button4.Text = l10n[0];
            gb_bootstrap.Text = l10n[1];
            save_file.Text = l10n[2];
            open_bootstrap.Title = l10n[3];
            ToolTip bootstrapini = MainUI.get_ToolTip(bootstrap_text, l10n[6]);
        }

        public bool openbootstrap_ini(bool autoEditenabled)
        {
            return openbootstrap_ini(autoEditenabled, parent.getbsINIPath());
        }

        public bool openbootstrap_ini(bool autoEditenabled, String file)
        {
            parent.piwik.sendFeatreUseageStats(TDFPiwik.Features.OpenBootstrap);
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
                    parent.exceptionmessage(ex.Message);
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
                parent.exceptionmessage(ex.Message);
            }
            if (working)
            {
                save_file.Enabled = true;
                bootinipath.Text = path;
            }
            return working;

        }
        private void open_bootstrap_Click(object sender, EventArgs e)
        {
            openbootstrap_iniFO();
        }

        private void editbs()
        {
            parent.give_message.ShowBalloonTip(2000, l10n[4], l10n[5], ToolTipIcon.Info);
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
                exeptiontext = ex.Message + " Error:UAE" + Environment.NewLine + Environment.NewLine + l10n[9];
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
                    parent.piwik.sendFeatreUseageStats(TDFPiwik.Features.SaveBootstrap);
                    if (!quiet)
                        MessageBox.Show(l10n[7], l10n[8], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    parent.exceptionmessage(exeptiontext);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userinstallation.Text = "UserInstallation=$ORIGIN/..";
        }
        private bool openbootstrap_iniFO()
        {
            if (open_bootstrap.ShowDialog() == DialogResult.OK)

                return secondtry(open_bootstrap.FileName);
            else return false;

        }

    }
}
