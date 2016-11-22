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
	/// GetDiscrepancyProgramClass: Implement the GetDiscrepancyProgram web method using XSLT.
	/// </summary>
	class GetDiscrepancyProgramClass
	{
		private const string FILE_GET_XSLT = @"GetDiscrepancyProgram.xslt";
		private const string PACKAGE_ID ="PACKAGE_ID";
		private const string PACKAGE_NUMBER ="PACKAGE_NUMBER";
		private const string PACKAGE_TITLE ="PACKAGE_TITLE";
		private const string PROGRAM_TITLE ="PROGRAM_TITLE";
		private const string SERIES_TITLE ="SERIES_TITLE";
		private const string PROGRAM_EPISODETITLE ="PROGRAM_EPISODETITLE";
		private const string SCHEDULED_DATETIME ="SCHEDULED_DATETIME";
		private const string SCHEDULED_DURATION ="SCHEDULED_DURATION";
		


		public GetDiscrepancyProgramClass()
		{
		}

		public void GetDiscrepancyProgram(string Channel
								,string DiscrepancyStart
								,out string sPackageID
								,out string sPackagenumber
								,out string sPackageTile
								,out string sProgramTile
								,out string sSeriesTile
								,out string sProgramEpisodeTitle
								,out DateTime dSchedDateTime
								,out int nSchedDuration)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetDiscrepancyProgram.\n Channel=" + Channel + ", DiscrepancyStart="  + DiscrepancyStart);

            TVSServer.rdmPBSRemedy oPBSDiscrepancyProgram;
			
			sPackageID				= string.Empty;
			sPackagenumber			= string.Empty;
			sPackageTile			= string.Empty;
			sProgramTile			= string.Empty;
			sSeriesTile				= string.Empty;
			sProgramEpisodeTitle	= string.Empty;
			dSchedDateTime			= DateTime.Now;
			nSchedDuration			= 0;


			try
			{
				oPBSDiscrepancyProgram = ComponentFactory.CreateRemedyClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSRemedy GetDiscrepancyProgram",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strResult = "";
			try
			{
				nErrorCode = oPBSDiscrepancyProgram.GetDiscrepancyProgram(Channel,DiscrepancyStart, out strResult, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"Channel= " + Channel + ", DiscrepancyStart= " + DiscrepancyStart,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetDiscrepancyProgram.\n Channel=" + Channel + ", DiscrepancyStart="  + DiscrepancyStart);
			
				DataSet oData = SchemaConverter.ToDataSet(strResult, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_XSLT);
				if (oData.Tables[0].Rows.Count>=1)
				{
					DataRow row = oData.Tables[0].Rows[0];
					sPackageID = Convert.ToString(row["PACKAGE_ID"]);
					sPackagenumber =Convert.ToString(row["PACKAGE_NUMBER"]);
					sPackageTile =Convert.ToString(row["PACKAGE_TITLE"]);
					sProgramTile =Convert.ToString(row["PROGRAM_TITLE"]);
					sSeriesTile =Convert.ToString(row["SERIES_TITLE"]);
					sProgramEpisodeTitle =Convert.ToString(row["PROGRAM_EPISODETITLE"]);
 					dSchedDateTime = Convert.ToDateTime(row["SCHEDULED_DATETIME"]);
					nSchedDuration=Convert.ToInt32(row["SCHEDULED_DURATION"]);
				}
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "Channel= " + Channel + ", DiscrepancyStart= " + DiscrepancyStart);
			}
		}
	}
}
