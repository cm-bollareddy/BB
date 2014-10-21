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
	public class PackageInfoSearch
	{
		public PackageInfoSearch()
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
			nErrorCode = p.SearchPackageInfo(strSessionID, (object) objSearchParams, 1, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PackageInfoSearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DataSet");
			oDataSet.Namespace = "http://localhost/SAWebService/PackageInfoSearchDataSet.xsd";

			XmlNode oPACKAGEINFONode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtPACKAGEINFO = new DataTable("PACKAGEINFO");
			XmlNodeList oPACKAGEINFONodes = oPACKAGEINFONode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPACKAGEINFO, oPACKAGEINFONodes);
			//dtPACKAGEINFO.Constraints.Add("PK_PACKAGEINFO", new DataColumn[] {dtPACKAGEINFO.Columns["REVISIONHOUSENUMBER"]}, true);
			oDataSet.Tables.Add(dtPACKAGEINFO);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\PackageInfoSearchDataSet.xsd");

			#endregion ORION Schema Generation

            #region PackageInfoSearch.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PackageInfoSearch.xslt", oDataSet);
			#endregion


            #region PackageInfoSearchClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\PackageInfoSearchTemplate.cs.txt", strTargetDir + @"\xsltClass\PackageInfoSearchClass.cs", "PackageInfo", "Search");
			#endregion
		}
	}
}
