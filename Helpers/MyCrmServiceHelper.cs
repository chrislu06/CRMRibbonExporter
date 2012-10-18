using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Sdk;
using System.IO;
using System.Xml;

namespace Microsoft.Crm.Sdk.RibbonExporter.Helpers
{
    public class MyCrmServiceHelper
    {
        private ServerConnection _serverConn;
        private string _credentialsFile = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrmServer"), "Credentials.xml");

        public MyCrmServiceHelper()
        {
            _serverConn =  new ServerConnection();
        }

        public Boolean ReadConfigurations()
        {
            if (_serverConn.configurations != null)
                _serverConn.configurations.Clear();

            return _serverConn.ReadConfigurations();
        }

        public void SaveConfiguration(ServerConnection.Configuration config, bool append)
        {
            FileInfo file = new FileInfo(_credentialsFile);
            // Create directory if it does not exist.
            if (!file.Directory.Exists)
                file.Directory.Create();

            // If the file exists, try to append to it
            if (File.Exists(_credentialsFile)) {
                try {
                    _serverConn.SaveConfiguration(_credentialsFile, config, append);
                }
                catch (Exception ex) {
                    // error appending (possibly invalid XML), just overwrite the file
                    CreateNewCredentialsFile(file);
                    _serverConn.SaveConfiguration(_credentialsFile, config, append);
                }
            }
            else {
                // File doesn't exist, create a new one
                CreateNewCredentialsFile(file);
                _serverConn.SaveConfiguration(_credentialsFile, config, append);
            }
        }

        private void CreateNewCredentialsFile(FileInfo file)
        {
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
        }

        public void SetIServiceManagementForOrganization(ref ServerConnection.Configuration config)
        {
            IServiceManagement<IOrganizationService> orgServiceManagement =
                            ServiceConfigurationFactory.CreateManagement<IOrganizationService>(
                            config.OrganizationUri);
            config.OrganizationServiceManagement = orgServiceManagement;
        }

        public OrganizationDetailCollection GetOrganizationAddressesAsList(ServerConnection.Configuration config)
        {
            OrganizationDetailCollection orgs = new OrganizationDetailCollection();
            using (DiscoveryServiceProxy serviceProxy = GetDiscoveryProxy(config)) {
                // Obtain organization information from the Discovery service. 
                if (serviceProxy != null)
                    orgs = DiscoverOrganizations(serviceProxy);
            }
            return orgs;
        }

        /// <summary>
        /// Get the discovery service proxy based on existing configuration data.
        /// Added new way of getting discovery proxy.
        /// Also preserving old way of getting discovery proxy to support old scenarios.
        /// </summary>
        /// <returns>An instance of DiscoveryServiceProxy</returns>
        private DiscoveryServiceProxy GetDiscoveryProxy(ServerConnection.Configuration config)
        {

            IServiceManagement<IDiscoveryService> serviceManagement =
                        ServiceConfigurationFactory.CreateManagement<IDiscoveryService>(
                        config.DiscoveryUri);

            // Get the EndpointType.
            config.EndpointType = serviceManagement.AuthenticationType;

            // Get the logon credentials.
            //config.Credentials = GetUserLogonCredentials();

            AuthenticationCredentials authCredentials = new AuthenticationCredentials();

            if (!String.IsNullOrWhiteSpace(config.UserPrincipalName)) {
                // Try to authenticate the Federated Identity organization with UserPrinicipalName.
                authCredentials.UserPrincipalName = config.UserPrincipalName;

                try {
                    AuthenticationCredentials tokenCredentials = serviceManagement.Authenticate(
                        authCredentials);
                    DiscoveryServiceProxy discoveryProxy = new DiscoveryServiceProxy(serviceManagement,
                        tokenCredentials.SecurityTokenResponse);
                    // Checking authentication by invoking some SDK methods.
                    OrganizationDetailCollection orgs = DiscoverOrganizations(discoveryProxy);
                    return discoveryProxy;
                }
                catch (System.ServiceModel.Security.SecurityAccessDeniedException ex) {
                    // If authentication failed using current UserPrincipalName, 
                    // request UserName and Password to try to authenticate using user credentials.
                    if (ex.Message.Contains("Access is denied.")) {
                        config.AuthFailureCount += 1;
                        authCredentials.UserPrincipalName = String.Empty;

                        //config.Credentials = GetUserLogonCredentials();
                    }
                    else {
                        throw ex;
                    }
                }
                // You can also catch other exceptions to handle a specific situation in your code, for example, 
                //      System.ServiceModel.Security.ExpiredSecurityTokenException
                //      System.ServiceModel.Security.MessageSecurityException
                //      System.ServiceModel.Security.SecurityNegotiationException                
            }

            // Resetting credentials in the AuthenicationCredentials.  
            if (config.EndpointType != AuthenticationProviderType.ActiveDirectory) {
                authCredentials = new AuthenticationCredentials();
                authCredentials.ClientCredentials = config.Credentials;

                if (config.EndpointType == AuthenticationProviderType.LiveId) {
                    authCredentials.SupportingCredentials = new AuthenticationCredentials();
                    authCredentials.SupportingCredentials.ClientCredentials = config.DeviceCredentials;
                }
                // Try to authenticate with the user credentials.
                AuthenticationCredentials tokenCredentials1 = serviceManagement.Authenticate(
                    authCredentials);
                return new DiscoveryServiceProxy(serviceManagement,
               tokenCredentials1.SecurityTokenResponse);
            }
            // For an on-premises environment.
            return new DiscoveryServiceProxy(serviceManagement, config.Credentials);
        }

        /// <summary>
        /// Discovers the organizations that the calling user belongs to.
        /// </summary>
        /// <param name="service">A Discovery service proxy instance.</param>
        /// <returns>Array containing detailed information on each organization that 
        /// the user belongs to.</returns>
        public OrganizationDetailCollection DiscoverOrganizations(IDiscoveryService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            RetrieveOrganizationsRequest orgRequest = new RetrieveOrganizationsRequest();
            RetrieveOrganizationsResponse orgResponse =
                (RetrieveOrganizationsResponse)service.Execute(orgRequest);

            return orgResponse.Details;
        }

        public List<ServerConnection.Configuration> Configurations
        {
            get { return _serverConn.configurations; }
        }
    }
}
