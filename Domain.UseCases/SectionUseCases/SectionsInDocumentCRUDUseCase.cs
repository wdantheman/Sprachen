using Domain.Entities;
using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.SectionUseCases
{
    public class SectionsInDocumentCRUDUseCase
    {
        internal IObjectIdentifierService IdCreator;
        internal Document LocalDocument;
        internal ISectionConfigCriteria Criteria;
        public SectionsInDocumentCRUDUseCase(IObjectIdentifierService objectIdentifierService, Document doc, ISectionConfigCriteria criteria)
        {
            IdCreator = objectIdentifierService;
            LocalDocument = doc;
            Criteria = criteria;
        }
        public void SetDocument(Document newDoc)
        {
            LocalDocument = newDoc ?? throw new ArgumentNullException(nameof(newDoc));
        }
        public Document GetDocument() 
        {
            return LocalDocument;
        }
        public void CreateEmptySectionInDocument()
        {
            LanguagesComponent defaultLanguagesCompenet = LocalDocument.GetLanguageComponent();
            SectionComposite newEmptySubscetion = new SectionComposite("Empty Subsection", IdCreator.CreateSubObjectId(LocalDocument.SystemId), defaultLanguagesCompenet, LocalDocument.SystemId);
            List<SectionComponent> localSections = LocalDocument.GetSections();
            localSections.Add(newEmptySubscetion);
            LocalDocument.SetSections(localSections);
        }
        public void AddSectionToDocument(SectionComponent section) 
        {
            if (!Criteria.IsSectionValid(section))
            {
                throw new SectionsInDocumentCRUDUseCaseException("the section to add is not Valid");
            }
            else 
            {
                LocalDocument.AddSection(section);
            }
        }
        public List<SectionComponent> ReadSections()
        {
            return LocalDocument.GetSections();
        }
        public SectionComponent ReadSectionById(int sectionId) 
        {
            if (LocalDocument.GetSections().Where(section => section.SectionIdDoc == sectionId).Count() == 0)
            {
                throw new SectionsInDocumentCRUDUseCaseException("the section Id didn't returned results");
            }
            else if (LocalDocument.GetSections().Where(section => section.SectionIdDoc == sectionId).Count() > 1)
            {
                return LocalDocument.GetSections().Where(section => section.SectionIdDoc == sectionId).First();
                throw new SectionsInDocumentCRUDUseCaseException("the section Id had a duplicated id, the first result was returned");
            }
            else 
            {
                return LocalDocument.GetSections().Where(section => section.SectionIdDoc == sectionId).First();
            }
        }
        public SectionComponent ReadSectionByTitle(string title)
        {
            if (LocalDocument.GetSections().Where(section => section.Title == title).Count() == 0)
            {
                throw new SectionsInDocumentCRUDUseCaseException("the section Title didn't returned results");
            }
            else if (LocalDocument.GetSections().Where(section => section.Title == title).Count() > 1)
            {
                return LocalDocument.GetSections().Where(section => section.Title == title).First();
                throw new SectionsInDocumentCRUDUseCaseException("the section Id had a duplicated id, the first result was returned");
            }
            else
            {
                return LocalDocument.GetSections().Where(section => section.Title == title).First();
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
                LocalDocument.SetSections(newSections);
            }
        }        
        public void DeleteSectionFromDocument(int sectionId) 
        {
            List<SectionComponent> localList = LocalDocument.GetSections();
            SectionComponent LocalComponent = LocalDocument.GetSections().Where(section => section.SectionIdDoc == sectionId).First();
            if (!Criteria.CanSectionBeRemoved(LocalComponent))
            {
                throw new SectionsInDocumentCRUDUseCaseException("Section couldn't be Removed");
            }
            else 
            {
                localList.Remove(LocalComponent);
                LocalDocument.SetSections(localList);
            }
        }
    }
}
