using Domain.Entities;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.EntriesUseCases
{
    public class CreateEntryUseCase
    {
        internal IObjectIdentifierService IdentifierService;
        internal IEntryCreatorCriteria CreatorCriteria;
        public CreateEntryUseCase(IObjectIdentifierService objectIdCreator, IEntryCreatorCriteria criteria)
        {
            IdentifierService = objectIdCreator;
            CreatorCriteria = criteria;
        }
        public Entry CreateEmptyEntry(int sourceDocumentId)
        {
            return new Entry(IdentifierService.CreateSubObjectId(sourceDocumentId), " ");
        }
        public Entry CreateEntry(int sourceDocumentId, string content)
        {
            if (!CreatorCriteria.IsContentValid(content))
            {
                throw new CreateEntryUseCaseException("the Content input is not valid");
            }
            else 
            {
                return new Entry(IdentifierService.CreateSubObjectId(sourceDocumentId), content);
            }            
        }
    }
}
