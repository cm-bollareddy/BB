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
	/// PutDataClass: Implement the PutDealWithTechnical web method using XSLT.
	/// </summary>
	class PutDealWithTechnicalClass
	{
		private const string FILE_SET_XSLT = @"PutDealWithTechnical.xslt";

		public PutDealWithTechnicalClass()
		{
		}

		public void PutDealWithTechnical(string strSessionID, int nDealWithTechnicalID, string strLockID, DataSet dsDealWithTechnical)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutDealWithTechnical.\n strSessionID=" + strSessionID + ", nDealWithTechnicalID="  + nDealWithTechnicalID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsDealWithTechnical, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSDealWithTechnical object, throwing exception if failed
			//
			TVSServer.rdmPBSDeal oPBSDealWithTechnical;
			try
			{
				oPBSDealWithTechnical = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSDeal PutDealWithTechnical",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSDealWithTechnical.PutDealWithTechnical(strSessionID, nDealWithTechnicalID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsDealWithTechnical.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText, "DealWithTechnicalID=" + nDealWithTechnicalID + "\n\nDataSet=" + dsDealWithTechnical.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutDealWithTechnical.\n strSessionID=" + strSessionID + ", nDealWithTechnicalID="  + nDealWithTechnicalID);
		}
	}
}
