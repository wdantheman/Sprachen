using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }

        internal User(int id, string name, Email email)
        {
            Id = 0;
            Name = name;
            Email = email;
        }
        public static User CreateUser(int id, string name, Email email) 
        {
            return new User(id, name, email);
        }
    }
}
