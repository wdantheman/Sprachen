using Domain.Entities.DataObjects.EntryComposite;
using Domain.UseCases.EntriesUseCases;
using Moq;
using Domain.UseCases.Tests.EntriesUseCasesTests.MockServices;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.UseCases.Exceptions;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.UseCases.Tests.EntriesUseCasesTests
{
    public class EntryInSectionCRUDUseCaseTests
    {
        [Fact]
        public void ResetSection_Should_SetSectionCorrectly()
        {
            // Arrange
            IObjectIdentifierService mockIdCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria mockEntryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite mockSection = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria mockCreatorCriteria = new SimpleEntryCreatorCriteria(0, 100);
            EntryInSectionCRUDUseCase useCase = new EntryInSectionCRUDUseCase(mockIdCreator, mockEntryConfigCriteria, mockSection, mockCreatorCriteria);

            // Act
            SectionComposite newMockSection = new SectionComposite("MockSection 2", 14, new LanguagesComponent(4), 1);
            useCase.ResetSection(newMockSection);

            // Assert
            Assert.Equal(newMockSection, useCase.Section);
            Assert.Equal(newMockSection.Title, useCase.Section.Title);
        }
        [Fact]
        public void AddEmptyEntryInSection_ShouldAddEntryWithEmptyContent()
        {
            // Arrange
            IObjectIdentifierService mockIdCreator = new BasicObjectIdentifierService();
            SectionComposite mockSection = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryConfigCriteria mockEntryConfigCriteria = new SimpleEntryConfigCriteria();
            IEntryCreatorCriteria mockCreatorCriteria = new SimpleEntryCreatorCriteria(0, 100);
            EntryInSectionCRUDUseCase useCase = new EntryInSectionCRUDUseCase(mockIdCreator, mockEntryConfigCriteria, mockSection, mockCreatorCriteria);

            // Act

            useCase.AddEmptyEntryInSection();

            //// Assert
            //// Check that a new entry with empty content is added to the section
            Assert.NotEmpty(mockSection.TranslationComponents);
            Assert.NotEmpty(mockSection.TranslationComponents.Keys);
            // Add more specific assertions if needed
        }


        [Fact]
        public void AddNewEntryInSection_ShouldAddEntryWithGivenContent()
        {
            // Arrange
            IObjectIdentifierService mockIdCreator = new BasicObjectIdentifierService();
            SectionComposite mockSection = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryConfigCriteria mockEntryConfigCriteria = new SimpleEntryConfigCriteria();
            IEntryCreatorCriteria mockCreatorCriteria = new SimpleEntryCreatorCriteria(0, 100);
            EntryInSectionCRUDUseCase useCase = new EntryInSectionCRUDUseCase(mockIdCreator, mockEntryConfigCriteria, mockSection, mockCreatorCriteria);
            string content = "Test Content";

            // Act
            useCase.AddNewEntryInSection(content);

            // Assert
            Assert.NotEmpty(mockSection.TranslationComponents);
            Assert.Equal(content, useCase.GetEntryByContent(content).Content);
        }   

        //[Fact]
        //public void AddEntryInSection_InvalidEntry_ShouldThrowException()
        //{
        //    // Arrange
        //    var useCase = new EntryInSectionCRUDUseCase(mockIdCreator, mockConfigurationCriteria, section, mockEntryCreatorCriteria);
        //    var invalidEntry = new Entry(12, "invalid content");

        //    // Act & Assert
        //    // Verify that an exception is thrown when adding an invalid entry
        //    Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.AddEntryInSection(invalidEntry));
        //}



    }
}
