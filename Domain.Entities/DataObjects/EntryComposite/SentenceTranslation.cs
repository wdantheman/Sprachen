using System;


namespace Domain.Entities.DataObjects.EntryComposite
{
    public class SentenceTranslation : TranslationComponent
    {
        private List<TranslationComponent> components;
        internal string text { get; set; }
        internal string translation;
        public SentenceTranslation(int id, string entryText) : base(id)
        {
            components = new List<TranslationComponent>();
            translation = new string("");
            text = entryText;
        }
        public override void AddComponent(TranslationComponent component)
        {
            components.Add(component);
        }
        public override void RemoveComponent(TranslationComponent component)
        {
            components.Remove(component);
        }

        public override void Translate(ITranslationService translationService)
        {
            translation = translationService.GetTranslations(text).First();
            foreach (TranslationComponent component in components) 
            {
                component.Translate(translationService);
            }
         
        }
        public List<TranslationComponent> GetTranslationComponents() 
        {
            return components;
        }
        public string GetTranslationText() 
        {
            return translation;
        }
    }
}
