using Domain.Entities.DataObjects.EntryComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Tests.DataObjectsTest.EntryCompositeTests
{
    public class EntryTranslationBlockTests
    {
            [Fact]
            public void AddTargetLanguage_ShouldAddLanguageToList()
            {
                // Arrange
                var languages = new List<Language>();
                var block = new EntryTranslationBlock(languages);
                var language = Language.English; // Replace with appropriate Language instance

                // Act
                block.AddtargetLanguage(language);

                // Assert
                Assert.Contains(language, block.GetBlockLanguages());
            }

            [Fact]
            public void AddTargetLanguage_ShouldNotAddDuplicateLanguages()
            {
                // Arrange
                var languages = new List<Language> { Language.English }; // Replace with appropriate Language instances
                var block = new EntryTranslationBlock(languages);
                var language = Language.English; // Replace with appropriate Language instance

                // Act
                block.AddtargetLanguage(language);

                // Assert
                Assert.Single(block.GetBlockLanguages());
            }

            [Fact]
            public void RemoveTargetLanguage_ShouldRemoveLanguageFromList()
            {
                // Arrange
                var language = Language.English; // Replace with appropriate Language instance
                var languages = new List<Language> { language };
                languages.Add(Language.Danish);
                var block = new EntryTranslationBlock(languages);

                // Act
                block.RemovetargetLanguage(language);

                // Assert
                Assert.DoesNotContain(language, block.GetBlockLanguages());
            }

            [Fact]
            public void AddTranslationComponentToLanguage_ShouldAddTranslationToDictionary()
            {
                // Arrange
                var block = new EntryTranslationBlock(new List<Language>());
                var language = Language.Danish; // Replace with appropriate Language instance
                var translation = new WordTranslation(12, "words"); // Replace with appropriate TranslationComponent instance

                // Act
                block.AddTranslationComponentToLenguage(translation, language);

                // Assert
                Assert.Equal(translation, block.GetTranslationComponents()[language]);
            }

            [Fact]
            public void RemoveTranslationComponentFromLanguage_ShouldRemoveTranslationFromDictionary()
            {
                // Arrange
                var language = Language.Spanish; // Replace with appropriate Language instance
                var translation = new SentenceTranslation(19, "some text in here"); // Replace with appropriate TranslationComponent instance
                var block = new EntryTranslationBlock(new List<Language>());
                block.AddTranslationComponentToLenguage(translation, language);

                // Act
                block.RemoveTranslationComponentFromLenguage(language);

                // Assert
                Assert.DoesNotContain(language, block.GetTranslationComponents().Keys);
            }
        }

}
