using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.PersistenceServices.EntryPersistenceServices;
using Domain.UseCases.EntriesUseCases;
using static System.Collections.Specialized.BitVector32;

namespace Domain.UseCases.Tests.EntriesUseCasesTests.MockServices
{
    public class BasicSectionEntryInSectionCRUDPersistenceService : ISectionEntryInSectionCRUDPersistenceService
    {
        public Dictionary<int, Document> DocumentSections = new Dictionary<int, Document>();
        public BasicSectionEntryInSectionCRUDPersistenceService(int docNumber, int SectionsPerDoc)
        {
            AddDocuments(docNumber);
            AddNSectionstoDocuments(SectionsPerDoc);
        }
        internal void AddDocuments(int docNumber) 
        {
            for (int i = 0; i < docNumber; i++)
            {
                Document temp = new Document(i, "testdoc " + i.ToString(), new List<SectionComponent>(), new LanguagesComponent(3));
                DocumentSections.Add(i, temp);
            }
        }
        internal void AddNSectionstoDocuments(int lenght) 
        {
            foreach (Document item in DocumentSections.Values)
            {
                for (int i = 0; i < lenght; i++)
                {
                    SectionComposite temp = new SectionComposite("section test" + i.ToString(), i+10 ,item.GetLanguageComponent(), item.SystemId);
                    AddEntriesToSection(12, temp);
                    item.AddSection(temp);
                }
            }
        }
        internal void AddEntriesToSection(int numberOfEntries, SectionComposite section)
        {
            EntryInSectionCRUDUseCase usecase = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), section,  new SimpleEntryCreatorCriteria(0, 100));
            for (int i = 0; i < numberOfEntries; i++)
            {
                usecase.AddNewEntryInSection("test Entry " + i.ToString());
            }
        }
        public SectionComposite GetSectionComposite(int documentId, int sectionId)
        {
            if (DocumentSections.ContainsKey(documentId))
            {
                return (SectionComposite)DocumentSections[documentId].GetSections().Where(item => item.SectionIdDoc == sectionId);
            }
            else
            {
                return null;
            }
        }

        public Entry ReadEntryinSection(int documentId, int entryId)
        {
            if (DocumentSections.ContainsKey(documentId))
            {
                EntryInSectionCRUDUseCase usecase = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), new SectionComposite("das", 12, new LanguagesComponent(23), 12), new SimpleEntryCreatorCriteria(0, 100));
                for (int i = 0; i < DocumentSections[documentId].GetSections().Count; i++)
                {
                    SectionComposite tempSection = (SectionComposite)DocumentSections[documentId].GetSections()[i];
                    usecase.ResetSection(tempSection);
                    if (usecase.GetEntrybyId(entryId) != null)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                return usecase.GetEntrybyId(entryId);
            }
            else 
            {
                return null;
            } 
        }
        /// I dont know if this will work
        public void CreateEntryinSection(int documentId, int sectionId, Entry newEntry)
        {


            List<SectionComponent> sections = DocumentSections[documentId].GetSections();
            EntryInSectionCRUDUseCase usecase = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), (SectionComposite)sections[sectionId], new SimpleEntryCreatorCriteria(0, 100));
            usecase.AddEntryInSection(newEntry);
            DocumentSections[documentId].SetSections(sections);


        }

        public void UpdateEntryinSection(int documentId, int sectionId, int oldEntryId, Entry newEntry)
        {
            List<SectionComponent> sections = DocumentSections[documentId].GetSections();
            EntryInSectionCRUDUseCase usecase = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), (SectionComposite)sections[sectionId], new SimpleEntryCreatorCriteria(0, 100));
            usecase.UpdateEntryContentById(oldEntryId, newEntry.Content);
            DocumentSections[documentId].SetSections(sections);
        }

        public void DeleteEntryinSection(int documentId, int sectionId, int entryId)
        {
            List<SectionComponent> sections = DocumentSections[documentId].GetSections();
            EntryInSectionCRUDUseCase usecase = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), (SectionComposite)sections[sectionId], new SimpleEntryCreatorCriteria(0, 100));
            usecase.DeleateEntryById(entryId);
            DocumentSections[documentId].SetSections(sections);
        }
    }

}
