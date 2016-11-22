using System;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using BVWebService;
using TVSServer = OrionProxy;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for SearchDeal
	/// </summary>
	public class MediaInventorySearch
	{
		public MediaInventorySearch()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSSearch p = ComponentFactory.CreateSearchClass();

			// Create a search criteria object
			object[] objSearchParams = new object[1];
			objSearchParams[0] = new object[2];
			((object[]) objSearchParams[0])[0] = "program_id";
			((object[]) objSearchParams[0])[1] = "5432";
			//((object[]) objSearchParams[1])[0] = "deal_id";
			//((object[]) objSearchParams[1])[1] = "5430";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.MediaInventorySearch(strSessionID, (object) objSearchParams, 10, out XmlString, out strErrorText);

			if (nErrorCode != 0)
			{
				MessageBox.Show(strErrorText);
				return;
			}

			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\MediaInventorySearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MediaInventoryDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/MediaInventorySearchDataSet.xsd";

			XmlNode oMEDIAINVENTORYNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMEDIAINVENTORY = new DataTable("MEDIAINVENTORYSEARCH");
			XmlNodeList oMEDIAINVENTORYNodes = oMEDIAINVENTORYNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMEDIAINVENTORY, oMEDIAINVENTORYNodes);
			//dtMEDIAINVENTORY.Constraints.Add("PK_MEDIAINVENTORY", new DataColumn[] {dtMEDIAINVENTORY.Columns["MEI_ID"]}, true);
			oDataSet.Tables.Add(dtMEDIAINVENTORY);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\MediaInventorySearchDataSet.xsd");

			#endregion ORION Schema Generation

            #region MediaInventorySearch.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\MediaInventorySearch.xslt", oDataSet);
			#endregion

            #region MediaInventorySearchClass Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\MediaInventorySearchTemplate.cs.txt", strTargetDir + @"\xsltClass\MediaInventorySearchClass.cs", "MediaInventory", "Search");
			#endregion
		}
	}
}
