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
	public class ListPackageMediaInfo
	{
		public ListPackageMediaInfo()
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
			((object[]) objSearchParams[0])[1] = "1000006-1";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.ListPackageMediaInfo(strSessionID, (object) objSearchParams, 1, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListPackageMediaInfo.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("PackageMediaInfoDataSet");
			oDataSet.Namespace = "http://localhost/SAWebService/ListPackageMediaInfoDataSet.xsd";

			XmlNode oPACKAGEMEDIAINFONode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtPACKAGEMEDIAINFO = new DataTable("PACKAGEMEDIAINFO");
			XmlNodeList oPACKAGEMEDIAINFONodes = oPACKAGEMEDIAINFONode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPACKAGEMEDIAINFO, oPACKAGEMEDIAINFONodes);
			dtPACKAGEMEDIAINFO.Constraints.Add("PK_PACKAGEMEDIAINFO", new DataColumn[] {dtPACKAGEMEDIAINFO.Columns["PACKAGENUMBER"]}, true);
			oDataSet.Tables.Add(dtPACKAGEMEDIAINFO);

			XmlNode oListPackageMediaInfo_DETAILNode = oPACKAGEMEDIAINFONode.SelectSingleNode("FIELDS/FIELD[@attrname='ListPackageMediaInfo_DETAIL']");
			DataTable dtListPackageMediaInfo_DETAIL = new DataTable("ListPackageMediaInfo_DETAIL");
			XmlNodeList oListPackageMediaInfo_DETAILNodes = oListPackageMediaInfo_DETAILNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtListPackageMediaInfo_DETAIL, oListPackageMediaInfo_DETAILNodes);
			dtListPackageMediaInfo_DETAIL.Constraints.Add("PK_LISTPACKAGEMEDIAINFO_DETAIL", new DataColumn[] {dtListPackageMediaInfo_DETAIL.Columns["PACKAGENUMBER"], dtListPackageMediaInfo_DETAIL.Columns["HOUSENUMBER"]}, true);
			oDataSet.Tables.Add(dtListPackageMediaInfo_DETAIL);

			oDataSet.Relations.Add("FK_PACKAGEMEDIAINFO_LISTPACKAGEMEDIAINFO_DETAIL", dtPACKAGEMEDIAINFO.Columns["PACKAGENUMBER"], dtListPackageMediaInfo_DETAIL.Columns["PACKAGENUMBER"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListPackageMediaInfoDataSet.xsd");

			#endregion ORION Schema Generation



            #region ListPackageMediaInfo.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListPackageMediaInfo.xslt", oDataSet);
			#endregion


            #region ListPackageMediaInfoClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListPackageMediaInfoTemplate.cs.txt", strTargetDir + @"\xsltClass\ListPackageMediaInfoClass.cs", "PackageMediaInfo", "Search");
			#endregion
		}
	}
}
