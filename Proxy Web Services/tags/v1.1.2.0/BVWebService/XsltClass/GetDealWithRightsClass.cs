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
	/// GetDealWithRightsClass: Implement the GetDealWithRights web method using XSLT.
	/// </summary>
	class GetDealWithRightsClass
	{
		private const string FILE_GET_XSLT = @"GetDealWithRights.xslt";

		public GetDealWithRightsClass()
		{
		}

		public DataSet GetDealWithRights(string strSessionID, int nDealWithRightsID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetDealWithRights.\n strSessionID=" + strSessionID + ", nDealWithRightsID="  + nDealWithRightsID);
		
			TVSServer.rdmPBSDeal oPBSDealWithRights;

			try
			{
				oPBSDealWithRights = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeal GetDealWithRights",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSDealWithRights.GetDealWithRights(strSessionID, nDealWithRightsID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DealWithRightsID= " + nDealWithRightsID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetDealWithRights.\n strSessionID=" + strSessionID + ", nDealWithRightsID="  + nDealWithRightsID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "DealWithRightsID= " + nDealWithRightsID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
