using Domain.Entities.DataObjects.EntryComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Tests.EntriesUseCasesTests
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
            if (content == null || content.Trim().Length == 0)
            {
                return false;
            }

            int contentLength = content.Trim().Length;
            return contentLength >= minContentLength && contentLength <= maxContentLength;
        }
    }
}
