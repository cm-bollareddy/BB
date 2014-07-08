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
	/// PutFormatSheetClass: Implement the PutFormatSheet web method using XSLT.
	/// </summary>
	class PutFormatSheetClass
	{
		private const string FILE_SET_XSLT = @"PutFormatSheet.xslt";

		public PutFormatSheetClass()
		{
		}

		public void PutFormatSheet(string strSessionID, string strLockID, DataSet dsFormatSheet)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutFormatSheet.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsFormatSheet, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSFormatSheet object, throwing exception if failed
			//
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
					"Component: TVSServer.rdmPBSManageTable PutFormatSheet",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSFormatSheet.PutFormatSheet(strSessionID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsFormatSheet.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsFormatSheet.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutFormatSheet.\n strSessionID=" + strSessionID );
		}
	}
}
