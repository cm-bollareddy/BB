using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using BVWebService;
using Pbs.WebServices.Utility;

namespace BVWebService
{
	/// <summary>
	/// Summary description for BVWebService
	/// </summary>
	[WebService(
		 Namespace="http://pbswebservice.broadviewsoftware.com/BVWebService",
		 Name="BVWebService",
		 Description="Web Service for PBS-BroadView integration")]
	public class BVWebService : System.Web.Services.WebService
	{
		public BVWebService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();

			// Get the current server path and save it here...
			if (m_strApplicationPath == "")
			{
				lock(this)
				{
					m_strApplicationPath = Server.MapPath(".");
				}
			}
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion


		private static string m_strApplicationPath = "";
		public static string ApplicationPath
		{
			get
			{
				
				return m_strApplicationPath;
			}
		}

		private void LogException(Exception ex)
		{
			Tracer oTracer = new Tracer();
			oTracer.LogError(ex);
		}

		#region Deal Interfaces
		[WebMethod]
		public DataSet GetDeal(string strSessionID, int nDealID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetDealClass oGetDeal = new GetDealClass();
				return oGetDeal.GetDeal(strSessionID, nDealID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutDeal(string strSessionID, int nDealID, string strLockID, DataSet dsDeal)
		{
			try
			{
				PutDealClass oPutDeal = new PutDealClass();
				oPutDeal.PutDeal(strSessionID, nDealID, strLockID, dsDeal);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion

        #region CreateDeal Interface
        /// <summary>
        /// Method used to create a Deal/Re-Up
        /// </summary>
        /// <param name="p_sSessionId">Session Id</param>
        /// <param name="p_iDealId">(New) Deal Id</param>
        /// <param name="p_sDealDescription">(New) Deal Description</param>
        /// <param name="p_iMasterDealId">Master Deal Id</param>
        /// <param name="p_sMasterDealTitle">Master Deal Title</param>
        /// <param name="p_bIsSDRights">Flag indicating SD Rights are required</param>
        /// <param name="p_bIsHDRights">Flag indicating HD Rights are required</param>
        /// <param name="p_aiEpisodeIds">Collection of Episode Ids to add to new Deal</param>
        /// <param name="p_aiDealAttributeIds">Collection of DealAttribute Ids to add to the new Deal</param>
        [WebMethod]
        public void CreateDeal(string p_sSessionId
                    , int p_iDealId
                    , string p_sDealDescription
                    , int p_iMasterDealId
                    , string p_sMasterDealTitle
                    , bool p_bIsSDRights
                    , bool p_bIsHDRights
                    , int[] p_aiEpisodeIds
                    , int[] p_aiDealAttributeIds)
        {
            try
            {
                CreateDealClass oCreateDeal = new CreateDealClass();
                oCreateDeal.CreateDeal(p_sSessionId
                    , p_iDealId
                    , p_sDealDescription
                    , p_iMasterDealId
                    , p_sMasterDealTitle
                    , p_bIsSDRights
                    , p_bIsHDRights
                    , p_aiEpisodeIds
                    , p_aiDealAttributeIds
                );

            }
            catch (Exception ex)
            {
                LogException(ex);
                ExceptionHandler.ThrowSoapException(ex);
                throw;
            }
        }
        #endregion


        #region DealAll Interface
        [WebMethod]
		public DataSet GetDealAll(string strSessionID, int nDealID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetDealAllClass oGetDealAll = new GetDealAllClass();
				return oGetDealAll.GetDealAll(strSessionID, nDealID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region DealWithFunding Interfaces
		[WebMethod]
		public DataSet GetDealWithFunding(string strSessionID, int nDealID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetDealWithFundingClass oGetDealWithFunding = new GetDealWithFundingClass();
				return oGetDealWithFunding.GetDealWithFunding(strSessionID, nDealID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutDealWithFunding(string strSessionID, int nDealID, string strLockID, DataSet dsDeal)
		{
			try
			{
				PutDealWithFundingClass oPutDealWithFunding = new PutDealWithFundingClass();
				oPutDealWithFunding.PutDealWithFunding(strSessionID, nDealID, strLockID, dsDeal);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion

		#region DealWithGeneral Interfaces
		[WebMethod]
		public DataSet GetDealWithGeneral(string strSessionID, int nDealID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetDealWithGeneralClass oGetDealWithGeneral = new GetDealWithGeneralClass();
				return oGetDealWithGeneral.GetDealWithGeneral(strSessionID, nDealID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutDealWithGeneral(string strSessionID, int nDealID, string strLockID, DataSet dsDeal)
		{
			try
			{
				PutDealWithGeneralClass oPutDealWithGeneral = new PutDealWithGeneralClass();
				oPutDealWithGeneral.PutDealWithGeneral(strSessionID, nDealID, strLockID, dsDeal);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion


		#region DealWithRights Interfaces
		[WebMethod]
		public DataSet GetDealWithRights(string strSessionID, int nDealID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetDealWithRightsClass oGetDealWithRights = new GetDealWithRightsClass();
				return oGetDealWithRights.GetDealWithRights(strSessionID, nDealID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutDealWithRights(string strSessionID, int nDealID, string strLockID, DataSet dsDeal)
		{
			try
			{
				PutDealWithRightsClass oPutDealWithRights = new PutDealWithRightsClass();
				oPutDealWithRights.PutDealWithRights(strSessionID, nDealID, strLockID, dsDeal);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion

		#region DealWithTechnical Interfaces
		[WebMethod]
		public DataSet GetDealWithTechnical(string strSessionID, int nDealID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetDealWithTechnicalClass oGetDealWithTechnical = new GetDealWithTechnicalClass();
				return oGetDealWithTechnical.GetDealWithTechnical(strSessionID, nDealID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutDealWithTechnical(string strSessionID, int nDealID, string strLockID, DataSet dsDeal)
		{
			try
			{
				PutDealWithTechnicalClass oPutDealWithTechnical = new PutDealWithTechnicalClass();
				oPutDealWithTechnical.PutDealWithTechnical(strSessionID, nDealID, strLockID, dsDeal);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion

		#region GetMasterDealInterfaces
		[WebMethod]
		public DataSet GetMasterDeal(string strSessionID, string strLimitingDate)
		{
			try
			{
				GetMasterDealClass oGetMasterDeal = new GetMasterDealClass();
				return oGetMasterDeal.GetMasterDeal(strSessionID, strLimitingDate);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion

        #region MediaInventory Interfaces
      
        
        
        /// <summary>
        /// </summary>
        /// <param name="strSessionID"></param>
        /// <param name="nMediaInventoryID"></param>
        /// <param name="bLockFlag"></param>
        /// <param name="strLockID"></param>
        /// <returns></returns>
        [Obsolete("This method has no internal implementation within BroadView",true)]
        public DataSet GetMediaInventory(string strSessionID, int nMediaInventoryID, bool bLockFlag, out string strLockID)
        {
            try
            {
                strLockID = null;
                return null;
                //GetMediaInventoryClass oGetMediaInventory = new GetMediaInventoryClass();
                //return oGetMediaInventory.GetMediaInventory(strSessionID, nMediaInventoryID, bLockFlag, out strLockID);
            }
            catch(Exception ex)
            {
                LogException(ex);
                ExceptionHandler.ThrowSoapException(ex);
                throw;
            }
        }

        [Obsolete("This method has no internal implementation within BroadView", true)]
        public void PutMediaInventory(string strSessionID, string strLockID, DataSet dsMediaInventory)
        {
            try
            {
                //PutMediaInventoryClass oPutMediaInventory = new PutMediaInventoryClass();
                //oPutMediaInventory.PutMediaInventory(strSessionID, strLockID, dsMediaInventory);
            }
            catch(Exception ex)
            {
                LogException(ex);
                ExceptionHandler.ThrowSoapException(ex);
                throw;
            }
        }
		[WebMethod]
		public void CreateMediaInventoryRevision(string strSessionID,string strLockId, int nOldMediaInventoryID,int nNewMediaInventoryRevisionID)
		{
			try
			{
				
				// changes to the method signature by -rs
				// Should not return any thing as this is not used by Orion logic
				CreateMediaInventoryRevisionClass oCreateMediaInventoryRevision = new CreateMediaInventoryRevisionClass();
				oCreateMediaInventoryRevision.CreateMediaInventoryRevision(strSessionID, strLockId, nOldMediaInventoryID,nNewMediaInventoryRevisionID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void GetBarCode(string strSessionID, int nMediaInventoryID,  out byte[] bBarCode)
		{
			try
			{
				GetBarCodeClass oGetBarCode = new GetBarCodeClass();
				oGetBarCode.GetBarCode(strSessionID, nMediaInventoryID,out bBarCode);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

        #endregion


		#region SearchInterfaces
		[WebMethod]
		public DataSet DealSearch(string strSessionID, SearchCriterion[] SearchCriteria, int nMaxRows)
		{
			try
			{
				DealSearchClass oDealSearch = new DealSearchClass();
				return oDealSearch.DealSearch(strSessionID, SearchCriteria, nMaxRows);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet ProgramSearch(string strSessionID, SearchCriterion[] SearchCriteria, int nMaxRows)
		{
			try
			{
				ProgramSearchClass oProgramSearch = new ProgramSearchClass();
				return oProgramSearch.ProgramSearch(strSessionID, SearchCriteria, nMaxRows);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet MasterDealSearch(string strSessionID, SearchCriterion[] SearchCriteria, int nMaxRows)
		{
			try
			{
				MasterDealSearchClass oMasterDealSearch = new MasterDealSearchClass();
				return oMasterDealSearch.MasterDealSearch(strSessionID, SearchCriteria, nMaxRows);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet MediaInventorySearch(string strSessionID, SearchCriterion[] SearchCriteria, int nMaxRows)
		{
			try
			{
				MediaInventorySearchClass oMediaInventorySearch = new MediaInventorySearchClass();
				return oMediaInventorySearch.MediaInventorySearch(strSessionID, SearchCriteria, nMaxRows);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet TrafficItemSearch(string strSessionID, SearchCriterion[] SearchCriteria, int nMaxRows)
		{
			try
			{
				TrafficItemSearchClass oTrafficItemSearch = new TrafficItemSearchClass();
				return oTrafficItemSearch.TrafficItemSearch(strSessionID, SearchCriteria, nMaxRows);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		
		[WebMethod]
		public DataSet AdCopySearch(string strSessionID, SearchCriterion[] SearchCriteria, int nMaxRows)
		{
			try
			{
				AdCopySearchClass oAdCopySearch = new AdCopySearchClass();
				return oAdCopySearch.AdCopySearch(strSessionID, SearchCriteria, nMaxRows);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet ValidateEpisodeSlate(string p_sSessionId, string p_sNolaRoot, int p_iStartingEpisodeNumber, int p_iNumberOfPrograms)
		{
			try
			{
				ValidateEpisodeSlateClass oValidateEpisodeSlate = new ValidateEpisodeSlateClass();
				return oValidateEpisodeSlate.ValidateEpisodeSlate(p_sSessionId, p_sNolaRoot, p_iStartingEpisodeNumber, p_iNumberOfPrograms);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		#endregion


		#region Load Interfaces
		[WebMethod]
		public DataSet LoadBillTo()
		{
			try
			{
				LoadBillToClass oLoadBillToClass = new LoadBillToClass();
				return oLoadBillToClass.LoadBillTo();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadBillToContact()
		{
			try
			{
				LoadBillToContactClass oLoadBillToContactClass = new LoadBillToContactClass();
				return oLoadBillToContactClass.LoadBillToContact();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		
		
		[WebMethod]
		public DataSet LoadCaptionVendor()
		{
			try
			{
				LoadCaptionVendorClass oLoadCaptionVendor = new LoadCaptionVendorClass();
				return oLoadCaptionVendor.LoadCaptionVendor();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadCompany()
		{
			try
			{
				LoadCompanyClass oLoadCompany = new LoadCompanyClass();
				return oLoadCompany.LoadCompany();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadContactType()
		{
			try
			{
				LoadContactTypeClass oLoadContactType = new LoadContactTypeClass();
				return oLoadContactType.LoadContactType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadDisclaimer()
		{
			try
			{
				LoadDisclaimerClass oLoadDisclaimer = new LoadDisclaimerClass();
				return oLoadDisclaimer.LoadDisclaimer();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadDistributors()
		{
			try
			{
				LoadDistributorsClass oLoadDistributors = new LoadDistributorsClass();
				return oLoadDistributors.LoadDistributors();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadFunders()
		{
			try
			{
				LoadFundersClass oLoadFunders = new LoadFundersClass();
				return oLoadFunders.LoadFunders();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadFunderType()
		{
			try
			{
				LoadFunderTypeClass oLoadFunderType = new LoadFunderTypeClass();
				return oLoadFunderType.LoadFunderType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadGenre()
		{
			try
			{
				LoadGenreClass oLoadGenre = new LoadGenreClass();
				return oLoadGenre.LoadGenre();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadKeywords()
		{
			try
			{
				LoadKeywordsClass oLoadKeywords = new LoadKeywordsClass();
				return oLoadKeywords.LoadKeywords();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadLanguage()
		{
			try
			{
				LoadLanguageClass oLoadLanguage = new LoadLanguageClass();
				return oLoadLanguage.LoadLanguage();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadLocalUnderwriting()
		{
			try
			{
				LoadLocalUnderwritingClass oLoadLocalUnderwriting = new LoadLocalUnderwritingClass();
				return oLoadLocalUnderwriting.LoadLocalUnderwriting();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadPBSProgramType()
		{
			try
			{
				LoadPBSProgramTypeClass oLoadPBSProgramType = new LoadPBSProgramTypeClass();
				return oLoadPBSProgramType.LoadPBSProgramType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadPlayRule()
		{
			try
			{
				LoadPlayRuleClass oLoadPlayRule = new LoadPlayRuleClass();
				return oLoadPlayRule.LoadPlayRule();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadProgramType()
		{
			try
			{
				LoadProgramTypeClass oLoadProgramType = new LoadProgramTypeClass();
				return oLoadProgramType.LoadProgramType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadRating()
		{
			try
			{
				LoadRatingClass oLoadRating = new LoadRatingClass();
				return oLoadRating.LoadRating();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadSchoolRights()
		{
			try
			{
				LoadSchoolRightsClass oLoadSchoolRights = new LoadSchoolRightsClass();
				return oLoadSchoolRights.LoadSchoolRights();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadUplinks()
		{
			try
			{
				LoadUplinksClass oLoadUplinks = new LoadUplinksClass();
				return oLoadUplinks.LoadUplinks();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadVersionFormatAndType()
		{
			try
			{
				LoadVersionFormatAndTypeClass oLoadVersionFormatAndType = new LoadVersionFormatAndTypeClass();
				return oLoadVersionFormatAndType.LoadVersionFormatAndType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadAudioType()
		{
			try
			{
				LoadAudioTypeClass oLoadAudioType = new LoadAudioTypeClass();
				return oLoadAudioType.LoadAudioType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadTalentRoles()
		{
			try
			{
				LoadTalentRolesClass oLoadTalentRoles = new LoadTalentRolesClass();
				return oLoadTalentRoles.LoadTalentRoles();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadSurroundSoundType()
		{
			try
			{
				LoadSurroundSoundTypeClass oLoadSurroundSoundType = new LoadSurroundSoundTypeClass();
				return oLoadSurroundSoundType.LoadSurroundSoundType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadAspectRatioType()
		{
			try
			{
				LoadAspectRatioTypeClass oLoadAspectRatio = new LoadAspectRatioTypeClass();
				return oLoadAspectRatio.LoadAspectRatioType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadAssetCategory()
		{
			try
			{
				LoadAssetCategoryClass oLoadAssetCategory = new LoadAssetCategoryClass();
				return oLoadAssetCategory.LoadAssetCategory();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadHighDefType()
		{
			try
			{
				LoadHighDefTypeClass oLoadHighDefType = new LoadHighDefTypeClass();
				return oLoadHighDefType.LoadHighDefType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadVideoFormat()
		{
			try
			{
				LoadVideoFormatClass oLoadVideoFormat = new LoadVideoFormatClass();
				return oLoadVideoFormat.LoadVideoFormat();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadMediaFeatureClass()
		{
			try
			{
				LoadMediaFeatureClassClass oLoadMediaFeatureClass = new LoadMediaFeatureClassClass();
				return oLoadMediaFeatureClass.LoadMediaFeatureClass();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadCutItemType()
		{
			try
			{
				LoadCutItemTypeClass oLoadCutItemType = new LoadCutItemTypeClass();
				return oLoadCutItemType.LoadCutItemType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadMediaFormatType()
		{
			try
			{
				LoadMediaFormatTypeClass oLoadMediaFormatType = new LoadMediaFormatTypeClass();
				return oLoadMediaFormatType.LoadMediaFormatType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadMediaInventoryType()
		{
			try
			{
				LoadMediaInventoryTypeClass oLoadMediaInventoryType = new LoadMediaInventoryTypeClass();
				return oLoadMediaInventoryType.LoadMediaInventoryType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadMediaStatus()
		{
			try
			{
				LoadMediaStatusClass oLoadMediaStatus = new LoadMediaStatusClass();
				return oLoadMediaStatus.LoadMediaStatus();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadMediaFeature()
		{
			try
			{
				LoadMediaFeatureClass oLoadMediaFeature = new LoadMediaFeatureClass();
				return oLoadMediaFeature.LoadMediaFeature();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadPackageType()
		{
			try
			{
				LoadPackageTypeClass oLoadPackageType = new LoadPackageTypeClass();
				return oLoadPackageType.LoadPackageType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadOacPreOfferDescriptionType()
		{
			try
			{
				LoadOacPreOfferDescriptionTypeClass oLoadOacPreOfferDescriptionType = new LoadOacPreOfferDescriptionTypeClass();
				return oLoadOacPreOfferDescriptionType.LoadOacPreOfferDescriptionType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadOacPostOfferDescriptionType()
		{
			try
			{
				LoadOacPostOfferDescriptionTypeClass oLoadOacPostOfferDescriptionType = new LoadOacPostOfferDescriptionTypeClass();
				return oLoadOacPostOfferDescriptionType.LoadOacPostOfferDescriptionType();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadVChipValues()
		{
			try
			{
				LoadVCHIPValuesClass oLoadVCHIPValues = new LoadVCHIPValuesClass();
				return oLoadVCHIPValues.LoadVCHIPValues();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet LoadAlliantContractModels()
		{
			try
			{
				LoadAlliantContractModelsClass oLoadAlliantContractModels = new LoadAlliantContractModelsClass();
				return oLoadAlliantContractModels.LoadAlliantContractModels();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public DataSet LoadStations()
		{
			try
			{
				LoadStationsClass oLoadStations = new LoadStationsClass();
				return oLoadStations.LoadStations();
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		#endregion

		#region CreateInterfaces
		[WebMethod]
		public void CreateProgram(string strSessionID,int nMasterDealID,string strMasterDealTitle,string strSeason,int nDealID,string 

								strDealDesc,string strDealSynopsis,int nPBSProgramTypeID,int nUpLinkID,int[] nProgramIDs,int nProgramTypeID,int 

								nDuration,string strNolaRoot,int nFirstEpisodeNumber,int nIncrement,int nDistributorID,

								int nGenreID,bool bLive,bool bRecord,int nDefaultRatingID,int nDisclaimerID,string 

								strFirstPictureLockDate,int nOperatingUnit,string strOperatingGroup,Packages[] cPackages,int nAssetVChipID,string sAssetEpisodeTitle, 
								string sAssetTitleString, bool p_bIsFinalTitle, bool p_bSDRightsFlag, bool p_bHDRightsFlag)
		{
			try
			{
				CreateProgramClass oProgramCreate = new CreateProgramClass();
			    oProgramCreate.CreateProgram(strSessionID, nMasterDealID, strMasterDealTitle, strSeason, nDealID, 

								strDealDesc, strDealSynopsis, nPBSProgramTypeID, nUpLinkID, nProgramIDs, nProgramTypeID, 

								nDuration, strNolaRoot, nFirstEpisodeNumber, nIncrement, nDistributorID, 

								 nGenreID, bLive, bRecord, nDefaultRatingID, nDisclaimerID, 

								strFirstPictureLockDate, nOperatingUnit, strOperatingGroup, cPackages,nAssetVChipID,sAssetEpisodeTitle,
								sAssetTitleString, p_bIsFinalTitle, p_bSDRightsFlag, p_bHDRightsFlag);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region ListInterfaces
		[WebMethod]
		public DataSet ListProgramByDeal(string strSessionID, int nDealID)
		{
			try
			{
				ListProgramsByDealClass oListProgramsByDeal = new ListProgramsByDealClass();
				return oListProgramsByDeal.ListProgramsByDeal(strSessionID, nDealID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet ListProgramPackagesByProgram(string strSessionID, int nProgramID)
		{
			try
			{
				ListProgramPackagesByProgramClass oListProgramPackagesByProgram = new ListProgramPackagesByProgramClass();
				return oListProgramPackagesByProgram.ListProgramPackagesByProgram(strSessionID, nProgramID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet ListDealsByMasterDeal(string strSessionID, int nDealID)
		{
			try
			{
				ListDealsByMasterDealClass oListDealsByMasterDealClass = new ListDealsByMasterDealClass();
				return oListDealsByMasterDealClass.ListDealsByMasterDeal(strSessionID, nDealID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region GetProgramInterfaces

		[WebMethod]
		public DataSet GetProgramDetails(string strSessionID, int nProgramID, bool bLockFlag, bool bGetPremiereDate,out string strLockID)
		{
			try
			{
				GetProgramDetailsClass oGetProgramDetails = new GetProgramDetailsClass();
				return oGetProgramDetails.GetProgramDetails(strSessionID, nProgramID, bLockFlag,bGetPremiereDate, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutProgramDetails(string strSessionID,int nProgramID, string strLockID, DataSet dsDeal)
		{
			try
			{
				PutProgramDetailsClass oPutProgramDetails = new PutProgramDetailsClass();
				oPutProgramDetails.PutProgramDetails(strSessionID, nProgramID,strLockID, dsDeal);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region TalentInterfaces

		[WebMethod]
		public void GetTalent(string strSessionID, int nDealID, int nTalentID, int nRoleID, out DataSet dEpisodeAppTo, out DataSet dEpisodeTalent, out DataSet dTalent)
		{
			try
			{
				GetTalentClass oGetTalent = new GetTalentClass();
			    oGetTalent.GetTalent(strSessionID, nDealID, nTalentID, nRoleID,out  dEpisodeAppTo, out  dEpisodeTalent, out  dTalent);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutTalent(string strSessionID,DataSet dEpisodeTalent,DataSet dTalent)
		{
			try
			{
				PutTalentClass oPutTalent = new PutTalentClass();
				oPutTalent.PutTalent(strSessionID, dEpisodeTalent,dTalent);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet TalentSearch(string strSessionID,string sTalentName)
		{
			try
			{
				TalentSearchClass oTalent = new TalentSearchClass();
				return oTalent.TalentSearch(strSessionID, sTalentName);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region FormatSheet
		[WebMethod]
		public DataSet GetFormatSheet(string strSessionID, int nFormatSheetID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetFormatSheetClass oGetFormatSheet = new GetFormatSheetClass();
				return oGetFormatSheet.GetFormatSheet(strSessionID, nFormatSheetID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutFormatSheet(string strSessionID,string strLockID, DataSet dsFormatSheet)
		{
			try
			{
				PutFormatSheetClass oPutFormatSheet = new PutFormatSheetClass();
				oPutFormatSheet.PutFormatSheet(strSessionID,strLockID, dsFormatSheet);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public void DeleteFormatSheet(string strSessionID,int nTabId,string strLockId)
		{
			try
			{
				
				
				DeleteFormatSheetClass oDeleteFormatSheet = new DeleteFormatSheetClass();
				oDeleteFormatSheet.DeleteFormatSheet(strSessionID, nTabId,strLockId);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region MusicCue
		[WebMethod]
		public DataSet GetMusicCue(string strSessionID, int nMusicCueID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetMusicCueClass oGetMusicCue = new GetMusicCueClass();
				return oGetMusicCue.GetMusicCue(strSessionID, nMusicCueID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutMusicCue(string strSessionID,string strLockID, DataSet dsMusicCue)
		{
			try
			{
				PutMusicCueClass oPutMusicCue = new PutMusicCueClass();
				oPutMusicCue.PutMusicCue(strSessionID,strLockID, dsMusicCue);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public void DeleteMusicCue(string strSessionID,int nTabId,string strLockId)
		{
			try
			{
				
				
				DeleteMusicCueClass oDeleteMusicCue = new DeleteMusicCueClass();
				oDeleteMusicCue.DeleteMusicCue(strSessionID, nTabId,strLockId);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region VisualArt
		[WebMethod]
		public DataSet GetVisualArt(string strSessionID, int nVisualArtID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetVisualArtClass oGetVisualArt = new GetVisualArtClass();
				return oGetVisualArt.GetVisualArt(strSessionID, nVisualArtID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutVisualArt(string strSessionID,string strLockID, DataSet dsVisualArt)
		{
			try
			{
				PutVisualArtClass oPutVisualArt = new PutVisualArtClass();
				oPutVisualArt.PutVisualArt(strSessionID,strLockID, dsVisualArt);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void DeleteVisualArt(string strSessionID,int nTabId,string strLockId)
		{
			try
			{
				
				
				DeleteVisualArtClass oDeleteVisualArt = new DeleteVisualArtClass();
				oDeleteVisualArt.DeleteVisualArt(strSessionID, nTabId,strLockId);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region OAC
		[WebMethod]
		public DataSet GetOAC(string strSessionID, int nOACID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetOACClass oGetOAC = new GetOACClass();
				return oGetOAC.GetOAC(strSessionID, nOACID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutOAC(string strSessionID,string strLockID, DataSet dsOAC)
		{
			try
			{
				PutOACClass oPutOAC = new PutOACClass();
				oPutOAC.PutOAC(strSessionID,strLockID, dsOAC);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public void DeleteOAC(string strSessionID,int nTabId,string strLockId)
		{
			try
			{
				
				
				DeleteOACClass oDeleteOAC = new DeleteOACClass();
				oDeleteOAC.DeleteOAC(strSessionID, nTabId,strLockId);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region IWT
		[WebMethod]
		public DataSet GetIWT(string strSessionID, int nIWTID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetIWTClass oGetIWT = new GetIWTClass();
				return oGetIWT.GetIWT(strSessionID, nIWTID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutIWT(string strSessionID,string strLockID, DataSet dsIWT)
		{
			try
			{
				PutIWTClass oPutIWT = new PutIWTClass();
				oPutIWT.PutIWT(strSessionID,strLockID, dsIWT);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public void DeleteIWT(string strSessionID,int nTabId,string strLockId)
		{
			try
			{
				
				
				DeleteIWTClass oDeleteIWT = new DeleteIWTClass();
				oDeleteIWT.DeleteIWT(strSessionID, nTabId,strLockId);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region UCC
		[WebMethod]
		public DataSet GetUCC(string strSessionID, int nUCCID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetUCCClass oGetUCC = new GetUCCClass();
				return oGetUCC.GetUCC(strSessionID, nUCCID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutUCC(string strSessionID,string strLockID, DataSet dsUCC)
		{
			try
			{
				PutUCCClass oPutUCC = new PutUCCClass();
				oPutUCC.PutUCC(strSessionID,strLockID, dsUCC);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public void DeleteUCC(string strSessionID,int nTabId,string strLockId)
		{
			try
			{
				
				
				DeleteUCCClass oDeleteUCC = new DeleteUCCClass();
				oDeleteUCC.DeleteUCC(strSessionID, nTabId,strLockId);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion

		#region AdCopy

		[WebMethod]
		public DataSet GetAdCopy(string strSessionID, int nAdCopyId, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetAdCopyClass oGetAdCopy = new GetAdCopyClass();
				return oGetAdCopy.GetAdCopy(strSessionID, nAdCopyId, bLockFlag,out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

        [WebMethod(MessageName = "PutAdCopy_Deprecated")]
        [Obsolete("This method is implemented incorrectly, use the other overload.",false)]
		public void PutAdCopy(string strSessionID,int nAdCopyId, string strLockID, DataSet dsAdCopy)
		{

			try
			{
                PutAdCopy(strSessionID, strLockID, dsAdCopy); 
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

        [WebMethod]
        public void PutAdCopy(string strSessionID, string strLockID, DataSet dsAdCopy)
        {
            try
            {
                PutAdCopyClass oPutAdCopy = new PutAdCopyClass();
                oPutAdCopy.PutAdCopy(strSessionID, strLockID, dsAdCopy);
            }
            catch (Exception ex)
            {
                LogException(ex);
                ExceptionHandler.ThrowSoapException(ex);
                throw;
            }
        }


		#endregion

		#region GetPackage
		[WebMethod]
		public DataSet GetPackage(string strSessionID, int nPackageID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetPackageClass oGetPackage = new GetPackageClass();
				return oGetPackage.GetPackage(strSessionID, nPackageID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}


		#endregion
		#region Media Inventory
		[WebMethod]
		public DataSet GetFeatureMediaInventory(string strSessionID, int nFeatureMediaInventoryID, bool bLockFlag, out string strLockID)
		{
			try
			{
				
				GetFeatureMediaInventoryClass oGetFeatureMediaInventoryClass = new GetFeatureMediaInventoryClass();
				return oGetFeatureMediaInventoryClass.GetFeatureMediaInventory(strSessionID, nFeatureMediaInventoryID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutFeatureMediaInventory(string strSessionID,string strLockID,  DataSet dsFeatureMediaInventory)
		{
			try
			{
				PutFeatureMediaInventoryClass oPutFeatureMediaInventoryClass = new PutFeatureMediaInventoryClass();
				oPutFeatureMediaInventoryClass.PutFeatureMediaInventory(strSessionID, strLockID, dsFeatureMediaInventory);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet GetMediaInventoryRevision(string strSessionID, int nMediaInventoryRevisionID, bool bLockFlag, out string strLockID)
		{
			try
			{
				GetMediaInventoryRevisionClass oGetMediaInventoryRevisionClass = new GetMediaInventoryRevisionClass();
				return oGetMediaInventoryRevisionClass.GetMediaInventoryRevision(strSessionID, nMediaInventoryRevisionID, bLockFlag, out strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutMediaInventoryRevision(string strSessionID,string strLockID, DataSet dsMediaInventoryRevision)
		{
			try
			{
				PutMediaInventoryRevisionClass oPutMediaInventoryRevisionClass = new PutMediaInventoryRevisionClass();
				oPutMediaInventoryRevisionClass.PutMediaInventoryRevision(strSessionID, strLockID, dsMediaInventoryRevision);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region Manageappliedto range methods
		[WebMethod]
		public DataSet GetAssetAppliesToRangeByTab(string strSessionID, int nTabID,string strTabType)
		{
			try
			{
				GetAssetAppliesToRangeByTabClass oGetAssetAppliesToRangeByTab = new GetAssetAppliesToRangeByTabClass();
				return oGetAssetAppliesToRangeByTab.GetAssetAppliesToRangeByTab(strSessionID, nTabID,strTabType);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutAssetAppliesToRangeByTab(string strSessionID, DataSet dsAssetAppliesTo)
		{
			try
			{
				PutAssetAppliesToRangeByTabClass oPutAssetAppliesToRangeByTab = new PutAssetAppliesToRangeByTabClass();
				oPutAssetAppliesToRangeByTab.PutAssetAppliesToRangeByTab(strSessionID, dsAssetAppliesTo);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet GetPackageAppliesToRangeByTab(string strSessionID, int nTabID,string strTabType)
		{
			try
			{
				GetPackageAppliesToRangeByTabClass oGetPackageAppliesToRangeByTab = new GetPackageAppliesToRangeByTabClass();
				return oGetPackageAppliesToRangeByTab.GetPackageAppliesToRangeByTab(strSessionID, nTabID,strTabType);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void PutPackageAppliesToRangeByTab(string strSessionID, DataSet dsPackageAppliesTo)
		{
			try
			{
				PutPackageAppliesToRangeByTabClass oPutPackageAppliesToRangeByTab = new PutPackageAppliesToRangeByTabClass();
				oPutPackageAppliesToRangeByTab.PutPackageAppliesToRangeByTab(strSessionID, dsPackageAppliesTo);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet  ListTabMapByDeal(string strSessionID,int nDealId)
		{
			try
			{
				ListTabMapByDealClass oListTabMapByDeal = new ListTabMapByDealClass();
				return oListTabMapByDeal.ListTabMapByDeal(strSessionID,nDealId);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region deadline methods

		[WebMethod]
		public DataSet ListPAADeadline(string strSessionID, int nDealStatus)
		{
			try
			{
				ListPAADeadlineClass oListPAADeadlineClass = new ListPAADeadlineClass();
				return oListPAADeadlineClass.ListPAADeadline(strSessionID, nDealStatus);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet ListFormDeadline(string strSessionID, int nDealStatus)
		{
			try
			{
				ListFormDeadlineClass oListFormDeadlineClass = new ListFormDeadlineClass();
				return oListFormDeadlineClass.ListFormDeadline(strSessionID, nDealStatus);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet ListMissingEpisodeFormDeadline(string strSessionID)
		{
			try
			{
				ListMissingEpisodeFormDeadlineClass oListMissingEpisodeFormDeadlineClass = new ListMissingEpisodeFormDeadlineClass();
				return oListMissingEpisodeFormDeadlineClass.ListMissingEpisodeFormDeadline(strSessionID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public DataSet ListMissingVersionFormDeadline(string strSessionID)
		{
			try
			{
				ListMissingVersionFormDeadlineClass oListMissingVersionFormDeadlineClass = new ListMissingVersionFormDeadlineClass();
				return oListMissingVersionFormDeadlineClass.ListMissingVersionFormDeadline(strSessionID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region RemedyMethods
		
		[WebMethod]
		public void GetDiscrepancyProgram(string sChannel,string sDicrepancyStartDate,
			out string sPackageID,out string sPackagenumber,
			out string sPackageTile,out string sProgramTile,
			out string sSeriesTile,out string sProgramEpisodeTitle,
			out DateTime dSchedDateTime,out int nSchedDuration)
		
		{
					
			try
			{
				//Generate YYYY-MM-DD HH:MM:SS
				DateTime dDicrepancyStartDate = Convert.ToDateTime(sDicrepancyStartDate);
//				string sDay =dDicrepancyStartDate.Day.ToString(); 
//				string sMon =dDicrepancyStartDate.Month.ToString(); 
//				string sYear =dDicrepancyStartDate.Year.ToString(); 
//				if(sDay.Length==1)
//				{
//					sDay = "0"+sDay;
//				}
				
//				string sDate = sYear+"-"+sMon+"-"+sDay+ " "+dDicrepancyStartDate.ToShortTimeString();
				string sDate = dDicrepancyStartDate.ToString("yyyy-MM-dd HH:mm:ss");
				
				GetDiscrepancyProgramClass oGetDiscrepancyProgramClass = new GetDiscrepancyProgramClass();
				oGetDiscrepancyProgramClass.GetDiscrepancyProgram(sChannel,sDate,
																out  sPackageID,out  sPackagenumber,
																out  sPackageTile,out  sProgramTile,
																out  sSeriesTile,out  sProgramEpisodeTitle,
																out  dSchedDateTime,out  nSchedDuration);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		[WebMethod]
		public void ReleaseLock(string strSessionID, string strLockID)
		{
			try
			{
				ReleaseLockClass oReleaseLock = new ReleaseLockClass();
				oReleaseLock.ReleaseLock(strSessionID, strLockID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public int[] GetIDs(int nHowMany)
		{
			try
			{
				GetIDsClass oGetIDs = new GetIDsClass();
				return oGetIDs.GetIDs(nHowMany);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public string OpenSession(
			[XmlElementAttribute(IsNullable=false)] UserProfile userProfile)
		{
			try
			{
				// Login to the BroadView server and get a session id
				BVSession oSession = new BVSession();
				string strSessionID = oSession.Login(userProfile);

				// Return this to be cached by caller
				return strSessionID;
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[WebMethod]
		public void CloseSession(string strSessionID)
		{
			try
			{
				// Log this session out of BroadView server
				BVSession oSession = new BVSession();
				oSession.Logout(strSessionID);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[WebMethod]
		public void DebugTimeOut(string strSessionID,int nTimeDelay)
			
		{
			try
			{
				DebugTimeOutClass oDebug  = new DebugTimeOutClass();
				oDebug.DebugTimeOut(strSessionID,nTimeDelay);

				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		//
		// Use these methods for testing...
		//
//		[WebMethod]
		public string ConvertToXml(DataSet dsDeal, string strXsltFile)
		{
			try
			{
				TestConverterClass oTestConverter = new TestConverterClass();
				return oTestConverter.ToXml(dsDeal, strXsltFile);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

//		[WebMethod]
		public DataSet ConvertToDataSet(string xmlString, string strXsltFile)
		{
			try
			{
				TestConverterClass oTestConverter = new TestConverterClass();
				return oTestConverter.ToDataSet(xmlString, strXsltFile);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
	}
}

