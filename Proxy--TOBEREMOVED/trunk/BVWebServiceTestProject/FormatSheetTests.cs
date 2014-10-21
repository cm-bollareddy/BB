using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BVWebServiceTestProject.BVWebServiceWS;
using System.Data;
using System.Diagnostics;

namespace BVWebServiceTestProject
{
    [TestClass]
    public class FormatSheetTests
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
        public void CreateFormatSheetTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            string strLockID = string.Empty;

            int nFormatSheetID = IDs[0];
            bool bLockFlag = false;

            int expected = 0;
            int actual = 0;
            // use -1 to get empty record shell
            DataSet getFormatSheetResults = target.GetFormatSheet(out strLockID, strSessionID, -1, bLockFlag);
            DataTable formatSheetTabletoModify = getFormatSheetResults.Tables["FORMATSHEET"];

            // grab and modify your record
            DataRow newFormatSheetDataRow = formatSheetTabletoModify.NewRow();
            newFormatSheetDataRow["PFS_ID"] = nFormatSheetID;
            formatSheetTabletoModify.Rows.Add(newFormatSheetDataRow);
            expected = int.Parse(formatSheetTabletoModify.Rows[0]["PFS_ID"].ToString());

            // add datatable to 
            DataSet dsFormatSheet = getFormatSheetResults;
            target.PutFormatSheet(strSessionID, strLockID, dsFormatSheet);
            target.ReleaseLock(strSessionID, strLockID);

            // get again to verify it was committed
            DataSet getModifiedFormatSheetResults = target.GetFormatSheet(out strLockID, strSessionID, nFormatSheetID, false);
            DataTable formatSheetTabletoCompare = getModifiedFormatSheetResults.Tables["FORMATSHEET"];
            actual = int.Parse(formatSheetTabletoCompare.Rows[0]["PFS_ID"].ToString());
            Debug.WriteLine("The New Format Sheet ID is " + nFormatSheetID);
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void EditExistingFormatSheetTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            BVWebServiceOld.BVWebServiceSoapClient oldTarget = new BVWebServiceOld.BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int nFormatSheetID = IDs[0]; // TODO: Initialize to an appropriate value
            bool bLockFlag = false; // Set to true if you need to modify a record.
            string strLockID = string.Empty;
            string strLockIDExpected = string.Empty;
            DataSet expected = oldTarget.GetFormatSheet(out strLockIDExpected, strSessionID, nFormatSheetID, bLockFlag);
            DataSet actual = target.GetFormatSheet(out strLockID, strSessionID, nFormatSheetID, bLockFlag);

            DataTable old_dt = expected.Tables["FORMATSHEET"];
            DataTable new_dt = actual.Tables["FORMATSHEET"];

            var combinedResults = old_dt.AsEnumerable().Intersect(new_dt.AsEnumerable(),
                                                    DataRowComparer.Default);

            Assert.AreEqual(old_dt.Rows.Count, combinedResults.Count());
        }

        [TestMethod]
        public void DeleteFormatSheetTest()
        {
            BVWebServiceSoapClient target = new BVWebServiceSoapClient();
            string strSessionID = m_newBVSessionId;
            int expected = 0;
            int actual = 0;
            int nTabId = IDs[0];
            string strLockId = string.Empty;
            DataSet formatSheetToDelete = target.GetFormatSheet(out strLockId, strSessionID, nTabId, true);
            target.DeleteFormatSheet(strSessionID, nTabId, strLockId);
            DataSet formatSheetDataSet = target.GetFormatSheet(out strLockId, strSessionID, nTabId, false);
            DataTable formatSheetTableToCompare = formatSheetDataSet.Tables["FORMATSHEET"];
            target.ReleaseLock(strSessionID, strLockId);
            actual = formatSheetTableToCompare.Rows.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
