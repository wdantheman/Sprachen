using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
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
                LocalSection.LanguagesComponent, LocalSection.SectionIdDoc, LocalSection.SectionIdDoc);
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
                throw new SectionsCRUDUseCaseException("the section to add is not Valid");
            }
            else
            {
                section.ParentObjectId = LocalSection.SectionIdDoc;
                LocalSection.Subsections.Add(section);
            }
        }
        public List<SectionComponent> ReadSections()
        {
            return LocalSection.Subsections;
        }
        public SectionComponent ReadSectionById(int sectionId)
        {
            if (LocalSection.Subsections.Where(section => section.SectionIdDoc == sectionId).Count() == 0)
            {
                throw new SectionsCRUDUseCaseException("the section Id didn't returned results");
            }
            else if (LocalSection.Subsections.Where(section => section.SectionIdDoc == sectionId).Count() > 1)
            {
                return LocalSection.Subsections.Where(section => section.SectionIdDoc == sectionId).First();
                throw new SectionsCRUDUseCaseException("the section Id had a duplicated id, the first result was returned");
            }
            else
            {
                return LocalSection.Subsections.Where(section => section.SectionIdDoc == sectionId).First();
            }
        }
        public SectionComponent ReadSectionByTitle(string title)
        {
            if (LocalSection.Subsections.Where(section => section.Title == title).Count() == 0)
            {
                throw new SectionsCRUDUseCaseException("the section Title didn't return any results");
            }
            else if (LocalSection.Subsections.Where(section => section.Title == title).Count() > 1)
            {
                return LocalSection.Subsections.Where(section => section.Title == title).First();
                throw new SectionsCRUDUseCaseException("the section Id had a duplicated id, the first result was returned");
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
                throw new SectionsCRUDUseCaseException("Sections couldn't be Updated as they weren't Valid");
            }
            else
            {
                LocalSection.SetSubsections(newSections);
            }
        }
        public void DeleteSectionFromSection(int sectionId)
        {

            SectionComponent TempSubsectionsToDeleate = LocalSection.Subsections.SingleOrDefault(section => section.SectionIdDoc == sectionId);
            List<SectionComponent> TempSubsections = LocalSection.Subsections;
            if(TempSubsectionsToDeleate == null)
            {
                throw new SectionsCRUDUseCaseException("There is no section to remove");
            }
            else if (!Criteria.CanSectionBeRemoved(TempSubsectionsToDeleate)) 
            {
                throw new SectionsCRUDUseCaseException("Section couldn't be Removed");
            }
            else
            {
                TempSubsections.Remove(TempSubsectionsToDeleate);
                LocalSection.SetSubsections(TempSubsections);
            }
        }
    }
}
