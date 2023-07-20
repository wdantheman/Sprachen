using Domain.Entities;

namespace Domain.UseCases.Tests.EntriesUseCasesTests.MockServices
{
    public class BasicObjectIdentifierService : IObjectIdentifierService
    {
        private int currentObjectId = 0;
        private int currentSubObjectId = 0;

        public int CreateObjectId()
        {
            // Increment the current object ID and return it
            return ++currentObjectId;
        }

        public int CreateSubObjectId(int objectId)
        {
            // Increment the current sub-object ID and return it, combined with the provided object ID
            int subObjectId = ++currentSubObjectId;
            return CombineObjectIds(objectId, subObjectId);
        }

        private int CombineObjectIds(int objectId, int subObjectId)
        {
            // Combine the object ID and sub-object ID into a single unique identifier
            // For simplicity, we'll use the sub-object ID as the least significant digits of the combined ID.
            // You can modify this method to create a more complex combination based on your specific needs.
            return objectId * 1000 + subObjectId;
        }
    }
}
