using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TranslateApp
{
    public abstract class AbstractTranslator : ITranslator
    {
        private static readonly List<string> Languages = new List<string> { "English", "Spanish", "French" };

        protected Dictionary<string, Dictionary<string, string>> dictionary;

        protected AbstractTranslator()
        {
            dictionary = new Dictionary<string, Dictionary<string, string>>();
        }

        public abstract void Run();

        public void LoadDictionary(string filePath)
        {
            dictionary = new Dictionary<string, Dictionary<string, string>>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    string sourceLanguage = parts[0].Trim();
                    string targetLanguage = parts[1].Trim();
                    string translation = parts[2].Trim();

                    if (!dictionary.ContainsKey(sourceLanguage))
                    {
                        dictionary[sourceLanguage] = new Dictionary<string, string>();
                    }

                    dictionary[sourceLanguage][targetLanguage] = translation;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: Dictionary file '{filePath}' not found.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading dictionary: {ex.Message}");
                Environment.Exit(1);
            }
        }

        public void DisplayLanguages()
        {
            int index = 1;
            foreach (var language in Languages)
            {
                Console.WriteLine($"{index}. {language}");
                index++;
            }
        }

        public int GetLanguageIndex()
        {
            while (true)
            {
                Console.Write("Enter the language index: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= dictionary.Count)
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid language index.");
                }
            }
        }

        public void Translate(int sourceLanguageIndex, int targetLanguageIndex, string input)
        {
            string sourceLanguage = Languages.ElementAt(sourceLanguageIndex - 1);
            string targetLanguage = Languages.ElementAt(targetLanguageIndex - 1);

            string sourceWord = input;

            if (dictionary.ContainsKey(sourceWord) && dictionary[sourceWord].ContainsKey(targetLanguage))
            {
                string translation = dictionary[sourceWord][targetLanguage].Replace("{word}", input);
                Console.WriteLine($"Translation from {sourceWord} to {targetLanguage}: {translation}");
            }
            else
            {
                Console.WriteLine($"Translation not available for '{input}' from {sourceWord} to {targetLanguage}.");

                Console.Write("Do you want to add the translation to the dictionary? (yes/no): ");
                string response = Console.ReadLine().ToLower();

                if (response == "yes")
                {
                    if (!dictionary.ContainsKey(sourceWord))
                    {
                        dictionary[sourceWord] = new Dictionary<string, string>();
                    }

                    dictionary[sourceWord][targetLanguage] = input;

                    UpdateDictionaryFile("dictionary.txt");
                }
            }
        }


        public void UpdateDictionaryFile(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var sourceWord in dictionary.Keys)
                    {
                        foreach (var targetLanguage in dictionary[sourceWord].Keys)
                        {
                            string translation = dictionary[sourceWord][targetLanguage];
                            sw.WriteLine($"{sourceWord} : {targetLanguage} : {translation}");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating dictionary file: {ex.Message}");
            }
        }
    }
}
