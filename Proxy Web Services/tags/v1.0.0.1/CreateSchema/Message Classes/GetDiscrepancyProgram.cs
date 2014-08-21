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
	public class GetDiscrepancyProgram
	{
		public GetDiscrepancyProgram()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			//string strSessionID = "";
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			//string strLockID = "";


			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSRemedy p = ComponentFactory.CreateRemedyClass();

			// Invoke the object to get the XML result string
            nErrorCode = p.GetDiscrepancyProgram("HD01", "2012-12-01 00:00:01", out XmlString, out strErrorText);

			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\GetDiscrepancyProgram.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DiscrepancyProgramDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/DiscrepancyProgramDataSet.xsd";

			XmlNode oPACKAGEDETAILNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtPACKAGEDETAIL = new DataTable("PACKAGEDETAIL");
			XmlNodeList oPACKAGEDETAILNodes = oPACKAGEDETAILNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPACKAGEDETAIL, oPACKAGEDETAILNodes);
			//dtPACKAGEDETAIL.Constraints.Add("PK_PACKAGEDETAIL", new DataColumn[] {dtPACKAGEDETAIL.Columns["DISCREPANCY_START"], dtPACKAGEDETAIL.Columns["CHA_CODE"]}, true);
			oDataSet.Tables.Add(dtPACKAGEDETAIL);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DiscrepancyProgramDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetDiscrepancyProgram.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetDiscrepancyProgram.xslt", oDataSet);
			#endregion

            //No PutDiscrepancyProgram.xslt 

            #region GetDiscrepancyProgramClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetDiscrepancyProgramClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetDiscrepancyProgramClass.cs", "DiscrepancyProgram", "Remedy");
			#endregion
            
            //No PutDiscrepancyProgramClass.cs 
		}
	}
}
