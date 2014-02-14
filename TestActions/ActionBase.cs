using System.Collections.Generic;
using InputDataReader;
using WebDriverFramework;

namespace TestActions
{
    public abstract class ActionBase
    {
        public WebDriverWrapper driverWrapper;    
        public Environments env;

        public ActionBase(ref WebDriverWrapper driverWrapper, Environments env)
        {
            this.driverWrapper = driverWrapper;
            this.env = env;
        }

        public abstract void RunAction(List<InputBase> inputList);

        protected void InjectInput<T>(List<InputBase> inputList,ref T instanceInput) where T : InputBase
        {  
            foreach (T input in inputList)
            {                
                if (input.GetType() == typeof(T))
                {
                    instanceInput = input;
                    return;
                }
            }
        }
    }
}
