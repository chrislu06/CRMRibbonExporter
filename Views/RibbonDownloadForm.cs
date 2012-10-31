using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk.Client;
using System.IO;
using System.Threading;

namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    public partial class RibbonDownloadForm : Form
    {
        private OrganizationServiceProxy _serviceProxy;
        private RibbonItemHelper _ribbonItemHelper;
        List<Model.RibbonItem> _itemsToDL;
        String _downloadDir;

        public RibbonDownloadForm()
        {
            InitializeComponent();
            //lstboxAvailable = new ListBox();
            lstboxAvailable.DisplayMember = "EntityName";
        }

        public RibbonDownloadForm(ServerConnection.Configuration config)
        {
            InitializeComponent();

            lstboxAvailable.DisplayMember = "EntityName";
            lstboxExport.DisplayMember = "EntityName";

            PopulateAvailableListBoxItems(config);
        }

        private void PopulateAvailableListBoxItems(ServerConnection.Configuration config)
        {
            try {
                using (_serviceProxy = ServerConnection.GetOrganizationProxy(config)) {
                    // This statement is required to enable early-bound type support.                  
                    _serviceProxy.EnableProxyTypes();
                    _ribbonItemHelper = new RibbonItemHelper(_serviceProxy, config);
                    List<Model.RibbonItem> ribbonItems = _ribbonItemHelper.GetListOfRibbonItems().OrderBy(i => i.EntityName).ToList();
                    foreach (var item in ribbonItems) {
                        lstboxAvailable.Items.Add(item);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Model.RibbonItem> delta = new List<Model.RibbonItem>();
            foreach (var item in lstboxAvailable.SelectedItems) {
                Model.RibbonItem ritem = (Model.RibbonItem)item;
                delta.Add(ritem);
            }

            foreach (var item in delta) {
                lstboxAvailable.Items.Remove(item);
                lstboxExport.Items.Add(item);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<Model.RibbonItem> delta = new List<Model.RibbonItem>();
            foreach (var item in lstboxExport.SelectedItems) {
                Model.RibbonItem ritem = (Model.RibbonItem)item;
                delta.Add(ritem);
            }

            foreach (var item in delta) {
                lstboxExport.Items.Remove(item);
                lstboxAvailable.Items.Add(item);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (lstboxExport.Items.Count == 0)
                return;

            if (!Directory.Exists(tbxDownloadTo.Text))
            {
                MessageBox.Show(String.Format("Path \"{0}\" does not exist, please choose another", tbxDownloadTo.Text));
                return;
            }

            List<Model.RibbonItem> itemsToDownload = new List<Model.RibbonItem>();
            foreach (var item in lstboxExport.Items) {
                itemsToDownload.Add((Model.RibbonItem)item);
            }

            String downloadDir = tbxDownloadTo.Text;
            if (!Directory.Exists(downloadDir)) {
                Directory.CreateDirectory(downloadDir);
            }

            BeginRibbonDownload(_ribbonItemHelper, itemsToDownload, downloadDir);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string selectedPath = null;

            var t = new Thread((ThreadStart)(() => {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK) {
                    selectedPath = folderBrowserDialog1.SelectedPath;
                }
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            tbxDownloadTo.Text = selectedPath;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Views.AboutView about = new AboutView();
            about.Show();
        }

        private void BeginRibbonDownload(RibbonItemHelper helper, List<Model.RibbonItem> itemsToDL, String downloadDir)
        {
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
            Action<string> callback = (file =>
            {
                this.Invoke((MethodInvoker)
                  delegate()
                  {
                      MainView myParent = this.MdiParent as MainView;
                      myParent.UpdateStatusLabel(file);
                      //lblCurrentFile.Text = file;
                  });
            });

            _ribbonItemHelper.FetchRibbonItems(_itemsToDL, _downloadDir, backgroundWorker1, callback);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainView myParent = this.MdiParent as MainView;
            myParent.UpdateProgressBar(e.ProgressPercentage);
            //progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MainView myParent = this.MdiParent as MainView;
            myParent.UpdateStatusLabel("Complete");
            myParent.UpdateProgressBar(0);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Ribbon Definitions Downloaded to " + tbxDownloadTo.Text, "Visual Ribbon Exporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
