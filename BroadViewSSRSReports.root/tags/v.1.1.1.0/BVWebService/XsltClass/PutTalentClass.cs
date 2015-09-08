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
	/// PutTalentClass: Implement the PutTalent web method using XSLT.
	/// </summary>
	
	class PutTalentClass
	{
		private const string FILE_PUT_DATA_EPISODE_APP_XSLT		= @"PutDataEpisodeAppliesTo.xslt";
		private const string FILE_PUT_DATA_EPISODE_TALENT_XSLT	= @"PutDataEpisodeTalent.xslt";
		private const string FILE_PUT_DATA_TALENT_XSLT			= @"PutDataTalent.xslt";
		public PutTalentClass()
		{
		
		}

		public void PutTalent(string strSessionID, DataSet dataSetDataEpisodeTalent,DataSet dataSetDataTalent)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering PutTalent.\n strSessionID=" + strSessionID);
		
			//
			// Convert incoming dataset into XML stream
			//
			
			//let convert them one by one
			string strUpdateEpisodeTalentXml = SchemaConverter.ToXml(dataSetDataEpisodeTalent, BVWebService.ApplicationPath + @"\xslt\" + FILE_PUT_DATA_EPISODE_TALENT_XSLT);
			
			string strUpdateTalentXml = SchemaConverter.ToXml(dataSetDataTalent, BVWebService.ApplicationPath + @"\xslt\" + FILE_PUT_DATA_TALENT_XSLT);
			
			//
			// Create the PBSTalent object, throwing exception if failed
			//
			TVSServer.rdmPBSTalent oPBSTalent;
			try
			{
				oPBSTalent = ComponentFactory.CreateTalentClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component: TVSServer.rdmPBSTalent PutTalent",
					ex);
			}

			//
			// Update the data
			//
			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSTalent.PutTalent(strSessionID, strUpdateEpisodeTalentXml,strUpdateTalentXml, out strErrorText);
			}
			catch(Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"DataSet=" + dataSetDataEpisodeTalent.GetXml() + "\n\nXML=" + strUpdateEpisodeTalentXml + "\n\nDataSet=" + dataSetDataTalent.GetXml() + "\n\nXML=" + strUpdateTalentXml ,
					ex);
			}

			if (nErrorCode != 0)
			{
				throw new BVException(nErrorCode, strErrorText, "\n\nDataSet=" + dataSetDataEpisodeTalent.GetXml() + "\n\nXML=" + strUpdateEpisodeTalentXml + "\n\nDataSet=" + dataSetDataTalent.GetXml() + "\n\nXML=" + strUpdateTalentXml);
			}
			
			oTracer.LogInfo("Leaving PutTalent.\n strSessionID=" + strSessionID);
		}
	}
}
