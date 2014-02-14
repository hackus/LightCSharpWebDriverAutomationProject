using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFramework
{
    public class BrowserCapabilities
    {
        public string Platform = null;
        public string Version = null;
        public string browserName = null;
        public bool IsJavaScriptEnabled = false;
        public string hubUri = null;

        public BrowserCapabilities(String str)
        {
            Platform = getDriverCapabilities("Platform", str);
            Version = getDriverCapabilities("Version", str);
            browserName = getDriverCapabilities("browserName", str);
            IsJavaScriptEnabled = getDriverCapabilities("IsJavaScriptEnabled", str) == null ? true : Boolean.Parse(getDriverCapabilities("IsJavaScriptEnabled", str));
        }

        public String getDriverCapabilities(string key, string capabilities)
        {
            String[] strCap = capabilities.Replace("\"", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in strCap)
            {
                string [] strAux = str.Split(new string[] { "=" }, StringSplitOptions.None);

                if (strAux[0].Equals(key, StringComparison.OrdinalIgnoreCase))
                    return strAux[1];
            }

            return null;
        }
    }
}
