using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputDataReader
{
    public class GoogleSearchInput : InputBase<GoogleSearchInput>
    {
        public GoogleSearch googleSearch { get; set; }
        
        public override GoogleSearchInput GenerateTestData()
        {
            GoogleSearch googleSearch = new GoogleSearch();
            googleSearch.text = "test";
            googleSearch.url = "http://www.google.com";

            GoogleSearchInput input = new GoogleSearchInput();

            input.googleSearch = googleSearch;

            return input;
        }
    }

    public class GoogleSearch
    {
        public String text { get; set; }
        public String url { get; set; }
    }


}
