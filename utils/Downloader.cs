#region Licence
/*This file is part of the project "Reisisoft Server Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */
#endregion
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml.Serialization;
using System.IO;

namespace SI_GUI
{
    public class Downloader
    {
        // Enum which things should be downloaded
        public enum Branch { M, LB, OB, T };
        public enum Version { MAIN, HP, SDK };
        //Easy file names --> Setting
        private static string hp_easy = "libo_help", main_easy = "libo_main", sdk_easy = "libo_sdk";
        //The folder to save the files in
        private string folder;
        //Should the easy file names be used
        private bool easyFilenames;
        //UI components used, which is used to show the progess
        private ProgressBar progress;
        private MainUI mainui;
        private Label percentLabel;
        private Button startDownload;
        private ComboBox languages;
        private string programVersion;
        public void setEasyFileNames(bool efn)
        {
            easyFilenames = efn;
        }
        public void setFolderPath(string path)
        {
            folder = path;
        }
        public string getstring(string s)
        {
            return mainui.getstring(s);
        }
        public void exceptionmessage(string s)
        {
            mainui.exceptionmessage(s);
        }
        public Downloader(SETTINGS s, string version, ProgressBar pb, MainUI ui, Label percentage, Button startDownload, ComboBox languages)
            : this(s.DL_saved_settings.download_path, !s.cb_advanced_filenames, pb, ui, percentage, startDownload, languages, version)
        { }
        public Downloader(string folder, bool easyFilenames, ProgressBar pb, MainUI ui, Label percentage, Button startDownload, ComboBox languages, string version)
        {
            this.folder = folder;
            this.easyFilenames = easyFilenames;
            progress = pb;
            mainui = ui;
            percentLabel = percentage;
            this.languages = languages;
            programVersion = version;
            this.startDownload = startDownload;
        }

        public void startStaticDL(Branch branch, Version td)
        {
            string url;
            switch (branch)
            {
                case (Branch.LB):
                    url = "http://download.documentfoundation.org/libreoffice/stable/";
                    break;
                case (Branch.OB):
                    url = "http://download.documentfoundation.org/libreoffice/stable/";
                    break;
                case (Branch.T):
                    url = "http://dev-builds.libreoffice.org/pre-releases/win/x86/";
                    break;
                default:
                    url = "";
                    break;
            }
            startAsyncDownload(url, branch, td);
        }
        // List of all web clients
        List<WebClient> list_wc = new List<WebClient>();
        Dictionary<int, long> dl_manager_current = new Dictionary<int, long>();
        Dictionary<int, long> dl_manager_total = new Dictionary<int, long>();
        Dictionary<int, Version> dl_type = new Dictionary<int, Version>();
        float sum_current, sum_total;
        float percentage;

        void download_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            sum_current = 0;
            sum_total = 0;
            if (dl_manager_current.ContainsKey(sender.GetHashCode()))
            {
                // Known dl
                dl_manager_current.Remove(sender.GetHashCode());
            }
            else
            {
                // New download
                Version v = Version.MAIN;
                if (e.TotalBytesToReceive < 20971520) //HP < 20 MB
                    v = Version.HP;
                else if (e.TotalBytesToReceive < 52428800) //  20 MB < SDK < 50 MB
                    dl_type.Add(sender.GetHashCode(), v);
                dl_manager_total.Add(sender.GetHashCode(), e.TotalBytesToReceive);
            }
            // Set already downloaded bytes
            dl_manager_current.Add(sender.GetHashCode(), e.BytesReceived);
            foreach (KeyValuePair<int, long> kvp in dl_manager_current)
            {
                sum_current += kvp.Value;
            }
            foreach (KeyValuePair<int, long> kvp in dl_manager_total)
            {
                sum_total += kvp.Value;
            }
            try
            {
                percentage = 100f * sum_current / sum_total;
                progress.Value = (int)(percentage * 100);
                percentLabel.Text = Math.Round(percentage, 2).ToString() + " %";
            }
            catch (Exception) { }
        }

        Dictionary<int, string> dllocation = new Dictionary<int, string>(); //TODO improve
        void download_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Version v;
            if (!easyFilenames)
                startDownload.Enabled = true;
            string filename;
            if (!e.Cancelled && dllocation.TryGetValue(sender.GetHashCode(), out filename))
            {
                mainui.issueNotifyBallon(10000, getstring("dl_finished_title"), getstring("dl_finished"));
                if (dl_type.TryGetValue(sender.GetHashCode(), out v))
                {
                    if (v == Version.MAIN) // Main installer
                        mainui.setPathMain(filename);
                    else if (v == Version.HP)  // Helppack
                        mainui.setPathHelp(filename);
                    else //SDK
                        mainui.setPathSDK(filename);
                    if (progress.Value == progress.Maximum)
                        resetDL();
                }
                else
                {
                    resetDL();
                }
            }
            else
                resetDL();
        }
        public void resetDL()
        {
            foreach (WebClient wc in list_wc)
                if (wc.IsBusy)
                    wc.CancelAsync();
            dl_manager_current.Clear();
            dl_manager_total.Clear();
            dl_type.Clear();
            dllocation.Clear();
            list_wc.Clear();
            progress.Value = 0;
            percentLabel.Text = "0 %";
        }
        //throws DownloadNotAvailableException
        public void startAsyncDownload(string url, Branch branch, Version version) 
        {
            // Download
            bool cont = true;
            string lang = (languages.SelectedItem == null ? null : languages.SelectedItem.ToString());
            try
            {
                if (version == Version.HP)
                {
                    if (lang == null || lang == "")
                    {
                        cont = false;
                        throw new ArgumentException();
                    }
                }
            }
            catch (Exception ex)
            {
                exceptionmessage(ex.Message);
            }
            if (cont)
            {
                string httpfile = downloadFile(url);
                if (httpfile != "error")
                {
                    if (branch == Branch.M)
                    {
                        int starting_position;
                        for (int i = 0; i < 6; i++)
                        {
                            starting_position = httpfile.IndexOf("<a href=");
                            httpfile = httpfile.Remove(0, 9 + starting_position);
                        }
                        starting_position = httpfile.IndexOf(".msi");
                        httpfile = httpfile.Remove(starting_position + 4);

                        if (version == Version.HP && (httpfile.Length != 2))
                        {
                            string vers2 = httpfile;
                            string insert = "_helppack_" + lang + ".msi";
                            starting_position = vers2.IndexOf("x86") + 3;
                            vers2 = vers2.Remove(starting_position);
                            vers2 += insert;
                            httpfile = vers2;
                        }
                    }
                    else if (branch == Branch.T)
                    {
                        int starting_position = httpfile.IndexOf("Lib");
                        // Show an error box, if no testing build is available
                        if (starting_position == -1)                           
                            throw new DownloadNotAvailableException(branch);
                        url = "http://dev-builds.libreoffice.org/pre-releases/win/x86/";
                        httpfile = httpfile.Remove(0, starting_position);
                        starting_position = httpfile.IndexOf("msi") + 3;
                        httpfile = httpfile.Remove(starting_position);

                        if (version == Version.HP && (httpfile.Length != 2))
                        {
                            string vers2 = httpfile;
                            string insert = "_helppack_" + lang + ".msi";
                            starting_position = vers2.IndexOf("x86") + 3;
                            vers2 = vers2.Remove(starting_position);
                            vers2 += insert;
                            httpfile = vers2;
                        }

                    }
                    else if (branch == Branch.LB || branch == Branch.OB)
                    {
                        int i = httpfile.IndexOf("Metadata");
                        httpfile = httpfile.Remove(0, i);
                        int max;
                        if (branch == Branch.OB)
                            max = 2;
                        else
                            max = 3;
                        for (int j = 0; j < max; j++)
                        {
                            i = httpfile.IndexOf("href=");
                            httpfile = httpfile.Remove(0, i + 6);
                        }
                        httpfile = httpfile.Remove(5);
                        url = "http://download.documentfoundation.org/libreoffice/stable/" + httpfile + "/win/x86/";
                        if (version == Version.HP)
                            httpfile = "LibreOffice_" + httpfile + "_Win_x86_helppack_" + lang + ".msi";
                        else
                            httpfile = "LibreOffice_" + httpfile + "_Win_x86.msi";
                    }
                    startDL(httpfile, url, branch, version);
                }
            }
        }

        public WebClient getPreparedWebClient()
        {
            WebClient webc = new WebClient();
            webc.Headers["User-Agent"] = "LibreOffice Server Install Gui " + programVersion;
            webc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_DownloadProgressChanged);
            webc.DownloadFileCompleted += new AsyncCompletedEventHandler(download_DownloadFileCompleted);
            return webc;
        }

        private void startDL(string programFilename, string finallink, Branch branch, Version version)
        {
            string path = folder;
            list_wc.Add(getPreparedWebClient());
            int wc = list_wc.Count - 1;
            Uri uritofile = new Uri(finallink + programFilename);
            string originalFilename = programFilename;
            if (easyFilenames)
            {
                if (programFilename.Contains("msi"))
                {
                    if (version == Version.HP)
                        programFilename = "libo_hp.msi";
                    else if (version == Version.SDK)
                        programFilename = "libo_sdk.msi";
                    else
                        programFilename = "libo_installer.msi";
                }
                else
                {
                    if (version == Version.HP)
                        programFilename = "libo_hp.exe";
                    else if (version == Version.SDK)
                        programFilename = "libo_sdk.exe";
                    else
                        programFilename = "libo_installer.exe";
                }
                startDownload.Enabled = false;
            }
            path = Path.Combine(path, programFilename);
            string mb_question = getstring("versiondl");
            mb_question = mb_question.Replace("%version", originalFilename);

            // If filename is TY, then no testing build is available
            if (programFilename.Contains("exe") || programFilename.Contains("msi"))
            {
                if (MessageBox.Show(mb_question, getstring("startdl"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    // Send stats
                    if (version != Version.HP)
                    {
                        mainui.sendStats("");
                    }
                    else
                    {
                        mainui.sendStats(languages.SelectedItem.ToString());
                    }
                    mainui.sendStatsFilename(uritofile);
                    // End send stats
                    mainui.issueNotifyBallon(5000, getstring("dl_started_title"), getstring("dl_started"));
                    set_progressbar();
                    list_wc[wc].DownloadFileAsync(uritofile, path);
                    dllocation.Add(list_wc[wc].GetHashCode(), path);
                    int k = 0;
                    if (branch != Branch.M)
                    {
                        k = originalFilename.IndexOf('~');
                        k = originalFilename.IndexOf('_', k + 1);
                        originalFilename = originalFilename.Substring(0, k);
                    }
                    else
                    {
                        k = originalFilename.IndexOf("_");
                        originalFilename = originalFilename.Remove(k);
                    }
                    if (version == Version.MAIN)
                        mainui.setSubfolder(originalFilename);
                }
                else
                    startDownload.Enabled = true;
            }
            else
            {
                MessageBox.Show(getstring("notest_txt"), getstring("notest_ti"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void downloadAnyVersion(string linkToFile, Version version)
        {
            // Get the final download links and initialize the download
            string httpfile = downloadFile(linkToFile + "?C=S;O=D");
            if (httpfile == null)
                return;
            int tmp = httpfile.IndexOf("Parent");
            httpfile = httpfile.Remove(0, tmp);
            tmp = httpfile.IndexOf("href") + 6;
            httpfile = httpfile.Remove(0, tmp);
            tmp = httpfile.IndexOf("\"");
            httpfile = httpfile.Remove(tmp);
            if (version == Version.HP)
            {
                // Helppack only

                //LibreOffice helppack
                if (httpfile.Contains("install_all"))
                {
                    // Old format
                    httpfile = httpfile.Replace("install_all_lang", "helppack_" + languages.SelectedItem.ToString());
                }
                else if (httpfile.Contains("install_multi"))
                {
                    // Newer format
                    httpfile = httpfile.Replace("install_multi", "helppack_" + languages.SelectedItem.ToString());
                }
                else
                {
                    // New format
                    httpfile = httpfile.Insert(httpfile.IndexOf("86") + 2, "_helppack_" + languages.SelectedItem.ToString());
                }

                // Start download
            }
            startDL(httpfile, linkToFile, Branch.M, version);
            //  startDL(httpfile, LinktoFile, false, helppack);
        }
        public string downloadFile(string url)
        {
            try
            {
                WebClient wc = getPreparedWebClient();
                return wc.DownloadString(url);
            }
            catch (WebException e)
            {
                exceptionmessage(e.Message);
                return null;
            }
        }
        public string[] getLibOListOfDL()
        {
            string link = "http://downloadarchive.documentfoundation.org/libreoffice/old/";
            List<string> versions = new List<string>();
            string httpfile = httpfile = downloadFile(link), tmp;
            int i;
            bool goon = true;
            // Get the version numbers of LibreOffice
            i = httpfile.IndexOf("Details") + 7;
            httpfile = httpfile.Remove(0, i);
            i = httpfile.IndexOf("sdremote-1.0.0");
            httpfile = httpfile.Remove(i);
            while (goon)
            {
                try
                {
                    i = httpfile.IndexOf("href");
                    httpfile = httpfile.Remove(0, i);
                    i = httpfile.IndexOf(">") + 1;
                    httpfile = httpfile.Remove(0, i);
                    i = httpfile.IndexOf("<") - 1;
                    tmp = httpfile.Remove(i);
                    versions.Add(tmp);
                }
                catch (System.ArgumentOutOfRangeException)
                { goon = false; }
            }
            return versions.ToArray();
        }
        private string get_final_link(string version)
        {
            return "http://downloadarchive.documentfoundation.org/libreoffice/old/" + version + "/win/x86/";

        }

        public void startArchiveDownload(string vName, Version version)
        {
            downloadAnyVersion(get_final_link(vName), version);
        }
        private void set_progressbar()
        {
            if (progress.Value == progress.Maximum || progress.Value == 0)
            {
                progress.Maximum = 10000;
                progress.Value = 0;
            }
        }
    }

}
