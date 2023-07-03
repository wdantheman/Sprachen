using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.DocumentPersistence;

namespace Domain.UseCases.DocumentUseCases
{
    public class DocumentConfigUseCase
    {
        internal IDocumentConfigPersistenceService ConfigurationService;
        public DocumentConfigUseCase(IDocumentConfigPersistenceService configService)
        {
            ConfigurationService = configService;
        }
        public void UpdateDescriptionInDB(int docId, string newDescription)
        {
            ConfigurationService.UpdateDocumentDescrition(docId, newDescription);
        }
        public void UpdateDescription(Document document, string newDescription)
        {
            document.UpdateDescription(newDescription);
        }
        public void UpdateDocumentLanguagesComponentInDB(int id, LanguagesComponent languagesComponent)
        {
            ConfigurationService.UpdateDocumentLanguagesComponent(id, languagesComponent);
        }
    }
}
