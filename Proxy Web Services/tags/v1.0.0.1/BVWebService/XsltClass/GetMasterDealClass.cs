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
	/// GetDataClass: Implement the GetData web method using XSLT.
	/// </summary>
	class GetMasterDealClass
	{
		private const string FILE_GET_XSLT = @"GetMasterDeal.xslt";

		public GetMasterDealClass()
		{
		}

		public DataSet GetMasterDeal(string strSessionID, string strLimitingDate)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetMasterDeal.\n strSessionID=" + strSessionID );
		
			TVSServer.rdmPBSGetMasterDeal oPBSMasterDeal;

			try
			{
				oPBSMasterDeal = ComponentFactory.CreateMasterDealClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= pbsInterface.PBSMasterDeal",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSMasterDeal.GetMasterDeal(strSessionID, strLimitingDate, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"SessionID= " + strSessionID,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetMasterDeal.\n SessionID=" + strSessionID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID );
			}
		}
	}
}
