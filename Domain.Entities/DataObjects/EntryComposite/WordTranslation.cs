using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects.EntryComposite
{
    public class WordTranslation : TranslationComponent
    {
        internal List<string>? Translations;
        internal List<string>? TargetDefinitions;
        internal List<string>? TargetExamples;
        public WordTranslation(int id) : base(id)
        {
            
        }
        public override void AddTranslationComponent(TranslationComponent component)
        {
            throw new WordTranslationException("Cannot add TranslationComponent from a Word.");
        }
        public override void RemoveTranslationComponent(TranslationComponent component)
        {
            throw new WordTranslationException("Cannot remove TranslationComponent from a Word.");
        }
        public void AddExamples(List<string> examples)
        {
            TargetExamples = examples;
        }
        public List<string> getExamples() 
        {
            return TargetExamples;
        }

        public void AddtargetDefinitions(List<string> targetDefinitions)
        {
            TargetDefinitions = targetDefinitions;
        }

        public List<string> getDefinitions()
        {
            return TargetDefinitions;
        }
        public List<string> getTranslations()
        {
            return Translations;
        }
        public override void AddTranslations(List<string> translations) 
        {
            Translations = translations;
        }
    }
}
