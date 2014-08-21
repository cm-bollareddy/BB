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
	/// GetFormatSheetClass: Implement the GetFormatSheet web method using XSLT.
	/// </summary>
	class GetFormatSheetClass
	{
		private const string FILE_GET_XSLT = @"GetFormatSheet.xslt";

		public GetFormatSheetClass()
		{
		}

		public DataSet GetFormatSheet(string strSessionID, int nFormatSheetID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetFormatSheet.\n strSessionID=" + strSessionID + ", nFormatSheetID="  + nFormatSheetID);
		
			TVSServer.rdmPBSManageTable oPBSFormatSheet;

			try
			{
				oPBSFormatSheet = ComponentFactory.CreateManageTableClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSManageTable GetFormatSheet",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSFormatSheet.GetFormatSheet(strSessionID, nFormatSheetID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"FormatSheetID= " + nFormatSheetID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetFormatSheet.\n strSessionID=" + strSessionID + ", nFormatSheetID="  + nFormatSheetID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "FormatSheetID= " + nFormatSheetID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
