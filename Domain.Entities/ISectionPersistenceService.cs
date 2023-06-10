using Domain.Entities.DataObjects.DocumentComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface ISectionPersistenceService
    {
        public void CreateSectionInDocument(int documentId, SectionComponent section);
        public void DeleteSectionInDocument(int documentId, int sectionId);
        public void UpdateSectionInDocument(int documentId, int sectionId, SectionComponent newSection);
        public SectionComponent ReadSectionInDocument(int documentId, int sectionId);

    }
}
