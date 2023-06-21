using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class Subsection : SectionComponent
    {
        internal Dictionary<string, EntryTranslationBlock> translationComponents;

        public Subsection(string title, int id, ILanguagesComponent languagesComponent): base(title, id, languagesComponent)
        {
            translationComponents = new Dictionary<string, EntryTranslationBlock>();
        }
        public override void AddSubsectionComponent(SectionComponent component)
        {
            throw new SubsectionException("Cannot Add SectionComponent to a Subsection.");
        }
        public override void RemoveSubsectionComponent(int id)
        {
            throw new SubsectionException("Cannot Remove SectionComponent to a Subsection.");
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
        public Language GetSourceLanguage() 
        {
            return LanguagesComponent.GetSourceLanguage();
        }
        public List<Language> GetTargetLanguages() 
        {
            return LanguagesComponent.GetTargetLanguages();
        }
        public override void SetTargetLanguages(List<Language> languages)
        {
            LanguagesComponent.SetTargetLanguages(languages);
        }
        public override void UpdateEntries(Dictionary<string, EntryTranslationBlock> entries)
        {
            translationComponents = entries;
        }

        public override int GetComponetId()
        {
            return DocSectionId;
        }
    }
}
