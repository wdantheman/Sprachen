using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    public class DocumentTests
    {
        [Fact]
        public void AddDescription_ShouldSetDescription()
        {
            // Arrange
            var document = new Document(1, "Test Document", new List<SectionComponent>());

            // Act
            document.AddDescription("Sample description");

            // Assert
            Assert.Equal("Sample description", document.Description);
        }

        [Fact]
        public void AddSection_ShouldAddSectionToSections()
        {
            // Arrange
            var document = new Document(1, "Test Document", new List<SectionComponent>());
            var section = new Subsection("some title", 2, new LanguagesComponent());

            // Act
            document.AddSection(section);

            // Assert
            Assert.Contains(section, document.GetSections());
        }

        [Fact]
        public void RemoveSection_ShouldRemoveSectionFromSections()
        {
            // Arrange
            var sectionToRemove = new Subsection("some title", 1, new LanguagesComponent());
            var sections = new List<SectionComponent> { sectionToRemove };
            var document = new Document(1, "Test Document", sections);

            // Act
            document.RemoveSection(1);

            // Assert
            Assert.DoesNotContain(sectionToRemove, document.GetSections());
        }

        [Fact]
        public void GetGeneralLanguages_ShouldReturnLanguages()
        {
            // Arrange
            var document = new Document(1, "Test Document", new List<SectionComponent>());
            var expectedLanguages = new List<Language> { Language.English, Language.Spanish};
            document.SetGeneralLanguages(expectedLanguages);

            // Act
            var result = document.GetGeneralLanguages();

            // Assert
            Assert.Equal(expectedLanguages, result);
        }

        [Fact]
        public void SetGeneralLanguages_ShouldAddLanguagesToLanguagesComponent()
        {
            // Arrange
            var document = new Document(1, "Test Document", new List<SectionComponent>());
            var languages = new List<Language> { Language.English, Language.Spanish };

            // Act
            document.SetGeneralLanguages(languages);

            // Assert
            Assert.Equal(languages, document.GetGeneralLanguages());
        }

        [Fact]
        public void SetMainLanguage_ShouldSetSourceLanguageInLanguagesComponent()
        {
            // Arrange
            var document = new Document(1, "Test Document", new List<SectionComponent>());
            var language = Language.English;

            // Act
            document.SetMainLanguage(language);

            // Assert
            Assert.Equal(language, document.GetDefaultLanguage());
        }

        [Fact]
        public void GetDefaultLanguage_ShouldReturnSourceLanguageFromLanguagesComponent()
        {
            // Arrange
            var document = new Document(1, "Test Document", new List<SectionComponent>());
            var expectedLanguage = Language.English;
            document.SetMainLanguage(expectedLanguage);

            // Act
            var result = document.GetDefaultLanguage();

            // Assert
            Assert.Equal(expectedLanguage, result);
        }
    }


}
