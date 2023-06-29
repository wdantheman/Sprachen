using Domain.Entities.DataObjects;
using Domain.Entities.PersistenceServices;
using Domain.Entities;
using Moq;

namespace Domain.UseCases.Tests
{
    public class LanguagesSettingUseCaseTests
    {
        [Fact]
        public void AddTargetLanguageToDocLanguagesComponent_Should_AddTargetLanguage()
        {
            // Arrange
            int documentId = 1;
            Language language = Language.English;
            var settingsServiceMock = new Mock<ILanguagesComponentSettingsService>();
            var useCase = new LanguagesSettingUseCase(settingsServiceMock.Object);
            var languagesComponent = new LanguagesComponent(3);
            settingsServiceMock.Setup(s => s.GetLanguagesComponentFromDocument(documentId))
                .Returns(languagesComponent);

            // Act
            useCase.AddTargetLanguageToDocLanguagesComponent(documentId, language);

            // Assert
            Assert.Contains(language, languagesComponent.GetTargetLanguages());
            settingsServiceMock.Verify(s => s.SetLanguagesComponentInDocument(languagesComponent, documentId), Times.Once);
        }

        [Fact]
        public void RemoveTargetLanguageToDocLanguagesComponent_Should_RemoveTargetLanguage()
        {
            // Arrange
            int documentId = 1;
            Language language = Language.English;
            var settingsServiceMock = new Mock<ILanguagesComponentSettingsService>();
            var useCase = new LanguagesSettingUseCase(settingsServiceMock.Object);
            var languagesComponent = new LanguagesComponent(3);
            languagesComponent.AddTargetLanguage(language);
            settingsServiceMock.Setup(s => s.GetLanguagesComponentFromDocument(documentId))
                .Returns(languagesComponent);

            // Act
            useCase.RemoveTargetLanguageToDocLanguagesComponent(documentId, language);

            // Assert
            Assert.DoesNotContain(language, languagesComponent.GetTargetLanguages());
            settingsServiceMock.Verify(s => s.SetLanguagesComponentInDocument(languagesComponent, documentId), Times.Once);
        }

        [Fact]
        public void SetSourceLanguageInDocumentLanguagesComponent_Should_SetSourceLanguage()
        {
            // Arrange
            int documentId = 1;
            Language language = Language.English;
            var settingsServiceMock = new Mock<ILanguagesComponentSettingsService>();
            var useCase = new LanguagesSettingUseCase(settingsServiceMock.Object);
            var languagesComponent = new LanguagesComponent(3);
            settingsServiceMock.Setup(s => s.GetLanguagesComponentFromDocument(documentId)).Returns(languagesComponent);

            // Act
            useCase.SetSourceLanguageInDocumentLanguagesComponent(documentId, language);

            // Assert
            Assert.Equal(language, languagesComponent.GetSourceLanguage());
            settingsServiceMock.Verify(s => s.SetLanguagesComponentInDocument(languagesComponent, documentId), Times.Once);
        }

        [Fact]
        public void AddTargetLanguageToDocSubsectionLanguagesComponent_Should_AddTargetLanguage()
        {
            // Arrange
            int documentId = 1;
            int subsectionId = 1;
            Language language = Language.English;
            var settingsServiceMock = new Mock<ILanguagesComponentSettingsService>();
            var useCase = new LanguagesSettingUseCase(settingsServiceMock.Object);
            var languagesComponent = new LanguagesComponent(3);
            settingsServiceMock.Setup(s => s.GetLanguagesComponentFromDocumentSubsection(documentId, subsectionId))
                .Returns(languagesComponent);

            // Act
            useCase.AddTargetLanguageToDocSubsectionLanguagesComponent(documentId, subsectionId, language);

            // Assert
            Assert.Contains(language, languagesComponent.GetTargetLanguages());
            settingsServiceMock.Verify(s => s.SetLanguagesComponentInDocumentSubsection(languagesComponent, documentId, subsectionId), Times.Once);
        }

        [Fact]
        public void RemoveTargetLanguageToDocSubsectionLanguagesComponent_Should_RemoveTargetLanguage()
        {
            // Arrange
            int documentId = 1;
            int subsectionId = 1;
            Language language = Language.English;
            var settingsServiceMock = new Mock<ILanguagesComponentSettingsService>();
            var useCase = new LanguagesSettingUseCase(settingsServiceMock.Object);
            var languagesComponent = new LanguagesComponent(3);
            languagesComponent.AddTargetLanguage(language);
            settingsServiceMock.Setup(s => s.GetLanguagesComponentFromDocumentSubsection(documentId, subsectionId))
                .Returns(languagesComponent);

            // Act
            useCase.RemoveTargetLanguageToDocSubsectionLanguagesComponent(documentId, subsectionId, language);

            // Assert
            Assert.DoesNotContain(language, languagesComponent.GetTargetLanguages());
            settingsServiceMock.Verify(s => s.SetLanguagesComponentInDocumentSubsection(languagesComponent, documentId, subsectionId), Times.Once);
        }

        [Fact]
        public void SetSourceLanguageInDocumentSubsectionLanguagesComponent_Should_SetSourceLanguage()
        {
            // Arrange
            int documentId = 1;
            int subsectionId = 1;
            Language language = Language.English;
            var settingsServiceMock = new Mock<ILanguagesComponentSettingsService>();
            var useCase = new LanguagesSettingUseCase(settingsServiceMock.Object);
            var languagesComponent = new LanguagesComponent(3);
            settingsServiceMock.Setup(s => s.GetLanguagesComponentFromDocumentSubsection(documentId, subsectionId))
                .Returns(languagesComponent);

            // Act
            useCase.SetSourceLanguageInDocumentSubsectionLanguagesComponent(documentId, subsectionId, language);

            // Assert
            Assert.Equal(language, languagesComponent.GetSourceLanguage());
            settingsServiceMock.Verify(s => s.SetLanguagesComponentInDocumentSubsection(languagesComponent, documentId, subsectionId), Times.Once);
        }
    }
}
