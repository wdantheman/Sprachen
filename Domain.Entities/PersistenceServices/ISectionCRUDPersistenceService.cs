using Domain.Entities.DataObjects.DocumentComposite;


namespace Domain.Entities.PersistenceServices
{
    public interface ISectionCRUDPersistenceService
    {
        public void CreateSectionInDocument(int documentId, SectionComponent section);
        public void DeleteSectionInDocument(int documentId, int sectionId);
        public void UpdateSectionInDocument(int documentId, int sectionId, SectionComponent newSection);
        public SectionComponent ReadSectionInDocument(int documentId, int sectionId);

    }
}
