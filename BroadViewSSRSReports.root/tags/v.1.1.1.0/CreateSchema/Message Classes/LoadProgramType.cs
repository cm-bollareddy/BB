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
	public class LoadProgramType
	{
		public LoadProgramType()
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

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSGetLookup p = ComponentFactory.CreateGetLookupClass();
			//new TVSServer.rdmPBSGetLookup();

			// Invoke the object to get the XML result string
			//nErrorCode = p.LoadProgramType(strSessionID, out XmlString, out strErrorText);
			nErrorCode = p.LoadProgramType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadProgramType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("ProgramTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadProgramTypeDataSet.xsd";

			XmlNode oProgramTypeNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtProgramType = new DataTable("ProgramType");
			XmlNodeList oProgramTypeNodes = oProgramTypeNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtProgramType, oProgramTypeNodes);
			dtProgramType.Constraints.Add("PK_PROGRAMTYPE", new DataColumn[] {dtProgramType.Columns["ACA_ID"]}, true);
			oDataSet.Tables.Add(dtProgramType);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadProgramTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadProgramType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadProgramType.xslt", oDataSet);
			#endregion 

            #region LoadProgramTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadProgramTypeClass.cs", "ProgramType", "GetLookup");
			#endregion
		}
	}
}
