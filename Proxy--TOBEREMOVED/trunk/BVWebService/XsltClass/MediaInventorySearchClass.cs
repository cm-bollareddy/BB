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
	/// MediaInventorySearchClass: Implement the MediaInventorySearch web method.
	/// </summary>
	class MediaInventorySearchClass
	{
		private const string FILE_SEARCH_XSLT = @"MediaInventorySearch.xslt";

		public MediaInventorySearchClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet MediaInventorySearch(string strSessionID, SearchCriterion[] searchCriteria, int nMaxRows)
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
			oTracer.LogInfo("Entering MediaInventorySearch.\n searchParams=" + searchParams);

			//
			// Validate that at least one of the input parameter(s) is defined
			//
			if (n == 0)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidParameters,
					"No search field is found.  Search field(s) supported are program_id,deal_id,operating_unit,operating_group,title.",
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
						case "program_id":
							oSearchParams[i] = (object) new object[2];
							((object[]) oSearchParams[i])[0] = s.SearchField;
							((object[]) oSearchParams[i])[1] = s.SearchValue;
							i++;
							break;
						case "deal_id":
							oSearchParams[i] = (object) new object[2];
							((object[]) oSearchParams[i])[0] = s.SearchField;
							((object[]) oSearchParams[i])[1] = s.SearchValue;
							i++;
							break;
						case "operating_unit":
							oSearchParams[i] = (object) new object[2];
							((object[]) oSearchParams[i])[0] = s.SearchField;
							((object[]) oSearchParams[i])[1] = s.SearchValue;
							i++;
							break;
						case "operating_group":
							oSearchParams[i] = (object) new object[2];
							((object[]) oSearchParams[i])[0] = s.SearchField;
							((object[]) oSearchParams[i])[1] = s.SearchValue;
							i++;
							break;
						case "title":
							oSearchParams[i] = (object) new object[2];
							((object[]) oSearchParams[i])[0] = s.SearchField;
							((object[]) oSearchParams[i])[1] = s.SearchValue;
							i++;
							break;
						


						default:
						{
							throw new ServiceException(
								ServiceException.ExceptionCode.InvalidParameters,
								"Invalid search field: " + s.SearchField + ". Search field(s) supported are program_id,deal_id,operating_unit,operating_group,title.",
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
					"Component= TVSServer.rdmPBSSearch MediaInventorySearch \nCriteria(" + searchParams + ")",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strSearchResult = "";
			try
			{
				nErrorCode = oPBSSearch.MediaInventorySearch(strSessionID, oSearchParams, nMaxRows, out strSearchResult, out strErrorText);
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
				return SchemaConverter.ToDataSet(strSearchResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_SEARCH_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID + ", Criteria(" + searchParams + ")");
			}
		}
	}
}
