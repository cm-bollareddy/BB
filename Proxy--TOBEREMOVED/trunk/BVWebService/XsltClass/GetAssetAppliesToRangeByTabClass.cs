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
	/// GetAssetAppliesToRangeByTabClass: Implement the GetAssetAppliesToRangeByTab web method using XSLT.
	/// </summary>
	class GetAssetAppliesToRangeByTabClass
	{
		private const string FILE_GET_XSLT = @"GetAssetAppliesToRangeByTab.xslt";

		public GetAssetAppliesToRangeByTabClass()
		{
		}

		public DataSet GetAssetAppliesToRangeByTab(string strSessionID, int nAssetAppliesToRangeByTabID, string strTabType)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetAssetAppliesToRangeByTab.\n strSessionID=" + strSessionID + ", nAssetAppliesToRangeByTabID="  + nAssetAppliesToRangeByTabID+ ", strTabType="  + strTabType);

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
					"Component= TVSServer.rdmPBSManageAppliesToRange GetAssetAppliesToRangeByTab",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSAssetAppliesToRangeByTab.GetAssetAppliesToRangeByTab(strSessionID, nAssetAppliesToRangeByTabID, strTabType, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"AssetAppliesToRangeByTabID= " + nAssetAppliesToRangeByTabID + ", strTabType= " + strTabType,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetAssetAppliesToRangeByTab.\n strSessionID=" + strSessionID + ", nAssetAppliesToRangeByTabID="  + nAssetAppliesToRangeByTabID+ ", strTabType="  + strTabType);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "AssetAppliesToRangeByTabID= " + nAssetAppliesToRangeByTabID + ", strTabType="  + strTabType);
			}
		}
	}
}
