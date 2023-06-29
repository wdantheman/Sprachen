using Domain.Entities.DataObjects;

namespace Domain.Entities.PersistenceServices
{
    public interface ILanguagesComponentSettingsService
    {
        public LanguagesComponent GetLanguagesComponentFromDocument(int documentId);
        public LanguagesComponent GetLanguagesComponentFromDocumentSubsection(int documentId, int subsectionId);
        public void SetLanguagesComponentInDocument(LanguagesComponent languagesComponent, int documentId);
        public void SetLanguagesComponentInDocumentSubsection(LanguagesComponent languagesComponent, int documentId, int subsectionId);
    }
}
