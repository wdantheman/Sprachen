using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.Entities.PersistenceServices.EntryPersistenceServices;
using Domain.Entities.PersistenceServices.SectionPersistenceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.DataObjects.EntryComposite;
using System.Reflection.Metadata;
using Domain.UseCases.Exceptions;
using static System.Collections.Specialized.BitVector32;
using System.Security.Cryptography;

namespace Domain.UseCases.EntriesUseCases
{
    public class PersistenceEntryInSectionCRUDUseCase
    {
        internal IObjectIdentifierService IdentityCreator;
        internal ISectionEntryInSectionCRUDPersistenceService EntryPersistenceService;
        internal IEntryInSectionCRUDUseCase EntryInSectionCRUDUseCase;

        public PersistenceEntryInSectionCRUDUseCase(IObjectIdentifierService idcreator, ISectionEntryInSectionCRUDPersistenceService persistenceService, IEntryInSectionCRUDUseCase entryInSectionCRUDUseCase)
        {
            IdentityCreator = idcreator;
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


    }
}
