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

namespace WindowsFormsApplication1
{
    public partial class MassDL : Form
    {
        public MassDL(string[] l10n, string[] version)
        {
            InitializeComponent();
            this.Text = l10n[0];
            okay.Text = l10n[1];
            cancel.Text = l10n[2];
            whichDL.Text = l10n[3];
            versions.Items.AddRange(version);
            okay.DialogResult = System.Windows.Forms.DialogResult.OK;
            cancel.DialogResult = System.Windows.Forms.DialogResult.Abort;
            getSelectedVersion = "error";
        }

        public string getSelectedVersion { get; private set; }

        private void MassDL_Load(object sender, EventArgs e)
        {

        }
    }
}
