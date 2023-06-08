using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class DocumentCRUDUseCase
    {
        internal IDocumentPersistenceService PersistenceService;
        internal IObjectIdentifierService IdentifierService;
        public DocumentCRUDUseCase(IDocumentPersistenceService persistenceService, IObjectIdentifierService identifierService)
        {
            PersistenceService = persistenceService;
            IdentifierService = identifierService;
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
            throw new NotImplementedException();
        }


    }
}
