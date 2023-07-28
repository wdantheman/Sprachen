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
        [Fact]
        public void AddEntryInSection_ValidEntry_AddsEntryAndTranslationBlock()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            EntryInSectionCRUDUseCase useCase = new EntryInSectionCRUDUseCase(mockIdCreator, mockEntryConfigCriteria, mockSection, mockCreatorCriteria);


            // Inject a fake EntryConfigCriteria that returns true for all entries
            var fakeEntryConfigCriteria = new Mock<IEntryConfigCriteria>();
            fakeEntryConfigCriteria.Setup(ec => ec.IsEntryValidInSection(It.IsAny<Entry>(), It.IsAny<SectionComposite>())).Returns(true);

            var useCase = new EntryInSectionCRUDUseCase(idCreator, fakeEntryConfigCriteria.Object, section, creatorCriteria);

            // Act
            var entry = new Entry(); // Create a test instance of Entry
            useCase.AddEntryInSection(entry);

            // Assert
            Assert.True(section.TranslationComponents.ContainsKey(entry));
        }

        [Fact]
        public void AddEntryInSection_InvalidEntry_ThrowsException()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            // Inject a fake EntryConfigCriteria that returns false for all entries
            var fakeEntryConfigCriteria = new Mock<IEntryConfigCriteria>();
            fakeEntryConfigCriteria.Setup(ec => ec.IsEntryValidInSection(It.IsAny<Entry>(), It.IsAny<SectionComposite>())).Returns(false);

            var useCase = new EntryInSectionCRUDUseCase(idCreator, fakeEntryConfigCriteria.Object, section, creatorCriteria);

            // Act & Assert
            var entry = new Entry(); // Create a test instance of Entry
            Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.AddEntryInSection(entry));
        }

        [Fact]
        public void GetEntrybyId_ExistingEntryId_ReturnsEntry()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            // Inject some test entries into the Section for testing
            var entry1 = new Entry { Id = 1 };
            var entry2 = new Entry { Id = 2 };
            section.TranslationComponents.Add(entry1, new EntryTranslationBlock(section.LanguagesComponent));
            section.TranslationComponents.Add(entry2, new EntryTranslationBlock(section.LanguagesComponent));

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);

            // Act
            var result = useCase.GetEntrybyId(1);

            // Assert
            Assert.Equal(entry1, result);
        }

        [Fact]
        public void GetEntrybyId_NonExistingEntryId_ThrowsException()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);

            // Act & Assert
            Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.GetEntrybyId(1));
        }

        [Fact]
        public void GetEntryByContent_ExistingEntryContent_ReturnsEntry()
        {
            // Arrange
            var idCreator = new Mock<IObjectIdentifierService>().Object;
            var entryConfigCriteria = new Mock<IEntryConfigCriteria>().Object;
            var section = new SectionComposite(); // Create a test instance of SectionComposite
            var creatorCriteria = new Mock<IEntryCreatorCriteria>().Object;

            // Inject some test entries into the Section for testing
            var entry1 = new Entry { Id = 1, Content = "Test Content" };
            section.TranslationComponents.Add(entry1, new EntryTranslationBlock(section.LanguagesComponent));

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);

            // Act
            var result = useCase.GetEntryByContent("Test Content");

            // Assert
            Assert.Equal(entry1, result);
        }

        [Fact]
        public void GetEntryByContent_NonExistingEntryContent_ThrowsException()
        {
            // Arrange
            var idCreator = new Mock<IObjectIdentifierService>().Object;
            var entryConfigCriteria = new Mock<IEntryConfigCriteria>().Object;
            var section = new SectionComposite(); // Create a test instance of SectionComposite
            var creatorCriteria = new Mock<IEntryCreatorCriteria>().Object;

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);

            // Act & Assert
            Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.GetEntryByContent("Non-existing Content"));
        }
        
        [Fact]
        public void UpdateEntryContentById_ValidEntryId_UpdatesEntryContent()
        {
            // Arrange
            var idCreator = new Mock<IObjectIdentifierService>().Object;
            var entryConfigCriteria = new Mock<IEntryConfigCriteria>().Object;
            var section = new SectionComposite(); // Create a test instance of SectionComposite
            var creatorCriteria = new Mock<IEntryCreatorCriteria>().Object;

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);

            // Act
            useCase.UpdateEntryContentById(1, "New Content");

            // Assert
            var updatedEntry = section.TranslationComponents.Keys.FirstOrDefault(entry => entry.Id == 1);
            Assert.NotNull(updatedEntry);
            Assert.Equal("New Content", updatedEntry.Content);
        }

        [Fact]
        public void DeleateEntryById_ValidEntryId_RemovesEntry()
        {
            // Arrange
            var idCreator = new Mock<IObjectIdentifierService>().Object;
            var entryConfigCriteria = new Mock<IEntryConfigCriteria>().Object;
            var section = new SectionComposite(); // Create a test instance of SectionComposite
            var creatorCriteria = new Mock<IEntryCreatorCriteria>().Object;

            // Inject some test entries into the Section for testing
            var entry1 = new Entry { Id = 1, Content = "Test Content" };
            section.TranslationComponents.Add(entry1, new EntryTranslationBlock(section.LanguagesComponent));

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);

            // Act
            useCase.DeleateEntryById(1);

            // Assert
            Assert.Empty(section.TranslationComponents);
        }

        [Fact]
        public void DeleateEntryByContent_ValidEntryContent_RemovesEntry()
        {
            // Arrange
            var idCreator = new Mock<IObjectIdentifierService>().Object;
            var entryConfigCriteria = new Mock<IEntryConfigCriteria>().Object;
            var section = new SectionComposite(); // Create a test instance of SectionComposite
            var creatorCriteria = new Mock<IEntryCreatorCriteria>().Object;

            // Inject some test entries into the Section for testing
            var entry1 = new Entry { Id = 1, Content = "Test Content" };
            section.TranslationComponents.Add(entry1, new EntryTranslationBlock(section.LanguagesComponent));

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);

            // Act
            useCase.DeleateEntryByContent("Test Content");

            // Assert
            Assert.Empty(section.TranslationComponents);
        }





    }
}
