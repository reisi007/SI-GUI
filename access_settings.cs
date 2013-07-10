#region Licence
/*This file is part of the project "Reisisoft Server Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace SI_GUI
{
    class access_settings
    {
        public SETTINGS open_settings()
        {
            SETTINGS value = new SETTINGS();
            try
            {
                StreamReader sr = new StreamReader(getfilename(), Encoding.Default, false);
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(SETTINGS));
                    value = (SETTINGS)ser.Deserialize(sr);
                }
                catch (DirectoryNotFoundException)
                {
                    try
                    {
                        Directory.CreateDirectory(getpath());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        save_settings(new SETTINGS());
                    }
                }
                catch (Exception) { }
                finally
                {
                    sr.Close();
                }
            }
            catch { }

            return value;
        }
        private string getpath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Reisisoft/Server Installation GUI");

        }
        private string getfilename()
        {
            return Path.Combine(getpath(), "sigui.settings");
        }
        public string program_version()
        { return "4.1.0.6"; }

        public void save_settings(SETTINGS set)
        {
            try
            {
                StreamWriter str = new StreamWriter(getfilename(), false, Encoding.Default);
                try
                {
                    XmlSerializer ser = new XmlSerializer(typeof(SETTINGS));
                    ser.Serialize(str, set);
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.Message);

#endif
                }
                finally
                {
                    str.Close();
                }
            }

            catch { }
        }
        public string[] update_manager_array(string[] oldarray, string toadd)
        {
            if (oldarray == null || !oldarray.Contains(toadd))
            {
                string[] newarray;
                if (oldarray == null)
                    newarray = new string[1];
                else
                {
                    newarray = new string[oldarray.Length + 1];
                    oldarray.CopyTo(newarray, 0);
                }
                newarray[newarray.Length - 1] = toadd;
                return newarray;
            }
            return oldarray;

        }
    }
    # region SETTINGS (File-format)
    // Setting file format definition
    public class SETTINGS
    {
        public SETTINGS()
        {
            // Default settings
            cb_create_subfolder = true;
            cb_advanced_filenames = false;
            cb_autoedit_bs = true;
            DL_saved_settings.cb_help = false;
            DL_saved_settings.cb_installer = true;
            Piwik.manually_set = false;
            Piwik.tracking_allowed = false;
        }
        public bool cb_create_subfolder;
        public bool cb_advanced_filenames;
        public bool cb_autoedit_bs;
        public int lang;
        public string l10n;
        public string[] manager_versions;
        public DL_UI_settings DL_saved_settings;
        public TDFPiwik_Settings Piwik;
        public FFNames FilesFolders;
    }
    public struct DL_UI_settings
    {
        public string[] versions;
        public bool cb_installer;
        public bool cb_help;
        public int versions_last_version;
        public string download_path;
    }

    public struct TDFPiwik_Settings
    {
        public string trackingID;
        public bool tracking_allowed;
        public bool manually_set;
    }
    public struct FFNames
    {
        public string InstallFolder;
        public string nameSubfolder;
        public string lastSofficeEXE;
        public string MainInstalldir;
        public string HelpInstalldir;
    }
    #endregion
}