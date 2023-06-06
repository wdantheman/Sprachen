using Domain.Entities.DataObjects.EntryComposite;


namespace Domain.Entities.Tests.DataObjectsTest.EntryCompositeTests
{
    public class SentenceTranslationTests
        {
            [Fact]
            public void AddComponent_AddsComponentToList()
            {
                // Arrange
                var sentenceTranslation = new SentenceTranslation(1, "EntryText");
                var component = new WordTranslation(12, "test word");

                // Act
                sentenceTranslation.AddComponent(component);

                // Assert
                Assert.Contains(component, sentenceTranslation.GetTranslationComponents());
            }

            [Fact]
            public void RemoveComponent_RemovesComponentFromList()
            {
                // Arrange
                var sentenceTranslation = new SentenceTranslation(1, "EntryText");
                var component = new WordTranslation(11, "some");
                sentenceTranslation.AddComponent(component);

                // Act
                sentenceTranslation.RemoveComponent(component);

                // Assert
                Assert.DoesNotContain(component, sentenceTranslation.GetTranslationComponents());
            }

            [Fact]
            public void Translate_CallsTranslateMethodOnComponents()
            {
            //// Arrange
            var sentenceTranslation = new SentenceTranslation(1, "EntryText");
            var translationServiceMock = new MockTranslationService();
            var component1Mock = new WordTranslation(3, "some");
            var component2Mock = new WordTranslation(4, "words");
            sentenceTranslation.AddComponent(component1Mock);
            sentenceTranslation.AddComponent(component2Mock);

            // Act
            sentenceTranslation.Translate(translationServiceMock);

            // Assert
            Assert.Equal(translationServiceMock.GetTranslations("whatever")[0], sentenceTranslation.GetTranslationText());
        }
    }

}
