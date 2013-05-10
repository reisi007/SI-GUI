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
        void download_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            start_install.Enabled = false;
            // Creating a double value like 2.5 %
            double temp = percentage * 100;
            temp = Math.Truncate(temp);
            progressBar1.Value = Convert.ToInt16(temp);
            temp /= 100;
            string output = Convert.ToString(temp) + " %";
            percent.Text = output;
        }

        void download_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {


            give_message.ShowBalloonTip(10000, getstring("dl_finished_title"), getstring("dl_finished"), ToolTipIcon.Info);
            path_main.Text = path_to_file_ondisk.Text;
            progressBar1.Value = 0;
            percent.Text = "0 %";
            start_install.Enabled = true;
            give_message.Text = "LibreOffice Server Installation GUI";
        #endregion
            #region Procerss for downloading helppacks
        }
        void download_hp_changed(object sender, DownloadProgressChangedEventArgs e)
        {

            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            start_install.Enabled = false;
            // Creating a double value like 2.5 %
            double temp = percentage * 100;
            temp = Math.Truncate(temp);
            progressBar2.Value = Convert.ToInt16(temp);
            temp /= 100;
            string output = Convert.ToString(temp) + " %";
            percent2.Text = output;
        }

        void download_hp_dl_completed(object sender, AsyncCompletedEventArgs e)
        {
            give_message.ShowBalloonTip(10000, getstring("dl_finished_title"), getstring("dl_finished"), ToolTipIcon.Info);
            path_help.Text = path_to_file_on_disk_2.Text;
            progressBar2.Value = 0;
            percent2.Text = "0 %";
            start_install.Enabled = true;
            give_message.Text = "LibreOffice Server Installation GUI";
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
                    string filename = "";
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
                    filename = httpfile;
                    string path = Path.GetTempPath();
                    WebClient downloadmaster = getPreparedWebClient(false);
                    WebClient download_hp = getPreparedWebClient(true);
                    
                    
                    Uri uritofile = new Uri(url + httpfile);
                    path += httpfile;
                    if (helppack)
                        path_to_file_on_disk_2.Text = path;
                    else
                        path_to_file_ondisk.Text = path;
                    string mb_question = getstring("versiondl");
                    mb_question = mb_question.Replace("%version", filename);

                    // If filename is TY, then no testing build is available
                    if (filename != "TY") 
                    {
                        if (MessageBox.Show(mb_question, getstring("startdl"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            give_message.ShowBalloonTip(5000, getstring("dl_started_title"), getstring("dl_started"), ToolTipIcon.Info);
                            if (helppack)
                                download_hp.DownloadFileAsync(uritofile, path);
                            else
                                downloadmaster.DownloadFileAsync(uritofile, path);
                            int k = 0;
                            if (!master)
                            {
                                k = filename.IndexOf("_") + 1;
                                filename = filename.Remove(0, k);
                                k = filename.IndexOf("_");
                                filename = filename.Remove(k);
                            }
                            else
                            {
                                k = filename.IndexOf("_");
                                filename = filename.Remove(k);
                            }
                            if (!helppack)
                                subfolder.Text = filename;
                        }
                    }
                    else
                    {
                        MessageBox.Show(getstring("notest_txt"), getstring("notest_ti"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
     #endregion
        private WebClient getPreparedWebClient(bool helppack)
        {
            WebClient webc = new WebClient();
            string ua = "LibreOffice Server Install Gui " + set.program_version();
            webc.Headers["User-Agent"] = ua;
            if (helppack)
            {
                webc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_hp_changed);
                webc.DownloadFileCompleted += new AsyncCompletedEventHandler(download_hp_dl_completed);
            }
            else
            {
                webc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(download_DownloadProgressChanged);
                webc.DownloadFileCompleted += new AsyncCompletedEventHandler(download_DownloadFileCompleted);
            }
            return webc;
        }

        private void download_any_version(string LinktoFile, bool helppack)
        {


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
    }
}
