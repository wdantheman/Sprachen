using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Tests.DataObjectsTest.EntryCompositeTests
{
    public class MockTranslationService : ITranslationService
    {
        public List<string> Meanings { get; private set; }

        public MockTranslationService()
        {
            Meanings = new List<string> { "Definition 1", "Definition 2" };
        }

        public List<string> GetMeaningsInTargetLanguage(string text)
        {
            return Meanings;
        }

        public List<string> GetTranslations(string text)
        {
            throw new NotImplementedException();
        }
    }
}
