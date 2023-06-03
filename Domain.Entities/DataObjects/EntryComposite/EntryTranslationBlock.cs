﻿using Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DataObjects.EntryComposite
{
    internal class EntryTranslationBlock
    {
        internal List<Language> targetLanguages;
        internal Dictionary<Language, TranslationComponent> targetTranslations;
        public EntryTranslationBlock(List<Language> languages)
        {
            targetLanguages = languages;
            targetTranslations = new Dictionary<Language, TranslationComponent>();
        }
        public void AddtargetLanguage(Language sprachen)
        {
            targetLanguages.Add(sprachen);
            targetLanguages = targetLanguages.Distinct().ToList();
        }
        public void RemovetargetLanguage(Language sprachen) 
        {
            targetLanguages.Remove(sprachen);
        }

    }
}
