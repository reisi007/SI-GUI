﻿#region Licence

/*This file is part of the project "Reisisoft Separate Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */

#endregion Licence

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SI_GUI
{
    public partial class MainUI : Form
    {
        private List<string> availableDLOptions = new List<string>();

        private bool isInstallerSelected()
        {
            return clb_downloadSelector.CheckedItems.Contains(availableDLOptions[(int)Downloader.Version.MAIN]);
        }

        private bool isHelpSelected()
        {
            return clb_downloadSelector.CheckedItems.Contains(availableDLOptions[(int)Downloader.Version.HP]);
        }

        private bool isSDKSelected()
        {
            return clb_downloadSelector.CheckedItems.Contains(availableDLOptions[(int)Downloader.Version.SDK]);
        }

        private void setInstallerSelected(bool isSelected)
        {
            clb_downloadSelector.SetItemCheckState((int)Downloader.Version.MAIN, isSelected ? CheckState.Checked : CheckState.Unchecked);
        }

        private void setHelpSelected(bool isSelected)
        {
            clb_downloadSelector.SetItemCheckState((int)Downloader.Version.HP, isSelected ? CheckState.Checked : CheckState.Unchecked);
        }

        private void setSDKSelected(bool isSelected)
        {
            clb_downloadSelector.SetItemCheckState((int)Downloader.Version.SDK, isSelected ? CheckState.Checked : CheckState.Unchecked);
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
            thingstosave.DL_saved_settings.cb_help = isHelpSelected();
            thingstosave.DL_saved_settings.cb_installer = isInstallerSelected();
            thingstosave.DL_saved_settings.cb_sdk = isSDKSelected();
            thingstosave.DL_saved_settings.versions = dl_list;
            thingstosave.DL_saved_settings.versions_last_version = dl_versions.SelectedIndex;
            if (dlInfos != null)
                thingstosave.DL_saved_settings.changingVersion = dlInfos;
            // Save paths and filenames
            thingstosave.FilesFolders.InstallFolder = path_installdir.Text;
            thingstosave.FilesFolders.nameSubfolder = subfolder.Text;
            thingstosave.FilesFolders.lastSofficeEXE = path_to_exe.Text;
            thingstosave.FilesFolders.HelpInstalldir = path_help.Text;
            thingstosave.FilesFolders.MainInstalldir = path_main.Text;
            thingstosave.FilesFolders.SDKInstalldir = path_sdk.Text;
            thingstosave.FilesFolders.OpenFileStoredDir = initialDir;
            // Finally save to file
            set.save_settings(thingstosave);
        }

        private void loadsettings()
        {
            try
            {
                SETTINGS toapply = set.open_settings();
                //Apply settings
                cb_subfolder.Checked = toapply.cb_create_subfolder;
                downloader.setEasyFileNames(!toapply.cb_advanced_filenames);
                path_installdir.Text = toapply.FilesFolders.InstallFolder;
                subfolder.Text = toapply.FilesFolders.nameSubfolder;
                choose_lang.SelectedIndex = toapply.lang;
                path_to_exe.Text = toapply.FilesFolders.lastSofficeEXE;
                path_main.Text = toapply.FilesFolders.MainInstalldir;
                path_help.Text = toapply.FilesFolders.HelpInstalldir;
                path_sdk.Text = toapply.FilesFolders.SDKInstalldir;
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
                setInstallerSelected(toapply.DL_saved_settings.cb_installer);
                setHelpSelected(toapply.DL_saved_settings.cb_help);
                setSDKSelected(toapply.DL_saved_settings.cb_sdk);
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }
    }
}