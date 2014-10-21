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
	/// GetIWTClass: Implement the GetIWT web method using XSLT.
	/// </summary>
	class GetIWTClass
	{
		private const string FILE_GET_XSLT = @"GetIWT.xslt";

		public GetIWTClass()
		{
		}

		public DataSet GetIWT(string strSessionID, int nIWTID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetIWT.\n strSessionID=" + strSessionID + ", nIWTID="  + nIWTID);
		
			TVSServer.rdmPBSManageTable oPBSIWT;

			try
			{
				oPBSIWT = ComponentFactory.CreateManageTableClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSManageTable GetIWT",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSIWT.GetIWT(strSessionID, nIWTID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"IWTID= " + nIWTID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetIWT.\n strSessionID=" + strSessionID + ", nIWTID="  + nIWTID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "IWTID= " + nIWTID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
