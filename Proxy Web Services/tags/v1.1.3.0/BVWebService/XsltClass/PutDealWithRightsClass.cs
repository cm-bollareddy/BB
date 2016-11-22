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
	/// PutDataClass: Implement the PutDealWithRights web method using XSLT.
	/// </summary>
	class PutDealWithRightsClass
	{
		private const string FILE_SET_XSLT = @"PutDealWithRights.xslt";

		public PutDealWithRightsClass()
		{
		}

		public void PutDealWithRights(string strSessionID, int nDealWithRightsID, string strLockID, DataSet dsDealWithRights)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutDealWithRights.\n strSessionID=" + strSessionID + ", nDealWithRightsID="  + nDealWithRightsID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsDealWithRights, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSDealWithRights object, throwing exception if failed
			//
			TVSServer.rdmPBSDeal oPBSDealWithRights;
			try
			{
				oPBSDealWithRights = ComponentFactory.CreateDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSDeal PutDealWithRights",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSDealWithRights.PutDealWithRights(strSessionID, nDealWithRightsID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsDealWithRights.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText, "DealWithRightsID=" + nDealWithRightsID + "\n\nDataSet=" + dsDealWithRights.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutDealWithRights.\n strSessionID=" + strSessionID + ", nDealWithRightsID="  + nDealWithRightsID);
		}
	}
}
