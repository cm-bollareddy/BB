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
	public class GetFeatureMediaInventory
	{
		public GetFeatureMediaInventory()
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
			//nErrorCode = p.GetFeatureMediaInventory(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);
            nErrorCode = p.GetFeatureMediaInventory(strSessionID, 17606095, false, out strLockID, out XmlString, out strErrorText);
            
			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutFeatureMediaInventory.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("FeatureMediaInventoryDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/FeatureMediaInventoryDataSet.xsd";

			XmlNode oFEATUREMEDIAINVENTORYNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtFEATUREMEDIAINVENTORY = new DataTable("FEATUREMEDIAINVENTORY");
			XmlNodeList oFEATUREMEDIAINVENTORYNodes = oFEATUREMEDIAINVENTORYNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtFEATUREMEDIAINVENTORY, oFEATUREMEDIAINVENTORYNodes);
			dtFEATUREMEDIAINVENTORY.Constraints.Add("PK_FEATUREMEDIAINVENTORY", new DataColumn[] {dtFEATUREMEDIAINVENTORY.Columns["MEI_ID"]}, true);
			oDataSet.Tables.Add(dtFEATUREMEDIAINVENTORY);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\FeatureMediaInventoryDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetFeatureMediaInventory.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetFeatureMediaInventory.xslt", oDataSet);
			#endregion 

            #region PutFeatureMediaInventory.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutFeatureMediaInventory.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetFeatureMediaInventoryClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetFeatureMediaInventoryClass.cs", "FeatureMediaInventory", "MediaInventory");
			#endregion

            #region PutFeatureMediaInventoryClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutFeatureMediaInventoryClass.cs", "FeatureMediaInventory", "MediaInventory");
			#endregion
		}
	}
}
