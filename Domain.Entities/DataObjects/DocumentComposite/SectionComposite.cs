using Domain.Entities.DataObjects.EntryComposite;


namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class SectionComposite : SectionComponent
    {
        internal List<SectionComponent> Subsections;
        internal Dictionary<string, EntryTranslationBlock> translationComponents;
        public SectionComposite(string title, int id, List<Language> lenguages) : base(title, id, lenguages)
        {
            Subsections= new List<SectionComponent>();
            translationComponents = new Dictionary<string, EntryTranslationBlock>();
        }

        public override void AddSubsectionComponent(SectionComponent component)
        {
            Subsections.Add(component);
        }

        public override void AddTargetLanguage(Language language)
        {
            targetLanguages.Add(language);
        }

        public override Dictionary<string, EntryTranslationBlock> getEntries()
        {
            return translationComponents;
        }

        public override void RemoveSubsectionComponent(int id)
        {
            SectionComponent itemToRemove = Subsections.FirstOrDefault(item => item.docId == id);
            if (itemToRemove != null)
            {
                Subsections.Remove(itemToRemove);
            }

        }

        public override void RemoveTargetLanguage(Language language)
        {
            targetLanguages.Remove(language);
        }

        public override void SetSourceLanguage(Language language)
        {
            sourceLanguage= language;
        }

        public override void UpdateEntries(Dictionary<string, EntryTranslationBlock> entries)
        {
            translationComponents = entries;
        }
    }
}
