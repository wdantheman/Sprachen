using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.PersistenceServices.EntryPersistenceServices;
using Domain.Entities;
using Domain.UseCases.EntriesUseCases;
using Moq;
using Domain.Entities.DataObjects;
using Domain.UseCases.Tests.EntriesUseCasesTests.MockServices;

namespace Domain.UseCases.Tests.EntriesUseCasesTests
{
    public class PersistenceEntryInSectionCRUDUseCaseTests
    {
        [Fact]
        public void CreateEmptyEntryInSection_ShouldResetSection_AddEmptyEntryAndCreateEntry()
        {
            // Arrange
            var startSection = new SectionComposite("test Section main", 6, new LanguagesComponent(3), 12);
            var persistenceServiceMock = new BasicSectionEntryInSectionCRUDPersistenceService(10, 10);
            var crudUseCaseMock = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), startSection, new SimpleEntryCreatorCriteria(0, 100));

            var useCase = new PersistenceEntryInSectionCRUDUseCase(persistenceServiceMock, crudUseCaseMock);
            var docId = 1;
            var sectionId = 2;

            // Act
            int docCount = persistenceServiceMock.DocumentSections.Count();
            useCase.CreateEmptyEntryInSection(docId, sectionId);
            int newEntryId = useCase.ReadEntryInSectionByContent(docId, sectionId, " ").Id;

            // Assert
            Assert.True(docCount < persistenceServiceMock.DocumentSections.Count());
            Assert.Equal(" ", persistenceServiceMock.ReadEntryinSection(docId, newEntryId).Content);
        }

        [Fact]
        public void CreateEntryInSectionByContent_ShouldResetSection_AddNewEntryAndCreateEntry()
        {
            // Arrange
            var startSection = new SectionComposite("test Section main", 6, new LanguagesComponent(3), 12);
            var persistenceServiceMock = new BasicSectionEntryInSectionCRUDPersistenceService(12, 12);
            var crudUseCaseMock = new EntryInSectionCRUDUseCase(new BasicObjectIdentifierService(), new SimpleEntryConfigCriteria(), startSection, new SimpleEntryCreatorCriteria(0, 100));

            var useCase = new PersistenceEntryInSectionCRUDUseCase(persistenceServiceMock, crudUseCaseMock);

            var docId = 1;
            var sectionId = 2;
            var content = "Sample content, m8";
            int docCount = persistenceServiceMock.DocumentSections.Count();
            // Act
            useCase.CreateEntryInSectionByContent(docId, sectionId, content);
            int newEntryId = useCase.ReadEntryInSectionByContent(docId, sectionId, content).Id;

            // Assert
            Assert.True(docCount < persistenceServiceMock.DocumentSections.Count());
            Assert.Equal(content, persistenceServiceMock.ReadEntryinSection(docId, newEntryId).Content);
        }
    }
}
