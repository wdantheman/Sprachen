
namespace Domain.Entities
{
    public interface IObjectIdentifierService
    {
        public int CreateObjectId();
        public int CreateSubObjectId(int objectId);
    }
}
