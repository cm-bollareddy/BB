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
	/// GetFeatureMediaInventoryClass: Implement the GetFeatureMediaInventory web method using XSLT.
	/// </summary>
	class GetFeatureMediaInventoryClass
	{
		private const string FILE_GET_XSLT = @"GetFeatureMediaInventory.xslt";

		public GetFeatureMediaInventoryClass()
		{
		}

		public DataSet GetFeatureMediaInventory(string strSessionID, int nFeatureMediaInventoryID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetFeatureMediaInventory.\n strSessionID=" + strSessionID + ", nFeatureMediaInventoryID="  + nFeatureMediaInventoryID);
		
			TVSServer.rdmPBSMediaInventory oPBSFeatureMediaInventory;

			try
			{
				oPBSFeatureMediaInventory = ComponentFactory.CreateMediaInventoryClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSMediaInventory GetFeatureMediaInventory",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSFeatureMediaInventory.GetFeatureMediaInventory(strSessionID, nFeatureMediaInventoryID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"FeatureMediaInventoryID= " + nFeatureMediaInventoryID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetFeatureMediaInventory.\n strSessionID=" + strSessionID + ", nFeatureMediaInventoryID="  + nFeatureMediaInventoryID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "FeatureMediaInventoryID= " + nFeatureMediaInventoryID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
