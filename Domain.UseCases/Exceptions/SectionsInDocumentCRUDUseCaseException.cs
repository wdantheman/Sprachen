using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Exceptions
{
    public class SectionsInDocumentCRUDUseCaseException : ArgumentException
    {
        internal string message { get; set; }
        public SectionsInDocumentCRUDUseCaseException(string message)
        {
            this.message = message;
        }
    }
}
