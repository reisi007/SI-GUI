﻿using System;
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
    public class GAnalytics
    {
        const string propertyID = "58";
        string trackingID;
        private access_settings aSet;
        private SETTINGS Set;
        string sallowed_txt;
        string sallowed_title;
        BackgroundWorker bw;
        List<string> pending_requests = new List<string>();
        public GAnalytics(string allowed_title, string allowed_txt)
        {
            aSet = new access_settings();
            Set = aSet.open_settings();
            if (Set.GA.trackingID != null)
                trackingID = Set.GA.trackingID;
            else
            {
                // Create new user ID
                string stemp = Environment.UserName + DateTime.Now.ToString();
                MD5 algo = MD5.Create();
                trackingID = BitConverter.ToString(algo.ComputeHash(Encoding.ASCII.GetBytes(stemp))).Replace("-", "").ToLower();
                Set.GA.trackingID = trackingID;
            }
            // Check whether GAnalytic tracking is allowed
            sallowed_title = allowed_title;
            allowed_txt = allowed_txt.Replace(":n:", Environment.NewLine);
            sallowed_txt = allowed_txt.Replace("%trackingID", trackingID);
            if (!Set.GA.manually_set)
            {
                Set.GA.tracking_allowed = Tracking_allowed();
                Set.GA.manually_set = true;
            }
            aSet.save_settings(Set);
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(submit_piwik);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(todo);
        }

        void todo(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                bw.RunWorkerAsync(pending_requests[0]);
                pending_requests.RemoveAt(0);
            }
            catch (Exception) { }

        }

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
        public enum Features { ParallelInstall, Manager, CreateInk, StartDL, OpenBootstrap, SaveBootstrap, Open_Installer, Open_Help, Config_Dir, OpenDialog_Help, OpenDialog_Manager, OpenDialog_About, OpenDialogManuallyAddInstallation, Update_ListOfVersion };
        public void sendFeatreUseageStats(Features feature)
        {
            submitGA("feature_useage", feature.ToString());
        }
        public void sendStartupStats(string l10n)
        {
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
            if (hp_lang != "")
            {
                sversion += "-hp";
                submitGA("download", sversion, hp_lang);
            }
            else
            {
                submitGA("download", sversion);
            }
        }
        #endregion
        // Background functiond for sending data to GAnalytics
        private void submitGA(string ec, string ea)
        {
            submitGA(ec, ea, "");
        }
        
        private void submitGA(string ec, string ea, string el)
        {
            if (Set.GA.tracking_allowed)
            {
                string POST_Data = "apiv=1&idsite=" + propertyID + "&rec=1&url=http://si-gui.libreoffice.org"; // standard
                POST_Data += "&action_name=" + ec + "/" + ea;
                if (el != null)
                    POST_Data += "/" + el;
                POST_Data += "&_id=" + Set.GA.trackingID.Remove(16);
                POST_Data += "_cvar={" + getJSON("1", ec, ea);
                if (el != "")
                    POST_Data += "," + getJSON("2", ec, el);
                POST_Data += "}";
                if (bw.IsBusy)
                    pending_requests.Add(POST_Data);
                else
                    bw.RunWorkerAsync(POST_Data);
            }
        }
        private void request(string POST)
        {
            byte[] data = ASCIIEncoding.UTF8.GetBytes(POST);
            WebRequest request = WebRequest.Create("http://piwik.documentfoundation.org/piwik.php");
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = "LibreOffice Server Install GUI Tracking";
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream datastream = request.GetRequestStream();
            datastream.Write(data, 0, data.Length);
            datastream.Close();
            WebResponse response = request.GetResponse();
            response.Close();
        }
        private string getJSON(string number, string key, string value)
        {
                return "\""+ number + "\":[\"" + key + "\",\"" + value + "\"]";
        }
    }
}
