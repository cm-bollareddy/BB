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
	/// ListDealsByMasterDealClass: Implement the ListDealsByMasterDeal web method using XSLT.
	/// </summary>
	class ListDealsByMasterDealClass
	{
		private const string FILE_List_XSLT = @"ListDealsByMasterDeal.xslt";

		public ListDealsByMasterDealClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet ListDealsByMasterDeal(string strSessionID, int nID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering ListDealsByMasterDeal.\n");
		
		
			TVSServer.rdmPBSGetMasterDeal oPBSDealsByMasterDeal;

			try
			{
				oPBSDealsByMasterDeal = ComponentFactory.CreateMasterDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSGetMasterDeal ListDealsByMasterDeal",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSDealsByMasterDeal.ListDealsByMasterDeal(strSessionID, nID, out strResult, out strErrorText);
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
				oTracer.LogInfo("Leaving ListDealsByMasterDeal.\n strSessionID=" + strSessionID + ", ID="  + nID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_List_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "");
			}
		}
	}
}
