using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using Domain.UseCases.SectionUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.DataObjects;

namespace Domain.UseCases.Tests.SectionUseCasesTests
{
    public class SectionsInSectionCRUDUseCaseTests
    {
        private readonly IObjectIdentifierService _objectIdentifierService;
        private readonly ISectionConfigCriteria _criteria;
        private SectionComposite _localSection;
        private SectionsInSectionCRUDUseCase _useCase;

        public SectionsInSectionCRUDUseCaseTests()
        {
            _objectIdentifierService = new ObjectIdentifierServiceMock(); 
            _criteria = new SectionConfigCriteriaMock(); 
            _localSection = new SectionComposite("Section test", 14, new LanguagesComponent(4), 143); // Create a test instance or use a mock object

            // Create an instance of SectionsInSectionCRUDUseCase with the dependencies
            _useCase = new SectionsInSectionCRUDUseCase(_objectIdentifierService, _criteria, _localSection);
        }

        [Fact]
        public void ResetTargetSection_ValidSection_SetsLocalSection()
        {
            // Arrange
            var newSection = new SectionComposite("other section test", 54, new LanguagesComponent(5), 143);

            // Act
            _useCase.ResetTargetSection(newSection);

            // Assert
            Assert.Equal(newSection, _useCase.GetTargetSection());
        }

        [Fact]
        public void CreateEmptySubsectionToSection_ValidSection_CreatesEmptySubsection()
        {
            // Arrange
            var initialSubsectionCount = _useCase.GetTargetSection().Subsections.Count;

            // Act
            _useCase.CreateEmptySubsectionToSection();

            // Assert
            Assert.Equal(initialSubsectionCount + 1, _useCase.GetTargetSection().Subsections.Count);
            Assert.NotNull(_useCase.GetTargetSection().Subsections[^1]); // Ensure the last subsection is not null
            Assert.Equal("Empty Section", _useCase.GetTargetSection().Subsections[^1].Title); // Ensure the title is set correctly
        }

        [Fact]
        public void AddSubsectionToSection_NullSection_ThrowsSectionsCRUDUseCaseException()
        {
            // Arrange

            // Act & Assert
            var exception = Assert.Throws<SectionsCRUDUseCaseException>(() => _useCase.AddSubsectionToSection(null));
            Assert.Equal("Subsection to add is null", exception.Message);
        }

        [Fact]
        public void AddSubsectionToSection_InvalidSection_ThrowsSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var invalidSection = new SectionComposite("Invalid Section", 54, new LanguagesComponent(5), 143);

            // Act & Assert
            var exception = Assert.Throws<SectionsCRUDUseCaseException>(() => _useCase.AddSubsectionToSection(invalidSection));
            Assert.Equal("the section to add is not Valid", exception.Message);
        }

        [Fact]
        public void AddSubsectionToSection_ValidSection_AddsSubsection()
        {
            // Arrange
            var subsection = new SectionComposite("some Section", 54, new LanguagesComponent(5), 143); 

            // Act
            _useCase.AddSubsectionToSection(subsection);

            // Assert
            Assert.Contains(subsection, _useCase.GetTargetSection().Subsections);
        }

        [Fact]
        public void ReadSections_EmptySection_ReturnsEmptyList()
        {
            // Arrange

            // Act
            var sections = _useCase.ReadSections();

            // Assert
            Assert.Empty(sections);
        }

        [Fact]
        public void ReadSections_NonEmptySection_ReturnsAllSections()
        {
            // Arrange
            var subsection1 = new SectionComposite("some Section", 54, new LanguagesComponent(5), 143);
            var subsection2 = new SectionComposite("some Section 2", 55, new LanguagesComponent(6), 143);
            _useCase.AddSubsectionToSection(subsection1);
            _useCase.AddSubsectionToSection(subsection2);

            // Act
            var sections = _useCase.ReadSections();

            // Assert
            Assert.Equal(2, sections.Count);
            Assert.Contains(subsection1, sections);
            Assert.Contains(subsection2, sections);
        }

        [Fact]
        public void ReadSectionById_SectionExists_ReturnsCorrectSection()
        {
            // Arrange
            var sectionId = 23;
            var subsection = new SectionComposite("some Section", sectionId, new LanguagesComponent(5), 143);
            _useCase.AddSubsectionToSection(subsection);

            // Act
            var section = _useCase.ReadSectionById(sectionId);

            // Assert
            Assert.Equal(subsection, section);
        }

        [Fact]
        public void ReadSectionById_SectionDoesNotExist_ThrowsSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var sectionId = 1;

            // Act & Assert
            var exception = Assert.Throws<SectionsCRUDUseCaseException>(() => _useCase.ReadSectionById(sectionId));
            Assert.Equal("the section Id didn't returned results", exception.Message);
        }

        [Fact]
        public void ReadSectionById_DuplicateSectionId_ReturnsFirstSection()
        {
            // Arrange
            var sectionId = 1;
            var subsection1 = new SectionComposite("some Section", sectionId, new LanguagesComponent(5), 143);
            var subsection2 = new SectionComposite("some other Section", sectionId, new LanguagesComponent(5), 143);
            _useCase.AddSubsectionToSection(subsection1);
            _useCase.AddSubsectionToSection(subsection2);
            // Act
            var section = _useCase.ReadSectionById(sectionId);

            // Assert
            Assert.Equal(subsection1, section);
        }

        [Fact]
        public void ReadSectionByTitle_SectionExists_ReturnsCorrectSection()
        {
            // Arrange
            var title = "Section 1";
            var subsection = new SectionComposite("some Section", 23, new LanguagesComponent(5), 143);
            subsection.Title = title;
            _useCase.AddSubsectionToSection(subsection);

            // Act
            var section = _useCase.ReadSectionByTitle(title);

            // Assert
            Assert.Equal(subsection, section);
        }

        [Fact]
        public void ReadSectionByTitle_SectionDoesNotExist_ThrowsSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var title = "Non-existent Section";

            // Act & Assert
            var exception = Assert.Throws<SectionsCRUDUseCaseException>(() => _useCase.ReadSectionByTitle(title));
            Assert.Equal("the section Title didn't return any results", exception.Message);
        }

        [Fact]
        public void ReadSectionByTitle_DuplicateSectionTitle_ReturnsFirstSection()
        {
            // Arrange
            var title = "Section 1";
            var subsection1 = new SectionComposite("some Section", 23, new LanguagesComponent(5), 143);
            subsection1.Title = title;
            var subsection2 = new SectionComposite("some Section", 23, new LanguagesComponent(5), 143);
            subsection2.Title = title;
            _useCase.AddSubsectionToSection(subsection1);
            _useCase.AddSubsectionToSection(subsection2);

            // Act
            var section = _useCase.ReadSectionByTitle(title);

            // Assert
            Assert.Equal(subsection1, section);
        }

        [Fact]
        public void UpdateSections_ValidSections_UpdatesSubsections()
        {
            // Arrange
            var subsection1 = new SectionComposite("some Section", 23, new LanguagesComponent(5), 143);
            var subsection2 = new SectionComposite("some Section 2", 23, new LanguagesComponent(5), 143);
            var newSections = new List<SectionComponent> { subsection1, subsection2 };

            // Act
            _useCase.UpdateSections(newSections);

            // Assert
            Assert.Equal(newSections, _useCase.GetTargetSection().Subsections);
        }

        [Fact]
        public void UpdateSections_InvalidSections_ThrowsSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var subsection1 = new SectionComposite("Invalid Section", 23, new LanguagesComponent(5), 143);
            var subsection2 = new SectionComposite("some Section 2", 23, new LanguagesComponent(5), 143);
            var newSections = new List<SectionComponent> { subsection1, subsection2 };

            // Act & Assert
            var exception = Assert.Throws<SectionsCRUDUseCaseException>(() => _useCase.UpdateSections(newSections));
            Assert.Equal("Sections couldn't be Updated as they weren't Valid", exception.Message);
        }

        [Fact]
        public void DeleteSectionFromSection_ValidSectionId_RemovesSection()
        {
            // Arrange
            var sectionId = 1;
            var subsection = new SectionComposite("some Section", sectionId, new LanguagesComponent(5), 143);
            _useCase.AddSubsectionToSection(subsection);

            // Act
            _useCase.DeleteSectionFromSection(sectionId);

            // Assert
            Assert.DoesNotContain(subsection, _useCase.GetTargetSection().Subsections);
        }

        [Fact]
        public void DeleteSectionFromSection_InvalidSectionId_ThrowsSectionsInSectionsCRUDUseCaseException()
        {
            // Arrange
            var sectionId = 1;

            // Act & Assert
            var exception = Assert.Throws<SectionsCRUDUseCaseException>(() => _useCase.DeleteSectionFromSection(sectionId));
            Assert.Equal("There is no section to remove", exception.Message);
        }
    }
}
