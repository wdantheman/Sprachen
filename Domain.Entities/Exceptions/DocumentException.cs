using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    public class DocumentException : ArgumentException
    {
        string data;
        public DocumentException(string messege) { data = messege; }
    }
}
