using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.PersistenceServices.EntryPersistenceServices;
using Domain.UseCases.EntriesUseCases;
using Xunit.Sdk;
using static System.Collections.Specialized.BitVector32;

namespace Domain.UseCases.Tests.EntriesUseCasesTests.MockServices
{
    public class BasicSectionEntryInSectionCRUDPersistenceService : ISectionEntryInSectionCRUDPersistenceService
    {
        public Dictionary<int, Document> Documents = new Dictionary<int, Document>();
        public Dictionary<(int, int), SectionComposite> Sections = new Dictionary<(int, int), SectionComposite>();
        public Dictionary<(int, int), Entry> Entries = new Dictionary<(int, int), Entry>(); 

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
                Documents.Add(i, temp);
            }
        }
        internal void AddNSectionstoDocuments(int listLenght) 
        {
            foreach (Document tempDoc in Documents.Values)
            {
                for (int i = 0; i < listLenght; i++)
                {
                    SectionComposite tempSection = new SectionComposite("section test" + i.ToString(), i+10 ,tempDoc.GetLanguageComponent(), tempDoc.SystemId);
                    AddNEntriesToSection(10, tempSection);
                    tempDoc.AddSection(tempSection);
                    Sections.Add((tempDoc.SystemId, tempSection.SectionIdDoc), tempSection);
                }
            }
        }
        internal void AddNEntriesToSection(int numberOfEntries, SectionComposite section)
        {
            EntryInSectionCRUDUseCase usecase = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), section,  new SimpleEntryCreatorCriteria(0, 100));
            for (int i = 0; i < numberOfEntries; i++)
            {
                usecase.AddNewEntryInSection("test Entry " + i.ToString());
            }
        }
        public Dictionary<(int, int), SectionComposite> GetSections() 
        {
            return Sections;
        }
        public SectionComposite GetSectionComposite(int documentId, int sectionId)
        {
            if (Documents.ContainsKey(documentId) && Sections.ContainsKey((documentId, sectionId)))
            {
                return Sections[(documentId, sectionId)];
            }
            else
            {
                return null;
            }
        }

        public Entry ReadEntryinSection(int documentId, int entryId)
        {
            if (Documents.ContainsKey(documentId) && Entries.ContainsKey((documentId, entryId)))
            {
                return Entries[(documentId, entryId)];
            }
            else 
            {
                return null;
            } 
        }
        public void CreateEntryinSection(int documentId, int sectionId, Entry newEntry)
        {
            if (Sections[(documentId, sectionId)] != null)
            {
                EntryInSectionCRUDUseCase usecase = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), Sections[(documentId, sectionId)], new SimpleEntryCreatorCriteria(0, 100));
                usecase.AddEntryInSection(newEntry);
                Entries.Add((documentId, sectionId), newEntry);
            }
            else
            {
                throw new Exception("no section to add entry to");
            }
        }

        public void UpdateEntryinSection(int documentId, int sectionId, int oldEntryId, Entry newEntry)
        {
            if (Sections[(documentId, sectionId)] != null && Entries[(documentId, oldEntryId)] != null)
            {
                DeleteEntryinSection(documentId, sectionId, oldEntryId);
                Entries.Add((documentId, newEntry.Id), newEntry);
            }
            else
            {
                throw new Exception("no entry in section to update");
            }
        }

        public void DeleteEntryinSection(int documentId, int sectionId, int entryId)
        {
            if (Sections[(documentId, sectionId)] != null && Entries[(documentId, entryId)] != null)
            {
                Entries.Remove((documentId, entryId));
            }
            else
            {
                throw new Exception("no entry in section to update");
            }
        }
    }

}
