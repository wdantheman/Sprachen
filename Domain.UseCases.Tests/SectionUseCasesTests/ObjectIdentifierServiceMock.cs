using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Tests.SectionUseCasesTests
{
    public class ObjectIdentifierServiceMock : IObjectIdentifierService
    {
        public int CreateObjectId()
        {
            throw new NotImplementedException();
        }

        public int CreateSubObjectId(int systemId)
        {
            // Basic implementation: Increment the systemId to create a subObjectId
            return systemId + 1;
        }
    }
}
