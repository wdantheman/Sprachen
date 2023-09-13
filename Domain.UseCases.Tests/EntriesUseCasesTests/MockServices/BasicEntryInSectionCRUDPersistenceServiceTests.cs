using Domain.Entities.DataObjects.EntryComposite;
using Domain.UseCases.EntriesUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.UseCases.Tests.EntriesUseCasesTests.MockServices
{
    public class BasicEntryInSectionCRUDPersistenceServiceTests
    {
        [Fact]
        public void DictionaryLoadsCorrectly() 
        {
            // Arrange
            int docNUmber = 10;
            int sectionsPerDoc = 10;
            int sectionCount = 10;
            // Act
            BasicEntryInSectionCRUDPersistenceService sut = new BasicEntryInSectionCRUDPersistenceService(docNUmber, sectionsPerDoc, sectionCount);
            // Assert
            Assert.Equal(docNUmber, sut.Documents.Count());
            Assert.Equal(sectionsPerDoc * docNUmber, sut.Sections.Count());
            Assert.Equal(sut.GetSectionComposite(1, 12).Title, sut.Sections[(1,12)].Title);
            // el rango de las secciones es i+10, el de las Entradas debe ser de i + 20 
        }
        // so, I need to add the apropiate test suit here for that, but, I want to do it with the fucking code generator first.


        //[Fact]
        //public void ReadEntryInSection_ReturnsCorrectEntry()
        //{
        //    // Arrange
        //    int docNUmber = 10;
        //    int sectionsPerDoc = 10;
        //    int entriesPerSection = 10;
        //    // Act
        //    BasicEntryInSectionCRUDPersistenceService sut = new BasicEntryInSectionCRUDPersistenceService(docNUmber, sectionsPerDoc, entriesPerSection);
        //    var result = sut.ReadEntryinSection(3,6);

        //    // Assert
        //    Assert.NotNull(result); // Add more specific assertions as needed
        //}

        //[Fact]
        //public void CreateEntryInSection_AddsNewEntry()
        //{
        //    // Arrange
        //    int docNUmber = 10;
        //    int sectionsPerDoc = 10;
        //    int entriesPerSection = 10;

        //    BasicEntryInSectionCRUDPersistenceService sut = new BasicEntryInSectionCRUDPersistenceService(docNUmber, sectionsPerDoc, entriesPerSection);
        //    CreateEntryUseCase entryCreator = new CreateEntryUseCase(new BasicObjectIdentifierService(), new SimpleEntryCreatorCriteria(0, 100));
        //    Entry entry = entryCreator.CreateEmptyEntry(3);

        //    // Act
        //    sut.CreateEntryinSection(3, 3, entry);

        //    // Assert
        //    // Check if the new entry was added successfully and exists in Entries dictionary
        //    var retrievedEntry = sut.ReadEntryinSection(3, entry.Id);
        //    Assert.NotNull(retrievedEntry); // Add more specific assertions as needed
        //    Assert.Equal(retrievedEntry.Content, entry.Content);
        //}

        //[Fact]
        //public void UpdateEntryInSection_UpdatesExistingEntry()
        //{
        //    // Arrange
        //    int docNUmber = 10;
        //    int sectionsPerDoc = 10;
        //    int entriesPerSection = 10;
        //    BasicEntryInSectionCRUDPersistenceService sut = new BasicEntryInSectionCRUDPersistenceService(docNUmber, sectionsPerDoc, entriesPerSection);    
        //    CreateEntryUseCase entryCreator = new CreateEntryUseCase(new BasicObjectIdentifierService(), new SimpleEntryCreatorCriteria(0, 100));
        //    Entry newEntry = entryCreator.CreateEmptyEntry(3);
        //    // Act
        //    sut.UpdateEntryinSection(4, 12, 4, newEntry);

        //    // Assert
        //    // Check if the entry was updated successfully
        //    var updatedEntry = sut.ReadEntryinSection(4, newEntry.Id);
        //    Assert.NotNull(updatedEntry); // Add more specific assertions as needed
        //}

        //[Fact]
        //public void DeleteEntryInSection_RemovesExistingEntry()
        //{
        //    // Arrange
        //    int docNUmber = 10;
        //    int sectionsPerDoc = 10;
        //    int entriesPerSection = 10;
        //    BasicEntryInSectionCRUDPersistenceService sut = new BasicEntryInSectionCRUDPersistenceService(docNUmber, sectionsPerDoc, entriesPerSection);
        //    // Act
        //    sut.DeleteEntryinSection(4, 12, 3);

        //    // Assert
        //    // Check if the entry was removed successfully
        //    var deletedEntry = sut.ReadEntryinSection(4, 3);
        //    Assert.Null(deletedEntry);
        //}
    }


}

