using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.Entities.PersistenceServices;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using Moq;
using Domain.Entities.PersistenceServices.SectionPersistenceServices;
using Domain.UseCases.SectionUseCases;

namespace Domain.UseCases.Tests
{
    public class SectionsInDocumentCRUDUseCaseTests
    {
        private readonly Mock<ILanguagesComponentSettingsService> mockLanguagesComponentService;
        private readonly Mock<IObjectIdentifierService> mockIdentityCreator;
        private readonly Mock<ISectionInDocumentCRUDPersistenceService> mockSectionPersistenceService;
        private readonly SectionsInDocumentCRUDUseCase sectionsInDocumentCRUDUseCase;

        public SectionsInDocumentCRUDUseCaseTests()
        {
            mockLanguagesComponentService = new Mock<ILanguagesComponentSettingsService>();
            mockIdentityCreator = new Mock<IObjectIdentifierService>();
            mockSectionPersistenceService = new Mock<ISectionInDocumentCRUDPersistenceService>();

            sectionsInDocumentCRUDUseCase = new SectionsInDocumentCRUDUseCase(
                mockLanguagesComponentService.Object,
                mockIdentityCreator.Object,
                mockSectionPersistenceService.Object
            );
        }

        [Fact]
        public void CreateEmptySectionInDocument_ShouldCallGetLanguagesComponentFromDocument()
        {
            // Arrange
            int docId = 1;
            LanguagesComponent defaultLanguagesComponent = new LanguagesComponent(2);
            mockLanguagesComponentService.Setup(x => x.GetLanguagesComponentFromDocument(docId)).Returns(defaultLanguagesComponent);

            // Act
            sectionsInDocumentCRUDUseCase.CreateEmptySectionInDocument(docId);

            // Assert
            mockLanguagesComponentService.Verify(x => x.GetLanguagesComponentFromDocument(docId), Times.Once);
        }

        [Fact]
        public void CreateEmptySectionInDocument_ShouldCallCreateSectionInDocument()
        {
            // Arrange
            int docId = 1;
            LanguagesComponent defaultLanguagesComponent = new LanguagesComponent(2);
            mockLanguagesComponentService.Setup(x => x.GetLanguagesComponentFromDocument(docId)).Returns(defaultLanguagesComponent);

            SectionComposite newEmptySubsection = new SectionComposite("Empty Subsection", 123, defaultLanguagesComponent);

            // Act
            sectionsInDocumentCRUDUseCase.CreateEmptySectionInDocument(docId);

            // Assert
            mockSectionPersistenceService.Verify(x => x.CreateSectionInDocument(docId, newEmptySubsection), Times.Once);
        }

        [Fact]
        public void CreateEmptySectionInDocumentWithLanguagesComponent_ShouldCallCreateSectionInDocument()
        {
            // Arrange
            int docId = 1;
            string title = "Section Title";
            LanguagesComponent languagesComponent = new LanguagesComponent(2);

            SectionComposite newSubsection = new SectionComposite(title, 456, languagesComponent);

            // Act
            sectionsInDocumentCRUDUseCase.CreateEmptySectionInDocumentWithLanguagesComponent(docId, title, languagesComponent);

            // Assert
            mockSectionPersistenceService.Verify(x => x.CreateSectionInDocument(docId, newSubsection), Times.Once);
        }

        [Fact]
        public void ReadSectionFromDocumentById_ShouldCallReadSectionInDocument()
        {
            // Arrange
            int documentId = 1;
            int sectionId = 2;
            LanguagesComponent languagesmock = new LanguagesComponent(3);
            SectionComponent sectionComponent = new SectionComposite("title", sectionId, languagesmock);
            mockSectionPersistenceService.Setup(x => x.ReadSectionInDocument(documentId, sectionId)).Returns(sectionComponent);

            // Act
            var result = sectionsInDocumentCRUDUseCase.ReadSectionFromDocumentById(documentId, sectionId);

            // Assert
            mockSectionPersistenceService.Verify(x => x.ReadSectionInDocument(documentId, sectionId), Times.Once);
            Assert.Equal(sectionComponent, result);
        }

        [Fact]
        public void ReadSectionFromDocumentById_ShouldThrowSectionsCRUDUseCaseException()
        {
            // Arrange
            int documentId = 1;
            int sectionId = 2;
            mockSectionPersistenceService.Setup(x => x.ReadSectionInDocument(documentId, sectionId)).Returns((SectionComponent)null);

            // Act & Assert
            Assert.Throws<SectionsCRUDUseCaseException>(() => sectionsInDocumentCRUDUseCase.ReadSectionFromDocumentById(documentId, sectionId));
        }

        [Fact]
        public void UpdateSectioninDocument_ShouldCallUpdateSectionInDocument()
        {
            // Arrange
            int documentId = 1;
            int sectionId = 2;
            LanguagesComponent languagesmock = new LanguagesComponent(2);
            SectionComponent newSection = new SectionComposite("title", sectionId, languagesmock);

            // Act
            sectionsInDocumentCRUDUseCase.UpdateSectioninDocument(documentId, sectionId, newSection);

            // Assert
            mockSectionPersistenceService.Verify(x => x.UpdateSectionInDocument(documentId, sectionId, newSection), Times.Once);
        }

        [Fact]
        public void DelateSectionInDocument_ShouldCallDeleteSectionInDocument()
        {
            // Arrange
            int documentId = 1;
            int sectionId = 2;

            // Act
            sectionsInDocumentCRUDUseCase.DelateSectionInDocument(documentId, sectionId);

            // Assert
            mockSectionPersistenceService.Verify(x => x.DeleteSectionInDocument(documentId, sectionId), Times.Once);
        }
    }
}
