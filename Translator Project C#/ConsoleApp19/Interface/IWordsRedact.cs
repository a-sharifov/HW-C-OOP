using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19.Interface
{
    public interface IWordsRedact
    {
        void SwapWord(string word);
        void AddTranslated(string translatedword);
        bool DeleteTranslated(string translatedword);
    }
}
