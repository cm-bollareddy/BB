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
	public class LoadAssetCategory
	{
		public LoadAssetCategory()
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
			nErrorCode = p.LoadAssetCategory( out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadAssetCategory.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("AssetCategoryDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadAssetCategoryDataSet.xsd";

			XmlNode oASSETCATEGORYNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtASSETCATEGORY = new DataTable("ASSETCATEGORY");
			XmlNodeList oASSETCATEGORYNodes = oASSETCATEGORYNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtASSETCATEGORY, oASSETCATEGORYNodes);
			dtASSETCATEGORY.Constraints.Add("PK_ASSETCATEGORY", new DataColumn[] {dtASSETCATEGORY.Columns["ACA_ID"]}, true);
			oDataSet.Tables.Add(dtASSETCATEGORY);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadAssetCategoryDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadAssetCategory.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadAssetCategory.xslt", oDataSet);
			#endregion 

            #region LoadAssetCategoryClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadAssetCategoryClass.cs", "AssetCategory", "GetLookup");
			#endregion
		}
	}
}
