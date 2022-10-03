using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._ООП__1___Класс
{
    enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,
    }

    internal class Student//описуємо студента
    {
        //конструктори:
        public Student()
        {

        }
        public Student(string lastName)
        {
            _lastName = lastName;
        }
        public Student(int age)
        {
            this.age = age;
        }
        public Student(DateTime birthday)
        {
            this.birthday = birthday;
            if (age is 0)
            {
                age = today.Year - birthday.Year;
            }
            if (birthday.Date > today.AddYears(-age)) age--;
        }
        public Student(DateTime birthday, int age)
        {
            this.birthday = birthday;
            this.age = age;
        }
        public Student(string lastName, int age)
        {
            _lastName = lastName;
            this.age = age;
        }
        public Student(string lastName, DateTime birthday)
        {
            _lastName = lastName;
            this.birthday = birthday;
            if (age is 0)
            {
                age = today.Year - birthday.Year;
            }
            if (birthday.Date > today.AddYears(-age)) age--;

        }
        public Student(string lastName, string firstName)
        {
            _lastName = lastName;
            _firstName = firstName;
        }
        public Student(string lastName, string firstName, int age)
        {
            _lastName = lastName;
            _firstName = firstName;
            this.age = age;
        }
        public Student(string lastName, string firstName, DateTime birthday)
        {
            _firstName = firstName;
            _lastName = lastName;
            this.birthday = birthday;
            if (age is 0)
            {
                age = today.Year - birthday.Year;
            }
            if (birthday.Date > today.AddYears(-age)) age--;
        }
        public Student(string lastName, string firstName, string middleName)
        {
            _lastName = lastName;
            _firstName = firstName;
            _middleName = middleName;
        }
        public Student(string lastName, string firstName, string middleName, int age)
        {
            _lastName = lastName;
            _firstName = firstName;
            _middleName = middleName;
            this.age = age;
        }
        public Student(string lastName, string firstName, string middleName, DateTime birthday)
        {
            _lastName = lastName;
            _firstName = firstName;
            _middleName = middleName;
            this.birthday = birthday;
            if (age is 0)
            {
                age = today.Year - birthday.Year;
            }
            if (birthday.Date > today.AddYears(-age)) age--;
        }
        //тут описано дію слова this:
        public Student(string lastName, string firstName, string middleName, DateTime birthday, int age)
        {
            _lastName = lastName;
            _firstName = firstName;
            _middleName = middleName;
            this.birthday = birthday;
            this.age = age; //this.age - ми звертаємо до age який знаходиться в цьому класі
        }
        public Student(Student student)
        {
            _firstName = student._firstName;
            _lastName = student._lastName;
            _middleName = student._middleName;
            birthday = student.birthday;
            age = age;
        }

        private readonly string _id = Guid.NewGuid().ToString(); //Guid - структура яка використовується для свторення унікальних id
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private int age;
        private DateTime birthday;
        private readonly DateTime today = DateTime.Today;

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }
        public void SetMiddleName(string middleName)
        {
            _middleName = middleName;
        }
        public void SetBirthday(DateTime birthday)
        {
            this.birthday = birthday;
            if (age is 0)
            {
                age = today.Year - birthday.Year;
            }
            if (birthday.Date > today.AddYears(-age)) age--;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }
        public void Print()
        {
            Console.WriteLine($"ID: {_id} | Name: {_firstName} | Last Name: {_lastName} | " +
                            $"Middle Name: {_middleName} | Age: {age} | Birthday: {birthday}");
        }

        public string GetFullName() //як варіант виведення інформації
        {
            return $"{_firstName} {_lastName} {_middleName}";
        }
        public string GetAge()
        {
            return $"{age}";
            if (age is 0)
            {
                return $"{age = today.Year - birthday.Year}";
            }
            else age = 0;
            if (birthday.Date > today.AddYears(-age)) age--;
            else age = 0;
        }
        public string GetId()
        {
            return $"{_id}";
        }
        public string GetBirthDate()
        {
            return $"{birthday}";
        }

        //АЛЕ наш клас залежний від консолі
        //тобто відбувається порушення "культури" написання коду Dependаncy Injection
    }
}
