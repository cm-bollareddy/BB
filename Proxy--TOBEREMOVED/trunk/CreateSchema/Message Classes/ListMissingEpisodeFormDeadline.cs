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
	public class ListMissingEpisodeFormDeadline
	{
		public ListMissingEpisodeFormDeadline()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";
			//int nID =0;
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
			TVSServer.rdmPBSDeadlineNotification p = ComponentFactory.CreateDeadlineNotificationClass();
			//new TVSServer.rdmPBSGetLookup();

			// Invoke the object to get the XML result string
			nErrorCode = p.ListMissingEpisodeFormDeadline(strSessionID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  List this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListMissingEpisodeFormDeadline.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MissingEpisodeFormDeadlineDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ListMissingEpisodeFormDeadlineDataSet.xsd";

			XmlNode oEPISODE_DEADLINE_TEMPNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtEPISODE_DEADLINE_TEMP = new DataTable("EPISODE_DEADLINE_TEMP");
			XmlNodeList oEPISODE_DEADLINE_TEMPNodes = oEPISODE_DEADLINE_TEMPNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtEPISODE_DEADLINE_TEMP, oEPISODE_DEADLINE_TEMPNodes);
			dtEPISODE_DEADLINE_TEMP.Constraints.Add("PK_EPISODE_DEADLINE_TEMP", new DataColumn[] {dtEPISODE_DEADLINE_TEMP.Columns["DEA_ID"],dtEPISODE_DEADLINE_TEMP.Columns["ASS_ID"],dtEPISODE_DEADLINE_TEMP.Columns["TABTYPE"]}, true);
			oDataSet.Tables.Add(dtEPISODE_DEADLINE_TEMP);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListMissingEpisodeFormDeadlineDataSet.xsd");

			#endregion ORION Schema Generation

            #region ListMissingEpisodeFormDeadline.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListMissingEpisodeFormDeadline.xslt", oDataSet);
			#endregion 

            #region ListMissingEpisodeFormDeadlineClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListMissingEVFormDeadlineClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ListMissingEpisodeFormDeadlineClass.cs", "MissingEpisodeFormDeadline", "DeadlineNotification");
			#endregion
		}
	}
}
