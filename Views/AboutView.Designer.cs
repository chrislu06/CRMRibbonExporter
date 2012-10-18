namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    partial class AboutView
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
            if (disposing && (components != null)) {
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
            this.gbxAbout = new System.Windows.Forms.GroupBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.gbxAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAbout
            // 
            this.gbxAbout.Controls.Add(this.lblAbout);
            this.gbxAbout.Location = new System.Drawing.Point(13, 13);
            this.gbxAbout.Name = "gbxAbout";
            this.gbxAbout.Size = new System.Drawing.Size(257, 228);
            this.gbxAbout.TabIndex = 0;
            this.gbxAbout.TabStop = false;
            this.gbxAbout.Text = "About";
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(38, 51);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(71, 17);
            this.lblAbout.TabIndex = 0;
            this.lblAbout.Text = "About text";
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.gbxAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AboutView";
            this.Text = "About";
            this.gbxAbout.ResumeLayout(false);
            this.gbxAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAbout;
        private System.Windows.Forms.Label lblAbout;
    }
}