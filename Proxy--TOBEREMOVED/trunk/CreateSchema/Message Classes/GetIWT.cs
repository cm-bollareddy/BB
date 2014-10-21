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
	public class GetIWT
	{
		public GetIWT()
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
			nErrorCode = p.GetIWT(strSessionID, 906, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutIWT.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("IWTDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/IWTDataSet.xsd";

			XmlNode oIWTNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtIWT = new DataTable("IWT");
			XmlNodeList oIWTNodes = oIWTNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtIWT, oIWTNodes);
			dtIWT.Constraints.Add("PK_IWT", new DataColumn[] {dtIWT.Columns["PIWT_ID"]}, true);
			oDataSet.Tables.Add(dtIWT);

			XmlNode oPBSIWTDETAILNode = oIWTNode.SelectSingleNode("FIELDS/FIELD[@attrname='PBSIWTDETAIL']");
			DataTable dtPBSIWTDETAIL = new DataTable("PBSIWTDETAIL");
			XmlNodeList oPBSIWTDETAILNodes = oPBSIWTDETAILNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPBSIWTDETAIL, oPBSIWTDETAILNodes);
			dtPBSIWTDETAIL.Constraints.Add("PK_PBSIWTDETAIL", new DataColumn[] {dtPBSIWTDETAIL.Columns["PIWTD_ID"]}, true);
			oDataSet.Tables.Add(dtPBSIWTDETAIL);

			oDataSet.Relations.Add("FK_IWT_PBSIWTDETAIL", dtIWT.Columns["PIWT_ID"], dtPBSIWTDETAIL.Columns["PIWTD_PIWT_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\IWTDataSet.xsd");

			#endregion ORION Schema Generation

			#region GetIWT.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetIWT.xslt", oDataSet);
			#endregion 

            #region PutIWT.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutIWT.xslt", XmlDocument, oDataSet);
			#endregion

            //No DeleteIWT xslt

            #region GetIWTClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetIWTClass.cs", "IWT", "ManageTable");
			#endregion

            #region PutIWTClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutIWTClass.cs", "IWT", "ManageTable");
			#endregion

            #region DeleteIWTClass.cs Generation
            GenDeleteClassHelper.GenClass(strTargetDir + @"\..\Templates\DeleteClassTemplate.cs.txt", strTargetDir + @"\xsltClass\DeleteIWTClass.cs", "IWT", "ManageTable");
            #endregion
		}
	}
}
