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
	public class LoadOacPreOfferDescriptionType
	{
		public LoadOacPreOfferDescriptionType()
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
			nErrorCode = p.LoadOacPreOfferDescriptionType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadOacPreOfferDescriptionType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("OacPreOfferDescriptionTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadOacPreOfferDescriptionTypeDataSet.xsd";

			XmlNode oOACPREOFFERNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtOACPREOFFER = new DataTable("OACPREOFFERDESC");
			XmlNodeList oOACPREOFFERNodes = oOACPREOFFERNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtOACPREOFFER, oOACPREOFFERNodes);
			dtOACPREOFFER.Constraints.Add("PK_OACPREOFFER", new DataColumn[] {dtOACPREOFFER.Columns["PODT_ID"]}, true);
			oDataSet.Tables.Add(dtOACPREOFFER);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadOacPreOfferDescriptionTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadOacPreOfferDescriptionType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadOacPreOfferDescriptionType.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region LoadOacPreOfferDescriptionTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadOacPreOfferDescriptionTypeClass.cs", "OacPreOfferDescriptionType", "GetLookup");
			#endregion
		}
	}
}
