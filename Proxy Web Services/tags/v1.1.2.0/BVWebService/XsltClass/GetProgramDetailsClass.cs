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
	/// GetProgramDetailsClass: Implement the GetProgramDetails web method using XSLT.
	/// </summary>
	class GetProgramDetailsClass
	{
		private const string FILE_GET_XSLT = @"GetProgramDetails.xslt";

		public GetProgramDetailsClass()
		{
		}
				
		public DataSet GetProgramDetails(string strSessionID, int nProgramDetailsID, bool bLockFlag,bool bGetPremiereDate, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetProgramDetails.\n strSessionID=" + strSessionID + ", nProgramDetailsID="  + nProgramDetailsID);
		
			TVSServer.rdmPBSProgram oPBSProgramDetails;

			try
			{
				oPBSProgramDetails = ComponentFactory.CreateProgramClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSProgram GetProgramDetails",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSProgramDetails.GetProgramDetails(strSessionID, nProgramDetailsID, bLockFlag, bGetPremiereDate, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"ProgramDetailsID= " + nProgramDetailsID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetProgramDetails.\n strSessionID=" + strSessionID + ", nProgramDetailsID="  + nProgramDetailsID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "ProgramDetailsID= " + nProgramDetailsID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
