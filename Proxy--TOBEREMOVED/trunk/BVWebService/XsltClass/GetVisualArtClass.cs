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
	/// GetVisualArtClass: Implement the GetVisualArt web method using XSLT.
	/// </summary>
	class GetVisualArtClass
	{
		private const string FILE_GET_XSLT = @"GetVisualArt.xslt";

		public GetVisualArtClass()
		{
		}

		public DataSet GetVisualArt(string strSessionID, int nVisualArtID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetVisualArt.\n strSessionID=" + strSessionID + ", nVisualArtID="  + nVisualArtID);
		
			TVSServer.rdmPBSManageTable oPBSVisualArt;

			try
			{
				oPBSVisualArt = ComponentFactory.CreateManageTableClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSManageTable GetVisualArt",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSVisualArt.GetVisualArt(strSessionID, nVisualArtID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"VisualArtID= " + nVisualArtID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetVisualArt.\n strSessionID=" + strSessionID + ", nVisualArtID="  + nVisualArtID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "VisualArtID= " + nVisualArtID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
