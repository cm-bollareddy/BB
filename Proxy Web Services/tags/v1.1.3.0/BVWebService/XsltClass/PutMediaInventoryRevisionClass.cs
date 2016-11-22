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
	/// PutMediaInventoryRevisionClass: Implement the PutMediaInventoryRevision web method using XSLT.
	/// </summary>
	class PutMediaInventoryRevisionClass
	{
		private const string FILE_SET_XSLT = @"PutMediaInventoryRevision.xslt";

		public PutMediaInventoryRevisionClass()
		{
		}

		public void PutMediaInventoryRevision(string strSessionID, string strLockID, DataSet dsMediaInventoryRevision)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutMediaInventoryRevision.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsMediaInventoryRevision, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSMediaInventoryRevision object, throwing exception if failed
			//
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
					"Component: TVSServer.rdmPBSMediaInventory PutMediaInventoryRevision",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSMediaInventoryRevision.PutMediaInventoryRevision(strSessionID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsMediaInventoryRevision.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsMediaInventoryRevision.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutMediaInventoryRevision.\n strSessionID=" + strSessionID );
		}
	}
}
