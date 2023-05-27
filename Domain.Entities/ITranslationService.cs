using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal interface ITranslationService
    {
        public List<string> GetTranslations(string text);
        public List<string> GetMeaningsInSourceLanguage(string word);
    }
}
