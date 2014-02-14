using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExceptionHandler;
using MyLogger;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Remote;

namespace WebDriverFramework
{
    public class WebDriverWrapper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WebDriverWrapper));

        private List<IWebDriver> _drivers = new List<IWebDriver>();
        private int _currenDriverIndex = -1;

        private int WaitForPageToLoadTimeout = 30;

        private string _currentTextContext;        

        public string TestContext{ 
            get{return _currentTextContext;}
            set{_currentTextContext = value;}
        }

        #region webdriver utils
        public int CurrentDriverIndex
        {
            get { return _currenDriverIndex; }
            set
            {
                if (value >= 0 && value < _drivers.Count)
                    _currenDriverIndex = value;
            }
        }

        public void RunAssert(int val, string filepath)
        {
            takeScreenshot(filepath);
            if (val == 1)
            {   
                log.Fatal(LoggerMessages.AnchorFatal + filepath);
                log.Fatal(LoggerMessages.TestFailed); 
                throw new Exception(LoggerMessages.TestFailed);
            }
            else if (val == 2)
            {
                log.Error(LoggerMessages.AnchorError + filepath);                
            }
        }

        public void addNewDriver(DriverType type)
        {
            log.Info("Adding a new Driver...");
            _drivers.Add(WebDriverFactory.GetDriver(type));
            _currenDriverIndex++;
        }

        public void addNewDriver(BrowserCapabilities capabilities)
        {
            log.Info("Adding a new Driver...");
            _drivers.Add(WebDriverFactory.GetDriver(capabilities));
            _currenDriverIndex++;
        }

        public void removeDriver(int index)
        {
            if (index >= 0 && index < _drivers.Count)
            {
                _drivers.RemoveAt(index);
                if (_currenDriverIndex >= index) _currenDriverIndex--;
                log.Info("Driver removed.");
            }
        }

        public IWebDriver getCurrentDriver()
        {
            return _drivers[_currenDriverIndex];
        }

        public void Close()
        { 
            for (int i = 0; i < _drivers.Count; i++)
            {
                _drivers[0].Quit();
                removeDriver(0);
                log.Info("Driver closed.");
            }
        }
        #endregion webdriver utils

        #region locators
        public IWebElement LocateElement(By locator, int timeout = 1, bool severity = false)
        {
            IWebElement element = null;

            try
            {
                WebDriverWait wait = new WebDriverWait(getCurrentDriver(), TimeSpan.FromSeconds(timeout));
             
                element = wait.Until(drv => drv.FindElement(locator));
            }
            catch (Exception e)
            {
                RunAssert(MyAssert.IsTrue(false,
                    severity,
                    "Function LocateElement try to find element of type [" + locator.ToString() + "]" + "\r\nStackTrace:\r\n" + e.Message), _currentTextContext + MyAssert.getErrorCounter());             
            }
            return element;
        }

        public IReadOnlyCollection<IWebElement> LocateAll(By locator, bool severity = false)
        {
            IReadOnlyCollection<IWebElement> elements = null;

            try
            {
                elements = getCurrentDriver().FindElements(locator);
            }
            catch (NoSuchElementException e)
            {   
                RunAssert(MyAssert.IsTrue(false,
                    severity,
                    "Function LocateAll try to find element of type [" + locator.ToString() + "]" + "\r\nStackTrace:\r\n" + e.Message), _currentTextContext + MyAssert.getErrorCounter());
            }

            return elements;
        }

        public IWebElement LocateWithin(By locator, IWebElement parent, int timeout = 0, bool severity = false)
        {
            IWebElement element = null;

            try
            {
                element = parent.FindElement(locator);
            }
            catch (Exception e)
            {   
                RunAssert(MyAssert.IsTrue(false,
                    severity,
                    "Function LocateWithin try to find element of type [" + locator.ToString() + "]" + "\r\nStackTrace:\r\n" + e.Message), _currentTextContext + MyAssert.getErrorCounter());
            }
            return element;
        }

        public IReadOnlyCollection<IWebElement> LocateAllWithin(By locator, IWebElement parent, bool severity = false)
        {
            IReadOnlyCollection<IWebElement> elements = null;

            try
            {
                elements = parent.FindElements(locator);
            }
            catch (Exception e)
            {   
                RunAssert(MyAssert.IsTrue(false,
                    severity,
                    "Function LocateAllWithin try to find element of type [" + locator.ToString() + "]" + "\r\nStackTrace:\r\n" + e.Message), _currentTextContext + MyAssert.getErrorCounter());
            }

            return elements;
        }

        public bool Exists(By locator, int timeout = 0, bool severity = false)
        {
            IWebElement element = null;

            try
            {
                element = getCurrentDriver().FindElement(locator);
            }
            catch (Exception e)
            {   
                RunAssert(MyAssert.IsTrue(false,
                    severity,
                    "Function LocateElement try to find element of type [" + locator.ToString() + "]" + "\r\nStackTrace:\r\n" + e.Message), _currentTextContext + MyAssert.getErrorCounter());
            }

            return element == null ? false : true;
        }
        #endregion locators

        #region utils
        public void WaitForPageToLoad(bool severity = false)
        {
            try
            {
                IWait<IWebDriver> wait = new WebDriverWait(getCurrentDriver(), TimeSpan.FromSeconds(WaitForPageToLoadTimeout));
                wait.Until(driver1 => ((IJavaScriptExecutor)getCurrentDriver()).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception e)
            {
                RunAssert(MyAssert.IsTrue(false, severity, "Function WaitForPageToLoad." + "\r\nStackTrace:\r\n" + e.Message), _currentTextContext + MyAssert.getErrorCounter());             
            }
        }

        public void takeScreenshot(string fileName)
        {
            var bitmap = (Bitmap)Bitmap.FromStream(new MemoryStream(((ITakesScreenshot)getCurrentDriver()).GetScreenshot().AsByteArray));

            int cropHeight = 0;

            string userAgent = (string)((IJavaScriptExecutor)getCurrentDriver()).ExecuteScript("return navigator.userAgent");
            if (!userAgent.Contains("MSIE")) goto ocolire;

            for (int j = 0; j < bitmap.Height; j++)
            {
                bool blackline = false;
                if (bitmap.GetPixel(0, j).ToArgb() != Color.Black.ToArgb()) continue;

                for (int i = 1; i < bitmap.Width; i++)
                {
                    if (bitmap.GetPixel(i, j).ToArgb() != Color.Black.ToArgb()) break;
                    else if (i == bitmap.Width - 1) blackline = true;
                }

                if (blackline == true)
                {
                    cropHeight = j - 1;
                    break;
                }
            }

        ocolire:
            if (cropHeight != 0) bitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, cropHeight), PixelFormat.DontCare);
            bitmap.Save(fileName);
        }
        #endregion utils
    }
}
