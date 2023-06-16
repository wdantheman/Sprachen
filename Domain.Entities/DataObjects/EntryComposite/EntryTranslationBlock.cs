

namespace Domain.Entities.DataObjects.EntryComposite
{
    public class EntryTranslationBlock
    {
        internal LanguagesComponent TargetLanguages;
        internal Dictionary<Language, TranslationComponent> TargetTranslations;
        public EntryTranslationBlock(LanguagesComponent targetLanguages)
        {
            TargetLanguages = targetLanguages;
            TargetTranslations = new Dictionary<Language, TranslationComponent>();
        }
        public void AddTranslationComponentToLenguage(TranslationComponent translation, Language language) 
        {
            TargetTranslations.Add(language, translation);
        }
        public void RemoveTranslationComponentFromLenguage(Language language) 
        {
            TargetTranslations.Remove(language);
        }
        public List<Language> GetBlockLanguages() 
        {
            return TargetLanguages;
        }
        public Dictionary<Language, TranslationComponent> GetTranslationComponents() 
        {
            return TargetTranslations;
        }
    }
}
