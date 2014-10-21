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
	public class ListTabMapByDeal
	{
		public ListTabMapByDeal()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";
			//int nDealID =0;
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSManageAppliesToRange p = ComponentFactory.CreateManageAppliesToRangeClass();
			//new TVSServer.rdmPBSGetLookup();

			// Invoke the object to get the XML result string
			nErrorCode = p.ListTabMapByDeal(strSessionID,3133742, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  List this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListTabMapByDeal.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("TabMapByDealDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ListTabMapByDealDataSet.xsd";

			XmlNode oTABMAPNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtTABMAP = new DataTable("TABMAP");
			XmlNodeList oTABMAPNodes = oTABMAPNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtTABMAP, oTABMAPNodes);
			dtTABMAP.Constraints.Add("PK_TABMAP", new DataColumn[] {dtTABMAP.Columns["TABID"],dtTABMAP.Columns["TABTYPE"]}, true);
			oDataSet.Tables.Add(dtTABMAP);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListTabMapByDealDataSet.xsd");

			#endregion ORION Schema Generation

            #region ListTabMapByDeal.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListTabMapByDeal.xslt", oDataSet);
			#endregion 

            #region ListTabMapByDealClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ListTabMapByDealClass.cs", "TabMapByDeal", "ManageAppliesToRange");
			#endregion
		}
	}
}
