using Domain.Entities;
using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices;

namespace Domain.UseCases.SectionUseCases
{
    public class SectionsInDocumentCRUDUseCase
    {
        internal IObjectIdentifierService IdentityCreator;
        internal Document LocalDocument;
        public SectionsInDocumentCRUDUseCase(IObjectIdentifierService objectIdentifierService, Document doc)
        {
            IdentityCreator= objectIdentifierService;
            LocalDocument = doc;
        }
        public void SetDocument(Document newDoc)
        {
            LocalDocument = newDoc ?? throw new ArgumentNullException(nameof(newDoc));
        }
        public void CreateEmptySectionInDocument()
        {
            LanguagesComponent defaultLanguagesCompenet = LocalDocument.GetLanguageComponent();
            SectionComposite newEmptySubscetion = new SectionComposite("Empty Subsection", IdentityCreator.CreateSubObjectId(LocalDocument.SystemId), defaultLanguagesCompenet);
            List<SectionComponent> localSections = LocalDocument.GetSections();
            localSections.Add(newEmptySubscetion);
            LocalDocument.SetSections(localSections);
        }


    }
}
