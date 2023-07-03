using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.PersistenceServices.SectionPersistenceServices
{
    internal interface ISectionComponentCRUDPersistenceService
    {
        public void CreateSectionComponentInSection(int documentId, int sectionId, SectionComponent newSection);
        public SectionComponent ReadSectionComponentInSection(int documentId, int sectionComponent);
        public void UpdateSectionComponentInSection(int documentId, int sectionId, int SectionComponent, SectionComponent newComponent);
        public void RemoveSectionComponentInSection(int documentId, int sectionId, int sectionComponentId);
    }
}
