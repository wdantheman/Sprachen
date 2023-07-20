using Domain.Entities.DataObjects.EntryComposite;
using Domain.UseCases.EntriesUseCases;
using Moq;
using Domain.UseCases.Tests.EntriesUseCasesTests.MockServices;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.UseCases.Exceptions;

namespace Domain.UseCases.Tests.EntriesUseCasesTests
{
    public class EntryInSectionCRUDUseCaseTests
    {
        internal BasicObjectIdentifierService mockIdCreator = new BasicObjectIdentifierService();
        internal SimpleEntryCreatorCriteria mockEntryCreatorCriteria = new SimpleEntryCreatorCriteria(0, 100);
        internal SimpleEntryConfigCriteria mockConfigurationCriteria = new SimpleEntryConfigCriteria();
        internal SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);

        [Fact]
        public void AddEmptyEntryInSection_ShouldAddEntryWithEmptyContent()
        {
            // Arrange
            var useCase = new EntryInSectionCRUDUseCase(mockIdCreator, mockConfigurationCriteria, section, mockEntryCreatorCriteria);

            // Act
            useCase.AddEmptyEntryInSection();

            // Assert
            // Check that a new entry with empty content is added to the section
            Assert.NotEmpty(section.TranslationComponents.Keys);
            // Add more specific assertions if needed
        }

        [Fact]
        public void AddNewEntryInSection_ShouldAddEntryWithGivenContent()
        {
            // Arrange
            var useCase = new EntryInSectionCRUDUseCase(mockIdCreator, mockConfigurationCriteria, section, mockEntryCreatorCriteria);
            string content = "Test Content";

            // Act
            useCase.AddNewEntryInSection(content);

            // Assert
            // Check that a new entry with the given content is added to the section
            Assert.NotEmpty(section.TranslationComponents);
            // Add more specific assertions if needed
        }

        [Fact]
        public void AddEntryInSection_InvalidEntry_ShouldThrowException()
        {
            // Arrange
            var useCase = new EntryInSectionCRUDUseCase(mockIdCreator, mockConfigurationCriteria, section, mockEntryCreatorCriteria);
            var invalidEntry = new Entry(12, "invalid content");

            // Act & Assert
            // Verify that an exception is thrown when adding an invalid entry
            Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.AddEntryInSection(invalidEntry));
        }



    }
}
