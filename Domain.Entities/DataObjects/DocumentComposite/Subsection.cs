using Domain.Entities.DataObjects.EntryComposite;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    internal class Subsection : SectionComponent
    {
        internal Dictionary<string, EntryTranslationBlock> translationComponents;

        public Subsection(string title, int id, List<Language> lengauges): base(title, id, lengauges)
        {
            translationComponents = new Dictionary<string, EntryTranslationBlock>();
            targetLanguages = lengauges;
        }

        public override void SetSourceLanguage(Language language)
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

        public override void AddTargetLanguage(Language language)
        {
            targetLanguages.Add(language);
        }

        public override void RemoveTargetLanguage(Language language)
        {
            targetLanguages.Remove(language);
        }

        public override Dictionary<string, EntryTranslationBlock> getEntries()
        {
            return translationComponents;
        }

        public override void UpdateEntries(Dictionary<string, EntryTranslationBlock> entries)
        {
            translationComponents= entries;
        }
    }
}
