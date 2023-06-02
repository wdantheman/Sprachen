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

    public class WordTranslationTests
    {
        [Fact]
        public void Word_ConstructedWithText_ReturnsCorrectText()
        {
            // Arrange
            string expectedText = "Test";

            // Act
            var word = new WordTranslation(12, expectedText);

            // Assert
            Assert.Equal(expectedText, word.getText());
        }

        [Fact]
        public void Word_AddExamples_ExamplesAreAdded()
        {
            // Arrange
            var word = new WordTranslation(2, "Test");
            var examples = new List<string> { "Example 1", "Example 2" };

            // Act
            word.AddExamples(examples);

            // Assert
            Assert.Equal(examples, word.getExamples());
        }

    }
}
