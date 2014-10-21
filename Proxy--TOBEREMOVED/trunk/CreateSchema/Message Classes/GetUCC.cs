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
	public class GetUCC
	{
		public GetUCC()
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
			TVSServer.rdmPBSManageTable p = ComponentFactory.CreateManageTableClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetUCC(strSessionID, 334, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutUCC.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("UCCDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/UCCDataSet.xsd";

			XmlNode oUCCNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtUCC = new DataTable("UCC");
			XmlNodeList oUCCNodes = oUCCNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtUCC, oUCCNodes);
			dtUCC.Constraints.Add("PK_UCC", new DataColumn[] {dtUCC.Columns["PUCC_ID"]}, true);
			oDataSet.Tables.Add(dtUCC);

			XmlNode oVW_PBSUCCDETAILNode = oUCCNode.SelectSingleNode("FIELDS/FIELD[@attrname='VW_PBSUCCDETAIL']");
			DataTable dtVW_PBSUCCDETAIL = new DataTable("VW_PBSUCCDETAIL");
			XmlNodeList oVW_PBSUCCDETAILNodes = oVW_PBSUCCDETAILNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVW_PBSUCCDETAIL, oVW_PBSUCCDETAILNodes);
			dtVW_PBSUCCDETAIL.Constraints.Add("PK_VW_PBSUCCDETAIL", new DataColumn[] {dtVW_PBSUCCDETAIL.Columns["PUCCD_ID"]}, true);
			oDataSet.Tables.Add(dtVW_PBSUCCDETAIL);

			oDataSet.Relations.Add("FK_UCC_VW_PBSUCCDETAIL", dtUCC.Columns["PUCC_ID"], dtVW_PBSUCCDETAIL.Columns["PUCCD_UCC_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\UCCDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetUCC.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetUCC.xslt", oDataSet);
			#endregion 

            #region PutUCC.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutUCC.xslt", XmlDocument, oDataSet);
			#endregion

            //No DeleteUCC xslt

            #region GetUCCClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetUCCClass.cs", "UCC", "ManageTable");
			#endregion

            #region PutUCCClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutUCCClass.cs", "UCC", "ManageTable");
			#endregion

            #region DeleteUCCClass.cs Generation
            GenDeleteClassHelper.GenClass(strTargetDir + @"\..\Templates\DeleteClassTemplate.cs.txt", strTargetDir + @"\xsltClass\DeleteUCCClass.cs", "UCC", "ManageTable");
            #endregion

		}
	}
}
