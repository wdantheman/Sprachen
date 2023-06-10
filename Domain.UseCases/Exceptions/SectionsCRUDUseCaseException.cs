using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Exceptions
{    
    public class SectionsCRUDUseCaseException : Exception
    {
        public SectionsCRUDUseCaseException(string message) : base(message)
        {
            
        }
    }

}
