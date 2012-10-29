﻿// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

//<snippetExportRibbonXml>
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;

// These namespaces are found in the Microsoft.Xrm.Sdk.dll assembly
// located in the SDK\bin folder of the SDK download.
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;



using Microsoft.Crm.Sdk.Messages;

//These references are required for this sample
using System.IO;
using System.IO.Packaging;
using Microsoft.Crm.Sdk.RibbonExporter.Views;

namespace Microsoft.Crm.Sdk.RibbonExporter
{
 /// <summary>
 /// Demonstrates how to export the RibbonXml definitions.</summary>
 /// <remarks>
 /// The generated XML files will be created in the ExportedRibbonXml folder of this project.</remarks>
 public class ExportRibbonXml
 {
  #region Class Level Members


  private OrganizationServiceProxy _serviceProxy;
  //<snippetExportRibbonXml6>
  //This array contains all of the system entities that use the ribbon.
  public System.String[] entitiesWithRibbons = {"account", "activitymimeattachment","activitypointer","appointment",
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
  //</snippetExportRibbonXml6>
  //Folder name for exported ribbon xml files.
  public String exportFolder = "ExportedRibbonXml";

  #endregion Class Level Members

  #region How To Sample Code
  /// <summary>
  /// This method first connects to the Organization service. Afterwards,
  /// basic create, retrieve, update, and delete entity operations are performed.
  /// </summary>
  /// <param name="serverConfig">Contains server connection information.</param>
  /// <param name="promptforDelete">When True, the user will be prompted to delete all
  /// created entities.</param>
  public void Run(ServerConnection.Configuration serverConfig, bool promptforDelete)
  {
   try
   {
    //<snippetExportRibbonXml1>
    // Connect to the Organization service. 
    // The using statement assures that the service proxy will be properly disposed.
    using (_serviceProxy = ServerConnection.GetOrganizationProxy(serverConfig))
    {
     // This statement is required to enable early-bound type support.                  
     _serviceProxy.EnableProxyTypes();
     
     //Create export folder for ribbon xml files if not already exist.
     if (!Directory.Exists(exportFolder))
         Directory.CreateDirectory(exportFolder);

     //<snippetExportRibbonXml3>
     //Retrieve the Appliation Ribbon
     RetrieveApplicationRibbonRequest appribReq = new RetrieveApplicationRibbonRequest();
     RetrieveApplicationRibbonResponse appribResp = (RetrieveApplicationRibbonResponse)_serviceProxy.Execute(appribReq);

     System.String applicationRibbonPath = Path.GetFullPath(exportFolder + "\\applicationRibbon.xml");
     File.WriteAllBytes(applicationRibbonPath, unzipRibbon(appribResp.CompressedApplicationRibbonXml));
     //</snippetExportRibbonXml3>
     //Write the path where the file has been saved.
     Console.WriteLine(applicationRibbonPath);
     //<snippetExportRibbonXml4>
     //Retrieve system Entity Ribbons
     RetrieveEntityRibbonRequest entRibReq = new RetrieveEntityRibbonRequest() { RibbonLocationFilter = RibbonLocationFilters.All };

     #region retrieval code

        bool isDone = false;
        while (!isDone)
        {
            Console.WriteLine("\nRetrieve all ribbons or specific ribbons? (a)ll/(s)pecific: ");
            string input = Console.ReadLine();

            if (input == "a")
            {

                foreach (System.String entityName in entitiesWithRibbons)
                {
                    entRibReq.EntityName = entityName;
                    RetrieveEntityRibbonResponse entRibResp = (RetrieveEntityRibbonResponse)_serviceProxy.Execute(entRibReq);

                    System.String entityRibbonPath = Path.GetFullPath(exportFolder + "\\" + entityName + "Ribbon.xml");
                    File.WriteAllBytes(entityRibbonPath, unzipRibbon(entRibResp.CompressedEntityXml));
                    //Write the path where the file has been saved.
                    Console.WriteLine(entityRibbonPath);
                }

                //</snippetExportRibbonXml4>

                //<snippetExportRibbonXml5>
                //Check for custom entities
                RetrieveAllEntitiesRequest raer = new RetrieveAllEntitiesRequest() { EntityFilters = EntityFilters.Entity };

                RetrieveAllEntitiesResponse resp = (RetrieveAllEntitiesResponse)_serviceProxy.Execute(raer);

                foreach (EntityMetadata em in resp.EntityMetadata)
                {
                    if (em.IsCustomEntity == true && em.IsIntersect == false)
                    {
                        entRibReq.EntityName = em.LogicalName;
                        RetrieveEntityRibbonResponse entRibResp = (RetrieveEntityRibbonResponse)_serviceProxy.Execute(entRibReq);

                        System.String entityRibbonPath = Path.GetFullPath(exportFolder + "\\" + em.LogicalName + "Ribbon.xml");
                        File.WriteAllBytes(entityRibbonPath, unzipRibbon(entRibResp.CompressedEntityXml));
                        //Write the path where the file has been saved.
                        Console.WriteLine(entityRibbonPath);
                    }
                }

                isDone = true;
            }
            else if (input == "s")
            {
                // first do system entities
                int i = 0;
                foreach (System.String entityName in entitiesWithRibbons)
                {
                    Console.WriteLine("[{0}] {1}", i++, entityName);
                }
                Console.WriteLine("Enter the numbers of the entities to download, separated by commas: ");
                string entityNums = Console.ReadLine();
                string[] entityNumsArr = entityNums.Split(new char[] { ',' });

                foreach (string numStr in entityNumsArr)
                {
                    int num;
                    if (Int32.TryParse(numStr, out num))
                    {
                        if (num >= 0 && num < entitiesWithRibbons.Length)
                        {
                            string entityName = entitiesWithRibbons[num];
                            entRibReq.EntityName = entityName;
                            RetrieveEntityRibbonResponse entRibResp = (RetrieveEntityRibbonResponse)_serviceProxy.Execute(entRibReq);

                            System.String entityRibbonPath = Path.GetFullPath(exportFolder + "\\" + entityName + "Ribbon.xml");
                            File.WriteAllBytes(entityRibbonPath, unzipRibbon(entRibResp.CompressedEntityXml));
                            //Write the path where the file has been saved.
                            Console.WriteLine(entityRibbonPath);
                        }
                        else
                        {
                            Console.WriteLine("No element index {0} in entitiesWithRibbons, skipping...", num);
                        }
                    }
                }

                // next check for custom entities
                RetrieveAllEntitiesRequest raer = new RetrieveAllEntitiesRequest() { EntityFilters = EntityFilters.Entity };
                RetrieveAllEntitiesResponse resp = (RetrieveAllEntitiesResponse)_serviceProxy.Execute(raer);

                i = 0;
                foreach (EntityMetadata em in resp.EntityMetadata)
                {
                    if (em.IsCustomEntity == true && em.IsIntersect == false)
                    {
                        Console.WriteLine("[{0}] {1}", i, em.LogicalName);
                    }
                    i++;
                }
                Console.WriteLine("Enter the numbers of the entities to download, separated by commas: ");
                entityNums = Console.ReadLine();
                entityNumsArr = entityNums.Split(new char[] { ',' });

                //foreach (EntityMetadata em in resp.EntityMetadata)
                foreach (string numStr in entityNumsArr)
                {
                    int index;
                    if (Int32.TryParse(numStr, out index))
                    {
                        if (index >= 0 && index < resp.EntityMetadata.Length)
                        {
                            EntityMetadata em = resp.EntityMetadata[index];
                            if (em.IsCustomEntity == true && em.IsIntersect == false)
                            {
                                entRibReq.EntityName = em.LogicalName;
                                RetrieveEntityRibbonResponse entRibResp = (RetrieveEntityRibbonResponse)_serviceProxy.Execute(entRibReq);

                                System.String entityRibbonPath = Path.GetFullPath(exportFolder + "\\" + em.LogicalName + "Ribbon.xml");
                                File.WriteAllBytes(entityRibbonPath, unzipRibbon(entRibResp.CompressedEntityXml));
                                //Write the path where the file has been saved.
                                Console.WriteLine(entityRibbonPath);
                            }
                        }
                    }
                }
                Console.WriteLine("");


                isDone = true;
            }

        }
     #endregion
    }
    //</snippetExportRibbonXml5>
    //</snippetExportRibbonXml1>
   }

   // Catch any service fault exceptions that Microsoft Dynamics CRM throws.
   catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
   {
    // You can handle an exception here or pass it back to the calling method.
    throw;
   }
  }

  //<snippetExportRibbonXml2>
  /// <summary>
  /// A helper method that decompresses the the Ribbon data returned
  /// </summary>
  /// <param name="data">The compressed ribbon data</param>
  /// <returns></returns>
  public byte[] unzipRibbon(byte[] data)
  {
   System.IO.Packaging.ZipPackage package = null;
   MemoryStream memStream = null;

   memStream = new MemoryStream();
   memStream.Write(data, 0, data.Length);
   package = (ZipPackage)ZipPackage.Open(memStream, FileMode.Open);

   ZipPackagePart part = (ZipPackagePart)package.GetPart(new Uri("/RibbonXml.xml", UriKind.Relative));
   using (Stream strm = part.GetStream())
   {
    long len = strm.Length;
    byte[] buff = new byte[len];
    strm.Read(buff, 0, (int)len);
    return buff;
   }
  }
  //</snippetExportRibbonXml2>

  #endregion How To Sample Code

  #region Main method

  /// <summary>
  /// Standard Main() method used by most SDK samples.
  /// </summary>
  /// <param name="args"></param>
  static public void Main(string[] args)
  {
   try
   {
       // Obtain the target organization's Web address and client logon 
       // credentials from the user.
       //ServerConnection serverConnect = new ServerConnection();
       //ServerConnection.Configuration config = serverConnect.GetServerConfiguration();

        // Enable the UI
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new ServerConfigurationForm());

        //initForm.Show();

        //ExportRibbonXml app = new ExportRibbonXml();
        //app.Run(config, true);
   }
   catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> ex)
   {
    Console.WriteLine("The application terminated with an error.");
    Console.WriteLine("Timestamp: {0}", ex.Detail.Timestamp);
    Console.WriteLine("Code: {0}", ex.Detail.ErrorCode);
    Console.WriteLine("Message: {0}", ex.Detail.Message);
    Console.WriteLine("Plugin Trace: {0}", ex.Detail.TraceText);
    Console.WriteLine("Inner Fault: {0}",
        null == ex.Detail.InnerFault ? "Has Inner Fault" : "No Inner Fault");
   }
   catch (System.TimeoutException ex)
   {
    Console.WriteLine("The application terminated with an error.");
    Console.WriteLine("Message: {0}", ex.Message);
    Console.WriteLine("Stack Trace: {0}", ex.StackTrace);
    Console.WriteLine("Inner Fault: {0}",
        null == ex.InnerException.Message ? "Has Inner Fault" : "No Inner Fault");
   }
   catch (System.Exception ex)
   {
    Console.WriteLine("The application terminated with an error.");
    Console.WriteLine(ex.Message);

    // Display the details of the inner exception.
    if (ex.InnerException != null)
    {
     Console.WriteLine(ex.InnerException.Message);

     FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> fe = ex.InnerException
         as FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>;
     if (fe != null)
     {
      Console.WriteLine("Timestamp: {0}", fe.Detail.Timestamp);
      Console.WriteLine("Code: {0}", fe.Detail.ErrorCode);
      Console.WriteLine("Message: {0}", fe.Detail.Message);
      Console.WriteLine("Plugin Trace: {0}", fe.Detail.TraceText);
      Console.WriteLine("Inner Fault: {0}",
          null == fe.Detail.InnerFault ? "Has Inner Fault" : "No Inner Fault");
     }
    }
   }
   // Additional exceptions to catch: SecurityTokenValidationException, ExpiredSecurityTokenException,
   // SecurityAccessDeniedException, MessageSecurityException, and SecurityNegotiationException.

   finally
   {
    Console.WriteLine("Press <Enter> to exit.");
    Console.ReadLine();
   }
  }
  #endregion Main method
 }
}
//</snippetExportRibbonXml>