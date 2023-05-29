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
        internal int id;
        public SectionComponent(string title, int id)
        {
            this.title = title;
            this.id = id;
        }
        public abstract void AddSubsectionComponent(SectionComponent component);
        public abstract void RemoveSubsectionComponent(int id);

    }
}
