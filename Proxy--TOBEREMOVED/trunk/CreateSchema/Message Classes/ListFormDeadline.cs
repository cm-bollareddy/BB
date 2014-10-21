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
	public class ListFormDeadline
	{
		public ListFormDeadline()
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
			//new TVSServer.rdmPBSGetLookupClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.ListFormDeadline(strSessionID,nID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  List this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ListFormDeadline.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("FormDeadlineDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ListFormDeadlineDataSet.xsd";

			XmlNode oFORM_DEADLINE_TEMPNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtFORM_DEADLINE_TEMP = new DataTable("FORM_DEADLINE_TEMP");
			XmlNodeList oFORM_DEADLINE_TEMPNodes = oFORM_DEADLINE_TEMPNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtFORM_DEADLINE_TEMP, oFORM_DEADLINE_TEMPNodes);
			dtFORM_DEADLINE_TEMP.Constraints.Add("PK_FORM_DEADLINE_TEMP", new DataColumn[] {dtFORM_DEADLINE_TEMP.Columns["DEA_ID"],dtFORM_DEADLINE_TEMP.Columns["TABID"],dtFORM_DEADLINE_TEMP.Columns["TABTYPE"]}, true);
			oDataSet.Tables.Add(dtFORM_DEADLINE_TEMP);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ListFormDeadlineDataSet.xsd");

			#endregion ORION Schema Generation

            #region ListFormDeadline.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ListFormDeadline.xslt", oDataSet);
			#endregion

            #region ListFormDeadlineClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ListClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ListFormDeadlineClass.cs", "FormDeadline", "DeadlineNotification");
			#endregion
		}
	}
}
