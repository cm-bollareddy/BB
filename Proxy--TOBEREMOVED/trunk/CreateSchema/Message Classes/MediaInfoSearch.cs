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
	public class MediaInfoSearch
	{
		public MediaInfoSearch()
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
			((object[]) objSearchParams[0])[0] = "NOLACODE";
			((object[]) objSearchParams[0])[1] = "ACAC  000101%";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.SearchMediaInfo(strSessionID, (object) objSearchParams, 1, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\MediaInfoSearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DataSet");
			oDataSet.Namespace = "http://localhost/SAWebService/MediaInfoSearchDataSet.xsd";

			XmlNode oMEDIAINFONode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMEDIAINFO = new DataTable("MEDIAINFO");
			XmlNodeList oMEDIAINFONodes = oMEDIAINFONode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMEDIAINFO, oMEDIAINFONodes);
			//dtMEDIAINFO.Constraints.Add("PK_MEDIAINFO", new DataColumn[] {dtMEDIAINFO.Columns["REVISIONHOUSENUMBER"]}, true);
			oDataSet.Tables.Add(dtMEDIAINFO);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\MediaInfoSearchDataSet.xsd");

			#endregion ORION Schema Generation

            #region MediaInfoSearch.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\MediaInfoSearch.xslt", oDataSet);
			#endregion


            #region MediaInfoSearchClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\MediaInfoSearchTemplate.cs.txt", strTargetDir + @"\xsltClass\MediaInfoSearchClass.cs", "MediaInfo", "Search");
			#endregion
		}
	}
}
