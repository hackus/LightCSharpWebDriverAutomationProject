using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFramework;

namespace Repository
{
    public abstract class BaseRepository
    {
        public BaseRepository(Environments env)
        {            
            switch (env)
            {
                case Environments.dev1:
                    setupDev1();
                    break;
                case Environments.test1:
                    setupTest1();
                    break;
            }
        }

        public abstract void setupTest1();
        public abstract void setupDev1();
    }
}
