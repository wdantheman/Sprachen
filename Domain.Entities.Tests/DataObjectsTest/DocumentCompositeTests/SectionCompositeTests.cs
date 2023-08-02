using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.DataObjects;
using Domain.Entities.Exceptions;
using System.Reflection;

namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    public class SectionCompositeTests
    {
        [Fact]
        public void SetSubsections_Should_Set_New_Subsections()
        {
            // Arrange
            var sectionComposite = new SectionComposite("Composite Section", 1, new LanguagesComponent(2), 1);
            var subsections = new List<SectionComponent> { new SectionComposite("Subsection 1", 2, new LanguagesComponent(23), 1), new SectionComposite("Subsection 2", 3, new LanguagesComponent(2), 1) };

            // Act
            sectionComposite.SetSubsections(subsections);

            // Assert
            Assert.Equal(subsections, sectionComposite.Subsections);
        }

        [Fact]
        public void SettranslationComponents_Should_Set_New_TranslationComponents()
        {
            // Arrange
            var sectionComposite = new SectionComposite("Composite Section", 1, new LanguagesComponent(2), 1);
            var translationComponents = new Dictionary<Entry, EntryTranslationBlock>
        {
            { new Entry(12, "can't"), new EntryTranslationBlock(sectionComposite.LanguagesComponent) },
            { new Entry(11, "anrufe"), new EntryTranslationBlock(sectionComposite.LanguagesComponent) }
        };

            // Act
            sectionComposite.SetTranslationComponents(translationComponents);

            // Assert
            Assert.Equal(translationComponents, sectionComposite.GetTranslationComponent());
        }

        [Fact]
        public void SetSubsections_Should_Clear_Subsections_When_Null_Subsections_Set()
        {
            // Arrange
            var sectionComposite = new SectionComposite("Composite Section", 1, new LanguagesComponent(2), 1);
            var subsections = new List<SectionComponent> { new SectionComposite("Subsection 1", 2, new LanguagesComponent(2), 1) };
            sectionComposite.SetSubsections(subsections);
            // Act // Assert
            Assert.Throws<SectionCompositeException>(() => sectionComposite.SetSubsections(null));
        }
        [Fact]
        public void Cannot_Modify_TranslationComponents()
        {
            // Arrange
            var sectionComposite = new SectionComposite("Sample Title", 1, new LanguagesComponent(2), 123);
            var entry = new Entry(13, "entry test");
            var translationBlock = new EntryTranslationBlock(sectionComposite.LanguagesComponent); 
            var translationComponents = new Dictionary<Entry, EntryTranslationBlock>
            {
                { entry, translationBlock }
            };

            // Act
            sectionComposite.SetTranslationComponents(translationComponents);
            var retrievedTranslationComponents = sectionComposite.GetTranslationComponent();

            // Assert they are not the same
            Assert.NotSame(translationComponents, retrievedTranslationComponents);
            // Assert they are independent after Clearing the first one
            translationComponents.Clear();
            Assert.Empty(translationComponents);
            Assert.NotEmpty(retrievedTranslationComponents);
            // Assert they are independent after making null the first one
            translationComponents = null;
            Assert.Null(translationComponents);
            Assert.NotEmpty(retrievedTranslationComponents);
            // Assert that modifying a retrived TranslationComponent doesn't change the orignal in SectionComponent
            translationComponents = sectionComposite.GetTranslationComponent();
            translationComponents.Add(new Entry(12, "added test"), new EntryTranslationBlock(sectionComposite.LanguagesComponent));
            translationComponents.Add(new Entry(15, "added test2"), new EntryTranslationBlock(sectionComposite.LanguagesComponent));
            Assert.NotEqual(translationComponents.Count, retrievedTranslationComponents.Count);
            sectionComposite.SetTranslationComponents(translationComponents);
            retrievedTranslationComponents = sectionComposite.GetTranslationComponent();
            Assert.Equal(translationComponents.Count, retrievedTranslationComponents.Count);

        }

    }
}
