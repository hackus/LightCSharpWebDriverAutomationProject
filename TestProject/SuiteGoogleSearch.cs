using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WebDriverFramework;
using log4net;
using log4net.Config;
using System.Collections;
using TestActions;
using InputDataReader;

namespace TestProject
{
    [TestClass]
    public class SuiteGoogleSearch : BaseUnitTest
    {      
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        SearchWordInGoogleAction searchGoogleAction;
        //String LoggsPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\Logs\";

        //public void run()
        //{            
        //    log.Info("Test class Entering application.");
        //    log.Warn("Test class Entering application.");
        //    log.Debug("Test class Entering application.");
        //    log.Error("Test class Entering application.");
        //    log.Fatal("Test class Entering application.");
        //}

        public SuiteGoogleSearch() : base()
        { 
             searchGoogleAction = new SearchWordInGoogleAction(ref driverWrapper, Configuration.getEnvironment());
        }

        #region tests
        [TestMethod, TestCategory("Google")]
        public void TestSearchGoogle()
        {
            GoogleSearchInput googleSearchInput = GoogleSearchInput.ReadJsonFile();            

            searchGoogleAction.RunAction(googleSearchInput);            
        }

        //const string dataDriver = "System.Data.OleDb";
        //const string connectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=matrix.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

                
        
        //[DataSource(dataDriver, connectionStr, "Sheet1$", DataAccessMethod.Sequential)]        
        //[DeploymentItem("matrix.xlsx")]
        //[DataSource("MyExcelDataSource")]      
        [TestMethod, TestCategory("Google")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData\\ConvertNumber.csv", "ConvertNumber#csv", DataAccessMethod.Sequential)]
        public void TestConvertNumber()
        {
            try
            {
                string rowInput = TestContext.DataRow["Input"].ToString();
                string rowExpected = TestContext.DataRow["Expected Result"].ToString();
                string rowException = TestContext.DataRow["Exception"].ToString();
                string rowComment = TestContext.DataRow["Comment"].ToString();

                int actualResult = ConvertToNumber(rowInput);
                Assert.AreEqual(rowExpected, actualResult.ToString());
            }
            catch (AssertFailedException)
            { 

            }

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
