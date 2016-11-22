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
	public class LoadPackageType
	{
		public LoadPackageType()
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
			nErrorCode = p.LoadPackageType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadPackageType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("PackageTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadPackageTypeDataSet.xsd";

			XmlNode oPACKAGETYPENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtPACKAGETYPE = new DataTable("PACKAGETYPE");
			XmlNodeList oPACKAGETYPENodes = oPACKAGETYPENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPACKAGETYPE, oPACKAGETYPENodes);
			dtPACKAGETYPE.Constraints.Add("PK_PACKAGETYPE", new DataColumn[] {dtPACKAGETYPE.Columns["VET_ID"]}, true);
			oDataSet.Tables.Add(dtPACKAGETYPE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadPackageTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadPackageType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadPackageType.xslt", oDataSet);
			#endregion 

            #region LoadPackageTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadPackageTypeClass.cs", "PackageType", "GetLookup");
			#endregion
		}
	}
}
