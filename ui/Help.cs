#region Licence

/*This file is part of the project "Reisisoft Separate Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */

#endregion Licence

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SI_GUI
{
    public partial class HelpUI : Form
    {
        private bool onlyOnce = true;
        private access_settings set = new access_settings();

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

                case ("it"):
                    code = "it";
                    break;

                default:
                    code = "en";
                    break;
            }
            this.Text = l10n[2];
            string url = "http://tdf.io/siguihelp" + code;
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
                this.Text += "-" + e.Url.ToString().Substring(e.Url.ToString().LastIndexOf("/") + 1)[0].ToString().ToUpper() + e.Url.ToString().Substring(e.Url.ToString().LastIndexOf("/") + 2, e.Url.ToString().LastIndexOf(".") - e.Url.ToString().LastIndexOf("/") - 2);
            }
        }
    }
}