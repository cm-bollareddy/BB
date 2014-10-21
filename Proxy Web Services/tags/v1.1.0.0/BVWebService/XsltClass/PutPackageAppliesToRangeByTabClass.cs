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
	/// PutPackageAppliesToRangeByTabClass: Implement the PutPackageAppliesToRangeByTab web method using XSLT.
	/// </summary>
	class PutPackageAppliesToRangeByTabClass
	{
		private const string FILE_SET_XSLT = @"PutPackageAppliesToRangeByTab.xslt";

		public PutPackageAppliesToRangeByTabClass()
		{
		}

		public void PutPackageAppliesToRangeByTab(string strSessionID, DataSet dsPackageAppliesToRangeByTab)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutPackageAppliesToRangeByTab.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsPackageAppliesToRangeByTab, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSPackageAppliesToRangeByTab object, throwing exception if failed
			//
			TVSServer.rdmPBSManageAppliesToRange oPBSPackageAppliesToRangeByTab;
			try
			{
				oPBSPackageAppliesToRangeByTab = ComponentFactory.CreateManageAppliesToRangeClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSManageAppliesToRange PutPackageAppliesToRangeByTab",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSPackageAppliesToRangeByTab.PutPackageAppliesToRangeByTab(strSessionID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsPackageAppliesToRangeByTab.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsPackageAppliesToRangeByTab.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutPackageAppliesToRangeByTab.\n strSessionID=" + strSessionID );
		}
	}
}
