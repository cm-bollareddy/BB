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
	public class ListMediaCutsInfo
	{
		public ListMediaCutsInfo()
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
			((object[]) objSearchParams[0])[0] = "REVISIONHOUSENUMBER";
			((object[]) objSearchParams[0])[1] = "10133-1";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.ListMediaCutsInfo(strSessionID, (object) objSearchParams, 1, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListMediaCutsInfo.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MediaCutsInfoDataSet");
			oDataSet.Namespace = "http://localhost/SAWebService/ListMediaCutsInfoDataSet.xsd";

			XmlNode oMEDIAINFONode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMEDIAINFO = new DataTable("MEDIAINFO");
			XmlNodeList oMEDIAINFONodes = oMEDIAINFONode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMEDIAINFO, oMEDIAINFONodes);
			dtMEDIAINFO.Constraints.Add("PK_MEDIAINFO", new DataColumn[] {dtMEDIAINFO.Columns["REVISIONHOUSENUMBER"], dtMEDIAINFO.Columns["RECORDHOUSENUMBER"]}, true);
			oDataSet.Tables.Add(dtMEDIAINFO);

			XmlNode oListMediaCutsInfo_DETAILNode = oMEDIAINFONode.SelectSingleNode("FIELDS/FIELD[@attrname='ListMediaCutsInfo_DETAIL']");
			DataTable dtListMediaCutsInfo_DETAIL = new DataTable("ListMediaCutsInfo_DETAIL");
			XmlNodeList oListMediaCutsInfo_DETAILNodes = oListMediaCutsInfo_DETAILNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtListMediaCutsInfo_DETAIL, oListMediaCutsInfo_DETAILNodes);
			dtListMediaCutsInfo_DETAIL.Constraints.Add("PK_LISTMEDIACUTSINFO_DETAIL", new DataColumn[] {dtListMediaCutsInfo_DETAIL.Columns["REVISIONHOUSENUMBER"], dtListMediaCutsInfo_DETAIL.Columns["CUTNUMBER"]}, true);
			oDataSet.Tables.Add(dtListMediaCutsInfo_DETAIL);

			oDataSet.Relations.Add("FK_MEDIAINFO_LISTMEDIACUTSINFO_DETAIL", dtMEDIAINFO.Columns["REVISIONHOUSENUMBER"], dtListMediaCutsInfo_DETAIL.Columns["REVISIONHOUSENUMBER"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListMediaCutsInfoDataSet.xsd");

			#endregion ORION Schema Generation

            #region ListMediaCutsInfo.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListMediaCutsInfo.xslt", oDataSet);
			#endregion


            #region ListMediaCutsInfoClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListMediaCutsInfoTemplate.cs.txt", strTargetDir + @"\xsltClass\ListMediaCutsInfoClass.cs", "MediaCutsInfo", "Search");
			#endregion
		}
	}
}
