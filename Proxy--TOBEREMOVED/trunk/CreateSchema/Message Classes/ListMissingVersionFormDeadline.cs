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
	public class ListMissingVersionFormDeadline
	{
		public ListMissingVersionFormDeadline()
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
			nErrorCode = p.ListMissingVersionFormDeadline(strSessionID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  List this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListMissingVersionFormDeadline.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MissingVersionFormDeadlineDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ListMissingVersionFormDeadlineDataSet.xsd";

			XmlNode oVERSION_DEADLINE_TEMPNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtVERSION_DEADLINE_TEMP = new DataTable("VERSION_DEADLINE_TEMP");
			XmlNodeList oVERSION_DEADLINE_TEMPNodes = oVERSION_DEADLINE_TEMPNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVERSION_DEADLINE_TEMP, oVERSION_DEADLINE_TEMPNodes);
			dtVERSION_DEADLINE_TEMP.Constraints.Add("PK_VERSION_DEADLINE_TEMP", new DataColumn[] {dtVERSION_DEADLINE_TEMP.Columns["VER_ID"],dtVERSION_DEADLINE_TEMP.Columns["TABTYPE"]}, true);
			oDataSet.Tables.Add(dtVERSION_DEADLINE_TEMP);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListMissingVersionFormDeadlineDataSet.xsd");

			#endregion ORION Schema Generation

            #region ListMissingVersionFormDeadline.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListMissingVersionFormDeadline.xslt", oDataSet);
			#endregion 

            #region ListMissingVersionFormDeadlineClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListMissingEVFormDeadlineClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ListMissingVersionFormDeadlineClass.cs", "MissingVersionFormDeadline", "DeadlineNotification");
			#endregion
		}
	}
}
