

namespace Domain.Entities.PersistenceServices
{
    public interface IDocumentLanguagesPersistenceService
    {
        public Language GetDocumentSourceLanguage(int id);
        public List<Language> GetDocumentTargetLanguage(int id);
        public void SetDefaultLanguageInDocument(int documentId, Language language);
        public void SetDefaultTargetLanguagesInDocument(int documentId, List<Language> languages);
        public void AddTargetLanguagetoDocument(int documentId, Language language);
        public void RemoveTargetLanguagetoDocument(int documentId, Language language);
    }
}
