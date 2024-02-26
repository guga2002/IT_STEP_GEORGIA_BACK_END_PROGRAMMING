using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateApp
{
    internal class Translator : AbstractTranslator
    {
        public Translator()
        {
            LoadDictionary("../../../dictionary.txt");
        }
        public override void Run()
        {
            Console.WriteLine("Welcome to the Translator Application!");

            while (true)
            {
                Console.Write("\nEnter the word or phrase to translate: ");
                string input = Console.ReadLine();

                Console.WriteLine("\nChoose the source language:");
                DisplayLanguages();

                int sourceLanguageIndex = GetLanguageIndex();

                Console.WriteLine("\nChoose the target language:");
                DisplayLanguages();

                int targetLanguageIndex = GetLanguageIndex();

                Translate(sourceLanguageIndex, targetLanguageIndex, input);
            }
        }
    }
}
