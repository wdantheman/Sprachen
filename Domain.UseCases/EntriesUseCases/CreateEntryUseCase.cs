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
    public class CreateEntryUseCase
    {
        internal IObjectIdentifierService IdentifierService;
        internal IDocumentCreatorCriteria CreatorCriteria;
        public CreateEntryUseCase(IObjectIdentifierService objectIdCreator, IDocumentCreatorCriteria criteria)
        {
            IdentifierService = objectIdCreator;
            CreatorCriteria = criteria;
        }
        public Entry CreateEmptyEntry() 
        {
            Entry newEmptyEntry = new Entry(IdentifierService.CreateSubObjectId(Section.DocSectionId), "  ");
            EntryTranslationBlock newTranslationBlock = new EntryTranslationBlock(Section.LanguagesComponent);
            Dictionary<Entry, EntryTranslationBlock> TempDic = Section.TranslationComponents;            
            TempDic.Add(newEmptyEntry, newTranslationBlock);
            Section.SetTranslationComponents(TempDic);
        }

    }

}
