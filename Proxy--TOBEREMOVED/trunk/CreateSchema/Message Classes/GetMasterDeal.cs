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
	public class GetMasterDeal
	{
		public GetMasterDeal()
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
			TVSServer.rdmPBSGetMasterDeal p = ComponentFactory.CreateMasterDealClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetMasterDeal(strSessionID, "", out XmlString, out strErrorText);

			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutMasterDeal.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MasterDealDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/MasterDealDataSet.xsd";

			XmlNode oMasterDealNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMasterDeal = new DataTable("MasterDeal");
			XmlNodeList oMasterDealNodes = oMasterDealNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMasterDeal, oMasterDealNodes);
			dtMasterDeal.Constraints.Add("PK_MASTERDEAL", new DataColumn[] {dtMasterDeal.Columns["MDL_ID"]}, true);
			oDataSet.Tables.Add(dtMasterDeal);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\MasterDealDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetMasterDeal.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetMasterDeal.xslt", oDataSet);
			#endregion 

            
            //There is no PutMasterDeal
            #region PutMasterDeal.xslt Generation
            //GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutMasterDeal.xslt", XmlDocument, oDataSet);
			#endregion


            #region GetMasterDealClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetMasterDealClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetMasterDealClass.cs", "MasterDeal", "GetMasterDeal");
			#endregion

            #region PutMasterDealClass.cs Generation
            //GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetMasterDealClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutMasterDealClass.cs", "MasterDeal");
			#endregion
		}
	}
}
