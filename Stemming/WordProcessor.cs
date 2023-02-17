using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stemming
{
    public struct StemmedWord
    {
        public readonly string Value;

        public readonly string Unstemmed;

        public StemmedWord(string value, string unstemmed)
        {
            Value = value;
            Unstemmed = unstemmed;
        }
    }
    class WordProcessor
    {
        public string GetStem(string word)
        {
            if (word.Length <= 2) return word;

            //remove plural
            if (word.EndsWith("'s"))
               word =  word.Substring(0, word.Length - 2);
            if(word.Length > 3 && word.EndsWith("s"))
                word = word.Substring(0, word.Length - 1);

            word = ReplaceSuffix(word);

            word = ReplaceCommonSuffix(word);

            return word;
        }

        private string ReplaceSuffix(string word)
        {
            foreach(var suffix in WordProcessingFilters.StringCanBeReplaced)
            {
                if(word.Length > 4)
                {
                    if (word.EndsWith(suffix))
                        return word.Substring(0, word.Length - suffix.Length);
                }                
            }
            return word;
        }

        private string ReplaceCommonSuffix(string word)
        {
            foreach (var suffix in WordProcessingFilters.CommonSuffix)
            {
                if (word.Length > 4)
                {
                    if (word.EndsWith(suffix.Key))
                        return word.Replace(suffix.Key, suffix.Value);
                }
            }
            return word;
        }
        
    }
}
