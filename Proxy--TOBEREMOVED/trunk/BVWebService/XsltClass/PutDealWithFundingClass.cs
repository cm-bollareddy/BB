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
	/// PutDataClass: Implement the PutDealWithFunding web method using XSLT.
	/// </summary>
	class PutDealWithFundingClass
	{
		private const string FILE_SET_XSLT = @"PutDealWithFunding.xslt";

		public PutDealWithFundingClass()
		{
		}

		public void PutDealWithFunding(string strSessionID, int nDealWithFundingID, string strLockID, DataSet dsDealWithFunding)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutDealWithFunding.\n strSessionID=" + strSessionID + ", nDealWithFundingID="  + nDealWithFundingID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsDealWithFunding, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSDealWithFunding object, throwing exception if failed
			//
			TVSServer.rdmPBSDeal oPBSDealWithFunding;
			try
			{
				oPBSDealWithFunding = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSDeal PutDealWithFunding",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSDealWithFunding.PutDealWithFunding(strSessionID, nDealWithFundingID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsDealWithFunding.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText, "DealWithFundingID=" + nDealWithFundingID + "\n\nDataSet=" + dsDealWithFunding.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutDealWithFunding.\n strSessionID=" + strSessionID + ", nDealWithFundingID="  + nDealWithFundingID);
		}
	}
}
