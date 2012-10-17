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

namespace Microsoft.Crm.Sdk.RibbonExporter.Views
{
    public partial class ServerConfigurationForm : Form
    {
        private ServerConnection _serverConn;
        public ServerConnection ServerConnection { get; set; }

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

            Boolean isConfigExist = _serverConn.ReadConfigurations();
            if (isConfigExist)
            {
                for (int i = 0; i < _serverConn.configurations.Count; i++)
                {
                    cmb_configurations.Items.Add(_serverConn.configurations[i].ServerAddress + " : " + _serverConn.configurations[i].OrganizationName);
                }
            }
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
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            ServerConnection.Configuration config = new ServerConnection.Configuration();

            config.ServerAddress = tbxServerAddr.Text;
            if (String.IsNullOrWhiteSpace(config.ServerAddress))
                config.ServerAddress = "crm.dynamics.com";

            // Get Server Address
            config.ServerAddress = tbxServerAddr.Text;

            // One of the Microsoft Dynamics CRM Online data centers.
            if (config.ServerAddress.EndsWith(".dynamics.com", StringComparison.InvariantCultureIgnoreCase)) {
                // Check if the organization is provisioned in Microsoft Office 365.
                if (cbxOffice365.Checked) {
                    config.DiscoveryUri =
                        new Uri(String.Format("https://disco.{0}/XRMServices/2011/Discovery.svc", config.ServerAddress));
                }
                else {
                    config.DiscoveryUri =
                        new Uri(String.Format("https://dev.{0}/XRMServices/2011/Discovery.svc", config.ServerAddress));

                    // Get or set the device credentials. This is required for Windows Live ID authentication. 
                    config.DeviceCredentials = Microsoft.Crm.Services.Utility.DeviceIdManager.LoadOrRegisterDevice();
                }
            }
            // Check if the server uses Secure Socket Layer (https).
            else if (cbxHttps.Checked)
                config.DiscoveryUri =
                    new Uri(String.Format("https://{0}/XRMServices/2011/Discovery.svc", config.ServerAddress));
            else
                config.DiscoveryUri =
                    new Uri(String.Format("http://{0}/XRMServices/2011/Discovery.svc", config.ServerAddress));

            // Get Login Credentials
            ClientCredentials credentials = new ClientCredentials();
            String[] domainAndUserName = tbxDomainUsername.Text.Split('\\');

            if (domainAndUserName.Count() != 2)
            {
                lblDomainAndUsername.ForeColor = Color.Red;
                return;
            }

            credentials.Windows.ClientCredential = new System.Net.NetworkCredential(domainAndUserName[1], tbxPassword.Text, domainAndUserName[0]);
            config.Credentials = credentials;
            string credentialsFile = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrmServer"), "Credentials.xml");

            // Get Target Organization
            MyCrmServiceHelper helpme = new MyCrmServiceHelper();
            OrganizationDetailCollection organizations = helpme.GetOrganizationAddressesAsList(config);

            if (organizations.Count == 1) {
                config.OrganizationName = organizations[0].FriendlyName;
                config.OrganizationUri = new Uri(organizations[0].Endpoints[EndpointType.OrganizationService]);
            }
            else
                MessageBox.Show("more than 1 organization");


            string path = Path.GetDirectoryName(credentialsFile);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!File.Exists(credentialsFile))
                File.Create(credentialsFile);

            _serverConn.SaveConfiguration(credentialsFile, config, true);

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

        private void ToggleFormView(bool hideView)
        {
            //if (cmb_configurations.SelectedIndex == cmb_configurations.Items.Count - 1) {
            if (! hideView) {
                this.Height = 363;
                this.groupBox1.Visible = true;
            }
            else {
                this.Height = 120;
                this.groupBox1.Visible = false;
            }
        }
    }
}
