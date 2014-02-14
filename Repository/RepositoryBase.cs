using WebDriverFramework;

namespace Repository
{
    public abstract class RepositoryBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RepositoryBase(Environments env)
        {                            
            log.Info("Set up Enviroment: "+env);
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
