using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using System.ServiceModel.Description;
using Microsoft.Crm.Sdk.RibbonExporter.Helpers;
using Microsoft.Xrm.Sdk.Discovery;
using System.Threading;

namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    public partial class NewServerConfigurationForm : Form
    {
        MyCrmServiceHelper _myCrmHelper;
        private ServerConnection.Configuration _newConfig;

        public NewServerConfigurationForm()
        {
            InitializeComponent();
            _myCrmHelper = new MyCrmServiceHelper();
        }

        /*private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Text = "Connecting";
            btnConnect.Enabled = false;

            if (cmb_configurations.SelectedIndex >= 0 && cmb_configurations.SelectedItem.ToString() != "<< Create new server configuration >>") {
                try {
                    ServerConnection.Configuration config = _myCrmHelper.Configurations[cmb_configurations.SelectedIndex];
                    config.Credentials.Windows.ClientCredential = new System.Net.NetworkCredential("tnd_dlagrew", "Welcome1", "tnd");
                    //config.Credentials.Windows.ClientCredential.UserName = "tnd\\tnd_spickford";
                    //config.Credentials.Windows.ClientCredential.Password = "Welcome1";
                    // Set IServiceManagement for the current organization.
                    _myCrmHelper.SetIServiceManagementForOrganization(ref config);

                    btnConnect.Enabled = true;
                    btnConnect.Text = "Connect";

                    Views.RibbonDownloadForm ribbonDlForm = new RibbonDownloadForm(config);
                    ribbonDlForm.Text = config.ServerAddress.ToString() + ": " + config.OrganizationName;
                    ribbonDlForm.MdiParent = this.MdiParent;
                    ribbonDlForm.Show();

                    this.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }*/

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            ResetLabels();
            bool isError = false;
            if (String.IsNullOrWhiteSpace(tbxServerAddr.Text)) {
                lblServerAddr.ForeColor = Color.Red;
                lblServerAddr.Text = "* " + lblServerAddr.Text;
                isError = true;
            }

            if (String.IsNullOrWhiteSpace(tbxDomainUsername.Text)) {
                lblDomainAndUsername.ForeColor = Color.Red;
                lblDomainAndUsername.Text = "* " + lblDomainAndUsername.Text;
                isError = true;
            }
            if (String.IsNullOrWhiteSpace(tbxPassword.Text)) {
                lblPassword.ForeColor = Color.Red;
                lblPassword.Text = "* " + lblPassword.Text;
                isError = true;
            }

            if (isError) return;

            String[] domainAndUserName = tbxDomainUsername.Text.Split('\\');

            if (domainAndUserName.Count() != 2) {
                lblDomainAndUsername.ForeColor = Color.Red;
                lblDomainAndUsername.Text = "* " + lblDomainAndUsername.Text;
                return;
            }

            _newConfig = new ServerConnection.Configuration { ServerAddress = tbxServerAddr.Text };

            if (String.IsNullOrWhiteSpace(_newConfig.ServerAddress))
                _newConfig.ServerAddress = "crm.dynamics.com";

            // One of the Microsoft Dynamics CRM Online data centers.
            if (_newConfig.ServerAddress.EndsWith(".dynamics.com", StringComparison.InvariantCultureIgnoreCase)) {
                // Check if the organization is provisioned in Microsoft Office 365.
                if (cbxOffice365.Checked) {
                    _newConfig.DiscoveryUri = new Uri(String.Format("https://disco.{0}/XRMServices/2011/Discovery.svc", _newConfig.ServerAddress));
                }
                else {
                    _newConfig.DiscoveryUri = new Uri(String.Format("https://dev.{0}/XRMServices/2011/Discovery.svc", _newConfig.ServerAddress));

                    // Get or set the device credentials. This is required for Windows Live ID authentication. 
                    _newConfig.DeviceCredentials = Microsoft.Crm.Services.Utility.DeviceIdManager.LoadOrRegisterDevice();
                }
            }
            // Check if the server uses Secure Socket Layer (https).
            else if (cbxHttps.Checked)
                _newConfig.DiscoveryUri = new Uri(String.Format("https://{0}/XRMServices/2011/Discovery.svc", _newConfig.ServerAddress));
            else
                _newConfig.DiscoveryUri = new Uri(String.Format("http://{0}/XRMServices/2011/Discovery.svc", _newConfig.ServerAddress));

            // Get Login Credentials
            ClientCredentials creds = new ClientCredentials();
            creds.Windows.ClientCredential = new System.Net.NetworkCredential(domainAndUserName[1], tbxPassword.Text, domainAndUserName[0]);
            _newConfig.Credentials = creds;

            // Get Target Organization
            OrganizationDetailCollection organizations = new OrganizationDetailCollection();
            try {
                organizations = _myCrmHelper.GetOrganizationAddressesAsList(_newConfig);
            }
            catch (System.IO.FileNotFoundException ex) {
                MessageBox.Show(String.Format("Error: {0}", ex.Message));
            }

            // If there's only one organization then use that. Otherwise present the user with the multiple options.
            if (organizations.Count == 1) {
                _newConfig.OrganizationName = organizations[0].FriendlyName;
                _newConfig.OrganizationUri = new Uri(organizations[0].Endpoints[EndpointType.OrganizationService]);
                SaveConfiguration();
            }
            else {
                this.Height = 510;
                gbxOrgs.Visible = true;
                lbOrganizations.DataSource = organizations;
                lbOrganizations.DisplayMember = "FriendlyName";
            }
        }

        private void SaveConfiguration()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _myCrmHelper.SaveConfiguration(_newConfig, true);
                _myCrmHelper.SetIServiceManagementForOrganization(ref _newConfig);
                MainView parentForm = this.MdiParent as MainView;
                parentForm.PopulateSavedConfigurations();

                Views.RibbonDownloadForm ribbonDlForm = new RibbonDownloadForm(_newConfig);
                ribbonDlForm.Text = _newConfig.ServerAddress.ToString() + ": " + _newConfig.OrganizationName;
                ribbonDlForm.MdiParent = this.MdiParent;
                ribbonDlForm.StartPosition = FormStartPosition.CenterScreen;
                ribbonDlForm.Show();

                Cursor.Current = Cursors.Default;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            tbxServerAddr.Text = "";
            tbxDomainUsername.Text = "";
            tbxPassword.Text = "";
            cbxHttps.Checked = false;
            cbxOffice365.Checked = false;
        }

        private void ResetLabels()
        {
            lblServerAddr.ForeColor = Color.Black;
            lblServerAddr.Text = "Server Address";

            lblDomainAndUsername.ForeColor = Color.Black;
            lblDomainAndUsername.Text = "Domain\\Username";

            lblPassword.ForeColor = Color.Black;
            lblPassword.Text = "Password";
        }

        public void ToggleFormView(bool hideView)
        {
            if (! hideView) {
                this.Height = 363;
                this.gbxServerConfig.Visible = true;
            }
            else {
                this.Height = 120;
                this.gbxServerConfig.Visible = false;
                this.gbxOrgs.Visible = false;
            }
        }

        private void btnSelectOrg_Click(object sender, EventArgs e)
        {
            OrganizationDetail organization = lbOrganizations.SelectedItem as OrganizationDetail;

            if (organization != null)
            {
                _newConfig.OrganizationName = organization.FriendlyName;
                _newConfig.OrganizationUri = new Uri(organization.Endpoints[EndpointType.OrganizationService]);

                SaveConfiguration();
            }
        }

        private void NewServerConfigurationForm_Load(object sender, EventArgs e)
        {

        }

    }
}
