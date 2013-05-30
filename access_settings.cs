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
                XmlSerializer ser = new XmlSerializer(typeof(SETTINGS));
                StreamReader sr = new StreamReader(getfilename());
                value = (SETTINGS)ser.Deserialize(sr);
                sr.Close();
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
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
            return value;
        }
        private string getpath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Reisisoft/Server Installation GUI");

        }
        private string getfilename()
        {
            return Path.Combine(getpath(), "sigui.config");
        }
        public string program_version()
        { return "4.0.3.7"; }

        public void save_settings(SETTINGS set)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(SETTINGS));
                FileStream str = new FileStream(getfilename(), FileMode.Create);
                ser.Serialize(str, set);
                str.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }
        public string[] update_manager_array(string[] old_array, string toadd)
        {
            int arrylength = 1;
            if (old_array != null)
                arrylength = old_array.Length + 1;
            string[] new_array = new string[arrylength];
            if (old_array != null)
            {
                for (int i = 0; i <= (arrylength - 2); i++)
                {
                    new_array[i] = old_array[i];

                }
            }
            new_array[arrylength - 1] = toadd;
            return new_array;
        }
    }

    public class SETTINGS
    {
        public string installdir;
        public string name_subfolder;
        public bool cb_create_subfolder;
        public int lang;
        public string l10n;
        public string[] manager_versions;
        public string last_path_to_sofficeEXE;
        public DL_UI_settings DL_saved_settings;
        public GA_Settings GA;
    }
    public struct DL_UI_settings
    {
        public string[] versions;
        public bool cb_installer;
        public bool cb_help;
        public int versions_last_version;
        public string download_path;
    }

    public struct GA_Settings
    {
        public string trackingID;
        public bool tracking_allowed;
        public bool manually_set;
    }

    

}