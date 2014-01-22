using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFramework
{
    public class WebDriverWrapper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WebDriverWrapper));

        private List<IWebDriver> _drivers = new List<IWebDriver>();
        private int _currenDriverIndex = -1;

        private int WaitForPageToLoadTimeout = 30;

        public WebDriverWrapper()
        {
            
        }

        #region webdriver utils
        public int CurrentDriverIndex
        {
            get {return _currenDriverIndex;}
            set {
                if (value >= 0 && value < _drivers.Count)
                    _currenDriverIndex = value;
            }          
        }

        public void addNewDriver(DriverType type)
        {
            _drivers.Add(WebDriverFactory.GetDriver(type));
            _currenDriverIndex++;
        }

        public void removeDriver(int index)
        {
            if (index >= 0 && index < _drivers.Count)
            {
                _drivers.RemoveAt(index);
                _currenDriverIndex--;
            }
        }

        public IWebDriver getCurrentDriver()
        {
            return _drivers[_currenDriverIndex];  
        }

        public void Close()
        {
            foreach(IWebDriver driver in _drivers)
            {
                driver.Quit();
            }

            for (int i = 0; i < _drivers.Count; i++)
            {
                removeDriver(0);
            }
        }
        #endregion webdriver utils       

        #region locators
        public IWebElement LocateElement(By locator, int timeout = 0)
        {
            IWebElement element = null;
           
            try {
                element = getCurrentDriver().FindElement(locator); 
            }
            catch(Exception e)
            {
                log.Debug("Function LocateElement, haven't find element of type [" + locator.ToString() + "] Error: " + e.Message);
            }
            return element;
        }
        public IReadOnlyCollection<IWebElement> LocateAll(By locator)
        {
            IReadOnlyCollection<IWebElement> elements = null;

            try 
            {
                elements = getCurrentDriver().FindElements(locator);
            }
            catch(Exception e)
            {
                log.Debug("Function LocateAll, haven't find element of type [" + locator.ToString() + "] Error: " + e.Message);
            }

            return elements;
        }

        public IWebElement LocateWithin(By locator, IWebElement parent, int timeout = 0)
        {
            IWebElement element = null;

            try
            {
                element = parent.FindElement(locator);
            }
            catch (Exception e)
            {
                log.Debug("Function LocateWithin, haven't find child element of type [" + locator.ToString() + "] Error: " + e.Message);
            }
            return element;
        }

        public IReadOnlyCollection<IWebElement> LocateAllWithin(By locator, IWebElement parent)
        {
            IReadOnlyCollection<IWebElement> elements = null;

            try
            {
                elements = parent.FindElements(locator);
            }
            catch (Exception e)
            {
                log.Debug("Function LocateAllWithin, haven't find child elements of type [" + locator.ToString() + "] Error: " + e.Message);
            }

            return elements;
        }

        public bool Exists(By locator, int timeout = 0)
        {
            IWebElement element = null;

            try
            {
                element = getCurrentDriver().FindElement(locator);
            }
            catch (Exception e)
            {
                log.Debug("Function LocateElement, haven't find element of type [" + locator.ToString() + "] Error: " + e.Message);
            }

            return element == null ? false : true;
        }
        #endregion locators

        #region utils
        public bool WaitForPageToLoad()
        {
            try
            {
                IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(getCurrentDriver(), TimeSpan.FromSeconds(WaitForPageToLoadTimeout));

                wait.Until(driver1 => ((IJavaScriptExecutor)getCurrentDriver()).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch(Exception e) //timeout
            {
                log.Debug("Function WaitForPageToLoad, error while waiting for page to load, Error: "+ e.Message);
                return false;
            }
            return true;
        }
        #endregion utils
    }
}
