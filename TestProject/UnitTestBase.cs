using System;
using ExceptionHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLogger;
using WebDriverFramework;
using log4net;
using System.IO;
using Repository;

namespace TestProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public abstract class UnitTestBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected WebDriverWrapper driverWrapper;
        private TestContext context;
        private int currentErrorCount;

        private static int _testsTotal;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }

        public UnitTestBase()
        {
            driverWrapper = new WebDriverWrapper();
        }

        #region setup and teardown

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            Configuration.context = context; //sa fie
            Directory.CreateDirectory(context.DeploymentDirectory + Configuration.scrnshotErrorFolder);
            Directory.CreateDirectory(context.DeploymentDirectory + Configuration.scrnshotFatalFolder);
            _testsTotal = 0;
            log.Info(LoggerMessages.TestSuiteStarted);         
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            log.Info(LoggerMessages.TestSuiteResults +"\r\n");
            log.Info(LoggerMessages.TestCasesRunned + _testsTotal);
            log.Info(LoggerMessages.TestCasesPassed + (_testsTotal - MyAssert.getErrorCounter()));
            log.Info(LoggerMessages.TestCasesFailed + MyAssert.getErrorCounter());            
        }

        [TestInitialize]
        public void SetupTest()
        {
            currentErrorCount = MyAssert.getErrorCounter();
            driverWrapper.TestContext = TestContext.TestDeploymentDir + Configuration.scrnshotFatalFolder + TestContext.TestName;
            _testsTotal++;
            log.Info(LoggerMessages.TestStarted);            
        }

        [TestCleanup]
        public void TearDown()
        {
            driverWrapper.Close();
            if (currentErrorCount != MyAssert.getErrorCounter())
            {
                log.Error(LoggerMessages.TestFailed);
            }

            log.Info(LoggerMessages.TestClosed);
            
            if (currentErrorCount < MyAssert.getErrorCounter())
            {
                throw new Exception(LoggerMessages.TestFailed);
            }
         }

        #endregion setup and teardown

        #region utils
        public void LoadDriver(String capabilities)
        {
            if (Configuration.getBrowser().Equals(DriverType.Remote))
            {
                BrowserCapabilities browserCappabilities = new BrowserCapabilities(capabilities);
                browserCappabilities.hubUri = Configuration.getRemoteDriverHub();
                driverWrapper.addNewDriver(browserCappabilities);
            }
            else
            {
                driverWrapper.addNewDriver(Configuration.getBrowser());
            }
        }
        #endregion utils
    }
}
