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
	/// Summary description for GetPackage.
	/// </summary>
	public class GetPackage
	{
		public GetPackage()
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
			nErrorCode = p.GetPackage(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutPackage.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("PackageDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/PackageDataSet.xsd";

			XmlNode oPACKAGENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtPACKAGE = new DataTable("PACKAGE");
			XmlNodeList oPACKAGENodes = oPACKAGENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtPACKAGE, oPACKAGENodes);
			dtPACKAGE.Constraints.Add("PK_PACKAGE", new DataColumn[] {dtPACKAGE.Columns["VER_ID"]}, true);
			oDataSet.Tables.Add(dtPACKAGE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\PackageDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetPackage.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetPackage.xslt", oDataSet);
			#endregion 

			//No PutDeal.xslt 

            #region GetPackageClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetPackageClass.cs", "Package", "Program");
			#endregion

			//No SetDealClass.cs 
		}
	}
}
