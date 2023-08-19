using Domain.Entities.DataObjects.EntryComposite;
using Domain.UseCases.EntriesUseCases;
using Moq;
using Domain.UseCases.Tests.EntriesUseCasesTests.MockServices;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.UseCases.Exceptions;
using Domain.Entities;


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
            Assert.NotEmpty(mockSection.GetTranslationComponent());
            Assert.NotEmpty(mockSection.GetTranslationComponent().Keys);
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
            Assert.NotEmpty(mockSection.GetTranslationComponent());
            Assert.Equal(content, useCase.GetEntryByContent(content).Content);
        }

        [Fact]
        public void AddEntryInSection_InvalidEntry_ShouldThrowException()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            EntryInSectionCRUDUseCase useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);
            Entry invalidEntry = new Entry(15, "invalid content");

            // Act & Assert
            // Verify that an exception is thrown when adding an invalid entry
            Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.AddEntryInSection(invalidEntry));
        }
        [Fact]
        public void AddEntryInSection_ValidEntry_AddsEntryAndTranslationBlock()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);
            EntryInSectionCRUDUseCase useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);
            
            // Act
            var entry = new Entry(12, "some content"); // Create a test instance of Entry
            useCase.AddEntryInSection(entry);

            // Assert
            Assert.True(section.GetTranslationComponent().ContainsKey(entry));
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
            var entry = new Entry(12, "some content"); // Create a test instance of Entry
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
            var entry1 = new Entry(1, "some content");
            var entry2 = new Entry(2, "some content 2");
            var temp = section.GetTranslationComponent();
            temp.Add(entry1, new EntryTranslationBlock(section.LanguagesComponent));
            temp.Add(entry2, new EntryTranslationBlock(section.LanguagesComponent));
            section.SetTranslationComponents(temp);

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
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            // Inject some test entries into the Section for testing
            var entry1 = new Entry(12, "Test Content");
            var temp = section.GetTranslationComponent();
            temp.Add(entry1, new EntryTranslationBlock(section.LanguagesComponent));
            section.SetTranslationComponents(temp);

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
            var section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            var creatorCriteria = new Mock<IEntryCreatorCriteria>().Object;

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);

            // Act & Assert
            Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.GetEntryByContent("Non-existing Content"));
        }
        
        [Fact]
        public void UpdateEntryContentById_ValidEntryId_UpdatesEntryContent()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);
            useCase.AddEntryInSection(new Entry(1, "Test Content"));
            string newContent = "New content";
            // Act
            useCase.UpdateEntryContentById(1, newContent);
            //// Assert
            Entry updatedEntry = useCase.GetEntryByContent(newContent);
            Assert.NotNull(updatedEntry);
            Assert.Equal(newContent, updatedEntry.Content);
        }

        [Fact]
        public void DeleateEntryById_ValidEntryId_RemovesEntry()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            var entry1 = new Entry(12, "some content");
            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);
            useCase.AddEntryInSection(entry1);

            // Act
            useCase.DeleateEntryById(12);

            // Assert
            Assert.Empty(section.GetTranslationComponent());
        }
        [Fact]
        public void DeleateManyEntriesById_ValidEntryId_RemovesEntry()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);

            // Inject some test entries into the Section for testing
            var entry1 = new Entry(12, "some content");
            var entry2 = new Entry(13, "some content 2");
            var entry3 = new Entry(14, "some content 3");
            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);
            useCase.AddEntryInSection(entry1);
            useCase.AddEntryInSection(entry2);
            useCase.AddEntryInSection(entry3);
            // Act
            useCase.DeleateEntryById(12);
            useCase.DeleateEntryById(13);

            //// Assert
            Assert.Single(section.GetTranslationComponent());
            Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.GetEntrybyId(12));
            Assert.Throws<EntryInSectionCRUDUseCaseException>(() => useCase.GetEntrybyId(13));
            Assert.NotNull(useCase.GetEntrybyId(14));
        }


        [Fact]
        public void DeleateEntryByContent_ValidEntryContent_RemovesEntry()
        {
            // Arrange
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);
            string testContent = "Test content to deleate";
            Entry entry1 = new Entry(12, "some content");
            Entry entry2 = new Entry(13, testContent);
            Entry entry3 = new Entry(14, "some content 3");
            Entry entry4 = new Entry(15, testContent);
            
            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);
            useCase.AddEntryInSection(entry1);
            useCase.AddEntryInSection(entry2);
            useCase.AddEntryInSection(entry3);
            useCase.AddEntryInSection(entry4);

            // Act
            useCase.DeleateEntryByContent(testContent);

            // Assert
            Assert.Equal(2, section.GetTranslationComponent().Count);
        }

        [Fact]
        public void UpdateEntryContainingSubsection_Correctly_Changed_ParentId() 
        {
            //Arrenge
            IObjectIdentifierService idCreator = new BasicObjectIdentifierService();
            IEntryConfigCriteria entryConfigCriteria = new SimpleEntryConfigCriteria();
            SectionComposite section = new SectionComposite("MockSection", 12, new LanguagesComponent(4), 1);
            SectionComposite section2 = new SectionComposite("MockSection", 423, new LanguagesComponent(7), 1);
            IEntryCreatorCriteria creatorCriteria = new SimpleEntryCreatorCriteria(0, 100);
            string testContent = "Test content to deleate";
            Entry entry1 = new Entry(12, "some content");
            Entry entry2 = new Entry(13, testContent);
            Entry entry3 = new Entry(14, "some content 3");
            Entry entry4 = new Entry(15, testContent);

            var useCase = new EntryInSectionCRUDUseCase(idCreator, entryConfigCriteria, section, creatorCriteria);
            useCase.AddEntryInSection(entry1);
            useCase.AddEntryInSection(entry2);
            useCase.AddEntryInSection(entry3);
            useCase.AddEntryInSection(entry4);

            //Act
            useCase.UpdateEntryContainingSubsection(15, 423);
            //Assert
            Assert.Equal(section2.SectionIdDoc, useCase.GetEntrybyId(15).ParentObjectId);
        }
    }
}
