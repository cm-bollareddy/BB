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
	/// PutAdCopyClass: Implement the PutAdCopy web method using XSLT.
	/// </summary>
	class PutAdCopyClass
	{
		private const string FILE_SET_XSLT = @"PutAdCopy.xslt";

		public PutAdCopyClass()
		{
		}

		public void PutAdCopy(string strSessionID, string strLockID, DataSet dsAdCopy)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutAdCopy.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsAdCopy, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSAdCopy object, throwing exception if failed
			//
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
					"Component: TVSServer.rdmPBSProgram PutAdCopy",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSAdCopy.PutAdCopy(strSessionID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsAdCopy.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsAdCopy.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutAdCopy.\n strSessionID=" + strSessionID );
		}
	}
}
