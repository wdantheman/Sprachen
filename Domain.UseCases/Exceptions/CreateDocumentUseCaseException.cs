using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Exceptions
{
    public class CreateDocumentUseCaseException : ArgumentException
    {
        internal string message { get; set; }
        public CreateDocumentUseCaseException(string message)
        {
            this.message = message;
        }
    }
}
