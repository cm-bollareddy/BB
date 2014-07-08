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
	public class GetDealWithFunding
	{
		public GetDealWithFunding()
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
			nErrorCode = p.GetDealWithFunding(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutDealWithFunding.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DealWithFundingDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/BVWebService/DealWithFundingDataSet.xsd";

			XmlNode oDEALNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtDEAL = new DataTable("DEAL");
			XmlNodeList oDEALNodes = oDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEAL, oDEALNodes);
			dtDEAL.Constraints.Add("PK_DEAL", new DataColumn[] {dtDEAL.Columns["DEA_ID"], dtDEAL.Columns["DEA_MDL_ID"]}, true);
			oDataSet.Tables.Add(dtDEAL);

			XmlNode oMASTERDEALNode = oDEALNode.SelectSingleNode("FIELDS/FIELD[@attrname='MASTERDEAL']");
			DataTable dtMASTERDEAL = new DataTable("MASTERDEAL");
			XmlNodeList oMASTERDEALNodes = oMASTERDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMASTERDEAL, oMASTERDEALNodes);
			dtMASTERDEAL.Constraints.Add("PK_MASTERDEAL", new DataColumn[] {dtMASTERDEAL.Columns["MDL_ID"]}, true);
			oDataSet.Tables.Add(dtMASTERDEAL);

			XmlNode oMASTERDEALFUNDINGNode = oDEALNode.SelectSingleNode("FIELDS/FIELD[@attrname='MASTERDEALFUNDING']");
			DataTable dtMASTERDEALFUNDING = new DataTable("MASTERDEALFUNDING");
			XmlNodeList oMASTERDEALFUNDINGNodes = oMASTERDEALFUNDINGNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMASTERDEALFUNDING, oMASTERDEALFUNDINGNodes);
			dtMASTERDEALFUNDING.Constraints.Add("PK_MASTERDEALFUNDING", new DataColumn[] {dtMASTERDEALFUNDING.Columns["MDF_ID"]}, true);
			oDataSet.Tables.Add(dtMASTERDEALFUNDING);

			XmlNode oDEALFUNDINGNode = oDEALNode.SelectSingleNode("FIELDS/FIELD[@attrname='DEALFUNDING']");
			DataTable dtDEALFUNDING = new DataTable("DEALFUNDING");
			XmlNodeList oDEALFUNDINGNodes = oDEALFUNDINGNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEALFUNDING, oDEALFUNDINGNodes);
			dtDEALFUNDING.Constraints.Add("PK_DEALFUNDING", new DataColumn[] {dtDEALFUNDING.Columns["DEF_ID"]}, true);
			oDataSet.Tables.Add(dtDEALFUNDING);

			oDataSet.Relations.Add("FK_DEAL_MASTERDEAL", dtDEAL.Columns["DEA_MDL_ID"], dtMASTERDEAL.Columns["MDL_ID"]);
			oDataSet.Relations.Add("FK_DEAL_MASTERDEALFUNDING", dtDEAL.Columns["DEA_MDL_ID"], dtMASTERDEALFUNDING.Columns["MDF_MDL_ID"]);
			oDataSet.Relations.Add("FK_DEAL_DEALFUNDING", dtDEAL.Columns["DEA_ID"], dtDEALFUNDING.Columns["DEF_DEA_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DealWithFundingDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetDealWithFunding.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetDealWithFunding.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region PutDealWithFunding.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutDealWithFunding.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetClassTemplate.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetDealWithFundingClass.cs", "DealWithFunding", "Deal");
			#endregion

            #region SetClassTemplate.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\PutClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutDealWithFundingClass.cs", "DealWithFunding", "Deal");
			#endregion
		}
	}
}
