using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.EntryComposite
{
    internal abstract class TranslationComponent
    {
        internal string text;
        public TranslationComponent(string txt)
        {
            text = txt;
        }
        public abstract void AddComponent(TranslationComponent component);
        public abstract void RemoveComponent(TranslationComponent component);
        public abstract void AddTranslations(List<string> translations);
        public abstract string getText();

    }
}
