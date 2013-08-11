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
    public partial class Form3 : Form
    {
        string lang = "";
        access_settings set = new access_settings();
        public Form3(string[] l10n, bool rtl, string clang)
        {
            lang = clang;
            if (rtl)
                RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            InitializeComponent();
            this.l10n = l10n;
        }
        private string[] l10n;
        public void exeptionmessage(string ex_message)
        {
            MessageBox.Show(l10n[0] + ex_message, l10n[1], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void form3load(object sender, EventArgs e)
        {
            string code = "";
            switch (lang)
            {
                case ("fr"):
                    code = "fr";
                    break;
                default:
                    code = "en";
                    break;
            }
            this.Text = l10n[2];
            string url = "http://dev-builds.libreoffice.org/si-gui/doc." + code + ".html";
            Uri uriurl = new Uri(url);
            help_browser.Url = uriurl;
        }
    }

}
