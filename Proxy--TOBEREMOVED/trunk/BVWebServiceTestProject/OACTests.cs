using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BVWebServiceTestProject.BVWebServiceWS;
using System.Data;
using System.Diagnostics;

namespace BVWebServiceTestProject
{
    /// <summary>
    /// Summary description for OACTests
    /// </summary>
    [TestClass]
    public class OACTests
    {
        private static string m_newBVSessionId;
        private static int[] IDs;
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
        // You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            UserProfile oUserProfile = new UserProfile();

            oUserProfile.sConnectId = "brboggio";
            oUserProfile.sExternalEmail = "brboggio@pbs.org";
            oUserProfile.sFirstName = "bryan";
            oUserProfile.sLastName = "boggio";
            oUserProfile.oOperatingGroup = new string[] { "Administrators", "Users" };
            oUserProfile.nOperatingUnit = 369;
            oUserProfile.nUnitType = 1;
            oUserProfile.sPhoneNumber = "7038675309";
            oUserProfile.nRole = 1;

            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceTestProject.BVWebServiceWS.UserProfile userProfile = oUserProfile;
            //generate a session id for the following tests
            m_newBVSessionId = target.OpenSession(userProfile);
            //generate an id for any new items you will create in your subsequent tests
            IDs = target.GetIDs(1);
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            target.CloseSession(m_newBVSessionId);
        }

        // Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //    BVWebServiceSoapClient target = new BVWebServiceSoapClient();
        //    BVWebServiceTestProject.BVWebServiceWS.UserProfile userProfile = GetUserProfile();
        //    m_newBVSessionId = target.OpenSession(userProfile);
        //}
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        public UserProfile GetUserProfile()
        {
            UserProfile oUserProfile = new UserProfile();

            oUserProfile.sConnectId = "brboggio";
            oUserProfile.sExternalEmail = "brboggio@pbs.org";
            oUserProfile.sFirstName = "bryan";
            oUserProfile.sLastName = "boggio";
            oUserProfile.oOperatingGroup = new string[] { "Administrators", "Users" };
            oUserProfile.nOperatingUnit = 369;
            oUserProfile.nUnitType = 1;
            oUserProfile.sPhoneNumber = "7038675309";
            oUserProfile.nRole = 1;

            return oUserProfile;
        }

        [TestMethod]
        public void CreateOACTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string strLockID = string.Empty;

            int nOACID = IDs[0];
            bool bLockFlag = false;

            int expected = 0;
            int actual = 0;
            // use -1 to get empty record shell
            DataSet getOACResults = target.GetOAC(out strLockID, strSessionID, -1, bLockFlag);
            DataTable oacTabletoModify = getOACResults.Tables["OAC"];

            // grab and modify your record
            DataRow newOACDataRow = oacTabletoModify.NewRow();
            newOACDataRow["POAC_ID"] = nOACID;
            oacTabletoModify.Rows.Add(newOACDataRow);
            expected = int.Parse(oacTabletoModify.Rows[0]["POAC_ID"].ToString());

            // add datatable to 
            DataSet dsOAC = getOACResults;
            target.PutOAC(strSessionID, strLockID, dsOAC);
            target.ReleaseLock(strSessionID, strLockID);

            // get again to verify it was committed
            DataSet getModifiedOACResults = target.GetOAC(out strLockID, strSessionID, nOACID, false);
            DataTable oacTabletoCompare = getModifiedOACResults.Tables["OAC"];
            actual = int.Parse(oacTabletoCompare.Rows[0]["POAC_ID"].ToString());
            Debug.WriteLine("The New OAC ID is " + nOACID);
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void EditExistingOACTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nOACID = IDs[0]; // TODO: Initialize to an appropriate value
            bool bLockFlag = false; // Set to true if you need to modify a record.
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            DataSet expected = oldTarget.GetOAC(out strLockIDExpected, strSessionID, nOACID, bLockFlag);
            DataSet actual = target.GetOAC(out strLockID, strSessionID, nOACID, bLockFlag);

            DataTable old_dt = expected.Tables["OAC"];
            DataTable new_dt = actual.Tables["OAC"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }
        
        [TestMethod]
        public void DeleteOACTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int expected = 0;
            int actual = 0;
            int nTabId = IDs[0];
            string strLockId = string.Empty;
            DataSet oacToDelete = target.GetOAC(out strLockId, strSessionID, nTabId, true);
            target.DeleteOAC(strSessionID, nTabId, strLockId);
            DataSet oacDataSet = target.GetOAC(out strLockId, strSessionID, nTabId, false);
            DataTable oacTableToCompare = oacDataSet.Tables["OAC"];
            target.ReleaseLock(strSessionID, strLockId);
            actual = oacTableToCompare.Rows.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
