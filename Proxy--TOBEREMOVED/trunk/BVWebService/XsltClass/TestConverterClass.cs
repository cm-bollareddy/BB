using System;
using System.Data;
using Pbs.WebServices.Utility;

namespace BVWebService
{
	/// <summary>
	/// GetDataClass: Implement the GetData web method using XSLT.
	/// </summary>
	class TestConverterClass
	{
		public TestConverterClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ToXml(DataSet dsDeal, string strXsltFile)
		{
			//
			// Convert incoming DataSet into XML stream using given XSLT file
			//
			return SchemaConverter.ToXml(dsDeal, BVWebService.ApplicationPath + @"\xslt\" + strXsltFile);
		}

		public DataSet ToDataSet(string xmlString, string strXsltFile)
		{
			//
			// Convert incoming string into DataSet using given XSLT file
			//
			return SchemaConverter.ToDataSet(xmlString, BVWebService.ApplicationPath + @"\xslt\" + strXsltFile);
		}
	}
}
