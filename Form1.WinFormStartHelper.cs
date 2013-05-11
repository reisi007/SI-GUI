#region Licence
/*This file is part of the project "Reisisoft Server Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    // This file helps to start all the subwindows with the right l10n strings
    partial class Form1 : Form
    {
        // Opens the help
        private void openHelp()
        {

        }
        // Opens manager
        private void openManager()
        {

        }

        // Opens About / change language
        private void openAbout()
        {

        }

        // Opens Mass DL. If true LibO LibreOffice archives will be opened, otherwise OpenOffice
        private string openMassDL(bool Libo, string[] versions, out bool goon)
        {
            string product;
            if(Libo)
                product = "LibreOffice";
            else
                product = "OpenOffice";
            string[] l10n = new string[4];
            l10n[0] = getstring("massdl_l10n_title").Replace("%product",product);
            l10n[3] = getstring("massdl_l10n_which");
            l10n[1] = getstring("okay");
            l10n[2] = getstring("abort");
            DialogResult dl;
            goon = true;
            MassDL mb = new MassDL(l10n, versions);
                dl = mb.ShowDialog();
            if (dl != System.Windows.Forms.DialogResult.OK)
                goon = false;
            return mb.getSelectedVersion;

        }
    }
}
