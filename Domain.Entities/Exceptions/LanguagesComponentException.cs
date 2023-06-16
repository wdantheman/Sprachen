using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    public class LanguagesComponentException : Exception
    {
        public LanguagesComponentException() : base()
        {
        }

        public LanguagesComponentException(string message) : base(message)
        {
        }
    }

}
