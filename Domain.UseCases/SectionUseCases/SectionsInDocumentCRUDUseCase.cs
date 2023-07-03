using Domain.Entities;
using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices;
using Domain.Entities.PersistenceServices.SectionPersistenceServices;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.SectionUseCases
{
    public class SectionsInDocumentCRUDUseCase
    {
        internal ILanguagesComponentSettingsService LanguagesComponentService;
        internal IObjectIdentifierService IdentityCreator;
        internal ISectionInDocumentCRUDPersistenceService SectionPersistenceService;
        public SectionsInDocumentCRUDUseCase(ILanguagesComponentSettingsService languagesComponentService, IObjectIdentifierService identityCreator, ISectionInDocumentCRUDPersistenceService sectionPersistenceService)
        {
            LanguagesComponentService = languagesComponentService;
            IdentityCreator = identityCreator;
            SectionPersistenceService = sectionPersistenceService;
        }
        public void CreateEmptySectionInDocument(int DocId)
        {
            LanguagesComponent defaultLanguagesCompenet = LanguagesComponentService.GetLanguagesComponentFromDocument(DocId);
            SectionComposite newEmptySubscetion = new SectionComposite("Empty Subsection", IdentityCreator.CreateObjectId(), defaultLanguagesCompenet);
            SectionPersistenceService.CreateSectionInDocument(DocId, newEmptySubscetion);
        }
        public void CreateEmptySectionInDocumentWithLanguagesComponent(int DocId, string title, LanguagesComponent languagesComponent)
        {
            SectionComposite newSubscetion = new SectionComposite(title, IdentityCreator.CreateSubObjectId(DocId), languagesComponent);
            SectionPersistenceService.CreateSectionInDocument(DocId, newSubscetion);
        }
        public SectionComponent ReadSectionFromDocumentById(int documentId, int SectionId)
        {
            SectionComponent temp = SectionPersistenceService.ReadSectionInDocument(documentId, SectionId);
            if (temp == null)
            {
                throw new SectionsCRUDUseCaseException("the Section id doesn't exist");
            }
            return temp;
        }
        public void UpdateSectioninDocument(int documentId, int sectionId, SectionComponent newSection)
        {
            SectionPersistenceService.UpdateSectionInDocument(documentId, sectionId, newSection);
        }
        public void DelateSectionInDocument(int documentId, int sectionId)
        {
            SectionPersistenceService.DeleteSectionInDocument(documentId, sectionId);
        }
    }
}
