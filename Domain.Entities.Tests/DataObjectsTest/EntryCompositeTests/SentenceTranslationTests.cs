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
                //var sentenceTranslation = new SentenceTranslation(1, "EntryText");
                //var translationServiceMock = new Mock<ITranslationService>();
                //var component1Mock = new Mock<TranslationComponent>();
                //var component2Mock = new Mock<TranslationComponent>();
                //sentenceTranslation.AddComponent(component1Mock.Object);
                //sentenceTranslation.AddComponent(component2Mock.Object);

                //// Act
                //sentenceTranslation.Translate(translationServiceMock.Object);

                //// Assert
                //component1Mock.Verify(c => c.Translate(translationServiceMock.Object), Times.Once);
                //component2Mock.Verify(c => c.Translate(translationServiceMock.Object), Times.Once);
            }
    }

}
