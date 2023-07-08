using Domain.Entities;
using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices;
using Domain.UseCases.Exceptions;
using static System.Collections.Specialized.BitVector32;

namespace Domain.UseCases.SectionUseCases
{
    public class SectionsInDocumentCRUDUseCase
    {
        internal IObjectIdentifierService IdentityCreator;
        internal Document LocalDocument;
        internal ISectionConfigCriteria Criteria;
        public SectionsInDocumentCRUDUseCase(IObjectIdentifierService objectIdentifierService, Document doc, ISectionConfigCriteria criteria)
        {
            IdentityCreator = objectIdentifierService;
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
            SectionComposite newEmptySubscetion = new SectionComposite("Empty Subsection", IdentityCreator.CreateSubObjectId(LocalDocument.SystemId), defaultLanguagesCompenet);
            List<SectionComponent> localSections = LocalDocument.GetSections();
            localSections.Add(newEmptySubscetion);
            LocalDocument.SetSections(localSections);
        }
        public void CreateAddSectionToDocument(SectionComponent section) 
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
        public SectionComponent ReadSectionwithId(int sectionId) 
        {
            List<SectionComponent> localList = (List<SectionComponent>)LocalDocument.GetSections().Where(section => section.DocSectionId == sectionId);
            if (localList.Count == 0)
            {
                throw new SectionsInDocumentCRUDUseCaseException("the section Id didn't returned results");
            }
            else if (localList.Count > 1)
            {
                return localList[0];
                throw new SectionsInDocumentCRUDUseCaseException("the section Id had a replacted id, the first result was returned");
            }
            else 
            {
                return LocalDocument.GetSections().Where(section => section.DocSectionId == sectionId).First();
            }
        }
        public SectionComponent ReadSectionByTitle(string title)
        {
            List<SectionComponent> localList = (List<SectionComponent>)LocalDocument.GetSections().Where(section => section.Title == title);
            if (localList.Count == 0)
            {
                throw new SectionsInDocumentCRUDUseCaseException("the section Title didn't returned results");
            }
            else if (localList.Count > 1)
            {
                return localList[0];
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
            SectionComponent LocalComponent = LocalDocument.GetSections().Where(section => section.DocSectionId == sectionId).First();
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
