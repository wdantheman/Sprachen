using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;


namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    using Xunit;
    using Moq;

    public class SectionCompositeTests
    {
        [Fact]
        public void AddSubsectionComponent_AddsComponentToList()
        {
            // Arrange
            var component = new Mock<SectionComponent>().Object;
            var sectionComposite = new SectionComposite("Title", 1, new Mock<ILanguagesComponent>().Object);

            // Act
            sectionComposite.AddSubsectionComponent(component);

            // Assert
            Assert.Contains(component, sectionComposite.GetSubsections());
        }

        [Fact]
        public void RemoveSubsectionComponent_RemovesComponentFromList()
        {
            // Arrange
            var component1 = new Subsection("Component1", 1, new Mock<ILanguagesComponent>().Object);
            var component2 = new Subsection("Component2", 2, new Mock<ILanguagesComponent>().Object);
            var sectionComposite = new SectionComposite("Title", 1, new Mock<ILanguagesComponent>().Object);
            sectionComposite.AddSubsectionComponent(component1);
            sectionComposite.AddSubsectionComponent(component2);

            // Act
            sectionComposite.RemoveSubsectionComponent(1);

            // Assert
            Assert.DoesNotContain(component1, sectionComposite.GetSubsections());
            Assert.Contains(component2, sectionComposite.GetSubsections());
        }

        [Fact]
        public void GetEntries_ReturnsTranslationComponents()
        {
            // Arrange
            var translationComponents = new Dictionary<string, EntryTranslationBlock>();
            var sectionComposite = new SectionComposite("Title", 1, new Mock<ILanguagesComponent>().Object);
            sectionComposite.UpdateEntries(translationComponents);

            // Act
            var result = sectionComposite.GetEntries();

            // Assert
            Assert.Equal(translationComponents, result);
        }
        [Fact]
        public void SetSourceLanguage_SetsSourceLanguage()
        {
            // Arrange
            var sourceLanguage = Language.English;
            var languagesComponentMock = new Mock<ILanguagesComponent>();
            var sectionComposite = new SectionComposite("Title", 1, languagesComponentMock.Object);

            // Act
            sectionComposite.SetSourceLanguage(sourceLanguage);

            // Assert
            languagesComponentMock.Verify(lc => lc.SetSourceLanguage(sourceLanguage), Times.Once);
        }

        [Fact]
        public void AddTargetLanguage_AddsTargetLanguage()
        {
            // Arrange
            var targetLanguage = Language.French;
            var languagesComponentMock = new Mock<ILanguagesComponent>();
            var sectionComposite = new SectionComposite("Title", 1, languagesComponentMock.Object);

            // Act
            sectionComposite.AddTargetLanguage(targetLanguage);

            // Assert
            languagesComponentMock.Verify(lc => lc.AddTargetLanguage(targetLanguage), Times.Once);
        }

        [Fact]
        public void RemoveTargetLanguage_RemovesTargetLanguage()
        {
            // Arrange
            var targetLanguage = Language.Spanish;
            var languagesComponentMock = new Mock<ILanguagesComponent>();
            var sectionComposite = new SectionComposite("Title", 1, languagesComponentMock.Object);

            // Act
            sectionComposite.RemoveTargetLanguage(targetLanguage);

            // Assert
            languagesComponentMock.Verify(lc => lc.RemoveTargetLanguage(targetLanguage), Times.Once);
        }

        [Fact]
        public void UpdateEntries_UpdatesTranslationComponents()
        {
            // Arrange
            var translationComponents = new Dictionary<string, EntryTranslationBlock>();
            var sectionComposite = new SectionComposite("Title", 1, new Mock<ILanguagesComponent>().Object);

            // Act
            sectionComposite.UpdateEntries(translationComponents);

            // Assert
            Assert.Equal(translationComponents, sectionComposite.GetEntries());
        }

        [Fact]
        public void SetTargetLanguages_SetsTargetLanguages()
        {
            // Arrange
            var targetLanguages = new List<Language> { Language.German, Language.Italian };
            var languagesComponentMock = new Mock<ILanguagesComponent>();
            var sectionComposite = new SectionComposite("Title", 1, languagesComponentMock.Object);

            // Act
            sectionComposite.SetTargetLanguages(targetLanguages);

            // Assert
            languagesComponentMock.Verify(lc => lc.SetTargetLanguages(targetLanguages), Times.Once);
        }

        [Fact]
        public void GetSourceLanguage_ReturnsSourceLanguage()
        {
            // Arrange
            var sourceLanguage = Language.English;
            var languagesComponentMock = new Mock<ILanguagesComponent>();
            languagesComponentMock.Setup(lc => lc.GetSourceLanguage()).Returns(sourceLanguage);
            var sectionComposite = new SectionComposite("Title", 1, languagesComponentMock.Object);

            // Act
            var result = sectionComposite.GetSourceLanguage();

            // Assert
            Assert.Equal(sourceLanguage, result);
        }

        [Fact]
        public void GetTargetLanguages_ReturnsTargetLanguages()
        {
            // Arrange
            var targetLanguages = new List<Language> { Language.French, Language.Spanish };
            var languagesComponentMock = new Mock<ILanguagesComponent>();
            languagesComponentMock.Setup(lc => lc.GetTargetLanguages()).Returns(targetLanguages);
            var sectionComposite = new SectionComposite("Title", 1, languagesComponentMock.Object);

            // Act
            var result = sectionComposite.GetTargetLanguages();

            // Assert
            Assert.Equal(targetLanguages, result);
        }

        [Fact]
        public void GetComponetId_ReturnsComponentId()
        {
            // Arrange
            var sectionComposite = new SectionComposite("Title", 1, new Mock<ILanguagesComponent>().Object);

            // Act
            var result = sectionComposite.GetComponetId();

            // Assert
            Assert.Equal(1, result);
        }
    }

}
