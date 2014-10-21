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

namespace SAWebService
{
	/// <summary>
	/// ListPackageCutsInfoClass: Implement the ListPackageCutsInfo web method.
	/// </summary>
	class ListPackageCutsInfoClass
	{
		private const string FILE_SEARCH_XSLT = @"ListPackageCutsInfo.xslt";

		public ListPackageCutsInfoClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public DataSet ListPackageCutsInfo(string strSessionID, SearchCriterion[] searchCriteria, int nMaxRows)
		{
			//
			// Construct the search input parameter for troubleshooting...
			//
			int n = 0;
			string searchParams = "";
			foreach (SearchCriterion s in searchCriteria)
			{
				if ((s != null) && (s.SearchField != null) && (s.SearchField != "") && (s.SearchValue != null) && (s.SearchValue != ""))
				{
					if (searchParams != "")
						searchParams += ",";
					searchParams += s.SearchField + "=\"" + s.SearchValue + "\"";
					n++;
				}
			}

			Tracer oTracer = new Tracer();
            oTracer.LogInfo("Entering ListPackageCutsInfo.\n" + string.Format("SessionId:[{0}]\n SearchCriteria:[{1}]\n MaxRows:[{2}]", strSessionID == null ? "" : strSessionID, searchParams, nMaxRows) + "\n");


			//
			// Validate that at least one of the input parameter(s) is defined
			//
			if (n == 0)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidParameters,
					"No search field is found.  Search field(s) supported are REVISIONHOUSENUMBER",
					"",
					ServiceException.ExceptionActor.Client);
			}

			//
			// Validate the incoming criteria
			//
			object[] oSearchParams = new object[n];
			int i = 0;
			foreach (SearchCriterion s in searchCriteria)
			{
				if ((s != null) && (s.SearchField != null) && (s.SearchField != "") && (s.SearchValue != null) && (s.SearchValue != ""))
				{
					switch (s.SearchField)
					{
						case "REVISIONHOUSENUMBER":
							oSearchParams[i] = (object) new object[2];
							((object[]) oSearchParams[i])[0] = s.SearchField;
							((object[]) oSearchParams[i])[1] = s.SearchValue;
							i++;
							break;
										

						default:
						{
							throw new ServiceException(
								ServiceException.ExceptionCode.InvalidParameters,
								"Invalid search field: " + s.SearchField + ". Search field(s) supported are REVISIONHOUSENUMBER",
								"Criteria(" + searchParams + ")",
								ServiceException.ExceptionActor.Client);
						}
					}
				}
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
					"Component= TVSServer.rdmPBSSearch ListPackageCutsInfo \nCriteria(" + searchParams + ")",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strSearchResult = "";
			try
			{
				nErrorCode = oPBSSearch.ListPackageCutsInfo(strSessionID, oSearchParams, nMaxRows, out strSearchResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"SessionID= " + strSessionID + ", Criteria(" + searchParams + ")",
					ex);
			}

			if (nErrorCode == 0)
			{
				return SchemaConverter.ToDataSet(strSearchResult, SAWebService.ApplicationPath + @"\xslt\" + FILE_SEARCH_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID + ", Criteria(" + searchParams + ")");
			}
		}
	}
}
