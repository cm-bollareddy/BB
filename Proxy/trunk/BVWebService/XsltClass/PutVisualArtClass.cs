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
	/// PutVisualArtClass: Implement the PutVisualArt web method using XSLT.
	/// </summary>
	class PutVisualArtClass
	{
		private const string FILE_SET_XSLT = @"PutVisualArt.xslt";

		public PutVisualArtClass()
		{
		}

		public void PutVisualArt(string strSessionID, string strLockID, DataSet dsVisualArt)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutVisualArt.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsVisualArt, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSVisualArt object, throwing exception if failed
			//
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
					"Component: TVSServer.rdmPBSManageTable PutVisualArt",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSVisualArt.PutVisualArt(strSessionID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsVisualArt.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsVisualArt.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutVisualArt.\n strSessionID=" + strSessionID );
		}
	}
}
