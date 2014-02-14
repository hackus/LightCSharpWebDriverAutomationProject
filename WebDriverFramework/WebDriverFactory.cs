using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace WebDriverFramework
{
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(DriverType type)
        {
            switch(type)
            {
                case DriverType.Firefox: 
                    return getFirefoxDriver();
                case DriverType.Chrome:
                    return getChromeDriver();
                case DriverType.IE:
                    return getIEDriver();               
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

        public static ScreenShotRemoteWebDriver GetDriver(BrowserCapabilities capabilities)
        {
            DesiredCapabilities browser = null;
            if (capabilities.browserName == null)
                capabilities.browserName = "firefox";
            if (capabilities.Platform == null)
                capabilities.Platform = "WINDOWS";

            switch (capabilities.browserName.ToUpper())
            {
                case "FIREFOX":
                    browser = DesiredCapabilities.Firefox();
                    break;
                case "CHROME":
                    browser = DesiredCapabilities.Chrome();
                    break;
                case "INTERNET EXPLORER":
                    //browser = DesiredCapabilities.InternetExplorer();
                    //browser.SetCapability(CapabilityType.BrowserName, "iexplorer");                    
                    //browser.SetCapability("seleniumProtocol", "WebDriver");                    
                    
                    browser = new DesiredCapabilities();
                    browser.SetCapability(CapabilityType.BrowserName, "internet explorer");
                    break;
            }

            switch (capabilities.Platform.ToUpper())
            {
                case "LINUX":
                    browser.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Linux));
                    break;
                case "WINDOWS":
                    browser.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    break;                     
            }

            if (capabilities.Version != null)
                browser.SetCapability(CapabilityType.Version, capabilities.Version);
                        
            //browser.SetCapability(CapabilityType.IsJavaScriptEnabled, capabilities.IsJavaScriptEnabled);

            return new ScreenShotRemoteWebDriver(new Uri(capabilities.hubUri), browser);
        }
    }
}
