using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects
{
    internal class Sentence : TranslationComponent
    {
        private List<TranslationComponent> components;
        public Sentence(string text) : base(text)
        {
            components = new List<TranslationComponent>();

        }
        public override void Add(TranslationComponent component)
        {
            components.Add(component);
        }

        public override string getText()
        {
            return text;
        }

        public override void Remove(TranslationComponent component)
        {
            components.Remove(component);
        }

    }
}
