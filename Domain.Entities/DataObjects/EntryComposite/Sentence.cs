using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.EntryComposite
{
    internal class Sentence : TranslationComponent
    {
        private List<TranslationComponent> components;
        internal string translation;
        public Sentence(string text) : base(text)
        {
            components = new List<TranslationComponent>();
            translation = new string("");
        }
        public override void AddComponent(TranslationComponent component)
        {
            components.Add(component);
        }
        public override void RemoveComponent(TranslationComponent component)
        {
            components.Remove(component);
        }

        public override void AddTranslations(List<string> translations)
        {
            translation = translations.First();
        }

        public override string getText()
        {
            return text;
        }

    }
}
