using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects.EntryComposite
{
    public class WordTranslation : TranslationComponent
    {
        internal List<string> translations;
        internal List<string> targetDefinitions;
        internal List<string> targetExamples;
        internal string text;
        public WordTranslation(int id, string entryText) : base(id)
        {
            translations = new List<string>();
            targetDefinitions = new List<string>();
            targetExamples = new List<string>();
            text = entryText;
        }
        public override void AddComponent(TranslationComponent component)
        {
            throw new WordTranslationException("Cannot add TranslationComponent from a Word.");
        }
        public override void RemoveComponent(TranslationComponent component)
        {
            throw new WordTranslationException("Cannot remove TranslationComponent from a Word.");
        }

        public void AddExamples(List<string> examples)
        {
            targetExamples = examples;
        }

        public void AddtargetDefinitions(ITranslationService translationService)
        {
            targetDefinitions = translationService.GetMeaningsInTargetLanguage(text);
        }

        public string getText()
        {
            return text;
        }

        public List<string> getExamples() 
        {
            return targetExamples;
        }

        public List<string> getDefinitions()
        {
            return targetDefinitions;
        }
        public List<string> getTranslations()
        {
            return translations;
        }

        public override void Translate(ITranslationService translationService)
        {
            translations = translationService.GetTranslations(text);
        }
    }
}
