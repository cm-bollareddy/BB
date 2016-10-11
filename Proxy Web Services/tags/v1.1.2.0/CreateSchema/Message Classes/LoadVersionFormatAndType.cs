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
	public class LoadVersionFormatAndType
	{
		public LoadVersionFormatAndType()
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
			//nErrorCode = p.LoadVersionFormatAndType(strSessionID, out XmlString, out strErrorText);
			nErrorCode = p.LoadVersionFormatAndType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadVersionFormatAndType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("VersionFormatAndTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadVersionFormatAndTypeDataSet.xsd";

			XmlNode oVersionFormatAndTypeNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtVersionFormatAndType = new DataTable("VersionFormatAndType");
			XmlNodeList oVersionFormatAndTypeNodes = oVersionFormatAndTypeNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVersionFormatAndType, oVersionFormatAndTypeNodes);
			dtVersionFormatAndType.Constraints.Add("PK_VERSIONFORMATANDTYPE", new DataColumn[] {dtVersionFormatAndType.Columns["VET_ID"]}, true);
			oDataSet.Tables.Add(dtVersionFormatAndType);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadVersionFormatAndTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadVersionFormatAndType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadVersionFormatAndType.xslt", oDataSet);
			#endregion 

            #region LoadVersionFormatAndTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadVersionFormatAndTypeClass.cs", "VersionFormatAndType", "GetLookup");
			#endregion
		}
	}
}
