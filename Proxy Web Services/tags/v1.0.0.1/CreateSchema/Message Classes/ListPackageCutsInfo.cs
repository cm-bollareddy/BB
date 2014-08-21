using System;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using BVWebService;
using TVSServer = OrionProxy;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for ListPackageCutsInfo
	/// </summary>
	public class ListPackageCutsInfo
	{
		public ListPackageCutsInfo()
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
            ((object[])objSearchParams[0])[1] = "P414357-002";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.ListPackageCutsInfo(strSessionID, (object) objSearchParams, 1, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListPackageCutsInfo.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation
			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("PackageCutsInfoDataSet");
			oDataSet.Namespace = "http://localhost/SAWebService/ListPackageCutsInfoDataSet.xsd";

			XmlNode oPACKAGEINFONode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtPACKAGEINFO = new DataTable("PACKAGEINFO");
			XmlNodeList oPACKAGEINFONodes = oPACKAGEINFONode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPACKAGEINFO, oPACKAGEINFONodes);
			dtPACKAGEINFO.Constraints.Add("PK_PACKAGEINFO", new DataColumn[] {dtPACKAGEINFO.Columns["PACKAGENUMBER"]}, true);
			oDataSet.Tables.Add(dtPACKAGEINFO);

			XmlNode oListPackageCutsInfo_DETAILNode = oPACKAGEINFONode.SelectSingleNode("FIELDS/FIELD[@attrname='ListPackageCutsInfo_DETAIL']");
			DataTable dtListPackageCutsInfo_DETAIL = new DataTable("ListPackageCutsInfo_DETAIL");
			XmlNodeList oListPackageCutsInfo_DETAILNodes = oListPackageCutsInfo_DETAILNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtListPackageCutsInfo_DETAIL, oListPackageCutsInfo_DETAILNodes);
			dtListPackageCutsInfo_DETAIL.Constraints.Add("PK_LISTPACKAGECUTSINFO_DETAIL", new DataColumn[] {dtListPackageCutsInfo_DETAIL.Columns["PACKAGENUMBER"], dtListPackageCutsInfo_DETAIL.Columns["CUTNUMBER"]}, true);
			oDataSet.Tables.Add(dtListPackageCutsInfo_DETAIL);

			oDataSet.Relations.Add("FK_PACKAGEINFO_LISTPACKAGECUTSINFO_DETAIL", dtPACKAGEINFO.Columns["PACKAGENUMBER"], dtListPackageCutsInfo_DETAIL.Columns["PACKAGENUMBER"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListPackageCutsInfoDataSet.xsd");

			#endregion ORION Schema Generation


            #region ListPackageCutsInfo.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListPackageCutsInfo.xslt", oDataSet);
			#endregion
			
			
			#region GetDealClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListPackageCutsInfoTemplate.cs.txt", strTargetDir + @"\xsltClass\ListPackageCutsInfoClass.cs", "PackageCutsInfo", "Search");
			#endregion
		}
	}
}
