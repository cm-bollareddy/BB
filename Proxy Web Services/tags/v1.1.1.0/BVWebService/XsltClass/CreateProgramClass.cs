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


using System.Linq;

using TVSServer = OrionProxy;

namespace BVWebService
{
	/// <summary>
	/// CreateProgramClass: Implement the CreateProgram web method.
	/// </summary>
	class CreateProgramClass
	{
		

		public CreateProgramClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public void CreateProgram(string strSessionID
            ,int nMasterDealID
            ,string strMasterDealTitle
            ,string strSeason
            ,int nDealID
            ,string strDealDesc
            ,string strDealSynopsis
            ,int nPBSProgramTypeID
            ,int nUpLinkID
            ,int[] nProgramIDs
            ,int nProgramTypeID
            ,int nDuration
            ,string strNolaRoot
            ,int nFirstEpisodeNumber
            ,int nIncrement
            ,int nDistributorID 
			,int nGenreID
            ,bool bLive
            ,bool bRecord
            ,int nDefaultRatingID
            ,int nDisclaimerID
            ,string strFirstPictureLockDate
            ,int nOperatingUnit
            ,string strOperatingGroup
            ,Packages[] cPackages
            ,int nAssetVChipID
            ,string sAssetEpisodeTitle
            ,string sAssetTitleListing
            ,bool bIsFinalTitle
            ,bool bSDRightsFlag
            ,bool bHDRightsFlag)


		{

            int nErrorCode = 0;
            string strErrorText = "";
            bool bExceptionCaught = false;


            Tracer oTracer = new Tracer();
            oTracer.LogInfo("Entering CreateProgram.");


			//
			// Construct the search input parameter for troubleshooting...
			//
			int numProgIds = 0;
            numProgIds = nProgramIDs.Length;

            oTracer.LogInfo("In CreateProgram - requesting " + numProgIds.ToString() + " programs.");


			int numPackages = 0;
            numPackages = cPackages.Length;

            oTracer.LogInfo("In CreateProgram - requesting " + numPackages.ToString() + " packages per program.");



            //string progIds = string.Empty;
            //string spacks = string.Empty;
			
            //foreach (int nid  in nProgramIDs)
            //{
            //    if ((nid != 0))
            //    {
            //        if (progIds != "")
            //            progIds += ",";
            //        progIds += nid.ToString();
            //        numProgIds++;
            //    }	

            //}
            //foreach (Packages pack in cPackages)
            //{
            //    if ((pack != null) && (pack.FormatAndTypeID != 0) && (pack.Length != 0))
            //    {
            //        if (spacks != "")
            //            spacks += ",";
            //        spacks += pack.FormatAndTypeID + "=\"" + pack.Length + "\"";
            //        numPackages++;
            //    }	

            //}

            //oTracer.LogInfo("Entering CreateProgram.\n ProgIds=" + nProgramIDs.ToString());
            //oTracer.LogInfo("Entering CreateProgram.\n Packages=" + spacks);


            //
			// Validate that at least one of the input parameter(s) is defined
			//
			if (numProgIds == 0)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidParameters,
					"No ProgramIds found.",
					"",
					ServiceException.ExceptionActor.Client);
			}
			if (numPackages == 0)
			{
				throw new ServiceException(
					ServiceException.ExceptionCode.InvalidParameters,
					"No packages found.",
					"",
					ServiceException.ExceptionActor.Client);
			}

			//
			// Validate the incoming criteria
			//

            oTracer.LogInfo("In CreateProgram - converting Program List.");
            object[] oProgramIDs = nProgramIDs.Cast<object>().ToArray();


            //object[] oProgramIDs = new object[numProgIds];
            //int i = 0;
            //foreach (int nIds  in nProgramIDs)
            //{
            //    if (nIds !=0)
            //    {	
            //        oProgramIDs[i] = nIds;
            //        i++;
            //    }
            //}


            oTracer.LogInfo("In CreateProgram - converting Package List.");
			object[] oPackages = new object[numPackages];
			int i=0;
			foreach (Packages pack in cPackages)
			{
				if ((pack != null) && ( pack.FormatAndTypeID != 0) && (pack.Length != 0))
				{
					oPackages[i] = (object) new object[6];
					((object[]) oPackages[i])[0] = pack.FormatAndTypeID;
					((object[]) oPackages[i])[1] = pack.Length ;
					((object[]) oPackages[i])[2] = pack.VchipID ;
					((object[]) oPackages[i])[3] = pack.IsVCHIPEmbedded ;
					((object[]) oPackages[i])[4] = pack.IsEiQualified ;
					((object[]) oPackages[i])[5] = pack.IsEiEmbedded ;
					i++;
				}
			}

			//
			// Go ahead and search based upon given parameters
			//
			TVSServer.rdmPBSProgramCreator oPBSProgram;

			try
			{
				oPBSProgram = ComponentFactory.CreateProgramCreatorClass();
				
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSProgramCreator CreateProgram",
					ex);
			}



            try
            {

                oTracer.LogInfo("In CreateProgram - Executing CreateProgram Call to BroadView.");
                nErrorCode = oPBSProgram.CreateProgram(
                    strSessionID
                    , nMasterDealID
                    , strMasterDealTitle
                    , strSeason
                    , nDealID
                    , strDealDesc
                    , strDealSynopsis
                    , nPBSProgramTypeID
                    , nUpLinkID
                    , oProgramIDs
                    , nProgramTypeID
                    , nDuration
                    , strNolaRoot
                    , nFirstEpisodeNumber
                    , nIncrement
                    , nDistributorID
                    , nGenreID
                    , bLive
                    , bRecord
                    , nDefaultRatingID
                    , nDisclaimerID
                    , strFirstPictureLockDate
                    , nAssetVChipID
                    , sAssetEpisodeTitle
                    , sAssetTitleListing
                    , bIsFinalTitle
                    , nOperatingUnit
                    , strOperatingGroup
                    , oPackages
                    , bSDRightsFlag
                    , bHDRightsFlag
                    , out strErrorText);
            }
            catch (Exception ex)
            {
                bExceptionCaught = true;

                throw new BVException(
                    BVException.ExceptionCode.ComponentExecutionFailure,
                    "Error while executing server component method: " + ex.Message,
                    "SessionID= " + strSessionID + ", Params( # Programs: " + numProgIds.ToString() + "; # Packages: " + numPackages.ToString() + ")",
                    ex);
            }
            finally
            {
                oTracer.LogInfo("In CreateProgram - Ended CreateProgram Call to BroadView.  Exception caught during invocation? " + bExceptionCaught.ToString());
            }


            oTracer.LogInfo("Exiting CreateProgram.  BV Error Code: [" + nErrorCode + "]  BV Error Text: [" + strErrorText + "]");	

			if (nErrorCode == 0)
			{
                
			}
			else
			{
                throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID + ", Params( # Programs: " + numProgIds.ToString() + "; # Packages: " + numPackages.ToString() + ")");
			}

		}
	}
}
