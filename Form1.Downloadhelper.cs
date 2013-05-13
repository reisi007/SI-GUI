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
/*
 * This files contains all data for downloading data or files
 */
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        #region Process for DL of main program
        Dictionary<int, int> dl_manager = new Dictionary<int, int>();
        Dictionary<int, bool> dl_is_hp = new Dictionary<int, bool>();
        int sum;
        float percentage;
        void download_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            sum = 0;
            if (dl_manager.ContainsKey(sender.GetHashCode()))
            {
                // Known dl
                dl_manager.Remove(sender.GetHashCode());
            }
            else
            {
                bool isHP = false;
                if (e.TotalBytesToReceive < 104857600)
                    isHP = true;
                dl_is_hp.Add(sender.GetHashCode(), isHP);
            }
            dl_manager.Add(sender.GetHashCode(), e.ProgressPercentage);
            foreach (KeyValuePair<int, int> kvp in dl_manager)
            {
                sum += kvp.Value;
            }
            try
            {
                percentage = (float)(sum / (dl_manager.Count));
                progressBar1.Value = (int)(percentage * 100);
                percent.Text = Convert.ToString(percentage) + " %";
            }
            catch (Exception) { }
        }
        bool hp_or_installer;
        void download_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            give_message.ShowBalloonTip(10000, getstring("dl_finished_title"), getstring("dl_finished"), ToolTipIcon.Info);
            if (dl_is_hp.TryGetValue(sender.GetHashCode(), out hp_or_installer))
            {
                if (!hp_or_installer)
                    path_main.Text = path_to_file_on_disk.Text;
                else
                    path_help.Text = path_to_file_on_disk_2.Text;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Value = 0;
                    percent.Text = "0 %";
                    dl_manager.Clear();
                }
            }
            give_message.Text = "LibreOffice Server Installation GUI";
        #endregion
            #region Procerss for downloading helppacks
        }
            #endregion

        #region Download of Master, Testing, Latest as well as Older branch
        public void startasyncdownload(string url, bool testing, bool master, bool latest_branch, bool older_branch)
        {
            startasyncdownload(url, testing, master, latest_branch, older_branch, false);
        }

        public void startasyncdownload(string url, bool testing, bool master, bool latest_branch, bool older_branch, bool helppack)
        {
            // Download
            bool cont = true;
            string[] version = new string[2];
            string lang = Convert.ToString(m_hp_lang.SelectedItem.ToString());
            try
            {
                if (helppack)
                {
                    if (lang == "")
                    {
                        cont = false;
                        throw new System.InvalidOperationException(getstring("error_langpack_nolang"));
                    }
                }
            }
            catch (Exception ex)
            {
                exeptionmessage(ex.Message);
            }
            if (cont)
            {
                string httpfile = downloadfile(url);
                if (httpfile != "error")
                {
                    if (master)
                    {
                        int starting_position = httpfile.IndexOf("<a href=\"master~");
                        httpfile = httpfile.Remove(0, 9 + starting_position);
                        starting_position = httpfile.IndexOf(".msi");
                        httpfile = httpfile.Remove(starting_position + 4);
                    }
                    else if (testing)
                    {
                        int starting_position = httpfile.IndexOf("href=\"LibreOffice") + 6;
                        url = "http://dev-builds.libreoffice.org/pre-releases/win/x86/";
                        httpfile = httpfile.Remove(0, starting_position);
                        starting_position = httpfile.IndexOf("msi") + 3;
                        httpfile = httpfile.Remove(starting_position);

                        if (helppack && (httpfile.Length != 2))
                        {
                            string vers2 = httpfile;
                            string insert = "_helppack_" + lang + ".msi";
                            starting_position = vers2.IndexOf("x86") + 3;
                            vers2 = vers2.Remove(starting_position);
                            vers2 += insert;
                            httpfile = vers2;
                        }

                    }
                    else if (latest_branch)
                    {
                        int i = httpfile.IndexOf("Metadata");
                        httpfile = httpfile.Remove(0, i);
                        for (int j = 0; j < 3; j++)
                        {
                            i = httpfile.IndexOf("href=");
                            httpfile = httpfile.Remove(0, i + 6);
                        }
                        httpfile = httpfile.Remove(5);
                        url = "http://download.documentfoundation.org/libreoffice/stable/" + httpfile + "/win/x86/";
                        if (helppack)
                            httpfile = "LibreOffice_" + httpfile + "_Win_x86_helppack_" + lang + ".msi";
                        else
                            httpfile = "LibreOffice_" + httpfile + "_Win_x86.msi";

                    }
                    else if (older_branch)
                    {
                        int i = httpfile.IndexOf(">Parent Directory<");
                        httpfile = httpfile.Remove(0, i);
                        i = httpfile.IndexOf("a href");
                        i += 8;
                        httpfile = httpfile.Remove(0, i);
                        i = httpfile.IndexOf("/");
                        httpfile = httpfile.Remove(i);
                        url = "http://download.documentfoundation.org/libreoffice/stable/" + httpfile + "/win/x86/";
                        if (helppack)
                            httpfile = "LibO_" + httpfile + "_Win_x86_helppack_" + lang + ".msi";
                        else
                            httpfile = "LibO_" + httpfile + "_Win_x86_install_multi.msi";
                    }

                    startDL(httpfile, url, master, helppack);
                    set_progressbar();
                }
            }
        }
        #endregion
        private WebClient getPreparedWebClient()
        {
            WebClient webc = new WebClient();
            string ua = "LibreOffice Server Install Gui " + set.program_version();
            webc.Headers["User-Agent"] = ua;
            webc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_DownloadProgressChanged);
            webc.DownloadFileCompleted += new AsyncCompletedEventHandler(download_DownloadFileCompleted);
            return webc;
        }

        private void startDL(string program_filename, string finallink, bool master, bool helppack)
        {
            WebClient webc = getPreparedWebClient();
            string path = Path.GetTempPath();
            Uri uritofile = new Uri(finallink + program_filename);
            path += program_filename;
            if (helppack)
                path_to_file_on_disk_2.Text = path;
            else
                path_to_file_on_disk.Text = path;
            string mb_question = getstring("versiondl");
            mb_question = mb_question.Replace("%version", program_filename);

            // If filename is TY, then no testing build is available
            if (program_filename != "TY")
            {
                if (MessageBox.Show(mb_question, getstring("startdl"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    give_message.ShowBalloonTip(5000, getstring("dl_started_title"), getstring("dl_started"), ToolTipIcon.Info);
                    set_progressbar();
                    webc.DownloadFileAsync(uritofile, path);
                    int k = 0;
                    if (!master)
                    {
                        k = program_filename.IndexOf("_") + 1;
                        program_filename = program_filename.Remove(0, k);
                        k = program_filename.IndexOf("_");
                        program_filename = program_filename.Remove(k);
                    }
                    else
                    {
                        k = program_filename.IndexOf("_");
                        program_filename = program_filename.Remove(k);
                    }
                    if (!helppack)
                        subfolder.Text = program_filename;
                }
            }
            else
            {
                MessageBox.Show(getstring("notest_txt"), getstring("notest_ti"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void download_any_version(string LinktoFile, bool helppack, bool libo)
        {
            // Get the final download links and initialize the download
            WebClient webc = getPreparedWebClient();
            string httpfile;
            if (libo)
                httpfile = downloadfile(LinktoFile + "?C=S;O=D");
            else
                httpfile = downloadfile(LinktoFile);
            int tmp;
            if (libo)
            {
                tmp = httpfile.IndexOf("Parent");
                httpfile = httpfile.Remove(0, tmp);
                tmp = httpfile.IndexOf("href") + 6;
                httpfile = httpfile.Remove(0, tmp);
                tmp = httpfile.IndexOf("\"");
                httpfile = httpfile.Remove(tmp);

            }
            else
            {

            }

            if (helppack)
            {
                // Helppack only
                if (libo)
                {
                    //LibreOffice helppack
                    if (httpfile.Contains("install_all"))
                    {
                        // Old format
                        httpfile = httpfile.Replace("install_all_lang", "helppack_" + m_hp_lang.SelectedItem.ToString());
                    }
                    else
                    {
                        // New format
                        httpfile = httpfile.Insert(httpfile.IndexOf("86"), "helppack_" + m_hp_lang.SelectedItem.ToString());
                    }

                }
                else
                {
                    //OpenOffice helppack
                }
                // Start download
            }
            startDL(httpfile, LinktoFile, false, helppack);
        }
        private string downloadfile(string url)
        {
            WebClient httpfileclient = new WebClient();
            Uri urlhttp = new Uri(url);
            string httpfile = "error";
            try
            {
                Stream httptextraw = httpfileclient.OpenRead(urlhttp);
                StreamReader httpreader = new StreamReader(httptextraw);
                httpfile = httpreader.ReadToEnd();
                httptextraw.Close();
                httpreader.Close();

            }
            catch (System.Net.WebException ex)
            {
                exeptionmessage(ex.Message);

            }
            return httpfile;
        }

        // Manages the download of all versions
        private void ManageMassDL(bool hp, bool libo)
        {
            // Goon specifies, if program should go on from time to time
            bool goon = true;
            // Where to find the old versions of the program?
            string link, tmp;
            if (libo)
                link = "http://downloadarchive.documentfoundation.org/libreoffice/old/";
            else
                link = "???";
            // Download this page and extract the versions
            string httpfile = downloadfile(link);
            int i;
            List<string> versions = new List<string>();
            if (libo)
            {
                // Get the version numbers of LibreOffice
                i = httpfile.IndexOf("Details") + 7;
                httpfile = httpfile.Remove(0, i);
                i = httpfile.IndexOf("latest");
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
                    { // End of file reached
                        goon = false;
                    }
                }
            }
            else
            {
                // Get the versions of OpenOffice
            }
            //httpfile from now on contains the selected version
            httpfile = openMassDL(libo, versions.ToArray(), out goon);
            if (goon)
            {
                // Specify the link to the folder, where the release is
                if (libo)
                {
                    link = "http://downloadarchive.documentfoundation.org/libreoffice/old/" + httpfile + "/win/x86/";
                }
                else
                {

                }

                download_any_version(link, hp, libo);
            }
            else
            { exeptionmessage(getstring("massdl_error")); }

        }

        private void set_progressbar()
        {
            if (progressBar1.Value == progressBar1.Maximum || progressBar1.Value == 0)
            {
                progressBar1.Maximum = 10000;
                progressBar1.Value = 0;
            }
            //else
            //{
            //    progressBar1.Maximum += 10000;
            //}
        }
    }
}
