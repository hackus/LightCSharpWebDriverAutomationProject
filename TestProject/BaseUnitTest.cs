using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDriverFramework;

namespace TestProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public abstract class BaseUnitTest
    {
        protected WebDriverWrapper driverWrapper;
        
        public BaseUnitTest()
        {
            driverWrapper = new WebDriverWrapper();
        }
        
        public String LoggsPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\Logs\";
        
        #region setup and teardown
        [TestInitialize]
        public void SetupTest()
        {
            driverWrapper.addNewDriver(Configuration.getBrowser());
        }

        [TestCleanup]
        public void TearDown()
        {
            driverWrapper.Close();
        }
        #endregion setup and teardown

        #region tests
        ///[TestMethod, TestCategory("test1")]
        #endregion tests
    }
}
