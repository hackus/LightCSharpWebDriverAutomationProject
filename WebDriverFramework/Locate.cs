using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFramework
{
    public class Locate
    {
        #region locate generators
        public static By XpathElementLocator(string type, string attribute, string text)
        {
            return attribute == "." ? By.XPath(String.Format("//{0}[contains({1},'{2}')]", type, attribute, text)) : By.XPath(String.Format("//{0}[contains(@{1},'{2}')]", type, attribute, text));
        }
        public static By XpathParentLocator(string type, string attribute, string text)
        {
            return attribute == "." ? By.XPath(String.Format("//{0}[contains({1},'{2}')]/..", type, attribute, text)) : By.XPath(String.Format("//{0}[contains(@{1},'{2}')]/..", type, attribute, text));
        }
        public static By XpathElementContainsTextLocator(string type, string text)
        {
            return By.XPath(String.Format("//{0}[contains(text(),'{1}')]", type, text));
        }
        #endregion locate generators
    }
}
