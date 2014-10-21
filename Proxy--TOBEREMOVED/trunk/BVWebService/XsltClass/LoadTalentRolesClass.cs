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
	/// GetDataClass: Implement the LoadTalentRoles web method using XSLT.
	/// </summary>
	public class LoadTalentRolesClass
	{
		private const string FILE_LOAD_XSLT = @"LoadTalentRoles.xslt";

		public LoadTalentRolesClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet LoadTalentRoles()
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering LoadTalentRoles.\n");
		
		
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
					"Component= TVSServer.rdmPBSGetLookup LoadTalentRoles",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSGetLookupClass.LoadTalentRoles(out strResult, out strErrorText);
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
				oTracer.LogInfo("Leaving LoadTalentRoles.\n");
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_LOAD_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "");
			}
		}
	}
}
