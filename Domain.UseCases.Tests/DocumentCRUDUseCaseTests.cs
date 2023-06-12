using Moq;
using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices;

namespace Domain.UseCases.Tests
{
    public class DocumentCRUDUseCaseTests
    {
        private readonly DocumentCRUDUseCase _documentCRUD;
        private readonly Mock<IDocumentPersistenceService> _mockPersistenceService;
        private readonly Mock<IObjectIdentifierService> _mockIdentifierService;
        private readonly Mock<IDocumentFinderService> _mockDocumentFinderService;

        public DocumentCRUDUseCaseTests()
        {
            _mockPersistenceService = new Mock<IDocumentPersistenceService>();
            _mockIdentifierService = new Mock<IObjectIdentifierService>();
            _mockDocumentFinderService = new Mock<IDocumentFinderService>();

            _documentCRUD = new DocumentCRUDUseCase(
                _mockPersistenceService.Object,
                _mockIdentifierService.Object,
                _mockDocumentFinderService.Object
            );
        }

        [Fact]
        public void CreateEmptyDocument_Should_Return_New_Document_With_Default_Name()
        {
            // Arrange
            int expectedId = 1;
            string expectedName = " Empty Document";
            List<SectionComponent> expectedComponents = new List<SectionComponent>();

            _mockIdentifierService.Setup(service => service.CreateId()).Returns(expectedId);

            // Act
            Document result = _documentCRUD.CreateEmptyDocument();

            // Assert
            Assert.Equal(expectedId, result.Id);
            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedComponents, result.GetSections());
        }

        [Fact]
        public void CreateDocumentWithName_Should_Return_New_Document_With_Given_Name()
        {
            // Arrange
            int expectedId = 1;
            string expectedName = "Test Document";
            List<SectionComponent> expectedComponents = new List<SectionComponent>();

            _mockIdentifierService.Setup(service => service.CreateId()).Returns(expectedId);

            // Act
            Document result = _documentCRUD.CreateDocumentWithName(expectedName);

            // Assert
            Assert.Equal(expectedId, result.Id);
            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedComponents, result.GetSections());
        }

        [Fact]
        public void ReadDocumentById_Should_Return_Document_From_PersistenceService()
        {
            // Arrange
            int documentId = 1;
            Document expectedDocument = new Document(documentId, "Test Document", new List<SectionComponent>());

            _mockPersistenceService.Setup(service => service.ReadDocument(documentId)).Returns(expectedDocument);

            // Act
            Document result = _documentCRUD.ReadDocumentById(documentId);

            // Assert
            Assert.Equal(expectedDocument, result);
        }

        [Fact]
        public void ReadDocumentByName_Should_Return_Document_From_DocumentFinderService()
        {
            // Arrange
            string documentName = "Test Document";
            Document expectedDocument = new Document(1, documentName, new List<SectionComponent>());

            _mockDocumentFinderService.Setup(service => service.GetDocumentByName(documentName)).Returns(expectedDocument);

            // Act
            Document result = _documentCRUD.ReadDocumentByName(documentName);

            // Assert
            Assert.Equal(expectedDocument, result);
        }

        [Fact]
        public void DeleteDocument_Should_Call_PersistenceService_With_Correct_Id()
        {
            // Arrange
            int documentId = 1;

            // Act
            _documentCRUD.DeleteDocument(documentId);

            // Assert
            _mockPersistenceService.Verify(service => service.DeleteDocument(documentId), Times.Once);
        }

        [Fact]
        public void UpdateDocument_Should_Call_PersistenceService_With_Correct_Id_And_Document()
        {
            // Arrange
            int documentId = 1;
            Document updatedDocument = new Document(documentId, "Updated Document", new List<SectionComponent>());

            // Act
            _documentCRUD.UpdateDocument(documentId, updatedDocument);

            // Assert
            _mockPersistenceService.Verify(service => service.UpdateDocument(documentId, updatedDocument), Times.Once);
        }
    }
}