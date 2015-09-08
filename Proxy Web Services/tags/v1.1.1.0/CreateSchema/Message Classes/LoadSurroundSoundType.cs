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
	public class LoadSurroundSoundType
	{
		public LoadSurroundSoundType()
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
			nErrorCode = p.LoadSurroundSoundType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadSurroundSoundType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("SurroundSoundTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/LoadSurroundSoundTypeDataSet.xsd";

			XmlNode oSURROUNDSOUNDNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtSURROUNDSOUND = new DataTable("SURROUNDSOUND");
			XmlNodeList oSURROUNDSOUNDNodes = oSURROUNDSOUNDNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtSURROUNDSOUND, oSURROUNDSOUNDNodes);
			dtSURROUNDSOUND.Constraints.Add("PK_SURROUNDSOUND", new DataColumn[] {dtSURROUNDSOUND.Columns["SLU_ID"]}, true);
			oDataSet.Tables.Add(dtSURROUNDSOUND);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadSurroundSoundTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadSurroundSoundType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadSurroundSoundType.xslt", oDataSet);
			#endregion 

            #region LoadSurroundSoundTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadSurroundSoundTypeClass.cs", "SurroundSoundType", "GetLookup");
			#endregion
		}
	}
}
