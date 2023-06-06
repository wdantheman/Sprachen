using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class Subsection : SectionComponent
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
            throw new SubsectionException("Cannot Add SectionComponent to a Subsection.");
        }
        public override void RemoveSubsectionComponent(int id)
        {
            throw new SubsectionException("Cannot Remove SectionComponent to a Subsection.");
        }

        public override void AddTargetLanguage(Language language)
        {
            targetLanguages.Add(language);
        }

        public override void RemoveTargetLanguage(Language language)
        {
            targetLanguages.Remove(language);
        }

        public override Dictionary<string, EntryTranslationBlock> GetEntries()
        {
            return translationComponents;
        }

        public override void UpdateEntries(Dictionary<string, EntryTranslationBlock> entries)
        {
            translationComponents= entries;
        }
        public override Language GetSourceLanguage() 
        {
            return sourceLanguage;
        }
        public override List<Language> GetTargetLanguages() 
        {
            return targetLanguages;
        }
    }
}
