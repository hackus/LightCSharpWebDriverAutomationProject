using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFramework;

namespace TestProject
{
    class Configuration
    {
        public static Environments getEnvironment()
        {
            Environments env = (Environments)Enum.Parse(typeof(Environments), ConfigurationManager.AppSettings["Environment"]);
            return env;
        }

        public static DriverType getBrowser()
        {
            DriverType browser = (DriverType)Enum.Parse(typeof(DriverType), ConfigurationManager.AppSettings["Browser"]);
            return browser;
        }
    }
}
