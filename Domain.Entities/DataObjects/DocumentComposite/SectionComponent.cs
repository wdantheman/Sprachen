using Domain.Entities.DataObjects.EntryComposite;
namespace Domain.Entities.DataObjects.DocumentComposite
{
    public abstract class SectionComponent
    {
        public string Title { get; set; }
        internal int DocSectionId { get; private set; }
        public ILanguagesComponent LanguagesComponent { get; private set; }
        public SectionComponent(string title, int id, ILanguagesComponent languagesComponent)
        {
            Title = title;
            DocSectionId = id;
            LanguagesComponent = languagesComponent;
        }
        public void SetLanguageComponent(ILanguagesComponent languagesComponent) 
        {
            LanguagesComponent = languagesComponent;
        }
    }
}
