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
	public class ListDealsByMasterDeal
	{
		public ListDealsByMasterDeal()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";
			int nID =0;
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
			TVSServer.rdmPBSGetMasterDeal p = ComponentFactory.CreateMasterDealClass();
			
			// Invoke the object to get the XML result string
			nErrorCode = p.ListDealsByMasterDeal(strSessionID,nID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  List this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListDealsByMasterDeal.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DealsByMasterDealDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/ListDealsByMasterDealDataSet.xsd";

			XmlNode oDEALNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtDEAL = new DataTable("DEAL");
			XmlNodeList oDEALNodes = oDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEAL, oDEALNodes);
			dtDEAL.Constraints.Add("PK_DEAL", new DataColumn[] {dtDEAL.Columns["DEA_ID"]}, true);
			oDataSet.Tables.Add(dtDEAL);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListDealsByMasterDealDataSet.xsd");

			#endregion ORION Schema Generation

			#region ListCompany.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListDealsByMasterDeal.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

			#region ListCompanyClass.cs Generation
			GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListDealsByMasterDealClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ListDealsByMasterDealClass.cs", "DealsByMasterDeal", "GetMasterDeal" );
			#endregion
		}
	}
}
