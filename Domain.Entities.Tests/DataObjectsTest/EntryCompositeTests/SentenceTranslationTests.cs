using Domain.Entities.DataObjects.EntryComposite;

namespace Domain.Entities.Tests.DataObjectsTest.EntryCompositeTests
{
    public class SentenceTranslationTests
    {
        [Fact]
        public void AddComponent_ShouldAddTranslationComponent()
        {
            // Arrange
            var sentenceTranslation = new SentenceTranslation(1);
            var translationComponent = new WordTranslation(2);

            // Act
            sentenceTranslation.AddComponent(translationComponent);

            // Assert
            Assert.Contains(translationComponent, sentenceTranslation.GetTranslationComponents());
        }

        [Fact]
        public void RemoveComponent_ShouldRemoveTranslationComponent()
        {
            // Arrange
            var sentenceTranslation = new SentenceTranslation(1);
            var translationComponent = new WordTranslation(2);
            sentenceTranslation.AddComponent(translationComponent);

            // Act
            sentenceTranslation.RemoveComponent(translationComponent);

            // Assert
            Assert.DoesNotContain(translationComponent, sentenceTranslation.GetTranslationComponents());
        }

        [Fact]
        public void AddTranslations_ShouldSetTranslationText()
        {
            // Arrange
            var sentenceTranslation = new SentenceTranslation(1);
            var translations = new List<string> { "Translation 1", "Translation 2" };

            // Act
            sentenceTranslation.AddTranslations(translations);

            // Assert
            Assert.Equal(translations, sentenceTranslation.GetTranslationText());
        }

        // Additional tests can be written to cover other methods and scenarios as needed
    }
}
