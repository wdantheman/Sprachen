﻿using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.PersistenceServices
{
    public interface IDocumentCRUDPersistenceService
    {
        public void CreateDocument(Document document);
        public Document ReadDocument(int id);
        public void UpdateDocument(int id, Document updatedDoc);
        public void DeleteDocument(int id);        
    }
}
