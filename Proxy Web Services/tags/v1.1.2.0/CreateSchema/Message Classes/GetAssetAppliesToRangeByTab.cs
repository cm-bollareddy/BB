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
	public class GetAssetAppliesToRangeByTab
	{
		public GetAssetAppliesToRangeByTab()
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
			//string strLockID = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSManageAppliesToRange p = ComponentFactory.CreateManageAppliesToRangeClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetAssetAppliesToRangeByTab(strSessionID, 258,"MUS", out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutAssetAppliesToRangeByTab.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("AssetAppliesToRangeByTabDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/AssetAppliesToRangeByTabDataSet.xsd";

			XmlNode oASSETAPPLIESTORANGENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtASSETAPPLIESTORANGE = new DataTable("ASSETAPPLIESTORANGE");
			XmlNodeList oASSETAPPLIESTORANGENodes = oASSETAPPLIESTORANGENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtASSETAPPLIESTORANGE, oASSETAPPLIESTORANGENodes);
			dtASSETAPPLIESTORANGE.Constraints.Add("PK_ASSETAPPLIESTORANGE", new DataColumn[] {dtASSETAPPLIESTORANGE.Columns["ASS_ID"],dtASSETAPPLIESTORANGE.Columns["TABID"],dtASSETAPPLIESTORANGE.Columns["TABTYPE"]}, true);
			oDataSet.Tables.Add(dtASSETAPPLIESTORANGE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\AssetAppliesToRangeByTabDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetAssetAppliesToRangeByTab.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetAssetAppliesToRangeByTab.xslt", oDataSet);
			#endregion 

            #region PutAssetAppliesToRangeByTab.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutAssetAppliesToRangeByTab.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetAssetAppliesToRangeByTabClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetAppliesToRangeClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetAssetAppliesToRangeByTabClass.cs", "AssetAppliesToRangeByTab", "ManageAppliesToRange");
			#endregion

            #region PutAssetAppliesToRangeByTabClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\PutAppliesToRangeClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutAssetAppliesToRangeByTabClass.cs", "AssetAppliesToRangeByTab", "ManageAppliesToRange");
			#endregion
		}
	}
}
