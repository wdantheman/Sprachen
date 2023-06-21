using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Exceptions;

namespace Domain.Entities.Tests.DataObjectsTest.EntryCompositeTests
{
    public class WordTranslationTests
    {
        [Fact]
        public void AddExamples_ShouldSetTargetExamples()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1);
            var examples = new List<string> { "Example 1", "Example 2" };

            // Act
            wordTranslation.AddExamples(examples);

            // Assert
            Assert.Equal(examples, wordTranslation.getExamples());
        }

        [Fact]
        public void AddtargetDefinitions_ShouldSetTargetDefinitions()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1);
            var definitions = new List<string> { "Definition 1", "Definition 2" };

            // Act
            wordTranslation.AddtargetDefinitions(definitions);

            // Assert
            Assert.Equal(definitions, wordTranslation.getDefinitions());
        }

        [Fact]
        public void AddTranslations_ShouldSetTranslations()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1);
            var translations = new List<string> { "Translation 1", "Translation 2" };

            // Act
            wordTranslation.AddTranslations(translations);

            // Assert
            Assert.Equal(translations, wordTranslation.getTranslations());
        }

        [Fact]
        public void AddComponent_ShouldThrowWordTranslationException()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1);
            var translationComponent = new SentenceTranslation(2);

            // Act & Assert
            Assert.Throws<WordTranslationException>(() => wordTranslation.AddComponent(translationComponent));
        }

        [Fact]
        public void RemoveComponent_ShouldThrowWordTranslationException()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1);
            var translationComponent = new SentenceTranslation(2);

            // Act & Assert
            Assert.Throws<WordTranslationException>(() => wordTranslation.RemoveComponent(translationComponent));
        }
    }
}
