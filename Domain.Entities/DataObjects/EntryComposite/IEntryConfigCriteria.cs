using Domain.Entities.DataObjects.DocumentComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.EntryComposite
{
    public interface IEntryConfigCriteria
    {
        public bool IsEntryValidInSection(Entry entry, SectionComposite section);
        public bool CanEntryBeRemovedFromSection(Entry entry, SectionComposite section);
    }
}
