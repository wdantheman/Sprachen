using Domain.Entities;
using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.DocumentPersistence;

namespace Domain.UseCases.DocumentUseCases
{
    public class DocumentCRUDUseCase
    {
        internal IDocumentCRUDPersistenceService PersistenceService;
        internal IObjectIdentifierService IdentifierService;
        public DocumentCRUDUseCase(IDocumentCRUDPersistenceService persistenceService, IObjectIdentifierService identifierService)
        {
            PersistenceService = persistenceService;
            IdentifierService = identifierService;
        }
        public Document CreateEmptyDocument()
        {
            int id = IdentifierService.CreateObjectId();
            string defaultName = "Empty Document";
            Document newDoc = new(id, defaultName, new List<SectionComponent>(), new LanguagesComponent(IdentifierService.CreateSubObjectId(id)));
            return newDoc;
        }
        public Document CreateDocumentWithName(string name)
        {
            int id = IdentifierService.CreateObjectId();
            return new Document(id, name, new List<SectionComponent>(), new LanguagesComponent(IdentifierService.CreateSubObjectId(id)));
        }
        public Document CreateDocumentWithSectionsAndName(string name, List<SectionComponent> sections)
        {
            int id = IdentifierService.CreateObjectId();
            return new Document(id, name, sections, new LanguagesComponent(IdentifierService.CreateSubObjectId(id)));
        }
        public void CreateDocumentInDB(Document doc)
        {
            PersistenceService.CreateDocument(doc);
        }
        public Document ReadDocumentById(int id)
        {
            return PersistenceService.ReadDocument(id);
        }
        public Document ReadDocumentByName(IDocumentFinderService DocumentFinderService, string name)
        {
            return DocumentFinderService.GetDocumentByName(name);
        }
        public void DeleteDocumentInDB(int id)
        {
            PersistenceService.DeleteDocument(id);
        }
        public void UpdateDocumentInDB(int id, Document documentUpdate)
        {
            PersistenceService.UpdateDocument(id, documentUpdate);
        }        
    }
}
