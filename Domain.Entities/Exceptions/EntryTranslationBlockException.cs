using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    internal class EntryTranslationBlockException : ArgumentException
    {
        string data;        
        public EntryTranslationBlockException(string display) 
        {
            data= display;
        }
    }
}
