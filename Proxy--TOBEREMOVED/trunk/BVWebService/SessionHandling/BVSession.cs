using System;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;
using Pbs.WebServices.Utility;

using TVSServer = OrionProxy;

namespace BVWebService
{
	/// <summary>
	/// Summary description for Session.
	/// </summary>
	public class BVSession
	{
		public BVSession()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string Login(UserProfile userProfile)
		{
			//
			// Create a serialization object and serialize given userProfile to string
			//
			string strUserProfile;

			XmlSerializer oXmlSerializer = new XmlSerializer(typeof(UserProfile));
			using (StringWriter oStringWriter = new StringWriter())
			{
				oXmlSerializer.Serialize((TextWriter) oStringWriter, userProfile);
				oStringWriter.Flush();
				strUserProfile = oStringWriter.ToString();
			}

			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering BVSession.Login.\n" + "UserProfile = " + strUserProfile);


			//
			// Login to the BroadView system using their authorization object
			//
			TVSServer.rdmPBSAuthorization oPBSAuthorization;

			try
			{
				oPBSAuthorization = ComponentFactory.CreateAuthorizationClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= PBSAuthorization.PBSAuthorization",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			string strSessionID = "";
			try
			{
				nErrorCode = oPBSAuthorization.Login(strUserProfile, out strSessionID, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"strUserProfile= " + strUserProfile,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving BVSession.Login.\n" + "strSessionID = " + strSessionID);
				return strSessionID;
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText,
					"strUserProfile= " + strUserProfile
					);
			}
		}

		public void Logout(string strSessionID)
		{
			Tracer oTracer = new Tracer(); 
			oTracer.LogInfo("Entering BVSession.Logout.\n strSessionID = " + strSessionID);

			//
			// Logout of the BroadView system using their authorization object
			//
			TVSServer.rdmPBSAuthorization oPBSAuthorization;

			try
			{
				oPBSAuthorization = ComponentFactory.CreateAuthorizationClass();
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= PBSAuthorization.PBSAuthorization",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			try
			{
				nErrorCode = oPBSAuthorization.Logout(strSessionID, out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"strSessionID= " + strSessionID,
					ex);
			}

			if (nErrorCode == 0)
			{
				oTracer.LogInfo("Leaving BVSession.Logout.\n" + "strSessionID = " + strSessionID);
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText,
					"strSessionID= " + strSessionID
					);
			}
		}
	}
}
