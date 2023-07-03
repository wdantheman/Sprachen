namespace Domain.Entities.DataObjects
{
    public interface ILanguagesComponent
    {
        public void AddTargetLanguage(Language language);
        public void RemoveTargetLanguage(Language language);
        public List<Language> GetTargetLanguages();
        public Language GetSourceLanguage();
        public void SetSourceLanguage(Language language);
        public void SetTargetLanguages(List<Language> targetLanguages);
        public int GetId();
    }
}
