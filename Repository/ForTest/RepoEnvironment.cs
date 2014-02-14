using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFramework;

namespace Repository
{
    class RepoEnvironment : RepositoryBase
    {
        public RepoEnvironment(Environments env)
            : base(env) { }

        public override void setupTest1()
        {
            throw new NotImplementedException();
        }

        public override void setupDev1()
        {
            throw new NotImplementedException();
        }
    }
}
