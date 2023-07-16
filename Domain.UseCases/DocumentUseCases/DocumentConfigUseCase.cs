using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.DocumentPersistence;

namespace Domain.UseCases.DocumentUseCases
{
    // rename this to DocumentConfigPresistenceUseCase
    public class DocumentConfigUseCase
    {
        internal IDocumentConfigPersistenceService PersistenceConfigurationService;
        internal IDocumentConfigCriteria ConfigCriteriaService;
        public DocumentConfigUseCase(IDocumentConfigPersistenceService configService, IDocumentConfigCriteria criteria)
        {
            PersistenceConfigurationService = configService;
            ConfigCriteriaService = criteria;
        }
        public void UpdateDescriptionInDB(int docId, string newDescription)
        {
            if (ConfigCriteriaService.IsDescriptionValid(newDescription)) 
            {
                PersistenceConfigurationService.UpdateDocumentDescrition(docId, newDescription);
            }
        }
        public void UpdateDocumentLanguagesComponentInDB(int id, LanguagesComponent languagesComponent)
        {
            PersistenceConfigurationService.UpdateDocumentLanguagesComponent(id, languagesComponent);
        }
        public void UpdateDocumentNameInDb(int id, string newName)
        {
            if (ConfigCriteriaService.IsNameValid(newName))
            {
                PersistenceConfigurationService.UpdateDocumentName(id, newName);
            }
        }
        public void UpdateDescription(Document document, string newDescription)
        {
            if (ConfigCriteriaService.IsDescriptionValid(newDescription))
            {
                document.UpdateDescription(newDescription);
            }
        }
        public void UpdateDocumentLanguagesComponent(Document document, LanguagesComponent newLanguagesComponent) 
        {
            document.SetLanguageComponent(newLanguagesComponent);
        }
        public void UpdateDocumentName(Document doc, string newName) 
        {
            if (ConfigCriteriaService.IsNameValid(newName)) 
            {
                doc.SetName(newName);
            }
        }
    }
}
