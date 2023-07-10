using Domain.Entities.DataObjects.DocumentComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Tests.SectionUseCasesTests
{
    public class SectionConfigCriteriaMock : ISectionConfigCriteria
    {
        public bool IsSectionValid(SectionComponent section)
        {
            // Basic implementation: Check if the section has a non-empty title
            if(section.Title == "Invalid Section") 
            {
                return false;
            }
            return !string.IsNullOrEmpty(section.Title);
        }

        public bool AreSectionsValid(List<SectionComponent> sections)
        {
            // Basic implementation: Check if all sections are valid based on IsSectionValid
            return sections.All(IsSectionValid);
        }

        public bool CanSectionBeRemoved(SectionComponent section)
        {
            // Basic implementation: Allow all sections to be removed
            if (section.Title == "Undeleatable") 
            {
                return false;
            }
            return true;
        }
    }
}
