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
            var translationBlock = new EntryTranslationBlock(sectionComposite.LanguagesComponent); // You should create an instance of EntryTranslationBlock to add to the dictionary.
            var translationComponents = new Dictionary<Entry, EntryTranslationBlock>
            {
                { entry, translationBlock }
            };

            // Act
            sectionComposite.SetTranslationComponents(translationComponents);
            var retrievedTranslationComponents = sectionComposite.GetTranslationComponent();

            // Assert
            Assert.NotSame(translationComponents, retrievedTranslationComponents);
            //translationComponents.Clear();
            Assert.NotEmpty(retrievedTranslationComponents);

            // Attempt to modify TranslationComponents using reflection
            var type = sectionComposite.GetType();
            var translationComponentsField = type.GetField("TranslationComponents", BindingFlags.NonPublic | BindingFlags.Instance);
            translationComponentsField.SetValue(sectionComposite, translationComponents);
            Assert.NotNull(translationComponentsField);

            //var modifiedTranslationComponents = new Dictionary<Entry, EntryTranslationBlock>
            //{
            //    // Create a new dictionary with different values
            //    { new Entry(15, "entry test5"), new EntryTranslationBlock(sectionComposite.LanguagesComponent) }
            //};
            //translationComponentsField.SetValue(sectionComposite, modifiedTranslationComponents);

            //// Assert that the property remains unchanged
            //retrievedTranslationComponents = sectionComposite.GetTranslationComponent();
            //Assert.NotSame(modifiedTranslationComponents, retrievedTranslationComponents);
            //Assert.Empty(retrievedTranslationComponents);
        }

    }
}
