using Domain.Entities.DataObjects.DocumentComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PersistenceServices
{
    internal interface ISectionComponentPersistenceService
    {
        public void CreateSectionComponentInSection(int documentId, int sectionId, SectionComponent newSection);
        public SectionComponent ReadSectionComponentInSection(int documentId, int sectionComponent);
        public void UpdateSectionComponentInSection(int documentId, int sectionId, int SectionComponent, SectionComponent newComponent);
        public void RemoveSectionComponentInSection(int documentId, int sectionId, int sectionComponentId);

    }
}
