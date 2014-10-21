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
	/// PutDataClass: Implement the PutDeal web method using XSLT.
	/// </summary>
	class PutDealClass
	{
		private const string FILE_SET_XSLT = @"PutDeal.xslt";

		public PutDealClass()
		{
		}

		public void PutDeal(string strSessionID, int nDealID, string strLockID, DataSet dsDeal)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutDeal.\n strSessionID=" + strSessionID + ", nDealID="  + nDealID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsDeal, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSDeal object, throwing exception if failed
			//
			TVSServer.rdmPBSDeal oPBSDeal;
			try
			{
				oPBSDeal = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSDeal PutDeal",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSDeal.PutDeal(strSessionID, nDealID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsDeal.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText, "DealID=" + nDealID + "\n\nDataSet=" + dsDeal.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutDeal.\n strSessionID=" + strSessionID + ", nDealID="  + nDealID);
		}
	}
}
