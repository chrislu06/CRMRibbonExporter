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
using System.Xml;

namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    public partial class ServerConfigurationForm : Form
    {
        private ServerConnection _serverConn;
        private ServerConnection.Configuration _newConfig;
        string _credentialsFile = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrmServer"), "Credentials.xml");
        //public ServerConnection ServerConnection { get; set; }

        public ServerConfigurationForm()
        {
            InitializeComponent();
            this.Height = 120;
            _serverConn = new ServerConnection();
        }

        public void PopulateSavedConfigurations()
        {
            cmb_configurations.Items.Clear();
            if (_serverConn.configurations != null)
                _serverConn.configurations.Clear();

            Boolean isConfigExist = false;
            try {
                isConfigExist = _serverConn.ReadConfigurations();
            }
            catch (Exception ex) {

            }

            if (isConfigExist) 
                foreach (var config in _serverConn.configurations) 
                    cmb_configurations.Items.Add(config.ServerAddress + " : " + config.OrganizationName);

            cmb_configurations.Items.Add("<< Create new server configuration >>");
        }

        private void ServerConfiguration_Load(object sender, EventArgs e)
        {
            PopulateSavedConfigurations();
        }

        private void cmb_configurations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_configurations.SelectedIndex == cmb_configurations.Items.Count - 1)
                ToggleFormView(hideView: false);
            else
                ToggleFormView(hideView: true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_configurations.SelectedIndex >= 0 && cmb_configurations.SelectedItem.ToString() != "<< Create new server configuration >>") {
                try {
                    ServerConnection.Configuration config = _serverConn.configurations[cmb_configurations.SelectedIndex];

                    // Set IServiceManagement for the current organization.
                    IServiceManagement<IOrganizationService> orgServiceManagement =
                            ServiceConfigurationFactory.CreateManagement<IOrganizationService>(
                            config.OrganizationUri);
                    config.OrganizationServiceManagement = orgServiceManagement;

                    Views.RibbonDownloadForm ribbonDlForm = new RibbonDownloadForm(config);
                    ribbonDlForm.Show();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

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
                    _newConfig.DiscoveryUri =
                        new Uri(String.Format("https://disco.{0}/XRMServices/2011/Discovery.svc", _newConfig.ServerAddress));
                }
                else {
                    _newConfig.DiscoveryUri =
                        new Uri(String.Format("https://dev.{0}/XRMServices/2011/Discovery.svc", _newConfig.ServerAddress));

                    // Get or set the device credentials. This is required for Windows Live ID authentication. 
                    _newConfig.DeviceCredentials = Microsoft.Crm.Services.Utility.DeviceIdManager.LoadOrRegisterDevice();
                }
            }
            // Check if the server uses Secure Socket Layer (https).
            else if (cbxHttps.Checked)
                _newConfig.DiscoveryUri =
                    new Uri(String.Format("https://{0}/XRMServices/2011/Discovery.svc", _newConfig.ServerAddress));
            else
                _newConfig.DiscoveryUri =
                    new Uri(String.Format("http://{0}/XRMServices/2011/Discovery.svc", _newConfig.ServerAddress));

            // Get Login Credentials
            ClientCredentials credentials = new ClientCredentials();
            credentials.Windows.ClientCredential = new System.Net.NetworkCredential(domainAndUserName[1], tbxPassword.Text, domainAndUserName[0]);
            _newConfig.Credentials = credentials;

            // Get Target Organization
            MyCrmServiceHelper helpme = new MyCrmServiceHelper();
            OrganizationDetailCollection organizations = helpme.GetOrganizationAddressesAsList(_newConfig);

            if (organizations.Count == 1) {
                _newConfig.OrganizationName = organizations[0].FriendlyName;
                _newConfig.OrganizationUri = new Uri(organizations[0].Endpoints[EndpointType.OrganizationService]);
                SaveConfiguration();
            }
            else
            {
                this.Height = 510;
                gbxOrgs.Visible = true;
                lbOrganizations.DataSource = organizations;
                lbOrganizations.DisplayMember = "FriendlyName";
            }
        }

        private void SaveConfiguration()
        {
            FileInfo file = new FileInfo(_credentialsFile);
            // Create directory if it does not exist.
            if (!file.Directory.Exists)
                file.Directory.Create();

            // Replace the file if it exists.
            using (FileStream fs = file.Open(FileMode.Create, FileAccess.Write, FileShare.None)) {
                using (XmlTextWriter writer = new XmlTextWriter(fs, Encoding.UTF8)) {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Configurations");
                    writer.WriteFullEndElement();
                    writer.WriteEndDocument();
                }
            }

            _serverConn.SaveConfiguration(_credentialsFile, _newConfig, true);

            ClearForm();
            ToggleFormView(hideView: true);
            PopulateSavedConfigurations();
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

        private void ToggleFormView(bool hideView)
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
    }
}
