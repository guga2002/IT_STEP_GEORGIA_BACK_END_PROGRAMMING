using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateApp
{
    public interface ITranslator
    {
        void Run();
        void LoadDictionary(string filePath);
        void DisplayLanguages();
        int GetLanguageIndex();
        void Translate(int sourceLanguageIndex, int targetLanguageIndex, string input);
        void UpdateDictionaryFile(string filePath);
    }
}
