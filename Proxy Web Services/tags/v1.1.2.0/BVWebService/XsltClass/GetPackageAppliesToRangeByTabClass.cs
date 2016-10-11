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
	/// GetPackageAppliesToRangeByTabClass: Implement the GetPackageAppliesToRangeByTab web method using XSLT.
	/// </summary>
	class GetPackageAppliesToRangeByTabClass
	{
		private const string FILE_GET_XSLT = @"GetPackageAppliesToRangeByTab.xslt";

		public GetPackageAppliesToRangeByTabClass()
		{
		}

		public DataSet GetPackageAppliesToRangeByTab(string strSessionID, int nPackageAppliesToRangeByTabID, string strTabType)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetPackageAppliesToRangeByTab.\n strSessionID=" + strSessionID + ", nPackageAppliesToRangeByTabID="  + nPackageAppliesToRangeByTabID+ ", strTabType="  + strTabType);

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
					"Component= TVSServer.rdmPBSManageAppliesToRange GetPackageAppliesToRangeByTab",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSPackageAppliesToRangeByTab.GetPackageAppliesToRangeByTab(strSessionID, nPackageAppliesToRangeByTabID, strTabType, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"PackageAppliesToRangeByTabID= " + nPackageAppliesToRangeByTabID + ", strTabType= " + strTabType,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetPackageAppliesToRangeByTab.\n strSessionID=" + strSessionID + ", nPackageAppliesToRangeByTabID="  + nPackageAppliesToRangeByTabID+ ", strTabType="  + strTabType);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "PackageAppliesToRangeByTabID= " + nPackageAppliesToRangeByTabID + ", strTabType="  + strTabType);
			}
		}
	}
}
