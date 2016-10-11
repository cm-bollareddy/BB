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
	public class LoadCompany
	{
		public LoadCompany()
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
			nErrorCode = p.LoadCompany(out XmlString, out strErrorText);


			//
			// End our session
			//
			s.Logout(strSessionID);


			//  Load this into an XML document
			XmlDocument XmlDocument = new XmlDocument();
			XmlDocument.LoadXml(XmlString);

			// Create an XmlTextWriter and save it out
			XmlTextWriter XmlWriter = new XmlTextWriter(strTargetDir + @"\BVSchema\LoadCompany.xml", System.Text.Encoding.UTF8);
			XmlDocument.WriteTo(XmlWriter);
			XmlWriter.Flush();
			XmlWriter.Close();
			#endregion BroadView Schema Generation

			#region ORION Schema Generation
			//
			// Generate the ORION Schema
			//
			
			DataSet oDataSet = new DataSet("CompanyDataSet");
			oDataSet.Namespace = "http://localhost/BVWebService/xsd/LoadCompanyDataSet.xsd";

			XmlNode oCOMPANYNode = XmlDocument.SelectSingleNode("/DATAPACKET/METADATA");
			DataTable dtCOMPANY = new DataTable("COMPANY");
			XmlNodeList oCOMPANYNodes = oCOMPANYNode.SelectNodes("FIELDS/FIELD");
			GenSchemaHelper.LoadColumns(dtCOMPANY, oCOMPANYNodes);
			dtCOMPANY.Constraints.Add("PK_COMPANY", new DataColumn[] {dtCOMPANY.Columns["COM_ID"]}, true);
			oDataSet.Tables.Add(dtCOMPANY);

			oDataSet.WriteXmlSchema(strTargetDir + @"\xsd\LoadCompanyDataSet.xsd");

			#endregion ORION Schema Generation

            #region LoadCompany.xslt Generation
            GenGetXsltHelper.GenXslTransform(strTargetDir + @"\xslt\LoadCompany.xslt", oDataSet);
			#endregion 

            #region LoadCompanyClass.cs Generation
            GenLoadClassHelper.GenClass(strTargetDir + @"\..\Templates\LoadClassTemplate.cs.txt", strTargetDir + @"\xsltClass\LoadCompanyClass.cs", "Company", "GetLookup");
			#endregion
		}
	}
}
