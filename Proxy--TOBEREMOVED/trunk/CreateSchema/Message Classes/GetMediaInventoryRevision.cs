using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using BVWebService;
using TVSServer = OrionProxy;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for GetData.
	/// </summary>
	public class GetMediaInventoryRevision
	{
		public GetMediaInventoryRevision()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			string strLockID = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSMediaInventory p = ComponentFactory.CreateMediaInventoryClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetMediaInventoryRevision(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);
            

			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutMediaInventoryRevision.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MediaInventoryRevisionDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/MediaInventoryRevisionDataSet.xsd";

			XmlNode oMEDIAINVENTORYREVISIONNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMEDIAINVENTORYREVISION = new DataTable("MEDIAINVENTORYREVISION");
			XmlNodeList oMEDIAINVENTORYREVISIONNodes = oMEDIAINVENTORYREVISIONNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMEDIAINVENTORYREVISION, oMEDIAINVENTORYREVISIONNodes);
			dtMEDIAINVENTORYREVISION.Constraints.Add("PK_MEDIAINVENTORYREVISION", new DataColumn[] {dtMEDIAINVENTORYREVISION.Columns["MEIR_ID"]}, true);
			oDataSet.Tables.Add(dtMEDIAINVENTORYREVISION);

			XmlNode oMEDIAINVENTORYCUTNode = oMEDIAINVENTORYREVISIONNode.SelectSingleNode("FIELDS/FIELD[@attrname='MEDIAINVENTORYCUT']");
			DataTable dtMEDIAINVENTORYCUT = new DataTable("MEDIAINVENTORYCUT");
			XmlNodeList oMEDIAINVENTORYCUTNodes = oMEDIAINVENTORYCUTNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMEDIAINVENTORYCUT, oMEDIAINVENTORYCUTNodes);
			dtMEDIAINVENTORYCUT.Constraints.Add("PK_MEDIAINVENTORYCUT", new DataColumn[] {dtMEDIAINVENTORYCUT.Columns["MIC_ID"]}, true);
			oDataSet.Tables.Add(dtMEDIAINVENTORYCUT);

			oDataSet.Relations.Add("FK_MEDIAINVENTORYREVISION_MEDIAINVENTORYCUT", dtMEDIAINVENTORYREVISION.Columns["MEIR_ID"], dtMEDIAINVENTORYCUT.Columns["MIC_MEIR_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\MediaInventoryRevisionDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetMediaInventoryRevision.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetMediaInventoryRevision.xslt", oDataSet);
			#endregion 

            #region PutMediaInventoryRevision.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutMediaInventoryRevision.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetMediaInventoryRevisionClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetMediaInventoryRevisionClass.cs", "MediaInventoryRevision", "MediaInventory");
			#endregion

            #region PutMediaInventoryRevisionClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutMediaInventoryRevisionClass.cs", "MediaInventoryRevision", "MediaInventory");
			#endregion

            #region CreateMediaInventoryRevisionClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\CreateMediaInventoryRevisionClassTemplate.cs.txt", strTargetDir + @"\xsltClass\CreateMediaInventoryRevisionClass.cs", "MediaInventoryRevision", "MediaInventory");
            #endregion

            #region GetBarcodeClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetBarcodeClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetBarCodeClass.cs", "BarCode", "MediaInventory");
            #endregion


		}
	}
}
