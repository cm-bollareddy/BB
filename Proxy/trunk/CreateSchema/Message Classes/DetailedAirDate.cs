using System;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using BVWebService;
using TVSServer = OrionProxy;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for DetailedAirDate
	/// </summary>
	public class DetailedAirDate
	{
		public DetailedAirDate()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSSearch p = ComponentFactory.CreateSearchClass();

			// Invoke the object to get the XML result string
			int nErrorCode		= 0;
			string sErrorText	= string.Empty;
			string sXmlString	= string.Empty;
			int iMediaInventoryId = 8073570;

			nErrorCode = p.DetailedAirDate(strSessionID, iMediaInventoryId,out sXmlString, out sErrorText);

			if (nErrorCode != 0)
			{
				MessageBox.Show(sErrorText);
				return;
			}
			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(sXmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\DetailedAirDate.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DetailedAirDateDataSet");
			oDataSet.Namespace = "http://localhost/SAWebService/DetailedAirDateDataSet.xsd";

			XmlNode oMASTERNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMASTER = new DataTable("MASTER");
			XmlNodeList oMASTERNodes = oMASTERNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMASTER, oMASTERNodes);
			//dtMASTER.Constraints.Add("PK_MASTER", new DataColumn[] {}, true);
			oDataSet.Tables.Add(dtMASTER);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DetailedAirDateDataSet.xsd");

			#endregion ORION Schema Generation

            #region DetailedAirDate.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\DetailedAirDate.xslt", oDataSet);
			#endregion


            #region DetailedAirDateClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\DetailedAirDateTemplate.cs.txt", strTargetDir + @"\xsltClass\DetailedAirDateClass.cs", "DetailedAirDate", "Search");
			#endregion
		}
	}
}
