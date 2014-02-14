using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputDataReader.Google
{
    public class GoogleSearchInput : InputBase
    {
        public String text { get; set; }
        public String url { get; set; }

        public override InputBase GenerateTestData()
        {
            throw new NotImplementedException();
        }
    }
}
