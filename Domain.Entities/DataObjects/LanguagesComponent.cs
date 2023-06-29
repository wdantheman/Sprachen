
using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects
{
    public class LanguagesComponent : ILanguagesComponent
    {
        private int _id { get; set; }
        private List<Language> TargetLanguages;
        private Language SourceLanguage;

        public LanguagesComponent(int id)
        {
            TargetLanguages = new List<Language>();
            SourceLanguage = Language.English;
            _id = id;
        }
        public LanguagesComponent(Language source, List<Language> targetLanguages)
        {
            TargetLanguages = targetLanguages;
            SourceLanguage = source;
        }
        public void AddTargetLanguage(Language language)
        {
            if (TargetLanguages.Contains(language))
            {
                throw new LanguagesComponentException("Language already exist in list");
            }
            else TargetLanguages.Add(language);
        }
        public void RemoveTargetLanguage(Language language)
        {
            TargetLanguages.Remove(language);
        }
        public List<Language> GetTargetLanguages()
        {
            return TargetLanguages;
        }
        public Language GetSourceLanguage()
        {
            return SourceLanguage;
        }
        public void SetSourceLanguage(Language language) 
        {
            SourceLanguage = language;
        }
        public void SetTargetLanguages(List<Language> targetLanguages) 
        {
            TargetLanguages = targetLanguages;
        }
        public int GetId() 
        {
            return _id;
        }
    }
}
