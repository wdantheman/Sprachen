using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.DocumentPersistence;
using Domain.UseCases.DocumentUseCases;
using Moq;
namespace Domain.UseCases.Tests.DocumentUseCasesTests
{
    public class DocumentConfigUseCaseTests
    {
        private readonly Mock<IDocumentConfigPersistenceService> mockConfigService;
        private readonly DocumentConfigUseCase useCase;

        public DocumentConfigUseCaseTests()
        {
            mockConfigService = new Mock<IDocumentConfigPersistenceService>();
            useCase = new DocumentConfigUseCase(mockConfigService.Object);
        }

        [Fact]
        public void UpdateDescriptionInDB_ShouldCallConfigurationService_WithCorrectArguments()
        {
            // Arrange
            int docId = 1;
            string newDescription = "New Description";

            // Act
            useCase.UpdateDescriptionInDB(docId, newDescription);

            // Assert
            mockConfigService.Verify(x => x.UpdateDocumentDescrition(docId, newDescription), Times.Once);
        }

        [Fact]
        public void UpdateDescription_ShouldCallUpdateDescription_OnDocument()
        {
            // Arrange
            var document = new Document(12, "default", new List<SectionComponent>());
            string newDescription = "New Description";

            // Act
            useCase.UpdateDescription(document, newDescription);

            // Assert
            Assert.Equal(newDescription, document.Description);
        }

        [Fact]
        public void UpdateDocumentLanguagesComponentInDB_ShouldCallConfigurationService_WithCorrectArguments()
        {
            // Arrange
            int id = 1;
            var languagesComponent = new LanguagesComponent(id);

            // Act
            useCase.UpdateDocumentLanguagesComponentInDB(id, languagesComponent);

            // Assert
            mockConfigService.Verify(x => x.UpdateDocumentLanguagesComponent(id, languagesComponent), Times.Once);
        }
    }
}
