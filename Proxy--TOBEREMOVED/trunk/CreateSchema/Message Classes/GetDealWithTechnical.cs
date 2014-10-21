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
	public class GetDealWithTechnical
	{
		public GetDealWithTechnical()
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
			nErrorCode = p.GetDealWithTechnical(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutDealWithTechnical.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DealWithTechnicalDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/DealWithTechnicalDataSet.xsd";

			XmlNode oDEALNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtDEAL = new DataTable("DEAL");
			XmlNodeList oDEALNodes = oDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEAL, oDEALNodes);
			dtDEAL.Constraints.Add("PK_DEAL", new DataColumn[] {dtDEAL.Columns["DEA_ID"]}, true);
			oDataSet.Tables.Add(dtDEAL);

			XmlNode oDEALVERSIONTYPENode = oDEALNode.SelectSingleNode("FIELDS/FIELD[@attrname='DEALVERSIONTYPE']");
			DataTable dtDEALVERSIONTYPE = new DataTable("DEALVERSIONTYPE");
			XmlNodeList oDEALVERSIONTYPENodes = oDEALVERSIONTYPENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEALVERSIONTYPE, oDEALVERSIONTYPENodes);
			dtDEALVERSIONTYPE.Constraints.Add("PK_DEALVERSIONTYPE", new DataColumn[] {dtDEALVERSIONTYPE.Columns["DVT_ID"]}, true);
			oDataSet.Tables.Add(dtDEALVERSIONTYPE);

			oDataSet.Relations.Add("FK_DEAL_DEALVERSIONTYPE", dtDEAL.Columns["DEA_ID"], dtDEALVERSIONTYPE.Columns["DVT_DEA_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DealWithTechnicalDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetDealWithTechnical.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetDealWithTechnical.xslt", oDataSet);
			#endregion

            #region PutDealWithTechnical.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutDealWithTechnical.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetDealWithTechnicalClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetDealWithTechnicalClass.cs", "DealWithTechnical", "Deal");
			#endregion

            #region PutDealWithTechnicalClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\PutClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutDealWithTechnicalClass.cs", "DealWithTechnical", "Deal");
			#endregion
		}
	}
}
