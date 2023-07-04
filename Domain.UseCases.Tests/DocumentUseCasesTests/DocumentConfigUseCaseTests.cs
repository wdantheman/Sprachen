using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.DocumentPersistence;
using Domain.UseCases.DocumentUseCases;
using Moq;
namespace Domain.UseCases.Tests.DocumentUseCasesTests
{

    public class DocumentConfigUseCaseTests
    {
        private Mock<IDocumentConfigPersistenceService> mockPersistenceService;
        private Mock<IDocumentConfigCriteria> mockCriteriaService;
        private DocumentConfigUseCase useCase;

        public DocumentConfigUseCaseTests()
        {
            mockPersistenceService = new Mock<IDocumentConfigPersistenceService>();
            mockCriteriaService = new Mock<IDocumentConfigCriteria>();
            useCase = new DocumentConfigUseCase(mockPersistenceService.Object, mockCriteriaService.Object);
        }

        [Fact]
        public void UpdateDescriptionInDB_ValidDescription_UpdatesDescription()
        {
            // Arrange
            int docId = 1;
            string newDescription = "New description";
            mockCriteriaService.Setup(c => c.IsDescriptionValid(newDescription)).Returns(true);

            // Act
            useCase.UpdateDescriptionInDB(docId, newDescription);

            // Assert
            mockPersistenceService.Verify(p => p.UpdateDocumentDescrition(docId, newDescription), Times.Once);
        }

        [Fact]
        public void UpdateDescriptionInDB_InvalidDescription_DoesNotUpdateDescription()
        {
            // Arrange
            int docId = 1;
            string newDescription = "Invalid description";
            mockCriteriaService.Setup(c => c.IsDescriptionValid(newDescription)).Returns(false);

            // Act
            useCase.UpdateDescriptionInDB(docId, newDescription);

            // Assert
            mockPersistenceService.Verify(p => p.UpdateDocumentDescrition(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void UpdateDocumentLanguagesComponentInDB_UpdatesLanguagesComponent()
        {
            // Arrange
            int id = 1;
            LanguagesComponent languagesComponent = new LanguagesComponent(2);

            // Act
            useCase.UpdateDocumentLanguagesComponentInDB(id, languagesComponent);

            // Assert
            mockPersistenceService.Verify(p => p.UpdateDocumentLanguagesComponent(id, languagesComponent), Times.Once);
        }

        [Fact]
        public void UpdateDocumentNameInDb_ValidName_UpdatesName()
        {
            // Arrange
            int id = 1;
            string newName = "New name";
            mockCriteriaService.Setup(c => c.IsNameValid(newName)).Returns(true);

            // Act
            useCase.UpdateDocumentNameInDb(id, newName);

            // Assert
            mockPersistenceService.Verify(p => p.UpdateDocumentName(id, newName), Times.Once);
        }

        [Fact]
        public void UpdateDocumentNameInDb_InvalidName_DoesNotUpdateName()
        {
            // Arrange
            int id = 1;
            string newName = "Invalid name";
            mockCriteriaService.Setup(c => c.IsNameValid(newName)).Returns(false);

            // Act
            useCase.UpdateDocumentNameInDb(id, newName);

            // Assert
            mockPersistenceService.Verify(p => p.UpdateDocumentName(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void UpdateDescription_ValidDescription_UpdatesDescription()
        {
            // Arrange
            Document document = new Document(2, "sometitle", new List<SectionComponent>(), new LanguagesComponent(4));
            string newDescription = "New description";
            mockCriteriaService.Setup(c => c.IsDescriptionValid(newDescription)).Returns(true);

            // Act
            useCase.UpdateDescription(document, newDescription);

            // Assert
            // Add assertions for the expected behavior of the Document class (e.g., verifying that UpdateDescription was called)
        }

        [Fact]
        public void UpdateDocumentLanguagesComponent_UpdatesLanguagesComponent()
        {
            // Arrange
            Document document = new Document(2, "sometitle", new List<SectionComponent>(), new LanguagesComponent(4));
            LanguagesComponent newLanguagesComponent = new LanguagesComponent(6);

            // Act
            useCase.UpdateDocumentLanguagesComponent(document, newLanguagesComponent);

            // Assert
            // Add assertions for the expected behavior of the Document class (e.g., verifying that SetLanguageComponent was called)
        }

        [Fact]
        public void UpdateDocumentName_ValidName_UpdatesName()
        {
            // Arrange
            Document document = new Document(2, "sometitle", new List<SectionComponent>(), new LanguagesComponent(4));
            string newName = "New name";
            mockCriteriaService.Setup(c => c.IsNameValid(newName)).Returns(true);

            // Act
            useCase.UpdateDocumentName(document, newName);

            // Assert
            // Add assertions for the expected behavior of the Document class (e.g., verifying that SetName was called)
        }
    }
}
