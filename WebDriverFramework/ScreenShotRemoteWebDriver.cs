using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFramework
{
    public class ScreenShotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
    {
        public ScreenShotRemoteWebDriver(Uri RemoteAdress, ICapabilities capabilities)
            : base(RemoteAdress, capabilities)
        {
        }

        public Screenshot GetScreenshot()
        {
            // Get the screenshot as base64. 
            Response screenshotResponse = this.Execute(DriverCommand.Screenshot, null);
            string base64 = screenshotResponse.Value.ToString();
            // ... and convert it. 
            return new Screenshot(base64);
        }
    }
}
