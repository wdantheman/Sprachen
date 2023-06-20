using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.Tests.DataObjectsTest.DocumentCompositeTests
{
    public class DocumentTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            int id = 1;
            string name = "DocumentName";
            var sections = new List<SectionComponent>();

            // Act
            var document = new Document(id, name, sections);

            // Assert
            Assert.Equal(id, document.Id);
            Assert.Equal(name, document.Name);
            Assert.Equal(sections, document.GetSections());
            Assert.Equal(string.Empty, document.Description);
        }

        [Fact]
        public void AddDescription_SetsDescription()
        {
            // Arrange
            var document = new Document(1, "DocumentName", new List<SectionComponent>());
            string description = "Document description";

            // Act
            document.AddDescription(description);

            // Assert
            Assert.Equal(description, document.Description);
        }

        [Fact]
        public void AddSection_AddsSectionToList()
        {
            // Arrange
            var document = new Document(1, "DocumentName", new List<SectionComponent>());
            var section = new Subsection("SectionName", 1, new List<Language>());

            // Act
            document.AddSection(section);

            // Assert
            Assert.Contains(section, document.GetSections());
        }

        [Fact]
        public void RemoveSection_RemovesSectionFromList()
        {
            // Arrange
            var section1 = new Subsection("Section1", 1, new List<Language>());
            var section2 = new Subsection("Section2", 2, new List<Language>());
            var sections = new List<SectionComponent> { section1, section2 };
            var document = new Document(1, "DocumentName", sections);

            // Act
            document.RemoveSection(2);

            // Assert
            Assert.DoesNotContain(section2, document.GetSections());
        }
    }
}
