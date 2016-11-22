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
	public class GetVisualArt
	{
		public GetVisualArt()
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
			nErrorCode = p.GetVisualArt(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutVisualArt.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("VisualArtDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/VisualArtDataSet.xsd";

			XmlNode oVISUALARTNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtVISUALART = new DataTable("VISUALART");
			XmlNodeList oVISUALARTNodes = oVISUALARTNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtVISUALART, oVISUALARTNodes);
			dtVISUALART.Constraints.Add("PK_VISUALART", new DataColumn[] {dtVISUALART.Columns["PVA_ID"]}, true);
			oDataSet.Tables.Add(dtVISUALART);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\VisualArtDataSet.xsd");

			#endregion ORION Schema Generation

			#region GetVisualArt.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetVisualArt.xslt", oDataSet);
			#endregion 

			#region PutVisualArt.xslt Generation
			GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutVisualArt.xslt", XmlDocument, oDataSet);
			#endregion

            //No DeleteVisualArt xslt

			#region GetVisualArtClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetVisualArtClass.cs", "VisualArt", "ManageTable");
			#endregion

			#region PutVisualArtClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutVisualArtClass.cs", "VisualArt", "ManageTable");
			#endregion

            #region DeleteVisualArtClass.cs Generation
            GenDeleteClassHelper.GenClass(strTargetDir + @"\..\Templates\DeleteClassTemplate.cs.txt", strTargetDir + @"\xsltClass\DeleteVisualArtClass.cs", "VisualArt", "ManageTable");
            #endregion
		}
	}
}
