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
	public class LoadMediaInventoryType
	{
		public LoadMediaInventoryType()
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
			nErrorCode = p.LoadMediaInventoryType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadMediaInventoryType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MediaInventoryTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadMediaInventoryTypeDataSet.xsd";

			XmlNode oMEDIAINVENTORYTYPENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMEDIAINVENTORYTYPE = new DataTable("MEDIAINVENTORYTYPE");
			XmlNodeList oMEDIAINVENTORYTYPENodes = oMEDIAINVENTORYTYPENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMEDIAINVENTORYTYPE, oMEDIAINVENTORYTYPENodes);
			dtMEDIAINVENTORYTYPE.Constraints.Add("PK_MEDIAINVENTORYTYPE", new DataColumn[] {dtMEDIAINVENTORYTYPE.Columns["MIT_ID"]}, true);
			oDataSet.Tables.Add(dtMEDIAINVENTORYTYPE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadMediaInventoryTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadMediaInventoryType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadMediaInventoryType.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region LoadMediaInventoryTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadMediaInventoryTypeClass.cs", "MediaInventoryType", "GetLookup");
			#endregion
		}
	}
}
