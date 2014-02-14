using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFramework;

namespace Repository.Google
{
    public class RepoGoogle : RepositoryBase
    {
        public By txtSearch;
        public By btnSearch1;
        public By btnSearch2;
        public By lnkAny;

        public RepoGoogle(Environments env)
            : base(env) { }

        public override void setupTest1()
        {
            throw new NotImplementedException();
        }

        public override void setupDev1()
        {
            txtSearch = By.Id("gbqfq");
            btnSearch1 = By.Id("gbqfba");
            btnSearch2 = By.Id("gbqfb");
            lnkAny = By.XPath(".//*[@id='rso']//a[1]");            
        }
    }
}
