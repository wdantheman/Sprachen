using Domain.Entities;
using Domain.Entities.PersistenceServices;
using System;

namespace Domain.UseCases
{
    public class LanguagesSettingUseCase
    {
        internal IDocumentLanguagesPersistenceService DocumentLanguagesService;
        public LanguagesSettingUseCase(IDocumentLanguagesPersistenceService documentLanguagesService)
        {
            DocumentLanguagesService = documentLanguagesService;
        }
        public void SetDefaultLanguageInDocument(int documentId, Language newDefault)
        {
            DocumentLanguagesService.SetDefaultLanguageInDocument(documentId, newDefault);
        }
        public void SetDefaultTargetLanguagesInDocument(int documentId, List<Language> targetLanguages)
        {
            DocumentLanguagesService.SetDefaultTargetLanguagesInDocument(documentId, targetLanguages);
        }
        public Language GetDocumentDefaultLanguage(int documentId) 
        {
            return DocumentLanguagesService.GetDocumentSourceLanguage(documentId);
        }
        public List<Language> GetDocumentDefaultTargetLanguages(int documentId) 
        {
            return DocumentLanguagesService.GetDocumentTargetLanguage(documentId);
        }
        public void AddTargetLanguageToDefaultsInDocument(int documentId, Language language) 
        {
            DocumentLanguagesService.AddTargetLanguagetoDocument(documentId, language);
        }
        public void RemoveTargetLanguageFromDefaultsInDocument(int documentId, Language language)
        {
            DocumentLanguagesService.RemoveTargetLanguagetoDocument(documentId, language);
        }

    }
}
