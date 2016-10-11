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
	public class GetDeal
	{
		public GetDeal()
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
			string strLockID = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSDeal p = ComponentFactory.CreateDealClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetDeal(strSessionID, 3910, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\GetDeal.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DealDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/DealDataSet.xsd";

			XmlNode oDEALNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtDEAL = new DataTable("DEAL");
			XmlNodeList oDEALNodes = oDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEAL, oDEALNodes);
			dtDEAL.Constraints.Add("PK_DEAL", new DataColumn[] {dtDEAL.Columns["DEA_ID"]}, true);
			oDataSet.Tables.Add(dtDEAL);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DealDataSet.xsd");

			#endregion ORION Schema Generation

			#region GetDeal.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetDeal.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

			#region PutDeal.xslt Generation
			GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutDeal.xslt", XmlDocument, oDataSet);
			#endregion


			#region GetDealClass.cs Generation
			GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetDealClass.cs", "Deal", "Deal");
			#endregion

			#region SetDealClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\PutClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutDealClass.cs", "Deal", "Deal");
			#endregion
		}
	}
}
