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
	/// ListProgramsByDealClass: Implement the ListProgramsByDeal web method using XSLT.
	/// </summary>
	class ListProgramsByDealClass
	{
		private const string FILE_List_XSLT = @"ListProgramsByDeal.xslt";

		public ListProgramsByDealClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataSet ListProgramsByDeal(string strSessionID, int nID)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering ListProgramsByDeal.\n");
		
		
			TVSServer.rdmPBSProgram oPBSProgramsByDeal;

			try
			{
				oPBSProgramsByDeal = ComponentFactory.CreateProgramClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSProgram ListProgramsByDeal",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSProgramsByDeal.ListProgramsByDeal(strSessionID, nID, out strResult, out strErrorText);
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
				oTracer.LogInfo("Leaving ListProgramsByDeal.\n strSessionID=" + strSessionID + ", ID="  + nID);
			
				return SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_List_XSLT);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "");
			}
		}
	}
}
