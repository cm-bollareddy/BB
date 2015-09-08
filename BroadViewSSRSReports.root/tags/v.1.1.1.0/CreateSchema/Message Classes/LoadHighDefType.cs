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
	public class LoadHighDefType
	{
		public LoadHighDefType()
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
			nErrorCode = p.LoadHighDefType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadHighDefType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("HighDefTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadHighDefTypeDataSet.xsd";

			XmlNode oHIGHDEFNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtHIGHDEF = new DataTable("HIGHDEF");
			XmlNodeList oHIGHDEFNodes = oHIGHDEFNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtHIGHDEF, oHIGHDEFNodes);
			dtHIGHDEF.Constraints.Add("PK_HIGHDEF", new DataColumn[] {dtHIGHDEF.Columns["SLU_ID"]}, true);
			oDataSet.Tables.Add(dtHIGHDEF);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadHighDefTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadHighDefType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadHighDefType.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region LoadHighDefTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadHighDefTypeClass.cs", "HighDefType", "GetLookup");
			#endregion
		}
	}
}
