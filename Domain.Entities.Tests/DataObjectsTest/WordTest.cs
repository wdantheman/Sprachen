using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domain.Entities.DataObjects.EntryComposite;
using ApprovalUtilities.SimpleLogger.Writers;

namespace Domain.Entities.Tests.DataObjectsTest
{

    public class WordTests
    {
        [Fact]
        public void Word_ConstructedWithText_ReturnsCorrectText()
        {
            // Arrange
            string expectedText = "Test";

            // Act
            var word = new Word(expectedText);

            // Assert
            Assert.Equal(expectedText, word.getText());
        }

        [Fact]
        public void Word_AddExamples_ExamplesAreAdded()
        {
            // Arrange
            var word = new Word("Test");
            var examples = new List<string> { "Example 1", "Example 2" };

            // Act
            word.AddExamples(examples);

            // Assert
            Assert.Equal(examples, word.getExamples());
        }

        [Fact]
        public void Word_AddTranslations_TranslationsAreAdded()
        {
            // Arrange
            var word = new Word("Test");
            var translations = new List<string> { "Translation 1", "Translation 2" };

            // Act
            word.AddTranslations(translations);

            // Assert
            Assert.Equal(translations, word.getTranslations());
        }

        [Fact]
        public void Word_AddSourceDefinitions_DefinitionsAreAdded()
        {
            // Arrange
            var word = new Word("Test");
            var definitions = new List<string> { "Definition 1", "Definition 2" };

            // Act
            word.AddSourceDefinitions(definitions);

            // Assert
            Assert.Equal(definitions, word.getDefinitions());
        }

        //[Fact]
        //public void Word_AddComponent_CannotAddTranslationComponent()
        //{
        //    // Arrange
        //    var word = new Word("Test");
        //    var translationComponent = new Sentence("Component");
        //    var expectedOutput = "Cannot add TranslationComponent to a Word.";

        //    // Act
        //    var consoleWriter = new ConsoleWriter();
        //    Console.SetOut(consoleWriter);
        //    word.AddComponent(translationComponent);

        //    // Assert
        //    Assert.Equal(expectedOutput, consoleWriter.GetOutput());
        //}

        //[Fact]
        //public void Word_RemoveComponent_CannotRemoveTranslationComponent()
        //{
        //    // Arrange
        //    var word = new Word("Test");
        //    var translationComponent = new TranslationComponent("Component");
        //    var expectedOutput = "Cannot remove TranslationComponent from a Word.";

        //    // Act
        //    var consoleWriter = new ConsoleWriter();
        //    Console.SetOut(consoleWriter);
        //    word.RemoveComponent(translationComponent);

        //    // Assert
        //    Assert.Equal(expectedOutput, consoleWriter.GetOutput());
        //}
    }
}
