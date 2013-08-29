#region Licence
/*This file is part of the project "Reisisoft Server Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Globalization;


namespace SI_GUI
{
    public partial class HelpUI : Form
    {
        bool onlyOnce = true;
        access_settings set = new access_settings();
        public HelpUI(string[] l10n, bool rtl, string lang)
        {
            if (rtl)
                RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            InitializeComponent();
            this.l10n = l10n;
            string code = "";
            // get language specific help page
            switch (lang.ToLower())
            {
                case ("pt"):
                    code = "pt";
                    break;
                default:
                    code = "en";
                    break;
            }
            this.Text = l10n[2];
            string url = "http://dev-builds.libreoffice.org/si-gui/help/" + code + ".html";
            help_browser.Navigate(url, false);


        }
        private string[] l10n;
        public void exeptionmessage(string ex_message)
        {
            MessageBox.Show(l10n[0] + ex_message, l10n[1], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loadComplete(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (onlyOnce)
            {
                help_browser.Refresh(WebBrowserRefreshOption.Completely);
                onlyOnce = false;
                this.Text += "-" + e.Url.ToString().Substring(e.Url.ToString().LastIndexOf("/") + 1)[0].ToString().ToUpper() + e.Url.ToString().Substring(e.Url.ToString().LastIndexOf("/") + 2, e.Url.ToString().LastIndexOf(".") - e.Url.ToString().LastIndexOf("/")-2);
            }
        }

    }

}
