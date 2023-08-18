using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Tests.EntriesUseCasesTests.MockServices
{
    public class BasicSectionEntryInSectionCRUDPersistenceServiceTests
    {
        [Fact]
        public void DictionaryLoadsCorrectly() 
        {
            // Arrange
            int docNUmber = 10;
            int sectionsPerDoc =10;
            // Act
            BasicSectionEntryInSectionCRUDPersistenceService sut = new BasicSectionEntryInSectionCRUDPersistenceService(docNUmber, sectionsPerDoc);


            // Assert
            Assert.Equal(docNUmber, sut.Documents.Count());
            Assert.Equal(sectionsPerDoc * docNUmber, sut.Sections.Count());

        }
    }
}
