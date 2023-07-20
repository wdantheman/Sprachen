using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.EntryComposite
{
    public interface IEntryCreatorCriteria
    {
        public bool IsContentValid(string content);
    }
}
