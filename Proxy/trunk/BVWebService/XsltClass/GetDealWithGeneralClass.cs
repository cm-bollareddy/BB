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
	/// GetDealWithGeneralClass: Implement the GetDealWithGeneral web method using XSLT.
	/// </summary>
	class GetDealWithGeneralClass
	{
		private const string FILE_GET_XSLT = @"GetDealWithGeneral.xslt";

		public GetDealWithGeneralClass()
		{
		}

		public DataSet GetDealWithGeneral(string strSessionID, int nDealWithGeneralID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetDealWithGeneral.\n strSessionID=" + strSessionID + ", nDealWithGeneralID="  + nDealWithGeneralID);
		
			TVSServer.rdmPBSDeal oPBSDealWithGeneral;

			try
			{
				oPBSDealWithGeneral = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeal GetDealWithGeneral",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSDealWithGeneral.GetDealWithGeneral(strSessionID, nDealWithGeneralID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DealWithGeneralID= " + nDealWithGeneralID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetDealWithGeneral.\n strSessionID=" + strSessionID + ", nDealWithGeneralID="  + nDealWithGeneralID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "DealWithGeneralID= " + nDealWithGeneralID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
