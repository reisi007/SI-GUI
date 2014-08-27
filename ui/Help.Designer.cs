namespace SI_GUI
{
    partial class HelpUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        #region Licence
        /*This file is part of the project "Reisisoft Server Install GUI",
        * which is licenced under LGPL v3+. You may find a copy in the source,
        * or obtain one at http://www.gnu.org/licenses/lgpl-3.0-standalone.html */
        #endregion
        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpUI));
            this.help_browser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // help_browser
            // 
            this.help_browser.AllowWebBrowserDrop = false;
            this.help_browser.CausesValidation = false;
            this.help_browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.help_browser.Location = new System.Drawing.Point(0, 0);
            this.help_browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.help_browser.Name = "help_browser";
            this.help_browser.Size = new System.Drawing.Size(637, 362);
            this.help_browser.TabIndex = 0;
            this.help_browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.loadComplete);
            // 
            // HelpUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 362);
            this.Controls.Add(this.help_browser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(653, 400);
            this.Name = "HelpUI";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Help";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser help_browser;
    }
}