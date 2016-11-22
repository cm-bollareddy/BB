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
	public class GetFormatSheet
	{
		public GetFormatSheet()
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
			TVSServer.rdmPBSManageTable p = ComponentFactory.CreateManageTableClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetFormatSheet(strSessionID, -1, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutFormatSheet.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("FormatSheetDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/FormatSheetDataSet.xsd";

			XmlNode oFORMATSHEETNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtFORMATSHEET = new DataTable("FORMATSHEET");
			XmlNodeList oFORMATSHEETNodes = oFORMATSHEETNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtFORMATSHEET, oFORMATSHEETNodes);
			dtFORMATSHEET.Constraints.Add("PK_FORMATSHEET", new DataColumn[] {dtFORMATSHEET.Columns["PFS_ID"]}, true);
			oDataSet.Tables.Add(dtFORMATSHEET);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\FormatSheetDataSet.xsd");

			#endregion ORION Schema Generation

			#region GetFormatSheet.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetFormatSheet.xslt", oDataSet);
			#endregion 

            #region PutFormatSheet.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutFormatSheet.xslt", XmlDocument, oDataSet);
			#endregion

            //No DeleteFormatSheet xslt

            #region GetFormatSheetClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetFormatSheetClass.cs", "FormatSheet", "ManageTable");
			#endregion

            #region PutFormatSheetClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutFormatSheetClass.cs", "FormatSheet", "ManageTable");
			#endregion

            #region DeleteFormatSheetClass.cs Generation
            GenDeleteClassHelper.GenClass(strTargetDir + @"\..\Templates\DeleteClassTemplate.cs.txt", strTargetDir + @"\xsltClass\DeleteFormatSheetClass.cs", "FormatSheet", "ManageTable");
            #endregion

		}
	}
}
