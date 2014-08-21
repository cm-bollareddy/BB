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
	/// Summary description for GetAdCopy.
	/// </summary>
	public class GetAdCopy
	{
		public GetAdCopy()
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
			string strLockID = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSProgram p = ComponentFactory.CreateProgramClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetAdCopy(strSessionID, 12345, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutAdCopy.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("AdCopyDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/AdCopyDataSet.xsd";

			XmlNode oAdCopyNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtAdCopy = new DataTable("ADCOPY");
			XmlNodeList oAdCopyNodes = oAdCopyNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtAdCopy, oAdCopyNodes);
			dtAdCopy.Constraints.Add("PK_ADCOPY", new DataColumn[] {dtAdCopy.Columns["ASS_ID"]}, true);
			oDataSet.Tables.Add(dtAdCopy);

			XmlNode oPBSAdCopyDETAILNode = oAdCopyNode.SelectSingleNode("FIELDS/FIELD[@attrname='ASSETRIGHTWINDOW']");
			DataTable dtPBSAdCopyDETAIL = new DataTable("ASSETRIGHTWINDOW");
			XmlNodeList oPBSIWTDETAILNodes = oPBSAdCopyDETAILNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPBSAdCopyDETAIL, oPBSIWTDETAILNodes);
			dtPBSAdCopyDETAIL.Constraints.Add("PK_ASSETRIGHTWINDOW", new DataColumn[] {dtPBSAdCopyDETAIL.Columns["ARW_ID"]}, true);
			oDataSet.Tables.Add(dtPBSAdCopyDETAIL);

			oDataSet.Relations.Add("FK_ADCOPYASSETRIGHTWINDOW", dtAdCopy.Columns["ASS_ID"], dtPBSAdCopyDETAIL.Columns["ARW_ASS_ID"]);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\AdCopyDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetAdCopy.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetAdCopy.xslt", oDataSet);
			#endregion 

            #region PutAdCopy.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutAdCopy.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetAdCopyClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetAdCopyClass.cs", "AdCopy", "Program");
			#endregion

            #region PutAdCopyClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutAdCopyClass.cs", "AdCopy", "Program");
			#endregion
		}
	}
}
