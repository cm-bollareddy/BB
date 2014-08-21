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
	/// DeleteOACClass .
	/// </summary>
	class DeleteOACClass
	{
		
		public DeleteOACClass()
		{
		}

		public void DeleteOAC(string strSessionID,int nTabId,string strLockId)
		{
			
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering DeleteOACClass.\n strSessionID=" + strSessionID + ", nTabId="  + nTabId);
		
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
					"Component= TVSServer.rdmPBSManageTable DeleteOAC",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			
			try
			{
				nErrorCode = oPBSManageTable.DeleteOAC(strSessionID, strLockId,nTabId, out strErrorText);
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
				oTracer.LogInfo("Leaving DeleteOACClass.\n strSessionID=" + strSessionID + ", nTabId="  + nTabId);
			
				
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "nTabId= " + nTabId + ", LockId= " + strLockId );
			}
		}
	}
}
