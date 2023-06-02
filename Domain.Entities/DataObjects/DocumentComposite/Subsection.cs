using Domain.Entities.DataObjects.EntryComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    internal class Subsection : SectionComponent
    {
        internal List<TranslationComponent> entries;

        public Subsection(string title, int id, List<Language> lengauges): base(title, id, lengauges)
        {
            entries = new List<TranslationComponent>();
            targetLanguages = lengauges;
        }

        public override void AddSourceLanguage(Language language)
        {
            sourceLanguage = language;
        }

        public override void AddSubsectionComponent(SectionComponent component)
        {
            Console.WriteLine("Cannot add SectionComponent to a Subsection.");
        }

        public override void RemoveSubsectionComponent(int id)
        {
            Console.WriteLine("Cannot remove SectionComponent to a Subsection.");
        }
    }
}
