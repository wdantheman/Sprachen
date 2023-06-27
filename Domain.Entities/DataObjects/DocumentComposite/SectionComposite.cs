using Domain.Entities.DataObjects.EntryComposite;
using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class SectionComposite : SectionComponent
    {
        internal List<SectionComponent> Subsections;
        internal Dictionary<string, EntryTranslationBlock> TranslationComponents { get; set; }
        internal ISectionComponentCRUDCriteria SectionComponentCRUDCriteria;
        public SectionComposite(string title, int id, ILanguagesComponent lenguagesComponent, ISectionComponentCRUDCriteria crudCriteria) : 
            base(title, id, lenguagesComponent)
        {
            Subsections = new List<SectionComponent>();
            TranslationComponents = new Dictionary<string, EntryTranslationBlock>();
            SectionComponentCRUDCriteria = crudCriteria;
        }
        public override void AddSectionComponent(SectionComponent sectionComponent)
        {
            if (SectionComponentCRUDCriteria.SubComponentCanBeAdded(sectionComponent))
                Subsections.Add(sectionComponent);
            else throw new SectionCompositeException("SectionComponent can't be added to SectionComposite");
        }
        public override void RemoveSectionComponent(SectionComponent sectionComponent)
        {
            if (SectionComponentCRUDCriteria.SubComponentCanBeAdded(sectionComponent))
                Subsections.Add(sectionComponent);
            else throw new SectionCompositeException("SectionComponent can't be Removed from SectionComposite");
        }
        public void SettranslationComponents(Dictionary<string, EntryTranslationBlock> translationComponents) 
        {
            translationComponents.Clear();
            TranslationComponents = translationComponents;
        }        
    }
}
