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
	/// GetDealClass: Implement the GetDeal web method using XSLT.
	/// </summary>
	class GetDealClass
	{
		private const string FILE_GET_XSLT = @"GetDeal.xslt";

		public GetDealClass()
		{
		}

		public DataSet GetDeal(string strSessionID, int nDealID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetDeal.\n strSessionID=" + strSessionID + ", nDealID="  + nDealID);
		
			TVSServer.rdmPBSDeal oPBSDeal;

			try
			{
				oPBSDeal = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeal GetDeal",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSDeal.GetDeal(strSessionID, nDealID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DealID= " + nDealID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetDeal.\n strSessionID=" + strSessionID + ", nDealID="  + nDealID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "DealID= " + nDealID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
