using Domain.Entities.PersistenceServices;
using Domain.Entities;
using Domain.Entities.PersistenceServices.SectionPersistenceServices;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.SectionUseCases
{
    public class SectionsInSectionCRUDUseCase
    {
        internal IObjectIdentifierService IdentityCreator;
        internal ISectionConfigCriteria Criteria;
        internal SectionComposite LocalSection;

        public SectionsInSectionCRUDUseCase(IObjectIdentifierService objectIdentifierService, ISectionConfigCriteria criteria, SectionComposite localSection)
        {
            IdentityCreator= objectIdentifierService;
            Criteria= criteria;
            LocalSection= localSection;
        }
        public void ResetTargetSection(SectionComposite section)
        {
            LocalSection = section ?? throw new ArgumentNullException(nameof(section));
        }
        public SectionComposite GetTargetSection() 
        {
            return LocalSection ?? throw new ArgumentNullException("no target sections is set");
        }
        public void CreateEmptySubsectionToSection()
        {
            SectionComposite tempSection = new SectionComposite("Empty Section", IdentityCreator.CreateSubObjectId(LocalSection.SourceDocument),
                LocalSection.LanguagesComponent, LocalSection.DocSectionId);
            LocalSection.Subsections.Add(tempSection);
        }
        public void AddSubsectionToSection(SectionComposite section) 
        {
            if (section == null) 
            {
                throw new SectionsCRUDUseCaseException("Subsection to add is null");
            }
            if (!Criteria.IsSectionValid(section))
            {
                throw new SectionsInDocumentCRUDUseCaseException("the section to add is not Valid");
            }
            else
            {
                LocalSection.Subsections.Add(section);
            }
        }
        public List<SectionComponent> ReadSections()
        {
            return LocalSection.Subsections;
        }
        public SectionComponent ReadSectionById(int sectionId)
        {
            if (LocalSection.Subsections.Where(section => section.DocSectionId == sectionId).Count() == 0)
            {
                throw new SectionsInDocumentCRUDUseCaseException("the section Id didn't returned results");
            }
            else if (LocalSection.Subsections.Where(section => section.DocSectionId == sectionId).Count() > 1)
            {
                return LocalSection.Subsections.Where(section => section.DocSectionId == sectionId).First();
                throw new SectionsInDocumentCRUDUseCaseException("the section Id had a duplicated id, the first result was returned");
            }
            else
            {
                return LocalSection.Subsections.Where(section => section.DocSectionId == sectionId).First();
            }
        }
        public SectionComponent ReadSectionByTitle(string title)
        {
            if (LocalSection.Subsections.Where(section => section.Title == title).Count() == 0)
            {
                throw new SectionsInDocumentCRUDUseCaseException("the section Title didn't returned results");
            }
            else if (LocalSection.Subsections.Where(section => section.Title == title).Count() > 1)
            {
                return LocalSection.Subsections.Where(section => section.Title == title).First();
                throw new SectionsInDocumentCRUDUseCaseException("the section Id had a duplicated id, the first result was returned");
            }
            else
            {
                return LocalSection.Subsections.Where(section => section.Title == title).First();
            }
        }
        public void UpdateSections(List<SectionComponent> newSections)
        {
            if (!Criteria.AreSectionsValid(newSections))
            {
                throw new SectionsInDocumentCRUDUseCaseException("Sections couldn't be Updated as they weren't Valid");
            }
            else
            {
                LocalSection.SetSubsections(newSections);
            }
        }
        public void DeleteSectionFromSection(int sectionId)
        {
            List<SectionComponent> localList = LocalSection.Subsections;
            SectionComponent LocalComponent = LocalSection.Subsections.Where(section => section.DocSectionId == sectionId).First();
            if (!Criteria.CanSectionBeRemoved(LocalComponent))
            {
                throw new SectionsInDocumentCRUDUseCaseException("Section couldn't be Removed");
            }
            else
            {
                localList.Remove(LocalComponent);
                LocalSection.SetSubsections(localList);
            }
        }
    }
}
