using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InputDataReader;
using System.Collections.Generic;
using InputDataReader.Google;
using TestActions.Google;
using ExceptionHandler;

namespace TestProject.TestSuites
{
    [TestClass]
    public class GoogleSearchTestSuite : UnitTestBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [TestMethod, TestCategory("GoogleSearch")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData\\Login.csv", "Login#csv", DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "D:\\Projects\\Automation\\Endava\\dotnet\\web\\UnitTestFramework\\TestProject\\bin\\Debug\\TestData\\GoogleSearch1.csv", "GoogleSearch1#csv", DataAccessMethod.Sequential)]
        public void GoogleSearchTest1()
        {
            List<InputBase> inputList = new List<InputBase>();
            GoogleSearchInput googleInput = new GoogleSearchInput();
            GoogleSearchAction googleAction = new GoogleSearchAction(ref driverWrapper, Configuration.getEnvironment());

            googleInput.url = TestContext.DataRow["Url"].ToString();
            googleInput.text = TestContext.DataRow["Text"].ToString();            
            
            String capabilities = TestContext.DataRow["RemoteBrowser"].ToString();

            log.Info("The Url name is: " + googleInput.url);
            log.Info("The Text name is: " + googleInput.text);

            inputList.Add(googleInput);

            LoadDriver(capabilities);

            googleAction.RunAction(inputList);
        }

        [TestMethod, TestCategory("GoogleSearch")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData\\Login.csv", "Login#csv", DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "D:\\Projects\\Automation\\Endava\\dotnet\\web\\UnitTestFramework\\TestProject\\bin\\Debug\\TestData\\GoogleSearch2.csv", "GoogleSearch2#csv", DataAccessMethod.Sequential)]
        public void GoogleSearchTest2()
        {
            List<InputBase> inputList = new List<InputBase>();
            GoogleSearchInput googleInput = new GoogleSearchInput();
            GoogleSearchValidateAction googleValidateAction = new GoogleSearchValidateAction(ref driverWrapper, Configuration.getEnvironment());

            googleInput.url = TestContext.DataRow["Url"].ToString();
            googleInput.text = TestContext.DataRow["Text"].ToString();

            String capabilities = TestContext.DataRow["RemoteBrowser"].ToString();

            log.Info("The Url name is: " + googleInput.url);
            log.Info("The Text name is: " + googleInput.text);

            inputList.Add(googleInput);

            LoadDriver(capabilities);

            googleValidateAction.RunAction(inputList);
        }

        [TestMethod, TestCategory("GoogleSearch")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData\\Login.csv", "Login#csv", DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "D:\\Projects\\Automation\\Endava\\dotnet\\web\\UnitTestFramework\\TestProject\\bin\\Debug\\TestData\\GoogleSearch3.csv", "GoogleSearch3#csv", DataAccessMethod.Sequential)]
        public void GoogleSearchTest3()
        {
            List<InputBase> inputList = new List<InputBase>();
            GoogleSearchInput googleInput = new GoogleSearchInput();
            GoogleSearchAction googleAction = new GoogleSearchAction(ref driverWrapper, Configuration.getEnvironment());

            googleInput.url = TestContext.DataRow["Url"].ToString();
            googleInput.text = TestContext.DataRow["Text"].ToString();

            String capabilities = TestContext.DataRow["RemoteBrowser"].ToString();

            log.Info("The Url name is: " + googleInput.url);
            log.Info("The Text name is: " + googleInput.text);

            inputList.Add(googleInput);

            LoadDriver(capabilities);

            googleAction.RunAction(inputList);
        }

        [TestMethod, TestCategory("GoogleSearch")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData\\Login.csv", "Login#csv", DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "D:\\Projects\\Automation\\Endava\\dotnet\\web\\UnitTestFramework\\TestProject\\bin\\Debug\\TestData\\GoogleSearch4.csv", "GoogleSearch4#csv", DataAccessMethod.Sequential)]
        public void GoogleSearchTest4()
        {
            List<InputBase> inputList = new List<InputBase>();
            GoogleSearchInput googleInput = new GoogleSearchInput();
            GoogleSearchAction googleAction = new GoogleSearchAction(ref driverWrapper, Configuration.getEnvironment());

            googleInput.url = TestContext.DataRow["Url"].ToString();
            googleInput.text = TestContext.DataRow["Text"].ToString();

            String capabilities = TestContext.DataRow["RemoteBrowser"].ToString();

            log.Info("The Url name is: " + googleInput.url);
            log.Info("The Text name is: " + googleInput.text);

            inputList.Add(googleInput);

            LoadDriver(capabilities);

            googleAction.RunAction(inputList);
        }

        [TestMethod, TestCategory("GoogleSearch")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestData\\Login.csv", "Login#csv", DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "D:\\Projects\\Automation\\Endava\\dotnet\\web\\UnitTestFramework\\TestProject\\bin\\Debug\\TestData\\GoogleSearch5.csv", "GoogleSearch5#csv", DataAccessMethod.Sequential)]
        public void GoogleSearchTest5()
        {
            List<InputBase> inputList = new List<InputBase>();
            GoogleSearchInput googleInput = new GoogleSearchInput();
            GoogleSearchAction googleAction = new GoogleSearchAction(ref driverWrapper, Configuration.getEnvironment());

            googleInput.url = TestContext.DataRow["Url"].ToString();
            googleInput.text = TestContext.DataRow["Text"].ToString();

            String capabilities = TestContext.DataRow["RemoteBrowser"].ToString();

            log.Info("The Url name is: " + googleInput.url);
            log.Info("The Text name is: " + googleInput.text);

            inputList.Add(googleInput);

            LoadDriver(capabilities);

            googleAction.RunAction(inputList);
        }
    }
}
