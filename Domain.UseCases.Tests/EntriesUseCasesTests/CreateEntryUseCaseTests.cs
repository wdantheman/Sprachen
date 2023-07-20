using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities;
using Domain.UseCases.EntriesUseCases;
using Domain.UseCases.Exceptions;
using Moq;
using Domain.UseCases.Tests.EntriesUseCasesTests.MockServices;

namespace Domain.UseCases.Tests.EntriesUseCasesTests
{
    public class CreateEntryUseCaseTests
    {
        [Fact]
        public void CreateEmptyEntry_ValidInput_ReturnsEntryWithEmptyContent()
        {
            // Arrange
            int sourceDocumentId = 1;
            var objectIdCreatorMock = new Mock<IObjectIdentifierService>();
            objectIdCreatorMock.Setup(m => m.CreateSubObjectId(sourceDocumentId)).Returns(22);

            var criteriaMock = new Mock<IEntryCreatorCriteria>();

            var createEntryUseCase = new CreateEntryUseCase(objectIdCreatorMock.Object, criteriaMock.Object);

            // Act
            Entry result = createEntryUseCase.CreateEmptyEntry(sourceDocumentId);

            // Assert
            Assert.Equal(22, result.Id);
            Assert.Equal("", result.Content);
        }

        [Fact]
        public void CreateEntry_ValidContent_ReturnsEntryWithContent()
        {
            // Arrange
            int sourceDocumentId = 1;
            string content = "Valid content";
            var objectIdCreatorMock = new Mock<IObjectIdentifierService>();
            objectIdCreatorMock.Setup(m => m.CreateSubObjectId(sourceDocumentId)).Returns(22);

            var criteriaMock = new Mock<IEntryCreatorCriteria>();
            criteriaMock.Setup(m => m.IsContentValid(content)).Returns(true);

            var createEntryUseCase = new CreateEntryUseCase(objectIdCreatorMock.Object, criteriaMock.Object);

            // Act
            var result = createEntryUseCase.CreateEntry(sourceDocumentId, content);

            // Assert
            Assert.Equal(22, result.Id);
            Assert.Equal(content, result.Content);
        }

        [Fact]
        public void CreateEntry_InvalidContent_ThrowsException()
        {
            // Arrange
            int sourceDocumentId = 1;
            string content = "Invalid content";
            var objectIdCreatorMock = new Mock<IObjectIdentifierService>();
            objectIdCreatorMock.Setup(m => m.CreateSubObjectId(sourceDocumentId)).Returns(22);

            var criteriaMock = new Mock<IEntryCreatorCriteria>();
            criteriaMock.Setup(m => m.IsContentValid(content)).Returns(false);

            var createEntryUseCase = new CreateEntryUseCase(objectIdCreatorMock.Object, criteriaMock.Object);

            // Act & Assert
            Assert.Throws<CreateEntryUseCaseException>(() => createEntryUseCase.CreateEntry(sourceDocumentId, content));
        }

        [Fact]
        public void CreateEntry_NullContent_ThrowsException()
        {
            // Arrange
            int sourceDocumentId = 1;
            string content = null;
            var objectIdCreatorMock = new Mock<IObjectIdentifierService>();
            objectIdCreatorMock.Setup(m => m.CreateSubObjectId(sourceDocumentId)).Returns(22);

            var criteriaMock = new Mock<IEntryCreatorCriteria>();

            var createEntryUseCase = new CreateEntryUseCase(objectIdCreatorMock.Object, criteriaMock.Object);

            // Act & Assert
            Assert.Throws<CreateEntryUseCaseException>(() => createEntryUseCase.CreateEntry(sourceDocumentId, content));
        }
        [Fact]
        public void CreateEntry_ContentExceedsMaxLength_ThrowsException()
        {
            // Arrange
            int sourceDocumentId = 1;
            string content = new string('a', 1001); // Assuming the maximum content length is 1000 characters
            var objectIdCreatorMock = new Mock<IObjectIdentifierService>();
            objectIdCreatorMock.Setup(m => m.CreateSubObjectId(sourceDocumentId)).Returns(22);

            var criteriaMock = new SimpleEntryCreatorCriteria(1, 1000);
            var createEntryUseCase = new CreateEntryUseCase(objectIdCreatorMock.Object, criteriaMock);

            // Act & Assert
            Assert.Throws<CreateEntryUseCaseException>(() => createEntryUseCase.CreateEntry(sourceDocumentId, content));
        }
    }
}
