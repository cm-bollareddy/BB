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
	/// PutMusicCueClass: Implement the PutMusicCue web method using XSLT.
	/// </summary>
	class PutMusicCueClass
	{
		private const string FILE_SET_XSLT = @"PutMusicCue.xslt";

		public PutMusicCueClass()
		{
		}

		public void PutMusicCue(string strSessionID, string strLockID, DataSet dsMusicCue)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutMusicCue.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsMusicCue, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSMusicCue object, throwing exception if failed
			//
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
					"Component: TVSServer.rdmPBSManageTable PutMusicCue",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSMusicCue.PutMusicCue(strSessionID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsMusicCue.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsMusicCue.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutMusicCue.\n strSessionID=" + strSessionID );
		}
	}
}
