using Domain.Entities.DataObjects.EntryComposite;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public abstract class SectionComponent
    {
        public string title { get; set; }
        internal int DocSectionId { get; private set; }
        internal List<Language> TargetLanguages { get; private set; }
        internal Language sourceLanguage { get; private set; }
        internal Dictionary<string, EntryTranslationBlock> entries { get; private set; }


        public SectionComponent(string title, int id, List<Language> languages)
        {
            this.title = title;
            DocSectionId = id;
            TargetLanguages = languages;
        }
        public abstract void AddSubsectionComponent(SectionComponent component);
        public abstract void RemoveSubsectionComponent(int id);
        public abstract void SetSourceLanguage(Language language);
        public abstract void SetTargetLanguages(List<Language> languages);
        public abstract Dictionary<string, EntryTranslationBlock> GetEntries();
        public abstract void UpdateEntries(Dictionary<string, EntryTranslationBlock> entries);
        public abstract int GetComponetId();

    }
}
