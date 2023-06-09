using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using System.Reflection;

namespace Domain.UseCases
{
    public class SectionsCRUDUseCase
    {
        internal IDocumentFinderService DocumentFinderService;
        internal IObjectIdentifierService IdentityCreator;
        public SectionsCRUDUseCase(IDocumentFinderService documentFinderService, IObjectIdentifierService identityCreator)
        {
            DocumentFinderService = documentFinderService;
            IdentityCreator = identityCreator;
        }
        public void CreateEmptySectionInDocument(int DocId)
        {
            Document document = DocumentFinderService.GetDocumentById(DocId);
            string sectionTitle = "Empty Subsection";
            Subsection newEmptySubscetion = new Subsection(sectionTitle, IdentityCreator.CreateId(), document.GetGeneralLanguages());
            newEmptySubscetion.SetSourceLanguage(document.GetDefaultLanguage());
            document.addSection(newEmptySubscetion);
        }
        public void CreateSectionInDocument (int DocId, string title, List<Language> targetLanguages)
        {
            Document document = DocumentFinderService.GetDocumentById (DocId);
            Subsection newSubscetion = new Subsection(title, IdentityCreator.CreateId(), targetLanguages);
            newSubscetion.SetSourceLanguage(document.GetDefaultLanguage());
            document.addSection(newSubscetion);
        }
        public SectionComponent ReadSectionFromDocumentById(int documentId, int SectionId) 
        {
            Document document = DocumentFinderService.GetDocumentById(documentId);
            SectionComponent sectionComponent = document.GetSections().Find(item => item.GetComponetId() == SectionId);
            return sectionComponent;
        }
    }
}
