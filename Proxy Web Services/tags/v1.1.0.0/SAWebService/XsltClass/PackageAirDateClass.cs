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
	/// PackageAirDateClass: Implement the SearchPackageAirDate web method.
	/// </summary>
	class PackageAirDateClass
	{
		public PackageAirDateClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string PackageAirDate(string strSessionID, string sId, int nTuneValue)
		{
			//
			// Construct the search input parameter for troubleshooting...
			

			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PackageAirDateClass.\n" + string.Format("SessionId:[{0}]\n sId:[{1}]\n TuneValue:[{2}]\n", 
																	strSessionID == null?"":strSessionID, sId, nTuneValue) + "\n");

			

			
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
					"Component= TVSServer.rdmPBSSearch SearchPackageAirDate",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strAirDate= string.Empty;
			
			try
			{
				nErrorCode = oPBSSearch.SearchPackageAirDate(strSessionID, sId, nTuneValue, out strAirDate, out strErrorText);
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
				return strAirDate;
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID );
			}
		}
	}
}
