using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Tests.DataObjectsTest.EntryCompositeTests
{
    public class MockTranslationService : ITranslationService
    {
        public List<string> Definitions { get; private set; }
        public List<string> Translations { get; private set; }


        public MockTranslationService()
        {
            Definitions = new List<string> { "Definition 1 in target language", "Definition 2 in target language" };
            Translations = new List<string> { "translation 1", "translation 2", "translation 3" };
        }

        public List<string> GetMeaningsInTargetLanguage(string text)
        {
            return Definitions;
        }

        public List<string> GetTranslations(string text)
        {
            return Translations;
        }
    }
}
