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
	/// ListFormDeadlineClass: Implement the ListFormDeadline web method using XSLT.
	/// </summary>
	class ListFormDeadlineClass
	{
		private const string FILE_List_XSLT = @"ListFormDeadline.xslt";

		public ListFormDeadlineClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet ListFormDeadline(string strSessionID, int nID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering ListFormDeadline.\n");
		
		
			TVSServer.rdmPBSDeadlineNotification oPBSFormDeadline;

			try
			{
				oPBSFormDeadline = ComponentFactory.CreateDeadlineNotificationClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeadlineNotification ListFormDeadline",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSFormDeadline.ListFormDeadline(strSessionID, nID, out strResult, out strErrorText);
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
				oTracer.LogInfo("Leaving ListFormDeadline.\n strSessionID=" + strSessionID + ", ID="  + nID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_List_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "");
			}
		}
	}
}
