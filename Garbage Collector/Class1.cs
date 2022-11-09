using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collector
{
    internal class Class1 : IDisposable
    {
        public Class1()
        {
            // constructor
        }

        ~Class1()
        {
            // destructor
            // тут ми визначаємо поведінку коли буде знищуватися об"єкт класа
            // наприклад при роботі з потоком, щоб коректно його закрити
            // або якась дія яка буде виконана перед знищення об"єкта класа
        }

        public void Dispose()
        {
            // визначаємо як наш об"єкт має бути знищений, тобто

            // 1. щось із ним робимо
            // 2. закриваємо поток
            
            GC.Collect(); // чистимо після себе пам"ять
        }
    }
}
