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
        internal Dictionary<string, List<TranslationComponent>> translationComponents;

        public Subsection(string title, int id, List<Language> lengauges): base(title, id, lengauges)
        {
            translationComponents = new Dictionary<string, List<TranslationComponent>>();
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

        public override void AddTargetLanguage(Language language)
        {
            targetLanguages.Add(language);
        }

        public override void RemoveSubsectionComponent(int id)
        {
            Console.WriteLine("Cannot remove SectionComponent to a Subsection.");
        }

        public override void RemoveTargetLanguage(Language language)
        {
            targetLanguages.Remove(language);
        }
    }
}
