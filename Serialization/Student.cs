using System;
using System.Runtime.Serialization;

namespace Serialization
{
    // створюємо структуру нашого класа який хочемо сеарілізувати
    // додаємо атрибут для серіалізації з метою захисту щоб не серіалізувати щось не те:
    // [Serializable] --- розкоментити для використання перший трьох типів серіалізації

    [DataContract]
    // цей тег атрибута використовується для JSON Serialization
    public class Student
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
        
        public Group Group { get; set; }

        public Student(string name, int age)
        {   
            // перевірка вхідних параметрів

            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
