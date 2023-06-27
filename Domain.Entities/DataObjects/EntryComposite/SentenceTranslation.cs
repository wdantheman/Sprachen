using System;


namespace Domain.Entities.DataObjects.EntryComposite
{
    public class SentenceTranslation : TranslationComponent
    {
        private List<TranslationComponent> components;
        internal List<string> Translations;
        public SentenceTranslation(int id) : base(id)
        {
            components = new List<TranslationComponent>();
            Translations = new List<string>();
        }
        public override void AddTranslationComponent(TranslationComponent component)
        {
            components.Add(component);
        }
        public override void RemoveTranslationComponent(TranslationComponent component)
        {
            components.Remove(component);
        }
        public override void AddTranslations(List<string> translations)
        {
            Translations = translations;
        }
        public List<TranslationComponent> GetTranslationComponents() 
        {
            return components;
        }
        public List<string> GetTranslationText()
        {
            return Translations;
        }

    }
}
