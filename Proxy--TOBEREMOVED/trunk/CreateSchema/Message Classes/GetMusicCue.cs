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
	public class GetMusicCue
	{
		public GetMusicCue()
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
			TVSServer.rdmPBSManageTable p = ComponentFactory.CreateManageTableClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetMusicCue(strSessionID, 6197186, false, out strLockID, out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\PutMusicCue.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("MusicCueDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/MusicCueDataSet.xsd";

			XmlNode oMUSICCUENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtMUSICCUE = new DataTable("MUSICCUE");
			XmlNodeList oMUSICCUENodes = oMUSICCUENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtMUSICCUE, oMUSICCUENodes);
			dtMUSICCUE.Constraints.Add("PK_MUSICCUE", new DataColumn[] {dtMUSICCUE.Columns["PMC_ID"]}, true);
			oDataSet.Tables.Add(dtMUSICCUE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\MusicCueDataSet.xsd");

			#endregion ORION Schema Generation

            #region GetMusicCue.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\GetMusicCue.xslt", oDataSet);
			#endregion 

            #region PutMusicCue.xslt Generation
            GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\PutMusicCue.xslt", XmlDocument, oDataSet);
			#endregion

            //No DeleteMusicCue xslt

            #region GetMusicCueClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetMusicCueClass.cs", "MusicCue", "ManageTable");
			#endregion

            #region PutMusicCueClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutMusicCueClass.cs", "MusicCue", "ManageTable");
			#endregion

            #region DeleteMusicCueClass.cs Generation
            GenDeleteClassHelper.GenClass(strTargetDir + @"\..\Templates\DeleteClassTemplate.cs.txt", strTargetDir + @"\xsltClass\DeleteMusicCueClass.cs", "MusicCue", "ManageTable");
            #endregion


		}
	}
}
