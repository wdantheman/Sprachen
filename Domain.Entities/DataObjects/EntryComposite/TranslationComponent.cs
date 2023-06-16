

namespace Domain.Entities.DataObjects.EntryComposite
{
    public abstract class TranslationComponent
    {
        internal int id;
        public TranslationComponent(int ID) 
        {
            id = ID;
        }
        public abstract void AddComponent(TranslationComponent component);
        public abstract void RemoveComponent(TranslationComponent component);
        public abstract void AddTranslations(List<string> translations);

    }
}
