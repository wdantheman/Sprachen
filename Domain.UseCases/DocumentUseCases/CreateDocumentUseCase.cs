using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.DocumentUseCases
{
    public class CreateDocumentUseCase
    {
        internal IObjectIdentifierService IdentifierService;
        internal IDocumentCreatorCriteria CreatorCriteria;
        public CreateDocumentUseCase(IObjectIdentifierService identifierService, IDocumentCreatorCriteria creatorCriteria)
        {
            IdentifierService = identifierService;
            CreatorCriteria = creatorCriteria;
        }
        public Document CreateEmptyDocument()
        {
            int id = IdentifierService.CreateObjectId();
            string defaultName = "Empty Document";
            Document newDoc = new(id, defaultName, new List<SectionComponent>(), new LanguagesComponent(IdentifierService.CreateSubObjectId(id)));
            return newDoc;
        }
        public Document CreateDocumentWithName(string name)
        {
            if (!CreatorCriteria.IsDocumentNameValid(name))
            {
                throw new CreateDocumentUseCaseException("name wasn't valid");
            }
            else
            {
                int id = IdentifierService.CreateObjectId();
                return new Document(id, name, new List<SectionComponent>(), new LanguagesComponent(IdentifierService.CreateSubObjectId(id)));
            }
        }
        public Document CreateDocumentWithSectionsAndName(string name, List<SectionComponent> sections) 
        {

            if (!CreatorCriteria.IsDocumentNameValid(name))
            {
                throw new CreateDocumentUseCaseException("name wasn't valid");
            }
            else if (!CreatorCriteria.AreDocumentSectionsValid(sections))
            {
                throw new CreateDocumentUseCaseException("Sections weren't valid");
            }
            else
            {
                int id = IdentifierService.CreateObjectId();
                return new Document(id, name, sections, new LanguagesComponent(IdentifierService.CreateSubObjectId(id)));
            }
        }
    }
}
