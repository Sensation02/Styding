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

        public partial string GerFullName() //це сігнатура метода, вона може бути розділена з самим виконанням
                                            //тобто дописується partial в назву метода і виноситья в клас Person
        {
            return FirstName + " " + LastName;
        }

        public partial void PrintFullName()
        {
            Console.WriteLine(GerFullName());
        }
        public partial void PrintName()
        {
            Console.WriteLine($"My name is {FirstName}");
        }

        public void Drive(Car car)
        {
            car.Drive();
        }
    }
}
