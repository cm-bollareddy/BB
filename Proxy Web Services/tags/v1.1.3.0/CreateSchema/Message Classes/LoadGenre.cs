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
	public class LoadGenre
	{
		public LoadGenre()
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

			// Invoke the object to get the XML result string
			//nErrorCode = p.LoadGenre(strSessionID, out XmlString, out strErrorText);
			nErrorCode = p.LoadGenre( out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadGenre.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			DataTable dtGenre = new DataTable("Genre");

			// Create the columns for Funders
			XmlNodeList oNodeList = XmlDocument.SelectNodes("/DATAPACKET/METADATA/FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtGenre, oNodeList);
			dtGenre.Constraints.Add("PK_GENRE", dtGenre.Columns["GNR_ID"], true);
			//dtDeal.PrimaryKey = new DataColumn[] { dtDeal.Columns["DEA_ID"] };

			// Create the DataSet
			DataSet oDataSet = new DataSet("GenreDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadGenreDataSet.xsd";
			oDataSet.Tables.Add(dtGenre);
			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadGenreDataSet.xsd");
			#endregion ORION Schema Generation

            #region LoadGenre.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadGenre.xslt", oDataSet);
			#endregion

            #region LoadGenreClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadGenreClass.cs", "Genre", "GetLookup");
			#endregion
		}
	}
}
