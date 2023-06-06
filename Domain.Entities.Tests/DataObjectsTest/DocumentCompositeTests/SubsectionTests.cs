using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    public class SubsectionTests
    {
            [Fact]
            public void SetSourceLanguage_ShouldSetSourceLanguage()
            {
                // Arrange
                var title = "Subsection 1";
                var id = 1;
                var languages = new List<Language> { Language.English, Language.French };
                var subsection = new Subsection(title, id, languages);
                var sourceLanguage = Language.English;

                // Act
                subsection.SetSourceLanguage(sourceLanguage);

                // Assert
                Assert.Equal(sourceLanguage, subsection.GetSourceLanguage());
            }

            [Fact]
            public void AddSubsectionComponent_ShouldNotAddComponentToSubsection()
            {
                // Arrange
                var title = "Subsection 1";
                var id = 1;
                var languages = new List<Language> { Language.English, Language.French };
                var subsection = new Subsection(title, id, languages);
                var component = new Subsection("Component", 2, languages); // Replace with appropriate Subsection instance

                // Act // Assert
                Assert.Throws<SubsectionException>(() => subsection.AddSubsectionComponent(component));
            }

            [Fact]
            public void RemoveSubsectionComponent_ShouldNotRemoveComponentFromSubsection()
            {
                // Arrange
                var title = "Subsection 1";
                var id = 1;
                var languages = new List<Language> { Language.English, Language.French };
                var subsection = new Subsection(title, id, languages);

                // Act // Assert
                Assert.Throws<SubsectionException>(() => subsection.RemoveSubsectionComponent(2));

            }

            [Fact]
            public void AddTargetLanguage_ShouldAddLanguageToTargetLanguages()
            {
                // Arrange
                var title = "Subsection 1";
                var id = 1;
                var languages = new List<Language> { Language.English };
                var subsection = new Subsection(title, id, languages);
                var language = Language.French; // Replace with appropriate Language instance

                // Act
                subsection.AddTargetLanguage(language);

                // Assert
                Assert.Contains(language, subsection.GetTargetLanguages());
            }

            [Fact]
            public void RemoveTargetLanguage_ShouldRemoveLanguageFromTargetLanguages()
            {
                // Arrange
                var title = "Subsection 1";
                var id = 1;
                var languages = new List<Language> { Language.English, Language.French };
                var subsection = new Subsection(title, id, languages);
                var language = Language.French; // Replace with appropriate Language instance

                // Act
                subsection.RemoveTargetLanguage(language);

                // Assert
                Assert.DoesNotContain(language, subsection.GetTargetLanguages());
            }

            [Fact]
            public void GetEntries_ShouldReturnTranslationComponents()
            {
                // Arrange
                var title = "Subsection 1";
                var id = 1;
                var languages = new List<Language> { Language.English, Language.French };
                var subsection = new Subsection(title, id, languages);
                var translationComponents = new Dictionary<string, EntryTranslationBlock>(); // Replace with appropriate EntryTranslationBlock instances
                subsection.UpdateEntries(translationComponents);

                // Act
                var entries = subsection.GetEntries();

                // Assert
                Assert.Equal(translationComponents, entries);
            }

            [Fact]
            public void UpdateEntries_ShouldUpdateTranslationComponents()
            {
                // Arrange
                var title = "Subsection 1";
                var id = 1;
                var languages = new List<Language> { Language.English, Language.French };
                var subsection = new Subsection(title, id, languages);
                var translationComponents = new Dictionary<string, EntryTranslationBlock>(); // Replace with appropriate EntryTranslationBlock instances

                // Act
                subsection.UpdateEntries(translationComponents);

                // Assert
                Assert.Equal(translationComponents, subsection.GetEntries());
            }
        }

}
