using Domain.Entities.DataObjects.DocumentComposite;

namespace Domain.Entities.PersistenceServices
{
    public interface IDocumentFinderService
    {
        public Document GetDocumentByName(string name);
        public Document GetDocumentById(int id);
    }
}