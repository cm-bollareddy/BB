using System;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using BVWebService;
using TVSServer = OrionProxy;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for SearchDeal
	/// </summary>
	public class TalentSearch
	{
		public TalentSearch()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void GenSchema(string strTargetDir)
		{
			#region BroadView Schema Generation
			string strSessionID = "";

			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSTalent p = ComponentFactory.CreateTalentClass();

			string strName =string.Empty;
			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.TalentSearch(strSessionID, strName, out XmlString, out strErrorText);

			if (nErrorCode != 0)
			{
				MessageBox.Show(strErrorText);
				return;
			}

			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\TalentSearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("TalentDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/TalentSearchDataSet.xsd";

			XmlNode oTALENTSEARCHNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtTALENTSEARCH = new DataTable("TALENTSEARCH");
			XmlNodeList oTALENTSEARCHNodes = oTALENTSEARCHNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtTALENTSEARCH, oTALENTSEARCHNodes);
			dtTALENTSEARCH.Constraints.Add("PK_TALENTSEARCH", new DataColumn[] {dtTALENTSEARCH.Columns["TAL_ID"]}, true);
			oDataSet.Tables.Add(dtTALENTSEARCH);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\TalentSearchDataSet.xsd");

			#endregion ORION Schema Generation

            #region TalentSearch.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\TalentSearch.xslt", oDataSet);
			#endregion

            #region TalentSearchClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\TalentSearchTemplate.cs.txt", strTargetDir + @"\xsltClass\TalentSearchClass.cs", "Talent", "Talent");
			#endregion
		}
	}
}
