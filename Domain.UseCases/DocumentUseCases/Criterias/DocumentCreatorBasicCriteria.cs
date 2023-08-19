using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.UseCases.DocumentUseCases.Criterias
{
    public class DocumentCreatorBasicCriteria : IDocumentCreatorCriteria
    {
        public bool IsDocumentValid(Document doc)
        {
            if (doc == null)
            {
                return false;
            }
            else if (doc.Name.Length > 10000)
            {
                return false;
            }
            return true;
        }

        public bool IsDocumentNameValid(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 10000)
            {
                return false;
            }
            return true;
        }

        public bool AreDocumentSectionsValid(List<SectionComponent> sections)
        {
            // Check if the sections list is not null
            if (sections == null)
            {
                return false;
            }

            // Implement your validation logic here
            // ...

            // Return true if the sections are valid, false otherwise
            return true;
        }
    }
}
