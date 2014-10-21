using System;
using System.Data;
using System.Xml;
using SAWebService;
using TVSServer = OrionProxy;
using Pbs.WebServices.Utility;


namespace SAWebService
{
	/// <summary>
	/// DetailedAirDateClass: Implement the DetailedAirDate web method.
	/// </summary>
	class DetailedAirDateClass
	{
		private const string FILE_SEARCH_XSLT = @"DetailedAirDate.xslt";

		public DetailedAirDateClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public DataSet GetDetailedAirDate(string strSessionID, int nMediaInventoryId)
		{

			//
			// Validate that at least one of the input parameter(s) is defined
			//
			if (nMediaInventoryId == int.MinValue || nMediaInventoryId == -1)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidParameters,
					"Media Inventory Id is required.  Value provided = " + nMediaInventoryId.ToString() + " ",
					"",
					ServiceException.ExceptionActor.Client);
			}

			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering DetailedAirDate.\n nMediaInventoryId=" + nMediaInventoryId.ToString());


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
					"Component= TVSServer.rdmPBSSearch DetailedAirDate ",
					ex);
			}

			int nErrorCode = 0;
			string sXmlData = "";
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSSearch.DetailedAirDate(strSessionID, nMediaInventoryId, out sXmlData, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"SessionID= " + strSessionID + ", MediaInventoryId(" + nMediaInventoryId.ToString()+ ")",
					ex);
			}

			if (nErrorCode == 0)
			{
				return SchemaConverter.ToDataSet(sXmlData, SAWebService.ApplicationPath + @"\xslt\" + FILE_SEARCH_XSLT );
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID + ", MediaInventoryId (" + nMediaInventoryId.ToString() + ")");
			}
		}
	}
}
