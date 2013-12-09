namespace SI_GUI
{
    partial class DownloadAny
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadAny));
            this.dlDesc = new System.Windows.Forms.Label();
            this.URL = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // dlDesc
            // 
            this.dlDesc.AutoSize = true;
            this.dlDesc.Location = new System.Drawing.Point(12, 9);
            this.dlDesc.Name = "dlDesc";
            this.dlDesc.Size = new System.Drawing.Size(118, 13);
            this.dlDesc.TabIndex = 0;
            this.dlDesc.Text = "Link to msi to download";
            // 
            // URL
            // 
            this.URL.Location = new System.Drawing.Point(12, 25);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(432, 20);
            this.URL.TabIndex = 1;
            this.URL.Validating += new System.ComponentModel.CancelEventHandler(this.validateURL);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(12, 51);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(188, 23);
            this.confirm.TabIndex = 2;
            this.confirm.Text = "Start download and installation";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(206, 51);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(238, 23);
            this.progress.TabIndex = 3;
            // 
            // DownloadAny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 88);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.dlDesc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadAny";
            this.Text = "DownloadAny";
            this.Load += new System.EventHandler(this.DownloadAny_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dlDesc;
        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.ProgressBar progress;
    }
}