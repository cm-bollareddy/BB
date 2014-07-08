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
	public class ProgramSearch
	{
		public ProgramSearch()
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
			TVSServer.rdmPBSSearch p = ComponentFactory.CreateSearchClass();

			// Create a search criteria object
			object[] objSearchParams = new object[4];
			objSearchParams[0] = new object[2];
			((object[]) objSearchParams[0])[0] = "program_title";
			((object[]) objSearchParams[0])[1] = "%";
			objSearchParams[1] = new object[2];
			((object[]) objSearchParams[1])[0] = "episode_title";
			((object[]) objSearchParams[1])[1] = "%";
			objSearchParams[2] = new object[2];
			((object[]) objSearchParams[2])[0] = "program_season";
			((object[]) objSearchParams[2])[1] = "%";
			objSearchParams[3] = new object[2];
			((object[]) objSearchParams[3])[0] = "episode_nola";
			((object[]) objSearchParams[3])[1] = "%";

			// Invoke the object to get the XML result string
			int nErrorCode = 0;
			string strErrorText = "";
			string XmlString = "";
			nErrorCode = p.ProgramSearch(strSessionID, (object) objSearchParams, 10, out XmlString, out strErrorText);

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
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ProgramSearch.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			DataTable dtDeal = new DataTable("ProgramSearch");

			// Create the columns for Deal
			XmlNodeList oNodeList = XmlDocument.SelectNodes("/DATAPACKET/METADATA/FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtDeal, oNodeList);
			dtDeal.Constraints.Add("PK_PROGRAMSEARCH", dtDeal.Columns["ASS_ID"], true);
			//dtDeal.PrimaryKey = new DataColumn[] { dtDeal.Columns["DEA_ID"] };

			// Create the DataSet
			DataSet oDataSet = new DataSet("ProgramSearchDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ProgramSearchDataSet.xsd";
			oDataSet.Tables.Add(dtDeal);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ProgramSearchDataSet.xsd");
			#endregion ORION Schema Generation

			#region ProgramSearch.xslt Generation
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ProgramSearch.xslt", oDataSet);
			#endregion

            #region ProgramSearchClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ProgramSearchClassTemplate.cs.txt", strTargetDir + @"\xsltClass\ProgramSearchClass.cs", "Program", "Search");
            #endregion

		}
	}
}
