using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Google;
using InputDataReader.Google;
using WebDriverFramework;
using MyLogger;
using OpenQA.Selenium;

namespace TestActions.Google
{
    public class GoogleSearchValidateAction : ActionBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        RepoGoogle repoGoogle;
        GoogleSearchInput googleInput = new GoogleSearchInput();

        public GoogleSearchValidateAction(ref WebDriverWrapper driverWrapper, Environments env)
            : base(ref driverWrapper, env)
        {
            repoGoogle = new RepoGoogle(env);
        }

        public override void RunAction(List<InputDataReader.InputBase> inputList)
        {
            log.Info(LoggerMessages.ActionStarted + this.GetType().Name);

            InjectInput<GoogleSearchInput>(inputList, ref googleInput);

            driverWrapper.getCurrentDriver().Manage().Window.Maximize();
            driverWrapper.getCurrentDriver().Navigate().GoToUrl(googleInput.url);
            driverWrapper.WaitForPageToLoad();
            driverWrapper.LocateElement(repoGoogle.txtSearch, 30).SendKeys(googleInput.text);
            driverWrapper.WaitForPageToLoad();
            driverWrapper.LocateElement(repoGoogle.btnSearch2, 30).Click();
            driverWrapper.WaitForPageToLoad();
            driverWrapper.LocateElement(repoGoogle.lnkAny, 30).Click();

            driverWrapper.LocateElement(By.Id("asdfasdfasdfasdf"), 30).Click();

            log.Info(LoggerMessages.ActionFinished + this.GetType().Name);
        }
    }
}
