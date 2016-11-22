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
	/// CreateMediaInventoryRevisionClass: Implement the CreateMediaInventoryRevision web method using XSLT.
	/// </summary>
	class CreateMediaInventoryRevisionClass
	{
		private const string FILE_GET_XSLT = @"GetMediaInventoryRevision.xslt";

		public CreateMediaInventoryRevisionClass()
		{
		}

		public DataSet CreateMediaInventoryRevision(string strSessionID,string strLockId, int nOldID, int nNewID)
		{
			// Method returns a GetMediaInventoryRevision result after a MEIR is created.

			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering CreateMediaInventoryRevision.\n strSessionID=" + strSessionID + ", nOldID="  + nOldID+ ", nNewID="  + nNewID+ ", strLockId="  + strLockId);
		
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
				nErrorCode = oPBSMediaInventoryRevision.CreateMediaInventoryRevision(strSessionID, strLockId,nOldID,nNewID,out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"nOldID= " + nOldID + ", nNewID= " + nNewID + ", LockId= " + strLockId,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving CreateMediaInventoryRevision..\n strSessionID=" + strSessionID + ", nOldID="  + nOldID+ ", nNewID="  + nNewID+ ", strLockId="  + strLockId);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "strSessionID=" + strSessionID + ", nOldID="  + nOldID+ ", nNewID="  + nNewID+ ", strLockId="  + strLockId );
			}
		}
	}
}
