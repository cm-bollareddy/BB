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
	public class GetDealAll
	{
		public GetDealAll()
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
			TVSServer.rdmPBSDeal p = ComponentFactory.CreateDealClass();

			// Invoke the object to get the XML result string
			try
			{
				nErrorCode = p.GetDealAll(strSessionID,8504190, false, out strLockID, out XmlString, out strErrorText);
			}
			catch(Exception _ex)
			{
				throw _ex;
			}


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutDealAll.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("DealAllDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/DealAllDataSet.xsd";

			XmlNode oDEALNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtDEAL = new DataTable("DEAL");
			XmlNodeList oDEALNodes = oDEALNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDEAL, oDEALNodes);
			dtDEAL.Constraints.Add("PK_DEAL", new DataColumn[] {dtDEAL.Columns["DEA_ID"]}, true);
			oDataSet.Tables.Add(dtDEAL);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\DealAllDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetDealAll.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetDealAll.xslt", oDataSet);
			#endregion 

            //No PutDealAll.xslt

            #region GetClassTemplate.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetDealAllClass.cs", "DealAll", "Deal");
			#endregion

            //No SetDealClass.cs 
            
		}
	}
}
