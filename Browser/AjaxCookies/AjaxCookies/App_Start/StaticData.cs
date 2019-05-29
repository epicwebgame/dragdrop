using System.Collections.Generic;

namespace AjaxCookies
{
    public class StaticData
    {
        private static int _counter;
        private static List<string> _quotes => new List<string>
        {
            "An act of kindness is better than all the knowledge in the world.", 
            "An ounce of practice weighs more than a ton of theory.", 
            "The study of mankind is man.", 
            "God is love. Live in love.", 
            "There is only one God. He is omnipresent."
        };

        public static string GetQuote()
        {
            if (_counter == _quotes.Count)
            {
                _counter = 0;
            }

            return _quotes[_counter++];
        }
    }
}