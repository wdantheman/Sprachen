using Domain.Entities.DataObjects;
using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.DocumentPersistence;

namespace Domain.UseCases.Tests.DocumentUseCasesTests
{
    internal class MockDocumentCRUDPersistenceService : IDocumentCRUDPersistenceService
    {
        public bool CreateDocumentCalled { get; private set; }
        public Document CreatedDocument { get; private set; }

        public bool ReadDocumentCalled { get; private set; }
        public int ReadDocumentId { get; private set; }
        public Document ReadDocumentResult { get; set; }

        public bool DeleteDocumentCalled { get; private set; }
        public int DeleteDocumentId { get; private set; }

        public bool UpdateDocumentCalled { get; private set; }
        public int UpdateDocumentId { get; private set; }
        public Document UpdatedDocument { get; private set; }

        public bool UpdateDocumentDescritionCalled { get; private set; }
        public int UpdateDocumentDescritionId { get; private set; }
        public string UpdatedDescription { get; private set; }

        public bool UpdateDocumentLanguagesComponentCalled { get; private set; }
        public LanguagesComponent UpdatedLanguagesComponent { get; private set; }

        public void CreateDocument(Document doc)
        {
            CreateDocumentCalled = true;
            CreatedDocument = doc;
        }

        public Document ReadDocument(int id)
        {
            ReadDocumentCalled = true;
            ReadDocumentId = id;
            return ReadDocumentResult;
        }

        public void DeleteDocument(int id)
        {
            DeleteDocumentCalled = true;
            DeleteDocumentId = id;
        }

        public void UpdateDocument(int id, Document documentUpdate)
        {
            UpdateDocumentCalled = true;
            UpdateDocumentId = id;
            UpdatedDocument = documentUpdate;
        }

        public void UpdateDocumentDescrition(int docId, string newDescription)
        {
            UpdateDocumentDescritionCalled = true;
            UpdateDocumentDescritionId = docId;
            UpdatedDescription = newDescription;
        }

        public void UpdateDocumentLanguagesComponent(LanguagesComponent languagesComponent)
        {
            UpdateDocumentLanguagesComponentCalled = true;
            UpdatedLanguagesComponent = languagesComponent;
        }
    }

    internal class MockObjectIdentifierService : IObjectIdentifierService
    {
        public int CreateObjectId()
        {
            return 1;
        }

        public int CreateSubObjectId(int objectId)
        {
            return objectId + 4;
        }
    }

    internal class MockDocumentFinderService : IDocumentFinderService
    {
        public bool GetDocumentByNameCalled { get; private set; }
        public string DocumentName { get; private set; }
        public Document GetDocumentByNameResult = new Document(5, "somenade", new List<SectionComponent>(), new LanguagesComponent(4));
        public LanguagesComponent LanguagesComponent1 = new LanguagesComponent(2);

        public LanguagesComponent GetDefaultLanguageComponentForDocument(int id)
        {
            return LanguagesComponent1;
        }
        public Document GetDocumentById(int id)
        {
            return GetDocumentByNameResult;
        }

        public Document GetDocumentByName(string name)
        {
            GetDocumentByNameCalled = true;
            DocumentName = name;
            GetDocumentByNameResult.SetName(name);
            return GetDocumentByNameResult;
        }
    }
}
