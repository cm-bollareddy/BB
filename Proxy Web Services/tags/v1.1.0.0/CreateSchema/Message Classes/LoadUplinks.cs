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
	public class LoadUplinks
	{
		public LoadUplinks()
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
			//nErrorCode = p.LoadUplinks(strSessionID, out XmlString, out strErrorText);
			nErrorCode = p.LoadUplinks( out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadUplinks.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("UplinksDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadUplinksDataSet.xsd";

			XmlNode oUplinksNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtUplinks = new DataTable("Uplinks");
			XmlNodeList oUplinksNodes = oUplinksNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtUplinks, oUplinksNodes);
			dtUplinks.Constraints.Add("PK_UPLINKS", new DataColumn[] {dtUplinks.Columns["PBSUP_ID"]}, true);
			oDataSet.Tables.Add(dtUplinks);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadUplinksDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadUplinks.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadUplinks.xslt", oDataSet);
			#endregion 

            #region LoadUplinksClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadUplinksClass.cs", "Uplinks", "GetLookup");
			#endregion
		}
	}
}
