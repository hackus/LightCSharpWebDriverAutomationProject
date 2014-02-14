using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WebDriverFramework;
using log4net;
using log4net.Config;
using System.Collections;
using TestActions;
using InputDataReader;
using ExceptionHandler;

namespace TestProject
{
    [TestClass]
    public class ForTestSuiteGoogleSearch : BaseUnitTest
    {      
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        SearchWordInGoogleAction searchGoogleAction;       

        public ForTestSuiteGoogleSearch() : base()
        { 
             searchGoogleAction = new SearchWordInGoogleAction(ref driverWrapper, Configuration.getEnvironment());
        }

        #region tests
        [TestMethod, TestCategory("Google")]
        public void TestSearchGoogle()
        {
            GoogleSearchInput googleSearchInput = new GoogleSearchInput();

            //googleSearchInput.ReadJsonFile<GoogleSearchInput>();
            googleSearchInput.GenerateTestData();

            searchGoogleAction.RunAction(googleSearchInput);            
        }
          
        [TestMethod, TestCategory("Google")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData\\ConvertNumber.csv", "ConvertNumber#csv", DataAccessMethod.Sequential)]
        public void TestConvertNumber()
        {   
            string rowInput = TestContext.DataRow["Input"].ToString();
            string rowExpected = TestContext.DataRow["Expected Result"].ToString();
            string rowException = TestContext.DataRow["Exception"].ToString();
            string rowComment = TestContext.DataRow["Comment"].ToString();

            int actualResult = ConvertToNumber(rowInput);
            MyAssert.AreEqual(rowExpected, actualResult.ToString(), true); //row input am prefacut in int si iarasi inapoi in string.
        }

        private TestContext context;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }


        int ConvertToNumber(string input)
        {
            int result = 0;
            while (input.Length > 0)
                result = (input[0] >= '0'
                || input[0] <= '9') ? (result
                * 10) + input[0] - '0' + (((input
                = input.Remove(0, 1)).Length
                > 0) ? 0 : 0) : 0;
            return result;
        }
        
        #endregion tests
    }
}
