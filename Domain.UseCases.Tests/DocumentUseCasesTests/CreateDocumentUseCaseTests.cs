using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities;
using Domain.UseCases.DocumentUseCases;
using Domain.UseCases.Exceptions;
using Moq;

namespace Domain.UseCases.Tests.DocumentUseCasesTests
{
    public class CreateDocumentUseCaseTests
    {
        private readonly Mock<IObjectIdentifierService> identifierServiceMock;
        private readonly Mock<IDocumentCreatorCriteria> creatorCriteriaMock;
        private readonly CreateDocumentUseCase createDocumentUseCase;

        public CreateDocumentUseCaseTests()
        {
            identifierServiceMock = new Mock<IObjectIdentifierService>();
            creatorCriteriaMock = new Mock<IDocumentCreatorCriteria>();
            createDocumentUseCase = new CreateDocumentUseCase(identifierServiceMock.Object, creatorCriteriaMock.Object);
        }

        [Fact]
        public void CreateEmptyDocument_ShouldReturnDocumentWithDefaultName()
        {
            // Arrange
            int objectId = 1;
            int subObjectId = 2;
            string defaultName = "Empty Document";
            identifierServiceMock.Setup(service => service.CreateObjectId()).Returns(objectId);
            identifierServiceMock.Setup(service => service.CreateSubObjectId(objectId)).Returns(subObjectId);

            // Act
            Document document = createDocumentUseCase.CreateEmptyDocument();

            // Assert
            Assert.Equal(objectId, document.SystemId);
            Assert.Equal(defaultName, document.Name);
            Assert.Empty(document.GetSections());
            Assert.Equal(subObjectId, document.GetLanguageComponent().GetId());
        }

        [Theory]
        [InlineData("Valid Name")]
        [InlineData("Another Valid Name")]
        public void CreateDocumentWithName_ValidName_ShouldReturnDocument(string name)
        {
            // Arrange
            int objectId = 1;
            int subObjectId = 2;
            identifierServiceMock.Setup(service => service.CreateObjectId()).Returns(objectId);
            identifierServiceMock.Setup(service => service.CreateSubObjectId(objectId)).Returns(subObjectId);
            creatorCriteriaMock.Setup(criteria => criteria.IsDocumentNameValid(name)).Returns(true);

            // Act
            Document document = createDocumentUseCase.CreateDocumentWithName(name);

            // Assert
            Assert.Equal(objectId, document.SystemId);
            Assert.Equal(name, document.Name);
            Assert.Empty(document.GetSections());
            Assert.Equal(subObjectId, document.GetLanguageComponent().GetId());
        }

        [Theory]
        [InlineData("")]
        [InlineData("Invalid/Name")]
        public void CreateDocumentWithName_InvalidName_ShouldThrowException(string name)
        {
            // Arrange
            creatorCriteriaMock.Setup(criteria => criteria.IsDocumentNameValid(name)).Returns(false);

            // Act & Assert
            Assert.Throws<CreateDocumentUseCaseException>(() => createDocumentUseCase.CreateDocumentWithName(name));
        }

        [Fact]
        public void CreateDocumentWithSectionsAndName_ValidData_ShouldReturnDocument()
        {
            // Arrange
            int objectId = 1;
            int subObjectId = 2;
            string name = "Valid Name";
            List<SectionComponent> sections = new List<SectionComponent>();
            identifierServiceMock.Setup(service => service.CreateObjectId()).Returns(objectId);
            identifierServiceMock.Setup(service => service.CreateSubObjectId(objectId)).Returns(subObjectId);
            creatorCriteriaMock.Setup(criteria => criteria.IsDocumentNameValid(name)).Returns(true);
            creatorCriteriaMock.Setup(criteria => criteria.AreDocumentSectionsValid(sections)).Returns(true);

            // Act
            Document document = createDocumentUseCase.CreateDocumentWithSectionsAndName(name, sections);

            // Assert
            Assert.Equal(objectId, document.SystemId);
            Assert.Equal(name, document.Name);
            Assert.Equal(sections, document.GetSections());
            Assert.Equal(subObjectId, document.GetLanguageComponent().GetId());
        }

        [Theory]
        [InlineData("")]
        [InlineData("Invalid/Name")]
        public void CreateDocumentWithSectionsAndName_InvalidName_ShouldThrowException(string name)
        {
            // Arrange
            List<SectionComponent> sections = new List<SectionComponent>();
            creatorCriteriaMock.Setup(criteria => criteria.IsDocumentNameValid(name)).Returns(false);

            // Act & Assert
            Assert.Throws<CreateDocumentUseCaseException>(() => createDocumentUseCase.CreateDocumentWithSectionsAndName(name, sections));
        }

        [Fact]
        public void CreateDocumentWithSectionsAndName_InvalidSections_ShouldThrowException()
        {
            // Arrange
            string name = "Valid Name";
            List<SectionComponent> sections = new List<SectionComponent>();
            creatorCriteriaMock.Setup(criteria => criteria.IsDocumentNameValid(name)).Returns(true);
            creatorCriteriaMock.Setup(criteria => criteria.AreDocumentSectionsValid(sections)).Returns(false);

            // Act & Assert
            Assert.Throws<CreateDocumentUseCaseException>(() => createDocumentUseCase.CreateDocumentWithSectionsAndName(name, sections));
        }
    }
}
