using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.PersistenceServices.SectionPersistenceServices
{
    public interface ISectionConfigurationPersistenceService
    {
        public void UpdateSectionLanguagesComponent(int docId, int sectionId, LanguagesComponent languagesComponent);
        public void AddSectionToSection(int docId, int sectionId, SectionComponent sectionComponent);
        public void RemoveSectionfromSection(int docId, int containingSectionId, int subsectionToRemoveId);
        public void AddEntry(int docId, int sectionId, string entry);
        public void RemoveEntry(int docId, int sectionId, int entryId);
    }
}
