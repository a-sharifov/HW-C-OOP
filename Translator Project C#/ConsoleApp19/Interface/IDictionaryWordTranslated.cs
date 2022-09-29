using ConsoleApp19.Class.Word;

namespace ConsoleApp19.Interface
{
    public interface IDictionaryWordTranslated
    {
        void AddTranslated(string word, string translatedword);
        void AddWordTranslated(WordTranslate wordtranslate);
        bool DeleteTranslated(string word, string translatedword);
        bool DeleteWordTranslated(string word);
    }
}