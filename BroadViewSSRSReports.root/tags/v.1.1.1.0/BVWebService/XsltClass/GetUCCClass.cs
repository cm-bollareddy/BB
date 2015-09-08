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
	/// GetUCCClass: Implement the GetUCC web method using XSLT.
	/// </summary>
	class GetUCCClass
	{
		private const string FILE_GET_XSLT = @"GetUCC.xslt";

		public GetUCCClass()
		{
		}

		public DataSet GetUCC(string strSessionID, int nUCCID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetUCC.\n strSessionID=" + strSessionID + ", nUCCID="  + nUCCID);
		
			TVSServer.rdmPBSManageTable oPBSUCC;

			try
			{
				oPBSUCC = ComponentFactory.CreateManageTableClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSManageTable GetUCC",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSUCC.GetUCC(strSessionID, nUCCID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"UCCID= " + nUCCID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetUCC.\n strSessionID=" + strSessionID + ", nUCCID="  + nUCCID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "UCCID= " + nUCCID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
