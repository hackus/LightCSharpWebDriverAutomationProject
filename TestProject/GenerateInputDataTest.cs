using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InputDataReader;

namespace TestProject
{
    [TestClass]
    public class GenerateInputDataTest : BaseUnitTest
    {
        #region setup and teardown
        [TestInitialize]
        public void SetupTest()
        {
        }

        [TestCleanup]
        public void TearDown()
        {
        }
        #endregion setup and teardown

        [TestMethod]
        public void TestGenerateInputData()
        {
            //GoogleSearchInput.WriteJsonFile(@"GoogleSearchInput.json", GoogleSearchInput.GenerateTestData());

            GoogleSearchInput googleSearchInput = new GoogleSearchInput();
            //googleSearchInput.GenerateTestData();

            GoogleSearchInput.WriteJsonFile(googleSearchInput.GenerateTestData());
        }
    }
}
