

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class Document
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        internal List<SectionComponent> Sections;

        public Document(int id, string name, List<SectionComponent> sections)
        {
            Name= name;
            Id= id;
            Description = string.Empty;
            Sections = sections;
        }
        public void addDescription(string description) 
        {
            Description= description;
        }

        public void addSection(SectionComponent section) 
        {
            Sections.Add(section);
        }
        public void removeSection(int sectionId) 
        {
            SectionComponent itemToRemove = Sections.FirstOrDefault(item => item.docId == sectionId);
            if (itemToRemove != null)
            {
                Sections.Remove(itemToRemove);
            }
        }
        public List<SectionComponent> GetSections() 
        {
            return Sections;
        }

    }
}
