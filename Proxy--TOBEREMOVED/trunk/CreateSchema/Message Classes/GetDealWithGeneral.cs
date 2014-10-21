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
	public class GetDealWithGeneral
	{
		public GetDealWithGeneral()
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
			nErrorCode = p.GetDealWithGeneral(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutDealWithGeneral.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DealWithGeneralDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/DealWithGeneralDataSet.xsd";

			XmlNode oDEALNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtDEAL = new DataTable("DEAL");
			XmlNodeList oDEALNodes = oDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEAL, oDEALNodes);
			dtDEAL.Constraints.Add("PK_DEAL", new DataColumn[] {dtDEAL.Columns["DEA_ID"]}, true);
			oDataSet.Tables.Add(dtDEAL);

			XmlNode oPBSDEALCONTACTNode = oDEALNode.SelectSingleNode("FIELDS/FIELD[@attrname='PBSDEALCONTACT']");
			DataTable dtPBSDEALCONTACT = new DataTable("PBSDEALCONTACT");
			XmlNodeList oPBSDEALCONTACTNodes = oPBSDEALCONTACTNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPBSDEALCONTACT, oPBSDEALCONTACTNodes);
			dtPBSDEALCONTACT.Constraints.Add("PK_PBSDEALCONTACT", new DataColumn[] {dtPBSDEALCONTACT.Columns["PBSDC_ID"]}, true);
			oDataSet.Tables.Add(dtPBSDEALCONTACT);

			oDataSet.Relations.Add("FK_DEAL_PBSDEALCONTACT", dtDEAL.Columns["DEA_ID"], dtPBSDEALCONTACT.Columns["PBSDC_DEA_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DealWithGeneralDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetDealWithGeneral.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetDealWithGeneral.xslt", oDataSet);
			#endregion 

            #region PutDealWithGeneral.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutDealWithGeneral.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetDealWithGeneralClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetDealWithGeneralClass.cs", "DealWithGeneral", "Deal");
			#endregion

            #region PutDealWithGeneralClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\PutClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutDealWithGeneralClass.cs", "DealWithGeneral", "Deal");
			#endregion
		}
	}
}
