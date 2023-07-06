

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public interface IDocumentCreatorCriteria
    {
        public bool IsDocumentValid(Document doc);
        public bool IsDocumentNameValid(string name);
        public bool AreDocumentSectionsValid(List<SectionComponent> sections);
    }
}
