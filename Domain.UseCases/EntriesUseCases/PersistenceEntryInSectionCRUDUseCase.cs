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
        public void CreateEmptyEntryInSection(int DocId, int sectionId)
        {

        }


    }
}
