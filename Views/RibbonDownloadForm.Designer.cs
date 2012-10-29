namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    partial class RibbonDownloadForm
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
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbxDownloadTo = new System.Windows.Forms.TextBox();
            this.lblSaveTo = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstboxExport = new System.Windows.Forms.ListBox();
            this.lblExport = new System.Windows.Forms.Label();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lstboxAvailable = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.btnBrowse);
            this.gbMain.Controls.Add(this.tbxDownloadTo);
            this.gbMain.Controls.Add(this.lblSaveTo);
            this.gbMain.Controls.Add(this.btnExport);
            this.gbMain.Controls.Add(this.btnAdd);
            this.gbMain.Controls.Add(this.btnRemove);
            this.gbMain.Controls.Add(this.lstboxExport);
            this.gbMain.Controls.Add(this.lblExport);
            this.gbMain.Controls.Add(this.lblAvailable);
            this.gbMain.Controls.Add(this.lstboxAvailable);
            this.gbMain.Location = new System.Drawing.Point(13, 12);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(713, 545);
            this.gbMain.TabIndex = 1;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Ribbon Exporter";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(533, 500);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 31);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbxDownloadTo
            // 
            this.tbxDownloadTo.Location = new System.Drawing.Point(190, 504);
            this.tbxDownloadTo.Name = "tbxDownloadTo";
            this.tbxDownloadTo.Size = new System.Drawing.Size(337, 22);
            this.tbxDownloadTo.TabIndex = 8;
            // 
            // lblSaveTo
            // 
            this.lblSaveTo.AutoSize = true;
            this.lblSaveTo.Location = new System.Drawing.Point(20, 507);
            this.lblSaveTo.Name = "lblSaveTo";
            this.lblSaveTo.Size = new System.Drawing.Size(164, 17);
            this.lblSaveTo.TabIndex = 7;
            this.lblSaveTo.Text = "Download XML Files To: ";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(614, 500);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 31);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export!";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(317, 227);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(317, 282);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstboxExport
            // 
            this.lstboxExport.FormattingEnabled = true;
            this.lstboxExport.ItemHeight = 16;
            this.lstboxExport.Location = new System.Drawing.Point(410, 61);
            this.lstboxExport.Name = "lstboxExport";
            this.lstboxExport.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstboxExport.Size = new System.Drawing.Size(272, 420);
            this.lstboxExport.TabIndex = 3;
            // 
            // lblExport
            // 
            this.lblExport.AutoSize = true;
            this.lblExport.Location = new System.Drawing.Point(527, 41);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(48, 17);
            this.lblExport.TabIndex = 2;
            this.lblExport.Text = "Export";
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(98, 41);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(65, 17);
            this.lblAvailable.TabIndex = 1;
            this.lblAvailable.Text = "Available";
            // 
            // lstboxAvailable
            // 
            this.lstboxAvailable.FormattingEnabled = true;
            this.lstboxAvailable.ItemHeight = 16;
            this.lstboxAvailable.Location = new System.Drawing.Point(28, 61);
            this.lstboxAvailable.Name = "lstboxAvailable";
            this.lstboxAvailable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstboxAvailable.Size = new System.Drawing.Size(272, 420);
            this.lstboxAvailable.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // RibbonDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 568);
            this.Controls.Add(this.gbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "RibbonDownloadForm";
            this.Text = "RibbonDownloadForm";
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstboxExport;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.ListBox lstboxAvailable;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbxDownloadTo;
        private System.Windows.Forms.Label lblSaveTo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}