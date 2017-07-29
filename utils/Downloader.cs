#region Licence

/*This file is part of the project "Reisisoft Separate Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */

#endregion Licence

using SI_GUI.exceptions;
using SI_GUI.ui.dialogs;
using SI_GUI.utils.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SI_GUI
{
    public class Downloader
    {
        // Enum which things should be downloaded
        public enum Branch { M, LB, OB, T, ARCHIVE };

        public enum Version { MAIN = 0, HP = 1, SDK = 2 };

        //Easy file names --> Setting
        private static string hp_easy = "libo_help", main_easy = "libo_main", sdk_easy = "libo_sdk";

        //The folder to save the files in
        private string dlFolder;

        //Should the easy file names be used
        private bool easyFilenames;

        //UI components used, which is used to show the progess
        private ProgressBar progress;

        private MainUI mainui;
        private Label percentLabel;
        private Button startDownload;
        private ComboBox languages;
        private string programVersion;
        private readonly string sortString = "?C=S;O=D";

        public void setEasyFileNames(bool efn)
        {
            easyFilenames = efn;
        }

        public void setDownloadFolderPath(string path)
        {
            dlFolder = path;
        }

        public string getstring(string s)
        {
            return mainui.getstring(s);
        }

        public void exceptionmessage(string s)
        {
            mainui.exceptionmessage(s);
        }

        public bool isEasyFileNames()
        {
            return easyFilenames;
        }

        public Downloader(SETTINGS s, string version, ProgressBar pb, MainUI ui, Label percentage, Button startDownload, ComboBox languages)
            : this(s.DL_saved_settings.download_path, !s.cb_advanced_filenames, pb, ui, percentage, startDownload, languages, version)
        { }

        public Downloader(string dlFolder, bool easyFilenames, ProgressBar pb, MainUI ui, Label percentage, Button startDownload, ComboBox languages, string version)
        {
            this.dlFolder = dlFolder;
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
        private List<DLFile> allDownloads = new List<DLFile>();

        private long sum_current, sum_total;

        public bool isDownloading()
        {
            return allDownloads.Count > 0;
        }

        private void download_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (cancelDl)
            {
                WebClient wc = (WebClient)sender;
                wc.CancelAsync();
                // Remove current download
                allDownloads.Remove(getDLfileFromHashCode(wc.GetHashCode()));
                cancelDl = allDownloads.Count != 0;
                return;
            }
            sum_current = 0;
            int hash = sender.GetHashCode();
            for (int i = 0; i < allDownloads.Count; i++)
            {
                DLFile download = allDownloads[i];
                if (download.hashCodeWC == hash)
                {
                    download.received = e.BytesReceived;
                    if (download.totalToreceive == 0)
                    {
                        download.totalToreceive = e.TotalBytesToReceive;
                        sum_total += download.totalToreceive;
                    }
                }
                sum_current += download.received;
            }
            try
            {
                double percentage = (100d * sum_current) / sum_total;
                progress.Value = (int)(percentage * 100);
                percentLabel.Text = Math.Round(percentage, 2).ToString() + " %";
            }
            catch (Exception) { }
            finally
            {
                set_progressbar();
            }
        }

        private void download_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled)
                mainui.give_message.ShowBalloonTip(10000, getstring("dl_finished_title"), getstring("dl_finished"), ToolTipIcon.Info);
            DLFile currentDownload = getDLfileFromHashCode(sender.GetHashCode());
            if (currentDownload != null)
            {
                switch (currentDownload.version)
                {
                    case Version.MAIN:
                        mainui.setPathMain(currentDownload.location);
                        break;

                    case Version.HP:
                        mainui.setPathHelp(currentDownload.location);
                        break;

                    case Version.SDK:
                        mainui.setPathSDK(currentDownload.location);
                        break;

                    default:
                        break;
                }
                allDownloads.Remove(currentDownload);
                if (allDownloads.Count == 0)
                {
                    cancel();
                }
            }
        }

        private DLFile getDLfileFromHashCode(int hashCode)
        {
            foreach (DLFile download in allDownloads)
                if (download.hashCodeWC == hashCode)
                    return download;
            return null;
        }

        private bool cancelDl = false;

        public void cancel()
        {
            cancelDl = true;
            progress.Value = 0;
            percentLabel.Text = "0 %";
            sum_total = 0;
            sum_current = 0;
            set_progressbar();
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
                cont = false;
            }
            if (cont)
            {
                string httpfile = downloadFile(url);
                if (httpfile != "error")
                {
                    if (branch == Branch.T)
                    {
                        int starting_position = httpfile.IndexOf("Lib");
                        // Show an error box, if no testing build is available
                        if (starting_position == -1)
                            throw new DownloadNotAvailableException(branch);
                        url = "http://dev-builds.libreoffice.org/pre-releases/win/x86/";
                        httpfile = httpfile.Remove(0, starting_position);
                        starting_position = httpfile.IndexOf("msi") + 3;
                        httpfile = httpfile.Remove(starting_position);
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
                        httpfile = downloadFile(url + sortString);
                        int hrefs = 5; // Number of hrefs before we find the needed string
                        string searchString = "href=";
                        httpfile = httpfile.Remove(0, httpfile.IndexOf("<body>"));
                        for (int j = 0; j < hrefs; j++)
                        {
                            i = httpfile.IndexOf(searchString) + 1;
                            httpfile = httpfile.Remove(0, i);
                        }
                        i = httpfile.IndexOf('"');
                        httpfile = httpfile.Remove(0, i);
                        httpfile = httpfile.Substring(1, httpfile.IndexOf("msi") + 2);
                    }
                    if (version == Version.HP)
                        httpfile = httpfile.Replace("Win_x86", "Win_x86_helppack_" + lang);
                    //Treat SDK
                    if (version == Version.SDK)
                        httpfile = httpfile.Replace("Win_x86", "Win_x86_sdk");
                    startDL(httpfile, url, branch, version);
                }
            }
        }

        public WebClient getPreparedWebClient()
        {
            WebClient webc = new WebClient();
            webc.Proxy = WebRequest.DefaultWebProxy;
            webc.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            webc.Headers["User-Agent"] = "LibreOffice Server Install Gui " + programVersion;
            webc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_DownloadProgressChanged);
            webc.DownloadFileCompleted += new AsyncCompletedEventHandler(download_DownloadFileCompleted);
            return webc;
        }

        private void startDL(string programFilename, string finallink, Branch branch, Version version)
        {
            //Check if DL folder exists
            try
            {
                Directory.CreateDirectory(dlFolder);
            }
            catch (Exception e)
            {
                dlFolder = Path.GetTempPath();
                exceptionmessage(e.Message);
            }
            //Start download
            WebClient wc = getPreparedWebClient();
            Uri uritofile = new Uri(finallink + programFilename);
            string originalFilename = programFilename;
            if (easyFilenames)
            {
                switch (version)
                {
                    case Version.MAIN:
                        programFilename = main_easy;
                        break;

                    case Version.HP:
                        programFilename = hp_easy;
                        break;

                    case Version.SDK:
                        programFilename = sdk_easy;
                        break;
                }
                programFilename += originalFilename.EndsWith(".msi") ? ".msi" : ".exe";
            }
            if (dlFolder == null)
                throw new MissingSettingException("Download path is not set");
            string path = Path.Combine(dlFolder, programFilename);
            string mb_question = getstring("versiondl");
            mb_question = mb_question.Replace("%version", originalFilename);
            // Start send stats
            if (MessageBox.Show(mb_question, getstring("startdl"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                return;
            switch (version)
            {
                case Version.HP:
                    mainui.sendStats(languages.SelectedItem.ToString());
                    break;

                case Version.SDK:
                    mainui.sendStats("sdk");
                    break;

                default:
                    mainui.sendStats("");
                    break;
            }
            mainui.sendStatsFilename(uritofile);
            // End send stats
            mainui.issueNotifyBallon(5000, getstring("dl_started_title"), getstring("dl_started"));
            wc.DownloadFileAsync(uritofile, path);
            DLFile download = new DLFile(path, version, wc.GetHashCode());
            allDownloads.Add(download);
            int k = 0;
            switch (branch)
            {
                case Branch.M:
                    k = originalFilename.IndexOf('~');
                    k = originalFilename.IndexOf('_', k + 1);
                    originalFilename = originalFilename.Substring(0, k);
                    break;

                default:
                    k = originalFilename.IndexOf("_");
                    originalFilename = originalFilename.Remove(0, k + 1);
                    k = originalFilename.IndexOf("_");
                    originalFilename = "LibreOffice " + originalFilename.Remove(k);
                    break;
            }
            if (version == Version.MAIN)
                mainui.setSubfolder(originalFilename);
        }

        public void downloadAnyVersion(string linkToFile, Version version, Branch branch)
        {
            // Get the final download links and initialize the download
            string httpfile = downloadFile(linkToFile + sortString);
            if (httpfile == null)
                return;
            if (branch == Branch.M)
            {
                string msi = ".msi\">";
                int end = httpfile.IndexOf(msi) + msi.Length - 2;
                httpfile = httpfile.Substring(0, end);
                string href = "href=\"";
                int start = httpfile.LastIndexOf(href) + href.Length;
                httpfile = httpfile.Substring(start);
            }
            else
            {
                int tmp = httpfile.IndexOf("Parent");
                httpfile = httpfile.Remove(0, tmp);
                tmp = httpfile.IndexOf("href") + 6;
                httpfile = httpfile.Remove(0, tmp);
                tmp = httpfile.IndexOf("\"");
                httpfile = httpfile.Remove(tmp);
            }
            switch (version)
            {
                case Version.HP:
                    if (httpfile.Contains("install_all"))
                    {
                        // Old format
                        httpfile = httpfile.Replace("install_all_lang", "helppack_" + languages.SelectedItem.ToString());
                    }
                    else if (httpfile.Contains("install_multi"))
                    {
                        // Old format
                        httpfile = httpfile.Replace("install_multi", "helppack_" + languages.SelectedItem.ToString());
                    }
                    else
                    {
                        // New format
                        httpfile = httpfile.Insert(httpfile.IndexOf("x") + 3, "_helppack_" + languages.SelectedItem.ToString());
                    }
                    break;

                case Version.SDK:
                    if (httpfile.StartsWith("LibO"))
                    {
                        httpfile = httpfile.Replace("LibO", "LibO-SDK");
                    }
                    else
                    {
                        httpfile = httpfile.Replace("x86", "x86_sdk");
                        httpfile = httpfile.Replace("x64", "x64_sdk");
                    }
                    break;

                default:
                    break;
            }
            startDL(httpfile, linkToFile, branch, version);
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
            string httpfile = downloadFile(link), tmp;
            int i;
            bool goon = true;
            // Get the version numbers of LibreOffice
            i = httpfile.IndexOf("Details") + 7;
            httpfile = httpfile.Remove(0, i);
            i = httpfile.IndexOf("loviewer");
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
            string url = "http://downloadarchive.documentfoundation.org/libreoffice/old/" + version + "/win";
            string tmpVersion = downloadFile(url);
            bool x64 = false;
            bool needDecision = tmpVersion.Contains("x86_64");
            if (needDecision)
            {
                DialogResult result = DialogResult.Abort;
                Architecture a = new Architecture();
                while (!(result == DialogResult.Yes || result == DialogResult.No))
                {
                    result = a.ShowDialog();
                }
                if (result == DialogResult.No)
                    x64 = true;
            }

            return url + "/" + (x64 ? "x86_64" : "x86") + "/";
        }

        public void startArchiveDownload(string vName, Version version)
        {
            downloadAnyVersion(get_final_link(vName), version, Branch.ARCHIVE);
        }

        private void set_progressbar()
        {
            if (progress.Maximum != 10000)
                progress.Maximum = 10000;
            if (progress.Value == progress.Maximum)
                progress.Value = 0;
        }
    }
}