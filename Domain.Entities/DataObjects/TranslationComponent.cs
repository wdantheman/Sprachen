using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects
{
    internal abstract class TranslationComponent
    {
        internal string text;
        public TranslationComponent(string txt)
        {
                text = txt;
        }
        public abstract void Add(TranslationComponent component);
        public abstract void Remove(TranslationComponent component);
        public abstract string getText();

    }
}
