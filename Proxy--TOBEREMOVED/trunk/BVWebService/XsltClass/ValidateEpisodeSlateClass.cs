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
	/// ValidateEpisodeSlateClass: Implement the ValidateEpisodeSlate web method.
	/// </summary>
	class ValidateEpisodeSlateClass
	{
		private const string FILE_SEARCH_XSLT = @"ValidateEpisodeSlate.xslt";

		public ValidateEpisodeSlateClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public DataSet ValidateEpisodeSlate(string strSessionID, string p_sNolaRoot, int p_iStartingEpisodeNumber, int p_iNumberOfPrograms)
		{

			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering ValidateEpisodeSlate.\n" + "Nola Root:[" + p_sNolaRoot + "] Starting Episode Number:[" + p_iStartingEpisodeNumber.ToString() + "] Number of Programs:[" + p_iNumberOfPrograms +"]");

			//
			// Validate that at least one of the input parameter(s) is defined
			//
			if (p_sNolaRoot == null || p_sNolaRoot == string.Empty)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidParameters,
					"Nola Root is null or empty string.",
					"",
					ServiceException.ExceptionActor.Client);
			}

			//
			// Go ahead and search based upon given parameters
			//
			TVSServer.rdmPBSSearch oPBSSearch;

			try
			{
				oPBSSearch = ComponentFactory.CreateSearchClass();
				
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSSearch ValidateEpisodeSlate \nCriteria(Nola Root:[" + p_sNolaRoot + "] Starting Episode Number:[" + p_iStartingEpisodeNumber.ToString() + "] Number of Programs:[" + p_iNumberOfPrograms +"])",
					ex);
			}

			int nErrorCode		= 0;
			string strErrorText = "";
			string sXMLData 	= "";
			try
			{
				nErrorCode = oPBSSearch.ValidateEpisodeSlate(strSessionID, p_sNolaRoot, p_iStartingEpisodeNumber, p_iNumberOfPrograms, out sXMLData, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"SessionID= " + strSessionID ,
					ex);
			}

			if (nErrorCode == 0)
			{
				return SchemaConverter.ToDataSet(sXMLData, BVWebService.ApplicationPath + @"\xslt\" + FILE_SEARCH_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID + ", " + "Nola Root:[" + p_sNolaRoot + "] Starting Episode Number:[" + p_iStartingEpisodeNumber.ToString() + "] Number of Programs:[" + p_iNumberOfPrograms +"]");
			}
		}

	}
}
