using Domain.Entities.DataObjects;
using Domain.Entities.Exceptions;

namespace Domain.Entities.Tests
{
    public class LanguagesComponentTests
    {
        [Fact]
        public void AddTargetLanguage_Adds_Language_To_TargetLanguages()
        {
            // Arrange
            var id = 1;
            var component = new LanguagesComponent(id);
            var language = Language.Spanish;

            // Act
            component.AddTargetLanguage(language);

            // Assert
            Assert.Contains(language, component.GetTargetLanguages());
        }

        [Fact]
        public void AddTargetLanguage_Throws_LanguagesComponentException_If_Language_Already_Exists()
        {
            // Arrange
            var id = 1;
            var component = new LanguagesComponent(id);
            var language = Language.Spanish;
            component.AddTargetLanguage(language);

            // Act & Assert
            var exception = Assert.Throws<LanguagesComponentException>(() => component.AddTargetLanguage(language));
            Assert.Equal("Language already exist in list", exception.Message);
        }

        [Fact]
        public void RemoveTargetLanguage_Removes_Language_From_TargetLanguages()
        {
            // Arrange
            var id = 1;
            var component = new LanguagesComponent(id);
            var language = Language.Spanish;
            component.AddTargetLanguage(language);

            // Act
            component.RemoveTargetLanguage(language);

            // Assert
            Assert.DoesNotContain(language, component.GetTargetLanguages());
        }

        [Fact]
        public void GetSourceLanguage_Returns_SourceLanguage()
        {
            // Arrange
            var id = 1;
            var sourceLanguage = Language.English;
            var component = new LanguagesComponent(sourceLanguage, new List<Language>(), id);

            // Act
            var result = component.GetSourceLanguage();

            // Assert
            Assert.Equal(sourceLanguage, result);
        }

        [Fact]
        public void SetSourceLanguage_Sets_SourceLanguage()
        {
            // Arrange
            var id = 1;
            var component = new LanguagesComponent(id);
            var sourceLanguage = Language.French;

            // Act
            component.SetSourceLanguage(sourceLanguage);

            // Assert
            Assert.Equal(sourceLanguage, component.GetSourceLanguage());
        }

        [Fact]
        public void SetTargetLanguages_Sets_TargetLanguages()
        {
            // Arrange
            var id = 1;
            var component = new LanguagesComponent(id);
            var targetLanguages = new List<Language> { Language.German, Language.Italian };

            // Act
            component.SetTargetLanguages(targetLanguages);

            // Assert
            Assert.Equal(targetLanguages, component.GetTargetLanguages());
        }

        [Fact]
        public void GetId_Returns_Id()
        {
            // Arrange
            var id = 1;
            var component = new LanguagesComponent(id);

            // Act
            var result = component.GetId();

            // Assert
            Assert.Equal(id, result);
        }
    }
}
