using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class DocumentCRUDUseCase
    {
        internal IDocumentPersistenceService PersistenceService;
        internal IObjectIdentifierService IdentifierService;
        internal IDocumentFinderService DocumentFinderService;
        public DocumentCRUDUseCase(IDocumentPersistenceService persistenceService, IObjectIdentifierService identifierService, 
        IDocumentFinderService documentFinder)
        {
            PersistenceService = persistenceService;
            IdentifierService = identifierService;
            DocumentFinderService = documentFinder;

        }
        public Document CreateEmptyDocument()
        {
            int id = IdentifierService.CreateId();
            string defaultName = " Empty Document";
            Document newDoc = new(id, defaultName, new List<SectionComponent>());
            return newDoc;
        }
        public Document CreateDocumentWithName(string name)
        {
            int id = IdentifierService.CreateId();
            return new Document(id, name, new List<SectionComponent>());
        }

        public Document ReadDocumentById(int id) 
        {
            return PersistenceService.ReadDocument(id);
        }
        public Document ReadDocumentByName(string name) 
        {
            return documentFinder.GetDocumentByName(name);
        }

        public void DeleteDocument(int id)
        {
            persistenceService.DeleteDocument(id);
        }

        public void UpdateDocument()
        {
            
        }


    }
}
