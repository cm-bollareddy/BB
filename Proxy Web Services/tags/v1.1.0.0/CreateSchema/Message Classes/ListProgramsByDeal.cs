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
	public class ListProgramsByDeal
	{
		public ListProgramsByDeal()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";
			//int nID =0;
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
			TVSServer.rdmPBSProgram p = ComponentFactory.CreateProgramClass();
			//new TVSServer.rdmPBSGetLookup();

			// Invoke the object to get the XML result string
            nErrorCode = p.ListProgramsByDeal(strSessionID, 24381484, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  List this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListProgramsByDeal.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("ProgramsByDealDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ListProgramsByDealDataSet.xsd";

			XmlNode oASSETNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtASSET = new DataTable("ASSET");
			XmlNodeList oASSETNodes = oASSETNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtASSET, oASSETNodes);
			dtASSET.Constraints.Add("PK_ASSET", new DataColumn[] {dtASSET.Columns["ASS_ID"]}, true);
			oDataSet.Tables.Add(dtASSET);

			XmlNode oVERSIONNode = oASSETNode.SelectSingleNode("FIELDS/FIELD[@attrname='VERSION']");
			DataTable dtVERSION = new DataTable("VERSION");
			XmlNodeList oVERSIONNodes = oVERSIONNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVERSION, oVERSIONNodes);
			dtVERSION.Constraints.Add("PK_VERSION", new DataColumn[] {dtVERSION.Columns["VER_ID"]}, true);
			oDataSet.Tables.Add(dtVERSION);

			oDataSet.Relations.Add("FK_ASSET_VERSION", dtASSET.Columns["ASS_ID"], dtVERSION.Columns["VER_ASS_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListProgramsByDealDataSet.xsd");

			#endregion ORION Schema Generation

            #region ListProgramsByDeal.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListProgramsByDeal.xslt", oDataSet);
			#endregion 

            #region ListProgramsByDealClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ListProgramsByDealClass.cs", "ProgramsByDeal", "Program");
            #endregion


		}
	}
}
