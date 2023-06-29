using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.DataObjects;
using Domain.Entities.Exceptions;

namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    public class SectionCompositeTests
    {
        [Fact]
        public void SetSubsections_Should_Set_New_Subsections()
        {
            // Arrange
            var sectionComposite = new SectionComposite("Composite Section", 1, new LanguagesComponent());
            var subsections = new List<SectionComponent> { new SectionComposite("Subsection 1", 2, new LanguagesComponent()), new SectionComposite("Subsection 2", 3, new LanguagesComponent()) };

            // Act
            sectionComposite.SetSubsections(subsections);

            // Assert
            Assert.Equal(subsections, sectionComposite.Subsections);
        }

        [Fact]
        public void SettranslationComponents_Should_Set_New_TranslationComponents()
        {
            // Arrange
            var sectionComposite = new SectionComposite("Composite Section", 1, new LanguagesComponent());
            var translationComponents = new Dictionary<string, EntryTranslationBlock>
        {
            { "en", new EntryTranslationBlock(sectionComposite.LanguagesComponent) },
            { "fr", new EntryTranslationBlock(sectionComposite.LanguagesComponent) }
        };

            // Act
            sectionComposite.SetTranslationComponents(translationComponents);

            // Assert
            Assert.Equal(translationComponents, sectionComposite.TranslationComponents);
        }

        [Fact]
        public void SetSubsections_Should_Clear_Subsections_When_Null_Subsections_Set()
        {
            // Arrange
            var sectionComposite = new SectionComposite("Composite Section", 1, new LanguagesComponent());
            var subsections = new List<SectionComponent> { new SectionComposite("Subsection 1", 2, new LanguagesComponent()) };
            sectionComposite.SetSubsections(subsections);
            // Act // Assert
            Assert.Throws<SectionCompositeException>(() => sectionComposite.SetSubsections(null));
        }
    }
}
