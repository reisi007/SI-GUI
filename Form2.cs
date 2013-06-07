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
using System.Resources;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace SI_GUI
{
    public partial class Form2 : Form
    {
        access_settings set = new access_settings();
        string[] lang = new string[] {
            "En",
            "De",
            "Fr",
            "Es",
            "Sl",
            "Da",
            "He",
            "Pt",
            "Nl"};
        ToolTip TTadvanced_file_renaming;
        public Form2(string[] l10n, bool rtl)
        {
            if (rtl)
                RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            InitializeComponent();
            bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            lang_chooser.Sorted = true;
            this.l10n = l10n;
            // Load default lang
            SETTINGS s = set.open_settings();
            if (s.DL_saved_settings.download_path == "")
                folder_save.Text = Path.GetTempPath();
            else
                folder_save.Text = s.DL_saved_settings.download_path;
            folder.RootFolder = Environment.SpecialFolder.MyComputer;
            lang_chooser.Items.AddRange(lang);
            try
            {
                lang_chooser.SelectedItem = s.l10n;
                ga_tracking.Checked = s.Piwik.tracking_allowed;
                ga_tracking.CheckedChanged += new EventHandler(ga_tracking_CheckedChanged);
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
            lang_chooser.SelectedIndexChanged += new System.EventHandler(this.update_lang);
            cb_advancedFilenames.Checked = s.cb_advanced_filenames;
            if (s.DL_saved_settings.download_path != null)
                folder_save.Text = s.DL_saved_settings.download_path;
            else
                folder_save.Text = Path.GetTempPath();
            TTadvanced_file_renaming = Form1.get_ToolTip(cb_advancedFilenames, l10n[22]);
        }

        void ga_tracking_CheckedChanged(object sender, EventArgs e)
        {
            SETTINGS settings = set.open_settings();
            settings.Piwik.tracking_allowed = ga_tracking.Checked;
            set.save_settings(settings);
        }
        private string[] l10n;
        private void Form2_Load(object sender, EventArgs e)
        {
            ga_tracking.Text = l10n[19];
            label1.Text = l10n[0];
            string abouttxt = "";
            string translations = l10n[1] + " ";
            string translator = l10n[2] + " ";
            string de = l10n[3] + " ";
            string en = l10n[4] + " ";
            string fr = l10n[5] + " ";
            string es = l10n[6] + " ";
            string he = l10n[7] + " ";
            string pt = l10n[8] + " ";
            string nl = l10n[9] + " ";
            string programmer = l10n[10] + " ";
            string florei = "Florian Reisinger";
            string sl = l10n[11] + " ";
            string da = l10n[12] + " ";
            abouttxt = programmer + florei + Environment.NewLine + translations + Environment.NewLine;
            abouttxt += en + florei + Environment.NewLine;
            abouttxt += de + florei + Environment.NewLine;
            abouttxt += fr + "Sophie Gautier" + Environment.NewLine;
            abouttxt += es + "Adolfo Jayme Barrientos" + Environment.NewLine;
            abouttxt += sl + "Martin Srebotnjak" + Environment.NewLine;
            abouttxt += da + "Leif Lodahl" + Environment.NewLine;
            abouttxt += pt + "Carlos Moreira " + l10n[13] + " Pedro Lino" + Environment.NewLine;
            abouttxt += he + "Yaron Shahrabani" + Environment.NewLine;
            abouttxt += nl + "Joren De Cuyper" + Environment.NewLine;
            about.Text = abouttxt;
            this.Text = l10n[14];
            B_open_folder.Text = l10n[20];
            cb_advancedFilenames.Text = l10n[21];
            bOk.Text = l10n[23];
        }
        public bool getAdvancedRenamingChecked
        {
            get
            {
                return cb_advancedFilenames.Checked;
            }
        }
        public void exeptionmessage(string ex_message)
        {
            MessageBox.Show(l10n[15] + ex_message, l10n[16], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void update_lang(object sender, EventArgs e)
        {
            SETTINGS temp = set.open_settings();
            temp.l10n = Convert.ToString(lang_chooser.SelectedItem);
            set.save_settings(temp);
            MessageBox.Show(l10n[17], l10n[18], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void B_open_folder_Click(object sender, EventArgs e)
        {
            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                folder_save.Text = folder.SelectedPath;
        }

        private void folder_save_TextChanged(object sender, EventArgs e)
        {
            SETTINGS s = set.open_settings();
            s.DL_saved_settings.download_path = folder_save.Text;
            set.save_settings(s);
        }
        public string get_download_location
        {
            get
            {
                return folder_save.Text;
            }
        }

        private void cb_advancedFilenames_CheckedChanged(object sender, EventArgs e)
        {
            SETTINGS s = set.open_settings();
            s.cb_advanced_filenames = cb_advancedFilenames.Checked;
            set.save_settings(s);
        }

    }
}
