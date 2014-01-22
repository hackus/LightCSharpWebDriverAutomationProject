using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFramework
{
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(DriverType type, String uri="http://127.0.0.1")
        {
            switch(type)
            {
                case DriverType.Firefox: 
                    return getFirefoxDriver();
                    break;
                case DriverType.Chrome:
                    return getChromeDriver();
                    break;
                case DriverType.IE:
                    return getIEDriver();
                    break;
                case DriverType.Remote:
                    return getRemoteDriver(new Uri(uri));
                    break;
            }

            return null;
        }

        public static IWebDriver getFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        public static IWebDriver getChromeDriver()
        {
            return new ChromeDriver();
        }

        public static IWebDriver getIEDriver()
        {
            return new InternetExplorerDriver();
        }

        public static IWebDriver getRemoteDriver(Uri uri)
        {
            return new RemoteWebDriver(uri, new DesiredCapabilities());
        }
    }
}
