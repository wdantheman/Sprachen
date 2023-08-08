using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Exceptions
{
    public class PersistenceEntryInSectionCRUDUseCaseException : ArgumentException
    {
        internal string message { get; set; }
        public PersistenceEntryInSectionCRUDUseCaseException(string message)
        {
            this.message = message;
        }
    }
}
