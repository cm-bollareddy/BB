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
	/// GetDealWithTechnicalClass: Implement the GetDealWithTechnical web method using XSLT.
	/// </summary>
	class GetDealWithTechnicalClass
	{
		private const string FILE_GET_XSLT = @"GetDealWithTechnical.xslt";

		public GetDealWithTechnicalClass()
		{
		}

		public DataSet GetDealWithTechnical(string strSessionID, int nDealWithTechnicalID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetDealWithTechnical.\n strSessionID=" + strSessionID + ", nDealWithTechnicalID="  + nDealWithTechnicalID);
		
			TVSServer.rdmPBSDeal oPBSDealWithTechnical;

			try
			{
				oPBSDealWithTechnical = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeal GetDealWithTechnical",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSDealWithTechnical.GetDealWithTechnical(strSessionID, nDealWithTechnicalID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DealWithTechnicalID= " + nDealWithTechnicalID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetDealWithTechnical.\n strSessionID=" + strSessionID + ", nDealWithTechnicalID="  + nDealWithTechnicalID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "DealWithTechnicalID= " + nDealWithTechnicalID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
