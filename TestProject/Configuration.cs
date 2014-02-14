using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDriverFramework;

namespace TestProject
{
    class Configuration
    {
        public static TestContext context;
        public static string scrnshotErrorFolder = @"\ScreenshotsErrors\";
        public static string scrnshotFatalFolder = @"\ScreenshotsFatals\";

        public static Environments getEnvironment()
        {
            Environments env = (Environments)Enum.Parse(typeof(Environments), ConfigurationManager.AppSettings["Environment"]);
            return env;
        }

        public static DriverType getBrowser()
        {
            if (!ConfigurationManager.AppSettings["Browser"].Equals(""))
            {
                DriverType browser = (DriverType)Enum.Parse(typeof(DriverType), ConfigurationManager.AppSettings["Browser"]);
                return browser;
            }
            return DriverType.Remote;
        }


        public static string getRemoteDriverHub()
        {
            string hubHost = ConfigurationManager.AppSettings["RemoteDriverHub"];
            return hubHost;
        }
    }
}
