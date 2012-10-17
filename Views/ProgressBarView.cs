using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    public partial class ProgressBarView : Form
    {
        RibbonItemHelper _ribbonItemHelper;
        List<Model.RibbonItem> _itemsToDL;
        String _downloadDir;

        public ProgressBarView()
        {
            InitializeComponent();
        }

        public ProgressBarView(RibbonItemHelper helper, List<Model.RibbonItem> itemsToDL, String downloadDir)
        {
            InitializeComponent();
            this.Show();

            _ribbonItemHelper = helper;
            _itemsToDL = itemsToDL;
            _downloadDir = downloadDir;

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Action<string> callback = (file => {
                    this.Invoke((MethodInvoker)
                      delegate() {
                          lblCurrentFile.Text = file;
                      });
                });

            _ribbonItemHelper.FetchRibbonItems(_itemsToDL, _downloadDir, backgroundWorker1, callback);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblCurrentFile.Text = "";
            MessageBox.Show("Finished downloading ribbons");
            this.Close();
        }
    }
}
