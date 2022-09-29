using ConsoleApp19.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp19.Class.Dictionary
{
    public static class DictionaryWordTranslatedFileService
    {
        public static void SaveDictionaryWordTranslated(DictionaryWordTranslated dictionaryWordTranslated)
        {
            string SaveAs = dictionaryWordTranslated.translationMode == TranslationMode.EngRus ? "EngRus.json " : "RusEng.json";
            using (FileStream fs = new FileStream(SaveAs, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    JsonSerializerOptions serializerOptions = new JsonSerializerOptions() { WriteIndented = true };
                    sw.WriteLine(JsonSerializer.Serialize(dictionaryWordTranslated));
                }
            }
        }

        public static DictionaryWordTranslated DownoloadAs(TranslationMode translationMode)
        {
            string SaveAs = translationMode == TranslationMode.EngRus ? "EngRus.json " : "RusEng.json";
            string? DownoloadDictionary;
            using (FileStream fs = new FileStream(SaveAs, FileMode.OpenOrCreate))
            {
                using (StreamReader sw = new StreamReader(fs))
                {
                    DownoloadDictionary = sw.ReadLine();
                }
            }
            if (DownoloadDictionary != null)
            {
                DictionaryWordTranslated? a = JsonSerializer.Deserialize<DictionaryWordTranslated>(DownoloadDictionary);
                if (a != null)
                {
                    return a;
                }
                throw new NullReferenceException();
            }
            return new DictionaryWordTranslated() { translationMode = translationMode };
        }


    }
}
