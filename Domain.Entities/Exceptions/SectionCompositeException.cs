using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    public class SectionCompositeException : ArgumentException
    {
        string data;
        public SectionCompositeException(string messege) { data = messege; }
    }
}
