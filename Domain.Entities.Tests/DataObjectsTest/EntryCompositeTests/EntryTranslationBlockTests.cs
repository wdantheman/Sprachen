using Domain.Entities.DataObjects.EntryComposite;
using Moq;

namespace Domain.Entities.Tests.DataObjectsTest.EntryCompositeTests
{
    public class EntryTranslationBlockTests
    {
        [Fact]
            public void AddTranslationComponentToLenguage_ShouldAddTranslationComponent()
            {
                // Arrange
                var targetLanguagesMock = new Mock<ILanguagesComponent>();
                var entryTranslationBlock = new EntryTranslationBlock(targetLanguagesMock.Object);
                var translationComponent = new WordTranslation(1);
                var language = new Language();

                // Act
                entryTranslationBlock.AddTranslationComponentToLenguage(translationComponent, language);

                // Assert
                Assert.Contains(language, entryTranslationBlock.GetTranslationComponents().Keys);
                Assert.Equal(translationComponent, entryTranslationBlock.GetTranslationComponents()[language]);
            }

        [Fact]
            public void RemoveTranslationComponentFromLenguage_ShouldRemoveTranslationComponent()
            {
                // Arrange
                var targetLanguagesMock = new Mock<ILanguagesComponent>();
                var entryTranslationBlock = new EntryTranslationBlock(targetLanguagesMock.Object);
                var translationComponent = new WordTranslation(1);
                var language = new Language();
                entryTranslationBlock.AddTranslationComponentToLenguage(translationComponent, language);

                // Act
                entryTranslationBlock.RemoveTranslationComponentFromLenguage(language);

                // Assert
                Assert.DoesNotContain(language, entryTranslationBlock.GetTranslationComponents().Keys);
            }

        [Fact]
        public void GetBlockLanguages_ShouldReturnListOfLanguages()
        {
            // Arrange
            var targetLanguagesMock = new Mock<ILanguagesComponent>();
            var entryTranslationBlock = new EntryTranslationBlock(targetLanguagesMock.Object);
            var languages = new List<Language> { new Language(), new Language(), new Language() };
            targetLanguagesMock.Setup(tl => tl.GetTargetLanguages()).Returns(languages);

            // Act
            var result = entryTranslationBlock.GetBlockLanguages();

            // Assert
            Assert.Equal(languages, result);
        }

        [Fact]
        public void GetTranslationComponents_ShouldReturnDictionaryOfTranslationComponents()
        {
            // Arrange
            var targetLanguagesMock = new Mock<ILanguagesComponent>();
            var entryTranslationBlock = new EntryTranslationBlock(targetLanguagesMock.Object);
            var translationComponents = new Dictionary<Language, TranslationComponent>
        {
            { new Language(), new WordTranslation (1) },
            { new Language(), new WordTranslation (2) },
            { new Language(), new WordTranslation (3) }
        };
            foreach (var kvp in translationComponents)
            {
                entryTranslationBlock.AddTranslationComponentToLenguage(kvp.Value, kvp.Key);
            }

            // Act
            var result = entryTranslationBlock.GetTranslationComponents();

            // Assert
            Assert.Equal(translationComponents, result);
        }
    }

}
