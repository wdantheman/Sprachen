
namespace Domain.Entities.DataObjects
{
    internal class Word : TranslationComponent
    {
        internal List<string> translations;
        internal List<string> sourceDeninitions;
        public Word(string text) : base(text)
        {
            translations = new List<string>();
            sourceDeninitions = new List<string>();
        }
        public override void Add(TranslationComponent component)
        {
            Console.WriteLine("Cannot add TranslationComponent to a Word.");
        }

        public override string getText()
        {
            return text;
        }

        public override void Remove(TranslationComponent component)
        {
            Console.WriteLine("Cannot remove TranslationComponent from a Word.");
        }

    }
}
