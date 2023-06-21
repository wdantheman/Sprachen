using Domain.Entities.DataObjects.EntryComposite;


namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class SectionComposite : SectionComponent
    {
        internal List<SectionComponent> Subsections;
        internal Dictionary<string, EntryTranslationBlock> translationComponents;
        public SectionComposite(string title, int id, ILanguagesComponent lenguagesComponent) : base(title, id, lenguagesComponent)
        {
            Subsections = new List<SectionComponent>();
            translationComponents = new Dictionary<string, EntryTranslationBlock>();
        }                    
        public override void AddSubsectionComponent(SectionComponent component)
        {
            Subsections.Add(component);
        }
        public override void RemoveSubsectionComponent(int id)
        {
            SectionComponent? itemToRemove = Subsections.FirstOrDefault(item => item.DocSectionId == id);
            if (itemToRemove != null)
            {
                Subsections.Remove(itemToRemove);
            }
        }
        public override Dictionary<string, EntryTranslationBlock> GetEntries()
        {
            return translationComponents;
        }
        public override void SetSourceLanguage(Language language)
        {
            LanguagesComponent.SetSourceLanguage(language);
        }
        public void AddTargetLanguage(Language language)
        {
            LanguagesComponent.AddTargetLanguage(language);
        }
        public void RemoveTargetLanguage(Language language)
        {
            LanguagesComponent.AddTargetLanguage(language);
        }
        public override void UpdateEntries(Dictionary<string, EntryTranslationBlock> entries)
        {
            translationComponents = entries;
        }
        public List<SectionComponent> GetSubsections() 
        {
            return Subsections;
        }
        public override void SetTargetLanguages(List<Language> languages)
        {
            LanguagesComponent.SetTargetLanguages(languages);
        }
        public Language GetSourceLanguage()
        {
            return LanguagesComponent.GetSourceLanguage();
        }
        public List<Language> GetTargetLanguages()
        {
            return LanguagesComponent.GetTargetLanguages();
        }
        public override int GetComponetId()
        {
            return DocSectionId;
        }
    }
}
