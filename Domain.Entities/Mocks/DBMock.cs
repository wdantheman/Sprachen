using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.DataObjects;
using Domain.Entities.PersistenceServices.EntryPersistenceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Mocks
{
    public class DBMock : ISectionEntryInSectionCRUDPersistenceService
    {
        public Dictionary<int, Document> Documents = new Dictionary<int, Document>();
        public Dictionary<(int, int), SectionComposite> Sections = new Dictionary<(int, int), SectionComposite>();
        public Dictionary<(int, int), Entry> Entries = new Dictionary<(int, int), Entry>();



        public DBMock(int docNumber, int SectionsPerDoc, int entriesPerSection)
        {
            AddDocuments(docNumber);
            AddNSectionstoDocuments(SectionsPerDoc);
            AddNEntriesToAllSections(entriesPerSection);
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
                for (int i = 1; i < listLenght + 1; i++)
                {
                    SectionComposite tempSection = new SectionComposite("section test" + i.ToString(), i, tempDoc.GetLanguageComponent(), tempDoc.SystemId);
                    tempDoc.AddSection(tempSection);
                    Sections.Add((tempDoc.SystemId, tempSection.SectionIdDoc), tempSection);
                }
            }
        }
        internal void AddNEntriesToAllSections(int numberOfEntries)
        {
            foreach (SectionComposite tempSection in Sections.Values) 
            {
                for (int i = 0; i < numberOfEntries; i++)
                {
                    // Generate a unique key for the entry based on the section and entry index
                    var random = new Random();
                    int id = random.Next(1, int.MaxValue);
                    var entryKey = (tempSection.SourceDocument, id);

                    // Check if the entryKey already exists in the dictionary
                    while (Entries.ContainsKey(entryKey))
                    {
                        // Generate a new key if it already exists
                        int newId = random.Next(1, int.MaxValue);
                        entryKey = (tempSection.SourceDocument, newId); 
                    }
                    Entry tempEntry = new Entry(id, "some entry content " + i.ToString());

                    Entries.Add(entryKey, tempEntry);
                }

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
                //here we are not compeling with the Business logic for the use case as we are not ensuring that 
                //the section list object is properly updated to contain the new entry, although we are adding it to the entries list. I need to adress this later as it might cause discrepancies in the DB behaviour
                Entries.Add((documentId, newEntry.Id), newEntry);
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
                throw new Exception("no entry in section to Deleate");
            }
        }
    }

}

