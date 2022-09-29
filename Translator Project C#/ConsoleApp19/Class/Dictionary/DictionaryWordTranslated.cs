using ConsoleApp19.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using ConsoleApp19.Interface;
using ConsoleApp19.Class.Word;

namespace ConsoleApp19.Class.Dictionary
{
    public class DictionaryWordTranslated : IDictionaryWordTranslated
    {
        public Dictionary<string, WordTranslate> WordTranslates { get; set; } = new Dictionary<string, WordTranslate>();
        public TranslationMode translationMode { get; set; }
        public WordTranslate? this[string i]
        {
            get
            {
                if (WordTranslates.ContainsKey(i)) return WordTranslates[i];
                return null;
            }
        }

        public void AddWordTranslated(WordTranslate wordtranslate)
        {
            if (!WordTranslates.ContainsKey(wordtranslate.Word))
            {
                WordTranslates.Add(wordtranslate.Word, wordtranslate);
            }
        }
        public bool DeleteWordTranslated(string word)
        {
           return WordTranslates.Remove(word);
        }
        public void AddTranslated(string word, string translatedword)
        {
            if (WordTranslates.ContainsKey(word))
                WordTranslates[word].AddTranslated(translatedword);
        }
        public bool DeleteTranslated(string word, string translatedword)
        {
            if (WordTranslates.ContainsKey(word))
            {
                return WordTranslates[word].DeleteTranslated(translatedword);
            }
            return false;
        }
    }
}
