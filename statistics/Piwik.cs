using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.ComponentModel;

namespace SI_GUI
{
    public class TDFPiwik : IDisposable
    {
        const string websiteID = "58";
        private access_settings aSet;
        private SETTINGS Set;
        string sallowed_txt;
        string sallowed_title;
        BackgroundWorker bw;
        List<string> pending_requests = new List<string>();
        ~TDFPiwik()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool dispose)
        {
            if (dispose && bw != null)
            {
                bw.Dispose();
                bw = null;
            }
        }
        public TDFPiwik(string allowed_title, string allowed_txt)
        {
            aSet = new access_settings();
            Set = aSet.open_settings();
            if (Set.Piwik.trackingID == null)
            {
                // Create new user ID
                string stemp = Environment.UserName + DateTime.Now.ToString();
                MD5 algo = MD5.Create();
                Set.Piwik.trackingID = BitConverter.ToString(algo.ComputeHash(Encoding.ASCII.GetBytes(stemp))).Replace("-", "").ToLower().Remove(16);
            }
            // Check whether GAnalytic tracking is allowed
            sallowed_title = allowed_title;
            sallowed_txt = allowed_txt.Replace("%trackingID", Set.Piwik.trackingID).Replace("nl", Environment.NewLine);
            if (!Set.Piwik.manually_set)
            {
                Set.Piwik.tracking_allowed = Tracking_allowed();
                Set.Piwik.manually_set = true;
            }
            aSet.save_settings(Set);
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(submit_piwik);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(todo);
        }
        // After doing work, check if work is pending
        void todo(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                bw.RunWorkerAsync(pending_requests[0]);
                pending_requests.RemoveAt(0);
            }
            catch (Exception) { }

        }
        // Submit data to Piwik
        void submit_piwik(object sender, DoWorkEventArgs e)
        {
            request(e.Argument.ToString());
        }
        private bool Tracking_allowed()
        {
            if (MessageBox.Show(sallowed_txt, sallowed_title, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                return true;
            else
                return false;
        }
        public enum Features { ParallelInstall_Start, ParallelInstall_OK, ParallelInstall_End, Manager, CreateInk, StartDL, OpenBootstrap, SaveBootstrap, Open_Installer, Open_Help, Open_SDK, Config_Dir, OpenDialog_Help, OpenDialog_Manager, OpenDialog_About, OpenDialogManuallyAddInstallation, Update_ListOfVersion, RunInstaller, FreeInstallerField };
        public void sendFeatreUseageStats(Features feature)
        {
            submitGA("feature_useage", feature.ToString());
        }
        public void sendStartupStats(string l10n)
        {
            if (l10n == null)
                l10n = "Default";
            submitGA("startup", l10n);
        }

        // Functions for download stats grabbing
        #region DL_Stats
        public void sendDLstats(int version, string sversion, string hp_lang)
        {
            switch (version)
            {
                case (0):
                    //LB
                    sversion = "LB";
                    break;
                case (1):
                    //OB
                    sversion = "OB";
                    break;
                case (2):
                    //T
                    sversion = "T";
                    break;
                case (3):
                    //M
                    sversion = "M";
                    break;
                default:
                    break;
            }
            if (hp_lang.Equals("sdk"))
            {
                submitGA("download", sversion, hp_lang);
            }
            else if (hp_lang != "")
            {
                sversion += "-hp";
                submitGA("download", sversion, hp_lang);
            }
            else
            {
                submitGA("download", sversion);
            }
        }

        public void sendDLfilename(string filename)
        {
            submitRequest2Queue(defaultPOST + "&url=" + filename + "&download=" + filename);
        }
        #endregion
        // Background functiond for sending data to GAnalytics
        uint i = 0;
        private string defaultPOST { get { return "apiv=1&idsite=" + websiteID + "&rec=1&_id = " + Set.Piwik.trackingID; } }
        private void submitGA(string ec, string ea, string el = "", string manualPOST = "")
        {
            string POST_Data = defaultPOST + "&url=http://si-gui.libreoffice.org&action_name=" + ec + "/" + ea;
            if (el != null)
                POST_Data += "/" + el;
            POST_Data += "&_cvar={" + getJSON(ec, ea);
            if (el != "")
                POST_Data += "," + getJSON("hp-download-lang", el);
            POST_Data += "}";
            submitRequest2Queue(POST_Data);
        }
        private void submitRequest2Queue(string POST)
        {
            if (bw.IsBusy)
                pending_requests.Add(POST);
            else
                bw.RunWorkerAsync(POST);
        }

        private void request(string POST)
        {
            if (Set.Piwik.tracking_allowed)
            {
                byte[] data = ASCIIEncoding.UTF8.GetBytes(POST);
                WebRequest request = WebRequest.Create("http://piwik.documentfoundation.org/piwik.php");
                request.Credentials = CredentialCache.DefaultCredentials;
                ((HttpWebRequest)request).UserAgent = "LibreOffice Server Install GUI Tracking";
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    Stream datastream = request.GetRequestStream();
                    datastream.Write(data, 0, data.Length);
                    datastream.Close();
                    WebResponse response = request.GetResponse();
                    response.Close();
                }
                catch (Exception)
                {
                }
            }
        }
        private string getJSON(string key, string value)
        {
            i++;
            i = (i % 5) + 1;
            return "\"" + 10 + "\":[\"" + key + "\",\"" + value + "\"]";
        }
    }
}
