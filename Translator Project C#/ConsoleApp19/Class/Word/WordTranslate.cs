using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp19.Enum;
using ConsoleApp19.Interface;

namespace ConsoleApp19.Class.Word
{
    public class WordTranslate : IWordsRedact
    {
        public string Word { get; set; }
        public List<string> TranslatedWord { get; set; } = new List<string>();
        public void SwapWord(string word) { Word = word; }
        public void AddTranslated(string translatedword) { TranslatedWord.Add(translatedword); }
        public bool DeleteTranslated(string translatedword)
        {
            if (TranslatedWord.Count > 1)
            {
                return TranslatedWord.Remove(translatedword);
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{Word} - ");
            foreach (var item in TranslatedWord)
            {
                stringBuilder.Append($"{item}, ");
            }

            return stringBuilder.ToString();
        }

    }

}
