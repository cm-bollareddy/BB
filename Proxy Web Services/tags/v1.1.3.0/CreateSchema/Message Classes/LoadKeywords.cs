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
	public class LoadKeywords
	{
		public LoadKeywords()
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
			//nErrorCode = p.LoadKeywords(strSessionID, out XmlString, out strErrorText);
			nErrorCode = p.LoadKeywords( out XmlString, out strErrorText);

			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadKeywords.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("KeywordsDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadKeywordsDataSet.xsd";

			XmlNode oKeywordNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtKeyword = new DataTable("Keyword");
			XmlNodeList oKeywordNodes = oKeywordNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtKeyword, oKeywordNodes);
			dtKeyword.Constraints.Add("PK_KEYWORD", new DataColumn[] {dtKeyword.Columns["PBSPK_ID"]}, true);
			oDataSet.Tables.Add(dtKeyword);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadKeywordsDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadKeywords.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadKeywords.xslt", oDataSet);
			#endregion 

            #region LoadKeywordsClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadKeywordsClass.cs", "Keywords", "GetLookup");
			#endregion
		}
	}
}
