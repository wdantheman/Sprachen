﻿using Domain.Entities;
using Domain.Entities.DataObjects.DocumentComposite;
using Domain.Entities.DataObjects.EntryComposite;
using Domain.UseCases.Exceptions;
using static System.Collections.Specialized.BitVector32;

namespace Domain.UseCases.EntriesUseCases
{
    public class EntryInSectionCRUDUseCase
    {
        internal IObjectIdentifierService IdentityCreator;
        internal IEntryConfigCriteria EntryConfigCriteria;
        public SectionComposite Section { get; internal set; }
        internal IEntryCreatorCriteria EntryCreatorCriteria;
        public EntryInSectionCRUDUseCase(IObjectIdentifierService idCreator, IEntryConfigCriteria entryConfigCriteria, 
            SectionComposite section, IEntryCreatorCriteria creatorCriteria)
        {
            IdentityCreator = idCreator;
            EntryConfigCriteria = entryConfigCriteria;
            Section = section;
            EntryCreatorCriteria = creatorCriteria;
        }
        public void ResetSection(SectionComposite section)
        {
            Section = section;
        }
        public void AddEmptyEntryInSection() 
        {
            CreateEntryUseCase EntryCreator = new CreateEntryUseCase(IdentityCreator, EntryCreatorCriteria);
            Entry newEmptyEntry = EntryCreator.CreateEmptyEntry(Section.SourceDocument);
            EntryTranslationBlock newTranslationBlock = new EntryTranslationBlock(Section.LanguagesComponent);
            if (Section.TranslationComponents == null)
            {
                Dictionary<Entry, EntryTranslationBlock> TempDic = new Dictionary<Entry, EntryTranslationBlock>
                {
                    { newEmptyEntry, newTranslationBlock }
                };
                Section.SetTranslationComponents(TempDic);
            }
            else
            {
                Dictionary<Entry, EntryTranslationBlock> TempDic = Section.TranslationComponents.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                TempDic.Add(newEmptyEntry, newTranslationBlock);
                Section.SetTranslationComponents(TempDic);
            }
        }
        public void AddNewEntryInSection(string content)
        {
            CreateEntryUseCase EntryCreator = new CreateEntryUseCase(IdentityCreator, EntryCreatorCriteria);
            Entry newEntry = EntryCreator.CreateEntry(Section.SourceDocument, content);
            EntryTranslationBlock newTranslationBlock = new EntryTranslationBlock(Section.LanguagesComponent);
            if (Section.TranslationComponents == null)
            {
                Dictionary<Entry, EntryTranslationBlock> TempDic = new Dictionary<Entry, EntryTranslationBlock>
                {
                    { newEntry, newTranslationBlock }
                };
                Section.SetTranslationComponents(TempDic);
            }
            else
            {
                Dictionary<Entry, EntryTranslationBlock> TempDic = Section.TranslationComponents.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                TempDic.Add(newEntry, newTranslationBlock);
                Section.SetTranslationComponents(TempDic);
            }
        }

        public void AddEntryInSection(Entry entry)
        {
            if (!EntryConfigCriteria.IsEntryValidInSection(entry, Section))
            {
                throw new EntryInSectionCRUDUseCaseException("Couldn't add Entry, as Entry in Section is not Valid");
            }
            else
            {
                EntryTranslationBlock newTranslationBlock = new EntryTranslationBlock(Section.LanguagesComponent);
                Dictionary<Entry, EntryTranslationBlock> TempDic = Section.TranslationComponents;
                TempDic.Add(entry, newTranslationBlock);
                Section.SetTranslationComponents(TempDic);
            }
        }
        public Entry GetEntrybyId(int id)
        {
            if (Section.TranslationComponents.Keys.Where(entry => entry.Id == id).Count() == 0)
            {
                throw new EntryInSectionCRUDUseCaseException("the Entry Id didn't returned results");
            }
            else if (Section.TranslationComponents.Keys.Where(entry => entry.Id == id).Count() > 1)
            {
                return Section.TranslationComponents.Keys.Where(entry => entry.Id == id).First();
                throw new EntryInSectionCRUDUseCaseException("the Entry Id had a duplicated id, the first result was returned");
            }
            else
            {
                return Section.TranslationComponents.Keys.Where(entry => entry.Id == id).First();
            }
        }
        public Entry GetEntryByContent(string content)
        {
            if (Section.TranslationComponents.Keys.Where(entry => entry.Content == content).Count() == 0)
            {
                throw new EntryInSectionCRUDUseCaseException("the Entry Id didn't returned results");
            }
            else if (Section.TranslationComponents.Keys.Where(entry => entry.Content == content).Count() > 1)
            {
                return Section.TranslationComponents.Keys.Where(entry => entry.Content == content).First();
                throw new EntryInSectionCRUDUseCaseException("the Entry Id had a duplicated id, the first result was returned");
            }
            else
            {
                return Section.TranslationComponents.Keys.Where(entry => entry.Content == content).First();
            }
        }
        public void UpdateEntryContentById(int entryId, string newEntryContent)
        {

            this.AddNewEntryInSection(newEntryContent);
        }
        public void DeleateEntryById(int entryId)
        {
            Entry? EntryToDeleate =  Section.TranslationComponents.Keys.SingleOrDefault(entry => entry.Id == entryId);
            Dictionary<Entry, EntryTranslationBlock> TempDic = Section.TranslationComponents;
            if (EntryToDeleate == null)
            {
                throw new EntryInSectionCRUDUseCaseException("There is no Entry to remove");
            }
            else if (!EntryConfigCriteria.CanEntryBeRemovedFromSection(EntryToDeleate, Section))
            {
                throw new SectionsCRUDUseCaseException("Entry couldn't be Removed");
            }
            else
            {
                TempDic.Remove(EntryToDeleate);
                Section.SetTranslationComponents(TempDic);
            }
        }
        public void DeleateEntryByContent(string content)
        {
            Entry? EntryToDeleate = Section.TranslationComponents.Keys.SingleOrDefault(entry => entry.Content == content);
            Dictionary<Entry, EntryTranslationBlock> TempDic = Section.TranslationComponents;
            if (EntryToDeleate == null)
            {
                throw new EntryInSectionCRUDUseCaseException("There is no Entry to remove");
            }
            else if (!EntryConfigCriteria.CanEntryBeRemovedFromSection(EntryToDeleate, Section))
            {
                throw new SectionsCRUDUseCaseException("Entry couldn't be Removed");
            }
            else
            {
                TempDic.Remove(EntryToDeleate);
                Section.SetTranslationComponents(TempDic);
            }
        }
    }
}
