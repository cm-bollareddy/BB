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
	public class GetTalent
	{
		public GetTalent()
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
			int nDealID = 0;
			int nTalentID =0;
			int nRoleID = 0;
			string strErrorText = "";
			//string XmlString = "";
			//string strLockID = "";
			string strDataEpisodeAppliesTo =string.Empty;
			string strDataEpisodeTalent =string.Empty;
			string strDataTalent =string.Empty;


			//
			// Start a BroadView session
			//
			BVSession s = new BVSession();
			strSessionID = s.Login();

			//
			// Generate the BroadView Schema
			//
			TVSServer.rdmPBSTalent p = ComponentFactory.CreateTalentClass();

			// Invoke the object to get the XML result string
			nErrorCode = p.GetTalent(strSessionID, nDealID,nTalentID,nRoleID,out strDataEpisodeAppliesTo, out strDataEpisodeTalent,out strDataTalent, out strErrorText);

			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load all into differnent  XML documents
			createxmlDocs(strDataEpisodeAppliesTo,"DataEpisodeAppilesTo",strTargetDir);
			createxmlDocs(strDataEpisodeTalent,"DataEpisodeTalent",strTargetDir);
			createxmlDocs(strDataTalent,"DataTalent",strTargetDir);
			
							
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			// DataTalent
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(strDataTalent);
			DataSet oDataSetDataTalent = new DataSet("TalentDataSet");
			oDataSetDataTalent.Namespace = "http://localhost/BVWebService/xsd/TalentDataSet.xsd";

			XmlNode oTALENTNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtTALENT = new DataTable("TALENT");
			XmlNodeList oTALENTNodes = oTALENTNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtTALENT, oTALENTNodes);
			dtTALENT.Constraints.Add("PK_TALENT", new DataColumn[] {dtTALENT.Columns["TAL_ID"]}, true);
			oDataSetDataTalent.Tables.Add(dtTALENT);

			oDataSetDataTalent.WriteXmlSchema(strTargetDir + @"\xsd\TalentDataSet.xsd");
			XmlDocument =null;
			
			//DataEpisodeTalent
			XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(strDataEpisodeTalent);
			DataSet oDataSetDataEpisodeTalent = new DataSet("EpisodeTalentDataSet");
			oDataSetDataEpisodeTalent.Namespace = "http://localhost/BVWebService/xsd/EpisodeTalentDataSet.xsd";
			XmlNode oEPISODETALENTNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtEPISODETALENT = new DataTable("EPISODETALENT");
			XmlNodeList oEPISODETALENTNodes = oEPISODETALENTNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtEPISODETALENT, oEPISODETALENTNodes);
			dtEPISODETALENT.Constraints.Add("PK_EPISODETALENT", new DataColumn[] {dtEPISODETALENT.Columns["ASS_ID"]}, true);
			oDataSetDataEpisodeTalent.Tables.Add(dtEPISODETALENT);
			oDataSetDataEpisodeTalent.WriteXmlSchema(strTargetDir + @"\xsd\EpisodeTalentDataSet.xsd");
			XmlDocument =null;
			
			//DataEpisodeAppTo
			
			XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(strDataEpisodeAppliesTo);
			DataSet oDataSetDataEpisodeAppilesTo = new DataSet("EpisodeAppliesTo");
			oDataSetDataEpisodeAppilesTo.Namespace = "http://localhost/BVWebService/xsd/EpisodeAppliesToDataSet.xsd";

			XmlNode oEPISODEAPPTONode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtEPISODEAPPTO = new DataTable("EPISODEAPPTO");
			XmlNodeList oEPISODEAPPTONodes = oEPISODEAPPTONode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtEPISODEAPPTO, oEPISODEAPPTONodes);
			dtEPISODEAPPTO.Constraints.Add("PK_EPISODEAPPTO", new DataColumn[] {dtEPISODEAPPTO.Columns["ASS_ID"]}, true);
			oDataSetDataEpisodeAppilesTo.Tables.Add(dtEPISODEAPPTO);

			oDataSetDataEpisodeAppilesTo.WriteXmlSchema(strTargetDir + @"\xsd\EpisodeAppliesToDataSet.xsd");
			XmlDocument =null;
			
			#endregion ORION Schema Generation

			
			#region allxslt
			createxsltDocs(strDataEpisodeAppliesTo,"DataEpisodeAppliesTo",oDataSetDataEpisodeAppilesTo,strTargetDir);
			createxsltDocs(strDataEpisodeTalent,"DataEpisodeTalent",oDataSetDataEpisodeTalent,strTargetDir);
			createxsltDocs(strDataTalent,"DataTalent",oDataSetDataTalent,strTargetDir);
			#endregion

            #region GetTalentClass.cs Generation
            GenGetClassHelper.GenClass(strTargetDir + @"\..\Templates\GetTalentClassTemplate.cs.txt", strTargetDir + @"\xsltClass\GetTalentClass.cs", "Talent", "Talent");
			#endregion

            #region PutTalentClass.cs Generation
            GenSetClassHelper.GenClass(strTargetDir + @"\..\Templates\SetTalentClassTemplate.cs.txt", strTargetDir + @"\xsltClass\PutTalentClass.cs", "Talent" , "Talent");
			#endregion



		}
		
		private void createxmlDocs(string sXML, string sOutPutType,string strTargetDir )
		{
		
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(sXML);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\"+sOutPutType +".xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
		
		
		}
		private void createxsltDocs(string sXML,string sOutPutType, DataSet oDataSet, string strTargetDir )
		{
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(sXML);
			#region 
			GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\Get" +sOutPutType + ".xslt", oDataSet);
			#endregion 

			#region
			GenPutXsltHelper.GenXslTransform(strTargetDir + @"\xslt\Put"+sOutPutType+".xslt", XmlDocument, oDataSet);
			#endregion
		
		
		}
	}
}
