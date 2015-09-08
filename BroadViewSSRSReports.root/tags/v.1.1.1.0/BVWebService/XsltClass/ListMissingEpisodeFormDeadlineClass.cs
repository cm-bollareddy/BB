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
	/// ListMissingEpisodeFormDeadlineClass: Implement the ListMissingEpisodeFormDeadline web method using XSLT.
	/// </summary>
	class ListMissingEpisodeFormDeadlineClass
	{
		private const string FILE_List_XSLT = @"ListMissingEpisodeFormDeadline.xslt";

		public ListMissingEpisodeFormDeadlineClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet ListMissingEpisodeFormDeadline(string strSessionID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering ListMissingEpisodeFormDeadline.\n");
		
		
			TVSServer.rdmPBSDeadlineNotification oPBSMissingEpisodeFormDeadline;

			try
			{
				oPBSMissingEpisodeFormDeadline = ComponentFactory.CreateDeadlineNotificationClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeadlineNotification ListMissingEpisodeFormDeadline",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSMissingEpisodeFormDeadline.ListMissingEpisodeFormDeadline(strSessionID, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"",
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving ListMissingEpisodeFormDeadline.\n strSessionID=" + strSessionID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_List_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "");
			}
		}
	}
}
