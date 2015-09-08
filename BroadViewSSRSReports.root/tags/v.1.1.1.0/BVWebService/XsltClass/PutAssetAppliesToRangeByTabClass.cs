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
	/// PutAssetAppliesToRangeByTabClass: Implement the PutAssetAppliesToRangeByTab web method using XSLT.
	/// </summary>
	class PutAssetAppliesToRangeByTabClass
	{
		private const string FILE_SET_XSLT = @"PutAssetAppliesToRangeByTab.xslt";

		public PutAssetAppliesToRangeByTabClass()
		{
		}

		public void PutAssetAppliesToRangeByTab(string strSessionID, DataSet dsAssetAppliesToRangeByTab)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutAssetAppliesToRangeByTab.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsAssetAppliesToRangeByTab, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSAssetAppliesToRangeByTab object, throwing exception if failed
			//
			TVSServer.rdmPBSManageAppliesToRange oPBSAssetAppliesToRangeByTab;
			try
			{
				oPBSAssetAppliesToRangeByTab = ComponentFactory.CreateManageAppliesToRangeClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSManageAppliesToRange PutAssetAppliesToRangeByTab",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSAssetAppliesToRangeByTab.PutAssetAppliesToRangeByTab(strSessionID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsAssetAppliesToRangeByTab.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsAssetAppliesToRangeByTab.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutAssetAppliesToRangeByTab.\n strSessionID=" + strSessionID );
		}
	}
}
