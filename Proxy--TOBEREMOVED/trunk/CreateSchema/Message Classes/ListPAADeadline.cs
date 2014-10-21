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
	public class ListPAADeadline
	{
		public ListPAADeadline()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";
			int nID =0;
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
			nErrorCode = p.ListPAADeadline(strSessionID,nID, out XmlString, out strErrorText);

			//
			// End our session
			//
			s.Logout(strSessionID);


			//  List this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListPAADeadline.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("PAADeadlineDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ListPAADeadlineDataSet.xsd";

			XmlNode oPAA_DEADLINE_TEMPNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtPAA_DEADLINE_TEMP = new DataTable("PAA_DEADLINE_TEMP");
			XmlNodeList oPAA_DEADLINE_TEMPNodes = oPAA_DEADLINE_TEMPNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPAA_DEADLINE_TEMP, oPAA_DEADLINE_TEMPNodes);
			dtPAA_DEADLINE_TEMP.Constraints.Add("PK_PAA_DEADLINE_TEMP", new DataColumn[] {dtPAA_DEADLINE_TEMP.Columns["DEA_ID"]}, true);
			oDataSet.Tables.Add(dtPAA_DEADLINE_TEMP);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListPAADeadlineDataSet.xsd");

			#endregion ORION Schema Generation

            #region ListPAADeadline.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListPAADeadline.xslt", oDataSet);
			#endregion 

            #region ListPAADeadlineClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ListPAADeadlineClass.cs", "PAADeadline" , "DeadlineNotification");
			#endregion
		}
	}
}
