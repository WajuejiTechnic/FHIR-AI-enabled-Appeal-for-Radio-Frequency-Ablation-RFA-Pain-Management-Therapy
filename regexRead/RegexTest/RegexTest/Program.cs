using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> keywords = new List<string>();
            keywords.Add("recover");
            keywords.Add("the");
            keywords.Add("evaluate");
            keywords.Add("invasive");


            string XMLLocation = @"C:\Users\bunne\Documents\6440 IHI\Team Project\xml\PMC5220447.xml";
            string XMLContent = parseXML(XMLLocation);
            string XMLTagToSearchFor = "abstract";
            //string XMLTagToSearchFor = "pmc-articleset"; /* Use this tag to search entire document */
            string XMLTagContents = GetXMLTag(XMLContent, XMLTagToSearchFor);

            //Split input string into logical sentences
            string[] parsedSentences = Regex.Split(XMLTagContents, @"(?<=[\.!\?])\s+");
            if (parsedSentences.Length == 1)
            {
                Console.WriteLine("Tag Not Found");
            }
           
            //Check for each keyword in each sentence, return resulting sentences
            List<string> returnableSentences = new List<string>();
            foreach (string keyword in keywords)
            {
                for (int i = 0; i < parsedSentences.Length; i++)
                {
                    string returnString = regexSingleSearcher(parsedSentences[i], keyword);
                    if (returnString != "")
                        returnableSentences.Add(returnString);
                }
            }
            // display returned sentences to console
            if (returnableSentences.Count == 0)
                Console.WriteLine("No results from these keywords");
            foreach (string s in returnableSentences)
            {
                Console.WriteLine(s);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
     
        static string regexSingleSearcher(string inputString, string term)
        {
            string results = "";

            //Define variables to handle plural forms of the final word with Regex String 
            var word = @"r'\b[a-z]+\b\s*'";
            var words = @"r'('" + word + @"r')+?'";
            var words_0_to_n = @"r'('" + word + @"r')*?'";

            string regexString = "[^.!?;]* (" + term + ")[^.?!;]*[.?!;]";

            //Giving multi-form of regex strings 
            string regexString1 = @"r'\b(if|should)\s+'" + words_0_to_n + term +
              @"r'\s+(should\s+)?\b(appear|arise|begin|crop\s+up|commence|come\s+to\s+light|come\s+into\s+being|develop|emanate|emerge|ensue|exhibit|happen|occur|originate|result|set\s+in|start|take\s+place)'";
            string regexString2 = @"r'\b(if|should)\s+'" + words_0_to_n + @"r'\b(commences?|develops?|exhibits?|happens?|presents?|results?(\s+in)?|sets?\s+in|starts?|takes?\s+place)\s+'" + words_0_to_n + term + @"r'\b'";
            string regexString3 = @"r'\b(in\s+case\s+of|should\s+there\s+be|should|(look|watch)\s+(out\s+)?for)\s+'" + words_0_to_n + term + @"r'\b'";


            Match m1 = Regex.Match(inputString, regexString, RegexOptions.IgnoreCase);
            Match m2 = Regex.Match(inputString, regexString1, RegexOptions.IgnoreCase);
            Match m3 = Regex.Match(inputString, regexString2, RegexOptions.IgnoreCase);
            Match m4 = Regex.Match(inputString, regexString3, RegexOptions.IgnoreCase);
            if (m1.Success)
            {
                results = m1.Value;
            }
            else if (m2.Success)
            {
                results = m2.Value;
            }
            else if (m3.Success)
            {
                results = m3.Value;
            }
            else
            {
                results = m4.Value;
            }
            return results;
        }

        static string GetXMLTag(string inputString, string XMLTag)
        {
            string results = "";
            string regexStringConclusion = @"<"+XMLTag+@">[\s\S]*?<\/"+XMLTag+@">";
            Match m = Regex.Match(inputString, regexStringConclusion, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                results = m.Value;
            }
            return results;
        }


        static string parseXML(string fileLocation) {
            // Load the xml file into XmlDocument object.
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileLocation);

            // Now create StringWriter object to get data from xml document.
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xw);
            String XmlString = sw.ToString();
            return XmlString;
        }

    }
}


