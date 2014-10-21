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
	public class LoadVCHIPValues
	{
		public LoadVCHIPValues()
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
			nErrorCode = p.LoadVCHIPValues( out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadVCHIPValues.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("VCHIPValuesDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadVCHIPValuesDataSet.xsd";

			XmlNode oVCHIPNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtVCHIP = new DataTable("VCHIP");
			XmlNodeList oVCHIPNodes = oVCHIPNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVCHIP, oVCHIPNodes);
			dtVCHIP.Constraints.Add("PK_VCHIP", new DataColumn[] {dtVCHIP.Columns["VCH_ID"], dtVCHIP.Columns["VCH_CODE"]}, true);
			oDataSet.Tables.Add(dtVCHIP);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadVCHIPValuesDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadVCHIPValues.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadVCHIPValues.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region LoadVCHIPValuesClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadVCHIPValuesClass.cs", "VCHIPValues", "GetLookup");
			#endregion
		}
	}
}
