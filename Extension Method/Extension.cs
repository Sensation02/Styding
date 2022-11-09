using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Method
{
    
    public static class Extensions
    {
        public static bool IsEven(this int i)
        // обовязково пишемо this, тоді це з"явиться як розширення у всіх перемінних типу даних int
        // які підключення до одного простору імен (Extension_Method)
        {
            return i % 2 == 0;
        }

        public static bool isDevided(this int i, int j) //зроблено для конкретного типу
        {
            return i % j == 0;
        }

        // в якості аргумента можна використовувати й інтерфейс
        // можливість звертатися до будь якого класу який реалізує IEnumerable
        public static string ConvertToString(this IEnumerable collection)
        {
            var result = "";
            foreach (var item in collection)
            {
                result += item.ToString() + ", \r\n";
            }
            return result;
        }

        // або, наприклад, ми отримали клас "дороги" з якоїсь бібліотеки і ми хочемо зробити
        // генератор випадкових доріг, тобто робимо розширення для класу доріг, який буде повертати нам
        // список доріг на основі вже існуючої дороги (але це не дуже правильно з точки зору архітектури)

        public static Road CreateRandomRoad(this Road road, int min, int max) 
            //створює якусь дорогу і яку буде нам повертати
        {
            var rnd = new Random(Guid.NewGuid().ToByteArray().Sum(x => x));
            road.Number = "M" + rnd.Next(1, 100);
            road.Lenght = rnd.Next(min, max);
            return road;
        }

    }
}
