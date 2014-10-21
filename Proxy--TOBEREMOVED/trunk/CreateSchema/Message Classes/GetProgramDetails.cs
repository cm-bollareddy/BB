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
	public class GetProgramDetails
	{
		public GetProgramDetails()
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
			TVSServer.rdmPBSProgram p = ComponentFactory.CreateProgramClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetProgramDetails(strSessionID, 6197186, false,false, out strLockID, out XmlString, out strErrorText);
            
			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutProgramDetails.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("ProgramDetailsDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ProgramDetailsDataSet.xsd";

			XmlNode oASSETNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtASSET = new DataTable("ASSET");
			XmlNodeList oASSETNodes = oASSETNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtASSET, oASSETNodes);
			dtASSET.Constraints.Add("PK_ASSET", new DataColumn[] {dtASSET.Columns["ASS_ID"]}, true);
			oDataSet.Tables.Add(dtASSET);

			XmlNode oCASTTABLENode = oASSETNode.SelectSingleNode("FIELDS/FIELD[@attrname='CASTTABLE']");
			DataTable dtCASTTABLE = new DataTable("CASTTABLE");
			XmlNodeList oCASTTABLENodes = oCASTTABLENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtCASTTABLE, oCASTTABLENodes);
			// have to add a composite primary key for ASS_DI, TAL_ID and TRO_ID
			dtCASTTABLE.Constraints.Add("PK_CASTTABLE", new DataColumn[] {dtCASTTABLE.Columns["TAL_ID"],dtCASTTABLE.Columns["TRO_ID"],dtCASTTABLE.Columns["ASS_ID"]}, true);
			oDataSet.Tables.Add(dtCASTTABLE);

			XmlNode oASSET_PBSPROGRAMKEYWORDNode = oASSETNode.SelectSingleNode("FIELDS/FIELD[@attrname='ASSET_PBSPROGRAMKEYWORD']");
			DataTable dtASSET_PBSPROGRAMKEYWORD = new DataTable("ASSET_PBSPROGRAMKEYWORD");
			XmlNodeList oASSET_PBSPROGRAMKEYWORDNodes = oASSET_PBSPROGRAMKEYWORDNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtASSET_PBSPROGRAMKEYWORD, oASSET_PBSPROGRAMKEYWORDNodes);
			dtASSET_PBSPROGRAMKEYWORD.Constraints.Add("PK_ASSET_PBSPROGRAMKEYWORD", new DataColumn[] {dtASSET_PBSPROGRAMKEYWORD.Columns["PBSPK_ID"]}, true);
			oDataSet.Tables.Add(dtASSET_PBSPROGRAMKEYWORD);

			oDataSet.Relations.Add("FK_ASSET_CASTTABLE", dtASSET.Columns["ASS_ID"], dtCASTTABLE.Columns["ASS_ID"]);
			oDataSet.Relations.Add("FK_ASSET_ASSET_PBSPROGRAMKEYWORD", dtASSET.Columns["ASS_ID"], dtASSET_PBSPROGRAMKEYWORD.Columns["ASS_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ProgramDetailsDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetProgramDetails.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetProgramDetails.xslt", oDataSet);
			#endregion 

            #region PutProgramDetails.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutProgramDetails.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetProgramDetailsClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetProgramDetailsClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetProgramDetailsClass.cs", "ProgramDetails", "Program");
			#endregion

            #region PutProgramDetailsClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\PutProgramDetailsClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutProgramDetailsClass.cs", "ProgramDetails", "Program");
			#endregion
		}
	}
}
