
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using BVWebServiceTestProject.BVWebServiceWS;
using System.Collections.Generic;
using BVWebServiceTestProject.Test_References;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.ServiceModel;

namespace BVWebServiceTestProject
{
    
    
    /// <summary>
    ///This is a test class for BVWebServiceTest and is intended
    ///to contain all BVWebServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BVWebServiceTest
    {
        private const string USER_PROFILE_CONFIG_FILE = "UserProfile.config";
        private static string m_newBVSessionId;
        //private static string m_oldBVSessionId;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceTestProject.BVWebServiceWS.UserProfile userProfile = GetUserProfile();
            m_newBVSessionId = target.OpenSession(userProfile);
        }
        
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        public BVWebServiceTestProject.BVWebServiceWS.UserProfile GetUserProfile()
        {
            UserProfile oUserProfile = new UserProfile();
            //XmlSerializer oXmlSerializer = new XmlSerializer(typeof(BVWebServiceTestProject.BVWebServiceWS.UserProfile));
        
                //oUserProfile = new BVWebServiceTestProject.BVWebServiceWS.UserProfile();
                oUserProfile.sConnectId = "brboggio";
                oUserProfile.sExternalEmail = "brboggio@pbs.org";
                oUserProfile.sFirstName = "bryan";
                oUserProfile.sLastName = "boggio";
                oUserProfile.oOperatingGroup = new string[]{"Administrators", "Users"};
                oUserProfile.nOperatingUnit =369;
                oUserProfile.nUnitType = 1;
                oUserProfile.sPhoneNumber = "7038675309";
                oUserProfile.nRole = 1;

            //using (StreamReader oReader = new StreamReader(Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar.ToString() + USER_PROFILE_CONFIG_FILE))
            //{
            //    oUserProfile = (BVWebServiceTestProject.BVWebServiceWS.UserProfile)oXmlSerializer.Deserialize(oReader);
            //}

            return oUserProfile;
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
                    prop.PropertyType) ?? prop.PropertyType);
            }

            return table;
        }


        static class MemberCompare
        {
            public static bool Equal<T>(T x, T y)
            {
                return Cache<T>.Compare(x, y);
            }
            static class Cache<T>
            {
                internal static readonly Func<T, T, bool> Compare;
                static Cache()
                {
                    var members = typeof(T).GetProperties(
                        BindingFlags.Instance | BindingFlags.Public)
                        .Cast<MemberInfo>().Concat(typeof(T).GetFields(
                        BindingFlags.Instance | BindingFlags.Public)
                        .Cast<MemberInfo>());
                    var x = Expression.Parameter(typeof(T), "x");
                    var y = Expression.Parameter(typeof(T), "y");

                    Expression body = null;
                    foreach (var member in members)
                    {
                        Expression memberEqual;
                        switch (member.MemberType)
                        {
                            case MemberTypes.Field:
                                memberEqual = Expression.Equal(
                                    Expression.Field(x, (FieldInfo)member),
                                    Expression.Field(y, (FieldInfo)member));
                                break;
                            case MemberTypes.Property:
                                memberEqual = Expression.Equal(
                                    Expression.Property(x, (PropertyInfo)member),
                                    Expression.Property(y, (PropertyInfo)member));
                                break;
                            default:
                                throw new NotSupportedException(
                                    member.MemberType.ToString());
                        }
                        if (body == null)
                        {
                            body = memberEqual;
                        }
                        else
                        {
                            body = Expression.AndAlso(body, memberEqual);
                        }
                    }
                    if (body == null)
                    {
                        Compare = delegate { return true; };
                    }
                    else
                    {
                        Compare = Expression.Lambda<Func<T, T, bool>>(body, x, y)
                                      .Compile();
                    }
                }
            }
        }
        /// <summary>
        ///A test for OpenSession
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [DeploymentItem("UserProfile.config")]
        public void OpenSessionTest()
        {
            BVWebServiceWS.BVWebServiceSoapClient target = new BVWebServiceWS.BVWebServiceSoapClient();

            BVWebServiceTestProject.BVWebServiceWS.UserProfile userProfile = GetUserProfile();
            string expected = string.Empty; //  
            string actual;
            
            actual = target.OpenSession(userProfile);

            Assert.IsNotNull(actual, "OpenSession result unexpected. Value {0}", actual);
        }



        ///// <summary>
        /////A test for ValidateEpisodeSlate
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ValidateEpisodeSlateTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string p_sSessionId = m_newBVSessionId;

            string p_sNolaRoot = "TAPI"; // You created this value in CreateProgramTest
            int p_iStartingEpisodeNumber = 1; 
            int p_iNumberOfPrograms = 4; 
            DataSet expected = oldTarget.ValidateEpisodeSlate(p_sSessionId, p_sNolaRoot, p_iStartingEpisodeNumber, p_iNumberOfPrograms);
            DataSet actual = target.ValidateEpisodeSlate(p_sSessionId, p_sNolaRoot, p_iStartingEpisodeNumber, p_iNumberOfPrograms);

            DataTable old_dt = expected.Tables["master"];
            DataTable new_dt = actual.Tables["master"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for TrafficItemSearch
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void TrafficItemSearchTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            SearchCriterion[] SearchCriteria = new SearchCriterion[5];
            BVWebServiceOld.SearchCriterion[] oldSearchCriteria = new BVWebServiceOld.SearchCriterion[5];

            List<string> dealSearchTerms = new List<string>();
            dealSearchTerms.Add("Title");
            dealSearchTerms.Add("Duration");
            dealSearchTerms.Add("Category");
            dealSearchTerms.Add("Is_Approved");
            dealSearchTerms.Add("EXCLUDEINUSE");
            for (var i = 0; i < SearchCriteria.Count(); i++)
            {
                SearchCriteria[i] = new SearchCriterion();
                oldSearchCriteria[i] = new BVWebServiceOld.SearchCriterion();
                SearchCriteria[i].SearchField = dealSearchTerms[i];
                oldSearchCriteria[i].SearchField = dealSearchTerms[i];
            }

            oldSearchCriteria[0].SearchValue = "%the%"; // Remember the percent signs when doing a search
            oldSearchCriteria[1].SearchValue = "";
            oldSearchCriteria[2].SearchValue = "";
            oldSearchCriteria[3].SearchValue = "";
            oldSearchCriteria[4].SearchValue = "";

            SearchCriteria[0].SearchValue = "%the%";
            SearchCriteria[1].SearchValue = "";
            SearchCriteria[2].SearchValue = "";
            SearchCriteria[3].SearchValue = "";
            SearchCriteria[4].SearchValue = "";

            int nMaxRows = 10; 
            DataSet expected = oldTarget.TrafficItemSearch(strSessionID, oldSearchCriteria, nMaxRows);
            DataSet actual = target.TrafficItemSearch(strSessionID, SearchCriteria, nMaxRows);
            DataTable old_dt = expected.Tables["TRAFFICITEMSEARCH"];
            DataTable new_dt = actual.Tables["TRAFFICITEMSEARCH"];

            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
            for (var i = 0; i < old_dt.Rows.Count; i++)
            {
                var bEqual = comparer.Equals(old_dt.Rows[i], new_dt.Rows[i]);
                if (bEqual)
                    Debug.WriteLine("Two rows are equal");
                else
                    Debug.WriteLine("Two rows are not equal");

                Debug.WriteLine("The hashcodes for the two rows are {0}, {1}", comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
                Assert.AreEqual(comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
            }
        }

        ///// <summary>
        /////A test for TalentSearch
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void TalentSearchTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string sTalentName = "%rod%"; // Remember the percent signs when searching
            DataSet expected = oldTarget.TalentSearch(strSessionID, sTalentName);
            DataSet actual = target.TalentSearch(strSessionID, sTalentName);

            DataTable old_dt = expected.Tables["talentsearch"];
            DataTable new_dt = actual.Tables["talentsearch"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);
            
            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for ReleaseLock
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        //public void ReleaseLockTest()
        //{
        //   BVWebService.BVWebServiceSoapClient target = new BVWebService.BVWebServiceSoapClient();// TODO: Initialize to an appropriate value
        //    string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
        //    string strLockID = string.Empty; // TODO: Initialize to an appropriate value
        //    target.ReleaseLock(strSessionID, strLockID);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        ///// <summary>
        /////A test for PutVisualArt
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void EditVisualArtTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string strLockID = string.Empty;
            int nVisualArtID = 382;
            bool bLockFlag = true;
            
            int expected = 0;
            int actual = 0;
            // get record
            DataSet getVisualArtResults = target.GetVisualArt(out strLockID, strSessionID, nVisualArtID, bLockFlag);
            DataTable visualArtTabletoModify = getVisualArtResults.Tables["visualart"];
            
            // grab and modify your record
            visualArtTabletoModify.Rows[0]["PVA_FORMSTATUS"] = 40; // this is either 30 or 40, active or inactive??
            expected = int.Parse(visualArtTabletoModify.Rows[0]["PVA_FORMSTATUS"].ToString());
            // add datatable to 
            DataSet dsVisualArt = getVisualArtResults;
            target.PutVisualArt(strSessionID, strLockID, dsVisualArt);
            target.ReleaseLock(strSessionID, strLockID);
            // get again to verify it was committed
            DataSet getModifiedVisualArtResults = target.GetVisualArt(out strLockID, strSessionID, nVisualArtID, false);
            DataTable visualArtTabletoCompare = getModifiedVisualArtResults.Tables["visualart"];
            actual = int.Parse(visualArtTabletoCompare.Rows[0]["PVA_FORMSTATUS"].ToString());

            Assert.AreEqual<int>(expected, actual);
        }        

        ///// <summary>
        /////A test for PutUCC
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void EditUCCTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();            
            string strSessionID = m_newBVSessionId;
            string strLockID = string.Empty;
            int nUCCID = 223510868;
            bool bLockFlag = true;

            int expected = 0;
            int actual = 0;
            // get record
            DataSet getUccResults = target.GetUCC(out strLockID, strSessionID, nUCCID, bLockFlag);
            DataTable uccTabletoModify = getUccResults.Tables["ucc"];
            // grab and modify your record
            uccTabletoModify.Rows[0]["PUCC_FORMSTATUS"] = 30; // this is 30-60
            expected = int.Parse(uccTabletoModify.Rows[0]["PUCC_FORMSTATUS"].ToString());
            // add datatable to 
            DataSet dsUCC = getUccResults;
            target.PutUCC(strSessionID, strLockID, dsUCC);
            target.ReleaseLock(strSessionID, strLockID);
            // get again to verify it was committed
            DataSet getModifiedUccResults = target.GetUCC(out strLockID, strSessionID, nUCCID, false);
            DataTable uccTabletoCompare = getModifiedUccResults.Tables["ucc"];
            actual = int.Parse(uccTabletoCompare.Rows[0]["PUCC_FORMSTATUS"].ToString());

            Assert.AreEqual<int>(expected, actual);           
        }
        
        ///// <summary>
        /////A test for PutTalent
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutTalentTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string expected = string.Empty;
            string actual = string.Empty;

            int nDealID = 3399613; // Ideally this should be the deal you created in createprogram
            int nTalentID = 3271462; // Look in ASSET_TALENT if you are having trouble finding valid values for all three
            int nRoleID = 3262458; // Talentroles is the lookup table

            DataSet oldEpisodeTalent = null;
            DataSet oldTalent = null;
            DataSet modifiedEpisodeTalent = null;
            DataSet modifiedTalent = null;

            DataSet toModify = target.GetTalent(out oldEpisodeTalent, out oldTalent, strSessionID, nDealID, nTalentID, nRoleID);
            DataTable old_EPISODETALENT_dt = oldEpisodeTalent.Tables["EPISODETALENT"];
            DataTable old_TALENT_dt = oldTalent.Tables["TALENT"];
            old_EPISODETALENT_dt.Rows[0]["ASS_TAL_DESC"] = "Interim Chairman & CEO, Boeing";
            expected = old_EPISODETALENT_dt.Rows[0]["ASS_TAL_DESC"].ToString();

            DataSet dEpisodeTalent = oldEpisodeTalent;
            DataSet dTalent = oldTalent;
            target.PutTalent(strSessionID, dEpisodeTalent, dTalent);

            DataSet toCompare = target.GetTalent(out modifiedEpisodeTalent, out modifiedTalent, strSessionID, nDealID, nTalentID, nRoleID);
            DataTable compare_EPISODETALENT_dt = modifiedEpisodeTalent.Tables["EPISODETALENT"];

            actual = compare_EPISODETALENT_dt.Rows[0]["ASS_TAL_DESC"].ToString();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PutProgramDetails
        ///</summary>
        ///<remarks>
        ///These PUT tests are a sequence of GET - PUT - GET 
        ///You GET to determine there is a value or lack of a value along with a LockID
        ///Next you modify the relevant dataset with the value(s) you want to PUT
        ///In order to have a sucessful PUT you need a LockID for the record you wish to modify
        ///Finally you GET the record again to verify the data was successfully written
        /// </remarks>

        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutProgramDetailsTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string strTitleCompare = "An episode title for ID 548";
            int nProgramID = 252145548;
            bool bLockFlag = true;
            bool bGetPremiereDate = true;
            string strLockID = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;

            DataSet getProgramResults = target.GetProgramDetails(out strLockID, strSessionID, nProgramID, bLockFlag, bGetPremiereDate);
            DataTable assetTabletoModify = getProgramResults.Tables["asset"];

            //Assert.AreNotEqual(assetTabletoModify.Rows[0]["ass_episodetitle"].ToString(), strTitleCompare);  If you know the values you are working with
            // you can uncomment this check.

            assetTabletoModify.Rows[0]["ass_episodetitle"] = strTitleCompare;
            expected = assetTabletoModify.Rows[0]["ass_episodetitle"].ToString();
           
            DataSet dsDeal = getProgramResults;
            target.PutProgramDetails(strSessionID, nProgramID, strLockID, dsDeal);

            target.ReleaseLock(strSessionID, strLockID); // you have to release the lock otherwise this record cannot be edited in the future

            DataSet getModifiedProgramResults = target.GetProgramDetails(out strLockID, strSessionID, nProgramID, false, bGetPremiereDate);  // we dont need a lock now
            DataTable assetTabletoCompare = getModifiedProgramResults.Tables["asset"];
            actual = assetTabletoCompare.Rows[0]["ass_episodetitle"].ToString();

            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for PutPackageAppliesToRangeByTab
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutPackageAppliesToRangeByTabTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string actual = string.Empty;
            string expected = string.Empty;
            int nTabID = 471;
            string strTabType = "OAC";

            DataSet toModify = target.GetPackageAppliesToRangeByTab(strSessionID, nTabID, strTabType);
                        
            DataTable new_dt = toModify.Tables["PROGRAMS"];            
            DataTable new_RANGE_dt = toModify.Tables["VW_VERSIONAPPLIESTORANGE"];
            new_RANGE_dt.Rows[0]["IS_APPROVED"] = 1; // No idea what is something that should be edited
            expected = new_RANGE_dt.Rows[0]["IS_APPROVED"].ToString();


            DataSet dsPackageAppliesTo = toModify; // TODO: Initialize to an appropriate value
            target.PutPackageAppliesToRangeByTab(strSessionID, dsPackageAppliesTo);

            DataSet toCompare = target.GetPackageAppliesToRangeByTab(strSessionID, nTabID, strTabType);

            DataTable compare_dt = toCompare.Tables["VW_VERSIONAPPLIESTORANGE"];
            actual = compare_dt.Rows[0]["IS_APPROVED"].ToString();

            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for PutOAC
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutOACTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string expected = string.Empty;
            string actual = string.Empty;
            int nOACID = 67;
            bool bLockFlag = true;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;

            DataSet toModify = target.GetOAC(out strLockID, strSessionID, nOACID, bLockFlag);
            DataTable old_OAC_dt = toModify.Tables["OAC"];
            DataTable old_OACITEM_dt = toModify.Tables["PBSOACITEM"];
            DataTable old_OACENTITY_dt = toModify.Tables["VW_PBSOACENTITY"];

            old_OAC_dt.Rows[0]["POAC_EMAIL"] = "";
            expected = old_OAC_dt.Rows[0]["POAC_EMAIL"].ToString();

            DataSet dsOAC = toModify;
            target.PutOAC(strSessionID, strLockID, dsOAC);
            target.ReleaseLock(strSessionID, strLockID); // you have to release the lock otherwise this record cannot be edited in the future

            DataSet toCompare = target.GetOAC(out strLockIDExpected, strSessionID, nOACID, false);
            DataTable new_OAC_dt = toCompare.Tables["OAC"];
            actual = new_OAC_dt.Rows[0]["POAC_EMAIL"].ToString();

            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for PutMusicCue
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutMusicCueTest()
        {
            bool processTest = false;
            if (processTest)
            {
                BVWebServiceSoapClient target = new BVWebServiceSoapClient();
                /////////////////
                DataSet expected = new DataSet();
                int nMusicCueID = 252133155; // PMC_ID 
                bool bLockFlag = false; // Edit is true, get is false
                string strLockID = string.Empty;

                // Establish Session to communicate with web service method
                string strSessionID = m_newBVSessionId;

                // Create new object 
                List<MUSICCUE> compareMusicCue = new List<MUSICCUE>();
                MUSICCUE tmpMusicCue = new MUSICCUE
                {
                    PMC_ID = 252133155,
                    PMC_DEA_ID = null,
                    PMC_FORMSTATUS = 50
                };
                compareMusicCue.Add(tmpMusicCue);

                // Convert your new object into a datatable
                //DataTable table1 = new DataTable();
                //table1 = ConvertTo(compareMusicCue);
                //expected.Tables.Add(table1);
                DataSet dsMusicCue = new DataSet();
                dsMusicCue = target.GetMusicCue(out strLockID, strSessionID, nMusicCueID, bLockFlag);
                DataTable old_dt = dsMusicCue.Tables["musiccue"];

                DataRow cueRow = old_dt.NewRow();
                //dsMusicCue = target.GetMusicCue(out strLockID, strSessionID, 252132671, true);
                /////////////////            
                cueRow["PMC_ID"] = 252133159;
                cueRow["PMC_DEA_ID"] = DBNull.Value;
                cueRow["PMC_FORMSTATUS"] = 50;
                old_dt.Rows.Add(cueRow);

                var boo = old_dt.Rows[0].RowState;
                target.PutMusicCue(strSessionID, strLockID, dsMusicCue);
            }
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///// <summary>
        /////A test for PutMediaInventoryRevision
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutMediaInventoryRevisionTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string actual = string.Empty;
            string expected = string.Empty;

            int nMediaInventoryRevisionID = 3838052; // TODO: Initialize to an appropriate value
            bool bLockFlag = true;
            string strLockID = string.Empty;

            DataSet toModify = target.GetMediaInventoryRevision(out strLockID, strSessionID, nMediaInventoryRevisionID, bLockFlag);            

            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            DataTable old_dt = toModify.Tables["MEDIAINVENTORYREVISION"];
            DataTable old_MICUT_dt = toModify.Tables["MEDIAINVENTORYCUT"];

            old_dt.Rows[0]["MEI_DESCRIPTION"] = "(AACR  000000, REEL 1) AFFIRMATIVE ACTION: THE RIGHT ROAD TO DIVERSITY?";
            expected = old_dt.Rows[0]["MEI_DESCRIPTION"].ToString();

            DataSet dsMediaInventoryRevision = toModify; // TODO: Initialize to an appropriate value
            target.PutMediaInventoryRevision(strSessionID, strLockID, dsMediaInventoryRevision);
            target.ReleaseLock(strSessionID, strLockID);

            DataSet toCompare = target.GetMediaInventoryRevision(out strLockID, strSessionID, nMediaInventoryRevisionID, false);

            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            DataTable toCompare_dt = toModify.Tables["MEDIAINVENTORYREVISION"];
            actual = toCompare_dt.Rows[0]["MEI_DESCRIPTION"].ToString();

            Assert.AreEqual(expected, actual);
        }


        ///// <summary>
        /////A test for PutFeatureMediaInventory
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutFeatureMediaInventoryTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nFeatureMediaInventoryID = 14969775; // TODO: No clue what makes a valid media inventory id 
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDActual = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;

            DataSet toModify = target.GetFeatureMediaInventory(out strLockID, strSessionID, nFeatureMediaInventoryID, true);
            DataTable meiDataTable = toModify.Tables["FEATUREMEDIAINVENTORY"];

            var existing_value = meiDataTable.Rows[0]["MEI_DESCRIPTION"].ToString();
            //expected = existing_value.Remove(existing_value.Length - 5);
            expected = existing_value + " TEST";

            meiDataTable.Rows[0]["MEI_DESCRIPTION"] = expected;

            DataSet dsFeatureMediaInventory = toModify;
            target.PutFeatureMediaInventory(strSessionID, strLockID, dsFeatureMediaInventory);
            target.ReleaseLock(strSessionID, strLockID);

            DataSet toCompare = target.GetFeatureMediaInventory(out strLockIDActual, strSessionID, nFeatureMediaInventoryID, bLockFlag);
            DataTable modifiedMEIDataTable = toCompare.Tables["FEATUREMEDIAINVENTORY"];

            actual = modifiedMEIDataTable.Rows[0]["MEI_DESCRIPTION"].ToString();
            Assert.AreEqual(expected, actual) ;
        }

        ///// <summary>
        /////A test for PutDealWithTechnical
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutDealWithTechnicalTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealID = 220466854;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDActual = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;

            DataSet toModify = target.GetDealWithTechnical(out strLockID, strSessionID, nDealID, true);
            DataTable dealDataTable = toModify.Tables["DEAL"];

            var existing_value = dealDataTable.Rows[0]["DEA_DESC"].ToString();
            //expected = existing_value.Remove(existing_value.Length - 5);
            expected = existing_value + " TEST";
            dealDataTable.Rows[0]["DEA_DESC"] = expected;

            DataSet dsDeal = toModify;
            target.PutDealWithTechnical(strSessionID, nDealID, strLockID, dsDeal);
            target.ReleaseLock(strSessionID, strLockID);

            DataSet toCompare = target.GetDealWithTechnical(out strLockID, strSessionID, nDealID, bLockFlag);
            DataTable modifiedDealDataTable = toCompare.Tables["DEAL"];

            actual = modifiedDealDataTable.Rows[0]["DEA_DESC"].ToString();
            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for PutDealWithRights
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutDealWithRightsTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealID = 220466854;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDActual = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;

            DataSet toModify = target.GetDealWithRights(out strLockID, strSessionID, nDealID, true);
            DataTable dealDataTable = toModify.Tables["DEAL"];

            var existing_value = dealDataTable.Rows[0]["DEA_DESC"].ToString();
            //expected = existing_value.Remove(existing_value.Length - 5);
            expected = existing_value + " TEST";
            dealDataTable.Rows[0]["DEA_DESC"] = expected;

            DataSet dsDeal = toModify;
            target.PutDealWithRights(strSessionID, nDealID, strLockID, dsDeal);
            target.ReleaseLock(strSessionID, strLockID);

            DataSet toCompare = target.GetDealWithRights(out strLockID, strSessionID, nDealID, bLockFlag);
            DataTable modifiedDealDataTable = toCompare.Tables["DEAL"];

            actual = modifiedDealDataTable.Rows[0]["DEA_DESC"].ToString();
            target.CloseSession(strSessionID);
            Assert.AreEqual(expected, actual);
            
            
        }

        ///// <summary>
        /////A test for PutDealWithGeneral
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutDealWithGeneralTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealID = 220466854;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDActual = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;

            DataSet toModify = target.GetDealWithGeneral(out strLockID, strSessionID, nDealID, true);
            DataTable dealDataTable = toModify.Tables["DEAL"];

            var existing_value = dealDataTable.Rows[0]["DEA_DESC"].ToString();
            //expected = existing_value.Remove(existing_value.Length - 5);
            expected = existing_value + " TEST";
            dealDataTable.Rows[0]["DEA_DESC"] = expected;

            DataSet dsDeal = toModify;
            target.PutDealWithGeneral(strSessionID, nDealID, strLockID, dsDeal);
            target.ReleaseLock(strSessionID, strLockID);

            DataSet toCompare = target.GetDealWithGeneral(out strLockID, strSessionID, nDealID, bLockFlag);
            DataTable modifiedDealDataTable = toCompare.Tables["DEAL"];

            actual = modifiedDealDataTable.Rows[0]["DEA_DESC"].ToString();
            target.CloseSession(strSessionID);
            Assert.AreEqual(expected, actual);                      
        }

        ///// <summary>
        /////A test for PutDealWithFunding
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutDealWithFundingTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealID = 220466854;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDActual = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;

            DataSet toModify = target.GetDealWithFunding(out strLockID, strSessionID, nDealID, true);
            DataTable dealDataTable = toModify.Tables["DEAL"];

            var existing_value = dealDataTable.Rows[0]["DEA_DESC"].ToString();
            //expected = existing_value.Remove(existing_value.Length - 5);
            expected = existing_value + " TEST";
            dealDataTable.Rows[0]["DEA_DESC"] = expected;

            DataSet dsDeal = toModify;
            target.PutDealWithFunding(strSessionID, nDealID, strLockID, dsDeal);            
            target.ReleaseLock(strSessionID, strLockID);

            DataSet toCompare = target.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);
            DataTable modifiedDealDataTable = toCompare.Tables["DEAL"];

            actual = modifiedDealDataTable.Rows[0]["DEA_DESC"].ToString();
            target.CloseSession(strSessionID);
            Assert.AreEqual(expected, actual);            
        }

        ///// <summary>
        /////A test for PutDeal
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void PutDealTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealID = 220466854;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDActual = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;

            DataSet toModify = target.GetDeal(out strLockID, strSessionID, nDealID, true);
            DataTable dealDataTable = toModify.Tables["DEAL"];

            var existing_value = dealDataTable.Rows[0]["DEA_DESC"].ToString();
            //expected = existing_value.Remove(existing_value.Length - 5);
            expected = existing_value + " TEST";
            dealDataTable.Rows[0]["DEA_DESC"] = expected;

            DataSet dsDeal = toModify;
            target.PutDeal(strSessionID, nDealID, strLockID, dsDeal);
            target.ReleaseLock(strSessionID, strLockID);

            DataSet toCompare = target.GetDeal(out strLockID, strSessionID, nDealID, bLockFlag);
            DataTable modifiedDealDataTable = toCompare.Tables["DEAL"];

            actual = modifiedDealDataTable.Rows[0]["DEA_DESC"].ToString();
            target.CloseSession(strSessionID);
            Assert.AreEqual(expected, actual);            
        }

        ///// <summary>
        /////A test for PutAssetAppliesToRangeByTab
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        //public void PutAssetAppliesToRangeByTabTest()
        //{
        //    BVWebServiceSoapClient target = new BVWebServiceSoapClient();
        //    BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
        //    string strSessionID = m_newBVSessionId;
        //    int nTabID = 952; // TODO: Create a helper class to grab a random value from BV
        //    string strTabType = "MUS"; // Either MUS or VIS
        //    string strLockID = string.Empty;
        //    string strLockIDActual = string.Empty;
        //    string expected = string.Empty;
        //    string actual = string.Empty;
        //    ///////////////////////////////////
        //    DataSet toModify = target.GetAssetAppliesToRangeByTab(strSessionID, nTabID, strTabType);


        //    DataSet dsAssetAppliesTo = null; // TODO: Initialize to an appropriate value
        //    target.CloseSession(strSessionID);
        //    target.PutAssetAppliesToRangeByTab(strSessionID, dsAssetAppliesTo);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}
       

        ///// <summary>
        /////A test for ProgramSearch
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ProgramSearchTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            SearchCriterion[] SearchCriteria = new SearchCriterion[4];
            BVWebServiceOld.SearchCriterion[] oldSearchCriteria = new BVWebServiceOld.SearchCriterion[4];

            List<string> programSearchTerms = new List<string>();
            programSearchTerms.Add("program_title");
            programSearchTerms.Add("episode_title");
            programSearchTerms.Add("program_season");
            programSearchTerms.Add("episode_nola");            

            for (var i = 0; i < SearchCriteria.Count(); i++)
            {
                SearchCriteria[i] = new SearchCriterion();
                oldSearchCriteria[i] = new BVWebServiceOld.SearchCriterion();
                SearchCriteria[i].SearchField = programSearchTerms[i];
                oldSearchCriteria[i].SearchField = programSearchTerms[i];
            }
            oldSearchCriteria[0].SearchValue = "";
            SearchCriteria[0].SearchValue = "";
            oldSearchCriteria[1].SearchValue = "";
            SearchCriteria[1].SearchValue = "";
            oldSearchCriteria[2].SearchValue = "";
            SearchCriteria[2].SearchValue = "";
            oldSearchCriteria[3].SearchValue = "%TAPI%";
            SearchCriteria[3].SearchValue = "%TAPI%";

            int nMaxRows = 10;
            DataSet expected = oldTarget.ProgramSearch(strSessionID, oldSearchCriteria, nMaxRows);
            DataSet actual = target.ProgramSearch(strSessionID, SearchCriteria, nMaxRows);

            DataTable old_dt = expected.Tables["PROGRAMSEARCH"];
            DataTable new_dt = actual.Tables["PROGRAMSEARCH"];

            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
            for (var i = 0; i < old_dt.Rows.Count; i++)
            {
                var bEqual = comparer.Equals(old_dt.Rows[i], new_dt.Rows[i]);
                if (bEqual)
                    Debug.WriteLine("Two rows are equal");
                else
                    Debug.WriteLine("Two rows are not equal");

                Debug.WriteLine("The hashcodes for the two rows are {0}, {1}", comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
                Assert.AreEqual(comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
            }
            ////actual = target.ProgramSearch(strSessionID, SearchCriteria, nMaxRows);            
        }

      


   
        ///// <summary>
        /////A test for MediaInventorySearch
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void MediaInventorySearchTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            SearchCriterion[] SearchCriteria = new SearchCriterion[5];
            BVWebServiceOld.SearchCriterion[] oldSearchCriteria = new BVWebServiceOld.SearchCriterion[5];

            List<string> mediaInventorySearchTerms = new List<string>();
            mediaInventorySearchTerms.Add("program_id");
            mediaInventorySearchTerms.Add("deal_id");
            mediaInventorySearchTerms.Add("operating_unit");
            mediaInventorySearchTerms.Add("operating_group");
            mediaInventorySearchTerms.Add("title");

            for (var i = 0; i < SearchCriteria.Count(); i++)
            {
                SearchCriteria[i] = new SearchCriterion();
                oldSearchCriteria[i] = new BVWebServiceOld.SearchCriterion();
                SearchCriteria[i].SearchField = mediaInventorySearchTerms[i];
                oldSearchCriteria[i].SearchField = mediaInventorySearchTerms[i];
            }

            oldSearchCriteria[0].SearchValue = "";
            SearchCriteria[0].SearchValue = "";
            oldSearchCriteria[1].SearchValue = "252145554";
            SearchCriteria[1].SearchValue = "252145554";
            oldSearchCriteria[2].SearchValue = "";
            SearchCriteria[2].SearchValue = "";
            oldSearchCriteria[3].SearchValue = "";
            SearchCriteria[3].SearchValue = "";
            oldSearchCriteria[4].SearchValue = "";
            SearchCriteria[4].SearchValue = "";

            int nMaxRows = 10;
            DataSet expected = oldTarget.MediaInventorySearch(strSessionID, oldSearchCriteria, nMaxRows);
            DataSet actual = target.MediaInventorySearch(strSessionID, SearchCriteria, nMaxRows);

            DataTable old_dt = expected.Tables["MEDIAINVENTORYSEARCH"];
            DataTable new_dt = actual.Tables["MEDIAINVENTORYSEARCH"];

            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
            for (var i = 0; i < old_dt.Rows.Count; i++)
            {
                var bEqual = comparer.Equals(old_dt.Rows[i], new_dt.Rows[i]);
                if (bEqual)
                    Debug.WriteLine("Two rows are equal");
                else
                    Debug.WriteLine("Two rows are not equal");

                Debug.WriteLine("The hashcodes for the two rows are {0}, {1}", comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
                Assert.AreEqual(comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
            }
        }

        ///// <summary>
        /////A test for MasterDealSearch
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void MasterDealSearchTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            SearchCriterion[] SearchCriteria = new SearchCriterion[1];
            BVWebServiceOld.SearchCriterion[] oldSearchCriteria = new BVWebServiceOld.SearchCriterion[1];

            List<string> masterDealSearchTerms = new List<string>();
            masterDealSearchTerms.Add("title");
            for (var i = 0; i < SearchCriteria.Count(); i++)
            {
                SearchCriteria[i] = new SearchCriterion();
                oldSearchCriteria[i] = new BVWebServiceOld.SearchCriterion();
                SearchCriteria[i].SearchField = masterDealSearchTerms[i];
                oldSearchCriteria[i].SearchField = masterDealSearchTerms[i];
            }

            oldSearchCriteria[0].SearchValue = "%BV%";  // Remember the percent symbols if you need a LIKE search
            SearchCriteria[0].SearchValue = "%BV%";

            int nMaxRows = 10; 

            DataSet actual = target.MasterDealSearch(strSessionID, SearchCriteria, nMaxRows);
            DataSet expected = oldTarget.MasterDealSearch(strSessionID, oldSearchCriteria, nMaxRows);

            DataTable old_dt = expected.Tables["MASTERDEAL"];
            DataTable new_dt = actual.Tables["MASTERDEAL"];

            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
            for (var i = 0; i < old_dt.Rows.Count; i++)
            {
                var bEqual = comparer.Equals(old_dt.Rows[i], new_dt.Rows[i]);
                if (bEqual)
                    Debug.WriteLine("Two rows are equal");
                else
                    Debug.WriteLine("Two rows are not equal");

                Debug.WriteLine("The hashcodes for the two rows are {0}, {1}", comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
                Assert.AreEqual(comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
            }
            
        }

        ///// <summary>
        /////A test for LogException
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        //[DeploymentItem("BVWebService.dll")]
        //public void LogExceptionTest()
        //{
        //    BVWebService_Accessor target = new BVWebService_Accessor(); // TODO: Initialize to an appropriate value
        //    Exception ex = null; // TODO: Initialize to an appropriate value
        //    target.LogException(ex);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        ///// <summary>
        /////A test for LoadVideoFormat
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadVideoFormatTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadVideoFormat();
            DataSet actual;
            actual = target.LoadVideoFormat();

            DataTable old_dt = expected.Tables["videoformat"];
            DataTable new_dt = actual.Tables["videoformat"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadVersionFormatAndType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadVersionFormatAndTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadVersionFormatAndType();
            DataSet actual;
            actual = target.LoadVersionFormatAndType();

            DataTable old_dt = expected.Tables["versionformatandtype"];
            DataTable new_dt = actual.Tables["versionformatandtype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadVChipValues
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadVChipValuesTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadVChipValues();
            DataSet actual;
            actual = target.LoadVChipValues();

            DataTable old_dt = expected.Tables["vchip"];
            DataTable new_dt = actual.Tables["vchip"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadUplinks
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadUplinksTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadUplinks();
            DataSet actual;
            actual = target.LoadUplinks();

            DataTable old_dt = expected.Tables["uplinks"];
            DataTable new_dt = actual.Tables["uplinks"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadTalentRoles
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadTalentRolesTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadTalentRoles();
            DataSet actual;
            actual = target.LoadTalentRoles();

            DataTable old_dt = expected.Tables["talentroles"];
            DataTable new_dt = actual.Tables["talentroles"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadSurroundSoundType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadSurroundSoundTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadSurroundSoundType();
            DataSet actual;
            actual = target.LoadSurroundSoundType();

            DataTable old_dt = expected.Tables["surroundsound"];
            DataTable new_dt = actual.Tables["surroundsound"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadStations
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadStationsTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadStations();
            DataSet actual;
            actual = target.LoadStations();

            DataTable old_dt = expected.Tables["station"];
            DataTable new_dt = actual.Tables["station"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadSchoolRights
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadSchoolRightsTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadSchoolRights();
            DataSet actual;
            actual = target.LoadSchoolRights();

            DataTable old_dt = expected.Tables["schoolrights"];
            DataTable new_dt = actual.Tables["schoolrights"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadRating
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadRatingTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadRating();
            DataSet actual;
            actual = target.LoadRating();

            DataTable old_dt = expected.Tables["rating"];
            DataTable new_dt = actual.Tables["rating"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadProgramType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadProgramTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadProgramType();
            DataSet actual;
            actual = target.LoadProgramType();

            DataTable old_dt = expected.Tables["programtype"];
            DataTable new_dt = actual.Tables["programtype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadPlayRule
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadPlayRuleTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadPlayRule();
            DataSet actual;
            actual = target.LoadPlayRule();

            DataTable old_dt = expected.Tables["playrule"];
            DataTable new_dt = actual.Tables["playrule"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadPackageType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadPackageTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadPackageType();
            DataSet actual;
            actual = target.LoadPackageType();

            DataTable old_dt = expected.Tables["packagetype"];
            DataTable new_dt = actual.Tables["packagetype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadPBSProgramType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadPBSProgramTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadPBSProgramType();
            DataSet actual;
            actual = target.LoadPBSProgramType();

            DataTable old_dt = expected.Tables["pbsprogramtype"];
            DataTable new_dt = actual.Tables["pbsprogramtype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }


        ///// <summary>
        /////A test for LoadOacPreOfferDescriptionType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("IIS")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadOacPreOfferDescriptionTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadOacPreOfferDescriptionType();
            DataSet actual;
            actual = target.LoadOacPreOfferDescriptionType();

            DataTable old_dt = expected.Tables["oacpreofferdesc"];
            DataTable new_dt = actual.Tables["oacpreofferdesc"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadOacPostOfferDescriptionType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadOacPostOfferDescriptionTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadOacPostOfferDescriptionType();
            DataSet actual;
            actual = target.LoadOacPostOfferDescriptionType();

            DataTable old_dt = expected.Tables["oacpostofferdesc"];
            DataTable new_dt = actual.Tables["oacpostofferdesc"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadMediaStatus
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadMediaStatusTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadMediaStatus();
            DataSet actual;
            actual = target.LoadMediaStatus();

            DataTable old_dt = expected.Tables["mediastatus"];
            DataTable new_dt = actual.Tables["mediastatus"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadMediaInventoryType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadMediaInventoryTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadMediaInventoryType();
            DataSet actual;
            actual = target.LoadMediaInventoryType();

            DataTable old_dt = expected.Tables["mediainventorytype"];
            DataTable new_dt = actual.Tables["mediainventorytype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadMediaFormatType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadMediaFormatTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadMediaFormatType();
            DataSet actual;
            actual = target.LoadMediaFormatType();

            DataTable old_dt = expected.Tables["mediaformattype"];
            DataTable new_dt = actual.Tables["mediaformattype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadMediaFeatureClass
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadMediaFeatureClassTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadMediaFeatureClass();
            DataSet actual;
            actual = target.LoadMediaFeatureClass();

            DataTable old_dt = expected.Tables["mediafeatureclass"];
            DataTable new_dt = actual.Tables["mediafeatureclass"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadMediaFeature
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadMediaFeatureTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadMediaFeature();
            DataSet actual;
            actual = target.LoadMediaFeature();

            DataTable old_dt = expected.Tables["mediafeature"];
            DataTable new_dt = actual.Tables["mediafeature"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadLocalUnderwriting
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadLocalUnderwritingTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadLocalUnderwriting();
            DataSet actual;
            actual = target.LoadLocalUnderwriting();

            DataTable old_dt = expected.Tables["localunderwriting"];
            DataTable new_dt = actual.Tables["localunderwriting"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadLanguage
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadLanguageTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadLanguage();
            DataSet actual;
            actual = target.LoadLanguage();

            DataTable old_dt = expected.Tables["language"];
            DataTable new_dt = actual.Tables["language"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadKeywords
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadKeywordsTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadKeywords();
            DataSet actual;
            actual = target.LoadKeywords();

            DataTable old_dt = expected.Tables["keyword"];
            DataTable new_dt = actual.Tables["keyword"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadHighDefType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadHighDefTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadHighDefType();
            DataSet actual;
            actual = target.LoadHighDefType();

            DataTable old_dt = expected.Tables["highdef"];
            DataTable new_dt = actual.Tables["highdef"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadGenre
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService/")]
        public void LoadGenreTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadGenre(); 
            DataSet actual;
            // make call to WS
            actual = target.LoadGenre();
            
            // pull appropriate datatable from dataset
            DataTable old_dt = expected.Tables["genre"];
            DataTable new_dt = actual.Tables["genre"];

            //List<Genre> oldGenres = new List<Genre>();
            //List<Genre> newGenres = new List<Genre>();
            //newGenres = (from DataRow row in new_dt.Rows
            //             select new Genre
            //             {
            //                 GNR_CODE = row["GNR_CODE"].ToString(),
            //                 GNR_DESC = row["GNR_DESC"].ToString(),
            //                 GNR_ID = int.Parse(row["GNR_ID"].ToString()),
            //                 GNR_ISARCHIVED = short.Parse(row["GNR_ISARCHIVED"].ToString())
            //             }).ToList();

            //oldGenres = (from DataRow row in old_dt.Rows
            //             select new Genre
            //             {
            //                 GNR_CODE = row["GNR_CODE"].ToString(),
            //                 GNR_DESC = row["GNR_DESC"].ToString(),
            //                 GNR_ID = int.Parse(row["GNR_ID"].ToString()),
            //                 GNR_ISARCHIVED = short.Parse(row["GNR_ISARCHIVED"].ToString())
            //             }).ToList();

            //var theta = MemberCompare.Equal(newGenres, oldGenres);

            // test 1 - old_dt.row.count should equal merged.intersect
            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);
            // test 2 - 
            //IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
            //for (var i = 0; i < old_dt.Rows.Count; i++)
            //{
            //    var bEqual = comparer.Equals(old_dt.Rows[i], new_dt.Rows[i]);
            //    if (bEqual)
            //        Debug.WriteLine("Two rows are equal");
            //    else
            //        Debug.WriteLine("Two rows are not equal");

            //    Debug.WriteLine("The hashcodes for the two rows are {0}, {1}", comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
            //}
            
            //var a = theta;

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///// <summary>
        /////A test for LoadFunders
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadFundersTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadFunders();
            DataSet actual;
            actual = target.LoadFunders();

            DataTable old_dt = expected.Tables["funders"];
            DataTable new_dt = actual.Tables["funders"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///// <summary>
        /////A test for LoadFunderType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadFunderTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadFunderType();
            DataSet actual;
            actual = target.LoadFunderType();

            DataTable old_dt = expected.Tables["fundertype"];
            DataTable new_dt = actual.Tables["fundertype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadDistributors
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadDistributorsTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadDistributors();
            DataSet actual;
            actual = target.LoadDistributors();

            DataTable old_dt = expected.Tables["distributors"];
            DataTable new_dt = actual.Tables["distributors"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadDisclaimer
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadDisclaimerTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadDisclaimer();
            DataSet actual;
            actual = target.LoadDisclaimer();

            DataTable old_dt = expected.Tables["disclaimer"];
            DataTable new_dt = actual.Tables["disclaimer"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadCutItemType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadCutItemTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadCutItemType();
            DataSet actual;
            actual = target.LoadCutItemType();

            DataTable old_dt = expected.Tables["cutitemtype"];
            DataTable new_dt = actual.Tables["cutitemtype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadContactType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadContactTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadContactType();
            DataSet actual;
            actual = target.LoadContactType();

            DataTable old_dt = expected.Tables["contacttype"];
            DataTable new_dt = actual.Tables["contacttype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadCompany
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadCompanyTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadCompany();
            DataSet actual;
            actual = target.LoadCompany();

            DataTable old_dt = expected.Tables["company"];
            DataTable new_dt = actual.Tables["company"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadCaptionVendor
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadCaptionVendorTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadCaptionVendor();
            DataSet actual;
            actual = target.LoadCaptionVendor();

            DataTable old_dt = expected.Tables["captionvendor"];
            DataTable new_dt = actual.Tables["captionvendor"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadBillToContact
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadBillToContactTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadBillToContact();
            DataSet actual;
            actual = target.LoadBillToContact();

            DataTable old_dt = expected.Tables["master"];
            DataTable new_dt = actual.Tables["master"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadBillTo
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadBillToTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadBillTo();
            DataSet actual;
            actual = target.LoadBillTo();

            DataTable old_dt = expected.Tables["master"];
            DataTable new_dt = actual.Tables["master"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadAudioType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadAudioTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadAudioType();
            DataSet actual;
            actual = target.LoadAudioType();

            DataTable old_dt = expected.Tables["audiotype"];
            DataTable new_dt = actual.Tables["audiotype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadAssetCategory
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadAssetCategoryTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadAssetCategory();
            DataSet actual;
            actual = target.LoadAssetCategory();

            DataTable old_dt = expected.Tables["assetcategory"];
            DataTable new_dt = actual.Tables["assetcategory"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadAspectRatioType
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadAspectRatioTypeTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadAspectRatioType();
            DataSet actual;
            actual = target.LoadAspectRatioType();

            DataTable old_dt = expected.Tables["aspectratiotype"];
            DataTable new_dt = actual.Tables["aspectratiotype"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for LoadAlliantContractModels
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void LoadAlliantContractModelsTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            DataSet expected = oldTarget.LoadAlliantContractModels();
            DataSet actual;
            actual = target.LoadAlliantContractModels();

            DataTable old_dt = expected.Tables["alliantcontractmodel"];
            DataTable new_dt = actual.Tables["alliantcontractmodel"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for ListTabMapByDeal
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ListTabMapByDealTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealId = 24381484; // TODO: Initialize to an appropriate value
            
            //int nDealID = 252145556; // This is the master deal id you created in CreateProgramTest
            DataSet expected = target.ListTabMapByDeal(strSessionID, nDealId);
            DataSet actual = oldTarget.ListTabMapByDeal(strSessionID, nDealId);

            DataTable old_dt = expected.Tables["tabmap"];
            DataTable new_dt = actual.Tables["tabmap"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for ListProgramPackagesByProgram
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ListProgramPackagesByProgramTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nProgramID = 252145546; // TODO: Initialize to an appropriate value
            DataSet expected = oldTarget.ListProgramPackagesByProgram(strSessionID, nProgramID);
            DataSet actual = target.ListProgramPackagesByProgram(strSessionID, nProgramID);

            DataTable old_dt = expected.Tables["version"];
            DataTable new_dt = actual.Tables["version"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for ListProgramByDeal
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ListProgramByDealTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nDealID = 252145554;
            DataSet expected = oldTarget.ListProgramByDeal(strSessionID, nDealID);
            DataSet actual = target.ListProgramByDeal(strSessionID, nDealID);

            DataTable old_dt = expected.Tables["asset"]; //Also Version
            DataTable new_dt = actual.Tables["asset"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for ListPAADeadline
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ListPAADeadlineTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nDealStatus = 1002; // TODO: Initialize to an appropriate value
            DataSet expected = oldTarget.ListPAADeadline(strSessionID, nDealStatus);
            DataSet actual = target.ListPAADeadline(strSessionID, nDealStatus);

            DataTable old_dt = expected.Tables["paa_deadline_temp"];
            DataTable new_dt = actual.Tables["paa_deadline_temp"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for ListMissingVersionFormDeadline
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ListMissingVersionFormDeadlineTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            DataSet expected = oldTarget.ListMissingVersionFormDeadline(strSessionID);
            DataSet actual = target.ListMissingVersionFormDeadline(strSessionID);

            DataTable old_dt = expected.Tables["form_deadline_temp"];
            DataTable new_dt = actual.Tables["form_deadline_temp"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());

            
        }

        ///// <summary>
        /////A test for ListMissingEpisodeFormDeadline
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ListMissingEpisodeFormDeadlineTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            DataSet expected = oldTarget.ListMissingEpisodeFormDeadline(strSessionID);
            DataSet actual = target.ListMissingEpisodeFormDeadline(strSessionID);

            DataTable old_dt = expected.Tables["form_deadline_temp"];
            DataTable new_dt = actual.Tables["form_deadline_temp"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for ListFormDeadline
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ListFormDeadlineTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nDealStatus = 1002; // TODO: Initialize to an appropriate value
            DataSet expected = oldTarget.ListFormDeadline(strSessionID, nDealStatus);
            DataSet actual = target.ListFormDeadline(strSessionID, nDealStatus);

            DataTable old_dt = expected.Tables["form_deadline_temp"];
            DataTable new_dt = actual.Tables["form_deadline_temp"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for ListDealsByMasterDeal
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void ListDealsByMasterDealTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nDealID = 252145556; // This is the master deal id you created in CreateProgramTest
            DataSet expected = oldTarget.ListDealsByMasterDeal(strSessionID, nDealID);
            DataSet actual= target.ListDealsByMasterDeal(strSessionID, nDealID);

            DataTable old_dt = expected.Tables["deal"];
            DataTable new_dt = actual.Tables["deal"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }
        

        ///// <summary>
        /////A test for GetVisualArt
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetVisualArtTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nVisualArtID = 279; // Grab a value from PBSVISUALART
            bool bLockFlag = false; // Set to true if you need to modify a record.
            string strLockID = string.Empty; 
            string strLockIDExpected = string.Empty; 

            DataSet expected = oldTarget.GetVisualArt(out strLockID, strSessionID, nVisualArtID, bLockFlag);
            DataSet actual = target.GetVisualArt(out strLockID, strSessionID, nVisualArtID, bLockFlag);

            DataTable old_dt = expected.Tables["VISUALART"];
            DataTable new_dt = actual.Tables["VISUALART"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());       
        }

        ///// <summary>
        /////A test for GetUCC
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetUCCTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nUCCID = 801; // TODO: Initialize to an appropriate value
            bool bLockFlag = false; // Set to true if you need to modify a record.
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            DataSet expected = oldTarget.GetUCC(out strLockIDExpected, strSessionID, nUCCID, bLockFlag);
            DataSet actual = target.GetUCC(out strLockID, strSessionID, nUCCID, bLockFlag);

            DataTable old_dt = expected.Tables["UCC"];
            DataTable new_dt = actual.Tables["UCC"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());     
        }

        ///// <summary>
        /////A test for GetTalent
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetTalentTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nDealID = 3399613; // Ideally this should be the deal you created in createprogram
            int nTalentID = 3271462; // Look in ASSET_TALENT if you are having trouble finding valid values for all three
            int nRoleID = 3262458; // Talentroles is the lookup table

            DataSet dEpisodeTalent = null;
            DataSet dEpisodeTalentExpected = null;
            DataSet dTalent = null;
            DataSet dTalentExpected = null;

            DataSet actual = target.GetTalent(out dEpisodeTalent, out dTalent, strSessionID, nDealID, nTalentID, nRoleID);
            DataSet expected = oldTarget.GetTalent(out dEpisodeTalentExpected, out dTalentExpected, strSessionID, nDealID, nTalentID, nRoleID);

            DataTable old_dt = expected.Tables["EPISODEAPPTO"];
            DataTable new_dt = actual.Tables["EPISODEAPPTO"];

            DataTable old_EPISODETALENT_dt = dEpisodeTalentExpected.Tables["EPISODETALENT"];
            DataTable new_EPISODETALENT_dt = dEpisodeTalent.Tables["EPISODETALENT"];

            DataTable old_TALENT_dt = dTalentExpected.Tables["TALENT"];
            DataTable new_TALENT_dt = dTalent.Tables["TALENT"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            var combinedResults_EPISODETALENT = old_EPISODETALENT_dt.AsEnumerable().Intersect(new_EPISODETALENT_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            var combinedResults_TALENT = old_TALENT_dt.AsEnumerable().Intersect(new_TALENT_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            Assert.AreEqual(old_EPISODETALENT_dt.Rows.Count, combinedResults_EPISODETALENT.Count());
            Assert.AreEqual(old_TALENT_dt.Rows.Count, combinedResults_TALENT.Count());
        }

        ///// <summary>
        /////A test for GetProgramDetails
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetProgramDetailsTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nProgramID = 24381487;
            bool bLockFlag = false;
            bool bGetPremiereDate = true;
            string strLockID = string.Empty; 
            string strLockIDExpected = string.Empty; 

            DataSet actual = target.GetProgramDetails(out strLockID, strSessionID, nProgramID, bLockFlag, bGetPremiereDate);
            DataSet expected = oldTarget.GetProgramDetails(out strLockIDExpected, strSessionID, nProgramID, bLockFlag, bGetPremiereDate);

            DataTable old_dt = expected.Tables["ASSET"];
            DataTable new_dt = actual.Tables["ASSET"];

            DataTable old_CASTTABLE_dt = expected.Tables["CASTTABLE"];
            DataTable new_CASTTABLE_dt = actual.Tables["CASTTABLE"];

            DataTable old_KEYWORD_dt = expected.Tables["ASSET_PBSPROGRAMKEYWORD"];
            DataTable new_KEYWORD_dt = actual.Tables["ASSET_PBSPROGRAMKEYWORD"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            var combinedResults_CASTTABLE = old_CASTTABLE_dt.AsEnumerable().Intersect(new_CASTTABLE_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            var combinedResults_KEYWORD = old_KEYWORD_dt.AsEnumerable().Intersect(new_KEYWORD_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            Assert.AreEqual(old_CASTTABLE_dt.Rows.Count, combinedResults_CASTTABLE.Count());
            Assert.AreEqual(old_KEYWORD_dt.Rows.Count, combinedResults_KEYWORD.Count());
        }

        ///// <summary>
        /////A test for GetPackageAppliesToRangeByTab
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetPackageAppliesToRangeByTabTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nTabID = 312;
            string strTabType = "OAC"; 

            DataSet actual = target.GetPackageAppliesToRangeByTab(strSessionID, nTabID, strTabType);
            DataSet expected = oldTarget.GetPackageAppliesToRangeByTab(strSessionID, nTabID, strTabType);

            DataTable old_dt = expected.Tables["PROGRAMS"];
            DataTable new_dt = actual.Tables["PROGRAMS"];

            DataTable old_RANGE_dt = expected.Tables["VW_VERSIONAPPLIESTORANGE"];
            DataTable new_RANGE_dt = actual.Tables["VW_VERSIONAPPLIESTORANGE"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);
            var combinedResults_RANGE = old_RANGE_dt.AsEnumerable().Intersect(new_RANGE_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            Assert.AreEqual(old_RANGE_dt.Rows.Count, combinedResults_RANGE.Count());
        }

        ///// <summary>
        /////A test for GetPackage
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetPackageTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nPackageID = 4042311; // SELECT * FROM version where ver_ass_id = your asset id 
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;

            DataSet actual = target.GetPackage(out strLockID, strSessionID, nPackageID, bLockFlag);
            DataSet expected = oldTarget.GetPackage(out strLockIDExpected, strSessionID, nPackageID, bLockFlag);

            DataTable old_dt = expected.Tables["PACKAGE"];
            DataTable new_dt = actual.Tables["PACKAGE"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            
        }

        ///// <summary>
        /////A test for GetOAC
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetOACTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nOACID = 213;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;

            DataSet actual = target.GetOAC(out strLockID, strSessionID, nOACID, bLockFlag);
            DataSet expected = oldTarget.GetOAC(out strLockIDExpected, strSessionID, nOACID, bLockFlag);
            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            
            DataTable old_OAC_dt = expected.Tables["OAC"];
            DataTable new_OAC_dt = actual.Tables["OAC"];

            DataTable old_OACITEM_dt = expected.Tables["PBSOACITEM"];
            DataTable new_OACITEM_dt = actual.Tables["PBSOACITEM"];

            DataTable old_OACENTITY_dt = expected.Tables["VW_PBSOACENTITY"];
            DataTable new_OACENTITY_dt = actual.Tables["VW_PBSOACENTITY"];

            var combinedResults = old_OAC_dt.AsEnumerable().Intersect(new_OAC_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            var combinedResults_ITEM = old_OACITEM_dt.AsEnumerable().Intersect(new_OACITEM_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            var combinedResults_ENTITY = old_OACENTITY_dt.AsEnumerable().Intersect(new_OACENTITY_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_OAC_dt.Rows.Count, combinedResults.Count());
            Assert.AreEqual(old_OACITEM_dt.Rows.Count, combinedResults_ITEM.Count());
            Assert.AreEqual(old_OACENTITY_dt.Rows.Count, combinedResults_ENTITY.Count());
        }

        ///// <summary>
        /////A test for GetMusicCue
        /////</summary>
        [TestMethod()]
        public void GetMusicCueTest()
        {
            DataSet expected = new DataSet();
            DataSet actual;
            int nMusicCueID = 352; // PMC_ID 
            bool bLockFlag = false; // Edit is true, get is false
            string strLockID = string.Empty; // TODO: is this necessary??

            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            
            // Create new object 
            List<MUSICCUE> compareMusicCue = new List<MUSICCUE>();
            MUSICCUE tmpMusicCue = new MUSICCUE
            {
                PMC_ID = 352,
                PMC_DEA_ID = 8521638,
                PMC_FORMSTATUS = 30
            };
            compareMusicCue.Add(tmpMusicCue);

            // Convert your new object into a datatable
            DataTable table1 = new DataTable();
            table1 = ConvertTo(compareMusicCue);                                 
            expected.Tables.Add(table1);

            // Preform the web service call 
            actual = target.GetMusicCue(out strLockID, strSessionID, nMusicCueID, bLockFlag);
            
            // We have to do an homegrown compare because we are dealing with datasets
            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
            DataTable old_dt = expected.Tables["musiccue"];
            DataTable new_dt = actual.Tables["musiccue"];
            Assert.AreEqual(comparer.GetHashCode(old_dt.Rows[0]), comparer.GetHashCode(new_dt.Rows[0]));
            //
        }

        ///// <summary>
        /////A test for GetMediaInventoryRevision
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetMediaInventoryRevisionTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nMediaInventoryRevisionID = 3838052; // TODO: Initialize to an appropriate value
            bool bLockFlag = false;
            string strLockID = string.Empty; 
            string strLockIDExpected = string.Empty;
            
            DataSet actual = target.GetMediaInventoryRevision(out strLockID, strSessionID, nMediaInventoryRevisionID, bLockFlag);
            DataSet expected = oldTarget.GetMediaInventoryRevision(out strLockIDExpected, strSessionID, nMediaInventoryRevisionID, bLockFlag);

            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            DataTable old_dt = expected.Tables["MEDIAINVENTORYREVISION"];
            DataTable new_dt = actual.Tables["MEDIAINVENTORYREVISION"];

            DataTable old_MICUT_dt = expected.Tables["MEDIAINVENTORYCUT"];
            DataTable new_MICUT_dt = actual.Tables["MEDIAINVENTORYCUT"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            var combinedResults_CUT = old_MICUT_dt.AsEnumerable().Intersect(new_MICUT_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            Assert.AreEqual(old_MICUT_dt.Rows.Count, combinedResults_CUT.Count());
        }
        

        ///// <summary>
        /////A test for GetMasterDeal
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetMasterDealTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string strLimitingDate = new DateTime(2013, 7, 1).ToString("MM/DD/YYYY");

            DataSet actual = target.GetMasterDeal(strSessionID, strLimitingDate);
            DataSet expected = oldTarget.GetMasterDeal(strSessionID, strLimitingDate);

            DataTable old_dt = expected.Tables["MASTERDEAL"];
            DataTable new_dt = actual.Tables["MASTERDEAL"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///// <summary>
        /////A test for GetIWT
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetIWTTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nIWTID = 432;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;

            DataSet actual = target.GetIWT(out strLockID, strSessionID, nIWTID, bLockFlag);
            DataSet expected = oldTarget.GetIWT(out strLockID, strSessionID, nIWTID, bLockFlag);
            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            DataTable old_IWT_dt = expected.Tables["IWT"];
            DataTable new_IWT_dt = actual.Tables["IWT"];

            DataTable old_IWTDETAIL_dt = expected.Tables["PBSIWTDETAIL"];
            DataTable new_IWTDETAIL_dt = actual.Tables["PBSIWTDETAIL"];

            var combinedResults_IWT = old_IWT_dt.AsEnumerable().Intersect(new_IWT_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            var combinedResults_DETAIL = old_IWTDETAIL_dt.AsEnumerable().Intersect(new_IWTDETAIL_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_IWT_dt.Rows.Count, combinedResults_IWT.Count());
            Assert.AreEqual(old_IWTDETAIL_dt.Rows.Count, combinedResults_DETAIL.Count());
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }


        ///// <summary>
        /////A test for GetFormatSheet
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetFormatSheetTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nFormatSheetID = 20; // TODO: Initialize to an appropriate value
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;

            DataSet actual = target.GetFormatSheet(out strLockID, strSessionID, nFormatSheetID, bLockFlag);
            DataSet expected = oldTarget.GetFormatSheet(out strLockID, strSessionID, nFormatSheetID, bLockFlag);

            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            DataTable old_dt = expected.Tables["FORMATSHEET"];
            DataTable new_dt = actual.Tables["FORMATSHEET"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///// <summary>
        /////A test for GetFeatureMediaInventory
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetFeatureMediaInventoryTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nFeatureMediaInventoryID = 14969775; // TODO: No clue what makes a valid media inventory id 
            bool bLockFlag = false;
            string strLockID = string.Empty; 
            string strLockIDExpected = string.Empty;
            
            DataSet actual = target.GetFeatureMediaInventory(out strLockID, strSessionID, nFeatureMediaInventoryID, bLockFlag);
            DataSet expected = oldTarget.GetFeatureMediaInventory(out strLockID, strSessionID, nFeatureMediaInventoryID, bLockFlag);
            // We arent making any edits to this record so we wont get an lockID
            //Assert.AreEqual(strLockIDExpected, strLockID);
            DataTable old_dt = expected.Tables["FEATUREMEDIAINVENTORY"];
            DataTable new_dt = actual.Tables["FEATUREMEDIAINVENTORY"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///// <summary>
        /////A test for GetDiscrepancyProgram
        /////</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDiscrepancyProgramTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string sChannel = "HD01";
            string sDicrepancyStartDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
            string sPackageID = string.Empty;
            string sPackageIDExpected = string.Empty;
            string sPackagenumber;
            string sPackagenumberExpected = string.Empty;
            string sPackageTile;
            string sPackageTileExpected = string.Empty;
            string sProgramTile;
            string sProgramTileExpected = string.Empty;
            string sSeriesTile;
            string sSeriesTileExpected = string.Empty;
            string sProgramEpisodeTitle;
            string sProgramEpisodeTitleExpected = string.Empty;
            DateTime dSchedDateTime = new DateTime();
            DateTime dSchedDateTimeExpected = new DateTime();
            int nSchedDuration = 0;
            int nSchedDurationExpected = 0;
            sPackageID = target.GetDiscrepancyProgram(out sPackagenumber, out sPackageTile, out sProgramTile, out sSeriesTile, 
                out sProgramEpisodeTitle, out dSchedDateTime, out nSchedDuration, sChannel, sDicrepancyStartDate);
            sPackageIDExpected = oldTarget.GetDiscrepancyProgram(out sPackagenumberExpected, out sPackageTileExpected, out sProgramTileExpected, 
                out sSeriesTileExpected, out sProgramEpisodeTitleExpected, out dSchedDateTimeExpected, out nSchedDurationExpected, sChannel, sDicrepancyStartDate);
            Assert.AreEqual(sPackageIDExpected, sPackageID);
            Assert.AreEqual(sPackagenumberExpected, sPackagenumber);
            Assert.AreEqual(sPackageTileExpected, sPackageTile);
            Assert.AreEqual(sProgramTileExpected, sProgramTile);
            Assert.AreEqual(sSeriesTileExpected, sSeriesTile);
            Assert.AreEqual(sProgramEpisodeTitleExpected, sProgramEpisodeTitle);
            Assert.AreEqual(dSchedDateTimeExpected, dSchedDateTime);
            Assert.AreEqual(nSchedDurationExpected, nSchedDuration);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///// <summary>
        /////A test for GetDealWithTechnical
        /////</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealWithTechnicalTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealID = 250154628; // TODO: Initialize to an appropriate value
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDealWithTechnical(out strLockID, strSessionID, nDealID, bLockFlag);
            DataSet actual = target.GetDealWithTechnical(out strLockIDExpected, strSessionID, nDealID, bLockFlag);

            DataTable old_dt = expected.Tables["DEALVERSIONTYPE"];
            DataTable new_dt = actual.Tables["DEALVERSIONTYPE"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for GetDealWithRights
        /////</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealWithRightsTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealID = 250154628; // TODO: Initialize to an appropriate value
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDealWithRights(out strLockID, strSessionID, nDealID, bLockFlag);
            DataSet actual = target.GetDealWithRights(out strLockIDExpected, strSessionID, nDealID, bLockFlag);

            DataTable old_dt = expected.Tables["DEALCONTENT"];
            DataTable new_dt = actual.Tables["DEALCONTENT"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for GetDealWithGeneral
        /////</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealWithGeneralTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nDealID = 250154628; // TODO: Initialize to an appropriate value
            bool bLockFlag = false; 
            string strLockID = string.Empty; 
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDealWithGeneral(out strLockID, strSessionID, nDealID, bLockFlag);
            DataSet actual = target.GetDealWithGeneral(out strLockIDExpected, strSessionID, nDealID, bLockFlag);

            DataTable old_dt = expected.Tables["PBSDEALCONTACT"];
            DataTable new_dt = actual.Tables["PBSDEALCONTACT"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for GetDealWithFunding_DealDataTable
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealWithFunding_DealDataTableTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            // To find a valid nDealID perform the following query
            // SELECT DEA_ID FROM DEAL WHERE dea_isArchived = 0
            int nDealID = 250154628;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);      
            DataSet actual = target.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);      

            DataTable old_dt = expected.Tables["DEAL"];
            DataTable new_dt = actual.Tables["DEAL"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());      
        }

        ///// <summary>
        /////A test for GetDealWithFunding_MasterDealDataTable
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealWithFunding_MasterDealDataTableTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            // To find a valid nDealID perform the following query
            // SELECT DEA_ID FROM DEAL WHERE dea_isArchived = 0
            int nDealID = 250154628;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);
            DataSet actual = target.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);

            DataTable old_dt = expected.Tables["MASTERDEAL"];
            DataTable new_dt = actual.Tables["MASTERDEAL"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for GetDealWithFunding_MasterDealFundingDataTable
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealWithFunding_MasterDealFundingDataTableTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            // To find a valid nDealID perform the following query
            // SELECT DEA_ID FROM DEAL WHERE dea_isArchived = 0
            int nDealID = 250154628;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);
            DataSet actual = target.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);

            DataTable old_dt = expected.Tables["MASTERDEALFUNDING"];
            DataTable new_dt = actual.Tables["MASTERDEALFUNDING"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for GetDealWithFunding_DealFundingDataTable
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealWithFunding_DealFundingDataTableTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            // To find a valid nDealID perform the following query
            // SELECT DEA_ID FROM DEAL WHERE dea_isArchived = 0
            int nDealID = 250154628;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);
            DataSet actual = target.GetDealWithFunding(out strLockID, strSessionID, nDealID, bLockFlag);

            DataTable old_dt = expected.Tables["DEALFUNDING"];
            DataTable new_dt = actual.Tables["DEALFUNDING"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        ///// <summary>
        /////A test for GetDealAll
        /////</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealAllTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            // To find a valid nDealID perform the following query
            // SELECT DEA_ID FROM DEAL WHERE dea_isArchived = 1
            int nDealID = 3392615;
            bool bLockFlag = false;
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDealAll(out strLockID, strSessionID, nDealID, bLockFlag);
            DataSet actual = target.GetDealAll(out strLockIDExpected, strSessionID, nDealID, bLockFlag);

            DataTable old_dt = expected.Tables["DEAL"];
            DataTable new_dt = actual.Tables["DEAL"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());  
        }

        ///// <summary>
        /////A test for GetDeal
        /////</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetDealTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            // To find a valid nDealID perform the following query
            // SELECT DEA_ID FROM DEAL WHERE dea_isArchived = 0
            int nDealID = 141533907;
            bool bLockFlag = false; 
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            ///////////////////////////////////
            DataSet expected = oldTarget.GetDeal(out strLockID, strSessionID, nDealID, bLockFlag);
            DataSet actual = target.GetDeal(out strLockIDExpected, strSessionID, nDealID, bLockFlag);

            DataTable old_dt = expected.Tables["DEAL"];
            DataTable new_dt = actual.Tables["DEAL"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());  
        }

        ///// <summary>
        /////A test for GetBarCode
        /////</summary>
        //// TODO: Currently these methods will timeout when called from the test harness or the 
        //// VB Form
        //// 
        [TestMethod()]
        public void GetBarCodeTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int nMediaInventoryID = 251904161;
            byte[] bBarCode = null; 
            byte[] bBarCodeExpected = null; 
            bBarCode = target.GetBarCode(strSessionID, nMediaInventoryID);
            bBarCodeExpected = oldTarget.GetBarCode(strSessionID, nMediaInventoryID);
            //bool areEqual = bBarCode.SequenceEqual(bBarCodeExpected);
            Assert.AreEqual(bBarCodeExpected, bBarCode);
        }
                

        ///// <summary>
        /////A test for CreateMediaInventoryRevision
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        //[TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        //public void CreateMediaInventoryRevisionTest()
        //{
        //   BVWebService.BVWebServiceSoapClient target = new BVWebService.BVWebServiceSoapClient();// TODO: Initialize to an appropriate value
        //    string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
        //    string strLockId = string.Empty; // TODO: Initialize to an appropriate value
        //    int nOldMediaInventoryID = 0; // TODO: Initialize to an appropriate value
        //    int nNewMediaInventoryRevisionID = 0; // TODO: Initialize to an appropriate value
        //    target.CreateMediaInventoryRevision(strSessionID, strLockId, nOldMediaInventoryID, nNewMediaInventoryRevisionID);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        ///// <summary>
        /////A test for CreateProgram
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void CreateProgramTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            //BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            int[] testIDs = target.GetIDs(6);
            int nMasterDealID = testIDs[5];
            int[] nProgramIDs = new int[4];

            SearchCriterion[] sCriterion = new SearchCriterion[1];
            sCriterion[0] = new SearchCriterion();
            sCriterion[0].SearchField = "program_title";
            sCriterion[0].SearchValue = "%BV API Master Deal Title%";

            DataSet searchResults = target.ProgramSearch(m_newBVSessionId, sCriterion, 10);
            //var foo = searchResults;
            //string strMasterDealTitle = "BV API Master Deal Title"; // No idea what the char limit is here or what is a valid char
            //string strSeason = DateTime.Now.ToString("yyyy"); // Season Year
            //int nDealID = testIDs[4];
            //string strDealDesc = "Some really exciting test description"; - Asset Title
            //string strDealSynopsis = "Some really exciting test synopsis";
            //int nPBSProgramTypeID = 0; // Verified from Orion UI form that this remains zero 
            //int nUpLinkID = 3177866; // PBS SOC
            //Array.Copy(testIDs, nProgramIDs, 4); // GetIDs(4) 
            //int nProgramTypeID = 3163744; // ACA_ID in AssetCategory table - Miniseries
            //int nDuration = 1800; // Duration is in seconds - 1800, 3600, 5400, 7200 are all valid amounts
            //string strNolaRoot = "TAPI"; // Our test NOLA root
            //int nFirstEpisodeNumber = 1;
            //int nIncrement = 1;
            //int nDistributorID = 3136739; // PBS Distributor ID
            //int nGenreID = 3261515; // GNR_ID from the Genre table
            //bool bLive = false;
            //bool bRecord = false;
            //int nDefaultRatingID = 3124915; // RAT_ID from Ratings table
            //int nDisclaimerID = 3125145; // DIS_ID from Disclaimer table
            //string strFirstPictureLockDate = DateTime.Today.AddDays(7).ToString("YYYYY-MM-DD"); // Date format of YYYY-MM-DD.  Has to be in the future
            //int nOperatingUnit = 369; //PBSOU_CODE in PBSOPERATINGUNIT table  this pairs with the strOperatingGroup
            //string strOperatingGroup = ""; //PBSOU_DESC in PBSOPERATINGUNIT table - This comes through as blank in the UI
            //int nAssetVChipID = Convert.ToInt32(-120); // VCH_ID in VCHIP table

            //Packages[] cPackages = new Packages[2]; // TODO: Initialize to an appropriate value

            //var SDPackage = new Packages();
            //SDPackage.FormatAndTypeID = 1;
            //SDPackage.Length = 1606; // this might be seconds 
            //SDPackage.VchipID = nAssetVChipID;
            //SDPackage.IsVCHIPEmbedded = 0;
            //SDPackage.IsEiQualified = 0;
            //SDPackage.IsEiEmbedded = 0;
            //cPackages[0] = SDPackage;

            //var HDPackage = new Packages();
            //HDPackage.FormatAndTypeID = 2;
            //HDPackage.Length = 1606; // this might be seconds 
            //HDPackage.VchipID = nAssetVChipID;
            //HDPackage.IsVCHIPEmbedded = 0;
            //HDPackage.IsEiQualified = 0;
            //HDPackage.IsEiEmbedded = 0;
            //cPackages[1] = HDPackage;

            //string sAssetEpisodeTitle = ""; // This is blank in the UI
            //string sAssetTitleString = "BV API Asset Title String"; // TODO: Initialize to an appropriate value
            //bool p_bIsFinalTitle = false;
            //bool p_bSDRightsFlag = true; // I believe these relate to the Packages array??
            //bool p_bHDRightsFlag = true;
            //target.CreateProgram(strSessionID, nMasterDealID, strMasterDealTitle, strSeason, nDealID, strDealDesc, strDealSynopsis, nPBSProgramTypeID, nUpLinkID, nProgramIDs, nProgramTypeID, nDuration, strNolaRoot, nFirstEpisodeNumber, nIncrement, nDistributorID, nGenreID, bLive, bRecord, nDefaultRatingID, nDisclaimerID, strFirstPictureLockDate, nOperatingUnit, strOperatingGroup, cPackages, nAssetVChipID, sAssetEpisodeTitle, sAssetTitleString, p_bIsFinalTitle, p_bSDRightsFlag, p_bHDRightsFlag);

            DataSet newSearchResults = target.ProgramSearch(m_newBVSessionId, sCriterion, 10);

            DataTable old_dt = searchResults.Tables["ProgramSearch"];
            DataTable new_dt = newSearchResults.Tables["ProgramSearch"];
            
            Assert.AreNotEqual(old_dt.Rows.Count, new_dt.Rows.Count);
        }

        ///// <summary>
        /////A test for AdCopySearch
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void AdCopySearchTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;

            SearchCriterion[] SearchCriteria = new SearchCriterion[5];
            BVWebServiceOld.SearchCriterion[] oldSearchCriteria = new BVWebServiceOld.SearchCriterion[5];

            List<string> adCopySearchTerms = new List<string>();
            adCopySearchTerms.Add("Title");
            adCopySearchTerms.Add("Duration");
            adCopySearchTerms.Add("Underwriter_Id");
            adCopySearchTerms.Add("Is_Approved");
            adCopySearchTerms.Add("EXCLUDEINUSE");
            for (var i = 0; i < SearchCriteria.Count(); i++)
            {
                SearchCriteria[i] = new SearchCriterion();
                oldSearchCriteria[i] = new BVWebServiceOld.SearchCriterion();
                SearchCriteria[i].SearchField = adCopySearchTerms[i];
                oldSearchCriteria[i].SearchField = adCopySearchTerms[i];
            }

            oldSearchCriteria[0].SearchValue = "%red%"; // TODO: Initialize to an appropriate value
            oldSearchCriteria[1].SearchValue = "";
            oldSearchCriteria[2].SearchValue = "";
            oldSearchCriteria[3].SearchValue = "";
            oldSearchCriteria[4].SearchValue = "";

            SearchCriteria[0].SearchValue = "%red%"; // TODO: Initialize to an appropriate value
            SearchCriteria[1].SearchValue = "";
            SearchCriteria[2].SearchValue = "";
            SearchCriteria[3].SearchValue = "";
            SearchCriteria[4].SearchValue = "";

            int nMaxRows = 10; 

            DataSet actual = target.AdCopySearch(strSessionID, SearchCriteria, nMaxRows);
            DataSet expected = oldTarget.AdCopySearch(strSessionID, oldSearchCriteria, nMaxRows);

            DataTable old_dt = expected.Tables["ADCOPYSEARCH"];
            DataTable new_dt = actual.Tables["ADCOPYSEARCH"];

            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
            for (var i = 0; i < old_dt.Rows.Count; i++)
            {
                var bEqual = comparer.Equals(old_dt.Rows[i], new_dt.Rows[i]);
                if (bEqual)
                    Debug.WriteLine("Two rows are equal");
                else
                    Debug.WriteLine("Two rows are not equal");

                Debug.WriteLine("The hashcodes for the two rows are {0}, {1}", comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
                Assert.AreEqual(comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
            }
        }

        ///// <summary>
        /////A test for DealSearch
        /////</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void DealSearchTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            SearchCriterion[] SearchCriteria = new SearchCriterion[2];
            BVWebServiceOld.SearchCriterion[] oldSearchCriteria = new BVWebServiceOld.SearchCriterion[2];

            List<string> dealSearchTerms = new List<string>();
            dealSearchTerms.Add("sub_deal_season");
            dealSearchTerms.Add("sub_deal_description");
            for (var i = 0; i < SearchCriteria.Count(); i++)
            {
                SearchCriteria[i] = new SearchCriterion();
                oldSearchCriteria[i] = new BVWebServiceOld.SearchCriterion();
                SearchCriteria[i].SearchField = dealSearchTerms[i];
                oldSearchCriteria[i].SearchField = dealSearchTerms[i];
            }

            oldSearchCriteria[0].SearchValue = "1";
            oldSearchCriteria[1].SearchValue = "";
  
            SearchCriteria[0].SearchValue = "1";
            SearchCriteria[1].SearchValue = "";
            int nMaxRows = 10; // TODO: Initialize to an appropriate value
            
            DataSet actual = target.DealSearch(strSessionID, SearchCriteria, nMaxRows);
            DataSet expected = oldTarget.DealSearch(strSessionID, oldSearchCriteria, nMaxRows);

            DataTable old_dt = expected.Tables["DEALSEARCH"];
            DataTable new_dt = actual.Tables["DEALSEARCH"];

            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;
            for (var i = 0; i < old_dt.Rows.Count; i++)
            {
                var bEqual = comparer.Equals(old_dt.Rows[i], new_dt.Rows[i]);
                if (bEqual)
                    Debug.WriteLine("Two rows are equal");
                else
                    Debug.WriteLine("Two rows are not equal");

                Debug.WriteLine("The hashcodes for the two rows are {0}, {1}", comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));
                Assert.AreEqual(comparer.GetHashCode(old_dt.Rows[i]), comparer.GetHashCode(new_dt.Rows[i]));  
            }
        }


        ///// <summary>
        /////A test for GetAdCopy
        /////</summary>
        //// TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        //// http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        //// whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetAdCopyTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nAdCopyId = 23011537; // TODO: Need to find an ID that returns results
            bool bLockFlag = false; 
            string strLockID = string.Empty; 

            DataSet expected = oldTarget.GetAdCopy(out strLockID, strSessionID, nAdCopyId, bLockFlag);
            DataSet actual = target.GetAdCopy(out strLockID, strSessionID, nAdCopyId, bLockFlag);

            DataTable old_dt = expected.Tables["ADCOPY"];
            DataTable new_dt = actual.Tables["ADCOPY"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        ///// <summary>
        /////A test for GetAssetAppliesToRangeByTab
        /////</summary>
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[UrlToTest("http://localhost/BVWebService")]
        public void GetAssetAppliesToRangeByTabTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nTabID = 952; // TODO: Create a helper class to grab a random value from BV
            string strTabType = "MUS"; // Either MUS or VIS
            ///////////////////////////////////
            DataSet expected = oldTarget.GetAssetAppliesToRangeByTab(strSessionID, nTabID, strTabType);
            DataSet actual = target.GetAssetAppliesToRangeByTab(strSessionID, nTabID, strTabType);

            DataTable old_dt = expected.Tables["ASSETAPPLIESTORANGE"];
            DataTable new_dt = actual.Tables["ASSETAPPLIESTORANGE"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());         
        }

        [TestMethod()]
        [ExpectedException(typeof(CommunicationException))]
        public void GetLockedDealOnRevisedWSExceptionTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();            
            string strSessionID = m_newBVSessionId;
            bool bLockFlag = true;
            string strLockID = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;
            int nDealID = 220466854;

            DataSet toLock = target.GetDeal(out strLockID, strSessionID, nDealID, bLockFlag);
            DataTable dealDataTable = toLock.Tables["DEAL"];

            DataSet toFail = target.GetDeal(out strLockID, strSessionID, nDealID, false);
            DataTable dealFailDataTable = toFail.Tables["DEAL"];
            target.ReleaseLock(strSessionID, strLockID);
            target.CloseSession(strSessionID);
        }

        [TestMethod()]
        [ExpectedException(typeof(CommunicationException))]
        public void GetLockedDealOnOldWSExceptionTest()
        {
            // Establish Session to communicate with web service method
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            bool bLockFlag = true;
            string strLockID = string.Empty;
            string expected = string.Empty;
            string actual = string.Empty;
            int nDealID = 220466854;

            DataSet toLock = oldTarget.GetDeal(out strLockID, strSessionID, nDealID, bLockFlag);
            DataTable dealDataTable = toLock.Tables["DEAL"];

            DataSet toFail = oldTarget.GetDeal(out strLockID, strSessionID, nDealID, bLockFlag);
            DataTable dealFailDataTable = toFail.Tables["DEAL"];
            oldTarget.ReleaseLock(strSessionID, strLockID);
            oldTarget.CloseSession(strSessionID);
        }
    }
}
