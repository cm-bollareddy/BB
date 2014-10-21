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
	public class MasterDealSearch
	{
		public MasterDealSearch()
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
			((object[]) objSearchParams[0])[0] = "title";
			((object[]) objSearchParams[0])[1] = "%";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.MasterDealSearch(strSessionID, (object) objSearchParams, 10, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\MasterDealSearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MasterDealDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/MasterDealSearchDataSet.xsd";

			XmlNode oMASTERDEALNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMASTERDEAL = new DataTable("MASTERDEAL");
			XmlNodeList oMASTERDEALNodes = oMASTERDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMASTERDEAL, oMASTERDEALNodes);
			dtMASTERDEAL.Constraints.Add("PK_MASTERDEAL", new DataColumn[] {dtMASTERDEAL.Columns["MDL_ID"]}, true);
			oDataSet.Tables.Add(dtMASTERDEAL);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\MasterDealSearchDataSet.xsd");

			#endregion ORION Schema Generation

            #region MasterDealSearch.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\MasterDealSearch.xslt", oDataSet);
			#endregion

            #region MasterDealSearchClass Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\MasterDealSearchTemplate.cs.txt", strTargetDir + @"\xsltClass\MasterDealSearchClass.cs", "MasterDeal", "Search");
			#endregion
		}
	}
}
