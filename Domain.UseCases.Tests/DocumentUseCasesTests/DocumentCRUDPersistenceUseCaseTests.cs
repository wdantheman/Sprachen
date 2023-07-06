using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.UseCases.DocumentUseCases;
using Domain.Entities.PersistenceServices.DocumentPersistence;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using Moq;

namespace Domain.UseCases.Tests.DocumentUseCasesTests
{
    public class DocumentCRUDPersistenceUseCaseTests
    {
        private readonly Mock<IDocumentCRUDPersistenceService> mockPersistenceService;
        private readonly Mock<IObjectIdentifierService> mockIdentifierService;
        private readonly Mock<IDocumentCreatorCriteria> mockDocumentValidator;

        private readonly DocumentCRUDPersistenceUseCase useCase;

        public DocumentCRUDPersistenceUseCaseTests()
        {
            mockPersistenceService = new Mock<IDocumentCRUDPersistenceService>();
            mockIdentifierService = new Mock<IObjectIdentifierService>();
            mockDocumentValidator = new Mock<IDocumentCreatorCriteria>();

            useCase = new DocumentCRUDPersistenceUseCase(
                mockPersistenceService.Object,
                mockIdentifierService.Object,
                mockDocumentValidator.Object
            );
        }

        [Fact]
        public void CreateDocumentInDB_ValidDocument_CallsPersistenceServiceCreateDocument()
        {
            // Arrange
            var doc = new Document(1, "basic test", new List<SectionComponent>(), new LanguagesComponent(3));
            mockDocumentValidator.Setup(v => v.IsDocumentValid(doc)).Returns(true);

            // Act
            useCase.CreateDocumentInDB(doc);

            // Assert
            mockPersistenceService.Verify(p => p.CreateDocument(doc), Times.Once);
        }

        [Fact]
        public void CreateDocumentInDB_InvalidDocument_ThrowsException()
        {
            // Arrange
            var doc = new Document(1, "basic test", new List<SectionComponent>(), new LanguagesComponent(3));
            mockDocumentValidator.Setup(v => v.IsDocumentValid(doc)).Returns(false);

            // Act & Assert
            Assert.Throws<CreateDocumentUseCaseException>(() => useCase.CreateDocumentInDB(doc));
        }

        [Fact]
        public void ReadDocumentById_CallsPersistenceServiceReadDocument()
        {
            // Arrange
            var id = 1;

            // Act
            useCase.ReadDocumentById(id);

            // Assert
            mockPersistenceService.Verify(p => p.ReadDocument(id), Times.Once);
        }

        [Fact]
        public void ReadDocumentByName_CallsDocumentFinderServiceGetDocumentByName()
        {
            // Arrange
            var documentFinderServiceMock = new Mock<IDocumentFinderService>();
            var name = "TestDocument";

            // Act
            useCase.ReadDocumentByName(documentFinderServiceMock.Object, name);

            // Assert
            documentFinderServiceMock.Verify(d => d.GetDocumentByName(name), Times.Once);
        }

        [Fact]
        public void DeleteDocumentInDB_DocumentDeleatable_CallsPersistenceServiceDeleteDocument()
        {
            // Arrange
            var id = 1;
            var criteriaMock = new Mock<IDocumentConfigCriteria>();
            criteriaMock.Setup(c => c.IsDocumentDeleatable(id)).Returns(true);

            // Act
            useCase.DeleteDocumentInDB(id, criteriaMock.Object);

            // Assert
            mockPersistenceService.Verify(p => p.DeleteDocument(id), Times.Once);
        }

        [Fact]
        public void DeleteDocumentInDB_DocumentNotDeleatable_DoesNotCallPersistenceServiceDeleteDocument()
        {
            // Arrange
            var id = 1;
            var criteriaMock = new Mock<IDocumentConfigCriteria>();
            criteriaMock.Setup(c => c.IsDocumentDeleatable(id)).Returns(false);

            // Act
            useCase.DeleteDocumentInDB(id, criteriaMock.Object);

            // Assert
            mockPersistenceService.Verify(p => p.DeleteDocument(id), Times.Never);
        }

        [Fact]
        public void UpdateDocumentInDB_ValidDocument_CallsPersistenceServiceUpdateDocument()
        {
            // Arrange
            var id = 1;
            var documentUpdate = new Document(1, "basic test", new List<SectionComponent>(), new LanguagesComponent(3));
            mockDocumentValidator.Setup(v => v.IsDocumentValid(documentUpdate)).Returns(true);

            // Act
            useCase.UpdateDocumentInDB(id, documentUpdate);

            // Assert
            mockPersistenceService.Verify(p => p.UpdateDocument(id, documentUpdate), Times.Once);
        }

        [Fact]
        public void UpdateDocumentInDB_InvalidDocument_ThrowsException()
        {
            // Arrange
            var id = 1;
            var documentUpdate = new Document(1, "basic test", new List<SectionComponent>(), new LanguagesComponent(3));
            mockDocumentValidator.Setup(v => v.IsDocumentValid(documentUpdate)).Returns(false);

            // Act & Assert
            Assert.Throws<CreateDocumentUseCaseException>(() => useCase.UpdateDocumentInDB(id, documentUpdate));
        }
    }
}
