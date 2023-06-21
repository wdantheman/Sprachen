using Domain.Entities.DataObjects.EntryComposite;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public abstract class SectionComponent
    {
        public string title { get; set; }
        internal int DocSectionId { get; private set; }
        internal ILanguagesComponent LanguagesComponent { get; private set; }
        internal Dictionary<string, EntryTranslationBlock>? entries { get; private set; }


        public SectionComponent(string title, int id, ILanguagesComponent languagesComponent)
        {
            this.title = title;
            DocSectionId = id;
            LanguagesComponent = languagesComponent;
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
