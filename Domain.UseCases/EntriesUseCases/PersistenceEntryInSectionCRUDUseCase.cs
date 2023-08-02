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
         
        public PersistenceEntryInSectionCRUDUseCase(IObjectIdentifierService idcreator, ISectionEntryInSectionCRUDPersistenceService persistenceService)
        {
            IdentityCreator = idcreator;
            EntryPersistenceService = persistenceService;
        }
        //okay, I need to use the fucking CRUDObject, but, how? are going to inyect all the requirements for that objecto to, or are we hardcoding it? 
        public void CreateEmptyEntryInSection(int DocId, int sectionId)
        {

        }


    }
}
