using Domain.Entities.DataObjects;

namespace Domain.Entities.PersistenceServices.DocumentPersistence
{
    public interface IDocumentConfigPersistenceService
    {
        public void UpdateDocumentDescrition(int id, string newDescription);
        public void UpdateDocumentLanguagesComponent(int id, LanguagesComponent languageComponent);

    }
}
