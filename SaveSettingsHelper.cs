using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SI_GUI
{
    public partial class MainUI : Form
    {
        private void savesettings(object sender, EventArgs e)
        {
            savesettings();
            // Enable or disable the DL button
            if (cb_installer.Checked || cb_help.Checked)
                start_dl.Enabled = true;
            else
                start_dl.Enabled = false;
        }

        private void savesettings()
        {
            // Changing text of version
            tb_version.Text = subfolder.Text;
            // Really save settings
            SETTINGS thingstosave = set.open_settings();
            thingstosave.cb_create_subfolder = cb_subfolder.Checked;
            thingstosave.lang = choose_lang.SelectedIndex;
            // Save download settings
            thingstosave.DL_saved_settings.cb_help = cb_help.Checked;
            thingstosave.DL_saved_settings.cb_installer = cb_installer.Checked;
            thingstosave.DL_saved_settings.versions = dl_list;
            thingstosave.DL_saved_settings.versions_last_version = dl_versions.SelectedIndex;
            thingstosave.DL_saved_settings.changingVersion =( dlInfos == null? new ChangingDLInfo[0]:dlInfos);
            // Save paths and filenames
            thingstosave.FilesFolders.InstallFolder = path_installdir.Text;
            thingstosave.FilesFolders.nameSubfolder = subfolder.Text;
            thingstosave.FilesFolders.lastSofficeEXE = path_to_exe.Text;
            thingstosave.FilesFolders.HelpInstalldir = path_help.Text;
            thingstosave.FilesFolders.MainInstalldir = path_main.Text;
            // Finally save to file
            set.save_settings(thingstosave);
        }
    }
}
