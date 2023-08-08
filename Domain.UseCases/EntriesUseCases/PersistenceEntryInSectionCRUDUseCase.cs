using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.EntryPersistenceServices;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.EntriesUseCases
{
    public class PersistenceEntryInSectionCRUDUseCase
    {
        internal ISectionEntryInSectionCRUDPersistenceService EntryPersistenceService;
        internal IEntryInSectionCRUDUseCase EntryInSectionCRUDUseCase;

        public PersistenceEntryInSectionCRUDUseCase(ISectionEntryInSectionCRUDPersistenceService persistenceService, IEntryInSectionCRUDUseCase entryInSectionCRUDUseCase)
        {
            EntryPersistenceService = persistenceService;
            EntryInSectionCRUDUseCase = entryInSectionCRUDUseCase;
        }
        public void CreateEmptyEntryInSection(int docId, int sectionId)
        {
            SectionComposite section = EntryPersistenceService.GetSectionComposite(docId, sectionId);
            EntryInSectionCRUDUseCase.ResetSection(section);
            EntryInSectionCRUDUseCase.AddEmptyEntryInSection();
            Entry entry = EntryInSectionCRUDUseCase.GetEntryByContent(" ");
            EntryPersistenceService.CreateEntryinSection(docId, sectionId, entry);
        }
        public void CreateEntryInSectionByContent(int docId, int sectionId, string content) 
        {
            SectionComposite section = EntryPersistenceService.GetSectionComposite(docId, sectionId);
            EntryInSectionCRUDUseCase.ResetSection(section);
            EntryInSectionCRUDUseCase.AddNewEntryInSection(content);
            Entry entry = EntryInSectionCRUDUseCase.GetEntryByContent(content);
            EntryPersistenceService.CreateEntryinSection(docId, sectionId, entry);
        }
        public void AddEntryInSection(int docId, int sectionId, Entry entry) 
        {
            SectionComposite section = EntryPersistenceService.GetSectionComposite(docId, sectionId);
            EntryInSectionCRUDUseCase.ResetSection(section);
            try
            {
                EntryInSectionCRUDUseCase.AddEntryInSection(entry);
                Entry entryCheck = EntryInSectionCRUDUseCase.GetEntrybyId(entry.Id);
                EntryPersistenceService.CreateEntryinSection(docId, sectionId, entry);
            }
            catch (EntryInSectionCRUDUseCaseException)
            {
                throw new PersistenceEntryInSectionCRUDUseCaseException("Entry couldn't be saved in persistence");
            }
        }
        public Entry ReadEntryInSectionById(int docId, int sectionId, int entryId) 
        {
            try
            {
                return EntryPersistenceService.ReadEntryinSection(docId, entryId); 
            }
            catch (Exception)
            {
                throw new PersistenceEntryInSectionCRUDUseCaseException("Entry couldn't be find in persistence");
            }
        }
        public Entry ReadEntryInSectionByContent(int docId, int sectionId, string content)
        {
            SectionComposite section = EntryPersistenceService.GetSectionComposite(docId, sectionId);
            EntryInSectionCRUDUseCase.ResetSection(section);
            try
            {
                return EntryInSectionCRUDUseCase.GetEntryByContent(content);
            }
            catch (EntryInSectionCRUDUseCaseException)
            {
                throw new PersistenceEntryInSectionCRUDUseCaseException("Entry couldn't be saved in persistence");
            }
        }
        public void DeleateEntryByContent(int docId, int sectionId, string content) 
        {
            SectionComposite section = EntryPersistenceService.GetSectionComposite(docId, sectionId);
            EntryInSectionCRUDUseCase.ResetSection(section);
            try
            {
                Entry tempentry = EntryInSectionCRUDUseCase.GetEntryByContent(content);
                EntryInSectionCRUDUseCase.DeleateEntryByContent(content);
                EntryPersistenceService.DeleteEntryinSection(docId, sectionId, tempentry.Id);
            }
            catch (EntryInSectionCRUDUseCaseException)
            {
                throw new PersistenceEntryInSectionCRUDUseCaseException("Entry couldn't be saved in persistence");
            }
        }
        public void DeleateEntryById(int docId, int sectionId, int entryId) 
        {
            SectionComposite section = EntryPersistenceService.GetSectionComposite(docId, sectionId);
            EntryInSectionCRUDUseCase.ResetSection(section);
            try
            {
                Entry tempentry = EntryInSectionCRUDUseCase.GetEntrybyId(entryId);
                EntryInSectionCRUDUseCase.DeleateEntryById(entryId);
                EntryPersistenceService.DeleteEntryinSection(docId, sectionId, tempentry.Id);
            }
            catch (EntryInSectionCRUDUseCaseException)
            {
                throw new PersistenceEntryInSectionCRUDUseCaseException("Entry couldn't be saved in persistence");
            }
        }
        public void UpdateEntryContentById(int docId, int sectionId, int oldEntry, string newContent) 
        {
            SectionComposite section = EntryPersistenceService.GetSectionComposite(docId, sectionId);
            EntryInSectionCRUDUseCase.ResetSection(section);
            try
            {
                EntryInSectionCRUDUseCase.UpdateEntryContentById(oldEntry, newContent);
                Entry tempentry = EntryInSectionCRUDUseCase.GetEntryByContent(newContent);
                EntryPersistenceService.UpdateEntryinSection(docId, sectionId, oldEntry, tempentry);
            }
            catch (EntryInSectionCRUDUseCaseException)
            {
                throw new PersistenceEntryInSectionCRUDUseCaseException("Entry couldn't be saved in persistence");
            }
        }

    }
}
