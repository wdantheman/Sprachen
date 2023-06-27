

namespace Domain.Entities.DataObjects.EntryComposite
{
    public abstract class TranslationComponent
    {
        internal int Id;
        public TranslationComponent(int id) 
        {
            Id = id;
        }
        public abstract void AddTranslationComponent(TranslationComponent component);
        public abstract void RemoveTranslationComponent(TranslationComponent component);
        public abstract void AddTranslations(List<string> translations);

    }
}
