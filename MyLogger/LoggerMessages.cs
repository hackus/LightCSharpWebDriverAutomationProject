using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    public static class LoggerMessages
    {
        public const string TestStarted = "Test Started.";
        public const string TestClosed = "Test Closed.";

        public const string TestFailed = "Test Failed!";

        public const string TestSuiteStarted = "Test suite run started.";
        public const string TestSuiteResults = "Test suite run finished.";

        public const string TestCasesRunned = "Tests runned:";
        public const string TestCasesPassed = "Tests passed:";
        public const string TestCasesFailed = "Tests failed:";

        //public const string TestStepsFailed = "Test steps failed:";

        public const string ActionStarted = "Action started:";
        public const string ActionFinished = "Action finished:";

        public const string AnchorError = "CreateAnchorError";        
        public const string AnchorFatal = "CreateAnchorFatal";        

        public const string GoBack = "Go Back";
    };
}
