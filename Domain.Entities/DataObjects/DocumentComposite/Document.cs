﻿using Domain.Entities.Exceptions;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public class Document
    {
        public int SystemId { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        internal List<SectionComponent> Sections { get; private set; }
        internal LanguagesComponent LanguagesComponent;
        
        public Document(int id, string name, List<SectionComponent> sections, LanguagesComponent languagesComponent)
        {
            if (sections == null)
            {
                throw new DocumentException("Sections cannot be null");
            }
            Name = name;
            SystemId= id;
            Description = string.Empty;
            Sections = sections;
            LanguagesComponent = languagesComponent;
        }
        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }
        public void SetSections(List<SectionComponent> sections)
        {
            Sections = sections;
        }
        public List<SectionComponent> GetSections() 
        {
            return Sections;
        }
        public LanguagesComponent GetLanguageComponent() 
        {
            return LanguagesComponent;
        }

        public void SetLanguageComponent(LanguagesComponent languages) 
        {
            LanguagesComponent = languages;
        }
        public void SetName(string name) 
        {
            Name = name;
        }
    }
}
