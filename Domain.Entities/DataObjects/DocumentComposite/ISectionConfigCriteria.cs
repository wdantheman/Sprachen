using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.DocumentComposite
{
    public interface ISectionConfigCriteria
    {
        public bool IsSectionValid(SectionComponent section);
        public bool CanSectionBeRemoved(SectionComponent section);
        public bool AreSectionsValid(List<SectionComponent> section);
        
    }
}
