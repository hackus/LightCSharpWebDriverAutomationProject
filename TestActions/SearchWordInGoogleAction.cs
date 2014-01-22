using InputDataReader;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFramework;

namespace TestActions
{
    public class SearchWordInGoogleAction
    {
        WebDriverWrapper driverWrapper;
        RepoGoogle repoGoogle;

        public SearchWordInGoogleAction(ref WebDriverWrapper driverWrapper, Environments env)
        {
            this.driverWrapper = driverWrapper;
            repoGoogle = new RepoGoogle(env);
        }

        public void RunAction(GoogleSearchInput googleSearchInput)            
        {
            driverWrapper.getCurrentDriver().Navigate().GoToUrl(googleSearchInput.googleSearch.url);
            driverWrapper.LocateElement(repoGoogle.txtSearch).SendKeys(googleSearchInput.googleSearch.text);
            driverWrapper.LocateElement(repoGoogle.btnSearch).Click();
        }    
    }
}
