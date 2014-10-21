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
	public class LoadMediaFeature
	{
		public LoadMediaFeature()
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
			nErrorCode = p.LoadMediaFeature(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadMediaFeature.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MediaFeatureDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadMediaFeatureDataSet.xsd";

			XmlNode oMEDIAFEATURENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMEDIAFEATURE = new DataTable("MEDIAFEATURE");
			XmlNodeList oMEDIAFEATURENodes = oMEDIAFEATURENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMEDIAFEATURE, oMEDIAFEATURENodes);
			dtMEDIAFEATURE.Constraints.Add("PK_MEDIAFEATURE", new DataColumn[] {dtMEDIAFEATURE.Columns["MEF_ID"]}, true);
			oDataSet.Tables.Add(dtMEDIAFEATURE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadMediaFeatureDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadMediaFeature.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadMediaFeature.xslt", oDataSet);
			#endregion 

            #region LoadMediaFeatureClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadMediaFeatureClass.cs", "MediaFeature", "GetLookup");
			#endregion
		}
	}
}
