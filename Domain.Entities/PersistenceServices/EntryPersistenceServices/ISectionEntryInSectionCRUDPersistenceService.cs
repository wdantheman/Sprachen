using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;

namespace Domain.Entities.PersistenceServices.EntryPersistenceServices
{
    public interface ISectionEntryInSectionCRUDPersistenceService
    {
        public SectionComposite GetSectionComposite(int DocumentId, int SectionId);
        public void CreateEntryinSection(int documentId, Entry newEntry);
        public void DeleteEntryinSection(int documentId, int entryId);
        public void UpdateEntryinSection(int documentId, int oldEntryId, Entry newEntry);
        public Entry ReadEntryinSection(int entryId);

    }
}
