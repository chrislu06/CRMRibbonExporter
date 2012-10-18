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

            Views.ProgressBarView pbView = new ProgressBarView(_ribbonItemHelper, itemsToDownload, downloadDir);
            pbView.Show();
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
    }
}
