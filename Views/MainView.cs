using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Crm.Sdk.RibbonExporter.Helpers;

namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    public partial class MainView : Form
    {
        private int childFormNumber = 0;
        MyCrmServiceHelper _myCrmHelper;

        public MainView()
        {
            InitializeComponent();
            _myCrmHelper = new MyCrmServiceHelper();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            NewServerConfigurationForm configForm = new NewServerConfigurationForm();
            configForm.MdiParent = this;
            configForm.ToggleFormView(false);
            configForm.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            PopulateSavedConfigurations();
        }

        public void UpdateStatusLabel(String labelText)
        {
            this.toolStripStatusLabel.Text = labelText;
        }

        public void UpdateProgressBar(int progressPercentage)
        {
            this.toolStripProgressBar1.Value = progressPercentage;
        }

        private void serverConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerConfigurationForm configForm = new ServerConfigurationForm();
            configForm.MdiParent = this;
            configForm.Show();
        }

        public void PopulateSavedConfigurations()
        {
            openToolStripMenuItem.DropDownItems.Clear();

            Boolean isConfigExist = false;
            try
            {
                isConfigExist = _myCrmHelper.ReadConfigurations();
                if (isConfigExist)
                {
                    int index = 1;
                    foreach (var config in _myCrmHelper.Configurations)
                    {
                        String newConfigString = index + ") " + config.ServerAddress + " : " + config.OrganizationName;
                        openToolStripMenuItem.DropDownItems.Add(newConfigString, null, orgConfig_Click);
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void orgConfig_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem selectedItem = sender as ToolStripMenuItem;
            String selectedIndexString = selectedItem.Text.Split(')')[0];
            int selectedIndex = int.Parse(selectedIndexString);
            ServerConnection.Configuration config = _myCrmHelper.Configurations[selectedIndex - 1];
            _myCrmHelper.SetIServiceManagementForOrganization(ref config);

            Views.RibbonDownloadForm ribbonDlForm = new RibbonDownloadForm(config);
            ribbonDlForm.Text = config.ServerAddress.ToString() + ": " + config.OrganizationName;
            ribbonDlForm.MdiParent = this;
            ribbonDlForm.Show();
        }
    }
}
