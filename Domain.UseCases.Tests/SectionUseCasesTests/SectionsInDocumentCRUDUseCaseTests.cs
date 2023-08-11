using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.Entities.PersistenceServices;
using Domain.Entities;
using Domain.UseCases.Exceptions;
using Moq;
using Domain.Entities.PersistenceServices.SectionPersistenceServices;
using Domain.UseCases.SectionUseCases;

namespace Domain.UseCases.Tests.SectionUseCasesTests
{
    public class SectionsInDocumentCRUDUseCaseTests
    {
        private readonly IObjectIdentifierService _objectIdentifierService;
        private readonly Document _document;
        private readonly ISectionConfigCriteria _criteria;

        public SectionsInDocumentCRUDUseCaseTests()
        {
            _objectIdentifierService = new ObjectIdentifierServiceMock();
            _document = new Document(1, "TEst DOc", new List<SectionComponent>(), new LanguagesComponent(2));
            _criteria = new SectionConfigCriteriaMock();
        }

        [Fact]
        public void SetDocument_WhenNewDocumentProvided_ShouldSetLocalDocument()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var newDocument = new Document(4, "TEst DOc 2", new List<SectionComponent>(), new LanguagesComponent(2));

            // Act
            useCase.SetDocument(newDocument);

            // Assert
            Assert.Equal(newDocument, useCase.GetDocument());
        }

        [Fact]
        public void SetDocument_WhenNullDocumentProvided_ShouldThrowArgumentNullException()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => useCase.SetDocument(null));
        }

        [Fact]
        public void CreateEmptySectionInDocument_ShouldAddEmptySubsectionToSections()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var initialSectionsCount = useCase.GetDocument().GetSections().Count;

            // Act
            useCase.CreateEmptySectionInDocument();
            var sections = useCase.GetDocument().GetSections();

            // Assert
            Assert.Equal(initialSectionsCount + 1, sections.Count);
            Assert.NotNull(sections.Find(s => s.Title == "Empty Subsection"));
        }

        [Fact]
        public void CreateAddSectionToDocument_WhenSectionIsValid_ShouldAddSectionToDocument()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var section = new SectionComposite("Valid Section", 1, _document.GetLanguageComponent(), 1); // Create a valid section

            // Act
            useCase.AddSectionToDocument(section);
            var sections = useCase.GetDocument().GetSections();

            // Assert
            Assert.Contains(section, sections);
        }

        [Fact]
        public void CreateAddSectionToDocument_WhenSectionIsInvalid_ShouldThrowSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var section = new SectionComposite("Invalid Section", 1, _document.GetLanguageComponent(), 1); // Create an invalid section

            // Act & Assert
            Assert.Throws<SectionsInDocumentCRUDUseCaseException>(() => useCase.AddSectionToDocument(section));
        }

        [Fact]
        public void ReadSections_ShouldReturnListOfSections()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
            {
                new SectionComposite("Section 1", 1, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 2", 2, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 3", 3, _document.GetLanguageComponent(), 1)
            };
            useCase.GetDocument().SetSections(sections);

            // Act
            var result = useCase.ReadSections();

            // Assert
            Assert.Equal(sections, result);
        }

        [Fact]
        public void ReadSectionwithId_WhenSectionIdExists_ShouldReturnSectionComponent()
        {
            // Arrange
            var sut = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
            {
                new SectionComposite("Section 1", 1, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 2", 2, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 3", 3, _document.GetLanguageComponent(), 1)
            };
            sut.GetDocument().SetSections(sections);
            int sectionId = 2;

            // Act
            SectionComponent result = sut.ReadSectionById(sectionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sectionId, result.SectionIdDoc);
        }

        [Fact]
        public void ReadSectionwithId_WhenSectionIdDoesNotExist_ShouldThrowSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
            {
                new SectionComposite("Section 1", 1, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 2", 2, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 3", 3, _document.GetLanguageComponent(), 1)
            };
            useCase.GetDocument().SetSections(sections);
            var sectionId = 4; // Non-existent section ID

            // Act & Assert
            Assert.Throws<SectionsInDocumentCRUDUseCaseException>(() => useCase.ReadSectionById(sectionId));
        }

        [Fact]
        public void ReadSectionByTitle_WhenSectionTitleExists_ShouldReturnSectionComponent()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
            {
                new SectionComposite("Section 1", 1, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 2", 2, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 3", 3, _document.GetLanguageComponent(), 1)
            };
            useCase.GetDocument().SetSections(sections);
            var title = "Section 2";

            // Act
            var result = useCase.ReadSectionByTitle(title);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(title, result.Title);
        }

        [Fact]
        public void ReadSectionByTitle_WhenSectionTitleDoesNotExist_ShouldThrowSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
            {
                new SectionComposite("Section 1", 1, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 2", 2, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 3", 3, _document.GetLanguageComponent(), 1)
            };
            useCase.GetDocument().SetSections(sections);
            var title = "Section 4"; // Non-existent section title

            // Act & Assert
            Assert.Throws<SectionsInDocumentCRUDUseCaseException>(() => useCase.ReadSectionByTitle(title));
        }

        [Fact]
        public void UpdateSections_WhenSectionsAreValid_ShouldUpdateSectionsInDocument()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
            {
                new SectionComposite("Section 1", 1, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 2", 2, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 3", 3, _document.GetLanguageComponent(), 1)
            };

            // Act
            useCase.UpdateSections(sections);
            var result = useCase.GetDocument().GetSections();

            // Assert
            Assert.Equal(sections, result);
        }

        [Fact]
        public void UpdateSections_WhenSectionsAreInvalid_ShouldThrowSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
            {
                new SectionComposite("Invalid Section", 1, _document.GetLanguageComponent(), 1) // Invalid section
            };

            // Act & Assert
            Assert.Throws<SectionsInDocumentCRUDUseCaseException>(() => useCase.UpdateSections(sections));
        }

        [Fact]
        public void DeleteSectionFromDocument_WhenSectionCanBeRemoved_ShouldRemoveSectionFromDocument()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
    {
        new SectionComposite("Section 1", 1, _document.GetLanguageComponent(), 1),
        new SectionComposite("Section 2", 2, _document.GetLanguageComponent(), 1),
        new SectionComposite("Section 3", 3, _document.GetLanguageComponent(), 1)
    };
            useCase.GetDocument().SetSections(sections);
            var sectionIdToRemove = 2;

            // Act
            useCase.DeleteSectionFromDocument(sectionIdToRemove);
            var result = useCase.GetDocument().GetSections();

            // Assert
            Assert.DoesNotContain(result, s => s.SectionIdDoc == sectionIdToRemove);
        }
        [Fact]
        public void DeleteSectionFromDocument_WhenSectionCannotBeRemoved_ShouldThrowSectionsInDocumentCRUDUseCaseException()
        {
            // Arrange
            var useCase = new SectionsInDocumentCRUDUseCase(_objectIdentifierService, _document, _criteria);
            var sections = new List<SectionComponent>
            {
                new SectionComposite("Undeleatable", 1, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 2", 2, _document.GetLanguageComponent(), 1),
                new SectionComposite("Section 3", 3, _document.GetLanguageComponent(), 1)
            };
            useCase.GetDocument().SetSections(sections);
            var sectionIdToRemove = 1;
            // Act and Assert
            Assert.Throws<SectionsInDocumentCRUDUseCaseException>(() => useCase.DeleteSectionFromDocument(sectionIdToRemove));
        }

    }
}