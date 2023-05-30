namespace Domain.Entities.DataObjects.EntryComposite
{
    public class Word : TranslationComponent
    {
        internal List<string> translations;
        internal List<string> sourceDefinitions;
        internal List<string> targetExamples;
        public Word(string text) : base(text)
        {
            translations = new List<string>();
            sourceDefinitions = new List<string>();
            targetExamples = new List<string>();
        }
        public override void AddComponent(TranslationComponent component)
        {
            Console.WriteLine("Cannot add TranslationComponent to a Word.");
        }
        public override void RemoveComponent(TranslationComponent component)
        {
            Console.WriteLine("Cannot remove TranslationComponent from a Word.");
        }

        public void AddExamples(List<string> examples)
        {
            targetExamples = examples;
        }

        public override void AddTranslations(List<string> ExternalTranslations)
        {
            translations = ExternalTranslations;
        }

        public void AddSourceDefinitions(List<string> definitions)
        {
            sourceDefinitions = definitions;
        }

        public override string getText()
        {
            return text;
        }

        public List<string> getExamples() 
        {
            return targetExamples;
        }

        public List<string> getDefinitions()
        {
            return sourceDefinitions;
        }
        public List<string> getTranslations()
        {
            return translations;
        }

    }
}
