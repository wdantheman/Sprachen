using Domain.Entities.DataObjects.DocumentComposite;


namespace Domain.Entities
{
    public interface ISectionComponentCRUDCriteria
    {
        public bool SubComponentCanBeAdded(SectionComponent component);
        public bool SubComponentCanBeRemoved(SectionComponent component);
    }
}
