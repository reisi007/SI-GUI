using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SI_GUI
{
    public partial class DownloadAny : Form
    {
        string[] l10n;
        bool valid;
        public DownloadAny(string[] l10n, string path_4_download)
        {
            this.l10n = l10n;
            InitializeComponent();
        }
        private string URLonDISC = "";
        public string getURLonDISC() { return URLonDISC; }
        private void DownloadAny_Load(object sender, EventArgs e)
        {
            this.Text = l10n[0];
            dlDesc.Text = l10n[1];
            confirm.Text = l10n[2];
        }

        private void validateURL(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("http(s):*msi");
            valid = r.IsMatch(URL.Text);
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (valid)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                MessageBox.Show(l10n[3], l10n[4], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
