using ConsoleApp19.Class.Word;
using ConsoleApp19.Enum;
using ConsoleApp19.Class.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp19.Class.Dictionary
{
    public static class DictionaryWordMenu
    {

        private static void AddWordTranslate(DictionaryWordTranslated dictionaryWord, string word, bool ModeAdd)
        {
            sbyte Select = 0;
            if (ModeAdd == true)
            {
                Console.Write("\nТакого слово нет. Желаете добавить (0 - да, 1 - нет) : ");
                Select = Convert.ToSByte(Console.ReadLine());
            }
            if (Select == 0)
            {
                string? word1;
                do
                {
                    Console.Write("\nвведите слова переводы : ");
                    word1 = Console.ReadLine();
                } while (!Regex.IsMatch(word1, dictionaryWord.translationMode == TranslationMode.RusEng ? @"^[a-zA-Z ]+$" : @"^[А-Яа-я ]+$"));

                var words = word1.Split(" ");
                WordTranslate translate = new WordTranslate { Word = word, TranslatedWord = new List<string>(words) };
                dictionaryWord.AddWordTranslated(translate);
                Console.WriteLine(dictionaryWord[word]?.ToString());
            }
        }

        private static void SearchTranslate(DictionaryWordTranslated dictionaryWord, bool ModeAddException)
        {
            Console.Clear();
            Console.Write("введите слово для перевода : ");
            var word = Console.ReadLine();

            if (word != null && Regex.IsMatch(word, dictionaryWord.translationMode == TranslationMode.RusEng ? @"^[А-Яа-я ]+$" : @"^[a-zA-Z ]+$"))
            {
                if (dictionaryWord[word] != null) Console.WriteLine($"\n{dictionaryWord[word]?.ToString()}");
                else AddWordTranslate(dictionaryWord, word, ModeAddException);
            }
            else
            {
                Console.Clear();
                ColorString.PrintStringColor("вы не правильно ввели слово", ConsoleColor.Red);
            }
            Thread.Sleep(2500);
        }

        private static void DeleteWorDeleteWordTranslated(DictionaryWordTranslated dictionaryWord)
        {
            Console.Clear();
            Console.Write("введите слово для удаление : ");
            var word = Console.ReadLine();
            if (word != null)
            {
                var didtheword = dictionaryWord.DeleteWordTranslated(word);
                Console.Clear();
                if (didtheword == true) ColorString.PrintStringColor("слово удалено", ConsoleColor.Blue);
                if (didtheword == false) ColorString.PrintStringColor("Слово не найдено", ConsoleColor.Red);
            }
            Thread.Sleep(2000);
            Console.Clear();
        }

        private static void DeleteTranslated(DictionaryWordTranslated dictionaryWord)
        {
            Console.Clear();
            Console.Write("введите слово для удаление перевода : ");
            var word = Console.ReadLine();
            if (word != null)
            {
                if (dictionaryWord[word] != null)
                {
                    Console.Clear();
                    Console.WriteLine(dictionaryWord[word]?.ToString());
                    Console.Write("введите перевод который нaдо удалить : ");
                    var word1 = Console.ReadLine();
                    if (word1 != null)
                    {
                        var didtheword = dictionaryWord[word]?.DeleteTranslated(word1);

                        if (didtheword == true) Console.WriteLine(dictionaryWord[word]?.ToString());
                        else ColorString.PrintStringColor("не смогли удалить", ConsoleColor.Red);
                    }
                }
                else ColorString.PrintStringColor("слово не найдено " , ConsoleColor.Red);
                Thread.Sleep(2000);
            }
        }

        private static void AddTranslated(DictionaryWordTranslated dictionaryWord)
        {

            Console.Clear();
            Console.Write("введите слово для добавление перевода : ");
            var word = Console.ReadLine();
            if (word != null)
            {
                if (dictionaryWord[word] != null)
                {
                    Console.Clear();
                    Console.WriteLine(dictionaryWord[word]?.ToString());
                    Console.Write("введите слово которое надо добавить : ");
                    var word1 = Console.ReadLine();
                    if (word1 != null && Regex.IsMatch(word, dictionaryWord.translationMode == TranslationMode.RusEng ? @"^[А-Яа-я ]+$" : @"^[a-zA-Z ]+$"))
                    {
                        dictionaryWord[word]?.AddTranslated(word1);
                        Console.WriteLine(dictionaryWord[word]?.ToString());
                    }
                    else ColorString.PrintStringColor("неправильно ввели слово" , ConsoleColor.Red);

                }
                else ColorString.PrintStringColor("слово не найдено " , ConsoleColor.Red);
                Thread.Sleep(2000);
            }
        }

        private static void RedactTranslate(DictionaryWordTranslated dictionaryWord)
        {
            Console.Clear();
            sbyte Select;
            do
            {
                Console.Write("Выберите 0 - добавить слово , 1 - удалить слово , 2 - удалить перевод , 3 - добавить перевод , 4 - назад: ");
                Select = Convert.ToSByte(Console.ReadLine());

                switch (Select)
                {
                    case 0:
                        SearchTranslate(dictionaryWord, false);
                        break;
                    case 1:
                        DeleteWorDeleteWordTranslated(dictionaryWord);
                        break;
                    case 2:
                        DeleteTranslated(dictionaryWord);
                        break;
                    case 3:
                        AddTranslated(dictionaryWord);
                        break;
                }
                Console.Clear();
            } while (Select != 4);
        }

        public static void DictionaryMenu()
        {
            Console.Write("Выберите  0 - EngRus , 1 - RusEng : ");
            var Select = Convert.ToSByte(Console.ReadLine());
            DictionaryWordTranslated wordTranslated = DictionaryWordTranslatedFileService.DownoloadAs(Select == 0 ? TranslationMode.EngRus : TranslationMode.RusEng);
            Console.Clear();
            do
            {
                Console.Write("Выберите 0 - редактирование переводов , 1 - поиск перевода , 2 - сохранить и выйти : ");
                Select = Convert.ToSByte(Console.ReadLine());

                switch (Select)
                {
                    case 0:
                        RedactTranslate(wordTranslated);
                        break;
                    case 1:
                        SearchTranslate(wordTranslated, true);
                        break;
                }
                Console.Clear();
            } while (Select != 2);
            DictionaryWordTranslatedFileService.SaveDictionaryWordTranslated(wordTranslated);
            Environment.Exit(0);
        }
    }
}
