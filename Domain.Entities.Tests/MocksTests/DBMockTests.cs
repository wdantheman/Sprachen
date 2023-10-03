using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.Tests.MocksTests
{
    public class DBMockTests
    {
        [Fact]
        public void GetSections_ReturnsAllSections()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);

            // Act
            var sections = dbMock.GetSections();

            // Assert
            Assert.Equal(6, sections.Count);
        }
        [Fact]
        public void DictionaryLoadsCorrectly()
        {
            // Arrange
            int docNUmber = 10;
            int sectionsPerDoc = 10;
            int Entries = 10;
            // Act
            DBMock sut = new DBMock(docNUmber, sectionsPerDoc, Entries);
            // Assert
            Assert.Equal(docNUmber, sut.Documents.Count());
            Assert.Equal(sectionsPerDoc * docNUmber, sut.Sections.Count());
            Assert.Equal(sectionsPerDoc * docNUmber * Entries, sut.Entries.Count());
            Assert.Equal(sut.GetSectionComposite(1, 2).Title, sut.Sections[(1, 2)].Title);
            // el rango de las secciones es i+10, el de las Entradas debe ser de i + 20 
        }

        [Fact]
        public void GetSectionComposite_ValidIds_ReturnsSection()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 3, SectionsPerDoc: 3, entriesPerSection: 4);

            // Act
            SectionComposite section = dbMock.GetSectionComposite(1, 2);

            // Assert
            Assert.NotNull(section);
            Assert.Equal("section test2", section.Title);
        }

        [Fact]
        public void GetSectionComposite_InvalidIds_ReturnsNull()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);

            // Act
            var section = dbMock.GetSectionComposite(documentId: 5, sectionId: 2);

            // Assert
            Assert.Null(section);
        }

        [Fact]
        public void ReadEntryinSection_ValidIds_ReturnsEntry()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 10, entriesPerSection: 4);
            Entry temp = new Entry(12, "test");
            dbMock.CreateEntryinSection(1,2,temp);
            // Act
            var entry = dbMock.ReadEntryinSection(documentId: 1, entryId: 12);

            // Assert
            Assert.NotNull(entry);
            Assert.Equal(temp.Content, entry.Content);
        }

        [Fact]
        public void ReadEntryinSection_InvalidIds_ReturnsNull()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);

            // Act
            var entry = dbMock.ReadEntryinSection(documentId: 5, entryId: 2);

            // Assert
            Assert.Null(entry);
        }

        [Fact]
        public void CreateEntryinSection_ValidData_EntryAdded()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);
            var newEntry = new Entry(999, "new entry content");

            // Act
            dbMock.CreateEntryinSection(documentId: 0, sectionId: 1, newEntry);
            var entry = dbMock.ReadEntryinSection(documentId: 0, entryId: 999);

            // Assert
            Assert.Equal(newEntry, entry);
        }

        [Fact]
        public void CreateEntryinSection_InvalidSection_ThrowsException()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);
            var newEntry = new Entry(999, "new entry content");

            // Assert
            Assert.Throws<Exception>(() =>
            {
                // Act
                dbMock.CreateEntryinSection(documentId: 0, sectionId: 10, newEntry);
            });
        }

        [Fact]
        public void UpdateEntryinSection_ValidData_EntryUpdated()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);
            var newEntry = new Entry(999, "updated entry content");

            // Act
            dbMock.UpdateEntryinSection(documentId: 0, sectionId: 1, oldEntryId: 2, newEntry);
            var entry = dbMock.ReadEntryinSection(documentId: 0, entryId: 999);

            // Assert
            Assert.Equal(newEntry, entry);
        }

        [Fact]
        public void UpdateEntryinSection_InvalidSection_ThrowsException()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);
            var newEntry = new Entry(999, "updated entry content");

            // Assert
            Assert.Throws<Exception>(() =>
            {
                // Act
                dbMock.UpdateEntryinSection(documentId: 0, sectionId: 10, oldEntryId: 2, newEntry);
            });
        }

        [Fact]
        public void UpdateEntryinSection_InvalidEntry_ThrowsException()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);
            var newEntry = new Entry(999, "updated entry content");

            // Assert
            Assert.Throws<Exception>(() =>
            {
                // Act
                dbMock.UpdateEntryinSection(documentId: 0, sectionId: 1, oldEntryId: 10, newEntry);
            });
        }

        [Fact]
        public void DeleteEntryinSection_ValidData_EntryDeleted()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);

            // Act
            dbMock.DeleteEntryinSection(documentId: 0, sectionId: 1, entryId: 2);
            var entry = dbMock.ReadEntryinSection(documentId: 0, entryId: 2);

            // Assert
            Assert.Null(entry);
        }

        [Fact]
        public void DeleteEntryinSection_InvalidSection_ThrowsException()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);

            // Assert
            Assert.Throws<Exception>(() =>
            {
                // Act
                dbMock.DeleteEntryinSection(documentId: 0, sectionId: 10, entryId: 2);
            });
        }

        [Fact]
        public void DeleteEntryinSection_InvalidEntry_ThrowsException()
        {
            // Arrange
            var dbMock = new DBMock(docNumber: 2, SectionsPerDoc: 3, entriesPerSection: 4);

            // Assert
            Assert.Throws<Exception>(() =>
            {
                // Act
                dbMock.DeleteEntryinSection(documentId: 0, sectionId: 1, entryId: 10);
            });
        }
    }
}
