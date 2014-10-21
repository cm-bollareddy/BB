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
	public class GetDealWithRights
	{
		public GetDealWithRights()
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
			nErrorCode = p.GetDealWithRights(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutDealWithRights.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DealWithRightsDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/DealWithRightsDataSet.xsd";

			XmlNode oDEALNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtDEAL = new DataTable("DEAL");
			XmlNodeList oDEALNodes = oDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEAL, oDEALNodes);
			dtDEAL.Constraints.Add("PK_DEAL", new DataColumn[] {dtDEAL.Columns["DEA_ID"]}, true);
			oDataSet.Tables.Add(dtDEAL);

			XmlNode oDEALCONTENTNode = oDEALNode.SelectSingleNode("FIELDS/FIELD[@attrname='DEALCONTENT']");
			DataTable dtDEALCONTENT = new DataTable("DEALCONTENT");
			XmlNodeList oDEALCONTENTNodes = oDEALCONTENTNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEALCONTENT, oDEALCONTENTNodes);
			dtDEALCONTENT.Constraints.Add("PK_DEALCONTENT", new DataColumn[] {dtDEALCONTENT.Columns["DCO_ID"]}, true);
			oDataSet.Tables.Add(dtDEALCONTENT);

			oDataSet.Relations.Add("FK_DEAL_DEALCONTENT", dtDEAL.Columns["DEA_ID"], dtDEALCONTENT.Columns["DCO_DEA_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DealWithRightsDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetDealWithRights.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetDealWithRights.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region PutDealWithRights.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutDealWithRights.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetDealWithRightsClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetDealWithRightsClass.cs", "DealWithRights", "Deal");
			#endregion

            #region PutDealWithRightsClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\PutClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutDealWithRightsClass.cs", "DealWithRights", "Deal");
			#endregion
		}
	}
}
