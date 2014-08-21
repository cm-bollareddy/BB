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
	public class LoadDisclaimer
	{
		public LoadDisclaimer()
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

			// Invoke the object to get the XML result string
			//nErrorCode = p.LoadDisclaimer(strSessionID, out XmlString, out strErrorText);
			nErrorCode = p.LoadDisclaimer( out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadDisclaimer.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			DataTable dtDisclaimer = new DataTable("Disclaimer");

			// Create the columns for Funders
			XmlNodeList oNodeList = XmlDocument.SelectNodes("/DATAPACKET/METADATA/FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDisclaimer, oNodeList);
			dtDisclaimer.Constraints.Add("PK_DISCLAIMER", dtDisclaimer.Columns["DIS_ID"], true);
			//dtDeal.PrimaryKey = new DataColumn[] { dtDeal.Columns["DEA_ID"] };

			// Create the DataSet
			DataSet oDataSet = new DataSet("DisclaimerDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadDisclaimerDataSet.xsd";
			oDataSet.Tables.Add(dtDisclaimer);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadDisclaimerDataSet.xsd");
			#endregion ORION Schema Generation

			#region LoadDisclaimer.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadDisclaimer.xslt", oDataSet);
			#endregion

			#region LoadDisclaimerClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadDisclaimerClass.cs", "Disclaimer", "GetLookup");
			#endregion
		}
	}
}
