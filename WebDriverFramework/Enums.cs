using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFramework
{
    public enum ElementFindType
    {
        XPATH,
        ID,
        CSS
    };

    public enum DriverType
    {
        Firefox, 
        Chrome, 
        IE, 
        Remote
    };

    public enum Environments
    {
        dev1,
        test1, 
        dev2
    };
}
