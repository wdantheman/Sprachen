using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domain.Entities.DataObjects.EntryComposite;
using ApprovalUtilities.SimpleLogger.Writers;
using Domain.Entities.Exceptions;

namespace Domain.Entities.Tests.DataObjectsTest.EntryCompositeTests
{

    public class WordTranslationTests
    {
        [Fact]
        public void WordTranslation_ConstructedWithIdAndText_ReturnsCorrectText()
        {
            // Arrange
            int id = 1;
            string expectedText = "Test";

            // Act
            var wordTranslation = new WordTranslation(id, expectedText);

            // Assert
            Assert.Equal(expectedText, wordTranslation.getText());
        }

        [Fact]
        public void WordTranslation_AddExamples_ExamplesAreAdded()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1, "Test");
            var examples = new List<string> { "Example 1", "Example 2" };

            // Act
            wordTranslation.AddExamples(examples);

            // Assert
            Assert.Equal(examples, wordTranslation.getExamples());
        }

        [Fact]
        public void WordTranslation_AddTargetDefinitions_DefinitionsAreAdded()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1, "Test");
            var translationService = new MockTranslationService();

            // Act
            wordTranslation.AddtargetDefinitions(translationService);

            // Assert
            Assert.Equal(translationService.Definitions, wordTranslation.getDefinitions());
        }

        [Fact]
        public void WordTranslation_AddComponent_CannotAddTranslationComponent()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1, "Test");
            var translationComponent = new SentenceTranslation(2, "Test text");

            // Act // Assert
            Assert.Throws<WordTranslationException>(() => wordTranslation.AddComponent(translationComponent));
        }

        [Fact]
        public void WordTranslation_RemoveComponent_CannotRemoveTranslationComponent()
        {
            // Arrange
            var wordTranslation = new WordTranslation(1, "Test");
            var translationComponent = new SentenceTranslation(2, "Test text");

            // Act // Assert
            Assert.Throws<WordTranslationException>(() => wordTranslation.RemoveComponent(translationComponent));
        }
    }
}
