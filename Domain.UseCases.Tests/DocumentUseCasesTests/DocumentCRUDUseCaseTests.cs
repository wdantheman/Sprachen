﻿using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects;
using Domain.UseCases.DocumentUseCases;

namespace Domain.UseCases.Tests.DocumentUseCasesTests
{
    public class DocumentCRUDUseCaseTests
    {
        [Fact]
        public void CreateEmptyDocument_Returns_New_Empty_Document()
        {
            // Arrange
            var persistenceService = new MockDocumentCRUDPersistenceService();
            var identifierService = new MockObjectIdentifierService();
            var useCase = new DocumentCRUDUseCase(persistenceService, identifierService);

            // Act
            var document = useCase.CreateEmptyDocument();

            // Assert
            Assert.NotNull(document);
            Assert.Equal("Empty Document", document.Name);
            Assert.Empty(document.GetSections());
        }

        [Fact]
        public void CreateDocumentWithName_Returns_New_Document_With_Given_Name()
        {
            // Arrange
            var persistenceService = new MockDocumentCRUDPersistenceService();
            var identifierService = new MockObjectIdentifierService();
            var useCase = new DocumentCRUDUseCase(persistenceService, identifierService);
            var name = "My Document";

            // Act
            var document = useCase.CreateDocumentWithName(name);

            // Assert
            Assert.NotNull(document);
            Assert.Equal(name, document.Name);
            Assert.Empty(document.GetSections());
        }

        [Fact]
        public void CreateDocumentWithSectionsAndName_Returns_New_Document_With_Given_Name_And_Sections()
        {
            // Arrange
            var persistenceService = new MockDocumentCRUDPersistenceService();
            var identifierService = new MockObjectIdentifierService();
            var useCase = new DocumentCRUDUseCase(persistenceService, identifierService);
            var name = "My Document";
            var sections = new List<SectionComponent> { new SectionComposite("Section 1", 1, new LanguagesComponent(3)) };

            // Act
            var document = useCase.CreateDocumentWithSectionsAndName(name, sections);

            // Assert
            Assert.NotNull(document);
            Assert.Equal(name, document.Name);
            Assert.Equal(sections, document.GetSections());
        }

        [Fact]
        public void CreateDocumentInDB_Calls_PersistenceService_CreateDocument()
        {
            // Arrange
            var persistenceService = new MockDocumentCRUDPersistenceService();
            var identifierService = new MockObjectIdentifierService();
            var useCase = new DocumentCRUDUseCase(persistenceService, identifierService);
            var document = new Document(1, "My Document", new List<SectionComponent>());

            // Act
            useCase.CreateDocumentInDB(document);

            // Assert
            Assert.True(persistenceService.CreateDocumentCalled);
            Assert.Equal(document, persistenceService.CreatedDocument);
        }

        [Fact]
        public void ReadDocumentById_Calls_PersistenceService_ReadDocument()
        {
            // Arrange
            var persistenceService = new MockDocumentCRUDPersistenceService();
            var identifierService = new MockObjectIdentifierService();
            var useCase = new DocumentCRUDUseCase(persistenceService, identifierService);
            var documentId = 1;

            // Act
            var document = useCase.ReadDocumentById(documentId);

            // Assert
            Assert.True(persistenceService.ReadDocumentCalled);
            Assert.Equal(documentId, persistenceService.ReadDocumentId);
            Assert.Equal(persistenceService.ReadDocumentResult, document);
        }

        [Fact]
        public void ReadDocumentByName_Calls_DocumentFinderService_GetDocumentByName()
        {
            // Arrange
            var persistenceService = new MockDocumentCRUDPersistenceService();
            var identifierService = new MockObjectIdentifierService();
            var documentFinderService = new MockDocumentFinderService();
            var useCase = new DocumentCRUDUseCase(persistenceService, identifierService);
            var name = "My Document";

            // Act
            var document = useCase.ReadDocumentByName(documentFinderService, name);

            // Assert
            Assert.True(documentFinderService.GetDocumentByNameCalled);
            Assert.Equal(name, documentFinderService.DocumentName);
            Assert.Equal(documentFinderService.GetDocumentByNameResult, document);
        }

        [Fact]
        public void DeleteDocument_Calls_PersistenceService_DeleteDocument()
        {
            // Arrange
            var persistenceService = new MockDocumentCRUDPersistenceService();
            var identifierService = new MockObjectIdentifierService();
            var useCase = new DocumentCRUDUseCase(persistenceService, identifierService);
            var documentId = 1;

            // Act
            useCase.DeleteDocumentInDB(documentId);

            // Assert
            Assert.True(persistenceService.DeleteDocumentCalled);
            Assert.Equal(documentId, persistenceService.DeleteDocumentId);
        }

        [Fact]
        public void UpdateDocument_Calls_PersistenceService_UpdateDocument()
        {
            // Arrange
            var persistenceService = new MockDocumentCRUDPersistenceService();
            var identifierService = new MockObjectIdentifierService();
            var useCase = new DocumentCRUDUseCase(persistenceService, identifierService);
            var documentId = 1;
            var documentUpdate = new Document(1, "Updated Document", new List<SectionComponent>());

            // Act
            useCase.UpdateDocumentInDB(documentId, documentUpdate);

            // Assert
            Assert.True(persistenceService.UpdateDocumentCalled);
            Assert.Equal(documentId, persistenceService.UpdateDocumentId);
            Assert.Equal(documentUpdate, persistenceService.UpdatedDocument);
        }


    }
}