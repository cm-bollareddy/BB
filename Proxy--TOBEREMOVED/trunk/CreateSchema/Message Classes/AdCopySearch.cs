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
	public class AdCopySearch
	{
		public AdCopySearch()
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
			nErrorCode = p.AdCopySearch(strSessionID, (object) objSearchParams, 10, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\AdCopySearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("AdCopyDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/AdCopySearchDataSet.xsd";

			XmlNode oADCOPYNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtADCOPY = new DataTable("ADCOPYSEARCH");
			XmlNodeList oADCOPYNodes = oADCOPYNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtADCOPY, oADCOPYNodes);
			//dtADCOPY.Constraints.Add("PK_ADCOPY", new DataColumn[] {dtADCOPY.Columns["ASS_ID"],dtADCOPY.Columns["VER_ID"]}, true);
			oDataSet.Tables.Add(dtADCOPY);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\AdCopySearchDataSet.xsd");

			#endregion ORION Schema Generation

            #region AdCopySearch.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\AdCopySearch.xslt", oDataSet);
			#endregion

            #region AdCopySearchClass Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\AdCopySearchTemplate.cs.txt", strTargetDir + @"\xsltClass\AdCopySearchClass.cs", "AdCopy", "Search");
			#endregion
		}
	}
}
