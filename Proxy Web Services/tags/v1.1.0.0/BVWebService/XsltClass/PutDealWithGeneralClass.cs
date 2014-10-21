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
	/// PutDataClass: Implement the PutDealWithGeneral web method using XSLT.
	/// </summary>
	class PutDealWithGeneralClass
	{
		private const string FILE_SET_XSLT = @"PutDealWithGeneral.xslt";

		public PutDealWithGeneralClass()
		{
		}

		public void PutDealWithGeneral(string strSessionID, int nDealWithGeneralID, string strLockID, DataSet dsDealWithGeneral)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutDealWithGeneral.\n strSessionID=" + strSessionID + ", nDealWithGeneralID="  + nDealWithGeneralID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsDealWithGeneral, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSDealWithGeneral object, throwing exception if failed
			//
			TVSServer.rdmPBSDeal oPBSDealWithGeneral;
			try
			{
				oPBSDealWithGeneral = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSDeal PutDealWithGeneral",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSDealWithGeneral.PutDealWithGeneral(strSessionID, nDealWithGeneralID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsDealWithGeneral.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText, "DealWithGeneralID=" + nDealWithGeneralID + "\n\nDataSet=" + dsDealWithGeneral.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutDealWithGeneral.\n strSessionID=" + strSessionID + ", nDealWithGeneralID="  + nDealWithGeneralID);
		}
	}
}
