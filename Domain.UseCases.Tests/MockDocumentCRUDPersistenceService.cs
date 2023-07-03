using Domain.Entities.DataObjects;
using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.PersistenceServices.DocumentPersistence;

namespace Domain.UseCases.Tests
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
            throw new NotImplementedException();
        }
    }

    internal class MockDocumentFinderService : IDocumentFinderService
    {
        public bool GetDocumentByNameCalled { get; private set; }
        public string DocumentName { get; private set; }
        public Document GetDocumentByNameResult { get; set; }

        public LanguagesComponent GetDefaultLanguageComponentForDocument(int id)
        {
            throw new NotImplementedException();
        }

        public Document GetDocumentById(int id)
        {
            throw new NotImplementedException();
        }

        public Document GetDocumentByName(string name)
        {
            GetDocumentByNameCalled = true;
            DocumentName = name;
            return GetDocumentByNameResult;
        }
    }
}
