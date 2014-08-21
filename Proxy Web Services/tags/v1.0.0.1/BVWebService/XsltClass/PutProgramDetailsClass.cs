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
	/// PutDataClass: Implement the PutProgramDetails web method using XSLT.
	/// </summary>
	class PutProgramDetailsClass
	{
		private const string FILE_SET_XSLT = @"PutProgramDetails.xslt";

		public PutProgramDetailsClass()
		{
		}

		public void PutProgramDetails(string strSessionID, int nProgramDetailsID, string strLockID, DataSet dsProgramDetails)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutProgramDetails.\n strSessionID=" + strSessionID + ", nProgramDetailsID="  + nProgramDetailsID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsProgramDetails, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSProgramDetails object, throwing exception if failed
			//
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
					"Component: TVSServer.rdmPBSProgram PutProgramDetails",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSProgramDetails.PutProgramDetails(strSessionID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsProgramDetails.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText, "ProgramDetailsID=" + nProgramDetailsID + "\n\nDataSet=" + dsProgramDetails.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutProgramDetails.\n strSessionID=" + strSessionID + ", nProgramDetailsID="  + nProgramDetailsID);
		}
	}
}
