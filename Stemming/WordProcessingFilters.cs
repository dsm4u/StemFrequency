using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stemming
{
    public static class WordProcessingFilters
    {
        public static char[] VowelsList { get { return "aeiouy".ToArray(); } }
               
       public static string[] StringCanBeReplaced { get { return new string[] { "ing", "ly", "es", "lies" }; } }

       public static Dictionary<string, string> CommonSuffix
        {
            get
            {
                return new Dictionary<string, string>
                { { "ation", "ate" }
                };
            }
        }

        public static string[] WordsFrequency { get { return new string[] { "following" ,"flow" ,"classification" ,"class" ,"flower" ,"friend" ,"friendly","classes"}; } }
}
}
