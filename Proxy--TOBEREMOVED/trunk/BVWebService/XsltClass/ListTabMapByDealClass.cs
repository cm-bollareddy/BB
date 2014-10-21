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
	/// ListTabMapByDealClass: Implement the ListTabMapByDeal web method using XSLT.
	/// </summary>
	class ListTabMapByDealClass
	{
		private const string FILE_List_XSLT = @"ListTabMapByDeal.xslt";

		public ListTabMapByDealClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet ListTabMapByDeal(string strSessionID, int nID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering ListTabMapByDeal.\n");
		
		
			TVSServer.rdmPBSManageAppliesToRange oPBSTabMapByDeal;

			try
			{
				oPBSTabMapByDeal = ComponentFactory.CreateManageAppliesToRangeClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSManageAppliesToRange ListTabMapByDeal",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSTabMapByDeal.ListTabMapByDeal(strSessionID, nID, out strResult, out strErrorText);
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
				oTracer.LogInfo("Leaving ListTabMapByDeal.\n strSessionID=" + strSessionID + ", ID="  + nID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_List_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "");
			}
		}
	}
}
