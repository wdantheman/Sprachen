using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.EntriesUseCases
{
    public class EntryInSectionCRUDUseCase
    {
        internal IObjectIdentifierService IdentityCreator;
        internal SectionComposite Section;
        internal IEntryConfigCriteria EntryConfigCriteria;

        public EntryInSectionCRUDUseCase(IObjectIdentifierService idCreator, IEntryConfigCriteria entryCriteria, SectionComposite section)
        {
            IdentityCreator = idCreator;
            Section = section;
            EntryConfigCriteria = entryCriteria;
        }
        public void ResetSection(SectionComposite section)
        {
            Section = section;
        }


        public void CreateEmptyEntry() 
        {
            Entry newEmptyEntry = new Entry(IdentityCreator.CreateSubObjectId(Section.DocSectionId), "  ");
            EntryTranslationBlock newTranslationBlock = new EntryTranslationBlock(Section.LanguagesComponent);
            Dictionary<Entry, EntryTranslationBlock> TempDic = Section.TranslationComponents;            
            TempDic.Add(newEmptyEntry, newTranslationBlock);
            Section.SetTranslationComponents(TempDic);
        }
        public void CreateNewEntry(Entry entry)
        {
            
        }
        public Entry GetEntrybyId()
        {
            
        }
        public Entry GetEntryByContent()
        {

        }
        public void UpdateEntry(int entryId, Entry newEntry)
        {

        }
        public void DeleateEntryById(int entryId)
        {

        }
        public void DeleateEntryByContent(string content)
        {

        }






    }
}
