using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;

namespace Domain.Entities.PersistenceServices.EntryPersistenceServices
{
    public interface ISectionEntryInSectionCRUDPersistenceService
    {
        public SectionComposite GetSectionComposite(int DocumentId, int SectionId);
        public Entry ReadEntryinSection(int documentId, int entryId);
        public void CreateEntryinSection(int documentId, int sectionID, Entry newEntry);
        public void UpdateEntryinSection(int documentId, int sectionId, int oldEntryId, Entry newEntry);
        public void DeleteEntryinSection(int documentId, int sectionId, int entryId);     

    }
}
