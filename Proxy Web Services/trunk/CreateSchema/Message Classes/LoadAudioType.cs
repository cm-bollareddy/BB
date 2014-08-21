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
	public class LoadAudioType
	{
		public LoadAudioType()
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
			nErrorCode = p.LoadAudioType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadAudioType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("AudioTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/LoadAudioTypeDataSet.xsd";

			XmlNode oAUDIOTYPENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtAUDIOTYPE = new DataTable("AUDIOTYPE");
			XmlNodeList oAUDIOTYPENodes = oAUDIOTYPENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtAUDIOTYPE, oAUDIOTYPENodes);
			dtAUDIOTYPE.Constraints.Add("PK_AUDIOTYPE", new DataColumn[] {dtAUDIOTYPE.Columns["MFC_ID"]}, true);
			oDataSet.Tables.Add(dtAUDIOTYPE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadAudioTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadAudioType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadAudioType.xslt", oDataSet);
			#endregion 

            #region LoadAudioTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadAudioTypeClass.cs", "AudioType", "GetLookup");
			#endregion
		}
	}
}
