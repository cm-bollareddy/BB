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
	public class ListProgramPackagesByProgram
	{
		public ListProgramPackagesByProgram()
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
			nErrorCode = p.ListProgramPackagesByProgram(strSessionID,4875, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  List this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListProgramPackagesByProgram.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("ProgramPackagesByProgramDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ListProgramPackagesByProgramDataSet.xsd";

			XmlNode oVERSIONNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtVERSION = new DataTable("VERSION");
			XmlNodeList oVERSIONNodes = oVERSIONNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVERSION, oVERSIONNodes);
			dtVERSION.Constraints.Add("PK_VERSION", new DataColumn[] {dtVERSION.Columns["VER_ID"]}, true);
			oDataSet.Tables.Add(dtVERSION);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListProgramPackagesByProgramDataSet.xsd");

			#endregion ORION Schema Generation

            #region ListProgramPackagesByProgram.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListProgramPackagesByProgram.xslt", oDataSet);
            #endregion 

            #region ListProgramPackagesByProgramClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ListProgramPackagesByProgramClass.cs", "ProgramPackagesByProgram", "Program");
            #endregion


		}
	}
}
