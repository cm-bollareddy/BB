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
	public class TrafficItemSearch
	{
		public TrafficItemSearch()
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
			((object[]) objSearchParams[0])[0] = "Title";
			((object[]) objSearchParams[0])[1] = "%";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.TrafficItemSearch(strSessionID, (object) objSearchParams, 10, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\TrafficItemSearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("TrafficItemDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/TrafficItemSearchDataSet.xsd";

			XmlNode oTRAFFICITEMNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtTRAFFICITEM = new DataTable("TRAFFICITEMSEARCH");
			XmlNodeList oTRAFFICITEMNodes = oTRAFFICITEMNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtTRAFFICITEM, oTRAFFICITEMNodes);
			//dtTRAFFICITEM.Constraints.Add("PK_TRAFFICITEM", new DataColumn[] {dtTRAFFICITEM.Columns["ASS_ID"],dtTRAFFICITEM.Columns["VER_ID"]}, true);
			oDataSet.Tables.Add(dtTRAFFICITEM);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\TrafficItemSearchDataSet.xsd");

			#endregion ORION Schema Generation

            #region TrafficItemSearch.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\TrafficItemSearch.xslt", oDataSet);
			#endregion

            #region TrafficItemSearchClass Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\TrafficItemSearchTemplate.cs.txt", strTargetDir + @"\xsltClass\TrafficItemSearchClass.cs", "TrafficItem", "Search");
			#endregion
		}
	}
}
