using Domain.Entities.DataObjects.EntryComposite;

namespace Domain.UseCases.Tests.EntriesUseCasesTests.MockServices
{
    public class SimpleEntryCreatorCriteria : IEntryCreatorCriteria
    {
        private int minContentLength;
        private int maxContentLength;

        public SimpleEntryCreatorCriteria(int minContentLength, int maxContentLength)
        {
            this.minContentLength = minContentLength;
            this.maxContentLength = maxContentLength;
        }

        public bool IsContentValid(string content)
        {
            // || content.Trim().Length == 0
            if (content == null )
            {
                return false;
            }

            int contentLength = content.Trim().Length;
            return contentLength >= minContentLength && contentLength <= maxContentLength;
        }
    }
}
