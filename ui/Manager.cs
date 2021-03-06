﻿#region Licence

/*This file is part of the project "Reisisoft Separate Install GUI",
 * which is licenced under LGPL v3+. You may find a copy in the source,
 * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */

#endregion Licence

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace SI_GUI
{
    public partial class Manager : Form
    {
        private access_settings set = new access_settings();
        private bool RTL = false;

        public Manager(string[] l10n, string[] l10n_mai, bool rtl)
        {
            if (rtl)
            {
                RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                RTL = true;
            }
            this.l10n = l10n;
            this.l10n_mai = l10n_mai;
            InitializeComponent();
        }

        private string[] l10n, l10n_mai;

        private void button1_Click(object sender, EventArgs e)
        {
            //Exit
            this.Close();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            this.Text = l10n[0];
            button1.Text = l10n[1];
            button3.Text = l10n[2];
            button2.Text = l10n[3];
            update_selector();
        }

        public void exeptionmessage(string ex_message)
        {
            MessageBox.Show(l10n[4] + ex_message, l10n[5], MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void update_selector()
        {
            SETTINGS temp = set.open_settings();
            string[] list = temp.manager_versions;

            manager_list.Items.Clear();
            if (list != null)
                foreach (string s in list)
                {
                    manager_list.Items.Add(s);
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Manually add installation
            manually_add_installation fm = new manually_add_installation(l10n_mai, RTL);
            fm.ShowDialog();
            if (fm.shared_string != null)
            {
                SETTINGS temp = set.open_settings();
                temp.manager_versions = set.update_manager_array(temp.manager_versions, fm.shared_string);
                set.save_settings(temp);
                update_selector();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Delete selected installations ...
            List<string> list = new List<string>();
            List<object> list_o = new List<object>();
            foreach (object itemChecked in manager_list.CheckedItems)
            {
                list.Add(itemChecked.ToString());
                list_o.Add(itemChecked);
            }

            string[] array = list.ToArray();
            if (array.Length == 0)
                return;
            deleteFileProgress.Visible = true;
            deleteFileProgress.Minimum = 0;
            deleteFileProgress.Maximum = array.Length + 1;
            deleteFileProgress.Value = 1;
            deleteFileProgress.Step = 1;
            deleteFileProgress.Refresh();

            for (int i = 0; i < array.Length; i++)
            {
                deleteFileProgress.PerformStep();
                deleteFileProgress.Refresh();
                try
                {
                    System.IO.Directory.Delete(array[i], true);
                }
                catch (Exception) { }
            }
            deleteFileProgress.PerformStep();
            object[] o_array = list_o.ToArray();
            foreach (object o in o_array)
            {
                manager_list.Items.Remove(o);
            }
            List<string> new_manager = new List<string>();
            foreach (string o in manager_list.Items)
            {
                new_manager.Add(o);
            }
            deleteFileProgress.Visible = false;
            SETTINGS sett = set.open_settings();
            sett.manager_versions = new_manager.ToArray();
            set.save_settings(sett);

            update_selector();
        }
    }
}