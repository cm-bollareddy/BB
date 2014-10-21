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
	/// GetOACClass: Implement the GetOAC web method using XSLT.
	/// </summary>
	class GetOACClass
	{
		private const string FILE_GET_XSLT = @"GetOAC.xslt";

		public GetOACClass()
		{
		}

		public DataSet GetOAC(string strSessionID, int nOACID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetOAC.\n strSessionID=" + strSessionID + ", nOACID="  + nOACID);
		
			TVSServer.rdmPBSManageTable oPBSOAC;

			try
			{
				oPBSOAC = ComponentFactory.CreateManageTableClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSManageTable GetOAC",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSOAC.GetOAC(strSessionID, nOACID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"OACID= " + nOACID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetOAC.\n strSessionID=" + strSessionID + ", nOACID="  + nOACID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "OACID= " + nOACID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
