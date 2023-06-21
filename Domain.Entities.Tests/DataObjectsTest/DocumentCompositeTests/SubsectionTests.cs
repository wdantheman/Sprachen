using Domain.Entities.DataObjects;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Exceptions;


namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    public class SubsectionTests
    {
        [Fact]
        public void AddTargetLanguage_ShouldAddLanguageToLanguagesComponent()
        {
            // Arrange
            var subsection = new Subsection("Subsection Title", 1, new LanguagesComponent());
            var language = Language.English;

            // Act
            subsection.AddTargetLanguage(language);
            var targetLanguages = subsection.GetTargetLanguages();

            // Assert
            Assert.Contains(language, targetLanguages);
        }

        [Fact]
        public void RemoveTargetLanguage_ShouldRemoveLanguageFromLanguagesComponent()
        {
            // Arrange
            var languageToRemove = Language.English;
            var subsection = new Subsection("Subsection Title", 1, new LanguagesComponent());
            subsection.AddTargetLanguage(languageToRemove);

            // Act
            subsection.RemoveTargetLanguage(languageToRemove);
            var targetLanguages = subsection.GetTargetLanguages();

            // Assert
            Assert.DoesNotContain(languageToRemove, targetLanguages);
        }

        [Fact]
        public void SetSourceLanguage_ShouldSetSourceLanguageInLanguagesComponent()
        {
            // Arrange
            var subsection = new Subsection("Subsection Title", 1, new LanguagesComponent());
            var sourceLanguage = Language.English;

            // Act
            subsection.SetSourceLanguage(sourceLanguage);
            var actualSourceLanguage = subsection.GetSourceLanguage();

            // Assert
            Assert.Equal(sourceLanguage, actualSourceLanguage);
        }

        [Fact]
        public void SetTargetLanguages_ShouldSetTargetLanguagesInLanguagesComponent()
        {
            // Arrange
            var subsection = new Subsection("Subsection Title", 1, new LanguagesComponent());
            var targetLanguages = new List<Language>
        {
            Language.English,
            Language.Spanish,
            Language.French
        };

            // Act
            subsection.SetTargetLanguages(targetLanguages);
            var actualTargetLanguages = subsection.GetTargetLanguages();

            // Assert
            Assert.Equal(targetLanguages, actualTargetLanguages);
        }

        [Fact]
        public void UpdateEntries_ShouldUpdateTranslationComponents()
        {
            // Arrange
            LanguagesComponent languages= new LanguagesComponent();
            languages.AddTargetLanguage(Language.English);
            languages.AddTargetLanguage(Language.Spanish);
            var subsection = new Subsection("Subsection Title", 1, languages);
            var entries = new Dictionary<string, EntryTranslationBlock>
        {
            { "Entry1", new EntryTranslationBlock(languages)},
            { "Entry2", new EntryTranslationBlock(languages)}
        };

            // Act
            subsection.UpdateEntries(entries);
            var actualEntries = subsection.GetEntries();

            // Assert
            Assert.Equal(entries, actualEntries);
        }

        [Fact]
        public void AddSubsectionComponent_ShouldThrowSubsectionException()
        {
            // Arrange
            var subsection = new Subsection("Subsection Title", 1, new LanguagesComponent());
            var sectionComponent = new SectionComposite("Section Title", 2, new LanguagesComponent());

            // Act & Assert
            Assert.Throws<SubsectionException>(() => subsection.AddSubsectionComponent(sectionComponent));
        }

        [Fact]
        public void RemoveSubsectionComponent_ShouldThrowSubsectionException()
        {
            // Arrange
            var subsection = new Subsection("Subsection Title", 1, new LanguagesComponent());
            var sectionComponentId = 2;

            // Act & Assert
            Assert.Throws<SubsectionException>(() => subsection.RemoveSubsectionComponent(sectionComponentId));
        }
    }

}
