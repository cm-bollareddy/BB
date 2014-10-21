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
	public class LoadBillToContact
	{
		public LoadBillToContact()
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
			nErrorCode = p.LoadBillToContact(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadBillToContact.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("BillToContactDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadBillToContactDataSet.xsd";

			XmlNode oMASTERNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMASTER = new DataTable("MASTER");
			XmlNodeList oMASTERNodes = oMASTERNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMASTER, oMASTERNodes);
			dtMASTER.Constraints.Add("PK_MASTER", new DataColumn[] {dtMASTER.Columns["PBSBC_ID"]}, true);
			oDataSet.Tables.Add(dtMASTER);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadBillToContactDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadBillToContact.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadBillToContact.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region LoadBillToContactClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadBillToContactClass.cs", "BillToContact", "GetLookup");
			#endregion
		}
	}
}
