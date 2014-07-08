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
	/// CreateDealClass: Implement the CreateDeal web method.
	/// </summary>
	class CreateDealClass
	{
		public CreateDealClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public void CreateDeal(string p_sSessionID
            ,int p_iNewDealId
            ,string p_sNewDealDescription
            ,int p_iMasterDealId
            ,string p_sMasterDealTitle
            ,bool p_bIsSDRights
            ,bool p_bIsHDRights
            ,int[] p_iEpisodeIds
			,int[] p_iDealAttributeIds
            )


		{
			//
			// Construct the search input parameter for troubleshooting...
			//
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering CreateDeal. \nNew Deal Id:  [" + p_iNewDealId.ToString() + "] "  
                                                + " Deal Desc: [" + p_sNewDealDescription + "]"
                                                + " Master Deal Id: [" + p_iMasterDealId.ToString() + "]"
                                                + " Master Deal Title: [" + p_sNewDealDescription + "]"
                                                + " SD Rights: [" + p_bIsSDRights.ToString() + "]"
                                                + " HD Rights: [" + p_bIsHDRights.ToString() + "]"
                                                + " Episode Ids: [" + string.Join(",", p_iEpisodeIds) + "]" 
                                                + " Deal Attribute Ids: [" + string.Join(",", p_iDealAttributeIds) + "]");
			
			// Validate that at least one of the input parameter(s) is defined
            // BroadView enforces (SD or HD required) and (Deal Desc Required) - Epsiode Ids are not required.

            //Check Deal Desc
            if (string.IsNullOrEmpty(p_sNewDealDescription))
            {
                throw new ServiceException(
                    ServiceException.ExceptionCode.InvalidParameters,
                    "A New Deal Description is Required.",
                    "",
                    ServiceException.ExceptionActor.Client);
            }

            //Check SD/HD Rights
            if (!p_bIsHDRights && !p_bIsSDRights)
            {
                throw new ServiceException(
                    ServiceException.ExceptionCode.InvalidParameters,
                    "A SD and/or HD Rights Selection is Required.",
                    "",
                    ServiceException.ExceptionActor.Client);
            }
			//
			// Go ahead and search based upon given parameters
			//
			TVSServer.rdmPBSDeal oPBSDeal;

			try
			{
				oPBSDeal = ComponentFactory.CreateDealClass();
				
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSDeal CreateDeal",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			
			try
			{
				nErrorCode = oPBSDeal.CreateDeal(
                    p_sSessionID
                    ,p_iNewDealId
                    ,p_sNewDealDescription
                    ,p_iMasterDealId
                    ,p_sMasterDealTitle
                    ,p_bIsSDRights
                    ,p_bIsHDRights
                    ,p_iEpisodeIds
                    ,p_iDealAttributeIds
                    ,out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"SessionID= " + p_sSessionID + ", New Deal Id:  " + p_iNewDealId + "MasterDealId:" + p_iMasterDealId,
					ex);
			}

			if (nErrorCode == 0)
			{
				
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + p_sSessionID);
			}
		}
	}
}
