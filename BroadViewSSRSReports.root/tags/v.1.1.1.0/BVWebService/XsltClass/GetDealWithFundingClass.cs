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
	/// GetDealWithFundingClass: Implement the GetDealWithFunding web method using XSLT.
	/// </summary>
	class GetDealWithFundingClass
	{
		private const string FILE_GET_XSLT = @"GetDealWithFunding.xslt";

		public GetDealWithFundingClass()
		{
		}

		public DataSet GetDealWithFunding(string strSessionID, int nDealWithFundingID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetDealWithFunding.\n strSessionID=" + strSessionID + ", nDealWithFundingID="  + nDealWithFundingID);
		
			TVSServer.rdmPBSDeal oPBSDealWithFunding;

			try
			{
				oPBSDealWithFunding = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeal GetDealWithFunding",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSDealWithFunding.GetDealWithFunding(strSessionID, nDealWithFundingID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DealWithFundingID= " + nDealWithFundingID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetDealWithFunding.\n strSessionID=" + strSessionID + ", nDealWithFundingID="  + nDealWithFundingID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "DealWithFundingID= " + nDealWithFundingID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
