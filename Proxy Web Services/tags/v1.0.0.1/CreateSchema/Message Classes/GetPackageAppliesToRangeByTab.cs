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
	public class GetPackageAppliesToRangeByTab
	{
		public GetPackageAppliesToRangeByTab()
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
			//nErrorCode = p.GetPackageAppliesToRangeByTab(strSessionID,672,"ICC",out XmlString, out strErrorText);
            nErrorCode = p.GetPackageAppliesToRangeByTab(strSessionID, 722, "OAC", out XmlString, out strErrorText);
            

			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutPackageAppliesToRangeByTab.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("PackageAppliesToRangeByTabDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/PackageAppliesToRangeByTabDataSet.xsd";

			XmlNode oPROGRAMSNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtPROGRAMS = new DataTable("PROGRAMS");
			XmlNodeList oPROGRAMSNodes = oPROGRAMSNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPROGRAMS, oPROGRAMSNodes);
			dtPROGRAMS.Constraints.Add("PK_PROGRAMS", new DataColumn[] {dtPROGRAMS.Columns["ASS_ID"]}, true);
			oDataSet.Tables.Add(dtPROGRAMS);

			XmlNode oVW_VERSIONAPPLIESTORANGENode = oPROGRAMSNode.SelectSingleNode("FIELDS/FIELD[@attrname='VW_VERSIONAPPLIESTORANGE']");
			DataTable dtVW_VERSIONAPPLIESTORANGE = new DataTable("VW_VERSIONAPPLIESTORANGE");
			XmlNodeList oVW_VERSIONAPPLIESTORANGENodes = oVW_VERSIONAPPLIESTORANGENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVW_VERSIONAPPLIESTORANGE, oVW_VERSIONAPPLIESTORANGENodes);
			dtVW_VERSIONAPPLIESTORANGE.Constraints.Add("PK_VW_VERSIONAPPLIESTORANGE", new DataColumn[] {dtVW_VERSIONAPPLIESTORANGE.Columns["VER_ID"],dtVW_VERSIONAPPLIESTORANGE.Columns["TABID"],dtVW_VERSIONAPPLIESTORANGE.Columns["TABTYPE"]}, true);
			oDataSet.Tables.Add(dtVW_VERSIONAPPLIESTORANGE);

			oDataSet.Relations.Add("FK_PROGRAMS_VW_VERSIONAPPLIESTORANGE", dtPROGRAMS.Columns["ASS_ID"], dtVW_VERSIONAPPLIESTORANGE.Columns["VER_ASS_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\PackageAppliesToRangeByTabDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetPackageAppliesToRangeByTab.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetPackageAppliesToRangeByTab.xslt", oDataSet);
			#endregion 

            #region PutPackageAppliesToRangeByTab.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutPackageAppliesToRangeByTab.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetPackageAppliesToRangeByTabClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetAppliesToRangeClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetPackageAppliesToRangeByTabClass.cs", "PackageAppliesToRangeByTab", "ManageAppliesToRange");
			#endregion

            #region PutPackageAppliesToRangeByTabClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\PutAppliesToRangeClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutPackageAppliesToRangeByTabClass.cs", "PackageAppliesToRangeByTab", "ManageAppliesToRange");
			#endregion
		}
	}
}
