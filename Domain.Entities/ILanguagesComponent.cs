using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface ILanguagesComponent
    {
        public void AddTargetLanguage(Language language);
        public void RemoveTargetLanguage(Language language);
        public List<Language> GetTargetLanguages();
        public Language GetSourceLanguage();
        public void SetSourceLanguage(Language language);
        public void SetTargetLanguages(List<Language> targetLanguages);
    }
}
