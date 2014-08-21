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
	/// PutIWTClass: Implement the PutIWT web method using XSLT.
	/// </summary>
	class PutIWTClass
	{
		private const string FILE_SET_XSLT = @"PutIWT.xslt";

		public PutIWTClass()
		{
		}

		public void PutIWT(string strSessionID, string strLockID, DataSet dsIWT)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutIWT.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsIWT, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSIWT object, throwing exception if failed
			//
			TVSServer.rdmPBSManageTable oPBSIWT;
			try
			{
				oPBSIWT = ComponentFactory.CreateManageTableClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSManageTable PutIWT",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSIWT.PutIWT(strSessionID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsIWT.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsIWT.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutIWT.\n strSessionID=" + strSessionID );
		}
	}
}
