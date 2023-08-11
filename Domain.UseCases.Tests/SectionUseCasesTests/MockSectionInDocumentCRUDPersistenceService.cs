using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.SectionPersistenceServices;


namespace Domain.UseCases.Tests.SectionUseCasesTests
{
    public class MockSectionInDocumentCRUDPersistenceService : ISectionInDocumentCRUDPersistenceService
    {
        private Dictionary<int, Dictionary<int, SectionComponent>> documentSections;

        public MockSectionInDocumentCRUDPersistenceService()
        {
            documentSections = new Dictionary<int, Dictionary<int, SectionComponent>>();
        }

        public void CreateSectionInDocument(int documentId, SectionComponent section)
        {
            if (!documentSections.ContainsKey(documentId))
                documentSections[documentId] = new Dictionary<int, SectionComponent>();
            int sectionId = section.SectionIdDoc;
            documentSections[documentId][sectionId] = section;
        }

        public void DeleteSectionInDocument(int documentId, int sectionId)
        {
            if (documentSections.ContainsKey(documentId))
            {
                if (documentSections[documentId].ContainsKey(sectionId))
                    documentSections[documentId].Remove(sectionId);
            }
        }

        public void UpdateSectionInDocument(int documentId, int sectionId, SectionComponent newSection)
        {
            if (documentSections.ContainsKey(documentId))
            {
                if (documentSections[documentId].ContainsKey(sectionId))
                {
                    documentSections[documentId][sectionId] = newSection;
                }
            }
        }

        public SectionComponent ReadSectionInDocument(int documentId, int sectionId)
        {
            if (documentSections.ContainsKey(documentId))
            {
                if (documentSections[documentId].ContainsKey(sectionId))
                    return documentSections[documentId][sectionId];
            }

            return null;
        }

        private int GenerateSectionId()
        {
            // Logic to generate a unique section id
            // You can replace this with your own implementation
            // This is just a simple example
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}
