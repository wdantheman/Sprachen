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
            int sectionsPerDoc = 10;
            // Act
            BasicSectionEntryInSectionCRUDPersistenceService sut = new BasicSectionEntryInSectionCRUDPersistenceService(docNUmber, sectionsPerDoc);
            // Assert
            Assert.Equal(docNUmber, sut.Documents.Count());
            Assert.Equal(sectionsPerDoc * docNUmber, sut.Sections.Count());
            Assert.Equal(sut.GetSectionComposite(1, 12).Title, sut.Sections[(1,12)].Title);
            // el rango de las secciones es i+10 
        }
        // so, I need to add the apropiate test suit here for that, but, I want to do it with the fucking code generator first.

    }
}
