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
	public class DealSearch
	{
		public DealSearch()
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
			((object[]) objSearchParams[0])[0] = "sub_deal_description";
			((object[]) objSearchParams[0])[1] = "%";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.DealSearch(strSessionID, (object) objSearchParams, 10, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\DealSearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			DataTable dtDeal = new DataTable("DealSearch");

			// Create the columns for Deal
			XmlNodeList oNodeList = XmlDocument.SelectNodes("/DATAPACKET/METADATA/FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDeal, oNodeList);
			dtDeal.Constraints.Add("PK_DEALSEARCH", dtDeal.Columns["DEA_ID"], true);
			//dtDeal.PrimaryKey = new DataColumn[] { dtDeal.Columns["DEA_ID"] };

			// Create the DataSet
			DataSet oDataSet = new DataSet("DealSearchDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/DealSearchDataSet.xsd";
			oDataSet.Tables.Add(dtDeal);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DealSearchDataSet.xsd");
			#endregion ORION Schema Generation

			#region DealSearch.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\DealSearch.xslt", oDataSet);
			#endregion

            #region DealSearchClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\DealSearchClassTemplate.cs.txt", strTargetDir + @"\xsltClass\DealSearchClass.cs", "Deal", "Search");
            #endregion


		}
	}
}
