using _21._ООП__1___Класс;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._ООП
{
    partial class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public Person()
        {

        }
        public Person(string firstName)
        {

        }
        public Person (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public partial string GerFullName();
        public partial void PrintFullName();
        public partial void PrintName();

        //ці часткові методи тут написані лише для того, щоб зрозуміти що вони взагалі є
    }
}
