using Domain.Entities.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal interface IPersistenceCore
    {
        public void SaveEntry(TranslationComponent component);
    }
}
