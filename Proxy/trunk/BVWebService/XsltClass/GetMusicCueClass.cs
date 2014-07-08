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
	/// GetMusicCueClass: Implement the GetMusicCue web method using XSLT.
	/// </summary>
	class GetMusicCueClass
	{
		private const string FILE_GET_XSLT = @"GetMusicCue.xslt";

		public GetMusicCueClass()
		{
		}

		public DataSet GetMusicCue(string strSessionID, int nMusicCueID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetMusicCue.\n strSessionID=" + strSessionID + ", nMusicCueID="  + nMusicCueID);
		
			TVSServer.rdmPBSManageTable oPBSMusicCue;

			try
			{
				oPBSMusicCue = ComponentFactory.CreateManageTableClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSManageTable GetMusicCue",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSMusicCue.GetMusicCue(strSessionID, nMusicCueID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"MusicCueID= " + nMusicCueID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetMusicCue.\n strSessionID=" + strSessionID + ", nMusicCueID="  + nMusicCueID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "MusicCueID= " + nMusicCueID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
