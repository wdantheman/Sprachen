using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.UseCases.Tests.EntriesUseCasesTests.MockServices
{
    public class SimpleEntryConfigCriteria : IEntryConfigCriteria
    {
        public bool IsEntryValidInSection(Entry entry, SectionComposite section)
        {
            int entryId = entry.Id;
            // You can replace the condition with your specific logic.
            var keys = section.TranslationComponents.Keys.Where(entry => entry.Id == entryId);
            return !keys.Any() || entry.Content != "invalid content";
        }

        public bool CanEntryBeRemovedFromSection(Entry entry, SectionComposite section)
        {
            return entry.Content != "invalid content";
        }
    }

}
