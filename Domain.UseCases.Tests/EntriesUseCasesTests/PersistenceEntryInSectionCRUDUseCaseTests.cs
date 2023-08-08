using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.PersistenceServices.EntryPersistenceServices;
using Domain.Entities;
using Domain.UseCases.EntriesUseCases;
using Moq;
using Domain.Entities.DataObjects;

namespace Domain.UseCases.Tests.EntriesUseCasesTests
{
    public class PersistenceEntryInSectionCRUDUseCaseTests
    {
        [Fact]
        public void CreateEmptyEntryInSection_ShouldResetSection_AddEmptyEntryAndCreateEntry()
        {
            // Arrange
            var idCreatorMock = new Mock<IObjectIdentifierService>();
            var persistenceServiceMock = new Mock<ISectionEntryInSectionCRUDPersistenceService>();
            var crudUseCaseMock = new Mock<IEntryInSectionCRUDUseCase>();

            var useCase = new PersistenceEntryInSectionCRUDUseCase(idCreatorMock.Object, persistenceServiceMock.Object, crudUseCaseMock.Object);

            var docId = 1;
            var sectionId = 2;

            var section = new SectionComposite("test Section", 12, new LanguagesComponent(3), 12); // You need to create a mock or instance of SectionComposite
            crudUseCaseMock.Setup(uc => uc.ResetSection(section));
            crudUseCaseMock.Setup(uc => uc.AddEmptyEntryInSection());
            crudUseCaseMock.Setup(uc => uc.GetEntryByContent(" ")).Returns(new Entry(15, "SOme content")); // You need to create a mock or instance of Entry

            // Act
            useCase.CreateEmptyEntryInSection(docId, sectionId);

            // Assert
            crudUseCaseMock.Verify(uc => uc.ResetSection(section), Times.Once);
            crudUseCaseMock.Verify(uc => uc.AddEmptyEntryInSection(), Times.Once);
            crudUseCaseMock.Verify(uc => uc.GetEntryByContent(" "), Times.Once);
            persistenceServiceMock.Verify(ps => ps.CreateEntryinSection(docId, sectionId, It.IsAny<Entry>()), Times.Once);
        }

        [Fact]
        public void CreateEntryInSectionByContent_ShouldResetSection_AddNewEntryAndCreateEntry()
        {
            // Arrange
            var idCreatorMock = new Mock<IObjectIdentifierService>();
            var persistenceServiceMock = new Mock<ISectionEntryInSectionCRUDPersistenceService>();
            var crudUseCaseMock = new Mock<IEntryInSectionCRUDUseCase>();

            var useCase = new PersistenceEntryInSectionCRUDUseCase(idCreatorMock.Object, persistenceServiceMock.Object, crudUseCaseMock.Object);

            var docId = 1;
            var sectionId = 2;
            var content = "Sample content";

            var section = new SectionComposite("test Section", 12, new LanguagesComponent(3), 12); // You need to create a mock or instance of SectionComposite
            crudUseCaseMock.Setup(uc => uc.ResetSection(section));
            crudUseCaseMock.Setup(uc => uc.AddNewEntryInSection(content));
            crudUseCaseMock.Setup(uc => uc.GetEntryByContent(content)).Returns(new Entry(15, "SOme content")); // You need to create a mock or instance of Entry

            // Act
            useCase.CreateEntryInSectionByContent(docId, sectionId, content);

            // Assert
            crudUseCaseMock.Verify(uc => uc.ResetSection(section), Times.Once);
            crudUseCaseMock.Verify(uc => uc.AddNewEntryInSection(content), Times.Once);
            crudUseCaseMock.Verify(uc => uc.GetEntryByContent(content), Times.Once);
            persistenceServiceMock.Verify(ps => ps.CreateEntryinSection(docId, sectionId, It.IsAny<Entry>()), Times.Once);
        }
    }
}
