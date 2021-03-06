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
	public class LoadVideoFormat
	{
		public LoadVideoFormat()
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
			nErrorCode = p.LoadVideoFormat( out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadVideoFormat.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("VideoFormatDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadVideoFormatDataSet.xsd";

			XmlNode oVIDEOFORMATNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtVIDEOFORMAT = new DataTable("VIDEOFORMAT");
			XmlNodeList oVIDEOFORMATNodes = oVIDEOFORMATNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVIDEOFORMAT, oVIDEOFORMATNodes);
			dtVIDEOFORMAT.Constraints.Add("PK_VIDEOFORMAT", new DataColumn[] {dtVIDEOFORMAT.Columns["SLU_ID"]}, true);
			oDataSet.Tables.Add(dtVIDEOFORMAT);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadVideoFormatDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadVideoFormat.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadVideoFormat.xslt", oDataSet);
			#endregion 

            #region LoadVideoFormatClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadVideoFormatClass.cs", "VideoFormat", "GetLookup");
			#endregion
		}
	}
}
