using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class SectionComposite : SectionComponent
    {
        public List<SectionComponent> Subsections { get; private set; }
        public Dictionary<string, EntryTranslationBlock> TranslationComponents { get; private set; }
        public SectionComposite(string title, int id, ILanguagesComponent lenguagesComponent) : 
            base(title, id, lenguagesComponent)
        {
            Subsections = new List<SectionComponent>();
            TranslationComponents = new Dictionary<string, EntryTranslationBlock>();
        }
        public void SetSubsections(List<SectionComponent> subsections) 
        {
            if (subsections == null) 
            {
                throw new SectionCompositeException("Subsections can't be null ");
            }
            Subsections.Clear();
            Subsections = subsections;
        }
        public void SetTranslationComponents(Dictionary<string, EntryTranslationBlock> translationComponents) 
        {
            translationComponents.Clear();
            TranslationComponents = translationComponents;
        }        
    }
}
