using System;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

using TVSServer = OrionProxy;


namespace BVWebService
{
	/// <summary>
	/// Summary description for Session.
	/// </summary>
	public class BVSession
	{

        private const string USER_PROFILE_CONFIG_FILE = "UserProfile.config";
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

			//
			// Login to the BroadView system using their authorization object
			//
			TVSServer.rdmPBSAuthorization oPBSAuthorization;
			oPBSAuthorization = ComponentFactory.CreateAuthorizationClass();

			int nErrorCode = 0;
			string strErrorText = "";
			string strSessionID = "";
			nErrorCode = oPBSAuthorization.Login(strUserProfile, out strSessionID, out strErrorText);

			if (nErrorCode == 0)
			{
				return strSessionID;
			}
			else
			{
				throw new Exception(strErrorText);
			}
		}

		public string Login()
		{

            UserProfile userProfile = new UserProfile();

			// Use a default profile 
			if (!File.Exists(USER_PROFILE_CONFIG_FILE))
            {
			    userProfile.sConnectId = "RSYED";
			    userProfile.oOperatingGroup = new string[] { "Administrators", "Users" };
			    userProfile.nUnitType = 1;
			    userProfile.nRole=1;
			    userProfile.nOperatingUnit=369;
                //userProfile.sExternalEmail = "faithfulc@avanade.com";
                //userProfile.sFirstName = "Rahiq";
                //userProfile.sLastName = "Syed";
            }
            else
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(typeof(BVWebService.UserProfile));
                using (StreamReader oReader = new StreamReader(USER_PROFILE_CONFIG_FILE))
                {
                    userProfile = (UserProfile)oXmlSerializer.Deserialize(oReader);
                }
            }
            
            return Login(userProfile);

		}

		public void Logout(string strSessionID)
		{
			//
			// Logout of the BroadView system using their authorization object
			//
            TVSServer.rdmPBSAuthorization oPBSAuthorization;
			oPBSAuthorization = ComponentFactory.CreateAuthorizationClass();

			int nErrorCode = 0;
			string strErrorText = "";
			nErrorCode = oPBSAuthorization.Logout(strSessionID, out strErrorText);
		}
	}
}
