

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class Document
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        internal List<SectionComponent> Sections;
        internal List<Language> GeneralLanguages;
        internal Language DefaultLanguage;

        public Document(int id, string name, List<SectionComponent> sections)
        {
            Name= name;
            Id= id;
            Description = string.Empty;
            Sections = sections;
            GeneralLanguages = new List<Language>() { Language.English };
            DefaultLanguage = GeneralLanguages.FirstOrDefault();
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
            SectionComponent itemToRemove = Sections.FirstOrDefault(item => item.DocSectionId == sectionId);
            if (itemToRemove != null)
            {
                Sections.Remove(itemToRemove);
            }
        }
        public List<SectionComponent> GetSections() 
        {
            return Sections;
        }
        public List<Language> GetGeneralLanguages() 
        {
            return GeneralLanguages;
        }

        public void SetGeneralLanguages(List<Language> languages) 
        {
            GeneralLanguages = languages;
        }
        public void SetMainLanguage(Language language) 
        {
            DefaultLanguage = language;
        }
        public Language GetDefaultLanguage() 
        {
            return DefaultLanguage;
        }

    }
}
