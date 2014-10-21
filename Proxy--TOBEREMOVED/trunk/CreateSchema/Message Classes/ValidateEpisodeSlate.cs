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
	public class ValidateEpisodeSlate
	{
		public ValidateEpisodeSlate()
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

			// Invoke the object to get the XML result string
			int nErrorCode		= 0;
			string sErrorText	= string.Empty;
			string sXmlString	= string.Empty;
			string sNolaRoot	= "BAFR";
			int iStartingEpisode	= 101;
			int iNumberOfEpisodes	= 10;

			nErrorCode = p.ValidateEpisodeSlate(strSessionID, sNolaRoot, iStartingEpisode, iNumberOfEpisodes, out sXmlString, out sErrorText);

			if (nErrorCode != 0)
			{
				MessageBox.Show(sErrorText);
				return;
			}
			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(sXmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\ValidateEpisodeSlate.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			
			#endregion BroadView Schema Generation


			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("ValidateEpisodeSlateDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/ValidateEpisodeSlateDataSet.xsd";

			XmlNode oMASTERNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMASTER = new DataTable("MASTER");
			XmlNodeList oMASTERNodes = oMASTERNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMASTER, oMASTERNodes);
			//dtMASTER.Constraints.Add("PK_MASTER", new DataColumn[] {}, true);
			oDataSet.Tables.Add(dtMASTER);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\ValidateEpisodeSlateDataSet.xsd");

			#endregion ORION Schema Generation

            #region ValidateEpisodeSlate Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\ValidateEpisodeSlate.xslt", oDataSet);
			#endregion


            #region ValidateEpisodeSlateClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\ValidateEpisodeSlateTemplate.cs.txt", strTargetDir + @"\xsltClass\ValidateEpisodeSlateClass.cs", "ValidateEpisodeSlate", "Search");
			#endregion
		}
	}
}
