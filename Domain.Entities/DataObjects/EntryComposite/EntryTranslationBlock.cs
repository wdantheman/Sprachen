namespace Domain.Entities.DataObjects.EntryComposite
{
    public class EntryTranslationBlock
    {
        internal ILanguagesComponent TargetLanguages;
        internal Dictionary<Language, TranslationComponent> TargetTranslations;
        public EntryTranslationBlock(ILanguagesComponent targetLanguages)
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
            return TargetLanguages.GetTargetLanguages();
        }
        public Dictionary<Language, TranslationComponent> GetTranslationComponents() 
        {
            return TargetTranslations;
        }
    }
}
