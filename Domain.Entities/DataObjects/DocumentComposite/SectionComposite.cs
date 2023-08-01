using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Exceptions;
using System.Collections.Generic;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class SectionComposite : SectionComponent
    {
        public List<SectionComponent> Subsections { get; private set; }
        internal Dictionary<Entry, EntryTranslationBlock> TranslationComponents { get; set; }
        public int SourceDocument;
        public SectionComposite(string title, int id, ILanguagesComponent lenguagesComponent, int sourceDoc) : 
            base(title, id, lenguagesComponent)
        {
            Subsections = new List<SectionComponent>();
            TranslationComponents = new Dictionary<Entry, EntryTranslationBlock>();
            SourceDocument = sourceDoc;
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
        public void SetTranslationComponents(Dictionary<Entry, EntryTranslationBlock> translationComponents) 
        {
            TranslationComponents.Clear();
            TranslationComponents = translationComponents;
        }
        public Dictionary<Entry, EntryTranslationBlock> GetTranslationComponent() 
        {
            Dictionary <Entry, EntryTranslationBlock> temp = new Dictionary<Entry, EntryTranslationBlock>(TranslationComponents);
            return temp;
        }
    }
}
