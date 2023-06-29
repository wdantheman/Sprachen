using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.Entities.Exceptions;

namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    public class DocumentTests
    {
        [Fact]
        public void UpdateDescription_Should_Set_New_Description()
        {
            // Arrange
            var document = new Document(1, "Document 1", new List<SectionComponent>());
            string newDescription = "Updated description";

            // Act
            document.UpdateDescription(newDescription);

            // Assert
            Assert.Equal(newDescription, document.Description);
        }

        [Fact]
        public void SetSections_Should_Set_New_Sections()
        {
            // Arrange
            var document = new Document(1, "Document 1", new List<SectionComponent>());
            var newSections = new List<SectionComponent> { new SectionComposite("title1", 1, document.GetLanguageComponent()), new SectionComposite("title2", 2, document.GetLanguageComponent())};

            // Act
            document.SetSections(newSections);

            // Assert
            Assert.Equal(newSections, document.GetSections());
        }

        [Fact]
        public void GetLanguageComponent_Should_Return_LanguagesComponent_Instance()
        {
            // Arrange
            var document = new Document(1, "Document 1", new List<SectionComponent>());
            var languagesComponent = new LanguagesComponent(2);
            document.SetLanguageComponent(languagesComponent);

            // Act
            var result = document.GetLanguageComponent();

            // Assert
            Assert.Same(languagesComponent, result);
        }

        [Fact]
        public void SetLanguageComponent_Should_Set_New_LanguagesComponent_Instance()
        {
            // Arrange
            var document = new Document(1, "Document 1", new List<SectionComponent>());
            var languagesComponent = new LanguagesComponent(2);

            // Act
            document.SetLanguageComponent(languagesComponent);

            // Assert
            Assert.Same(languagesComponent, document.GetLanguageComponent());
        }

        [Fact]
        public void GetSections_Should_Throw_EmptyException_When_No_Sections_Set()
        {
            // Arrange // Act// Assert
            Assert.Throws<DocumentException>(() => new Document(1, "Document 1", null));
        }

        [Fact]
        public void GetSections_Should_Return_Same_Sections_List_Instance()
        {
            // Arrange
            LanguagesComponent languagesComponent = new LanguagesComponent(2);
            var sections = new List<SectionComponent> { new SectionComposite("title1", 1, languagesComponent), new SectionComposite("title2", 2, languagesComponent) };
            var document = new Document(1, "Document 1", sections);

            // Act
            var result = document.GetSections();

            // Assert
            Assert.Same(sections, result);
        }
    }
}
