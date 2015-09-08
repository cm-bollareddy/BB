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
	/// GetTalentClass: Implement the GetTalent web method using XSLT.
	/// </summary>
	class GetTalentClass
	{
		private const string FILE_GET_DATA_EPISODE_APP_XSLT = @"GetDataEpisodeAppliesTo.xslt";
		private const string FILE_GET_DATA_EPISODE_TALENT_XSLT = @"GetDataEpisodeTalent.xslt";
		private const string FILE_GET_DATA_TALENT_XSLT = @"GetDataTalent.xslt";

		public GetTalentClass()
		{
		}

		public void GetTalent(string strSessionID, int nDealID,int nTalentID,int nRoleId, out DataSet dataSetDataEpisodeAppliesTo, out DataSet dataSetEpisodeTalent, out DataSet dataSetDataTalent )
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering GetTalent.\n strSessionID=" + strSessionID + ", nDealID=" + nDealID+ ", nTalentID=" + nTalentID+ ", nRoleId=" + nRoleId );
		
			TVSServer.rdmPBSTalent oPBSTalent;
			dataSetDataEpisodeAppliesTo =null;
			dataSetEpisodeTalent = null;
			dataSetDataTalent = null;

			try
			{
				oPBSTalent = ComponentFactory.CreateTalentClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSTalent GetTalent",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strDataEpisodeAppliesTo = string.Empty;
			string strDataEpisodeTalent = string.Empty;
			string strDataTalent = string.Empty;
			try
			{
				nErrorCode =oPBSTalent.GetTalent(strSessionID, nDealID,nTalentID,nRoleId,out strDataEpisodeAppliesTo,out strDataEpisodeTalent,out strDataTalent, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"nDealID=" + nDealID+ ", nTalentID=" + nTalentID+ ", nRoleId=" + nRoleId,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving GetTalent.\n strSessionID=" + strSessionID + ",nDealID=" + nDealID+ ", nTalentID=" + nTalentID+ ", nRoleId=" + nRoleId);
				//get our duck in the row and populate all the datasets
				dataSetDataEpisodeAppliesTo = SchemaConverter.ToDataSet(strDataEpisodeAppliesTo, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_DATA_EPISODE_APP_XSLT);
				dataSetEpisodeTalent = SchemaConverter.ToDataSet(strDataEpisodeTalent, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_DATA_EPISODE_TALENT_XSLT);
				dataSetDataTalent = SchemaConverter.ToDataSet(strDataTalent, BVWebService.ApplicationPath + @"\xslt\" + FILE_GET_DATA_TALENT_XSLT);

			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, ",nDealID=" + nDealID+ ", nTalentID=" + nTalentID+ ", nRoleId=" + nRoleId);
			}
		}
	}
}
