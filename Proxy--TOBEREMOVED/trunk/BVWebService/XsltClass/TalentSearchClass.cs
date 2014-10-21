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
	/// TalentSearchClass: Implement the TalentSearch web method.
	/// </summary>
	class TalentSearchClass
	{
		private const string FILE_SEARCH_XSLT = @"TalentSearch.xslt";

		public TalentSearchClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet TalentSearch(string strSessionID, string strTalentName)
		{
			//
			// Construct the search input parameter for troubleshooting...
			//
			

			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering TalentSearch.\n searchParams=" + strTalentName);

			if ( strTalentName ==string.Empty)
			{
				throw new ServiceException(
				ServiceException.ExceptionCode.InvalidParameters,
				"Invalid Search Parameter " +strTalentName ,strTalentName ,
				ServiceException.ExceptionActor.Client);
			}
			

			//
			// Go ahead and search based upon given parameters
			//
			TVSServer.rdmPBSTalent oPBSTalent;

			try
			{
				oPBSTalent = ComponentFactory.CreateTalentClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSTalent TalentSearch \nCriteria(" + strTalentName + ")",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = string.Empty;
			try
			{
				nErrorCode = oPBSTalent.TalentSearch(strSessionID, strTalentName, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"SessionID= " + strSessionID + ", Criteria(" + strTalentName + ")",
					ex);
			}

			if (nErrorCode == 0)
			{
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_SEARCH_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID + ", Criteria(" + strTalentName + ")");
			}
		}
	}
}
