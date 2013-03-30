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
    public partial class choose_TB : Form
    {
        public choose_TB(string[] version, string question, string window_title)
        {
            InitializeComponent();
            no.DialogResult = System.Windows.Forms.DialogResult.No;
            yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            yes.Text = version[0] + " RC";
            no.Text = version[1] + " RC";
            text_question.Text = question;
            this.Text = window_title;
            text_question.Width = this.Width - 24;
        }

        private void choose_TB_Load(object sender, EventArgs e)
        {

        }
    }
}
