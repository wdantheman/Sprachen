using Domain.Entities.DataObjects.EntryComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    internal abstract class SectionComponent
    {
        internal string title;
        internal int docId;
        internal List<Language> targetLanguages;
        internal Language sourceLanguage;

        public SectionComponent(string title, int id, List<Language> languages)
        {
            this.title = title;
            docId = id;
            targetLanguages = languages;
        }
        public abstract void AddSubsectionComponent(SectionComponent component);
        public abstract void RemoveSubsectionComponent(int id);
        public abstract void AddSourceLanguage(Language language);
        public abstract void AddTargetLanguage(Language language);
        public abstract void RemoveTargetLanguage(Language language);



    }
}
