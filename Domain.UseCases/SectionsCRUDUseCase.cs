using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.UseCases.Exceptions;
using Document = Domain.Entities.DataObjects.DocumentComposite.Document;

namespace Domain.UseCases
{
    public class SectionsCRUDUseCase
    {
        internal IDocumentPersistenceService DocumentPersistenceService;
        internal IObjectIdentifierService IdentityCreator;
        public SectionsCRUDUseCase(IDocumentPersistenceService documentPersistenceService, IObjectIdentifierService identityCreator)
        {
            DocumentPersistenceService = documentPersistenceService;
            IdentityCreator = identityCreator;
        }
        public void CreateEmptySectionInDocument(int DocId)
        {
            Document document = DocumentPersistenceService.ReadDocument(DocId);
            string sectionTitle = "Empty Subsection";
            Subsection newEmptySubscetion = new Subsection(sectionTitle, IdentityCreator.CreateId(), document.GetGeneralLanguages());
            newEmptySubscetion.SetSourceLanguage(document.GetDefaultLanguage());
            document.addSection(newEmptySubscetion);
        }
        public void CreateSectionInDocument (int DocId, string title, List<Language> targetLanguages)
        {
            Document document = DocumentPersistenceService.ReadDocument(DocId);
            Subsection newSubscetion = new Subsection(title, IdentityCreator.CreateId(), targetLanguages);
            newSubscetion.SetSourceLanguage(document.GetDefaultLanguage());
            document.addSection(newSubscetion);
        }
        public SectionComponent ReadSectionFromDocumentById(int documentId, int SectionId) 
        {
            Document document = DocumentPersistenceService.ReadDocument(documentId);
            SectionComponent sectionComponent = document.GetSections().Find(item => item.GetComponetId() == SectionId);
            if (sectionComponent == null) 
            {
                throw new SectionsCRUDUseCaseException("the Section id doesn't exist");
            }
            return sectionComponent;
        }
        public List<SectionComponent> ReadSectionsFromDocumentByTitle(int documentId, string sectionName) 
        {
            Document document = DocumentPersistenceService.ReadDocument(documentId);
            List<SectionComponent> sectionComponents = document.GetSections().FindAll(item => item.title == sectionName);
            if (sectionComponents == null)
            {
                throw new SectionsCRUDUseCaseException("the Section with given title doesn't exist");
            }
            return sectionComponents;
        }
        public void UpdateSectioninDocument(int documentId, int sectionId, SectionComponent newSection)
        {
            Document document = DocumentPersistenceService.ReadDocument(documentId);
            
        }

    }
}
