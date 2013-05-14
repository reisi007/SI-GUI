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
using System.Threading;
using System.Globalization;


namespace SI_GUI
{
    public partial class manually_add_installation : Form
    {
        public string[,] manually_added { get; private set; }
        public manually_add_installation(string[] l10n)
        {
            InitializeComponent();
            this.l10n = l10n;
        }
        private string[] l10n;
        public string shared_string { get; private set; }
        public void exeptionmessage(string ex_message)
        {
            MessageBox.Show(l10n[0], l10n[1], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void manually_add_installation_Load(object sender, EventArgs e)
        {
            okay.DialogResult = System.Windows.Forms.DialogResult.OK;
            abort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            // l10n
            label2.Text = l10n[2];
            configure.Text = l10n[3];
            this.Text = l10n[4];
            abort.Text = l10n[5];
            okay.Text = l10n[6];
        }


        private void configure_Click(object sender, EventArgs e)
        {
            string path_text = "";

            if (DialogResult.OK == openFileDialog1.ShowDialog())
                path_text = openFileDialog1.FileName;

            if (path_text != "")
            {
                string delete = "\\program\\soffice.exe";
                int i = path_text.IndexOf(delete);
                try
                {
                    System.IO.File.ReadAllBytes(path_text);
                    path_text = path_text.Remove(i);
                    shared_string = path_text;
                }
                catch (Exception ex) { exeptionmessage(ex.Message); }
            }
        }

    }
}
