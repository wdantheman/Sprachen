using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.PersistenceServices.SectionPersistenceServices
{
    public interface ISectionConfigurationPersistenceService
    {
        public void UpdateSectionsLanguagesComponent(int docId, int sectionId, LanguagesComponent languagesComponent);
        public void AddSectiontoSection(int docId, int sectionId, SectionComponent sectionComponent);
        public void RemoveSectionfromSection(int docId, int containingSectionId, int subsectionToRemoveId);
        public void AddEntry(int docId, int sectionId, string entry);
        public void RemoveEntry();
    }
}
