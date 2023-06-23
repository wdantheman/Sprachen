using Domain.Entities;
using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices;
using Domain.UseCases.Exceptions;
using Document = Domain.Entities.DataObjects.DocumentComposite.Document;

namespace Domain.UseCases
{
    public class SectionsCRUDUseCase
    {
        internal IDocumentFinderService DocumentFinderService;
        internal IObjectIdentifierService IdentityCreator;
        internal ISectionCRUDPersistenceService SectionPersistenceService;
        public SectionsCRUDUseCase(IDocumentFinderService documentFinderService, IObjectIdentifierService identityCreator, ISectionCRUDPersistenceService sectionPersistenceService)
        {
            DocumentFinderService = documentFinderService;
            IdentityCreator = identityCreator;
            SectionPersistenceService = sectionPersistenceService;
        }
        public void CreateEmptySectionInDocument(int DocId)
        {
            string sectionTitle = "Empty Subsection";
            LanguagesComponent defaultLanguagesCompenet = DocumentFinderService.GetDefaultLanguageComponentForDocument(DocId);
            SectionComposite newEmptySubscetion = new SectionComposite(sectionTitle, IdentityCreator.CreateObjectId(), defaultLanguagesCompenet);
            newEmptySubscetion.SetSourceLanguage(defaultLanguagesCompenet.GetSourceLanguage());
            SectionPersistenceService.CreateSectionInDocument(DocId, newEmptySubscetion);
        }
        public void CreateEmptySectionInDocumentWithLanguagesComponent(int DocId, string title, LanguagesComponent languagesComponent)
        {
            Subsection newSubscetion = new Subsection(title, IdentityCreator.CreateSubObjectId(DocId), languagesComponent);
            newSubscetion.SetSourceLanguage(languagesComponent.GetSourceLanguage());
            SectionPersistenceService.CreateSectionInDocument(DocId, newSubscetion);
        }
        public SectionComponent ReadSectionFromDocumentById(int documentId, int SectionId) 
        {
            Document document = DocumentFinderService.GetDocumentById(documentId);
            SectionComponent sectionComponent = document.GetSections().Find(item => item.GetComponetId() == SectionId);
            if (sectionComponent == null) 
            {
                throw new SectionsCRUDUseCaseException("the Section id doesn't exist");
            }
            return sectionComponent;
        }
        public List<SectionComponent> ReadSectionsFromDocumentByTitle(int documentId, string sectionName) 
        {
            Document document = DocumentFinderService.GetDocumentById(documentId);
            List<SectionComponent> sectionComponents = document.GetSections().FindAll(item => item.title == sectionName);
            if (sectionComponents == null)
            {
                throw new SectionsCRUDUseCaseException("the Section with given title doesn't exist");
            }
            return sectionComponents;
        }
        public void UpdateSectioninDocument(int documentId, int sectionId, SectionComponent newSection)
        {
            Document document = DocumentFinderService.GetDocumentById(documentId);
            
        }

    }
}
