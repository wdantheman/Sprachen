using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IObjectIdentifierService
    {
        public int CreateId();
        public int CreateSubObjectId(int objectId);
    }
}
