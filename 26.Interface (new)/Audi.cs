using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26.Interface__new_
{
    internal class Audi : ICar 
    {
        //реалізація інтерфейса
        //тобто в інтерфейсі ми задаємо що має бути, а тут реалізовуємо і це має бути обов"язково
        //створили новий інтерфейс? будь ласка добавляємо реалізацію в класи які його успадковують
        public int Move(int distance) 
        {
            return distance / 40;
        }
        public string StartEngine(string word)
        {
            if (word == "Start")
            {
                return "Engine started";
            }
            else
            {
                return "Start Engine!";
            }
        }
    }
}
