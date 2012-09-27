using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Crm.Sdk.RibbonExporter.Model;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Messages;
using System.IO;
using System.IO.Packaging;

namespace Microsoft.Crm.Sdk.RibbonExporter
{
    public class RibbonItemHelper
    {
        OrganizationServiceProxy _serviceProxy;
        ServerConnection.Configuration _serverConfig;

        public RibbonItemHelper(OrganizationServiceProxy serviceProxy, ServerConnection.Configuration serverConfig)
        {
            _serviceProxy = serviceProxy;
            _serverConfig = serverConfig;
        }

        private List<RibbonItem> GetListOfRibbonItems()
        {
            List<RibbonItem> ribbonItems = new List<RibbonItem>();
            // This statement is required to enable early-bound type support.                  
            _serviceProxy.EnableProxyTypes();
            // First build the system entities
            String[] entitiesWithRibbons = {"account", "activitymimeattachment","activitypointer","appointment",
                                                "bulkoperation","campaign","campaignactivity","campaignresponse",
                                                "competitor","connection","contact","contract","contractdetail",
                                                "customeraddress","discount","discounttype","email","fax","goal",
                                                "importfile","incident","invoice","invoicedetail","kbarticle",
                                                "kbarticlecomment","lead","letter","list","listmember", "metric",
                                                "opportunity","opportunityproduct","phonecall","pricelevel","product",
                                                "productpricelevel","queueitem","quote","quotedetail",
                                                "recurringappointmentmaster","report","salesliterature","salesorder",
                                                "salesorderdetail","service","serviceappointment","sharepointdocumentlocation",
                                                "sharepointsite","systemuser","task","team","territory","uom","uomschedule",
                                                "userquery"};

            foreach (String entity in entitiesWithRibbons) {
                ribbonItems.Add(new RibbonItem { EntityName = entity, IsSystemEntity = true });
            }

            // Next add the custom entities
            RetrieveAllEntitiesRequest raer = new RetrieveAllEntitiesRequest() { EntityFilters = EntityFilters.Entity };
            RetrieveAllEntitiesResponse resp = (RetrieveAllEntitiesResponse)_serviceProxy.Execute(raer);

            foreach (EntityMetadata em in resp.EntityMetadata) {
                if (em.IsCustomEntity == true && em.IsIntersect == false)
                    ribbonItems.Add(new RibbonItem { EntityName = em.LogicalName, IsSystemEntity = false });
            }

            return ribbonItems;
        }

        public void FetchRibbonItems(List<RibbonItem> ribbonItems, String exportFolder)
        {
            RetrieveEntityRibbonRequest entRibReq = new RetrieveEntityRibbonRequest() { RibbonLocationFilter = RibbonLocationFilters.All };

            foreach (RibbonItem item in ribbonItems) {
                entRibReq.EntityName = item.EntityName;
                RetrieveEntityRibbonResponse entRibResp = (RetrieveEntityRibbonResponse)_serviceProxy.Execute(entRibReq);

                System.String entityRibbonPath = Path.GetFullPath(exportFolder + "\\" + item.EntityName + "Ribbon.xml");
                File.WriteAllBytes(entityRibbonPath, unzipRibbon(entRibResp.CompressedEntityXml));
                //Write the path where the file has been saved.
                Console.WriteLine(entityRibbonPath);
            }
        }

        /// <summary>
        /// A helper method that decompresses the the Ribbon data returned
        /// </summary>
        /// <param name="data">The compressed ribbon data</param>
        /// <returns></returns>
        private byte[] unzipRibbon(byte[] data)
        {
            System.IO.Packaging.ZipPackage package = null;
            MemoryStream memStream = null;

            memStream = new MemoryStream();
            memStream.Write(data, 0, data.Length);
            package = (ZipPackage)ZipPackage.Open(memStream, FileMode.Open);

            ZipPackagePart part = (ZipPackagePart)package.GetPart(new Uri("/RibbonXml.xml", UriKind.Relative));
            using (Stream strm = part.GetStream()) {
                long len = strm.Length;
                byte[] buff = new byte[len];
                strm.Read(buff, 0, (int)len);
                return buff;
            }
        }
    }
}
