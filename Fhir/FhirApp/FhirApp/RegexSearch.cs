using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FhirApp
{
    public class RegexSearch
    {
        public static IEnumerable<string> GetMatches(string text)
        {
            var list = new HashSet<string>();
            var parsedSentences = Regex.Split(text, @"(?<=[\.!\?])\s*");

            List<string> keywords = new List<string>();
            keywords.Add("radiofrequency|RFA");
            keywords.Add("relief|favor");
            keywords.Add("treat|improved");

            List<string> returnableSentences = new List<string>();

            foreach (var sentence in parsedSentences)
            {
                var success = true;
                foreach (var keyword in keywords)
                {
                    success &= RegexSingleSearcher(sentence, keyword);
                }
                if (success)
                    returnableSentences.Add(sentence);
            }

            foreach (var s in returnableSentences)
            {
                list.Add(s);
            }

            return list;
        }

        private static bool RegexSingleSearcher(string inputString, string term)
        {
            //var regexString = "[^.!?;]* (" + term + ")[^.?!;]*[.?!;]";
            //var m = Regex.Match(inputString, regexString, RegexOptions.IgnoreCase);
            var word = @"r'\b[a-z]+\b\s*'";
            var words = @"r'('" + word + @"r')+?'";
            var words_0_to_n = @"r'('" + word + @"r')*?'";

            string regexString = "[^.!?;]* (" + term + ")[^.?!;]*[.?!;]";

            //Giving multi-form of regex strings 
            string regexString1 = @"r'\b(if|should)\s+'" + words_0_to_n + term +
              @"r'\s+(should\s+)?\b(appear|arise|begin|crop\s+up|commence|come\s+to\s+light|come\s+into\s+being|develop|emanate|emerge|ensue|exhibit|happen|occur|originate|result|set\s+in|start|take\s+place)'";
            string regexString2 = @"r'\b(if|should)\s+'" + words_0_to_n + @"r'\b(commences?|develops?|exhibits?|happens?|presents?|results?(\s+in)?|sets?\s+in|starts?|takes?\s+place)\s+'" + words_0_to_n + term + @"r'\b'";
            string regexString3 = @"r'\b(in\s+case\s+of|should\s+there\s+be|should|(look|watch)\s+(out\s+)?for)\s+'" + words_0_to_n + term + @"r'\b'";

            var m1 = Regex.Match(inputString, regexString, RegexOptions.IgnoreCase);
            var m2 = Regex.Match(inputString, regexString1, RegexOptions.IgnoreCase);
            var m3 = Regex.Match(inputString, regexString2, RegexOptions.IgnoreCase);
            var m4 = Regex.Match(inputString, regexString3, RegexOptions.IgnoreCase);

            return m1.Success || m2.Success || m3.Success || m4.Success;
        }
    }
}
