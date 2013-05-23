﻿#region Licence
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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace SI_GUI
{
    public partial class Form2 : Form
    {
        access_settings set = new access_settings();
        string[] lang = new string[] {
            "En",
            "De",
            "Fr",
            "Es",
            "Sl",
            "Da",
            "He",
            "Pt",
            "Nl"};

        public Form2(string[] l10n, bool rtl)
        {
            if (rtl)
                RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            InitializeComponent();
            lang_chooser.Sorted = true;
            this.l10n = l10n;
            // Load default lang
            SETTINGS s = set.open_settings();
            lang_chooser.Items.AddRange(lang);
            try
            {
                lang_chooser.SelectedItem = s.l10n;
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
            lang_chooser.SelectedIndexChanged += new System.EventHandler(this.update_lang);
        }
        private string[] l10n;
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = l10n[0];
            string abouttxt = "";
            string translations = l10n[1] + " ";
            string translator = l10n[2] + " ";
            string de = l10n[3] + " ";
            string en = l10n[4] + " ";
            string fr = l10n[5] + " ";
            string es = l10n[6] + " ";
            string he = l10n[7] + " ";
            string pt = l10n[8] + " ";
            string nl = l10n[9] + " ";
            string programmer = l10n[10] + " ";
            string florei = "Florian Reisinger";
            string sl = l10n[11] + " ";
            string da = l10n[12] + " ";
            abouttxt = programmer + florei + Environment.NewLine + translations + Environment.NewLine;
            abouttxt += en + florei + Environment.NewLine;
            abouttxt += de + florei + Environment.NewLine;
            abouttxt += fr + "Sophie Gautier" + Environment.NewLine;
            abouttxt += es + "Adolfo Jayme Barrientos" + Environment.NewLine;
            abouttxt += sl + "Martin Srebotnjak" + Environment.NewLine;
            abouttxt += da + "Leif Lodahl" + Environment.NewLine;
            abouttxt += pt + "Carlos Moreira " + l10n[13] + " Pedro Lino" + Environment.NewLine;
            abouttxt += he + "Yaron Shahrabani" + Environment.NewLine;
            abouttxt += nl + "Joren De Cuyper" + Environment.NewLine;
            about.Text = abouttxt;
            this.Text = l10n[14];
            
        }

        public void exeptionmessage(string ex_message)
        {
            MessageBox.Show(l10n[15] + ex_message, l10n[16], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void update_lang(object sender, EventArgs e)
        {
            SETTINGS temp = set.open_settings();
            temp.l10n = Convert.ToString(lang_chooser.SelectedItem);
            set.save_settings(temp);
            MessageBox.Show(l10n[17], l10n[18], MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

    }
}
