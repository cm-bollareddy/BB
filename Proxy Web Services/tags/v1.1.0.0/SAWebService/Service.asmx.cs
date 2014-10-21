using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using Pbs.WebServices.Utility;
using System.Xml;
using System.Xml.Serialization;

namespace SAWebService
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	/// 
	[WebService(
		 Namespace="http://webservices.pbstest.org/SAWebService",
		 Name="SAWebService",
		 Description="Web Service for PBS-BroadView-ScheduALL integration")]
	public class SAWebService : System.Web.Services.WebService
	{
		public SAWebService()
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

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5
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
		/// <summary>
		/// Closes the BV Session
		/// </summary>
		/// <param name="strSessionID">Session ID</param>
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
		/// <summary>
		/// Open Session : Opens a new Broad View Session
		/// </summary>
		/// <param name="userProfile">User Profile</param>
		/// <returns>Session ID</returns>
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

		
		
		#region with session
		[System.Web.Services.WebMethod(MessageName="ListMediaCutsInfoSession")]
		public DataSet ListMediaCutsInfo(string strSessionID,SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
                ListMediaCutsInfoClass oListMediaInfo = new ListMediaCutsInfoClass();
				return oListMediaInfo.ListMediaCutsInfo(strSessionID,searchCriteria,nMaxRow);
				
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}



		[System.Web.Services.WebMethod(MessageName="GetDetailedAirDateSession")]
		public DataSet GetDetailedAirDate(string strSessionID, int nMediaInventoryId)
		{
			try
			{
				DetailedAirDateClass oDetailedAirDate = new DetailedAirDateClass();
				return oDetailedAirDate.GetDetailedAirDate(strSessionID, nMediaInventoryId);				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}



		
		
		[System.Web.Services.WebMethod(MessageName="ListPackageCutsInfoSession")]
		public DataSet ListPackageCutsInfo(string strSessionID,SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
                ListPackageCutsInfoClass oListPackageCutsInfoClass = new ListPackageCutsInfoClass();
                return oListPackageCutsInfoClass.ListPackageCutsInfo(strSessionID, searchCriteria, nMaxRow);
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[System.Web.Services.WebMethod(MessageName="ListPackageMediaInfoSession")]
		public DataSet ListPackageMediaInfo(string strSessionID,SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
				ListPackageMediaInfoClass oListPackageMediaInfo   = new ListPackageMediaInfoClass();
				return oListPackageMediaInfo.ListPackageMediaInfo(strSessionID,searchCriteria,nMaxRow);
				 
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[System.Web.Services.WebMethod(MessageName="SearchMediaAirDateSession")]
		public string SearchMediaAirDate(string strSessionID, string strMediaHouseNumber,int nTune_value)
		{
			try
			{
				MediaAirDateClass oMediaAirDate  = new MediaAirDateClass();
				return oMediaAirDate.MediaAirDate(strSessionID,strMediaHouseNumber,nTune_value);
				 
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[System.Web.Services.WebMethod(MessageName="SearchPackageAirDateSession")]
		public string SearchPackageAirDate(string strSessionID, string strPackageNumber,int nTune_value)
		{
			try
			{
				PackageAirDateClass oPackageAirDate  = new PackageAirDateClass();
				return oPackageAirDate.PackageAirDate(strSessionID,strPackageNumber,nTune_value);
				 
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[System.Web.Services.WebMethod(MessageName="SearchMediaInfoSession")]
		public DataSet SearchMediaInfo(string strSessionID,SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
				MediaInfoSearchClass oMediaSearch =  new MediaInfoSearchClass();
				return oMediaSearch.MediaInfoSearch(strSessionID,searchCriteria,nMaxRow);

				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[System.Web.Services.WebMethod(MessageName="SearchPackageInfoSession")]
		public DataSet SearchPackageInfo(string strSessionID,SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
				
				PackageInfoSearchClass oPackageSearch =  new PackageInfoSearchClass();


				return oPackageSearch.PackageInfoSearch(strSessionID,searchCriteria,nMaxRow);
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		#region withoutsession
		[System.Web.Services.WebMethod(MessageName="ListMediaCutsInfo")]
		public DataSet ListMediaCutsInfo(SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
                ListMediaCutsInfoClass oListMediaInfo = new ListMediaCutsInfoClass();
				//open
				string strSessionID  = GetSessionFromBV();
				//get data
				DataSet odateSet  =oListMediaInfo.ListMediaCutsInfo(strSessionID,searchCriteria,nMaxRow);
				//close
				CloseSessionFromBV(strSessionID);
				return odateSet;
				 
				
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[System.Web.Services.WebMethod(MessageName="GetDetailedAirDate")]
		public DataSet GetDetailedAirDate(int nMediaInventoryId)
		{
			try
			{
				DetailedAirDateClass oDetailedAirDate = new DetailedAirDateClass();

				//open
				string strSessionID  = GetSessionFromBV();
				//get data
				DataSet oDataSet =oDetailedAirDate.GetDetailedAirDate(strSessionID,nMediaInventoryId);
				//close
				CloseSessionFromBV(strSessionID);
				return oDataSet;
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}



			[System.Web.Services.WebMethod(MessageName="ListPackageCutsInfo")]
		public DataSet ListPackageCutsInfo(SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
                ListPackageCutsInfoClass oListPackageCutsInfoClass = new ListPackageCutsInfoClass();
				//open
				string strSessionID  = GetSessionFromBV();
				//get data
                DataSet odateSet = oListPackageCutsInfoClass.ListPackageCutsInfo(strSessionID, searchCriteria, nMaxRow);
				//close
				CloseSessionFromBV(strSessionID);

				return odateSet;
			
				
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[System.Web.Services.WebMethod(MessageName="ListPackageMediaInfo")]
		public DataSet ListPackageMediaInfo(SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
				ListPackageMediaInfoClass oListPackageMediaInfo   = new ListPackageMediaInfoClass();
				//open
				string strSessionID  = GetSessionFromBV();
				//get data
				DataSet odateSet  =oListPackageMediaInfo.ListPackageMediaInfo(strSessionID,searchCriteria,nMaxRow);
				//close
				CloseSessionFromBV(strSessionID);
				return odateSet;
				
				 
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[System.Web.Services.WebMethod(MessageName="SearchMediaAirDate")]
		public string SearchMediaAirDate(string strMediaHouseNumber,int nTune_value)
		{
			try
			{
				MediaAirDateClass oMediaAirDate  = new MediaAirDateClass();
				//open
				string strSessionID  = GetSessionFromBV();
				//get data
				string sDate  =oMediaAirDate.MediaAirDate(strSessionID,strMediaHouseNumber,nTune_value);
				//close
				CloseSessionFromBV(strSessionID);
				return sDate;
				
				 
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		[System.Web.Services.WebMethod(MessageName="SearchPackageAirDate")]
		public string SearchPackageAirDate(string strPackageNumber,int nTune_value)
		{
			try
			{
				PackageAirDateClass oPackageAirDate  = new PackageAirDateClass();
				//open
				string strSessionID  = GetSessionFromBV();
				//get data
				string sDate  =oPackageAirDate.PackageAirDate(strSessionID,strPackageNumber,nTune_value);
				//close
				CloseSessionFromBV(strSessionID);
				return sDate;
				
				 
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		[System.Web.Services.WebMethod(MessageName="SearchFeatureAirDate")]
		public string SearchFeatureAirDate(int intFeatureMediaInventoryID,int nTune_value)
		{
			try
			{
				FeatureAirDateClass oFeatureAirDate  = new FeatureAirDateClass();
				//open
				string strSessionID  = GetSessionFromBV();
				//get data
				string sDate  =oFeatureAirDate.FeatureAirDate(strSessionID,intFeatureMediaInventoryID,nTune_value);
				//close
				CloseSessionFromBV(strSessionID);
				return sDate;
				
				 
				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

	
		[System.Web.Services.WebMethod(MessageName="SearchMediaInfo")]
		public DataSet SearchMediaInfo(SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
				MediaInfoSearchClass oMediaSearch =  new MediaInfoSearchClass();
				//open
				string strSessionID  = GetSessionFromBV();
				//get data
				DataSet odateSet  =oMediaSearch.MediaInfoSearch(strSessionID,searchCriteria,nMaxRow);
				//close
				CloseSessionFromBV(strSessionID);
				return odateSet;
				 

				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}

		
		[System.Web.Services.WebMethod(MessageName="SearchPackageInfo")]
		public DataSet SearchPackageInfo(SearchCriterion[] searchCriteria,int nMaxRow)
		{
			try
			{
				
				
				
				PackageInfoSearchClass oPackageSearch =  new PackageInfoSearchClass();
				//open
				string strSessionID  = GetSessionFromBV();
				//get data
				DataSet odateSet  =oPackageSearch.PackageInfoSearch(strSessionID,searchCriteria,nMaxRow);
				//close
				CloseSessionFromBV(strSessionID);
				return odateSet;

				
			}
			catch(Exception ex)
			{
				LogException(ex);
				ExceptionHandler.ThrowSoapException(ex);
				throw;
			}
		}
		#endregion
		private string GetSessionFromBV()
		{
			
			try
			{
				BVSession oSession = new BVSession();
				UserProfile userProfile = new UserProfile();
				userProfile.sConnectId = "ScheduAll";
				userProfile.oOperatingGroup =new string[] { "Administrators", "Users" };
				userProfile.nUnitType = 369;
				userProfile.sExternalEmail = "";
				string strSessionID = oSession.Login(userProfile);

				// Return this to be cached by caller
				return strSessionID;

			}
			catch(Exception es)
			{
				throw es;

			}

			

		}

		private void CloseSessionFromBV(string strSessionID)
		{
			
			try
			{
				//init session object				
				BVSession oSession = new BVSession();
				//log out

				oSession.Logout(strSessionID);

			}
			catch(Exception es)
			{
				throw es;

			}

			

		}
	}
}
