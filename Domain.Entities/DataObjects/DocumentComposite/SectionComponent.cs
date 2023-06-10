using Domain.Entities.DataObjects.EntryComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public abstract class SectionComponent
    {
        public string title { get; set; }
        internal int DocSectionId;
        internal List<Language> targetLanguages;
        internal Language sourceLanguage;

        public SectionComponent(string title, int id, List<Language> languages)
        {
            this.title = title;
            DocSectionId = id;
            targetLanguages = languages;
        }
        public abstract void AddSubsectionComponent(SectionComponent component);
        public abstract void RemoveSubsectionComponent(int id);
        public abstract void SetSourceLanguage(Language language);
        public abstract void AddTargetLanguage(Language language);
        public abstract void RemoveTargetLanguage(Language language);
        public abstract Language GetSourceLanguage();
        public abstract List<Language> GetTargetLanguages();
        public abstract Dictionary<string, EntryTranslationBlock> GetEntries();
        public abstract void UpdateEntries(Dictionary<string, EntryTranslationBlock> entries);
        public abstract int GetComponetId();

    }
}
