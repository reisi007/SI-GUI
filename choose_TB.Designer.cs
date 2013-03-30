namespace WindowsFormsApplication1
{
    partial class choose_TB
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
            this.yes = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.Button();
            this.text_question = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yes
            // 
            this.yes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.yes.AutoSize = true;
            this.yes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yes.Location = new System.Drawing.Point(95, 37);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(180, 52);
            this.yes.TabIndex = 0;
            this.yes.Text = "3.1.0 RC";
            this.yes.UseVisualStyleBackColor = true;
            // 
            // no
            // 
            this.no.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.no.AutoSize = true;
            this.no.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.Location = new System.Drawing.Point(289, 37);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(180, 52);
            this.no.TabIndex = 1;
            this.no.Text = "3.2.0 RC";
            this.no.UseVisualStyleBackColor = true;
            // 
            // text_question
            // 
            this.text_question.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_question.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.text_question.Location = new System.Drawing.Point(12, 9);
            this.text_question.Name = "text_question";
            this.text_question.Size = new System.Drawing.Size(321, 20);
            this.text_question.TabIndex = 2;
            this.text_question.Text = "Which testversion of LibreOffice do you wish to download?";
            this.text_question.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // choose_TB
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(564, 101);
            this.Controls.Add(this.text_question);
            this.Controls.Add(this.no);
            this.Controls.Add(this.yes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(414, 139);
            this.Name = "choose_TB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "choose_TB";
            this.Load += new System.EventHandler(this.choose_TB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Button no;
        private System.Windows.Forms.Label text_question;
    }
}