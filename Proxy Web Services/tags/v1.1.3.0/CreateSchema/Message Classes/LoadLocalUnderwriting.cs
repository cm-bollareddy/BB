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
	public class LoadLocalUnderwriting
	{
		public LoadLocalUnderwriting()
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
			//nErrorCode = p.LoadLocalUnderwriting(strSessionID, out XmlString, out strErrorText);
			nErrorCode = p.LoadLocalUnderwriting( out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadLocalUnderwriting.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			DataTable dt = new DataTable("LocalUnderwriting");

			// Create the columns for Company
			XmlNodeList oNodeList = XmlDocument.SelectNodes("/DATAPACKET/METADATA/FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dt, oNodeList);
			dt.Constraints.Add("PK_LOCALUNDERWRITING", dt.Columns["SLU_ID"], true);
			//dtDeal.PrimaryKey = new DataColumn[] { dtDeal.Columns["DEA_ID"] };

			// Create the DataSet
			DataSet oDataSet = new DataSet("LocalUnderwritingDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadLocalUnderwritingDataSet.xsd";
			oDataSet.Tables.Add(dt);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadLocalUnderwritingDataSet.xsd");
			#endregion ORION Schema Generation

			#region LoadLocalUnderwriting.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadLocalUnderwriting.xslt", oDataSet);
			#endregion

			#region LoadLocalUnderwritingClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadLocalUnderwritingClass.cs", "LocalUnderwriting", "GetLookup");
			#endregion
		}
	}
}
