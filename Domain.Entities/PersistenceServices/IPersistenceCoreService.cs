using Domain.Entities.DataObjects.EntryComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PersistenceServices
{
    internal interface IPersistenceCoreService
    {
        public void SaveEntry(TranslationComponent component);
    }
}
