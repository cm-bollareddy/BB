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
	/// DeleteFormatSheetClass .
	/// </summary>
	class DeleteFormatSheetClass
	{
		
		public DeleteFormatSheetClass()
		{
		}

		public void DeleteFormatSheet(string strSessionID,int nTabId,string strLockId)
		{
			
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering DeleteFormatSheetClass.\n strSessionID=" + strSessionID + ", nTabId="  + nTabId);
		
			TVSServer.rdmPBSManageTable oPBSManageTable;

			try
			{
				oPBSManageTable = ComponentFactory.CreateManageTableClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSManageTable DeleteFormatSheet",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			
			try
			{
				nErrorCode = oPBSManageTable.DeleteFormatSheet(strSessionID, strLockId,nTabId, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"nTabId= " + nTabId + ", LockId= " + strLockId,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving DeleteFormatSheetClass.\n strSessionID=" + strSessionID + ", nTabId="  + nTabId);
			
				
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "nTabId= " + nTabId + ", LockId= " + strLockId );
			}
		}
	}
}
