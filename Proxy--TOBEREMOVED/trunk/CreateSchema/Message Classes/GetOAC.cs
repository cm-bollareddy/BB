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
	public class GetOAC
	{
		public GetOAC()
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
			nErrorCode = p.GetOAC(strSessionID, 505, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutOAC.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("OACDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/OACDataSet.xsd";

			XmlNode oOACNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtOAC = new DataTable("OAC");
			XmlNodeList oOACNodes = oOACNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtOAC, oOACNodes);
			dtOAC.Constraints.Add("PK_OAC", new DataColumn[] {dtOAC.Columns["POAC_ID"]}, true);
			oDataSet.Tables.Add(dtOAC);

			XmlNode oVW_PBSOACENTITYNode = oOACNode.SelectSingleNode("FIELDS/FIELD[@attrname='VW_PBSOACENTITY']");
			DataTable dtVW_PBSOACENTITY = new DataTable("VW_PBSOACENTITY");
			XmlNodeList oVW_PBSOACENTITYNodes = oVW_PBSOACENTITYNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVW_PBSOACENTITY, oVW_PBSOACENTITYNodes);
			dtVW_PBSOACENTITY.Constraints.Add("PK_VW_PBSOACENTITY", new DataColumn[] {dtVW_PBSOACENTITY.Columns["POEN_ID"]}, true);
			oDataSet.Tables.Add(dtVW_PBSOACENTITY);

			XmlNode oPBSOACITEMNode = oVW_PBSOACENTITYNode.SelectSingleNode("FIELDS/FIELD[@attrname='PBSOACITEM']");
			DataTable dtPBSOACITEM = new DataTable("PBSOACITEM");
			XmlNodeList oPBSOACITEMNodes = oPBSOACITEMNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPBSOACITEM, oPBSOACITEMNodes);
			dtPBSOACITEM.Constraints.Add("PK_PBSOACITEM", new DataColumn[] {dtPBSOACITEM.Columns["POAI_ID"]}, true);
			oDataSet.Tables.Add(dtPBSOACITEM);

			oDataSet.Relations.Add("FK_OAC_VW_PBSOACENTITY", dtOAC.Columns["POAC_ID"], dtVW_PBSOACENTITY.Columns["POEN_OAC_ID"]);
			oDataSet.Relations.Add("FK_VW_PBSOACENTITY_PBSOACITEM", dtVW_PBSOACENTITY.Columns["POEN_ID"], dtPBSOACITEM.Columns["POAI_OEN_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\OACDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetOAC.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetOAC.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region PutOAC.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutOAC.xslt", XmlDocument, oDataSet);
			#endregion

            //No DeleteOAC xslt

            #region GetOACClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetOACClass.cs", "OAC", "ManageTable");
			#endregion

            #region PutOACClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutOACClass.cs", "OAC", "ManageTable");
			#endregion

            #region DeleteOACClass.cs Generation
            GenDeleteClassHelper.GenClass(strTargetDir + @"\..\Templates\DeleteClassTemplate.cs.txt", strTargetDir + @"\xsltClass\DeleteOACClass.cs", "OAC", "ManageTable");
            #endregion



		}
	}
}
