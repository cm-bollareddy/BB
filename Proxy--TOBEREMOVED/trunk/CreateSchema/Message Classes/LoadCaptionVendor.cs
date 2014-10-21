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
	public class LoadCaptionVendor
	{
		public LoadCaptionVendor()
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
			//nErrorCode = p.LoadCaptionVendor(strSessionID, out XmlString, out strErrorText);
			nErrorCode = p.LoadCaptionVendor(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadCaptionVendor.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("CaptionVendorDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadCaptionVendorDataSet.xsd";

			XmlNode oCaptionVendorNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtCaptionVendor = new DataTable("CaptionVendor");
			XmlNodeList oCaptionVendorNodes = oCaptionVendorNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtCaptionVendor, oCaptionVendorNodes);
			dtCaptionVendor.Constraints.Add("PK_CAPTIONVENDOR", new DataColumn[] {dtCaptionVendor.Columns["PBSCV_ID"]}, true);
			oDataSet.Tables.Add(dtCaptionVendor);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadCaptionVendorDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadCaptionVendor.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadCaptionVendor.xslt", oDataSet);
			#endregion 

            #region LoadCaptionVendorClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadCaptionVendorClass.cs", "CaptionVendor", "GetLookup");
			#endregion
		}
	}
}
