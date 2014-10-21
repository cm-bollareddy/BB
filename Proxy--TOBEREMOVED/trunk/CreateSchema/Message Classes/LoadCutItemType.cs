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
	public class LoadCutItemType
	{
		public LoadCutItemType()
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
			nErrorCode = p.LoadCutItemType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadCutItemType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("CutItemTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadCutItemTypeDataSet.xsd";

			XmlNode oCUTITEMTYPENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtCUTITEMTYPE = new DataTable("CUTITEMTYPE");
			XmlNodeList oCUTITEMTYPENodes = oCUTITEMTYPENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtCUTITEMTYPE, oCUTITEMTYPENodes);
			dtCUTITEMTYPE.Constraints.Add("PK_CUTITEMTYPE", new DataColumn[] {dtCUTITEMTYPE.Columns["MICT_ID"]}, true);
			oDataSet.Tables.Add(dtCUTITEMTYPE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadCutItemTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadCutItemType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadCutItemType.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region LoadCutItemTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadCutItemTypeClass.cs", "CutItemType", "GetLookup");
			#endregion
		}
	}
}
