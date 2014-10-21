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
	public class LoadMediaStatus
	{
		public LoadMediaStatus()
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
			nErrorCode = p.LoadMediaStatus(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadMediaStatus.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MediaStatusDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadMediaStatusDataSet.xsd";

			XmlNode oMEDIASTATUSNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMEDIASTATUS = new DataTable("MEDIASTATUS");
			XmlNodeList oMEDIASTATUSNodes = oMEDIASTATUSNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMEDIASTATUS, oMEDIASTATUSNodes);
			dtMEDIASTATUS.Constraints.Add("PK_MEDIASTATUS", new DataColumn[] {dtMEDIASTATUS.Columns["SLU_ID"]}, true);
			oDataSet.Tables.Add(dtMEDIASTATUS);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadMediaStatusDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadMediaStatus.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadMediaStatus.xslt", oDataSet);
			#endregion 

            #region LoadMediaStatusClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadMediaStatusClass.cs", "MediaStatus", "GetLookup");
			#endregion
		}
	}
}
