using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;

namespace Microsoft.Crm.Sdk.RibbonExporter.Helpers
{
    public class MyCrmServiceHelper
    {
        public OrganizationDetailCollection GetOrganizationAddressesAsList(ServerConnection.Configuration config)
        {
            using (DiscoveryServiceProxy serviceProxy = GetDiscoveryProxy(config)) {
                // Obtain organization information from the Discovery service. 
                if (serviceProxy != null) {
                    OrganizationDetailCollection orgs = DiscoverOrganizations(serviceProxy);
                    return orgs;
                }
            }
            return null;
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
    }
}
