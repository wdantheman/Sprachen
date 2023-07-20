using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Exceptions
{
    public class EntryInSectionCRUDUseCaseException : ArgumentException
    {
        internal string message { get; set; }
        public EntryInSectionCRUDUseCaseException(string message)
        {
            this.message = message;
        }
    }
}
