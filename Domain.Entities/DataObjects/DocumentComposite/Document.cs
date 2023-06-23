using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class Document
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        internal List<SectionComponent> Sections;
        internal LanguagesComponent LanguagesComponent;
        

        public Document(int id, string name, List<SectionComponent> sections)
        {
            Name= name;
            Id= id;
            Description = string.Empty;
            Sections = sections;
            LanguagesComponent = new LanguagesComponent();
        }
        public void AddDescription(string description) 
        {
            Description= description;
        }

        public void AddSection(SectionComponent section) 
        {
            Sections.Add(section);
        }
        public void RemoveSection(int sectionId) 
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
            return LanguagesComponent.GetTargetLanguages();
        }

        public void SetGeneralLanguages(List<Language> languages) 
        {
            foreach (var language in languages)
            {
                LanguagesComponent.AddTargetLanguage(language);
            }
        }
        public void SetMainLanguage(Language language) 
        {
            LanguagesComponent.SetSourceLanguage(language);
        }
        public Language GetDefaultLanguage() 
        {
            return LanguagesComponent.GetSourceLanguage();
        }
        public LanguagesComponent GetLanguagesComponent() 
        {
            return LanguagesComponent;
        }

    }
}
