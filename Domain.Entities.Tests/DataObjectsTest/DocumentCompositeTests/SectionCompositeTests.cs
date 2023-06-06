using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;


namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    public class SectionCompositeTests
    {
        [Fact]
        public void AddSubsectionComponent_AddsComponentToList()
        {
            // Arrange
            var composite = new SectionComposite("Title", 1, new List<Language>());

            // Act
            var component = new Subsection("Subsection", 2, new List<Language>());
            composite.AddSubsectionComponent(component);

            // Assert
            Assert.Contains(component, composite.GetSubsections());
        }

        [Fact]
        public void AddTargetLanguage_AddsLanguageToList()
        {
            // Arrange
            var composite = new SectionComposite("Title", 1, new List<Language>());
            var language = Language.English;

            // Act
            composite.AddTargetLanguage(language);

            // Assert
            Assert.Contains(language, composite.GetTargetLanguages());
        }

        [Fact]
        public void GetEntries_ReturnsTranslationComponents()
        {
            // Arrange
            var composite = new SectionComposite("Title", 1, new List<Language>());
            var entries = new Dictionary<string, EntryTranslationBlock>();

            // Act
            var result = composite.GetEntries();

            // Assert
            Assert.Equal(entries, result);
        }

        [Fact]
        public void RemoveSubsectionComponent_RemovesComponentFromList()
        {
            // Arrange
            var composite = new SectionComposite("Title", 1, new List<Language>());
            var component = new Subsection("Subsection", 2, new List<Language>());
            composite.AddSubsectionComponent(component);

            // Act
            composite.RemoveSubsectionComponent(2);

            // Assert
            Assert.DoesNotContain(component, composite.GetSubsections());
        }

        [Fact]
        public void RemoveTargetLanguage_RemovesLanguageFromList()
        {
            // Arrange
            var composite = new SectionComposite("Title", 1, new List<Language>());
            var language = Language.English;
            composite.AddTargetLanguage(language);

            // Act
            composite.RemoveTargetLanguage(language);

            // Assert
            Assert.DoesNotContain(language, composite.GetTargetLanguages());
        }

        [Fact]
        public void SetSourceLanguage_SetsSourceLanguage()
        {
            // Arrange
            var composite = new SectionComposite("Title", 1, new List<Language>());
            var language = Language.English;

            // Act
            composite.SetSourceLanguage(language);

            // Assert
            Assert.Equal(language, composite.GetSourceLanguage());
        }

        [Fact]
        public void UpdateEntries_UpdatesTranslationComponents()
        {
            // Arrange
            var composite = new SectionComposite("Title", 1, new List<Language>());
            var entries = new Dictionary<string, EntryTranslationBlock>();

            // Act
            composite.UpdateEntries(entries);

            // Assert
            Assert.Same(entries, composite.GetEntries());
        }
    }
}
