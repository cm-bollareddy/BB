using BVWebServiceTestProject.SAWebService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data;

namespace BVWebServiceTestProject
{
    
    
    /// <summary>
    ///This is a test class for SAWebServiceTest and is intended
    ///to contain all SAWebServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SAWebServiceTest
    {


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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SAWebService Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SAWebServiceConstructorTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient();            
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CloseSession
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void CloseSessionTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            target.CloseSession(strSessionID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }


        /// <summary>
        ///A test for GetDetailedAirDate
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void GetDetailedAirDateTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            int nMediaInventoryId = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.GetDetailedAirDate(strSessionID, nMediaInventoryId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDetailedAirDate
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void GetDetailedAirDateTest1()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            int nMediaInventoryId = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.GetDetailedAirDate(strSessionID, nMediaInventoryId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for ListMediaCutsInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void ListMediaCutsInfoTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value            
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ListMediaCutsInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ListMediaCutsInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void ListMediaCutsInfoTest1()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ListMediaCutsInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ListPackageCutsInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void ListPackageCutsInfoTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ListPackageCutsInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ListPackageCutsInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void ListPackageCutsInfoTest1()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ListPackageCutsInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ListPackageMediaInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void ListPackageMediaInfoTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ListPackageMediaInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ListPackageMediaInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void ListPackageMediaInfoTest1()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ListPackageMediaInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for OpenSession
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void OpenSessionTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            UserProfile userProfile = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.OpenSession(userProfile);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchFeatureAirDate
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchFeatureAirDateTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            int intFeatureMediaInventoryID = 0; // TODO: Initialize to an appropriate value
            int nTune_value = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SearchFeatureAirDate(intFeatureMediaInventoryID, nTune_value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchMediaAirDate
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchMediaAirDateTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            string strMediaHouseNumber = string.Empty; // TODO: Initialize to an appropriate value
            int nTune_value = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SearchMediaAirDate(strSessionID, strMediaHouseNumber, nTune_value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchMediaAirDate
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchMediaAirDateTest1()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            string strMediaHouseNumber = string.Empty; // TODO: Initialize to an appropriate value
            int nTune_value = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SearchMediaAirDate(strSessionID, strMediaHouseNumber, nTune_value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchMediaInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchMediaInfoTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.SearchMediaInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchMediaInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchMediaInfoTest1()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.SearchMediaInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchPackageAirDate
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchPackageAirDateTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            string strPackageNumber = string.Empty; // TODO: Initialize to an appropriate value
            int nTune_value = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SearchPackageAirDate(strSessionID, strPackageNumber, nTune_value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchPackageAirDate
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchPackageAirDateTest1()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            string strPackageNumber = string.Empty; // TODO: Initialize to an appropriate value
            int nTune_value = 0; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SearchPackageAirDate(strSessionID, strPackageNumber, nTune_value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchPackageInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchPackageInfoTest()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.SearchPackageInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SearchPackageInfo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/SAWebService")]
        public void SearchPackageInfoTest1()
        {
            SAWebServiceSoapClient target = new SAWebServiceSoapClient(); // TODO: Initialize to an appropriate value
            string strSessionID = string.Empty; // TODO: Initialize to an appropriate value
            SearchCriterion[] searchCriteria = null; // TODO: Initialize to an appropriate value
            int nMaxRow = 0; // TODO: Initialize to an appropriate value
            DataSet expected = null; // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.SearchPackageInfo(strSessionID, searchCriteria, nMaxRow);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
