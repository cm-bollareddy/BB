﻿using System;
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
	public class LoadAspectRatioType
	{
		public LoadAspectRatioType()
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
			nErrorCode = p.LoadAspectRatioType(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadAspectRatioType.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("AspectRatioTypeDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadAspectRatioTypeDataSet.xsd";

			XmlNode oASPECTRATIOTYPENode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtASPECTRATIOTYPE = new DataTable("ASPECTRATIOTYPE");
			XmlNodeList oASPECTRATIOTYPENodes = oASPECTRATIOTYPENode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtASPECTRATIOTYPE, oASPECTRATIOTYPENodes);
			dtASPECTRATIOTYPE.Constraints.Add("PK_ASPECTRATIOTYPE", new DataColumn[] {dtASPECTRATIOTYPE.Columns["SLU_ID"]}, true);
			oDataSet.Tables.Add(dtASPECTRATIOTYPE);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadAspectRatioTypeDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadAspectRatioType.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadAspectRatioType.xslt", oDataSet);
			#endregion 

            #region LoadAspectRatioTypeClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadAspectRatioTypeClass.cs", "AspectRatioType", "GetLookup");
			#endregion
		}
	}
}
