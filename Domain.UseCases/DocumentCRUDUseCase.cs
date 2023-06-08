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



    }
}
