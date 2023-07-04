using Domain.Entities.PersistenceServices;
using Domain.Entities;
using Domain.Entities.PersistenceServices.SectionPersistenceServices;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.SectionUseCases
{
    public class SectionsInSectionCRUDUseCase
    {
        internal ISectionComponentCRUDPersistenceService SectionComponentPersistenceService;
        internal ILanguagesComponentSettingsService LanguagesComponentService;
        internal IObjectIdentifierService IdentityCreator;
        public SectionsInSectionCRUDUseCase(ISectionComponentCRUDPersistenceService sectionComponentPersistenceService, ILanguagesComponentSettingsService languagesComponentSettings, IObjectIdentifierService objectIdentifierService)
        {
            SectionComponentPersistenceService= sectionComponentPersistenceService;
            LanguagesComponentService= languagesComponentSettings;
            IdentityCreator= objectIdentifierService;
        }
        public void AddEmptySubsectionToSection(int docId, int sectionId)
        {
            LanguagesComponent defaultLanguagesCompenet = LanguagesComponentService.GetLanguagesComponentFromDocumentSubsection(docId, sectionId);
            SectionComposite newEmptySubscetion = new SectionComposite("Empty Subsection", IdentityCreator.CreateSubObjectId(docId), defaultLanguagesCompenet);
            SectionComponentPersistenceService.CreateSectionComponentInSection(docId, sectionId, newEmptySubscetion);
        }
        public void AddSubsectionToSection(int docId, int sectionId, SectionComponent section) 
        {
            if (section == null) 
            {
                throw new SectionsCRUDUseCaseException("Subsection to add is null");
            }
            SectionComponentPersistenceService.CreateSectionComponentInSection(docId, sectionId, section);
        }





    }
}
