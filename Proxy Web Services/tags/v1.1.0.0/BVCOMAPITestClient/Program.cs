using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TVSServer = OrionProxy;
using Pbs.WebServices.Utility;
using System.Reflection;

namespace BVCOMAPITestClient
{

    class Program
    {
        private static string API_TARGET_HOST = System.Configuration.ConfigurationManager.AppSettings["TVSServer"];
        private static string DEAL_ID = System.Configuration.ConfigurationManager.AppSettings["DealId"];
        private static string IMPERSONATION_DOMAIN = System.Configuration.ConfigurationManager.AppSettings["ImpersonationDomain"];
        private static string IMPERSONATION_USER = System.Configuration.ConfigurationManager.AppSettings["ImpersonationUser"];
        private static string IMPERSONATION_PASSWORD = System.Configuration.ConfigurationManager.AppSettings["ImpersonationPassword"];
        private static string IMPERSONATION_ENABLED = System.Configuration.ConfigurationManager.AppSettings["ImpersonationEnabled"];


        static void Main(string[] args)
        {

            ListClasses();
                        

            Tracer oTracer = new Tracer();
            
            try
            {
                if (bool.Parse(IMPERSONATION_ENABLED))
                {
                    Impersonate();
                }
                else
                {
                    CallProxyInterfaces();
                }


            }
            catch (Exception oEx)
            {
                oTracer.LogInfo("Exception:  " + oEx.ToString());
            }

        }

        static void CallProxyInterfaces()
        {
             //int iId = 251881492;
             DoLoadRating();
             DoDealAPIs(int.Parse(DEAL_ID));
             DoFeatureMediaInventory(43648730);
             //SearchFeatureAirDate(251881492, 356);
             //DoMediaInventoryRevision(int p_iMediaInventoryRevisionId);
        }


        static void Impersonate()
        {

            ImpersonationHelper oHelper = new ImpersonationHelper();

            if (oHelper.impersonateValidUser(IMPERSONATION_USER, IMPERSONATION_DOMAIN, IMPERSONATION_PASSWORD))
            {
                CallProxyInterfaces();
                oHelper.undoImpersonation();
            }
            else
            {
                throw new Exception("Error:  Impersonation Failed for " + IMPERSONATION_USER);
            }

        }


        static string Login()
        {
            string sUserProfileXML = @"<?xml version=""1.0"" encoding=""utf-16""?>
     <UserProfile xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
<sConnectId>brboggio</sConnectId>
<sFirstName>bryan</sFirstName>
<sLastName>boggio</sLastName>
<oOperatingGroup>
  <sCode>Administrators</sCode>
  <sCode>Users</sCode>
</oOperatingGroup>
<nOperatingUnit>369</nOperatingUnit>
<nUnitType>1</nUnitType>
<nRole>1</nRole>
<sExternalEmail>brboggio@pbs.org</sExternalEmail>
<sPhoneNumber /></UserProfile>";

            Tracer oTracer = new Tracer();
            

            string sSessionId;
            string sErrorText;
            int iLoginResult;
            try
            {
                Type oPBSAuthorizationType = Type.GetTypeFromCLSID(typeof(TVSServer.rdmPBSAuthorization).GUID, API_TARGET_HOST, true);
                TVSServer.rdmPBSAuthorization oPBSAuthorization = (TVSServer.rdmPBSAuthorization)Activator.CreateInstance(oPBSAuthorizationType);

                oTracer.LogInfo("Account:  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                oTracer.LogInfo("Host:  " + API_TARGET_HOST);
                oTracer.LogInfo("Before Call - Login");
                iLoginResult = oPBSAuthorization.Login(sUserProfileXML, out sSessionId, out sErrorText);
                oTracer.LogInfo("After Call - Login");

                oTracer.LogInfo("Method Result = " + iLoginResult.ToString());
                oTracer.LogInfo("sSessionId = " + sSessionId);
                oTracer.LogInfo("sErrorText = " + sErrorText);

            }
            catch (Exception oEx)
            {

                oTracer.LogInfo("Error:  " + oEx.ToString());
                throw;
            }

            if (iLoginResult == 0)
            {
                return sSessionId;
            }
            else
            {
                throw new Exception("Error:  " + sErrorText);

            }
        }

        static void Logout(string p_sSessionId)
        {
            Tracer oTracer = new Tracer();
            string sErrorText;

            try
            {
                Type oPBSAuthorizationType = Type.GetTypeFromCLSID(typeof(TVSServer.rdmPBSAuthorization).GUID, API_TARGET_HOST, true);
                TVSServer.rdmPBSAuthorization oPBSAuthorization = (TVSServer.rdmPBSAuthorization)Activator.CreateInstance(oPBSAuthorizationType);

                oTracer.LogInfo("Account:  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                oTracer.LogInfo("Host:  " + API_TARGET_HOST);
                oTracer.LogInfo("Before Call - Logout");
                int iResult = oPBSAuthorization.Logout(p_sSessionId, out sErrorText);
                oTracer.LogInfo("After Call - Logout");

                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("sErrorText = " + sErrorText);

            }
            catch (Exception oEx)
            {

                oTracer.LogInfo("Error:  " + oEx.ToString());
                throw;
            }
        }

        static void DoLoadRating()
        {
            Tracer oTracer = new Tracer();
            try
            {


                Type ordmPBSGetLookupType = Type.GetTypeFromCLSID(typeof(TVSServer.rdmPBSGetLookup).GUID, API_TARGET_HOST, true);
                TVSServer.rdmPBSGetLookup oPBSGetLookupClass = (TVSServer.rdmPBSGetLookup)Activator.CreateInstance(ordmPBSGetLookupType);

                string sXMLResult;
                string sErrorText;

                oTracer.LogInfo("Account:  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                oTracer.LogInfo("Host:  " + API_TARGET_HOST);
                oTracer.LogInfo("Before Call - LoadRating");
                int iResult = oPBSGetLookupClass.LoadRating(out sXMLResult, out sErrorText);
                oTracer.LogInfo("After Call - LoadRating");

                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("sXMLResult = " + sXMLResult);
                oTracer.LogInfo("sErrorText = " + sErrorText);

            }
            catch (Exception oException)
            {
                oTracer.LogInfo("Error: " + oException.ToString());
                throw;
            }
            finally
            {

            }
        }

        static void DoDealAPIs(int p_iDealId)
        {
            string sSessionId = string.Empty;
            Tracer oTracer = new Tracer();
            try
            {

                Type ordmPBSDealClassType = Type.GetTypeFromCLSID(typeof(TVSServer.rdmPBSDeal).GUID, API_TARGET_HOST, true);
                TVSServer.rdmPBSDeal oPBSDealClass = (TVSServer.rdmPBSDeal)Activator.CreateInstance(ordmPBSDealClassType);

                string sXMLResult;
                string sErrorText;
                string sLockId;

                sSessionId = Login();

                oTracer.LogInfo("Account:  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                oTracer.LogInfo("Host:  " + API_TARGET_HOST);
                oTracer.LogInfo("Before Call - GetDeal");
                int iResult = oPBSDealClass.GetDeal(sSessionId, p_iDealId, false, out sLockId, out sXMLResult, out sErrorText);
                oTracer.LogInfo("After Call - GetDeal");

                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("sLockId = " + sLockId);
                oTracer.LogInfo("sXMLResult Length = " + sXMLResult.Length.ToString());
                oTracer.LogInfo("sErrorText = " + sErrorText);

                oTracer.LogInfo("Before Call - GetDealWithFunding");
                iResult = oPBSDealClass.GetDealWithFunding(sSessionId, p_iDealId, false, out sLockId, out sXMLResult, out sErrorText);
                oTracer.LogInfo("After Call - GetDealWithFunding");

                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("sLockId = " + sLockId);
                oTracer.LogInfo("sXMLResult Length = " + sXMLResult.Length.ToString());
                oTracer.LogInfo("sErrorText = " + sErrorText);




            }
            catch (Exception oException)
            {
                oTracer.LogInfo("Error: " + oException.ToString());
                throw;
            }
            finally
            {
                Logout(sSessionId);
            }
        }

        static void DoFeatureMediaInventory(int p_iId)
        {
            string sSessionId = string.Empty;
            Tracer oTracer = new Tracer();
            try
            {

                Type oPBSMediaInventoryType = Type.GetTypeFromCLSID(typeof(OrionProxy.rdmPBSMediaInventory).GUID, API_TARGET_HOST, true);
                TVSServer.rdmPBSMediaInventory oPBSMediaInventory = (TVSServer.rdmPBSMediaInventory)Activator.CreateInstance(oPBSMediaInventoryType);



                string sReturn;
                string sErrorText;
                string sLockId;

                sSessionId = Login();

                oTracer.LogInfo("Account:  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                oTracer.LogInfo("Host:  " + API_TARGET_HOST);

                
                oTracer.LogInfo("Before Call - GetFeatureMediaInventory");
                int iResult = oPBSMediaInventory.GetFeatureMediaInventory(sSessionId, p_iId, false, out sLockId, out sReturn, out sErrorText);
                oTracer.LogInfo("After Call - GetFeatureMediaInventory");


                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("Session Id = " + sSessionId);
                oTracer.LogInfo("MI Id = " + p_iId);
                oTracer.LogInfo("Lock Id = " + sLockId);
                oTracer.LogInfo("Result XML Length = " + sReturn.Length);
                oTracer.LogInfo("Error Text = " + sErrorText);


                if (iResult != 0)
                {
                    throw new Exception("Error with GetFeatureMediaInventory: " + sErrorText);
                }

            }
            catch (Exception oException)
            {
                oTracer.LogInfo("Error: " + oException.ToString());
                throw;
            }
            finally
            {

                try
                {
                    Logout(sSessionId);
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        static void SearchFeatureAirDate(int p_iFeatureMediaInventoryId, int p_iTune)
        {
            string sSessionId = string.Empty;
            Tracer oTracer = new Tracer();
            try
            {

                Type oPBSSearchType = Type.GetTypeFromCLSID(typeof(OrionProxy.rdmPBSSearch).GUID, API_TARGET_HOST, true);
                TVSServer.rdmPBSSearch oPBSSearch = (TVSServer.rdmPBSSearch)Activator.CreateInstance(oPBSSearchType);

                string sReturn;
                string sErrorText;

                sSessionId = Login();

                oTracer.LogInfo("Account:  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                oTracer.LogInfo("Host:  " + API_TARGET_HOST);

                oTracer.LogInfo("Before Call - SearchFeatureAirDate");
                int iResult = oPBSSearch.SearchFeatureAirDate(sSessionId, p_iFeatureMediaInventoryId, p_iTune, out sReturn, out sErrorText);
                oTracer.LogInfo("After Call - SearchFeatureAirDate");

                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("Session Id = " + sSessionId);
                oTracer.LogInfo("MI Id = " + p_iFeatureMediaInventoryId);
                oTracer.LogInfo("Tune Value = " + p_iTune);
                oTracer.LogInfo("Result XML Length = " + sReturn.Length);
                oTracer.LogInfo("Error Text = " + sErrorText);

                if (iResult != 0)
                {
                    throw new Exception("Error with SearchFeatureAirDate: " + sErrorText);
                }


                //sReturn = null;
                //sErrorText = null;
                //iReturn = oPBSSearch.SearchMediaAirDate(sSessionId, "1165860M", p_iTune, out sReturn, out sErrorText);
                //if (iReturn != 0)
                //{
                //    throw new Exception("Error with SearchFeatureAirDate: " + sErrorText);
                //}



            }
            catch (Exception oException)
            {
                oTracer.LogInfo("Error: " + oException.ToString());
                throw;
            }
            finally
            {

                try
                {
                    Logout(sSessionId);
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        static void DoMediaInventoryRevision(int p_iMediaInventoryRevisionId)
        {
            string sSessionId = string.Empty;
            Tracer oTracer = new Tracer();
            try
            {

                Type oPBSMediaInventoryType = Type.GetTypeFromCLSID(typeof(OrionProxy.rdmPBSMediaInventory).GUID, API_TARGET_HOST, true);
                TVSServer.rdmPBSMediaInventory oPBSMediaInventory = (TVSServer.rdmPBSMediaInventory)Activator.CreateInstance(oPBSMediaInventoryType);

                string sReturn;
                string sErrorText;
                string sLockId;

                sSessionId = Login();



               
                oTracer.LogInfo("Account:  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                oTracer.LogInfo("Host:  " + API_TARGET_HOST);


                oTracer.LogInfo("Before Call - GetMediaInventoryRevision");
                int iResult = oPBSMediaInventory.GetMediaInventoryRevision(sSessionId, p_iMediaInventoryRevisionId, true, out sLockId, out sReturn, out sErrorText);
                oTracer.LogInfo("After Call - GetMediaInventoryRevision");

                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("Session Id = " + sSessionId);
                oTracer.LogInfo("MI Id = " + p_iMediaInventoryRevisionId);
                oTracer.LogInfo("Lock Id = " + sLockId);
                oTracer.LogInfo("Result XML Length = " + sReturn.Length);
                oTracer.LogInfo("Error Text = " + sErrorText);

                if (iResult != 0)
                {
                    throw new Exception("Error with GetMediaInventoryRevision: " + sErrorText);
                }




                int iNewRevisionId = -1;

                oTracer.LogInfo("Before Call - GetID");
                iResult = oPBSMediaInventory.GetID(out iNewRevisionId, out sErrorText);
                oTracer.LogInfo("Before Call - GetID");

                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("New MI Revision Id = " + iNewRevisionId);
                oTracer.LogInfo("Error Text = " + sErrorText);


                if (iResult != 0)
                {
                    throw new Exception("Error with GetID: " + sErrorText);
                }



                


                oTracer.LogInfo("Before Call - GetMediaInventoryRevision");
                iResult = oPBSMediaInventory.CreateMediaInventoryRevision(sSessionId, sLockId, p_iMediaInventoryRevisionId, iNewRevisionId, out sReturn, out sErrorText);
                oTracer.LogInfo("After Call - GetMediaInventoryRevision");

                oTracer.LogInfo("Method Result = " + iResult.ToString());
                oTracer.LogInfo("Session Id = " + sSessionId);
                oTracer.LogInfo("Old MI Id = " + p_iMediaInventoryRevisionId);
                oTracer.LogInfo("New MI Id = " + iNewRevisionId);
                oTracer.LogInfo("Lock Id = " + sLockId);
                oTracer.LogInfo("Result XML Length = " + sReturn.Length);
                oTracer.LogInfo("Error Text = " + sErrorText);


                if (iResult != 0)
                {
                    throw new Exception("Error with CreateMediaInventoryRevision: " + sErrorText);
                }



            }
            catch (Exception oException)
            {
                oTracer.LogInfo("Error: " + oException.ToString());
                throw;
            }
            finally
            {

                try
                {
                    Logout(sSessionId);
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }


        public static void ListMethodsForType(Type p_oType)
        {
            Tracer oTracer = new Tracer();

            foreach (MethodInfo oMethodInfo in p_oType.GetMethods())
            {
                 oTracer.LogInfo("\t" + oMethodInfo.Name);
            }
        }

        public static void ListClasses()
        {
            Tracer oTracer = new Tracer();

            Assembly oAssembly = Assembly.Load(@"OrionProxyLib");

            List<Type> oInterfaces = new List<Type>();
            List<Type> oClasses = new List<Type>();

            
            foreach (Type oType in oAssembly.GetTypes())
            {
                //Eliminate Listing Interfaces
                if (!oType.IsAbstract)
                {
                     oTracer.LogInfo(oType.FullName);
                    ListMethodsForType(oType);
                }
            }


            
            


            

            //MethodInfo[] methodInfos =  typeof(OrionProxy).GetMethods(BindingFlags.Public |
            //                                          BindingFlags.Static);
            //// sort methods by name
            //Array.Sort(methodInfos,
            //        delegate(MethodInfo methodInfo1, MethodInfo methodInfo2)
            //        { return methodInfo1.Name.CompareTo(methodInfo2.Name); });

            //// write method names
            //foreach (MethodInfo methodInfo in methodInfos)
            //{
            //    Console.WriteLine(methodInfo.Name);
            //}



        }


    }
}
