using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.PersistenceServices.EntryPersistenceServices;
using System;

namespace Domain.UseCases.Tests.EntriesUseCasesTests.MockServices
{
    public class BasicSectionEntryInSectionCRUDPersistenceService : ISectionEntryInSectionCRUDPersistenceService
    {
        private Dictionary<int, Dictionary<int, SectionComposite>> documentSections = new Dictionary<int, Dictionary<int, SectionComposite>>();
        private Dictionary<int, Dictionary<int, Entry>> sectionEntries = new Dictionary<int, Dictionary<int, Entry>>();

        public SectionComposite GetSectionComposite(int documentId, int sectionId)
        {
            if (documentSections.ContainsKey(documentId) && documentSections[documentId].ContainsKey(sectionId))
            {
                return documentSections[documentId][sectionId];
            }
            return null;
        }

        public Entry ReadEntryinSection(int documentId, int entryId)
        {
            foreach (var sections in sectionEntries.Values)
            {
                if (sections.ContainsKey(entryId))
                {
                    return sections[entryId];
                }
            }
            return null;
        }

        public void CreateEntryinSection(int documentId, int sectionId, Entry newEntry)
        {
            if (!documentSections.ContainsKey(documentId))
            {
                documentSections[documentId] = new Dictionary<int, SectionComposite>();
            }

            if (!sectionEntries.ContainsKey(sectionId))
            {
                sectionEntries[sectionId] = new Dictionary<int, Entry>();
            }

            if (!documentSections[documentId].ContainsKey(sectionId))
            {
                documentSections[documentId][sectionId] = new SectionComposite("mock test Section", 12, new LanguagesComponent(3), 12);
            }

            documentSections[documentId][sectionId].Entries.Add(newEntry);
            sectionEntries[sectionId][newEntry.EntryId] = newEntry;
        }

        public void UpdateEntryinSection(int documentId, int sectionId, int oldEntryId, Entry newEntry)
        {
            if (documentSections.ContainsKey(documentId) && documentSections[documentId].ContainsKey(sectionId) &&
                sectionEntries.ContainsKey(sectionId) && sectionEntries[sectionId].ContainsKey(oldEntryId))
            {
                var section = documentSections[documentId][sectionId];
                var entry = sectionEntries[sectionId][oldEntryId];

                section.Entries.Remove(entry);
                section.Entries.Add(newEntry);

                sectionEntries[sectionId].Remove(oldEntryId);
                sectionEntries[sectionId][newEntry.EntryId] = newEntry;
            }
        }

        public void DeleteEntryinSection(int documentId, int sectionId, int entryId)
        {
            if (documentSections.ContainsKey(documentId) && documentSections[documentId].ContainsKey(sectionId) &&
                sectionEntries.ContainsKey(sectionId) && sectionEntries[sectionId].ContainsKey(entryId))
            {
                var section = documentSections[documentId][sectionId];
                var entry = sectionEntries[sectionId][entryId];

                section.Entries.Remove(entry);
                sectionEntries[sectionId].Remove(entryId);
            }
        }
    }

}
