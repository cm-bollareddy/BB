﻿using System;
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
	/// PutFeatureMediaInventoryClass: Implement the PutFeatureMediaInventory web method using XSLT.
	/// </summary>
	class PutFeatureMediaInventoryClass
	{
		private const string FILE_SET_XSLT = @"PutFeatureMediaInventory.xslt";

		public PutFeatureMediaInventoryClass()
		{
		}

		public void PutFeatureMediaInventory(string strSessionID, string strLockID, DataSet dsFeatureMediaInventory)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutFeatureMediaInventory.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			string strUpdateXml = SchemaConverter.ToXml(dsFeatureMediaInventory, BVWebService.ApplicationPath + @"\xslt\" + FILE_SET_XSLT);
			
			//
			// Create the PBSFeatureMediaInventory object, throwing exception if failed
			//
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
					"Component: TVSServer.rdmPBSMediaInventory PutFeatureMediaInventory",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSFeatureMediaInventory.PutFeatureMediaInventory(strSessionID, strLockID, strUpdateXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dsFeatureMediaInventory.GetXml() + "\n\nXML=" + strUpdateXml,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText,"\n\nDataSet=" + dsFeatureMediaInventory.GetXml() + "\n\nXML=" + strUpdateXml);
			}
			
			oTracer.LogInfo("Leaving PutFeatureMediaInventory.\n strSessionID=" + strSessionID );
		}
	}
}
