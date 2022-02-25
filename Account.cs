using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKelompok
{
    class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Account()
        {

        }
        public Account(string firstName, string lastName, string password, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            UserName = userName;
        }
    }
}
