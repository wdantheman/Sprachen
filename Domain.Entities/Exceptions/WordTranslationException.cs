using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    public class WordTranslationException : ArgumentException
    {
        string data;
        public WordTranslationException(string display)
        {
            data = display;
        }
    }
}
