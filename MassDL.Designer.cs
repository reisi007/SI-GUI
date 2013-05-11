namespace WindowsFormsApplication1
{
    partial class MassDL
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
            this.versions = new System.Windows.Forms.ComboBox();
            this.whichDL = new System.Windows.Forms.Label();
            this.okay = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // versions
            // 
            this.versions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.versions.FormattingEnabled = true;
            this.versions.Location = new System.Drawing.Point(16, 29);
            this.versions.Name = "versions";
            this.versions.Size = new System.Drawing.Size(260, 21);
            this.versions.TabIndex = 0;
            this.versions.SelectedIndexChanged += new System.EventHandler(this.versions_SelectedIndexChanged);
            // 
            // whichDL
            // 
            this.whichDL.AutoSize = true;
            this.whichDL.Location = new System.Drawing.Point(13, 13);
            this.whichDL.Name = "whichDL";
            this.whichDL.Size = new System.Drawing.Size(191, 13);
            this.whichDL.TabIndex = 1;
            this.whichDL.Text = "Which version should be downloaded?";
            // 
            // okay
            // 
            this.okay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.okay.Enabled = false;
            this.okay.Location = new System.Drawing.Point(16, 56);
            this.okay.Name = "okay";
            this.okay.Size = new System.Drawing.Size(123, 39);
            this.okay.TabIndex = 2;
            this.okay.Text = "Okay";
            this.okay.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Location = new System.Drawing.Point(145, 56);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(131, 39);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Abort";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // MassDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 107);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.okay);
            this.Controls.Add(this.whichDL);
            this.Controls.Add(this.versions);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 145);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 145);
            this.Name = "MassDL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MassDL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox versions;
        private System.Windows.Forms.Label whichDL;
        private System.Windows.Forms.Button okay;
        private System.Windows.Forms.Button cancel;
    }
}