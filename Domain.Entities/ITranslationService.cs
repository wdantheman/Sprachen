using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface ITranslationService
    {
        public List<string> GetTranslations(string text);
        public List<string> GetMeaningsInTargetLanguage(string word);
    }
}
