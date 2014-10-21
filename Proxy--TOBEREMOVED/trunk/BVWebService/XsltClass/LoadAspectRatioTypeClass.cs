using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Globalization;
using Pbs.WebServices.Utility;

using TVSServer = OrionProxy;

namespace BVWebService
{
	/// <summary>
	/// GetDataClass: Implement the LoadAspectRatioType web method using XSLT.
	/// </summary>
	public class LoadAspectRatioTypeClass
	{
		private const string FILE_LOAD_XSLT = @"LoadAspectRatioType.xslt";

		public LoadAspectRatioTypeClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet LoadAspectRatioType()
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering LoadAspectRatioType.\n");
		
		
			TVSServer.rdmPBSGetLookup oPBSGetLookupClass;

			try
			{
				oPBSGetLookupClass = ComponentFactory.CreateGetLookupClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSGetLookup LoadAspectRatioType",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSGetLookupClass.LoadAspectRatioType(out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"",
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving LoadAspectRatioType.\n");
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_LOAD_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "");
			}
		}
	}
}
