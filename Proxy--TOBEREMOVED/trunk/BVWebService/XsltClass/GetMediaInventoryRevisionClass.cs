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
	/// GetMediaInventoryRevisionClass: Implement the GetMediaInventoryRevision web method using XSLT.
	/// </summary>
	class GetMediaInventoryRevisionClass
	{
		private const string FILE_GET_XSLT = @"GetMediaInventoryRevision.xslt";

		public GetMediaInventoryRevisionClass()
		{
		}

		public DataSet GetMediaInventoryRevision(string strSessionID, int nMediaInventoryRevisionID, bool bLockFlag, out string strLockID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetMediaInventoryRevision.\n strSessionID=" + strSessionID + ", nMediaInventoryRevisionID="  + nMediaInventoryRevisionID);
		
			TVSServer.rdmPBSMediaInventory oPBSMediaInventoryRevision;

			try
			{
				oPBSMediaInventoryRevision = ComponentFactory.CreateMediaInventoryClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSMediaInventory GetMediaInventoryRevision",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSMediaInventoryRevision.GetMediaInventoryRevision(strSessionID, nMediaInventoryRevisionID, bLockFlag, out strLockID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"MediaInventoryRevisionID= " + nMediaInventoryRevisionID + ", LockFlag= " + bLockFlag,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetMediaInventoryRevision.\n strSessionID=" + strSessionID + ", nMediaInventoryRevisionID="  + nMediaInventoryRevisionID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "MediaInventoryRevisionID= " + nMediaInventoryRevisionID + ", LockFlag= " + bLockFlag);
			}
		}
	}
}
