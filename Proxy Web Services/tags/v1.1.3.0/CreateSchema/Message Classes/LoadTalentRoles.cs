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
	public class LoadTalentRoles
	{
		public LoadTalentRoles()
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
			nErrorCode = p.LoadTalentRoles(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadTalentRoles.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("TalentRolesDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/LoadTalentRolesDataSet.xsd";

			XmlNode oTALENTROLESNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtTALENTROLES = new DataTable("TALENTROLES");
			XmlNodeList oTALENTROLESNodes = oTALENTROLESNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtTALENTROLES, oTALENTROLESNodes);
			dtTALENTROLES.Constraints.Add("PK_TALENTROLES", new DataColumn[] {dtTALENTROLES.Columns["TRO_ID"]}, true);
			oDataSet.Tables.Add(dtTALENTROLES);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadTalentRolesDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadTalentRoles.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadTalentRoles.xslt", oDataSet);
			#endregion GetDeal.xslt Generation

            #region LoadTalentRolesClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadTalentRolesClass.cs", "TalentRoles", "GetLookup");
			#endregion
		}
	}
}
