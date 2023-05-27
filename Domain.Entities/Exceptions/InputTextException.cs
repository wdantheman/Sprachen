using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    public class InputTextException : ArgumentException
    {
        string data;
        public InputTextException(string messege) { data = messege; }

    }
}
