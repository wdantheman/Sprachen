using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public interface IDocumentConfigCriteria
    {
        public bool IsNameValid(string newName);
        public bool IsDescriptionValid(string description);
        public bool IsDocumentDeleatable(int docId);
    }
}
