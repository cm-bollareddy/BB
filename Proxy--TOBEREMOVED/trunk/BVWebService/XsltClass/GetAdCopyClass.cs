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
	/// GetAdCopyClass: Implement the GetAdCopy web method using XSLT.
	/// </summary>
	class GetAdCopyClass
	{
		private const string FILE_GET_XSLT = @"GetAdCopy.xslt";

		public GetAdCopyClass()
		{
		}

		public DataSet GetAdCopy(string strSessionID, int nAdCopyID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetAdCopy.\n strSessionID=" + strSessionID + ", nAdCopyID="  + nAdCopyID);
		
			TVSServer.rdmPBSProgram oPBSAdCopy;

			try
			{
				oPBSAdCopy = ComponentFactory.CreateProgramClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSProgram GetAdCopy",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSAdCopy.GetAdCopy(strSessionID, nAdCopyID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"AdCopyID= " + nAdCopyID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetAdCopy.\n strSessionID=" + strSessionID + ", nAdCopyID="  + nAdCopyID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "AdCopyID= " + nAdCopyID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
