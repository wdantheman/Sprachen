using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.PersistenceServices.DocumentPersistence
{
    public interface IDocumentFinderService
    {
        public Document GetDocumentByName(string name);
        public Document GetDocumentById(int id);
        public LanguagesComponent GetDefaultLanguageComponentForDocument(int id);

    }
}