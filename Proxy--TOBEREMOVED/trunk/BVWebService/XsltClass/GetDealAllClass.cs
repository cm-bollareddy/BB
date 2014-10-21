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
	/// GetDealAllClass: Implement the GetDealAll web method using XSLT.
	/// </summary>
	class GetDealAllClass
	{
		private const string FILE_GET_XSLT = @"GetDealAll.xslt";

		public GetDealAllClass()
		{
		}

		public DataSet GetDealAll(string strSessionID, int nDealAllID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetDealAll.\n strSessionID=" + strSessionID + ", nDealAllID="  + nDealAllID);
		
			TVSServer.rdmPBSDeal oPBSDealAll;

			try
			{
				oPBSDealAll = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeal GetDealAll",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSDealAll.GetDealAll(strSessionID, nDealAllID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DealAllID= " + nDealAllID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetDealAll.\n strSessionID=" + strSessionID + ", nDealAllID="  + nDealAllID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "DealAllID= " + nDealAllID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
