using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Уроки
{
    internal class Person
    {
        public event Action GoToSleep; //створили подію що людина пішла спати

        //але використаний Action дає дуже мало інформації, він використовується
        //на практиці повинні передаватися якісь конкретні дані, дя цього можна користуватися і Func і Predicate
        //але частіше всього використовується спеціальний EventHandler - так званий шаблон делегата

        public event EventHandler DoWork;

        public string Name { get; set; }

        public void TakeTime(DateTime now)
        {
            if (now.Hour <= 8)
            {
                GoToSleep?.Invoke();
            }
            else
            {
                //var args = new EventArgs(); 
                //EventArgs використовується частіше всього в стандартних формах
                //але якщо нам не потрібно передавати якісь параметри а треба передати самий тип
                //то можна користуватися Null
                DoWork?.Invoke(this, null);
                //сюди () передаємо той об"єкт який був викликаний (це наш клас Person з використанням this)
                //та передаємо якісь дані
            }
        }

        //створили людину і метод по якому людина приймає якийсь час, якщо менше 8 годин - людина спить
        //якщо людина йде спати відповідно йде сповіщення
    }
}
