using Domain.Entities;
using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.DocumentPersistence;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.DocumentUseCases
{
    public class DocumentCRUDPersistenceUseCase
    {
        internal IDocumentCRUDPersistenceService PersistenceService;
        internal IObjectIdentifierService IdentifierService;
        internal IDocumentCreatorCriteria DocumentValidator;
        public DocumentCRUDPersistenceUseCase(IDocumentCRUDPersistenceService persistenceService, 
            IObjectIdentifierService identifierService,
            IDocumentCreatorCriteria documentValidator)
        {
            PersistenceService = persistenceService;
            IdentifierService = identifierService;
            DocumentValidator = documentValidator;
        }
        public void CreateDocumentInDB(Document doc)
        {
            if (!DocumentValidator.IsDocumentValid(doc))
            {
                throw new CreateDocumentUseCaseException("DocumentCRUDPersistenceUseCase couldn't create invalid Document");
            }
            else 
            {
                PersistenceService.CreateDocument(doc);
            }
        }
        public Document ReadDocumentById(int id)
        {
            return PersistenceService.ReadDocument(id);
        }
        public Document ReadDocumentByName(IDocumentFinderService DocumentFinderService, string name)
        {
            return DocumentFinderService.GetDocumentByName(name);
        }
        public void DeleteDocumentInDB(int id, IDocumentConfigCriteria criteria)
        {
            if (criteria.IsDocumentDeleatable(id)) 
            {
                PersistenceService.DeleteDocument(id);
            }
        }
        public void UpdateDocumentInDB(int id, Document documentUpdate)
        {
            if (!DocumentValidator.IsDocumentValid(documentUpdate))
            {
                throw new CreateDocumentUseCaseException("DocumentCRUDPersistenceUseCase couldn't update invalid Document");
            }
            else
            {
                PersistenceService.UpdateDocument(id, documentUpdate);
            }
        }        
    }
}
