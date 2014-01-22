using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFramework;

namespace Repository
{
    public class RepoGoogle : BaseRepository
    {
        public By txtSearch = null;
        public By btnSearch = null;

        public RepoGoogle(Environments env)
            : base(env) { }

        public override void setupTest1()
        {
            txtSearch = Locate.XpathElementLocator("INPUT", "id", "gbqfq");            
            btnSearch = By.Id("");
        }

        public override void setupDev1()
        {
            txtSearch = By.Id("gbqfq");
            btnSearch = By.Id("gbqfb");
        }
    }
}
